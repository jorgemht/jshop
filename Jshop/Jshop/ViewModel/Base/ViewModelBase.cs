namespace Jshop.ViewModel.Base
{
    using Jshop.Services;
    using Jshop.Services.Sqlite;

    public abstract class ViewModelBase : MvvmHelpers.BaseViewModel
    {
        protected SqliteService Isqlite;
        protected HttpService Api;
    }
}
