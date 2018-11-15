using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Jshop
{
    using Helpers;
    using Jshop.Services;
    using System.Threading.Tasks;
    using Views;
    using Plugin.Connectivity;

    public partial class App : Application
    {
        #region Properties
        public static NavigationPage Navigator { get; set; }
        public static MasterDetailView Master { get; set; }
        #endregion

        public App()
        {
            InitializeComponent();

            if (Settings.Lang.Equals(string.Empty))
            {
                Language.UpdateLanguage("es");
            }

            /*
            if (string.IsNullOrEmpty(Settings.AccessToken) && CrossConnectivity.Current.IsConnected)
            {
                Task.Run(async () => { await LoadUser(); }).Wait();
            }*/

            MainPage = new MasterDetailView();
        }

        private async Task LoadUser()
        {
            var api = new HttpService();

            var token = await api.GetToken();

            Settings.AccessToken = token.token;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        { 
        }

        protected override void OnResume()
        {
        }
    }
}
