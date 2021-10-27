﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WeightCore.MassaK
{
    public static class CmdQueries
    {
        // Установить тару.
        // byte Header[0] 0xF8 заголовочная последовательность
        // byte Header[1] 0x55 заголовочная последовательность
        // byte Header[2] 0xCE заголовочная последовательность
        // word Len 0x0005 длина тела сообщения
        // byte Command 0xA3 CMD_TCP_SET_TARE
        // int Tare 4 байта Масса тары в делениях
        // word CRC 2 байта CRC
        public static readonly byte[] CMD_TCP_SET_TARE = { 0xF8, 0x55, 0xCE, 0x05, 0x00, 0xA3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

    }
}
