using ScalesDesktop.Source.Shared.Utils;

namespace ScalesDesktop.Source.Shared.Api.Desktop.Handlers;

public class HostNameMessageHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Authorization = new("ArmAuthenticationScheme", WindowsUtils.GetBiosId().ToString());
        return await base.SendAsync(request, cancellationToken);
    }
}