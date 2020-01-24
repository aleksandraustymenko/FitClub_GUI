using FitClub.Controller;
using FitClub.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FitClub
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("pl-pl");
            var resourceManager = new ResourceManager("FitClub.Languages.Messages",typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello",culture));
            Thread.Sleep(3000);

            Console.WriteLine(resourceManager.GetString("EnterName",culture));
            var imie = Console.ReadLine();

            var użytkownikController = new UżytkownikController(imie);
            var jescControler = new JeśćControler(użytkownikController.Aktualny);
            var cwiczeniaControler = new CwiczeniaControler(użytkownikController.Aktualny);
            if(użytkownikController.NowyUżytkownik)
            {
                Console.WriteLine("Wprowadz płeć:");
                var plec = Console.ReadLine();
                var urodziny=ParseData("urodziny");
                var waga = ParseDouble("waga");
                var wzrost = ParseDouble("wzrost");
                

                użytkownikController.UstawNowegoUżytkownika(plec, urodziny, waga, wzrost);
            }
            Console.WriteLine(użytkownikController.Aktualny);

            
            while (true)
            {
                Console.WriteLine("Co chcesz zrobic?");
                Console.WriteLine("J-wprowadż posilek");
                Console.WriteLine("A-wprowadż ćwiczenia");
                Console.WriteLine("I -informacja o twórcy");
                Console.WriteLine("E-wyjście");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.J:
                        var jedzenie = WpiszJeść();
                        jescControler.Dodaj(jedzenie.Jedzenia, jedzenie.Waga);

                        foreach (var item in jescControler.Jeść.Jedzenie)
                        {
                            Console.WriteLine($"\t{item.Key}-{item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var cwiczenia = WpiszCwiczenia();
                        cwiczeniaControler.Dodaj(cwiczenia.Aktywnosc,cwiczenia.poczatek,cwiczenia.koniec);
                        foreach(var item in cwiczeniaControler.cwiczenia)
                        {
                            Console.WriteLine($"\t{item.Aktywnosc} od {item.Start.ToShortTimeString()} do {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.I:
                        Console.WriteLine("Projekt aplikacja konsolowa FitClub");
                        Console.WriteLine("Wykonała studentka || roku ISI Ustymenko Oleksandra");
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                 Console.ReadLine();
            }

        }

        private static (DateTime poczatek,DateTime koniec,Aktywnosc Aktywnosc) WpiszCwiczenia()
        {
            Console.WriteLine("Wprowadz nazwę ćwiczenia:");
            var nazwa = Console.ReadLine();

            var energia = ParseDouble("zużycie energii na minutę");

            var poczatek = ParseData("początek ćwiczenia");
            var koniec = ParseData("koniec ćwiczenia");
            var aktywnosc = new Aktywnosc(nazwa, energia);

            return (poczatek, koniec, aktywnosc);
        }

        private static (Jedzenia Jedzenia ,double Waga) WpiszJeść()
        {
            Console.WriteLine("Wprowadż nazwę dania:");
            var danie = Console.ReadLine();
            
            var kalorie = ParseDouble("kalorie");
            var bialko = ParseDouble("bialko");
            var tluszcze = ParseDouble("tłuszcze");
            var weglowodany = ParseDouble("weglowodany");
            var waga = ParseDouble("waga porcji");

            var jedzenie = new Jedzenia(danie,kalorie,bialko,tluszcze,weglowodany);

            return (Jedzenia:jedzenie,Waga: waga);
        }

        private static DateTime ParseData(string value)
        {
            DateTime urodziny;
            while (true)
            {
                Console.WriteLine($"Wprowadz {value}(dd.MM.yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out urodziny))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Nieprawidlowy format {value}");
                }
            }

            return urodziny;
        }

        private static double ParseDouble(string nazwa)
        {
            while (true)
            {
                Console.WriteLine($"Wprowadz {nazwa}:");
                if (double.TryParse(Console.ReadLine(), out double temp))
                {
                    return temp;
                }
                else
                {
                    Console.WriteLine($"Nieprawidlowy format pola {nazwa}");
                }
            }
        }
    }
}
