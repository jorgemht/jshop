using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Jshop
{
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

            MainPage = new MasterDetailView();
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
