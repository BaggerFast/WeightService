﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Drawing;

namespace DataCore.Utils;

public class DataUtils
{
    public static bool ByteEquals(byte[] a1, byte[] a2)
    {
        if (a1.Length != a2.Length)
            return false;

        for (int i = 0; i < a1.Length; i++)
            if (a1[i] != a2[i])
                return false;

        return true;
    }

    public static byte[] ByteClone(byte[] value)
    {
        byte[] result = new byte[value.Length];
        value.CopyTo(result, 0);
        return result;
    }

    public static string GetBytesLength(byte[]? value, bool isShowLabel)
    {
        if (value == null)
            return isShowLabel 
					? $"{LocaleCore.Strings.DataSizeVolume}: 0 {LocaleCore.Strings.DataSizeBytes}"
		            : $"0 {LocaleCore.Strings.DataSizeBytes}";
        if (Encoding.Default.GetString(value).Length > 1024 * 1024)
            return isShowLabel 
				? $"{LocaleCore.Strings.DataSizeVolume}: {(float)Encoding.Default.GetString(value).Length / 1024 / 1024:### ###.###} {LocaleCore.Strings.DataSizeMBytes}"
				: $"{(float)Encoding.Default.GetString(value).Length / 1024 / 1024:### ###.###} {LocaleCore.Strings.DataSizeMBytes}";
        if (Encoding.Default.GetString(value).Length > 1024)
            return isShowLabel
				? $"{LocaleCore.Strings.DataSizeVolume}: {(float)Encoding.Default.GetString(value).Length / 1024:### ###.###} {LocaleCore.Strings.DataSizeKBytes}"
				: $"{(float)Encoding.Default.GetString(value).Length / 1024:### ###.###} {LocaleCore.Strings.DataSizeKBytes}";
        return isShowLabel 
	        ? $"{LocaleCore.Strings.DataSizeVolume}: {Encoding.Default.GetString(value).Length:### ###} {LocaleCore.Strings.DataSizeBytes}"
	        : $"{Encoding.Default.GetString(value).Length:### ###} {LocaleCore.Strings.DataSizeBytes}";
    }

    public static string GetBytesLength(string value, bool isShowLabel)
    {
        List<byte> listBytes = new();
        foreach (char ch in value.ToArray())
        {
            listBytes.Add((byte)ch);
        }
        byte[] bytes = listBytes.ToArray();
        return GetBytesLength(bytes, isShowLabel);
    }

    public static object? GetDefaultValue(Type t)
    {
        if (t.IsValueType)
            return Activator.CreateInstance(t);
        return null;
    }

    public static string GetStringLength(string str)
    {
        if (string.IsNullOrEmpty(str))
            return $"{LocaleCore.Strings.DataSizeLength}: 0 {LocaleCore.Strings.DataSizeChars}";
        return $"{LocaleCore.Strings.DataSizeLength}: {str.Length:### ###} {LocaleCore.Strings.DataSizeChars}";
    }

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
}
