using System.Collections.Generic;

namespace ChocolateStoreAPI.DataFile
{
    internal interface IDataAccess<T>
    {
        void Save(List<T> list);
        List<T> Read();
    }
}
