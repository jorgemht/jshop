namespace Jshop.ViewModel
{
    using Common;
    using Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class HomeViewModel : ViewModelBase
    {
        private ObservableCollection<Store> _stores;
        private List<Store> _storeList;
        private string _store;

        public ObservableCollection<Store> Stores
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

        public HomeViewModel()
        {
            loadStores();
        }

        private void Search()
        {
            Stores = string.IsNullOrWhiteSpace(SearchStore)
                ? new ObservableCollection<Store>(_storeList)
                : new ObservableCollection<Store>(
                    _storeList.Where(c => c.Name.ToLower().Contains(SearchStore.ToLower())).OrderBy(c => c.Name));
        }

        private async void loadStores()
        {
            var api = new HttpService();

            var result = await api.GetList<Store>("Stores");

            if (!result.IsSuccess || result.Result == null) return;

            _storeList = (List<Store>) result.Result;

            Stores = new ObservableCollection<Store>(_storeList);

        }
    }
}
