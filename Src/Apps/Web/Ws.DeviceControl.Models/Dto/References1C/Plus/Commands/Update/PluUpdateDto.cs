namespace Ws.DeviceControl.Models.Dto.References1C.Plus.Commands.Update;

public sealed record PluUpdateDto
{
    [JsonPropertyName("templateId")]
    public Guid TemplateId { get; set; }
}