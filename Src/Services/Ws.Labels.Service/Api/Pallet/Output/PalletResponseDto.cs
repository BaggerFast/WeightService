using System.Xml.Serialization;

namespace Ws.Labels.Service.Api.Pallet.Output;

[XmlRoot("ResponseType", Namespace = "http://www.kolbasa-vs.ru/scales/ResponseVesovaya2_0")]
public sealed class PalletResponseDto
{
    [XmlArray("Successes"), XmlArrayItem("Record")]
    public List<PalletSuccess> Successes { get; set; } = [];

    [XmlArray("Errors"), XmlArrayItem("Error")]
    public List<PalletError> Errors { get; set; } = [];
}