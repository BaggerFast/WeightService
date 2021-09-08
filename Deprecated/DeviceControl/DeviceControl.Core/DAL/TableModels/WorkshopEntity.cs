﻿using System;

namespace DeviceControl.Core.DAL.TableModels
{
    public class WorkshopEntity : BaseEntity
    {
        #region Public and private fields and properties

        public virtual DateTime? CreateDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual ProductionFacilityEntity ProductionFacility { get; set; } = new ProductionFacilityEntity();
        public virtual string Name { get; set; }
        public virtual Guid? IdRRef { get; set; }
        public virtual bool Marked { get; set; }

        #endregion

        #region Public and private methods

        public override string ToString()
        {
            var strProductionFacility = ProductionFacility != null ? ProductionFacility.Id.ToString() : "null";
            return base.ToString() +
                   $"{nameof(ProductionFacility)}: {strProductionFacility}. " +
                   $"{nameof(Name)}: {Name}. " +
                   $"{nameof(CreateDate)}: {CreateDate}. " +
                   $"{nameof(ModifiedDate)}: {ModifiedDate}. " +
                   $"{nameof(IdRRef)}: {IdRRef}. " +
                   $"{nameof(Marked)}: {Marked}. ";
        }

        public virtual bool Equals(WorkshopEntity entity)
        {
            if (entity is null) return false;
            if (ReferenceEquals(this, entity)) return true;
            return base.Equals(entity) &&
                   Equals(CreateDate, entity.CreateDate) &&
                   Equals(ModifiedDate, entity.ModifiedDate) &&
                   ProductionFacility.Equals(entity.ProductionFacility) &&
                   Equals(Name, entity.Name) &&
                   Equals(IdRRef, entity.IdRRef) &&
                   Equals(Marked, entity.Marked);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((WorkshopEntity)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual bool EqualsNew()
        {
            return Equals(new WorkshopEntity());
        }

        public new virtual bool EqualsDefault()
        {
            if (ProductionFacility != null && !ProductionFacility.EqualsDefault())
                return false;
            return base.EqualsDefault() &&
                   Equals(CreateDate, default(DateTime?)) &&
                   Equals(ModifiedDate, default(DateTime?)) &&
                   Equals(Name, default(string)) && 
                   Equals(IdRRef, default(Guid?)) &&
                   Equals(Marked, default(bool));
        }

        public override object Clone()
        {
            return new WorkshopEntity
            {
                Id = Id,
                CreateDate = CreateDate,
                ModifiedDate = ModifiedDate,
                ProductionFacility = (ProductionFacilityEntity)ProductionFacility?.Clone(),
                Name = Name,
                IdRRef = IdRRef,
                Marked = Marked,
            };
        }

        #endregion
    }
}