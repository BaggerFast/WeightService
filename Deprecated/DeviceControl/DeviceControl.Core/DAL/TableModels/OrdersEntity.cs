﻿using System;

namespace DeviceControl.Core.DAL.TableModels
{
    public class OrdersEntity : BaseEntity
    {
        #region Public and private fields and properties

        public virtual OrderTypesEntity OrderTypes { get; set; } = new OrderTypesEntity();
        public virtual DateTime? ProductDate { get; set; }
        public virtual int? PlaneBoxCount { get; set; }
        public virtual int? PlanePalletCount { get; set; }
        public virtual DateTime? PlanePackingOperationBeginDate { get; set; }
        public virtual DateTime? PlanePackingOperationEndDate { get; set; }
        public virtual ScalesEntity Scales { get; set; } = new ScalesEntity();
        public virtual PluEntity Plu { get; set; } = new PluEntity();
        public virtual Guid? IdRRef { get; set; }
        public virtual TemplatesEntity Templates { get; set; } = new TemplatesEntity();
        public virtual DateTime? CreateDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }

        #endregion

        #region Public and private methods

        public override string ToString()
        {
            var strOrderTypes = OrderTypes != null ? OrderTypes.Id.ToString() : "null";
            var strScales = Scales != null ? Scales.Id.ToString() : "null";
            var strPlu = Plu != null ? Plu.Id.ToString() : "null";
            var strTemplates = Templates != null ? Templates.Id.ToString() : "null";
            return base.ToString() +
                   $"{nameof(OrderTypes)}: {strOrderTypes}. " +
                   $"{nameof(ProductDate)}: {ProductDate}. " +
                   $"{nameof(PlaneBoxCount)}: {PlaneBoxCount}. " +
                   $"{nameof(PlanePalletCount)}: {PlanePalletCount}. " +
                   $"{nameof(PlanePackingOperationBeginDate)}: {PlanePackingOperationBeginDate}. " +
                   $"{nameof(PlanePackingOperationEndDate)}: {PlanePackingOperationEndDate}. " +
                   $"{nameof(Scales)}: {strScales}. " +
                   $"{nameof(Plu)}: {strPlu}." +
                   $"{nameof(IdRRef)}: {IdRRef}." +
                   $"{nameof(Templates)}: {strTemplates}." +
                   $"{nameof(CreateDate)}: {CreateDate}." +
                   $"{nameof(ModifiedDate)}: {ModifiedDate}.";
        }

        public virtual bool Equals(OrdersEntity entity)
        {
            if (entity is null) return false;
            if (ReferenceEquals(this, entity)) return true;
            return base.Equals(entity) &&
                   OrderTypes.Equals(entity.OrderTypes) &&
                   Equals(ProductDate, entity.ProductDate) &&
                   Equals(PlaneBoxCount, entity.PlaneBoxCount) &&
                   Equals(PlanePalletCount, entity.PlanePalletCount) &&
                   Equals(PlanePackingOperationBeginDate, entity.PlanePackingOperationBeginDate) &&
                   Equals(PlanePackingOperationEndDate, entity.PlanePackingOperationEndDate) &&
                   Scales.Equals(entity.Scales) &&
                   Plu.Equals(entity.Plu) &&
                   Equals(IdRRef, entity.IdRRef) &&
                   Templates.Equals(entity.Templates) &&
                   Equals(CreateDate, entity.CreateDate) &&
                   Equals(ModifiedDate, entity.ModifiedDate);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((OrdersEntity)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual bool EqualsNew()
        {
            return Equals(new OrdersEntity());
        }

        public new virtual bool EqualsDefault()
        {
            if (OrderTypes != null && !OrderTypes.EqualsDefault())
                return false;
            if (Plu != null && !Plu.EqualsDefault())
                return false;
            if (Scales != null && !Scales.EqualsDefault())
                return false;
            if (Templates != null && !Templates.EqualsDefault())
                return false;
            return base.EqualsDefault() &&
                   Equals(ProductDate, default(DateTime?)) &&
                   Equals(PlaneBoxCount, default(int?)) &&
                   Equals(PlanePalletCount, default(int?)) &&
                   Equals(PlanePackingOperationBeginDate, default(DateTime?)) &&
                   Equals(PlanePackingOperationEndDate, default(DateTime?)) &&
                   Equals(IdRRef, default(Guid?)) &&
                   Equals(CreateDate, default(DateTime?)) &&
                   Equals(ModifiedDate, default(DateTime?));
        }

        public override object Clone()
        {
            return new OrdersEntity
            {
                Id = Id,
                OrderTypes = (OrderTypesEntity)OrderTypes?.Clone(),
                ProductDate = ProductDate,
                PlaneBoxCount = PlaneBoxCount,
                PlanePalletCount = PlanePalletCount,
                PlanePackingOperationBeginDate = PlanePackingOperationBeginDate,
                PlanePackingOperationEndDate = PlanePackingOperationEndDate,
                Scales = (ScalesEntity)Scales?.Clone(),
                Plu = (PluEntity)Plu?.Clone(),
                IdRRef = IdRRef,
                Templates = (TemplatesEntity)Templates?.Clone(),
                CreateDate = CreateDate,
                ModifiedDate = ModifiedDate,
            };
        }

        #endregion
    }
}
