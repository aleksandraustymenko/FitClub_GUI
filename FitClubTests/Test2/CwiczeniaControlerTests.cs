using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitClub.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitClub.Model;

namespace FitClub.Controller.Tests
{
    [TestClass()]
    public class CwiczeniaControlerTests
    {
        [TestMethod()]
        public void DodajTest()
        {
            var użytkownik = Guid.NewGuid().ToString();
            var aktywnoscNazwa = Guid.NewGuid().ToString();
            var rnd = new Random();
            var użytkownikControler = new UżytkownikController(użytkownik);
            var cwiczeniaControler = new CwiczeniaControler(użytkownikControler.Aktualny);
            var aktywnosc = new Aktywnosc(aktywnoscNazwa, rnd.Next(10, 50));
            //Act
            cwiczeniaControler.Dodaj(aktywnosc, DateTime.Now,DateTime.Now.AddHours(1));
            //Assert
            Assert.AreEqual(aktywnoscNazwa, cwiczeniaControler.aktywnosc.First().Nazwa);
        }
    }
}