using FitClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitClub.Controller
{
    public class CwiczeniaControler: BazowaKlasa
    {
        private readonly Użytkownik użytkownik;
       
        public List<Cwiczenia> cwiczenia { get; }
        public List<Aktywnosc> aktywnosc { get; }
        public CwiczeniaControler(Użytkownik użytkownik)
        {
            this.użytkownik = użytkownik ?? throw new ArgumentNullException(nameof(użytkownik));
            cwiczenia = OtrzymacCwiczenia();
            aktywnosc = OtrzymacAktywnosc();
        }
        public void Dodaj(Aktywnosc Aktywnosc,DateTime poczatek,DateTime koniec)
        {
            var akt = aktywnosc.SingleOrDefault(a => a.Nazwa == Aktywnosc.Nazwa);
            if(akt==null)
            {
                aktywnosc.Add(Aktywnosc);

                var Cwiczenia = new Cwiczenia(poczatek, koniec, Aktywnosc, użytkownik);
                cwiczenia.Add(Cwiczenia);
            }
            else
            {
                var Cwiczenia = new Cwiczenia(poczatek, koniec, akt, użytkownik);
                cwiczenia.Add(Cwiczenia);
            }
            Zapisz();
        }
        private List<Aktywnosc> OtrzymacAktywnosc()
        {
            return Zaladuj<Aktywnosc>() ?? new List<Aktywnosc>();
        }

        private List<Cwiczenia> OtrzymacCwiczenia()
        {
            return Zaladuj<Cwiczenia>() ?? new List<Cwiczenia>();
        }
        private void Zapisz()
        {
            Zapisz(cwiczenia);
            Zapisz(aktywnosc);
        }
    }
}
