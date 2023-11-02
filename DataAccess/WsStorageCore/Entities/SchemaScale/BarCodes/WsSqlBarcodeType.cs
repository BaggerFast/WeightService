using System.Diagnostics.CodeAnalysis;
namespace WsStorageCore.Entities.SchemaScale.BarCodes;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public enum WsSqlBarcodeType
{
    Default,
    Codabar,
    Code11,
    Code128,
    Code128A,
    Code128B,
    Code128C,
    Code39,
    Code39E,
    Code93,
    EAN13,
    EAN8
}