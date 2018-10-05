using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Jshop
{
    using Common;
    using Helpers;
    using Services;
    using Views;

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
                Language.UpdateLanguage();
            }

            loadUser();

            MainPage = new MasterDetailView();
        }

        private async void loadUser()
        {
            var api = new HttpService();

            var user = new UserApp
            {
                Email = "jorge@store.com",
                Password = "123321"
            };

            await api.GetTokenUser("account/login", user);            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
