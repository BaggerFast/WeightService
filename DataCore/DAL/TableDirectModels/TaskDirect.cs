﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.DAL.Models;
using System;

namespace DataCore.DAL.TableDirectModels
{
    [Serializable]
    public class TaskDirect : BaseSerializeEntity<TaskDirect>
    {
        #region Public and private fields and properties

        public Guid Uid { get; set; } = default;
        public TaskTypeDirect TaskType { get; set; } = new TaskTypeDirect();
        public ScaleDirect Scale { get; set; } = new ScaleDirect();
        public bool Enabled { get; set; } = default;

        #endregion

        #region Constructor and destructor

        public TaskDirect()
        {
            //
        }

        public TaskDirect(Guid uid, long scaleId, string scaleDescription, Guid taskTypeUid, string taskType, bool enabled) : this()
        {
            Uid = uid;
            Scale = new ScaleDirect(scaleId, scaleDescription);
            TaskType = new TaskTypeDirect(taskTypeUid, taskType);
            Enabled = enabled;
            //TaskTypeUid = GetTaskTypeUid(taskName);
            //ScaleDescription = GetScaleDescription(scaleId);
            //Uid = SaveTask(TaskTypeUid, ScaleId, enabled);
            //GetTask(TaskTypeUid, ScaleId);
        }

        #endregion

        #region Public and private methods

        //

        #endregion
    }
}