﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Linq;

namespace WeightCore.MassaK
{
    public class ResponseMassaEntity
    {
        public int Weight;
        public int ScaleFactor;
        public byte _division;
        public byte Division
        {
            get => _division;
            set
            {
                _division = value;
                ScaleFactor = value switch
                {
                    0x00 => 10000,
                    0x01 => 1000,
                    0x02 => 100,
                    0x03 => 10,
                    0x04 => 1,
                    _ => 1000,
                };
            }
        }
        public byte Stable;
        public byte Net;
        public byte Zero;
        public int Tare;

        public ResponseMassaEntity(byte[] response)
        {
            Weight = BitConverter.ToInt32(response.Skip(6).Take(4).ToArray(), 0);
            Division = response[10];
            Stable = response[11];
            Net = response[12];
            Zero = response[13];
            Tare = BitConverter.ToInt32(response.Skip(14).Take(4).ToArray(), 0);
        }
    }
}