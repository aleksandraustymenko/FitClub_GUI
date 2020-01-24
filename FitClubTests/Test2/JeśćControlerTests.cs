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
    public class JeśćControlerTests
    {
        [TestMethod()]
        public void DodajTest()
        {
            //Arrange
            var użytkownik = Guid.NewGuid().ToString();
            var danie = Guid.NewGuid().ToString();
            var rnd = new Random();
            var użytkownikControler = new UżytkownikController(użytkownik);
            var jeśćControler = new JeśćControler(użytkownikControler.Aktualny);
            var jedzenie = new Jedzenia(danie, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));
            //Act
            jeśćControler.Dodaj(jedzenie, 100);
            //Assert
            Assert.AreEqual(jedzenie.Nazwa, jeśćControler.Jeść.Jedzenie.First().Key.Nazwa);
        }
    }
}