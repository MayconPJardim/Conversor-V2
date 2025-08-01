using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using eCommerce.Client;
using eCommerce.Client.Services.HP;
using eCommerce.Client.Services.Job;
using eCommerce.Client.Services.Bling;
using eCommerce.Client.Services.Lenovo;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<HPService>();
builder.Services.AddScoped<JobService>();
builder.Services.AddScoped<BlingService>();
builder.Services.AddScoped<LenovoService>();

await builder.Build().RunAsync();
