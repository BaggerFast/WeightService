﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace DataCore.Sql.TableScaleModels;

/// <summary>
/// Table "Scales".
/// </summary>
[Serializable]
public class ScaleEntity : BaseEntity
{
	#region Public and private fields, properties, constructor

	/// <summary>
	/// Identity name.
	/// </summary>
	[XmlElement] public static ColumnName IdentityName => ColumnName.Id;
	[XmlElement(IsNullable = true)] public virtual TemplateEntity? TemplateDefault { get; set; }
	[XmlElement(IsNullable = true)] public virtual TemplateEntity? TemplateSeries { get; set; }
	[XmlElement(IsNullable = true)] public virtual WorkShopEntity? WorkShop { get; set; }
	[XmlElement(IsNullable = true)] public virtual PrinterEntity? PrinterMain { get; set; }
	[XmlElement(IsNullable = true)] public virtual PrinterEntity? PrinterShipping { get; set; }
	[XmlElement] public virtual byte ShippingLength { get; set; }
	[XmlElement] public virtual HostEntity Host { get; set; }
	[XmlElement] public virtual string Description { get; set; }
	[XmlElement] public virtual string DeviceIp { get; set; }
	[XmlElement] public virtual short DevicePort { get; set; }
	[XmlElement] public virtual string DeviceMac { get; set; }
	[XmlElement(IsNullable = true)] public virtual short? DeviceSendTimeout { get; set; }
	[XmlElement(IsNullable = true)] public virtual short? DeviceReceiveTimeout { get; set; }
	[XmlElement] public virtual string DeviceComPort { get; set; }
	[XmlElement] public virtual string ZebraIp { get; set; }
    [XmlIgnore] public virtual string ZebraLink => string.IsNullOrEmpty(ZebraIp) ? string.Empty : $"http://{ZebraIp}";
    [XmlElement(IsNullable = true)] public virtual short? ZebraPort { get; set; }
    [XmlElement] public virtual int Number { get; set; }
    [XmlElement] public virtual int Counter { get; set; }
    [XmlElement(IsNullable = true)] public virtual int? ScaleFactor { get; set; }
    [XmlElement] public virtual bool IsShipping { get; set; }
    [XmlElement] public virtual bool IsOrder { get; set; }
    [XmlElement] public virtual bool IsKneading { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    public ScaleEntity() : this(0)
    {
        //
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public ScaleEntity(long id) : base(id)
    {
        TemplateDefault = null;
        TemplateSeries = null;
        WorkShop = null;
        Host = new();
        PrinterMain = null;
        PrinterShipping = null;
        ShippingLength = 0;
        Description = string.Empty;
        DeviceIp = string.Empty;
        DevicePort = 0;
        DeviceMac = string.Empty;
        DeviceSendTimeout = default;
        DeviceReceiveTimeout = default;
        DeviceComPort = string.Empty;
        ZebraIp = string.Empty;
        ZebraPort = default;
        Number = 0;
        Counter = 0;
        ScaleFactor = default;
        IsShipping = false;
        IsOrder = false;
        IsKneading = false;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public ScaleEntity(SerializationInfo info, StreamingContext context) : this()
    {
        //Id = info.GetInt64(nameof(Id));
        ShippingLength = info.GetByte(nameof(ShippingLength));
		Description = info.GetString(nameof(Description));
    }

    #endregion

    #region Public and private methods - override

    public override string ToString()
    {
        string strTemplateDefault = TemplateDefault != null ? TemplateDefault.IdentityId.ToString() : "null";
        string strTemplateSeries = TemplateSeries != null ? TemplateSeries.IdentityId.ToString() : "null";
        string strWorkShop = WorkShop != null ? WorkShop.IdentityId.ToString() : "null";
        string strPrinterMain = PrinterMain != null ? PrinterMain.IdentityId.ToString() : "null";
        string strPrinterShipping = PrinterShipping != null ? PrinterShipping.IdentityId.ToString() : "null";
        string strPrinterVehicle = PrinterShipping != null ? PrinterShipping.IdentityId.ToString() : "null";
        string strHost = Host.IdentityId.ToString();
        return
			$"{nameof(IdentityId)}: {IdentityId}. " + 
			base.ToString() +
			$"{nameof(Description)}: {Description}. " +
			$"{nameof(DeviceIp)}: {DeviceIp}. " +
			$"{nameof(DevicePort)}: {DevicePort}. " +
			$"{nameof(DeviceMac)}: {DeviceMac}. " +
			$"{nameof(DeviceSendTimeout)}: {DeviceSendTimeout}. " +
			$"{nameof(DeviceReceiveTimeout)}: {DeviceReceiveTimeout}. " +
			$"{nameof(DeviceComPort)}: {DeviceComPort}. " +
			$"{nameof(ZebraIp)}: {ZebraIp}. " +
			$"{nameof(ZebraPort)}: {ZebraPort}. " +
			$"{nameof(IsOrder)}: {IsOrder}. " +
			$"{nameof(Number)}: {Number}. " +
			$"{nameof(Counter)}: {Counter}. " +
			$"{nameof(TemplateDefault)}: {strTemplateDefault}. " +
			$"{nameof(TemplateSeries)}: {strTemplateSeries}. " +
			$"{nameof(ScaleFactor)}: {ScaleFactor}. " +
			$"{nameof(WorkShop)}: {strWorkShop}. " +
			$"{nameof(PrinterMain)}: {strPrinterMain}. " +
			$"{nameof(PrinterShipping)}: {strPrinterShipping}. " +
			$"{nameof(PrinterShipping)}: {strPrinterVehicle}. " +
			$"{nameof(IsShipping)}: {IsShipping}. " +
			$"{nameof(IsKneading)}: {IsKneading}. " +
			$"{nameof(ShippingLength)}: {ShippingLength}. " +
			$"{nameof(Host)}: {strHost}. ";
    }

    public virtual bool Equals(ScaleEntity item)
    {
        //if (item is null) return false;
        if (ReferenceEquals(this, item)) return true;
        if (TemplateDefault != null && item.TemplateDefault != null && !TemplateDefault.Equals(item.TemplateDefault))
            return false;
        if (TemplateSeries != null && item.TemplateSeries != null && !TemplateSeries.Equals(item.TemplateSeries))
            return false;
        if (WorkShop != null && item.WorkShop != null && !WorkShop.Equals(item.WorkShop))
            return false;
        if (PrinterMain != null && item.PrinterMain != null && !PrinterMain.Equals(item.PrinterMain))
            return false;
        if (PrinterShipping != null && item.PrinterShipping != null && !PrinterShipping.Equals(item.PrinterShipping))
            return false;
        if (!Host.Equals(item.Host))
            return false;
        return base.Equals(item) &&
               Equals(Description, item.Description) &&
               Equals(DeviceIp, item.DeviceIp) &&
               Equals(DevicePort, item.DevicePort) &&
               Equals(DeviceMac, item.DeviceMac) &&
               Equals(DeviceSendTimeout, item.DeviceSendTimeout) &&
               Equals(DeviceReceiveTimeout, item.DeviceReceiveTimeout) &&
               Equals(DeviceComPort, item.DeviceComPort) &&
               Equals(ZebraIp, item.ZebraIp) &&
               Equals(ZebraPort, item.ZebraPort) &&
               Equals(IsOrder, item.IsOrder) &&
               Equals(Number, item.Number) &&
               Equals(Counter, item.Counter) &&
               Equals(ScaleFactor, item.ScaleFactor) &&
               Equals(IsShipping, item.IsShipping) &&
               Equals(IsKneading, item.IsKneading) &&
               ShippingLength.Equals(item.ShippingLength);
    }

    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((ScaleEntity)obj);
    }

	public override int GetHashCode() => IdentityId.GetHashCode();

	public virtual bool EqualsNew()
    {
        return Equals(new());
    }

    public new virtual bool EqualsDefault()
    {
        if (TemplateDefault != null && !TemplateDefault.EqualsDefault())
            return false;
        if (TemplateSeries != null && !TemplateSeries.EqualsDefault())
            return false;
        if (WorkShop != null && !WorkShop.EqualsDefault())
            return false;
        if (PrinterMain != null && !PrinterMain.EqualsDefault())
            return false;
        if (PrinterShipping != null && !PrinterShipping.EqualsDefault())
            return false;
        if (!Host.EqualsDefault())
            return false;
        return base.EqualsDefault() &&
               Equals(Description, string.Empty) &&
               Equals(DeviceIp, string.Empty) &&
               Equals(DevicePort, (short)0) &&
               Equals(DeviceMac, string.Empty) &&
               Equals(DeviceSendTimeout, null) &&
               Equals(DeviceReceiveTimeout, null) &&
               Equals(DeviceComPort, string.Empty) &&

               Equals(ZebraIp, string.Empty) &&
               Equals(ZebraPort, null) &&
               Equals(IsOrder, false) &&

               Equals(Number, 0) &&
               Equals(Counter, 0) &&
               Equals(ScaleFactor, null) &&
               Equals(IsShipping, false) &&
               Equals(IsKneading, false) &&
               Equals(ShippingLength, (byte)0);
    }

    public new virtual object Clone()
    {
        ScaleEntity item = new();
        item.TemplateDefault = TemplateDefault?.CloneCast();
        item.TemplateSeries = TemplateSeries?.CloneCast();
        item.WorkShop = WorkShop?.CloneCast();
        item.PrinterMain = PrinterMain?.CloneCast();
        item.PrinterShipping = PrinterShipping?.CloneCast();
        item.IsShipping = IsShipping;
        item.IsKneading = IsKneading;
        item.ShippingLength = ShippingLength;
        item.Host = Host.CloneCast();
        item.Description = Description;
        item.DeviceIp = DeviceIp;
        item.DevicePort = DevicePort;
        item.DeviceMac = DeviceMac;
        item.DeviceSendTimeout = DeviceSendTimeout;
        item.DeviceReceiveTimeout = DeviceReceiveTimeout;
        item.DeviceComPort = DeviceComPort;
        item.ZebraIp = ZebraIp;
        item.ZebraPort = ZebraPort;
        item.IsOrder = IsOrder;
        item.Number = Number;
        item.Counter = Counter;
        item.ScaleFactor = ScaleFactor;
        item.Setup(((BaseEntity)this).CloneCast());
        return item;
    }

    public new virtual ScaleEntity CloneCast() => (ScaleEntity)Clone();

    #endregion
}
