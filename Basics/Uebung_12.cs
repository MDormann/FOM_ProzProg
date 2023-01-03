namespace Basics;

public class Uebung_12
{
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("12. Aufgabe");
        Console.ResetColor();
            
        Console.WriteLine(@"Schreiben Sie ein Programm, das mithilfe einer Schleife herausfindet, welche natürliche Zahl die kleinste fünfstellige Quadratzahl hat.");
            
        int counter = 0;
        double result = 0;
            
        do
        {
            counter++;
            result = Math.Pow(counter, 2);
                
        } while (result < 10000);
            
        Console.WriteLine("Ergebnis: natürliche Zahl '" + counter + "' Quadratzahl '" + result + "'");
    }
}