namespace Basics;

public class Uebung_2
{
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("2. Aufgabe");
        Console.ResetColor();
            
        Console.WriteLine(@"Fragen Sie den Benutzer nach einer reellen Zahl größer 0. Legen Sie die Zahl in einer geeigneten Variable ab. Sehen Sie die Zahl als Radius eines Kreises an und berechnen Sie mit ihr den Umfang und die Fläche eben jenen Kreises. Geben Sie das Ergebnis aus.");

        double radius;
        Console.WriteLine("Bitte geben Sie eine Zahl größer 0 ein: ");
        radius = double.Parse(Console.ReadLine()!);
            
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Ergebnisse");
        Console.ResetColor();

        Console.WriteLine("Umfang (π * r^2): \t" + (Math.PI * radius * radius));
        Console.WriteLine("Umfang (π * r^2): \t" + (Math.PI * Math.Pow(radius, 2)));
        Console.WriteLine("Flaeche (2 * π * r):\t" + (2 * Math.PI * radius));
    }
}