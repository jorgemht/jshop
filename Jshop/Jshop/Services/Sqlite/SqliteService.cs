namespace Jshop.Services.Sqlite
{
    using SQLite;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class SqliteService : ISqlite
    {
        private readonly SQLiteAsyncConnection database;

        public SqliteService() => database = DependencyService.Get<IPathService>().GetAsyncConnection();

        public async Task SaveValueAsync<T>(T value, bool overrideIfExists = true) where T : class, IKeyObject, new()
        {
            if (overrideIfExists) await database.InsertOrReplaceAsync(value);
            else
                try
                {
                    await database.InsertAsync(value);
                }
                catch (SQLiteException e)
                {
                    if (e.Result == SQLite3.Result.Constraint) throw new Exception($"Element { value.Id } already exists");
                }
        }

        public async Task SaveAllAsync<T>(IEnumerable<T> values, bool overrideIfExists = true) where T : class, IKeyObject, new()
        {
            await database.DropTableAsync<T>();
            await database.CreateTableAsync<T>();
            await database.InsertAllAsync(values);
        }

        public async Task DeleteAsync<T>(T value) where T : class, IKeyObject, new() => await database.DeleteAsync(value);

        public async Task<List<T>> GetAllItemsAsync<T>() where T : class, IKeyObject, new()
        {
            try
            {
                return await database.Table<T>().ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<T> GetItemAsync<T>(string id) where T : class, IKeyObject, new() => await database.FindAsync<T>(id);
    }
}
