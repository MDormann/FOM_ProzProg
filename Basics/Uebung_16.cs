namespace Basics;

public class Uebung_16
{
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("16. Aufgabe");
        Console.ResetColor();
            
        Console.WriteLine(@"Schreiben Sie ein Programm, das vom Benutzer zehn Zahlen entgegennimmt, in einer Liste speichert und die Werte dann absteigend wieder ausgibt. Vermeiden Sie es, eingebaute Sortierverfahren zu nutzen!");

        int totalNumber = 10;
        List<int> numbers = new List<int>();
            
        for (int i = 1; i <= totalNumber; i++)
        {
            Console.WriteLine($"Bitte geben Sie eine Zahl ein");
            int number = int.Parse(Console.ReadLine()!);
                
            numbers.Add(number);
        }
            
        int swapNumber;

        for (int current = 0; current < totalNumber - 1; current++)
        {
            for (int next = current + 1; next < totalNumber; next++)
            {
                if (numbers[current] < numbers[next])
                {
                    swapNumber = numbers[current];
                    numbers[current] = numbers[next];
                    numbers[next] = swapNumber;
                }
            }
        }
            
        Console.WriteLine("Ergebnis: Absteigende Liste");
        foreach (var number in numbers)
        {
            Console.WriteLine("Zahl: '" + number + "'");
        }
    }
}