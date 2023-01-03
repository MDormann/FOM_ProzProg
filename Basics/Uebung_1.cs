namespace Basics;

public static class Uebung_1
{
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1. Aufgabe");
        Console.ResetColor();
            
        Console.WriteLine(@"Legen Sie zwei Variablen an, die bei eine beliebige Zahl aufnehmen können. Führen Sie dann die Grundrechenarten der Mathematik mit beiden Variablen durch und geben Sie das jeweilige Ergebnis aus.");

        int zahl1 = 0;
        int zahl2 = 0;
             
        Console.WriteLine("Zahl 1: ");
        zahl1 = Convert.ToInt32(Console.ReadLine());
             
        Console.WriteLine("Zahl 2: ");
        zahl2 = Convert.ToInt32(Console.ReadLine());
        
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Ergebnisse");
        Console.ResetColor();
        
        Console.WriteLine("Addition:\t" + (zahl1 + zahl2));
        Console.WriteLine($"Subtraktion:\t {(zahl1 - zahl2)}");
        Console.WriteLine("Multiplikation:\t" + (zahl1 * zahl2));
        Console.WriteLine("Division:\t" + (zahl1 / zahl2));
        
    }
}