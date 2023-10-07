using AtaCompany.Client;
using AtaCompany.Client.RazorComponents;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Http.Features;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Add("Max-Allowed-Content-Length", "5242880");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<PopUpState>();
builder.Services.AddSingleton(typeof(SearchParameters<>));


await builder.Build().RunAsync();
