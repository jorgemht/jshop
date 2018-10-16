namespace Jshop.Services.Sqlite
{
    using SQLite;

    public interface IPathService
    {
        SQLiteAsyncConnection GetAsyncConnection();
        SQLiteConnection GetConnection();
    }
}
