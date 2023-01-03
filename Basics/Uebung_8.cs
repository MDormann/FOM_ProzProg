namespace Basics;

public class Uebung_8
{
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("8. Aufgabe");
        Console.ResetColor();
            
        Console.WriteLine(@"Schreiben Sie ein Programm, das den Benutzer nach einer Zahl 1-12 fragt und die Anzahl der Tage des passenden Monats ausgibt.");

        var inputNumber = 0;
            
        Console.WriteLine("Bitte geben Sie eine Zahl zwischen 1 und 12 an.");
        inputNumber = int.Parse(Console.ReadLine()!);

        int result;
        switch (inputNumber)
        {
            case 1:
                result = 31;
                break;
            case 2:
                result = 28;
                break;
            case 3:
                result = 31;
                break;
            case 4:
                result = 30;
                break;
            case 5:
                result = 31;
                break;
            case 6:
                result = 30;
                break;
            case 7:
                result = 31;
                break;
            case 8:
                result = 31;
                break;
            case 9:
                result = 30;
                break;
            case 10:
                result = 31;
                break;
            case 11:
                result = 30;
                break;
            case 12:
                result = 31;
                break;
            default:
                result = -1;
                break;
        }
            
        Console.WriteLine("[Version 1] Der Monat '" + inputNumber + "' hat '" + result + "' Tage");
            
        Console.WriteLine("[Version 2] Der Monat '" + inputNumber + "' hat '" + DateTime.DaysInMonth(DateTime.Now.Year, inputNumber) + "' Tage");
    }
}