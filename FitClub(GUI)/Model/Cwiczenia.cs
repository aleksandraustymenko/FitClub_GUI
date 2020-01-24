using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitClub.Model
{
    [Serializable]
    public class Cwiczenia
    {
        public int ID { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public virtual Aktywnosc Aktywnosc { get; set; }
        public int AktywnoscID { get; set; }
        public int UżytkownikID { get; set; }
        
        public virtual Użytkownik Użytkownik { get; set; }
        public Cwiczenia() { }
        public Cwiczenia(DateTime start, DateTime finish, Aktywnosc aktywnosc, Użytkownik użytkownik)
        {
            Start = start;
            Finish = finish;
            Aktywnosc = aktywnosc;
            Użytkownik = użytkownik;
        }
    }
}
