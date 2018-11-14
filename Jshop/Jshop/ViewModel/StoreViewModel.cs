namespace Jshop.ViewModel
{
    using System;
    using Jshop.Model;
    using Jshop.Services;
    using Jshop.ViewModel.Base;

    public class StoreViewModel : ViewModelBase
    {
        private StoreModel _storeModel;

        public StoreModel StoreModel
        {
            get => _storeModel;
            set => SetProperty(ref _storeModel, value);
        }

        public StoreViewModel(long id)
        {
            Api = new HttpService();
            LoadStore(id);
        }

        private async void LoadStore(long id)
        {
            try
            {
                var result = await Api.Get<StoreModel>("Stores/"+id);

                StoreModel = (StoreModel)result.Result;

            }
            catch (Exception e)
            {
               
            }

        }
    }
}
