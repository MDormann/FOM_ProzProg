namespace Basics;

public class Uebung_13
{
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("13. Aufgabe");
        Console.ResetColor();
            
        Console.WriteLine(@"Schreiben Sie ein Programm, das den Benutzer nach einem Betrag fragt und dann eine mögliche Stückelung in €-Scheinen ausgibt.");
            
            
        int[] verfuegbareStueckelung = {500, 200, 100, 50, 20, 10, 5};
        int inputNumber;
            
        Console.WriteLine("Bitte geben Sie einen Betrag in EUR an:");
        inputNumber = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < verfuegbareStueckelung.Length; i++)
        {
            //Prüfe mögliche Anzahl für Schein x
            int schein = verfuegbareStueckelung[i];
                
            //Ermittle die Anzahl der möglichen Scheine
            int anzahlMoeglicherScheine = (int)(inputNumber / schein);

            //Ziehe den ermittelten Betrag vom Eingabebetrag ab
            inputNumber = inputNumber - (anzahlMoeglicherScheine * schein);
                
            if(anzahlMoeglicherScheine > 0)
                Console.WriteLine($"{anzahlMoeglicherScheine} x {schein} EUR");
        }
            
        Console.WriteLine($"Es verbleibt ein Rest von {inputNumber} EUR");
    }
}