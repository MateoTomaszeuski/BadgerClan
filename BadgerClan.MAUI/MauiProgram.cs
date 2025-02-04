using BadgerClan.MAUI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BadgerClan.MAUI
{
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            builder.Services.AddSingleton<IApiService, ApiService>();
            builder.Services.AddHttpClient("AzureApi1", (o) =>
            {
                o.BaseAddress = new Uri("https://mateobadgerclan1.azurewebsites.net");
            });
            
            builder.Services.AddHttpClient("AzureApi2", (o) =>
            {
                o.BaseAddress = new Uri("https://mateobadgerclan2.azurewebsites.net");
            });

            builder.Services.AddHttpClient("LocalApi", (o) =>
            {
                if (DeviceInfo.Current.Platform == DevicePlatform.Android)
                o.BaseAddress = new Uri("http://10.0.2.2:1000");
                else if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
                o.BaseAddress = new Uri("http://127.0.0.1:1000");

            });


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
