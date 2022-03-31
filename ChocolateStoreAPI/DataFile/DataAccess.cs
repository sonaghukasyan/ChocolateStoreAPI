using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChocolateStoreAPI.DataFile
{
    internal class DataAccess<T> : IDataAccess<T>
    {
        private DirectoryInfo DirectoryInfo;
        public string DirectoryName { get; set; }

        public DataAccess(string name)
        {
            this.DirectoryName = name;
            DirectoryInfo = new DirectoryInfo(this.DirectoryName);
            DirectoryInfo.Create();
        }
        public void Save(List<T> list)
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            string JsonData = JsonConvert.SerializeObject(list, jsonSerializerSettings);
            byte[] data = Encoding.UTF8.GetBytes(JsonData);


            using (FileStream fileStream = new FileStream(DirectoryName + "/File.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                fileStream.Write(data, 0, data.Length);
            }
        }

        public List<T> Read()
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            byte[] data;
            using (FileStream fileStream = new FileStream(DirectoryName + "/File.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                data = new byte[fileStream.Length];
                fileStream.Write(data, 0, data.Length);
            }

            string JsonData = Encoding.Default.GetString(data);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(JsonData, jsonSerializerSettings);

            if (list == null)
            {
                list = new List<T>();
            }

            return list;
        }
    }
}
