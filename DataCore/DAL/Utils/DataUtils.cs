﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace DataCore.DAL.Utils
{
    public static class DataUtils
    {
        #region Public and private methods

        public static object? GetDefaultValue(Type t)
        {
            if (t.IsValueType)
                return Activator.CreateInstance(t);
            return null;
        }

        public static byte[] CloneBytes(byte[] bytes)
        {
            byte[] result = new byte[bytes.Length];
            bytes.CopyTo(result, 0);
            return result;
        }

        public static string GetBytesLength(byte[] bytes)
        {
            if (bytes == null)
                return $"{LocalizationCore.Strings.Main.DataSizeVolume}: 0 {LocalizationCore.Strings.Main.DataSizeBytes}";
            if (Encoding.Default.GetString(bytes).Length > 1024 * 1024)
                return $"{LocalizationCore.Strings.Main.DataSizeVolume}: {(float)Encoding.Default.GetString(bytes).Length / 1024 / 1024:### ###.###} {LocalizationCore.Strings.Main.DataSizeMBytes}";
            if (Encoding.Default.GetString(bytes).Length > 1024)
                return $"{LocalizationCore.Strings.Main.DataSizeVolume}: {(float)Encoding.Default.GetString(bytes).Length / 1024:### ###.###} {LocalizationCore.Strings.Main.DataSizeKBytes}";
            return $"{LocalizationCore.Strings.Main.DataSizeVolume}: {Encoding.Default.GetString(bytes).Length:### ###} {LocalizationCore.Strings.Main.DataSizeBytes}";
        }

        public static string GetStringLength(string str)
        {
            if (string.IsNullOrEmpty(str))
                return $"{LocalizationCore.Strings.Main.DataSizeLength}: 0 {LocalizationCore.Strings.Main.DataSizeChars}";
            return $"{LocalizationCore.Strings.Main.DataSizeLength}: {str.Length:### ###} {LocalizationCore.Strings.Main.DataSizeChars}";
        }

        //public virtual async Task<byte[]> GetBytes(Stream stream, bool useBase64)
        public static byte[] GetBytes(Stream stream, bool useBase64)
        {
            MemoryStream memoryStream = new();
            //await stream.CopyToAsync(memoryStream);
            stream.CopyTo(memoryStream);

            if (useBase64)
            {
                string base64String = Convert.ToBase64String(memoryStream.ToArray(), Base64FormattingOptions.None);
                return Encoding.Default.GetBytes(base64String);
            }
            return memoryStream.ToArray();
        }

        public static Image GetImage(byte[] bytes, bool useBase64)
        {
            MemoryStream ms = new(bytes, 0, bytes.Length);
            ms.Write(useBase64 ? Convert.FromBase64String(bytes.ToString()) : bytes, 0, bytes.Length);
            return Image.FromStream(ms, true);
        }

        #endregion
    }
}