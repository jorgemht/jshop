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
                    ViewName = "CategoryView",
                    Title = Resource.Menu_Category,
                },
                new Menu
                {
                    Icon = string.Empty,
                    ViewName = "CustomerView",
                    Title = Resource.Menu_Customer,
                },
                new Menu
                {
                    Icon = string.Empty,
                    ViewName = "OrderView",
                    Title = Resource.Menu_Order,
                },
                new Menu
                {
                    Icon = "menuMap",
                    ViewName = "MainMapView",
                    Title = Resource.Menu_Map,
                },
                new Menu
                {
                    Icon = string.Empty,
                    ViewName = "LanguageView",
                    Title = Resource.Menu_Language,
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

            await MainViewModel.GetInstance().NavigationService.NavigateOnMaster(MenuSelectItem.ViewName);
        }
    }
}
