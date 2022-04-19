using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Uebung_17
{
    public class AddressManager
    {
        private List<Address> Addresses = new List<Address>();
        private string FileName;

        public AddressManager(string fileName)
        {
            FileName = fileName;
            ReadAddresses();
        }
        
        public Address CreateAddress(Address address)
        {
            var maxId = 0;
            
            // Weg 1: mit "Boardmitteln"
            if(Addresses.Any())
                maxId = Addresses.Max(address => address.Id);

            address.Id = maxId + 1;
            
            Addresses.Add(address);
            SaveAddresses();

            return address;
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
}