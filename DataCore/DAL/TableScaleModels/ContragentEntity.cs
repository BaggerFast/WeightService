﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.DAL.Models;
using System;

namespace DataCore.DAL.TableScaleModels
{
    /// <summary>
    /// Таблица "Контрагенты".
    /// </summary>
    [Obsolete(@"Use ContragentEntityV2")]
    public class ContragentEntity : BaseEntity
    {
        #region Public and private fields and properties

        public virtual DateTime CreateDate { get; set; } = default;
        public virtual DateTime ModifiedDate { get; set; } = default;
        public virtual string Name { get; set; } = string.Empty;
        public virtual bool? Marked { get; set; } = null;
        public virtual bool MarkedGui
        {
            get => Marked == true;
            set => Marked = value;
        }
        public virtual string SerializedRepresentationObject { get; set; } = string.Empty;

        #endregion

        #region Constructor and destructor

        public ContragentEntity()
        {
            PrimaryColumn = new PrimaryColumnEntity(ColumnName.Id);
        }

        #endregion

        #region Public and private methods

        public override string ToString()
        {
            return base.ToString() +
                $"{nameof(CreateDate)}: {CreateDate}. " +
                $"{nameof(ModifiedDate)}: {ModifiedDate}. " +
                $"{nameof(Marked)}: {Marked}." +
                $"{nameof(Name)}: {Name}. " +
                $"{nameof(SerializedRepresentationObject)}.Length: {SerializedRepresentationObject?.Length ?? 0}. ";
        }

        public virtual bool Equals(ContragentEntity entity)
        {
            if (entity is null) return false;
            if (ReferenceEquals(this, entity)) return true;
            return base.Equals(entity) &&
                   Equals(CreateDate, entity.CreateDate) &&
                   Equals(ModifiedDate, entity.ModifiedDate) &&
                   Equals(Name, entity.Name) &&
                   Equals(Marked, entity.Marked) &&
                   Equals(SerializedRepresentationObject, entity.SerializedRepresentationObject);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ContragentEntity)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual bool EqualsNew()
        {
            return Equals(new ContragentEntity());
        }

        public new virtual bool EqualsDefault()
        {
            return base.EqualsDefault() &&
                   Equals(CreateDate, default(DateTime)) &&
                   Equals(ModifiedDate, default(DateTime)) &&
                   Equals(Name, string.Empty) &&
                   Equals(Marked, default(bool?)) &&
                   Equals(SerializedRepresentationObject, string.Empty);
        }

        public override object Clone()
        {
            return new ContragentEntity
            {
                PrimaryColumn = (PrimaryColumnEntity)PrimaryColumn.Clone(),
                Id = Id,
                CreateDate = CreateDate,
                ModifiedDate = ModifiedDate,
                Name = Name,
                Marked = Marked,
                SerializedRepresentationObject = SerializedRepresentationObject,
            };
        }

        #endregion
    }
}