﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;

namespace CoreTests
{
    /// <summary>
    /// Enumeration of values.
    /// </summary>
    public static class TestsEnums
    {
        /// <summary>
        /// List of bool values.
        /// </summary>
        /// <returns></returns>
        public static List<bool> GetBool()
        {
            return new List<bool>() { false, true };
        }

        /// <summary>
        /// List of string values.
        /// </summary>
        /// <returns></returns>
        public static List<string> GetString()
        {
            return new List<string>() { null, "", string.Empty };
        }

        public static List<Guid> GetGuid()
        {
            return new List<Guid> { Guid.Empty, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), };
        }

        public static List<decimal> GetDecimal()
        {
            return new List<decimal> { decimal.MinValue, decimal.MinValue / 2, 0, 1, decimal.MaxValue / 2, decimal.MaxValue };
        }

        /// <summary>
        /// List of ushort values.
        /// </summary>
        /// <returns></returns>
        public static List<ushort> GetUshort()
        {
            return new List<ushort>() { ushort.MinValue, 1, ushort.MaxValue / 2, ushort.MaxValue };
        }

        /// <summary>
        /// List of progress values.
        /// </summary>
        /// <returns></returns>
        public static List<ushort> GetProgress()
        {
            return new List<ushort>() { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 };
        }

        /// <summary>
        /// List of short values.
        /// </summary>
        /// <returns></returns>
        public static List<short> GetShort()
        {
            return new List<short>() { short.MinValue, 1, short.MaxValue / 2, short.MaxValue };
        }

        /// <summary>
        /// List of uint values.
        /// </summary>
        /// <returns></returns>
        public static List<uint> GetUint()
        {
            return new List<uint>() { uint.MinValue, 1, uint.MaxValue / 2, uint.MaxValue };
        }

        /// <summary>
        /// List of int values.
        /// </summary>
        /// <returns></returns>
        public static List<int> GetInt()
        {
            return new List<int>() { int.MinValue, 1, int.MaxValue / 2, int.MaxValue };
        }

        /// <summary>
        /// List of long values.
        /// </summary>
        /// <returns></returns>
        public static List<long> GetLong()
        {
            return new List<long>() { long.MinValue, 1, long.MaxValue / 2, long.MaxValue };
        }

        /// <summary>
        /// List of DateTime values.
        /// </summary>
        /// <returns></returns>
        public static List<DateTime> GetDateTime()
        {
            return new List<DateTime>() { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today, DateTime.UtcNow };
        }

        /// <summary>
        /// String value.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string AsString(this string str)
        {
            return str == null ? "<null>" : str == "" ? "<empty>" : str;
        }

        /// <summary>
        /// List of uri values.
        /// </summary>
        /// <returns></returns>
        public static List<Uri> GetUri()
        {
            return new List<Uri>() { new Uri("http://google.com/"), new Uri("http://microsoft.com/") };
        }

        /// <summary>
        /// List of timeout values in ms.
        /// </summary>
        /// <returns></returns>
        public static List<int> GetTimeoutMs()
        {
            return new List<int>() { 50, 500 };
        }

        /// <summary>
        /// List of bytes.
        /// </summary>
        /// <returns></returns>
        public static List<byte> GetBytes()
        {
            return new List<byte>() { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, };
        }
    }
}
