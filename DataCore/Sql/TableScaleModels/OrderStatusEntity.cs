﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using DataCore.Sql.Models;
using System;

namespace DataCore.Sql.TableScaleModels
{
    /// <summary>
    /// Table "OrderStatuses".
    /// </summary>
    public class OrderStatusEntity : BaseEntity
    {
        #region Public and private fields and properties

        public virtual string OrderId { get; set; }
        public virtual DateTime CurrentDate { get; set; }
        public virtual byte CurrentStatus { get; set; }

        #endregion

        #region Constructor and destructor

        public OrderStatusEntity() : this(0)
        {
            //
        }

        public OrderStatusEntity(long id) : base(id)
        {
            OrderId = string.Empty;
            CurrentDate = DateTime.MinValue;
            CurrentStatus = 0x00;
        }

        #endregion

        #region Public and private methods

        public override string ToString() =>
            base.ToString() +
            $"{nameof(OrderId)}: {OrderId}. " +
            $"{nameof(CurrentDate)}: {CurrentDate}. " +
            $"{nameof(CurrentStatus)}: {CurrentStatus}. ";

        public virtual bool Equals(OrderStatusEntity item)
        {
            if (item is null) return false;
            if (ReferenceEquals(this, item)) return true;
            return base.Equals(item) &&
                   Equals(OrderId, item.OrderId) &&
                   Equals(CurrentDate, item.CurrentDate) &&
                   Equals(CurrentStatus, item.CurrentStatus);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((OrderStatusEntity)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual bool EqualsNew()
        {
            return Equals(new OrderStatusEntity());
        }

        public new virtual bool EqualsDefault()
        {
            return base.EqualsDefault(IdentityName) &&
                   Equals(OrderId, string.Empty) &&
                   Equals(CurrentDate, DateTime.MinValue) &&
                   Equals(CurrentStatus, (byte)0x00);
        }

        public new virtual object Clone()
        {
            OrderStatusEntity item = new();
            item.OrderId = OrderId;
            item.CurrentDate = CurrentDate;
            item.CurrentStatus = CurrentStatus;
            item.Setup(((BaseEntity)this).CloneCast());
            return item;
        }

        public new virtual OrderStatusEntity CloneCast() => (OrderStatusEntity)Clone();

        #endregion
    }
}