using Microsoft.Extensions.Configuration;

namespace ScalesDesktop.Source.Shared.Refit.Clients;

internal class DesktopRefitClient : IRefitClient
{
    public void Configure(MauiAppBuilder builder)
    {
        IConfigurationSection oidcConfiguration = builder.Configuration.GetSection("Api");
        builder.Services.AddRefitClient<IDesktopApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new($"{oidcConfiguration.GetValue<string>("BaseUrl") ?? ""}"))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            })
            .AddHttpMessageHandler<HostNameMessageHandler>();
    }
}