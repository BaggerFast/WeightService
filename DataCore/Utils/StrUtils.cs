﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DataCore.Utils;

public static class StrUtils
{
    public static string FormatDtLong => "{0:dd.MM.yy HH:mm:ss}";
    public static string FormatDtDefault => "{0:dd.MM.yy HH:mm}";
    public static string FormatDtShort => "{0:dd.MM.yy}";
    
    public static string FormatDtRus(DateTime dt, bool isShowSeconds) =>
	    isShowSeconds
		    ? $"{dt.Day:D2}.{dt.Month:D2}.{dt.Year:D4} {dt.Hour:D2}:{dt.Minute:D2}.{dt.Second:D2}"
		    : $"{dt.Day:D2}.{dt.Month:D2}.{dt.Year:D4} {dt.Hour:D2}:{dt.Minute:D2}";

    public static string FormatDtRus(DateTime dt, bool isShowHours, bool isShowSeconds) =>
	    isShowSeconds
		    ? isShowHours 
			    ? $"{dt.Day:D2}.{dt.Month:D2}.{dt.Year:D4} {dt.Hour:D2}:{dt.Minute:D2}.{dt.Second:D2}"
				: $"{dt.Day:D2}.{dt.Month:D2}.{dt.Year:D4}"
		    : isShowHours
				? $"{dt.Day:D2}.{dt.Month:D2}.{dt.Year:D4} {dt.Hour:D2}:{dt.Minute:D2}"
				: $"{dt.Day:D2}.{dt.Month:D2}.{dt.Year:D4}";

    public static string FormatDtEng(DateTime dt, bool isShowSeconds) =>
	    isShowSeconds
		    ? $"{dt.Year:D4}-{dt.Month:D2}-{dt.Day:D2} {dt.Hour:D2}:{dt.Minute:D2}.{dt.Second:D2}"
		    : $"{dt.Year:D4}-{dt.Month:D2}-{dt.Day:D2} {dt.Hour:D2}:{dt.Minute:D2}";

    public static string FormatCurDtRus(bool isShowSeconds)
    {
        DateTime dt = DateTime.Now;
        return isShowSeconds
            ? $"{dt.Day:D2}.{dt.Month:D2}.{dt.Year:D4} {dt.Hour:D2}:{dt.Minute:D2}.{dt.Second:D2}"
            : $"{dt.Day:D2}.{dt.Month:D2}.{dt.Year:D4} {dt.Hour:D2}:{dt.Minute:D2}";
    }

    public static string FormatCurDtEng(bool isShowSeconds)
    {
        DateTime dt = DateTime.Now;
        return isShowSeconds
            ? $"{dt.Year:D4}-{dt.Month:D2}-{dt.Day:D2} {dt.Hour:D2}:{dt.Minute:D2}.{dt.Second:D2}"
            : $"{dt.Year:D4}-{dt.Month:D2}-{dt.Day:D2} {dt.Hour:D2}:{dt.Minute:D2}";
    }

    public static string FormatCurTimeRus(bool isShowSeconds)
    {
        DateTime dt = DateTime.Now;
        return isShowSeconds
            ? $"{dt.Hour:D2}:{dt.Minute:D2}.{dt.Second:D2}"
            : $"{dt.Hour:D2}:{dt.Minute:D2}";
    }

    public static string FormatCurTimeEng(bool isShowSeconds)
    {
        DateTime dt = DateTime.Now;
        return isShowSeconds
            ? $"{dt.Hour:D2}:{dt.Minute:D2}.{dt.Second:D2}"
            : $"{dt.Hour:D2}:{dt.Minute:D2}";
    }

    public static char GetProgressChar(char ch) =>
	    ch switch
	    {
		    '*' => '/',
		    '/' => '|',
		    '|' => '\\',
		    '\\' => '-',
		    '-' => '/',
		    _ => '*'
        };

    public static string GetProgressString(string s) =>
	    s switch
	    {
		    "" => ".",
		    "." => "..",
		    ".." => "...",
		    "..." => "",
		    _ => ""
        };

    public static string GetStringValueTrim(string value, int length) => 
	    value.Length > length ? value[..length] : value;

    public static string? GetStringNullValueTrim(string? value, int length) => 
	    value is not null && value.Length > length ? value[..length] : value;

    public static void SetStringValueTrim(ref string value, int length, bool isGetFileName = false)
    {
        if (string.IsNullOrEmpty(value))
            return;
        if (isGetFileName)
            value = Path.GetFileName(value);
        if (value.Length > length)
            value = value[..length];
    }

    public static string Utf16ToUtf8(string utf16String)
    {
        /**************************************************************
         * Every .NET string will store text with the UTF16 encoding, *
         * known as Encoding.Unicode. Other encodings may exist as    *
         * Byte-Array or incorrectly stored with the UTF16 encoding.  *
         *                                                            *
         * UTF8 = 1 bytes per char                                    *
         *    ["100" for the ansi 'd']                                *
         *    ["206" and "186" for the russian 'κ']                   *
         *                                                            *
         * UTF16 = 2 bytes per char                                   *
         *    ["100, 0" for the ansi 'd']                             *
         *    ["186, 3" for the russian 'κ']                          *
         *                                                            *
         * UTF8 inside UTF16                                          *
         *    ["100, 0" for the ansi 'd']                             *
         *    ["206, 0" and "186, 0" for the russian 'κ']             *
         *                                                            *
         * We can use the convert encoding function to convert an     *
         * UTF16 Byte-Array to an UTF8 Byte-Array. When we use UTF8   *
         * encoding to string method now, we will get a UTF16 string. *
         *                                                            *
         * So we imitate UTF16 by filling the second byte of a char   *
         * with a 0 byte (binary 0) while creating the string.        *
         **************************************************************/

        // Storage for the UTF8 string
        string utf8String = string.Empty;

        // Get UTF16 bytes and convert UTF16 bytes to UTF8 bytes
        byte[] utf16Bytes = Encoding.Unicode.GetBytes(utf16String);
        byte[] utf8Bytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, utf16Bytes);

        // Fill UTF8 bytes inside UTF8 string
        for (int i = 0; i < utf8Bytes.Length; i++)
        {
            // Because char always saves 2 bytes, fill char with 0
            byte[] utf8Container = new byte[2] { utf8Bytes[i], 0 };
            utf8String += BitConverter.ToChar(utf8Container, 0);
        }

        // Return UTF8
        return utf8String;
    }

    public static byte[] StringToByteArray(string hex, ushort method)
    {
        switch (method)
        {
            case 1:
                return Enumerable.Range(0, hex.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                    .ToArray();
            default:
                int NumberChars = hex.Length;
                byte[] bytes = new byte[NumberChars / 2];
                for (int i = 0; i < NumberChars; i += 2)
                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                return bytes;
        }
    }

    public static string AnsiToUtf8(string text)
    {
        // encode the string as an ASCII byte array
        byte[] myASCIIBytes = Encoding.ASCII.GetBytes(text);

        // convert the ASCII byte array to a UTF-8 byte array
        byte[] myUTF8Bytes = Encoding.Convert(Encoding.ASCII, Encoding.UTF8, myASCIIBytes);

        // reconstitute a string from the UTF-8 byte array 
        return Encoding.UTF8.GetString(myUTF8Bytes);
    }

    public static decimal GetDecimalValue(string value)
    {
        //System.Globalization.CultureInfo cultureInfo = System.Globalization.CultureInfo.InvariantCulture;
        string convert = value.Replace(',', '.');
        if (decimal.TryParse(convert, out decimal result))
            return result;
        return 0M;
    }

    private static int NextInt32(Random random)
	{
        try
        {
            int firstBits = random.Next(0, 1 << 4) << 28;
            int lastBits = random.Next(0, 1 << 28);
            return firstBits | lastBits;
        }
        catch (Exception)
        {
	        return 0;
        }
	}

	public static decimal NextDecimal(decimal min, decimal max)
    {
        Random random = new();
        decimal result = min;
        if (max == min && min == 0)
        {
            return random.Next(0, 10);
        }

        try
        {
            byte scale = (byte)random.Next(29);
            bool sign = random.Next(2) == 1;
			result = new(NextInt32(random), NextInt32(random), NextInt32(random), sign, scale);
        }
        catch (Exception)
        {
	        //
        }
		
        if (result < min)
			result = min;
		if (result > max)
			result = max;
		return result;
	}
}