﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataProjectsCore.DAL.TableModels;
using Microsoft.Data.SqlClient;
using System;

namespace DataProjectsCore.DAL.Utils
{
    public static class TasksUtils
    {
        #region Public and private methods

        public static void SaveNullTask(TaskTypeDirect taskType, int scaleId, bool enabled)
        {
            using SqlConnection con = SqlConnectFactory.GetConnection();
            con.Open();
            using SqlCommand cmd = new(SqlQueries.DbScales.Tables.Tasks.InsertTask);
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@task_type_uid", taskType.Uid);
            cmd.Parameters.AddWithValue("@scale_id", scaleId);
            cmd.Parameters.AddWithValue("@enabled", enabled);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void SaveTask(TaskDirect task, bool enabled)
        {
            if (task == null)
                return;
            using SqlConnection con = SqlConnectFactory.GetConnection();
            con.Open();
            using SqlCommand cmd = new(SqlQueries.DbScales.Tables.Tasks.UpdateTask);
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@uid", task.Uid);
            cmd.Parameters.AddWithValue("@enabled", enabled);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static Guid GetTaskUid(string taskName)
        {
            Guid result = Guid.Empty;
            using (SqlConnection con = SqlConnectFactory.GetConnection())
            {
                con.Open();
                DataShareCore.Utils.StringUtils.SetStringValueTrim(ref taskName, 32);
                using (SqlCommand cmd = new(SqlQueries.DbScales.Tables.Tasks.GetTaskUid))
                {
                    cmd.Connection = con;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@task_type", taskName);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            result = SqlConnectFactory.GetValue<Guid>(reader, "UID");
                        }
                    }
                    reader.Close();
                }
                con.Close();
            }
            return result;
        }

        public static TaskDirect GetTask(Guid taskTypeUid, int scaleId)
        {
            TaskDirect result = null;
            using (SqlConnection con = SqlConnectFactory.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new(SqlQueries.DbScales.Tables.Tasks.GetTaskByTypeAndScale))
                {
                    cmd.Connection = con;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@task_type_uid", taskTypeUid);
                    cmd.Parameters.AddWithValue("@scale_id", scaleId);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            result = new TaskDirect
                            {
                                Uid = SqlConnectFactory.GetValue<Guid>(reader, "TASK_UID"),
                                TaskType = TasksTypeUtils.GetTaskType(SqlConnectFactory.GetValue<Guid>(reader, "TASK_TYPE_UID")),
                                Scale = ScalesUtils.GetScale(SqlConnectFactory.GetValue<int>(reader, "SCALE_ID")),
                                Enabled = SqlConnectFactory.GetValue<bool>(reader, "ENABLED")
                            };
                        }
                    }
                    reader.Close();
                }
                con.Close();
            }
            return result;
        }

        public static TaskDirect GetTask(Guid taskUid)
        {
            TaskDirect result = null;
            using (SqlConnection con = SqlConnectFactory.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new(SqlQueries.DbScales.Tables.Tasks.GetTaskByUid))
                {
                    cmd.Connection = con;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@task_uid", taskUid);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            result = new TaskDirect
                            {
                                Uid = SqlConnectFactory.GetValue<Guid>(reader, "TASK_UID"),
                                TaskType = TasksTypeUtils.GetTaskType(SqlConnectFactory.GetValue<Guid>(reader, "TASK_TYPE_UID")),
                                Scale = ScalesUtils.GetScale(SqlConnectFactory.GetValue<int>(reader, "SCALE_ID")),
                                Enabled = SqlConnectFactory.GetValue<bool>(reader, "ENABLED")
                            };
                        }
                    }
                    reader.Close();
                }
                con.Close();
            }
            return result;
        }

        #endregion
    }
}