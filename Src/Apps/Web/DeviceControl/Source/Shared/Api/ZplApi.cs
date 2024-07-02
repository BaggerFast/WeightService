using Phetch.Core;

namespace DeviceControl.Source.Shared.Api;

public class ZplApi(ILabelaryApi labelary)
{
    public Endpoint<ZplEndpointArgs, string> ZplEndpoint { get; } = new(
        async value =>
        {
          double widthInch = Math.Round(value.Width / 25.4, 1);
          double heightInch = Math.Round(value.Height / 25.4, 1);

          StringContent content = new(value.Zpl);
          content.Headers.ContentType = new("application/x-www-form-urlencoded");
          HttpResponseMessage response = await labelary.RenderZpl(widthInch, heightInch, content, value.RotateDegrees);

          using MemoryStream ms = new();
          await response.Content.CopyToAsync(ms);
          return Convert.ToBase64String(ms.ToArray());
        },
        options: new() { DefaultStaleTime = TimeSpan.FromMinutes(5) });
}

public record ZplEndpointArgs(string Zpl, short Width, short Height, short RotateDegrees = 0);