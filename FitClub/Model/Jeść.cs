using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitClub.Model
{ 
   /// <summary>
   /// Przejęcie jedzenia
   /// </summary>
   /// 
   [Serializable]
    public class Jeść
    {
        public int ID { get; set; }
        public DateTime Czas { get; set; }

        public Dictionary<Jedzenia,double> Jedzenie { get; set; }
        public int UżytkownikID { get; set; }
        public virtual Użytkownik Użytkownik { get; set; }
        public Jeść() { }
        public Jeść(Użytkownik użytkownik)
        {
            Użytkownik = użytkownik ?? throw new ArgumentNullException(nameof(użytkownik));
            Czas = DateTime.UtcNow;
            Jedzenie = new Dictionary<Jedzenia, double>();
        }
        public void Dodaj(Jedzenia jedzenia,double waga)
        { 
           var danie= Jedzenie.Keys.FirstOrDefault(j => j.Nazwa.Equals(jedzenia.Nazwa));

           if(danie==null)
           {
                Jedzenie.Add(jedzenia, waga);
           }
            else
            {
                Jedzenie[danie] += waga;
            }
        }

    }
}
