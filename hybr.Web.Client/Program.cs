using hybr.Shared.Services;
using hybr.Web.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

DataBase.GetAllData();

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddBlazorBootstrap();

// Add device-specific services used by the hybr.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

await builder.Build().RunAsync();
