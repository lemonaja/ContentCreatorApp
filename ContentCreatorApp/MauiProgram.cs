using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using ContentCreatorApp.Services;
using ContentCreatorApp.Pages;

namespace ContentCreatorApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-SemiBold.ttf", "OpenSansSemiBold");
            });

        builder.Services.AddSingleton<ApiService>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddHttpClient<ApiService>(client =>
        {
            client.BaseAddress = new Uri(" https://822b-2804-1b3-a480-230b-5832-fd6e-2754-a079.ngrok-free.app"); 
        });

        return builder.Build();
    }
}
