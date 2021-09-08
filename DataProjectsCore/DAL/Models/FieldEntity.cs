﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataShareCore;

namespace DataProjectsCore.DAL.Models
{
    public class FieldEntity
    {
        #region Public and private fields and properties

        public ShareEnums.DbField Name { get; set; }
        public object Value { get; set; }

        #endregion

        #region Constructor and destructor

        public FieldEntity(ShareEnums.DbField name, object value)
        {
            Name = name;
            Value = value;
        }

        #endregion

        #region Public and private methods

        public virtual bool Equals(FieldEntity entity)
        {
            if (entity is null) return false;
            if (ReferenceEquals(this, entity)) return true;
            return Name.Equals(entity.Name) &&
                   Value.Equals(entity.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((FieldEntity)obj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}. " +
                   $"{nameof(Value)}: {Value}.";
        }

        #endregion
    }
}
