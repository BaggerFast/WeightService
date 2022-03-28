﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.DAL.Models;
using System;
using System.Text;

namespace DataCore.DAL.TableScaleModels
{
    /// <summary>
    /// Таблица "Этикетки".
    /// </summary>
    public class LabelEntity : BaseEntity
    {
        #region Public and private fields and properties

        public virtual WeithingFactEntity WeithingFact { get; set; } = new WeithingFactEntity();
        public virtual DateTime CreateDate { get; set; } = default;
        public virtual byte[] Label { get; set; } = new byte[0];
        public virtual string LabelString
        {
            get => Label == null || Label.Length == 0 ? string.Empty : Encoding.Default.GetString(Label);
            set => Label = Encoding.Default.GetBytes(value);
        }
        public virtual string LabelInfo
        {
            get => GetBytesLength(Label);
            set => _ = value;
        }
        public virtual string Zpl { get; set; } = string.Empty;
        public virtual string ZplInfo
        {
            get => GetStringLength(Zpl);
            set => _ = value;
        }

        #endregion

        #region Constructor and destructor

        public LabelEntity()
        {
            PrimaryColumn = new PrimaryColumnEntity(ColumnName.Id);
        }

        #endregion

        #region Public and private methods

        public override string ToString()
        {
            string? strWeithingFact = WeithingFact != null ? WeithingFact.Id.ToString() : "null";
            return base.ToString() +
                   $"{nameof(WeithingFact)}: {strWeithingFact}. " +
                   $"{nameof(Label)}: {LabelString}. " +
                   $"{nameof(Zpl)}: {ZplInfo}. " +
                   $"{nameof(CreateDate)}: {CreateDate}. ";
        }

        public virtual bool Equals(LabelEntity entity)
        {
            if (entity is null) return false;
            if (ReferenceEquals(this, entity)) return true;
            return base.Equals(entity) &&
                   WeithingFact.Equals(entity.WeithingFact) &&
                   Equals(CreateDate, entity.CreateDate) &&
                   Equals(Label, entity.Label) &&
                   Equals(Zpl, entity.Zpl);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((LabelEntity)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual bool EqualsNew()
        {
            return Equals(new LabelEntity());
        }

        public new virtual bool EqualsDefault()
        {
            if (WeithingFact != null && !WeithingFact.EqualsDefault())
                return false;
            return base.EqualsDefault() &&
                   Equals(CreateDate, default(DateTime)) &&
                   Equals(Label, default(byte[])) &&
                   Equals(Zpl, default(string));
        }

        public override object Clone()
        {

            return new LabelEntity
            {
                PrimaryColumn = (PrimaryColumnEntity)PrimaryColumn.Clone(),
                Id = Id,
                WeithingFact = (WeithingFactEntity)WeithingFact.Clone(),
                CreateDate = CreateDate,
                Label = CloneBytes(Label),
                Zpl = Zpl,
            };
        }

        #endregion
    }
}