namespace Basics;

public class Uebung_7
{
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("7. Aufgabe");
        Console.ResetColor();
            
        Console.WriteLine(@"Schreiben Sie ein Programm, das den Benutzer nach einer Zahl 1-7 fragt und dann den zur Zahl passenden Wochentag ausgibt.");

        var inputNumber = 0;
            
        Console.WriteLine("Bitte geben Sie eine Zahl zwischen 1 und 7 an.");
        inputNumber = int.Parse(Console.ReadLine()!);

        string result;
        switch (inputNumber)
        {
            case 1:
                result = "Montag";
                break;
            case 2:
                result = "Dienstag";
                break;
            case 3:
                result = "Mittwoch";
                break;
            case 4:
                result = "Donnerstag";
                break;
            case 5:
                result = "Freitag";
                break;
            case 6:
                result = "Samstag";
                break;
            case 7:
                result = "Sonntag";
                break;
            default:
                result = "n/a";
                break;
        }
            
        Console.WriteLine("[Version 1] Sie haben den Wochentag '" + result + "' ausgewählt");

        string result2 = inputNumber switch
        {
            1 => "Montag",
            2 => "Dienstag",
            3 => "Mittwoch",
            4 => "Donnerstag",
            5 => "Freitag",
            6 => "Samstag",
            7 => "Sonntag",
            _ => "n/a"
        };

        Console.WriteLine("[Version 2] Sie haben den Wochentag '" + result2 + "' ausgewählt");
            
        Console.WriteLine("[Version 3] Sie haben den Wochentag '" + (DayOfWeek)(inputNumber -1) + "' ausgewählt");
    }
}