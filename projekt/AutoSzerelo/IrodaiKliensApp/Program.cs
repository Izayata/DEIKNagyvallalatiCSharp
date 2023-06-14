using IrodaiKliensApp;
using IrodaiKliensApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7205") });

//Services mappa (manuálisan létrehozott) regisztrálása a programba
builder.Services.AddScoped<IPersonService, PersonService>();

await builder.Build().RunAsync();
