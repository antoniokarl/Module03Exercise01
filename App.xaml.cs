using Module03Exercise01.View;
using System.Diagnostics;
using Microsoft.Maui.ApplicationModel;
using System.Threading.Tasks;
using System.Net.Http;
using Module03Exercise01.Resources.Styles;

namespace Module03Exercise01
{
    public partial class App : Application
    {
        private const string TestUrl = "https://www.google.com";

        public App()
        {
            InitializeComponent();

            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                this.Resources.MergedDictionaries.Add(new WindowsResources());
            }
            else if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                this.Resources.MergedDictionaries.Add(new AndroidResources());
            }

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            var current = Connectivity.NetworkAccess;
            bool isWebsiteReachable = await IsWebsiteReachable(TestUrl);

            if (current == NetworkAccess.Internet && isWebsiteReachable)
            {
                MainPage = new LoginPage(); 
            }
            else
            {
                MainPage = new OfflinePage(); 
            }

            Debug.WriteLine("Application Started");
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("Application Sleeping");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("Application Resumed");
        }

        private async Task<bool> IsWebsiteReachable(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
