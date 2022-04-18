﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.DAL.Models;
using DataCore.DAL.TableScaleModels;

namespace DataCore.DAL.DataModels
{
    public class DeviceEntity : BaseEntity<DeviceEntity>
    {
        #region Public and private fields and properties

        public virtual ScaleEntity Scales { get; set; }

        #endregion

        #region Constructor and destructor

        public DeviceEntity() : this(0)
        {
            //
        }

        public DeviceEntity(long id) : base(id)
        {
            Scales = new();
        }

        #endregion

        #region Public and private methods - override

        public override string ToString()
        {
            return $"{nameof(Scales)}: {Scales}.";
        }

        public override int GetHashCode()
        {
            return Scales.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is DeviceEntity entity)
            {
                return
                   Scales == null && entity.Scales == null || Scales != null && Scales.Equals(entity.Scales);
            }
            return false;
        }

        #endregion

        #region Public and private methods

        public virtual bool EqualsNew()
        {
            return Equals(new DeviceEntity());
        }

        public new virtual bool EqualsDefault()
        {
            if (Scales != null && !Scales.EqualsDefault())
                return false;
            return base.EqualsDefault();
        }

        public override object Clone()
        {
            DeviceEntity item = (DeviceEntity)base.Clone();
            item.Scales = (ScaleEntity)Scales.Clone();
            return item;
        }

        #endregion
    }
}
