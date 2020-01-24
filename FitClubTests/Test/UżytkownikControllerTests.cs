using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitClub.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitClub.Controller.Tests
{
    [TestClass()]
    public class UżytkownikControllerTests
    {
        
        [TestMethod()]
        public void UstawNowegoUżytkownikaTest()
        {
            //Arrange
            var użytkownikName = Guid.NewGuid().ToString();
            var urodziny = DateTime.Now.AddYears(-18);
            var waga = 54;
            var wzrost = 174;
            var plec = "kobieta";
            var controler = new UżytkownikController(użytkownikName);
            //Act
            controler.UstawNowegoUżytkownika(plec, urodziny, waga, wzrost);
            var controler2 = new UżytkownikController(użytkownikName);
            
            //Assert
            Assert.AreEqual(użytkownikName,controler2.Aktualny.Imie);
            Assert.AreEqual(plec, controler2.Aktualny.Plec.Imie);
            Assert.AreEqual(urodziny, controler2.Aktualny.Urodziny);
            Assert.AreEqual(waga, controler2.Aktualny.Waga);
            Assert.AreEqual(wzrost, controler2.Aktualny.Wzrost);
           
        }

        [TestMethod()]
        public void ZapiszTest()
        {
            //Arrange
            var użytkownikName = Guid.NewGuid().ToString();
            //Act
            var controler = new UżytkownikController(użytkownikName);
            //Assert
            Assert.AreEqual(użytkownikName,controler.Aktualny.Imie);
        }

        
    }
}