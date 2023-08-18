using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShoppingListDemo.Client.Services;
using ShoppingListDemo.Client.Services.Interfaces;

namespace ShoppingListDemo.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddHttpClient("ShoppingListDemo.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ShoppingListDemo.ServerAPI"));
            builder.Services.AddApiAuthorization();

            builder.Services.AddTransient<IShoppingListService, ShoppingListService>()
            .AddTransient<IShoppingItemService, ShoppingItemService>();

            await builder.Build().RunAsync();
        }
    }
}