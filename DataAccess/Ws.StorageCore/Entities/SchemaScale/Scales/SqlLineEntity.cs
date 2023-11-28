using Ws.StorageCore.Entities.SchemaRef.Hosts;
using Ws.StorageCore.Entities.SchemaRef.Printers;

namespace Ws.StorageCore.Entities.SchemaScale.Scales;

/// <summary>
/// Модель таблицы SCALES.
/// </summary>
[DebuggerDisplay("{ToString()}")]
public class SqlLineEntity : SqlEntityBase
{
    #region Public and private fields, properties, constructor
    
    public virtual SqlHostEntity Host { get; set; }
    public virtual SqlWorkShopEntity WorkShop { get; set; }
    public virtual SqlPrinterEntity Printer { get; set; }
    public virtual string DeviceComPort { get; set; }
    public virtual int Number { get; set; }
    public override string DisplayName => IsNew ?  LocaleCore.Table.FieldEmpty : $"{Description}";
    
    private int _labelCounter;
    
    public virtual int LabelCounter { get => _labelCounter; set { _labelCounter = value > 1_000_000 ? 1 : value; } }
    public virtual string NumberWithDescription => $"{LocaleCore.Table.Number}: {Number} | {Description}";
    public virtual string ClickOnce { get; set; } = string.Empty;
    public virtual string Version { get; set; } = string.Empty;
    
    public SqlLineEntity() : base(SqlEnumFieldIdentity.Id)
    {
        Version = string.Empty;
        WorkShop = new();
        Host = new();
        Printer = new();
        Number = 0;
        LabelCounter = 0;
        DeviceComPort = "COM6";
    }

    public SqlLineEntity(SqlLineEntity item) : base(item)
    {
        Host = new(item.Host);
        WorkShop = new(item.WorkShop);
        Printer = new(item.Printer);
        DeviceComPort = item.DeviceComPort;
        Number = item.Number;
        LabelCounter = item.LabelCounter;
        Version = item.Version;
    }

    #endregion

    #region Public and private methods - override

    public override string ToString() => $"{IdentityValueId} | {Description}";

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((SqlLineEntity)obj);
    }

    public override int GetHashCode() => base.GetHashCode();
    
    public override void FillProperties()
    {
        base.FillProperties();
        WorkShop.FillProperties();
        Printer.FillProperties();
        Host.FillProperties();
    }

    #endregion

    #region Public and private methods - virtual

    public virtual bool Equals(SqlLineEntity item) =>
        ReferenceEquals(this, item) || base.Equals(item) && //-V3130
        Equals(DeviceComPort, item.DeviceComPort) &&
        Equals(Number, item.Number) &&
        Equals(LabelCounter, item.LabelCounter) &&
        WorkShop.Equals(item.WorkShop) &&
        Host.Equals(item.Host) &&
        Printer.Equals(item.Printer) &&
        Version.Equals(item.Version);

    #endregion
}