namespace Jshop.ViewModel
{
    using Jshop.Extensions;
    using Jshop.Model;
    using Jshop.Services.Sqlite;
    using Jshop.ViewModel.Base;
    using Plugin.Connectivity;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class HomeViewModel : ViewModelBase
    {
        private ObservableCollection<StoreModel> _stores;
        private StoreModel _storeSelectItem;
        private string _store;

        public ObservableCollection<StoreModel> Stores
        {
            get => _stores;
            set => SetProperty(ref _stores, value);
        }

        public string SearchStore
        {
            get => _store;
            set
            {
                SetProperty(ref _store, value);
                Search();
            }
        }

        public StoreModel StoreSelectItem
        {
            get => _storeSelectItem;
            set
            {
                SetProperty(ref _storeSelectItem, value);
                HandleSelectionAsync();
            }
        }

        private async void HandleSelectionAsync()
        {
            if (StoreSelectItem?.StoreId == null) return;

            await MainViewModel.GetInstance().NavigationService.Navigate("StoreView", StoreSelectItem.StoreId);
        }

        public HomeViewModel()
        {
            Isqlite = new SqliteService();
            Api = new HttpService();

            LoadStores();
        }

        private async void Search()
        {
            var storesSqlite = await Isqlite.GetAllItemsAsync<StoreModel>();

            Stores = string.IsNullOrWhiteSpace(SearchStore)
                ? new ObservableCollection<StoreModel>(storesSqlite)
                : new ObservableCollection<StoreModel>(
                    storesSqlite.Where(c => c.Name.ToLower().Contains(SearchStore.ToLower())).OrderBy(c => c.Name));
        }

        private async void LoadStores()
        {
            var result = await Api.GetList<StoreModel>("Stores");

            if (!CrossConnectivity.Current.IsConnected || !result.IsSuccess || result.Result == null)
            {
                var storesSqlite = await Isqlite.GetAllItemsAsync<StoreModel>();
                if (storesSqlite == null) return;
                Stores = new ObservableCollection<StoreModel>(storesSqlite);
            }
            else
            {
                Stores = ((List<StoreModel>)result.Result).ToObservableRangeCollection();
                await Isqlite.SaveAllAsync<StoreModel>((IEnumerable<StoreModel>)result.Result);
            }
        }
    }
}
