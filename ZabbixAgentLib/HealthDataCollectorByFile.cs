﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable StringLiteralTypo

namespace ZabbixAgentLib
{
    /// <summary>
    /// Сбор данных из файла.
    /// </summary>
    public class HealthDataCollectorByFile : IHealthDataCollector
    {
        #region Public and private fields and properties

        public Dictionary<string, string> Dict { get; set; }
        public DateTime StartDateTime { get; }
        public int RequestCount { get; private set; }
        public string SettingFileName { get; set; }

        #endregion

        #region Constructor and destructor

        public HealthDataCollectorByFile(Dictionary<string, string> dict)
        {
            Dict = dict;
            StartDateTime = DateTime.Now;
            RequestCount = 0;
        }

        #endregion

        #region Public and private methods

        [Obsolete(@"Используй ResponseStatus")]
        public string ResponseBuilderFunc()
        {
            return Response().ToString();
        }

        public StringBuilder Response()
        {
            var result = new StringBuilder();
            foreach (KeyValuePair<string, string> v in Dict)
            {
                result.AppendLine($"{v.Key}={v.Value}");
            }
            result.AppendLine($"CurrentTime={DateTime.Now.ToString(CultureInfo.InvariantCulture)};");
            TimeSpan interval = DateTime.Now - StartDateTime;
            result.AppendLine($"TimePassed={interval.ToString()};");
            result.AppendLine($"RequestCount={++RequestCount};");
            return result;
        }

        public void LoadValues()
        {
            Dict.Clear();
            if (File.Exists(SettingFileName))
            {
                var settingdata = File.ReadAllLines(SettingFileName);
                for (var i = 0; i < settingdata.Length; i++)
                {
                    var setting = settingdata[i];
                    var sidx = setting.IndexOf("=");
                    if (sidx >= 0)
                    {
                        var skey = setting.Substring(0, sidx);
                        var svalue = setting.Substring(sidx + 1);
                        //if (Dict.ContainsKey(skey))
                        //{
                        //    Dict.Remove(skey);
                        //}
                        Dict.Add(skey, svalue);

                    }
                }
            }
        }

        #endregion
    }
}
