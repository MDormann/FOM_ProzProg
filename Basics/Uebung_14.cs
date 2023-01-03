namespace Basics;

public class Uebung_14
{
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("14. Aufgabe");
        Console.ResetColor();
            
        Console.WriteLine(@"Schreiben Sie ein Programm, das vom Benutzer für jede volle Stunde des Tages einen Temperaturwert entgegennimmt und in einer Liste abspeichert.");

        List<decimal> temperaturWerte = new List<decimal>();

        for (int i = 0; i < 24; i++)
        {
            Console.WriteLine($"Bitte geben Sie den Temperatur-Wert für Stunde {i} ein.");
            decimal temperaturWert = decimal.Parse(Console.ReadLine()!);
                
            temperaturWerte.Add(temperaturWert);
        }

        for (int i = 0; i < 24; i++)
        {
            Console.WriteLine($"Eingabe für Stunde {i}: {temperaturWerte[i]}");
        }
    }
}