// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ReSharper disable InconsistentNaming

using DataCore.Serialization.Models;

namespace WsWebApi.Models;

[XmlRoot(WebConstants.Record, Namespace = "", IsNullable = false)]
public class WsResponse1cRecordModel : SerializeBase
{
    #region Public and private fields, properties, constructor

    [XmlAttribute("Guid")]
    public Guid Uid { get; set; }

    [XmlAttribute(nameof(Message))]
    public string Message { get; set; }

    [XmlAttribute(nameof(InnerMessage))]
    public string? InnerMessage { get; set; }

    public WsResponse1cRecordModel()
    {
        Uid = Guid.Empty;
        Message = string.Empty;
        InnerMessage = null;
    }

    public WsResponse1cRecordModel(Guid uid, string message, string innerMessage)
    {
        Uid = uid;
        Message = message;
        InnerMessage = innerMessage;
    }

    public WsResponse1cRecordModel(Guid uid, string message) : this(uid, message, string.Empty) { }

    public WsResponse1cRecordModel(Exception ex)
    {
        Uid = Guid.Empty;
        Message = ex.Message;
        InnerMessage = ex.InnerException?.Message;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    private WsResponse1cRecordModel(SerializationInfo info, StreamingContext context) : base(info, context)
    {
        object? uid = info.GetValue(nameof(Uid), typeof(Guid));
        Uid = uid is not null ? (Guid)uid : Guid.Empty;
        Message = info.GetString(nameof(Message)) ?? string.Empty;
        InnerMessage = info.GetString(nameof(InnerMessage)) ?? string.Empty;
    }

    #endregion

    #region Public and private methods

    public override string ToString() =>
        $"{nameof(Uid)}: {Uid}. " +
        $"{nameof(Message)}: {Message}. " +
        $"{nameof(InnerMessage)}: {InnerMessage}. ";

    /// <summary>
    /// Get object data for serialization info.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(Uid), Uid);
        info.AddValue(nameof(Message), Message);
        info.AddValue(nameof(InnerMessage), InnerMessage);
    }

    #endregion
}