using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Ws.Database.EntityFramework;
using Ws.DeviceControl.Api.App.Features.Database.Common;
using Ws.DeviceControl.Api.App.Features.Database.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

#region Internal services

builder.Services.AddScoped<IDatabaseService, DatabaseService>();

#endregion

#region Ready services

builder.Services.AddEfCore();

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


var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();