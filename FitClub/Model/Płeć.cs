using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitClub.Model
{
    /// <summary>
    /// Płeć
    /// </summary>
    [Serializable]
    public class Płeć
    {
        public int ID { get; set; }
        /// <summary>
        /// Nazwa(Imie)
        /// </summary>
        public string Imie { get; set; }
        public virtual ICollection<Użytkownik> użytkownik { get; set; }
        public Płeć() { }
        /// <summary>
        /// Stworzy nowy płeć
        /// </summary>
        /// <param name="imie">Imie płeć</param>
        public Płeć(string imie)
        {
            if(string.IsNullOrWhiteSpace(imie))
            {
                throw new ArgumentNullException(nameof(imie));
            }
            Imie = imie;
        }
        public override string ToString()
        {
            return Imie;
        }


    }
}
