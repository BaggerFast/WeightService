﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataProjectsCore.DAL.TableModels;
using DataProjectsCore.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace DataProjectsCore.DAL.Utils
{
    public static class TasksTypeUtils
    {
        #region Public and private methods

        public static Guid GetTaskTypeUid(string taskTypeName)
        {
            Guid result = Guid.Empty;
            using (SqlConnection con = SqlConnectFactory.GetConnection())
            {
                con.Open();
                StringUtils.SetStringValueTrim(ref taskTypeName, 32);
                using (SqlCommand cmd = new SqlCommand(SqlQueries.DbScales.Tables.TaskTypes.GetTaskTypeUid))
                {
                    cmd.Connection = con;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@task_type", taskTypeName);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                result = SqlConnectFactory.GetValue<Guid>(reader, "UID");
                            }
                        }
                        reader.Close();
                    }
                }
                con.Close();
            }
            return result;
        }

        public static TaskTypeDirect GetTaskType(string name)
        {
            TaskTypeDirect result = new TaskTypeDirect();
            using (SqlConnection con = SqlConnectFactory.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SqlQueries.DbScales.Tables.TaskTypes.GetTasksTypesByName))
                {
                    cmd.Connection = con;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@task_name", name);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                result.Uid = SqlConnectFactory.GetValue<Guid>(reader, "UID");
                                result.Name = SqlConnectFactory.GetValue<string>(reader, "NAME");
                            }
                        }
                        reader.Close();
                    }
                }
                con.Close();
            }
            return result;
        }

        public static TaskTypeDirect GetTaskType(Guid uid)
        {
            TaskTypeDirect result = new TaskTypeDirect();
            using (SqlConnection con = SqlConnectFactory.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SqlQueries.DbScales.Tables.TaskTypes.GetTasksTypesByUid))
                {
                    cmd.Connection = con;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@task_uid", uid);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                result.Uid = SqlConnectFactory.GetValue<Guid>(reader, "UID");
                                result.Name = SqlConnectFactory.GetValue<string>(reader, "NAME");
                            }
                        }
                        reader.Close();
                    }
                }
                con.Close();
            }
            return result;
        }

        public static List<TaskTypeDirect> GetTasksTypes()
        {
            List<TaskTypeDirect> result = new List<TaskTypeDirect>();
            using (SqlConnection con = SqlConnectFactory.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SqlQueries.DbScales.Tables.TaskTypes.GetTasksTypes))
                {
                    cmd.Connection = con;
                    cmd.Parameters.Clear();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                result.Add(new TaskTypeDirect(
                                    SqlConnectFactory.GetValue<Guid>(reader, "UID"), SqlConnectFactory.GetValue<string>(reader, "NAME")));
                            }
                        }
                        reader.Close();
                    }
                }
                con.Close();
            }
            return result;
        }

        #endregion
    }
}