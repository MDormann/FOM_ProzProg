namespace Basics;

public class Uebung_3
{
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("3. Aufgabe");
        Console.ResetColor();
            
        Console.WriteLine(@"Fragen Sie den Benutzer nach einer Distanz (in km) und einer Zeit (in Stunden und Minuten). Legen Sie alle drei Werte in geeigneten Variablen ab und berechnen Sie damit die Geschwindigkeit (in km/h). Geben Sie das Ergebnis aus.");

        double distance;
        Console.WriteLine("Bitte geben Sie die Distanz in km an: ");
        distance = double.Parse(Console.ReadLine()!);

        int hour;
        Console.WriteLine("Bitte geben Sie die Stunden an: ");
        hour = int.Parse(Console.ReadLine()!);

        int minute;
        Console.WriteLine("Bitte geben Sie die Minuten an: ");
        minute = int.Parse(Console.ReadLine()!);

        double hourminute = ((hour * 60d) + minute) / 60d;
            
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Ergebnisse");
        Console.ResetColor();

        Console.WriteLine("Die Geschwindigkeit (km/h) beträgt: \t" + (distance / hourminute));
    }
}