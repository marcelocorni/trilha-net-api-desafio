using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Net.Http;
using TarefasBlazor.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Registrar HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices(options =>
{
    options.PopoverOptions.ThrowOnDuplicateProvider = false;
});

// Registrar TarefaService
builder.Services.AddScoped<ITarefaService, TarefaService>();

await builder.Build().RunAsync();
