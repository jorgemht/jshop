using Jshop.iOS.Interface;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteIos))]
namespace Jshop.iOS.Interface
{
    using Services.Sqlite;
    using System;
    using System.IO;

    public class SqliteIos : IPathService
    {
        public SQLiteAsyncConnection GetAsyncConnection() => new SQLiteAsyncConnection(GetPath());

        public SQLiteConnection GetConnection() => new SQLiteConnection(GetPath());

        private string GetPath()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var libraryPath = Path.Combine(documentsPath, "..", "Library"); //  Library folder
            return Path.Combine(libraryPath, "Sql.db3");
        }
    }
}