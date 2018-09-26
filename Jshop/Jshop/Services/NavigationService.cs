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
                case "MapView": await App.Navigator.PushAsync(new LanguageView()); break;
                case "LanguageView": await App.Navigator.PushAsync(new LanguageView()); break;
                case "AboutView": await App.Navigator.PushAsync(new LanguageView()); break;
            }
        }
    }
}
