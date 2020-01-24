using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitClub.Model
{
    [Serializable]
    public class Aktywnosc
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public double KalorieNaMin { get; set; }
        public virtual ICollection<Cwiczenia> cwiczenia { get; set; }
        public Aktywnosc() { }
        public Aktywnosc(string nazwa,double kalorieNaMin)
        {
            Nazwa = nazwa;
            KalorieNaMin = kalorieNaMin;
        }
        public override string ToString()
        {
            return Nazwa;
        }


    }
}
