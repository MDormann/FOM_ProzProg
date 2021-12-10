using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Uebung_17
{
    class Program
    {
        private static List<Address> Addresses = new List<Address>();
        private static string FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "addresses.csv");

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("17. Aufgabe");
            Console.ResetColor();
            
            Console.WriteLine(@"Das Ziel der Aufgabe ist es, eine kleine Anwendung zur Verwaltung von Adressen zu entwickeln. Weiterhin soll die Anwendung die Möglichkeit bieten, alle Datensätze zu speichern und bei erneuter Benutzung wieder zu laden.");
            Console.WriteLine(@"Folgende Daten wurden als relevant ausgewählt:");
            Console.WriteLine(@"Anrede, Titel, Vorname, Name, Straße, PLZ, Ort, Land Telefon, eMail-Adresse, Firma");
            Console.WriteLine(@"Funktionalitäten:");
            Console.WriteLine(@"Datensatz anlegen, ansehen, ändern, löschen. Datensatz über Index (primärer Schlüssel) und über Suchbegriff suchen");
            Console.WriteLine(@"Erweiterung für die ganz schnellen:");
            Console.WriteLine(@"Wie würden Sie die Anwendung unter realeren Bedingungen, hinsichtlich der Persistenz und der Datenmodellierung, gestalten?");

            ReadAddresses();
            
            
            Console.WriteLine("Willkommen in der Adressverwaltung!");
            while (true)
            {
                Console.WriteLine("Bitte wählen Sie eine Aktion aus:");
                Console.WriteLine("(1) Datensatz anlegen");
                Console.WriteLine("(2) Datensatz laden");
                Console.WriteLine("(3) Datensatz löschen");
                Console.WriteLine("(4) Datensatz suchen");

                int action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        CreateAddress();

                        break;
                    case 2:
                        Console.WriteLine("Datensatz laden:");
                        Console.Write("Bitte geben Sie die Id ein: ");
                        
                        var id = int.Parse(Console.ReadLine());
                        
                        var address = LoadAddress(id);
                        PrintAddress(address);
                        
                        break;
                    case 3:
                        DeleteAddress();
                        
                        break;
                    case 4:
                        SearchAddress();
                        
                        break;
                    default:
                        Console.WriteLine("Ungültige Aktion. Bitte erneut versuchen.");
                        break;
                }
            }
        }

        static void CreateAddress()
        {
            Console.WriteLine("Neuen Datensatz anlegen:");

            var address = new Address();
            
            Console.Write("Anrede: ");
            address.Anrede = Console.ReadLine();
            Console.Write("Titel: ");
            address.Titel = Console.ReadLine();
            Console.Write("Vorname: ");
            address.Vorname = Console.ReadLine();
            Console.Write("Name: ");
            address.Name = Console.ReadLine();
            Console.Write("Straße: ");
            address.Straße = Console.ReadLine();
            Console.Write("PLZ: ");
            address.PLZ = Console.ReadLine();
            Console.Write("Ort: ");
            address.Ort = Console.ReadLine();
            Console.Write("Land: ");
            address.Land = Console.ReadLine();
            Console.Write("Telefon: ");
            address.Telefon = Console.ReadLine();
            Console.Write("eMail: ");
            address.eMail = Console.ReadLine();
            Console.Write("Firma: ");
            address.Firma = Console.ReadLine();


            var maxId = 0;
            
            // Weg 1: mit "Boardmitteln"
            if(Addresses.Any())
                maxId = Addresses.Max(address => address.Id);

            // Weg 2: klassischer Weg
            foreach (var address1 in Addresses)
            {
                if (address.Id > maxId)
                    maxId = address.Id;
            }

            address.Id = maxId + 1;
            
            Addresses.Add(address);
            SaveAddresses();
        }

        static Address LoadAddress(int id)
        {
            Address address1 = new Address();

            foreach (var address in Addresses)
            {
                if (address.Id == id)
                    address1 = address;
            }

            var address2 = Addresses.FirstOrDefault(address => address.Id == id);

            return address1;
        }

        static void PrintAddress(Address address)
        {
            Console.WriteLine($"Id: {address.Id}");
            Console.WriteLine($"Anrede: {address.Anrede}");
            Console.WriteLine($"Titel: {address.Titel}");
            Console.WriteLine($"Vorname: {address.Vorname}");
            Console.WriteLine($"Name: {address.Name}");
            Console.WriteLine($"Straße: {address.Straße}");
            Console.WriteLine($"PLZ: {address.PLZ}");
            Console.WriteLine($"Ort: {address.Ort}");
            Console.WriteLine($"Land: {address.Land}");
            Console.WriteLine($"Telefon: {address.Telefon}");
            Console.WriteLine($"eMail: {address.eMail}");
            Console.WriteLine($"Firma: {address.Firma}");
        }
        
        static void ReadAddresses()
        {
            var inputLines = File.ReadAllLines(FileName, Encoding.UTF8);

            foreach (var line in inputLines)
            {
                var entries = line.Split(";");

                if (entries.Length != 12)
                {
                    Debug.WriteLine("Wrong data format!");
                    continue;
                }

                foreach (var entry in entries)
                {
                    Addresses.Add(new Address()
                    {
                        Id = int.Parse(entry[0].ToString()),
                        Anrede = entry[1].ToString(),
                        Titel = entry[2].ToString(), 
                        Vorname = entry[3].ToString(),
                        Name = entry[4].ToString(),
                        Straße = entry[5].ToString(),
                        PLZ = entry[6].ToString(),
                        Ort = entry[7].ToString(),
                        Land = entry[8].ToString(),
                        Telefon = entry[9].ToString(),
                        eMail = entry[10].ToString(),
                        Firma = entry[11].ToString(),
                    });
                }
            }
        }

        static void DeleteAddress()
        {
            Console.WriteLine("Datensatz löschen:");
            
            Console.Write("Bitte geben Sie die Id ein: ");
            var id = int.Parse(Console.ReadLine());

            var address = LoadAddress(id);

            Addresses.Remove(address);
            SaveAddresses();
        }

        static void SearchAddress()
        {
            Console.WriteLine("Datensatz suchen:");
            
            Console.Write("Bitte geben Sie den Namen ein: ");
            var name = Console.ReadLine();

            foreach (var address in Addresses)
            {
                if (address.Name.Contains(name))
                    PrintAddress(address);
            }
        }
        
        static void SaveAddresses()
        {
            List<string> export = new List<string>();
            
            foreach (var address in Addresses)
            {
                export.Add($"{address.Id};" +
                           $"{address.Anrede};" +
                           $"{address.Titel};" +
                           $"{address.Vorname};" +
                           $"{address.Name};" +
                           $"{address.Straße};" +
                           $"{address.PLZ};" +
                           $"{address.Ort};" +
                           $"{address.Land};" +
                           $"{address.Telefon};" +
                           $"{address.eMail};" +
                           $"{address.Firma}");
            }
            
            File.WriteAllLines(FileName, export, Encoding.UTF8);
        }
    }
}