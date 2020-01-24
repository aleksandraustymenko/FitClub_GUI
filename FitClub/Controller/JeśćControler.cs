using FitClub.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FitClub.Controller
{
   public  class JeśćControler:BazowaKlasa
   {
        private readonly Użytkownik użytkownik;
        public Jeść Jeść { get; }
        public List<Jedzenia> Jedzenie { get; }
        public JeśćControler(Użytkownik użytkownik)
        {
            this.użytkownik = użytkownik ?? throw new ArgumentNullException(nameof(użytkownik));
            Jedzenie = OtrzymacJedzenie();
            Jeść = OtrzymacJesc();

        }
      
        public void Dodaj(Jedzenia jedzenia,double waga)
        {
            var danie= Jedzenie.SingleOrDefault(j => j.Nazwa ==jedzenia.Nazwa);
            if(danie==null)
            {
                Jedzenie.Add(jedzenia);
                Jeść.Dodaj(jedzenia, waga);
                Zapisz();
            }
            else
            {
                Jeść.Dodaj(danie, waga);
                Zapisz();
            }
        }
        private Jeść OtrzymacJesc()
        {
            return Zaladuj<Jeść>().FirstOrDefault() ?? new Jeść(użytkownik);
        }

        private List<Jedzenia> OtrzymacJedzenie()
        {
            return Zaladuj<Jedzenia>() ?? new List<Jedzenia>();
            
        }
        private void Zapisz()
        {
            Zapisz( Jedzenie);
            Zapisz(new List<Jeść>() { Jeść});
        }
        
    }
}
