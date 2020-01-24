using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitClub.Controller
{
   public  interface IDataSaver
    {
        void Zapisz<T>(List<T> item)where T:class;
        List<T> Zaladuj<T>()where T:class;
    }
}
