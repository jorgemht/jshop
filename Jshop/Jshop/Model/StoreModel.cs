namespace Jshop.Model
{
    using Jshop.Common;
    using Jshop.Services.Sqlite;

    public class StoreModel : Store, IKeyObject
    {
        public string Id { get; set; }
    }
}
