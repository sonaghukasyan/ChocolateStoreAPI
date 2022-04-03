using System.Collections.Generic;

namespace ChocolateStoreAPI.DataFile
{
    public interface IDataAccess<T>
    {
        void Save(IEnumerable<T> list);
        IEnumerable<T> Read();
    }
}
