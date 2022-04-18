﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.DAL.Models;
using DataCore.DAL.TableDirectModels;
using DataCore.DAL.Utils;
using Microsoft.Data.SqlClient;
using MvvmHelpers;
using System.Collections.Generic;
using System.Threading;

namespace DataCore.DAL
{
    public class SqlViewModelEntity : BaseViewModel
    {
        #region Design pattern "Lazy Singleton"

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static SqlViewModelEntity _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static SqlViewModelEntity Instance => LazyInitializer.EnsureInitialized(ref _instance);

        #endregion

        #region Public and private fields and properties

        private ShareEnums.PublishType _publishType = ShareEnums.PublishType.Default;
        public ShareEnums.PublishType PublishType
        {
            get => _publishType;
            private set
            {
                _publishType = value;
                OnPropertyChanged();
            }
        }
        private string _publishDescription = "";
        public string PublishDescription
        {
            get => _publishDescription;
            private set
            {
                _publishDescription = value;
                OnPropertyChanged();
            }
        }
        private string _sqlInstance = "";
        public string SqlInstance
        {
            get => _sqlInstance;
            private set
            {
                _sqlInstance = value;
                OnPropertyChanged();
            }
        }
        private List<TaskDirect> _tasks = new();
        public List<TaskDirect> Tasks
        {
            get => _tasks;
            private set
            {
                _tasks = value;
                OnPropertyChanged();
            }
        }
        private List<TaskTypeDirect> _taskTypes = new();
        public List<TaskTypeDirect> TaskTypes
        {
            get => _taskTypes;
            private set
            {
                _taskTypes = value;
                OnPropertyChanged();
            }
        }
        public SqlConnectFactory SqlConnect { get; private set; } = SqlConnectFactory.Instance;

        #endregion

        #region Constructor and destructor

        public SqlViewModelEntity()
        {
            PublishType = ShareEnums.PublishType.Default;
            PublishDescription = "Неизвестный сервер";

            SqlInstance = GetInstance();
            if (SqlInstance.Equals("INS1"))
            {
                PublishType = ShareEnums.PublishType.Debug;
                PublishDescription = "Тестовый сервер";
            }
            else if (SqlInstance.Equals("SQL2019"))
            {
                PublishType = ShareEnums.PublishType.Dev;
                PublishDescription = "Сервер разработки";
            }
            else if (SqlInstance.Equals("LUTON"))
            {
                PublishType = ShareEnums.PublishType.Release;
                PublishDescription = "Продуктовый сервер";
            }

            TaskTypes = new List<TaskTypeDirect>();
            Tasks = new List<TaskDirect>();
        }

        public void SetupTasks(DataAccessEntity dataAccess, long? scaleId)
        {
            if (scaleId == null)
                return;

            TaskTypes = TasksTypeUtils.GetTasksTypes();

            Tasks = new List<TaskDirect>();
            foreach (TaskTypeDirect taskType in TaskTypes)
            {
                TaskDirect? task = TasksUtils.GetTask(dataAccess, taskType.Uid, (long)scaleId);
                if (task == null)
                {
                    TasksUtils.SaveNullTask(taskType, (long)scaleId, true);
                    task = TasksUtils.GetTask(dataAccess, taskType.Uid, (long)scaleId);
                }
                if (task != null)
                    Tasks.Add(task);
            }
        }

        public bool IsTaskEnabled(ProjectsEnums.TaskType taskType)
        {
            if (Tasks == null)
                return false;
            // Table [TASKS] don't has records.
            if (Tasks.Count == 0)
                return true;

            foreach (TaskDirect task in Tasks)
            {
                if (string.Equals(task.TaskType.Name, taskType.ToString(), System.StringComparison.InvariantCultureIgnoreCase))
                {
                    return task.Enabled;
                }
            }
            return false;
        }

        #endregion

        #region Public and private methods

        private string GetInstance()
        {
            string result = string.Empty;
            SqlConnect.ExecuteReader(SqlQueries.DbSystem.Properties.GetInstance, (SqlDataReader reader) =>
            {
                if (reader.Read())
                {
                    result = SqlConnect.GetValueAsString(reader, "InstanceName");
                }
            });
            return result;
        }

        #endregion
    }
}
