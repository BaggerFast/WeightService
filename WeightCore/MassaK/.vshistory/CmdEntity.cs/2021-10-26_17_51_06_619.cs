﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Linq;

namespace WeightCore.MassaK
{
    public class CmdEntity
    {
        #region Public and private fields and properties

        public int WeightTare { get; set; }
        public int ScaleFactor { get; set; } = 1_000;

        #endregion

        #region Public and private methods

        public byte[] CmdSetTare()
        {
            byte[] data = new byte[CmdQueries.CMD_TCP_SET_TARE.Length];
            for (int i = 0; i < CmdQueries.CMD_TCP_SET_TARE.Length; i++)
            {
                data[i] = CmdQueries.CMD_TCP_SET_TARE[i];
            }
            data[6] = (byte)(WeightTare & 0xFF);
            data[7] = (byte)((byte)(WeightTare >> 0x08) & 0xFF);
            data[8] = (byte)((byte)(WeightTare >> 0x16) & 0xFF);
            data[9] = (byte)((byte)(WeightTare >> 0x32) & 0xFF);

            data[10] = ScaleFactor switch
            {
                10000 => 0x00,
                1000 => 0x01,
                100 => 0x02,
                10 => 0x03,
                1 => 0x04,
                _ => 0x01,
            };
            byte[] selected = data.Skip(5).Take(9).ToArray();
            _ = selected.Reverse();

            // Посчитать CRC-код.
            //short crc = ComputeCRC16CCITT(0, selected, 1);
            ushort crc = Crc16.ComputeChecksum(selected);
            //var crc2 = Utils.Crc16.ComputeCRC16CCITT(0, selected, 1);

            data[data.Length - 2] = (byte)(crc >> 0x08 & 0xFF);
            data[data.Length - 1] = (byte)(crc & 0xFF);

            return data;
        }

        public byte[] CmdSetZero()
        {
            byte[] data = new byte[CmdQueries.CMD_TCP_SET_ZERO.Length];
            for (int i = 0; i < CmdQueries.CMD_TCP_SET_ZERO.Length; i++)
            {
                data[i] = CmdQueries.CMD_TCP_SET_ZERO[i];
            }

            byte[] selected = data.Skip(5).Take(1).ToArray();
            _ = selected.Reverse();
            ushort crc = Crc16.ComputeChecksum(selected);

            data[data.Length - 2] = (byte)(crc >> 0x08 & 0xFF);
            data[data.Length - 1] = (byte)(crc & 0xFF);

            return data;
        }

        public byte[] CmdGetMassa()
        {
            byte[] data = new byte[CmdQueries.CMD_GET_MASSA.Length];
            for (int i = 0; i < CmdQueries.CMD_GET_MASSA.Length; i++)
            {
                data[i] = CmdQueries.CMD_GET_MASSA[i];
            }

            byte[] selected = data.Skip(5).Take(1).ToArray();
            _ = selected.Reverse();
            ushort crc = Crc16.ComputeChecksum(selected);

            data[data.Length - 2] = (byte)(crc >> 0x08 & 0xFF);
            data[data.Length - 1] = (byte)(crc & 0xFF);

            return data;
        }

        public byte[] CmdGetScalePar()
        {
            byte[] data = new byte[CmdQueries.CMD_GET_SCALE_PAR.Length];
            for (int i = 0; i < CmdQueries.CMD_GET_SCALE_PAR.Length; i++)
            {
                data[i] = CmdQueries.CMD_GET_SCALE_PAR[i];
            }

            byte[] selected = data.Skip(5).Take(1).ToArray();
            _ = selected.Reverse();
            ushort crc = Crc16.ComputeChecksum(selected);

            data[data.Length - 2] = (byte)(crc >> 0x08 & 0xFF);
            data[data.Length - 1] = (byte)(crc & 0xFF);

            return data;
        }

        public byte[] CmdSetName(string name = "xx")
        {
            var data = new byte[CmdQueries.CMD_SET_NAME.Length + name.Length + 2];
            int k = 0;
            for (var i = 0; i < CmdQueries.CMD_SET_NAME.Length; i++)
            {
                data[i] = CmdQueries.CMD_SET_NAME[i];
                k++;
            }

            for (var i = 0; (i < name.Length && i < 27); i++, k++)
            {
                data[k] = (byte)name.ToArray<char>()[i];
                k++;
            }

            data[k++] = 0x00;
            data[k++] = 0x00;

            data[4] = (byte)(1 + name.Length);
            data[5] = 0x00;


            var selected = data.Skip(6).Take(1 + name.Length).ToArray();
            selected.Reverse();
            var crc = Crc16.ComputeChecksum(selected);

            data[data.Length - 2] = (byte)((crc >> 0x08) & 0xFF);
            data[data.Length - 1] = (byte)(crc & 0xFF);

            return data;
        }

        public byte[] CmdGetName()
        {
            var data = new byte[CmdQueries.CMD_TCP_GET_NAME.Length];
            for (var i = 0; i < CmdQueries.CMD_TCP_GET_NAME.Length; i++)
            {
                data[i] = CmdQueries.CMD_TCP_GET_NAME[i];
            }

            var selected = data.Skip(5).Take(1).ToArray();
            selected.Reverse();
            var crc = Crc16.ComputeChecksum(selected);

            data[data.Length - 2] = (byte)((crc >> 0x08) & 0xFF);
            data[data.Length - 1] = (byte)(crc & 0xFF);

            return data;
        }

        public static byte[] CmdTcpGetTare()
        {
            var data = new byte[CmdQueries.CMD_TCP_GET_TARE.Length];
            for (var i = 0; i < CmdQueries.CMD_TCP_GET_TARE.Length; i++)
            {
                data[i] = CmdQueries.CMD_TCP_GET_TARE[i];
            }

            var selected = data.Skip(5).Take(1).ToArray();
            selected.Reverse();
            var crc = Crc16.ComputeChecksum(selected);

            data[data.Length - 2] = (byte)((crc >> 0x08) & 0xFF);
            data[data.Length - 1] = (byte)(crc & 0xFF);

            return data;
        }

        public byte[] CmdTcpSetRegnum(int Regnum)
        {
            var data = new byte[CmdQueries.CMD_TCP_SET_RGNUM.Length];
            for (var i = 0; i < CmdQueries.CMD_TCP_SET_RGNUM.Length; i++)
            {
                data[i] = CmdQueries.CMD_TCP_SET_RGNUM[i];
            }

            data[7] = (byte)(Regnum & 0xFF);
            data[8] = (byte)((byte)(Regnum >> 0x08) & 0xFF);
            data[9] = (byte)((byte)(Regnum >> 0x16) & 0xFF);
            data[10] = (byte)((byte)(Regnum >> 0x32) & 0xFF);

            var selected = data.Skip(5).Take(6).ToArray();
            selected.Reverse();

            // Посчитать CRC-код.
            //short crc = ComputeCRC16CCITT(0, selected, 1);
            var crc = Crc16.ComputeChecksum(selected);
            //var crc2 = Utils.Crc16.ComputeCRC16CCITT(0, selected, 1);

            data[data.Length - 2] = (byte)((crc >> 0x08) & 0xFF);
            data[data.Length - 1] = (byte)(crc & 0xFF);

            return data;
        }

        public byte[] CmdTcpSetDatetime(DateTime dt)
        {
            var data = new byte[CmdQueries.CMD_TCP_SET_DATETIME.Length];
            for (var i = 0; i < CmdQueries.CMD_TCP_SET_DATETIME.Length; i++)
            {
                data[i] = CmdQueries.CMD_TCP_SET_DATETIME[i];
            }

            data[7] = (byte)(dt.Year & 0xFF);
            data[8] = (byte)((byte)(dt.Month >> 0xFF) & 0xFF);
            data[9] = (byte)((byte)(dt.Day >> 0xFF) & 0xFF);
            data[10] = (byte)((byte)(dt.Hour >> 0xFF) & 0xFF);
            data[11] = (byte)((byte)(dt.Minute >> 0xFF) & 0xFF);
            data[12] = (byte)((byte)(dt.Second >> 0xFF) & 0xFF);

            return data;
        }

        public byte[] CmdTcpGetSys()
        {
            var data = new byte[CmdQueries.CMD_TCP_GET_SYS.Length];
            for (var i = 0; i < CmdQueries.CMD_TCP_GET_SYS.Length; i++)
            {
                data[i] = CmdQueries.CMD_TCP_GET_SYS[i];
            }

            return data;
        }

        public byte[] CmdTcpGetWeight()
        {
            var data = new byte[CmdQueries.CMD_TCP_GET_WEIGHT.Length];
            for (var i = 0; i < CmdQueries.CMD_TCP_GET_WEIGHT.Length; i++)
            {
                data[i] = CmdQueries.CMD_TCP_GET_WEIGHT[i];
            }

            var selected = data.Skip(5).Take(1).ToArray();
            selected.Reverse();
            var crc = Crc16.ComputeChecksum(selected);

            data[data.Length - 2] = (byte)((crc >> 0x08) & 0xFF);
            data[data.Length - 1] = (byte)(crc & 0xFF);

            return data;
        }


        #endregion
    }

    //public struct CmdResponseNameStruct
    //{
    //    public byte[] Data;
    //    public byte Header0;
    //    public byte Header1;
    //    public byte Header2;

    //    public Int16 Len;
    //    public byte Command;
    //    public Int32 ScalesID;
    //    public char[] Name;
    //    public Int16 CRC;

    //    public void Parse()
    //    {
    //        Header0 = Data[0];
    //        Header1 = Data[1];
    //        Header2 = Data[2];
    //        Len = BitConverter.ToInt16(Data.Skip(3).Take(2).ToArray(), 0);
    //        Command = Data[5];
    //        ScalesID = BitConverter.ToInt16(Data.Skip(6).Take(2).ToArray(), 0);
    //        //Name 
    //        //CRC = BitConverter.ToInt16(data.Skip(6).Take(2).ToArray(), 0);
    //    }
    //}

    //public struct CmdResponseStruct
    //{
    //    public byte[] data;
    //    public byte Header0;
    //    public byte Header1;
    //    public byte Header2;

    //    public Int16 Len;
    //    public byte Command;
    //    public Int16 CRC;
    //    public bool Parse()
    //    {
    //        Header0 = data[0];
    //        Header1 = data[1];
    //        Header2 = data[2];
    //        Len = BitConverter.ToInt16(data.Skip(3).Take(2).ToArray(), 0);
    //        Command = data[5];
    //        CRC = BitConverter.ToInt16(data.Skip(6).Take(2).ToArray(), 0);

    //        var selected = data.Skip(5).Take(Len).ToArray();
    //        selected.Reverse();
    //        var crc = Crc16.ComputeChecksum(selected);
    //        return (Int16)CRC == (Int16)crc;

    //    }
    //}
}
