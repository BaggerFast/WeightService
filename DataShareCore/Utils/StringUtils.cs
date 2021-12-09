﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.IO;

namespace DataShareCore.Utils
{
    public static class StringUtils
    {
        public static string FormatDtRus(DateTime dt, bool useSeconds)
        {
            return useSeconds
                ? $"{dt.Day:D2}.{dt.Month:D2}.{dt.Year:D4} {dt.Hour:D2}:{dt.Minute:D2}.{dt.Second:D2}"
                : $"{dt.Day:D2}.{dt.Month:D2}.{dt.Year:D4} {dt.Hour:D2}:{dt.Minute:D2}";
        }
        
        public static string FormatDtEng(DateTime dt, bool useSeconds)
        {
            return useSeconds
                ? $"{dt.Year:D4}-{dt.Month:D2}-{dt.Day:D2} {dt.Hour:D2}:{dt.Minute:D2}.{dt.Second:D2}"
                : $"{dt.Year:D4}-{dt.Month:D2}-{dt.Day:D2} {dt.Hour:D2}:{dt.Minute:D2}";
        }
        
        public static string FormatCurDtRus(bool useSeconds)
        {
            DateTime dt = DateTime.Now;
            return useSeconds
                ? $"{dt.Day:D2}.{dt.Month:D2}.{dt.Year:D4} {dt.Hour:D2}:{dt.Minute:D2}.{dt.Second:D2}"
                : $"{dt.Day:D2}.{dt.Month:D2}.{dt.Year:D4} {dt.Hour:D2}:{dt.Minute:D2}";
        }

        public static string FormatCurDtEng(bool useSeconds)
        {
            DateTime dt = DateTime.Now;
            return useSeconds
                ? $"{dt.Year:D4}-{dt.Month:D2}-{dt.Day:D2} {dt.Hour:D2}:{dt.Minute:D2}.{dt.Second:D2}"
                : $"{dt.Year:D4}-{dt.Month:D2}-{dt.Day:D2} {dt.Hour:D2}:{dt.Minute:D2}";
        }
        
        public static string FormatCurTimeRus(bool useSeconds)
        {
            DateTime dt = DateTime.Now;
            return useSeconds
                ? $"{dt.Hour:D2}:{dt.Minute:D2}.{dt.Second:D2}"
                : $"{dt.Hour:D2}:{dt.Minute:D2}";
        }

        public static string FormatCurTimeEng(bool useSeconds)
        {
            DateTime dt = DateTime.Now;
            return useSeconds
                ? $"{dt.Hour:D2}:{dt.Minute:D2}.{dt.Second:D2}"
                : $"{dt.Hour:D2}:{dt.Minute:D2}";
        }

        public static char GetProgressChar(char ch)
        {
            return ch switch
            {
                '*' => '/',
                '/' => '|',
                '|' => '\\',
                '\\' => '-',
                '-' => '/',
                _ => '*',
            };
        }

        public static string GetProgressString(string s)
        {
            return s switch
            {
                "" => ".",
                "." => "..",
                ".." => "...",
                "..." => "",
                _ => "",
            };
        }

        public static string GetStringValueTrim(string value, int length)
        {
            return (value.Length > length) ? value.Substring(0, length) : value;
        }

        public static string? GetStringNullValueTrim(string? value, int length)
        {
            return (value != null && value.Length > length) ? value.Substring(0, length) : value;
        }

        public static void SetStringValueTrim(ref string value, int length, bool isGetFileName = false)
        {
            if (string.IsNullOrEmpty(value))
                return;
            if (isGetFileName)
                value = Path.GetFileName(value);
            if (value.Length > length)
                value = value.Substring(0, length);
        }
    }
}