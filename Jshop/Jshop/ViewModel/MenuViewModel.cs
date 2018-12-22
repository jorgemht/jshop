namespace Jshop.ViewModel
{
    using Jshop.Model;
    using Jshop.Resources;
    using Jshop.Utils;
    using Jshop.ViewModel.Base;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Essentials;

    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<Menu> _menu;
        private Menu _menuSelectItem;
        public string _image;

        public ObservableCollection<Menu> Menu
        {
            get => _menu;
            set => SetProperty(ref _menu, value);
        }

        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        public Menu MenuSelectItem
        {
            get => _menuSelectItem;
            set
            {
                SetProperty(ref _menuSelectItem, value);
                HandleSelectionAsync();
            }
        }

        public MenuViewModel()
        {
            var menu = new List<Menu>
            {
                new Menu
                {
                    Icon = string.Empty,
                    ViewName = "HomeView",
                    Title = Resource.Menu_Home,
                },
                new Menu
                {
                    Icon = string.Empty,
                    ViewName = "MainMapView",
                    Title = Resource.Menu_Map,
                },
                new Menu
                {
                    Icon = string.Empty,
                    ViewName = "LanguageView",
                    Title = Resource.Menu_Language,
                },
                new Menu
                {
                    Icon = string.Empty,
                    ViewName = "AboutView",
                    Title = Resource.Menu_About,
                },
                new Menu
                {
                    Icon = string.Empty,
                    ViewName = "GithubView",
                    Title = "Github",
                }
            };

            Menu = new ObservableCollection<Menu>(menu);

            Image = AppSettings.DefaultPhoto;
        }

        public ICommand GithubCommand => new AsyncCommand(Github);

        private async Task Github() => await Browser.OpenAsync(AppSettings.GithubUrl, BrowserLaunchMode.SystemPreferred);

        private async void HandleSelectionAsync()
        {
            if (MenuSelectItem.ViewName == null) return;

            if(MenuSelectItem.ViewName == "GithubView") await Browser.OpenAsync(AppSettings.GithubUrl, BrowserLaunchMode.SystemPreferred);
            else await MainViewModel.GetInstance().NavigationService.NavigateOnMaster(MenuSelectItem.ViewName);
        }
    }
}
