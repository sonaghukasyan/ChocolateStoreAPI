using System.Collections.Generic;

namespace ChocolateStoreAPI.DataFile
{
    public interface IDataAccess<T>
    {
        void Save(List<T> list);
        List<T> Read();
    }
}
