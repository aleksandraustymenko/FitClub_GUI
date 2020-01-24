using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FitClub.Controller
{
    public abstract class BazowaKlasa
    {
        private readonly IDataSaver saver = new SerializeDataSaver();


        protected void Zapisz<T>(List<T> item) where T:class
        {
            saver.Zapisz(item);
        }
        protected List<T> Zaladuj<T>() where T:class
        {
           return saver.Zaladuj<T>();
        }
    }
}
