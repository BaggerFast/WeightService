﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataProjectsCore.Utils;
using DataShareCore.DAL.Models;
using Microsoft.Data.SqlClient;
using System;

namespace DataProjectsCore.DAL.TableModels
{
    [Serializable]
    public class LogTypeDirect : BaseSerializeEntity<LogTypeDirect>
    {
        #region Public and private fields and properties

        public Guid Uid { get; set; }
        public byte Number { get; set; }
        public string Icon { get; set; }

        #endregion

        #region Constructor and destructor

        public LogTypeDirect()
        {

        }

        public LogTypeDirect(Guid uid, byte number, string icon) : this()
        {
            Uid = uid;
            Number = number;
            Icon = icon;
        }

        #endregion

        #region Public and private methods

        public void Save(byte number, string icon)
        {
            using (SqlConnection con = SqlConnectFactory.GetConnection())
            {
                con.Open();
                StringUtils.SetStringValueTrim(ref icon, 32);
                using (SqlCommand cmd = new SqlCommand(SqlQueries.DbServiceManaging.Tables.Logs.AddLogType))
                {
                    cmd.Connection = con;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@number", number);
                    cmd.Parameters.AddWithValue("@icon", icon);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void Save()
        {
            Save(Number, Icon);
        }

        #endregion
    }
}