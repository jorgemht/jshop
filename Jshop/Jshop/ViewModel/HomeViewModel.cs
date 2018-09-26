namespace Jshop.ViewModel
{
    using Jshop.Common;
    using Jshop.Services;
    using System;
    using System.Collections.ObjectModel;

    public class HomeViewModel : ViewModelBase
    {
        private ObservableCollection<Store> _stores;

        public ObservableCollection<Store> Stores
        {
            get => _stores;
            set => SetProperty(ref _stores, value);
        }

        public HomeViewModel()
        {
            loadStores();
        }

        private async void loadStores()
        {
            var api = new HttpService();

            var x = await api.Get<Store>("Stores/1");

            var result = await api.GetList<Store>("Stores");
        }
    }
}
