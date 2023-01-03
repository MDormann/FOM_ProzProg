namespace Basics;

public class Uebung_4
{
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("4. Aufgabe");
        Console.ResetColor();
            
        Console.WriteLine(@"Fragen Sie den Benutzer nach drei Wörtern, die Sie in geeigneten Variablen ablegen. Geben Sie danach die Wörter in der umgekehrten Reihenfolge aus.");

        string word1 = "";
        string word2 = "";
        string word3 = "";
            
        Console.WriteLine("Wort 1: ");
        word1 = Console.ReadLine();

        Console.WriteLine("Wort 2: ");
        word2 = Console.ReadLine();
            
        Console.WriteLine("Wort 3: ");
        word3 = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Ergebnisse");
        Console.ResetColor();

        Console.WriteLine(word3);
        Console.WriteLine(word2);
        Console.WriteLine(word1);
            
        Console.WriteLine("Wörter bitte Komma-getrennt angeben (,): ");
        string combinedWords = Console.ReadLine();

        var wordsInArray = combinedWords?.Split(",");

        //Variante 1:
        Console.WriteLine("Variante 1 (Umgedrehte for-Schleife):");
        for (int i = wordsInArray.Length - 1; i >= 0; i--)
        {
            Console.WriteLine(wordsInArray[i]);
        }
        
        //Variante 2: Array umdrehen mit der Funktion Array.Reverse()
        Array.Reverse(wordsInArray!);

        Console.WriteLine("Variante 2 (Array.Reverse):");
        for (int i = 0; i < wordsInArray.Length; i++)
        {
            Console.WriteLine(wordsInArray[i]);
        }

    }
}