namespace Jshop.Services.Store
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Jshop.Model;

    public class StoreFake : IStoreFake
    {
        public async Task<List<StoreModel>> All()
        {
            await Task.Delay(5000);

            return new List<StoreModel>()
            {
                new StoreModel()
                {
                    Name = "Uno",
                    Address = "Dos",
                    CodePostal = "Tres",
                }
            };
        }

        public Task<List<StoreModel>> AllByCity()
        {
            throw new NotImplementedException();
        }
    }
}
