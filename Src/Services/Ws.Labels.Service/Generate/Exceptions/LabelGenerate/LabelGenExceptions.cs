using System.ComponentModel;

namespace Ws.Labels.Service.Generate.Exceptions.LabelGenerate;

public enum LabelGenExceptions
{
    [Description("LabelGenExcInvalid")]
    Invalid,
    [Description("LabelGenExcBarcodeInvalid")]
    BarcodeInvalid,
    [Description("LabelGenExcTemplateNotFound")]
    TemplateNotFound,
    [Description("LabelGenExcBarcodeVariableNotFound")]
    BarcodeVarNotFound,
    [Description("LabelGenExcExchangeFailed")]
    ExchangeFailed
}