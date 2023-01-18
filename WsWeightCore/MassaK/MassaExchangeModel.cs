﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Linq;
using WeightCore.MassaK.Enums;

namespace WeightCore.MassaK;

public class MassaExchangeModel
{
	#region Public and private fields and properties

	private MassaRequestHelper MassaRequest { get; } = MassaRequestHelper.Instance;
	public byte[] Request { get; set; }
    private int ScaleFactor { get; } = 1_000;
    private int WeightTare { get; }
	public MassaCmdType CmdType { get; }
	public ResponseParseModel ResponseParse { get; set; }

	#endregion

	#region Constructor and destructor

	public MassaExchangeModel()
	{
        Request = Array.Empty<byte>();
        CmdType = MassaCmdType.Nack;
		ResponseParse = new(CmdType, Array.Empty<byte>());
	}

	public MassaExchangeModel(MassaCmdType cmdType)
	{
        Request = Array.Empty<byte>();
        CmdType = cmdType;
		ResponseParse = new(CmdType, Array.Empty<byte>());
	}

	public MassaExchangeModel(MassaCmdType cmdType, int weightTare, int scaleFactor = 1_000)
	{
        Request = Array.Empty<byte>();
        CmdType = cmdType;
        ResponseParse = new(CmdType, Array.Empty<byte>());
        WeightTare = weightTare;
		ScaleFactor = scaleFactor;
	}

	#endregion

	#region Public and private methods

	public byte[] CmdSetTare()
	{
		byte[] request = MassaRequest.CMD_SET_TARE;
		request[6] = (byte)(WeightTare & 0xFF);
		request[7] = (byte)((byte)(WeightTare >> 0x08) & 0xFF);
		request[8] = (byte)((byte)(WeightTare >> 0x16) & 0xFF);
		request[9] = (byte)((byte)(WeightTare >> 0x32) & 0xFF);
		CmdSetaTareScaleFactor(request);
		MassaRequest.MakeRequestCrcRecalc(request);
		return request;
	}

	private void CmdSetaTareScaleFactor(byte[] data)
	{
		data[10] = ScaleFactor switch
		{
			10000 => 0x00,
			1000 => 0x01,
			100 => 0x02,
			10 => 0x03,
			1 => 0x04,
			_ => 0x01,
		};
	}

	public byte[] CmdSetName(string name = "xx")
	{
		byte[] request = new byte[MassaRequest.CMD_SET_NAME.Length + name.Length + 2];
		int k = 0;
		for (int i = 0; i < MassaRequest.CMD_SET_NAME.Length; i++)
		{
			request[i] = MassaRequest.CMD_SET_NAME[i];
			k++;
		}
		for (int i = 0; i < name.Length && i < 27; i++, k++)
		{
			request[k] = (byte)name.ToArray()[i];
			k++;
		}
		request[k++] = 0x00;
		request[k++] = 0x00;
		request[4] = (byte)(1 + name.Length);
		request[5] = 0x00;
		MassaRequest.MakeRequestCrcRecalc(request);
		return request;
	}

	//public byte[] CmdTcpSetRegnum(int Regnum)
	//{
	//    byte[] request = _massaRequest.CMD_SET_RGNUM;
	//    request[7] = (byte)(Regnum & 0xFF);
	//    request[8] = (byte)((byte)(Regnum >> 0x08) & 0xFF);
	//    request[9] = (byte)((byte)(Regnum >> 0x16) & 0xFF);
	//    request[10] = (byte)((byte)(Regnum >> 0x32) & 0xFF);
	//    _massaRequest.CrcRecalc(request);
	//    return request;
	//}

	//public byte[] CmdSetDatetime(DateTime dt)
	//{
	//    byte[] data = _massaRequest.CMD_SET_DATETIME;
	//    data[7] = (byte)(dt.Year & 0xFF);
	//    data[8] = (byte)((byte)(dt.Month >> 0xFF) & 0xFF);
	//    data[9] = (byte)((byte)(dt.Day >> 0xFF) & 0xFF);
	//    data[10] = (byte)((byte)(dt.Hour >> 0xFF) & 0xFF);
	//    data[11] = (byte)((byte)(dt.Minute >> 0xFF) & 0xFF);
	//    data[12] = (byte)((byte)(dt.Second >> 0xFF) & 0xFF);
	//    return data;
	//}

	#endregion
}