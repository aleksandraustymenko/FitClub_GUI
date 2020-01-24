using FitClub.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitClub.Controller
{
    class FitnessContext:DbContext
    {
        public FitnessContext() : base("DBConnection") { }

        public DbSet<Aktywnosc> aktywnosc { get; set; }
        public DbSet<Jeść> jesc { get; set; }
        public DbSet<Cwiczenia> cwiczenia { get; set; }
        public DbSet<Jedzenia> jedzenia { get; set; }
        public DbSet<Płeć> plec { get; set; }
        public DbSet<Użytkownik> użytkownik { get; set; }


    }
}
