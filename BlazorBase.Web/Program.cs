using BlazorBase.Web;
using BlazorBase.Web.Service;
using BlazorBase.Web.Service.Interfaces;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddHttpClient("BlazorBase.Api", opts =>
{
#if DEBUG
    opts.BaseAddress = new Uri("https://localhost:44359/");
#else
    opts.BaseAddress = new Uri("https://agontesteapi.azurewebsites.net/"); 

#endif

});

await builder.Build().RunAsync();
