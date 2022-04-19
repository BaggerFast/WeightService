﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.DAL.Models;
using System;

namespace DataCore.DAL.TableScaleModels
{
    /// <summary>
    /// Table "LogTypes".
    /// </summary>
    public class LogTypeEntity : BaseEntity
    {
        #region Public and private fields and properties

        public virtual byte Number { get; set; }
        public virtual string Icon { get; set; }

        #endregion

        #region Constructor and destructor

        public LogTypeEntity() : this(Guid.Empty)
        {
            //
        }

        public LogTypeEntity(Guid uid) : base(uid)
        {
            Number = 0x00;
            Icon = string.Empty;
        }

        #endregion

        #region Public and private methods

        public override string ToString()
        {
            return base.ToString() +
                   $"{nameof(Number)}: {Number}. " +
                   $"{nameof(Icon)}: {Icon}. ";
        }

        public virtual bool Equals(LogTypeEntity item)
        {
            if (item is null) return false;
            if (ReferenceEquals(this, item)) return true;
            return base.Equals(item) &&
                   Equals(Number, item.Number) &&
                   Equals(Icon, item.Icon);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((LogTypeEntity)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual bool EqualsNew()
        {
            return Equals(new LogTypeEntity());
        }

        public new virtual bool EqualsDefault()
        {
            return base.EqualsDefault() &&
                   Equals(Number, 0x00) &&
                   Equals(Icon, string.Empty);
        }

        public override object Clone()
        {
            LogTypeEntity item = (LogTypeEntity)base.Clone();
            item.Number = Number;
            item.Icon = Icon;
            return item;
        }

        #endregion
    }
}
