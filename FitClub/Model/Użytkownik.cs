using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitClub.Model
{
    /// <summary>
    /// Użytkownik
    /// </summary>
    /// 
    [Serializable]
   public  class Użytkownik
    {
        /// <summary>
        /// Parametry
        /// </summary>
        /// 
        public int ID { get; set; }
        public string Imie { get; set; }
        public int? PlecID { get; set; }
        public virtual Płeć Plec { get; set; }

        public DateTime Urodziny { get; set; }

        public double Waga { get; set; }
        
        public double Wzrost { get; set; }
        public virtual ICollection<Jeść> jesc { get; set; }
        public virtual ICollection<Cwiczenia> cwiczenia { get; set; }
        public int Wiek { get { return DateTime.Now.Year - Urodziny.Year; } }
        /// <summary>
        /// Stworzy nowego użytkownika
        /// </summary>
        /// <param name="imie">Imie użytkownika</param>
        /// <param name="płeć">Płeć</param>
        /// <param name="urodziny">Data urodzin</param>
        /// <param name="waga">Waga</param>
        /// <param name="wzrost">Wzrost</param>
        public Użytkownik(string imie,Płeć płeć,DateTime urodziny,double waga,double wzrost)
        {
            #region Sprawdzenia
            if (string.IsNullOrWhiteSpace(imie))
            {
                throw new ArgumentNullException(nameof(imie));
            }
            if(płeć==null)
            {
                throw new ArgumentNullException(nameof(płeć));
            }
            if (urodziny < DateTime.Parse("01.01.1960") || urodziny>=DateTime.Parse("01.01.2002")) 
            {
                throw new ArgumentException(nameof(urodziny));
            }
            if(waga<=0)
            {
                throw new ArgumentException(nameof(waga));
            }
            if(wzrost<=0)
            {
                throw new ArgumentException(nameof(wzrost));
            }
            #endregion
            Imie = imie;
            Plec = płeć;
            Urodziny = urodziny;
            Waga = waga;
            Wzrost = wzrost;
        }
        public Użytkownik() { }
        public Użytkownik(string imie)
        {
            if (string.IsNullOrWhiteSpace(imie))
            {
                throw new ArgumentNullException(nameof(imie));
            }
            Imie = imie;
        }
        public override string ToString()
        {
            return Imie + " " + Wiek;
        }

    }
}
