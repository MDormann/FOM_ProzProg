// See https://aka.ms/new-console-template for more information

using Basics;

while(true) 
{
    Console.WriteLine("Hallo zu den Basics. " + Environment.NewLine + "Bitte wähle deine Übung: ");

    var uebung = Convert.ToInt32(Console.ReadLine());
    switch(uebung)
    {
        case 1: Uebung_1.Run(); break;
        case 2: Uebung_2.Run(); break;
        case 3: Uebung_3.Run(); break;
        case 4: Uebung_4.Run(); break;
        case 5: Uebung_5.Run(); break;
        case 6: Uebung_6.Run(); break;
        case 7: Uebung_7.Run(); break;
        case 8: Uebung_8.Run(); break;
        case 9: Uebung_9.Run(); break;
        case 10: Uebung_10.Run(); break;
        case 11: Uebung_11.Run(); break;
        case 12: Uebung_12.Run(); break;
        case 13: Uebung_13.Run(); break;
        case 14: Uebung_14.Run(); break;
        case 15: Uebung_15.Run(); break;
        case 16: Uebung_16.Run(); break;
        case 17: Uebung_17.Run(); break;
        default: Console.WriteLine("Ungültige Übung ausgewählt!."); break;
    }
}
