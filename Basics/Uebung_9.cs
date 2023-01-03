namespace Basics;

public class Uebung_9
{
    public static void Run()
    {
            
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("9. Aufgabe");
        Console.ResetColor();
            
        Console.WriteLine(@"Schreiben Sie ein Programm, um herauszufinden, ob ein einzelner Buchstabe ein Konsonant oder ein Vokal ist.");

        string inputChar;
            
        Console.WriteLine("Bitte geben Sie einen Buchstaben ein");
        inputChar = Console.ReadLine()!.ToLower();

        string result;
        switch (inputChar)
        {
            case "a":
            case "e":
            case "i":
            case "o":
            case "u":
            case "ä":
            case "ö":
            case "ü":
                result = "Vokal";
                break;
            default:
                result = "Konsonant";
                break;
        }
            
        Console.WriteLine("[Version 1] Der Buchstabe '" + inputChar + "' ein '" + result + "'.");

        string result2 = "Konsonant";

        if (inputChar == "a" || inputChar == "e" || inputChar == "i" || inputChar == "o" || inputChar == "u" ||
            inputChar == "ä" || inputChar == "ö" || inputChar == "ü")
        {
            result2 = "Vokal";
        }

        Console.WriteLine("[Version 2] Der Buchstabe '" + inputChar + "' ein '" + result2 + "'.");
    }
}