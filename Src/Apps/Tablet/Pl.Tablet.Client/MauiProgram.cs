﻿using BarcodeScanning;
using CommunityToolkit.Maui;
using Fluxor;
using Microsoft.Extensions.Logging;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Pl.Tablet.Client.Source.Shared;
using Pl.Tablet.Client.Source.Shared.Api;
using Pl.Tablet.Client.Source.Shared.Services;
using Pl.Shared.Web.Extensions;
using TailwindMerge.Extensions;

namespace Pl.Tablet.Client;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder.Configuration.LoadAppSettings<ITabletAssembly>();

        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

        builder.RegisterRefitClients();
        builder.UseBarcodeScanning();

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddFluentUIComponents(c => c.ValidateClassNames = false);

        builder.Services
            .SetupMauiLocalizer(builder.Configuration)
            .AddRefitEndpoints<ITabletAssembly>()
            .AddDelegatingHandlers<ITabletAssembly>();

        builder.Services.AddFluxor(options =>
        {
            options.WithLifetime(StoreLifetime.Singleton);
            options.ScanAssemblies(typeof(ITabletAssembly).Assembly);
        });

        builder.Services.AddTailwindMerge();

        builder.Services
            .AddScoped<HtmlRenderer>()
            .AddScoped<IPrintService, PrintService>()
            .AddSingleton<IPrinterService, PrinterService>();

        #if DEBUG

        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();

        #endif

        return builder.Build();
    }
}