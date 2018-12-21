using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Jshop
{
    using Helpers;
    using Jshop.Services;
    using System.Threading.Tasks;
    using Views;
    using Plugin.Permissions;
    using Plugin.Permissions.Abstractions;
    using System;
    using Xamarin.Essentials;

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

            //Task.Run(async () => { await PermissionUbication(); });
        }

        private async Task PermissionUbication()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);

                if (status != PermissionStatus.Granted)
                {
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location)) status = results[Permission.Location];
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected override void OnSleep()
        { 
        }

        protected override void OnResume()
        {
        }
    }
}
