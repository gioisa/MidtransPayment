using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Midtrans.Payment.Web.Helpers;
using Midtrans.Payment.Web.Services;
using Midtrans.Payment.Shared;

namespace Midtrans.Payment.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.RegisterServices();
            builder.Services.RegisterShared();
            builder.Services.AddTransient<IAuthorizeService, AuthorizeService>();

            await builder.Build().RunAsync();
        }
    }
}