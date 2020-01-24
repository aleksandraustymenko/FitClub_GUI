using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FitClub.Controller
{
    class SerializeDataSaver : IDataSaver
    {
        public List<T> Zaladuj<T>()where T:class
        {
            var bf = new BinaryFormatter();
            var file = typeof(T) + ".dat";
            using (var fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && bf.Deserialize(fs) is List<T> value)
                {
                    return value;
                }
                else
                {
                    return new List<T>();
                }
            }
        }

        public void Zapisz<T>(List<T> item)where T:class
        {
            var bf = new BinaryFormatter();
            var file = typeof(T) + ".dat";
            using (var fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, item);
            }
        }
    }
}
