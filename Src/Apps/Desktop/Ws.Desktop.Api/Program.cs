using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Ws.Database.EntityFramework;
using Ws.Desktop.Api.App.Features.Arms.Common;
using Ws.Desktop.Api.App.Features.Arms.Impl;
using Ws.Desktop.Api.App.Features.PalletMen.Common;
using Ws.Desktop.Api.App.Features.PalletMen.Impl;
using Ws.Desktop.Api.App.Features.Pallets.Common;
using Ws.Desktop.Api.App.Features.Pallets.Impl;
using Ws.Desktop.Api.App.Features.Plu.Common;
using Ws.Desktop.Api.App.Features.Plu.Impl.Piece;
using Ws.Desktop.Api.App.Features.Plu.Impl.Weight;
using Ws.Desktop.Api.App.Middlewares;
using Ws.Domain.Services;
using Ws.Labels.Service;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

#region Internal services

builder.Services.AddScoped<IArmService, ArmService>();
builder.Services.AddScoped<IPluPieceService, PluPieceService>();
builder.Services.AddScoped<IPluWeightService, PluWeightService>();
builder.Services.AddScoped<IPalletManService, PalletManService>();
builder.Services.AddScoped<IPalletApiService, PalletApiService>();

#endregion

#region Ready services

builder.Services.AddEfCore();
builder.Services.AddDomainServices();
builder.Services.AddLabelsServices();

#endregion


builder.Services
    .AddControllers(options => {
        options.Filters.Add(new AllowAnonymousFilter());
        options.Filters.Add(new ConsumesAttribute(MediaTypeNames.Application.Json));
    })
    .ConfigureApiBehaviorOptions(options => {
        options.SuppressConsumesConstraintForFormFileParameters = true;
        options.SuppressInferBindingSourcesForParameters = true;
        options.SuppressModelStateInvalidFilter = true;
        options.SuppressMapClientErrors = true;
    })
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.WriteIndented = true;
    });


builder.Services.AddTransient<GenerateLabelExceptionHandlingMiddleware>();

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.UseMiddleware<GenerateLabelExceptionHandlingMiddleware>();

app.Run();