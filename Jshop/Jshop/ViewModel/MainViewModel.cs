namespace Jshop.ViewModel
{
    using Jshop.Services;

    public class MainViewModel
    {
        public HttpService HttpService;
        public NavigationService NavigationService;

        public MainViewModel()
        {
            NavigationService = new NavigationService();
            instance = this;
        }

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            return instance ?? (instance = new MainViewModel());
        }
        #endregion
    }
}
