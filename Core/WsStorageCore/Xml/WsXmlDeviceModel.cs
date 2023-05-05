// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsStorageCore.Xml;

[Serializable]
public class WsXmlDeviceModel : WsSqlTableBase
{
    #region Public and private fields, properties, constructor

    public virtual WsSqlScaleModel Scale { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    public WsXmlDeviceModel() : base(WsSqlFieldIdentity.Id)
    {
        Scale = new();
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    private WsXmlDeviceModel(SerializationInfo info, StreamingContext context) : base(info, context)
    {
        Scale = (WsSqlScaleModel)info.GetValue(nameof(Scale), typeof(WsSqlScaleModel));
    }

    #endregion

    #region Public and private methods - override

    public override string ToString() =>
        $"{nameof(Scale)}: {Scale}.";

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj is WsXmlDeviceModel item)
        {
            return
               Scale.Equals(item.Scale);
        }
        return false;
    }

    public override int GetHashCode() => Scale.GetHashCode();

    public override bool EqualsNew() => Equals(new());

    public override bool EqualsDefault() =>
	    base.EqualsDefault() &&
	    Scale.EqualsDefault();

    public override object Clone()
    {
        WsXmlDeviceModel item = new();
        item.CloneSetup(base.CloneCast());
        item.Scale = Scale.CloneCast();
        return item;
    }

    /// <summary>
    /// Get object data for serialization info.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(Scale), Scale);
    }

    #endregion

    #region Public and private methods - virtual

    public virtual bool Equals(WsXmlDeviceModel item) =>
	    ReferenceEquals(this, item) || base.Equals(item) && //-V3130
	    Equals(Scale, item.Scale);

    public new virtual WsXmlDeviceModel CloneCast() => (WsXmlDeviceModel)Clone();

    #endregion
}