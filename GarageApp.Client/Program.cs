using Blazored.LocalStorage;
using GarageApp.Client;
using GarageApp.Client.Providers;
using GarageApp.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Supabase;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();

// ---------- BLAZOR AUTH
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>(
    provider => new CustomAuthStateProvider(
        provider.GetRequiredService<ILocalStorageService>(),
        provider.GetRequiredService<Supabase.Client>(),
        provider.GetRequiredService<ILogger<CustomAuthStateProvider>>()
    )
)
    ;
builder.Services.AddAuthorizationCore();



builder.Services.AddScoped<Supabase.Client>(
    provider => new Supabase.Client(
        url,
        key,
        new Supabase.SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true,
            SessionHandler = new CustomSupabaseSessionHandler(
                provider.GetRequiredService<ILocalStorageService>(),
                provider.GetRequiredService<ILogger<CustomSupabaseSessionHandler>>()
            )
        }
    )
);

var options = new SupabaseOptions
{
    AutoRefreshToken = true,
    AutoConnectRealtime = false,
    // SessionHandler = new SupabaseSessionHandler() <-- This must be implemented by the developer
};

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<DatabaseService>();
builder.Services.AddScoped<StorageService>();

//Note the creation as a singleton.
builder.Services.AddSingleton(provider => new Supabase.Client(url, key, options));

await builder.Build().RunAsync();
