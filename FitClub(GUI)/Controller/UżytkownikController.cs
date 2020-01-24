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
    public class UżytkownikController:BazowaKlasa
    {
        public List<Użytkownik> Użytkownik { get; }

        public Użytkownik Aktualny { get; }
        public bool NowyUżytkownik { get; } = false;
        public UżytkownikController(string użytkownikName)
        {
            if(string.IsNullOrWhiteSpace(użytkownikName))
            {
                throw new ArgumentNullException();
            }
            Użytkownik = OtrzymacUżytkownika();

            Aktualny = Użytkownik.SingleOrDefault(u => u.Imie == użytkownikName);
            if(Aktualny==null)
            {
                Aktualny = new Użytkownik(użytkownikName);
                Użytkownik.Add(Aktualny);
                NowyUżytkownik = true;
            }
            
        }
        public void UstawNowegoUżytkownika(string plec,DateTime urodziny,double waga=1,double wzrost=1)
        {
            Aktualny.Plec = new Płeć(plec);
            Aktualny.Urodziny = urodziny;
            Aktualny.Waga = waga;
            Aktualny.Wzrost = wzrost;
            Zapisz();
        }
        public List<Użytkownik> OtrzymacUżytkownika()
        {
            return Zaladuj<Użytkownik>() ?? new List<Użytkownik>(); 
        }
        /// <summary>
        /// Zapisać danne użytkownika
        /// </summary>
        public void Zapisz()
        {
            Zapisz(Użytkownik); 
        }

        
        
    }
}
