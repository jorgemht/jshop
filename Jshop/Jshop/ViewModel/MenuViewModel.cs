namespace Jshop.ViewModel
{
    using Jshop.Model;
    using Jshop.Resources;
    using Jshop.ViewModel.Base;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<Menu> _menu;
        private Menu _menuSelectItem;

        public ObservableCollection<Menu> Menu
        {
            get => _menu;
            set => SetProperty(ref _menu, value);
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
                    ViewName = "MapView",
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
                }
            };

            Menu = new ObservableCollection<Menu>(menu);
        }

        private async void HandleSelectionAsync()
        {
            if (MenuSelectItem.ViewName == null) return;

            await MainViewModel.GetInstance().NavigationService.NavigateOnMaster(MenuSelectItem.ViewName);
        }
    }
}
