namespace Basics;

public class Uebung_6
{
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("6. Aufgabe");
        Console.ResetColor();
            
        Console.WriteLine(@"Fragen Sie den Kunden einer Tankstelle nach der Menge an getanktem Benzin (in l) und speichern Sie diese in einer geeigneten Variable. Berechnen Sie mit einem angemessenen Literpreis (€/l) die Gesamtsumme. Fragen Sie weiterhin, ob der Benutzer eine Kundenkarte hat. Wenn ja, reduzieren Sie den Gesamtpreis um 2%. Wenn nein, dann passiert nichts. Geben Sie die endgültige Summe aus.");

        double filledPetrol = 0;
        double pricePerLitre = 1.75d;
        double result = 0;
            
        Console.WriteLine("Wieviel Liter haben Sie getankt? ");
        filledPetrol = double.Parse(Console.ReadLine()!);

        result = filledPetrol * pricePerLitre;
            
        Console.WriteLine("Der aktuelle Literpreis beträgt: " + pricePerLitre);
        Console.WriteLine("Besitzen Sie eine Kundenkarte? (y)es or (n)o");
        string customerCardAvailable = Console.ReadLine();

        if (customerCardAvailable == "y")
        {
            result = result * 0.98d;
        }


        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Ergebnisse");
        Console.ResetColor();

        Console.WriteLine("Sie müssen " + result + " EUR bezahlen.");
    }
}