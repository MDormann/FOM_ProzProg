namespace Basics;

public class Uebung_5
{
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("5. Aufgabe");
        Console.ResetColor();
        
        Console.WriteLine(@"Fragen Sie den Benutzer nacheinander nach drei Zahlen und speichern Sie diese in geeigneten Variablen. Geben Sie die Zahlen dann aufsteigend wieder aus.");

        int[] arrayOfNumber = new int[3];
        int number1;
        int number2;
        int number3;
        
        Console.WriteLine("Zahl 1: ");
        arrayOfNumber[0] = number1 = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Zahl 2: ");
        arrayOfNumber[1] = number2 = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Zahl 3: ");
        arrayOfNumber[2] = number3 = int.Parse(Console.ReadLine()!);
        
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Ergebnisse");
        Console.ResetColor();
        
        int placeHolder = 0;

        if (number1 > number2)
        {
            placeHolder = number1;
            number1 = number2;
            number2 = placeHolder;
        }

        if (number2 > number3)
        {
            placeHolder = number2;
            number2 = number3;
            number3 = placeHolder;
        }

        if (number1 > number2)
        {
            placeHolder = number1;
            number1 = number2;
            number2 = placeHolder;
        }

        Console.WriteLine("Reihenfolge:\t" + number1 + ", " + number2 + ", "+ number3);
        
        Array.Sort(arrayOfNumber);

        Console.Write("Reihenfolge:\t");
        for (int i = 0; i < arrayOfNumber.Length; i++)
        {
            string output = Convert.ToString(arrayOfNumber[i]);

            if (i < arrayOfNumber.Length -1)
            {
                output += ", ";
            }
            
            Console.Write(output);
        }
    }
}