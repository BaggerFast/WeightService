﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataProjectsCore;
using DataProjectsCore.DAL;
using DataShareCore.Memory;

namespace WeightCore.Managers
{
    public class ManagerFactoryMemory : ManagerBase
    {
        #region Public and private fields and properties

        public MemorySizeEntity MemorySize { get; private set; } = new MemorySizeEntity();

        #endregion

        #region Constructor and destructor

        public ManagerFactoryMemory()
        {
            Init(
                () => { CloseMethod(); },
                () => { ReleaseManaged(); },
                () => { ReleaseUnmanaged(); }
            );
        }

        #endregion

        #region Public and private methods

        public void Init()
        {
            Init(ProjectsEnums.TaskType.MemoryManager,
            () =>
            {
                //
            },
            1_000);
        }

        public void Open(SqlViewModelEntity sqlViewModel)
        {
            Open(sqlViewModel,
            () =>
            {
                MemorySize.Update();
            },
            null,
            null);
        }

        public new void CloseMethod()
        {
            base.CloseMethod();
        }

        public new void ReleaseManaged()
        {
            base.ReleaseManaged();

            MemorySize.Dispose();
            MemorySize = null;
        }

        public new void ReleaseUnmanaged()
        {
            base.ReleaseUnmanaged();
        }

        #endregion
    }
}
