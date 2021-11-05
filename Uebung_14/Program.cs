using System;
using System.Collections.Generic;

namespace Uebung_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("14. Aufgabe");
            Console.ResetColor();
            
            Console.WriteLine(@"Schreiben Sie ein Programm, das vom Benutzer für jede volle Stunde des Tages einen Temperaturwert entgegennimmt und in einer Liste abspeichert.");

            List<decimal> temperatureWerte = new List<decimal>();

            for (int i = 0; i < 24; i++)
            {
                Console.WriteLine($"Bitte geben Sie den Temperatur-Wert für Stunde {i} ein.");
                decimal temperaturWert = decimal.Parse(Console.ReadLine()!);
                
                temperatureWerte.Add(temperaturWert);
            }

            for (int i = 0; i < 24; i++)
            {
                Console.WriteLine($"Eingabe für Stunde {i}: {temperatureWerte[i]}");
            }
        }
    }
}