namespace Jshop.Services.Store
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Jshop.Model;

    public interface IStoreFake
    {
        Task<List<StoreModel>> All();
        Task<List<StoreModel>> AllByCity();
    }
}
