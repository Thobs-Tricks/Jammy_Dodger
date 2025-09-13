using MonkeyCache.FileStore;

namespace Finance_Quest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JEaF5cXmRCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXhceHVURGVZVkF3WEBWYEk=");

            //Application.Current!.UserAppTheme = AppTheme.Light;

            //Set up cache
            Barrel.ApplicationId = AppInfo.PackageName;
            Barrel.Current.AutoExpire = false;
            Barrel.Current.EmptyExpired();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
