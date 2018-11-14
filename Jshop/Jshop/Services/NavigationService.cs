namespace Jshop.Services
{
    using Jshop.Views;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class NavigationService
    {
        public void SetMainPage()
        {
            Application.Current.MainPage = new MasterDetailView();
        }

        public async Task NavigateOnMaster(string pageName)
        {
            App.Master.IsPresented = false;

            switch (pageName)
            {
                case "HomeView": Application.Current.MainPage = new MasterDetailView(); break;
                case "LanguageView": await App.Navigator.PushAsync(new LanguageView()); break;
                case "AboutView": await App.Navigator.PushAsync(new LanguageView()); break;
                case "MainMapView": await App.Navigator.PushAsync(new MainMapView()); break;
            }
        }

        public async Task Navigate(string pageName, long id)
        {
            switch (pageName)
            {
                case "StoreView": await App.Navigator.PushAsync(new StoreView(id)); break;
            }
        }
    }
}
