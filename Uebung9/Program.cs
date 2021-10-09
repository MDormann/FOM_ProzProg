using System;

namespace Uebung9
{
    class Program
    {
        static void Main(string[] args)
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
                    result = "Vokal";
                    break;
                case "e":
                    result = "Vokal";
                    break;
                case "i":
                    result = "Vokal";
                    break;
                case "o":
                    result = "Vokal";
                    break;
                case "u":
                    result = "Vokal";
                    break;
                case "ä":
                    result = "Vokal";
                    break;
                case "ö":
                    result = "Vokal";
                    break;
                case "ü":
                    result = "Vokal";
                    break;
                default:
                    result = "Konsonant";
                    break;
            }
            
            Console.WriteLine("[Version 1] Der Buchstabe '" + inputChar + "' ein '" + result + "'.");

            string result2;

            if (inputChar == "a" || inputChar == "e" || inputChar == "i" || inputChar == "o" || inputChar == "u" ||
                inputChar == "ä" || inputChar == "ö" || inputChar == "ü")
            {
                result2 = "Vokal";
            }
            else
            {
                result2 = "Konsonant";
            }
            
            Console.WriteLine("[Version 2] Der Buchstabe '" + inputChar + "' ein '" + result2 + "'.");
        }
    }
}