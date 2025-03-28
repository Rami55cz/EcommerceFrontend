using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EcommerceFrontend;
using EcommerceFrontend.Services;
using Microsoft.AspNetCore.Components.Authorization;
using EcommerceFrontend.AuthServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7005") });
builder.Services.AddScoped<ProductService>();
/* builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
 */

builder.Services.AddScoped<AuthService>();
await builder.Build().RunAsync();
