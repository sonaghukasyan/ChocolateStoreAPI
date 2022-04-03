using ChocolateStoreAPI.Models;
using System.Collections.Generic;

namespace ChocolateStoreAPI.Services
{
    public interface IChocolateService
    {
        IEnumerable<Chocolate> Get();
        Chocolate GetByID(int id);
        void Save(Chocolate chocolate);  
        void Delete(int id);

    }
}
