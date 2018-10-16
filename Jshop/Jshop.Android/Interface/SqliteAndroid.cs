using Jshop.Droid.Interface;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteAndroid))]
namespace Jshop.Droid.Interface
{
    using Services.Sqlite;
    using System;
    using System.IO;

    public class SqliteAndroid : IPathService
    {
        public SQLiteAsyncConnection GetAsyncConnection() => new SQLiteAsyncConnection(GetPath());

        public SQLiteConnection GetConnection() => new SQLiteConnection(GetPath());

        private string GetPath()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, "Sql.db3");
            return path;
        }
    }
}