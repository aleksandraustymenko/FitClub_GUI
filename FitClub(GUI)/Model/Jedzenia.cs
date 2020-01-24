using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitClub.Model
{
    [Serializable]
    public class Jedzenia
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }

        public double Białko { get; set; }

        public double Tłuszcze { get; set; }

        public double Weglowodany { get; set; }
        /// <summary>
        /// Kalorie za 100 gramów
        /// </summary>
        public double Kalorie { get; set; }
        public virtual ICollection<Jeść> jesc { get; set; }
        public Jedzenia() { }
       
        public Jedzenia(string nazwa):this(nazwa,0,0,0,0)
        {

        }
        public Jedzenia(string nazwa, double kalorie, double bialko, double tluszcze, double weglowodany)
        {
            Nazwa = nazwa;
            Kalorie = kalorie / 100.0;
            Białko = bialko / 100.0;
            Tłuszcze = tluszcze / 100.0;
            Weglowodany = weglowodany / 100.0;
        }
        public override string ToString()
        {
            return Nazwa;
        }
    }
}
