namespace Basics;

public class Uebung_15
{
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("15. Aufgabe");
        Console.ResetColor();
            
        Console.WriteLine(@"Schreiben Sie ein Programm, das vom Benutzer zwölf Monatstemperaturen entgegennimmt, in einer passenden Liste speichert und dann den Jahresmittelwert ausgibt.");
            
        List<decimal> temperaturWerte = new List<decimal>();
        decimal summe = 0;
            
        for (int i = 1; i <= 12; i++)
        {
            Console.WriteLine($"Bitte geben Sie den Monat {i} ein.");
            decimal temperaturWert = decimal.Parse(Console.ReadLine()!);
                
            temperaturWerte.Add(temperaturWert);
            summe += temperaturWert;
        }

        Console.WriteLine($"Der Jahresmittelwert beträgt: {summe / 12}");
            
    }
}