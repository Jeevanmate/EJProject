using EJProject.Client;
using EJProject.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddHttpClient("EJProject.ServerAPI", (sp,client) => { client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress); client.EnableIntercept(sp);})
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddHttpClient("YourProject.ServerAPI.Anonymous",
        client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));


// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("EJProject.ServerAPI"));
builder.Services.AddScoped<IHttpAnonymousClientFactory, HttpAnonymousClientFactory>();

builder.Services.AddHttpClientInterceptor();
builder.Services.AddScoped<HttpInterceptorService>();


builder.Services.AddApiAuthorization();






await builder.Build().RunAsync();
