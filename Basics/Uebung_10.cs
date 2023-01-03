namespace Basics;

public class Uebung_10
{
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("10. Aufgabe");
        Console.ResetColor();
            
        Console.WriteLine(@"Schreiben Sie ein Programm, das den Benutzer nach einer Zahl n fragt und dann alle Zahlen von 1 bis n ausgibt. Nutzen Sie dafür einmal eine While- und einmal eine For-Schleife.");

        int inputNumber;
            
        Console.WriteLine("Bitte geben Sie eine Zahl ein");
        inputNumber = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Variante 1: While-Schleife");
        int counter = 1;
            
        while (counter <= inputNumber)
        {
            Console.WriteLine("Zahl: " + counter);
            counter++;
        }
            
        Console.WriteLine("Variante 2: For-Schleife");
            
        for (int i = 1; i <= inputNumber; i++)
        {
            Console.WriteLine("Zahl: " + i);
        }

            
    }
}