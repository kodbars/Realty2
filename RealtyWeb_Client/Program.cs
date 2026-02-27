using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RealtyWeb_Client;
using RealtyWeb_Client.Utils;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl") ?? builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient<YandexService>("yandex", client =>
{
    client.BaseAddress = new Uri("https://ya.ru/");
});
builder.Services.AddHttpClient<WebApiService>("webapi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl") ?? builder.HostEnvironment.BaseAddress);
});

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, SpecialAuthenticationStateProvider>();

await builder.Build().RunAsync();
