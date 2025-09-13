using CommunityToolkit.Maui;
using Finance_Quest.ViewModels;
using Finance_Quest.Views.TabPages;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace Finance_Quest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("LeagueSpartan-Black.ttf", "LS_Black");
                    fonts.AddFont("LeagueSpartan-Bold.ttf", "LS_Bold");
                    fonts.AddFont("LeagueSpartan-ExtraBold.ttf", "LS_eBold");
                    fonts.AddFont("LeagueSpartan-SemiBold.ttf", "LS_semiBold");
                    fonts.AddFont("LeagueSpartan-Regular.ttf", "LS_Regular");
                });

            builder.Services.AddSingleton<HomeVM>();

            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<StatsPage>();
            builder.Services.AddSingleton<AchievementPage>();
            builder.Services.AddSingleton<SettingsPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
