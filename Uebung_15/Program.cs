using System;
using System.Collections.Generic;

namespace Uebung_15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("15. Aufgabe");
            Console.ResetColor();
            
            Console.WriteLine(@"Schreiben Sie ein Programm, das vom Benutzer zwölf Monatstemperaturen entgegennimmt, in einer passenden Liste speichert und dann den Jahresmittelwert ausgibt.");
            
            List<decimal> temperatureWerte = new List<decimal>();
            decimal summe = 0;
            
            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine($"Bitte geben Sie den Monat {i} ein.");
                decimal temperaturWert = decimal.Parse(Console.ReadLine()!);
                
                temperatureWerte.Add(temperaturWert);
                summe += temperaturWert;
            }

            
            Console.WriteLine($"Der Jahresmittelwert beträgt: {summe / 12}");
            
        }
    }
}