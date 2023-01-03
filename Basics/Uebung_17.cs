using System.Diagnostics;
using System.Text;

namespace Basics;

public class Uebung_17
{
    private static AddressManager _addressManager =
        new AddressManager(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "addresses.csv"));

    public static void Run()
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

        Console.WriteLine("Willkommen in der Adressverwaltung!");


        while (true)
        {
            Console.WriteLine("Bitte wählen Sie eine Aktion aus:");
            Console.WriteLine("(1) Datensatz anlegen");
            Console.WriteLine("(2) Datensatz laden");
            Console.WriteLine("(3) Datensatz löschen");
            Console.WriteLine("(4) Datensatz suchen");
            Console.WriteLine("(5) Anwendung beeenden");

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

                    var address = _addressManager.LoadAddress(id);
                    PrintAddress(address);

                    break;
                case 3:
                    DeleteAddress();

                    break;
                case 4:
                    SearchAddress();

                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Ungültige Aktion. Bitte erneut versuchen.");
                    break;
            }

            if (action == 5)
                break;
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


        _addressManager.CreateAddress(address);
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

    static void DeleteAddress()
    {
        Console.WriteLine("Datensatz löschen:");

        Console.Write("Bitte geben Sie die Id ein: ");
        var id = int.Parse(Console.ReadLine());

        _addressManager.DeleteAddress(id);
    }

    static void SearchAddress()
    {
        Console.WriteLine("Datensatz suchen:");

        Console.Write("Bitte geben Sie den Namen ein: ");
        var name = Console.ReadLine();

        _addressManager.SearchAddress(name);
    }
}

public class Address
{
    public int Id { get; set; }
    public string Anrede { get; set; }
    public string Titel { get; set; }
    public string Vorname { get; set; }
    public string Name { get; set; }
    public string Straße { get; set; }
    public string PLZ { get; set; }
    public string Ort { get; set; }
    public string Land { get; set; }
    public string Telefon { get; set; }
    public string eMail { get; set; }
    public string Firma { get; set; }
}

public class AddressManager
{
    private List<Address> Addresses = new List<Address>();
    private string FileName;

    public AddressManager(string fileName)
    {
        FileName = fileName;
        ReadAddresses();
    }

    public void CreateAddress(Address address)
    {
        var maxId = 0;

        // Weg 1: mit "Boardmitteln"
        if (Addresses.Any())
            maxId = Addresses.Max(address => address.Id);

        address.Id = maxId + 1;

        Addresses.Add(address);
        SaveAddresses();
    }

    public Address LoadAddress(int id)
    {
        Address address1 = new Address();

        foreach (var address in Addresses)
        {
            if (address.Id == id)
                address1 = address;
        }

        return address1;
    }


    public void ReadAddresses()
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

    public void DeleteAddress(int id)
    {
        var address = LoadAddress(id);

        Addresses.Remove(address);
        SaveAddresses();
    }

    public Address SearchAddress(string name)
    {
        foreach (var address in Addresses)
        {
            if (address.Name.Contains(name))
                return address;
        }

        return null;
    }

    public void SaveAddresses()
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