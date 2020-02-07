using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using BusinessLayer;

namespace PresentationLayer
{
    class Program
    {
        public delegate void SimpleDelegate();

        static void Main(string[] args)
        {
            uint state = 0;
            char key;
            bool fail;
            string[] types = { "Auto:", "Motorka:", "Letadlo:", "Lod:" };

            //nacteni dat z XML, pokud existuje
            VehicleCollection col = XMLS.Load();
        
            SimpleDelegate simpleDelegate = new SimpleDelegate(col.Check);


            /// <summary>
            /// vypisy menu
            /// </summary>
            while (state != 5)
            {
                switch (state)
                {
                    case 0: //hlavni menu
                        simpleDelegate(); //kontrola, zda neni treba prevest nejake vozidlo do srotu
                        Console.Clear();
                        Console.WriteLine("HLAVNI MENU");
                        Console.WriteLine("");
                        Console.WriteLine("1. Seznam vozidel");
                        Console.WriteLine("2. Seznam vozidel k sesrotovani");
                        Console.WriteLine("3. Pridat nove vozidlo");
                        Console.WriteLine("4. Vymazat vozidlo");
                        Console.WriteLine("5. Konec aplikace");
                        Console.WriteLine("");
                        key = Console.ReadKey().KeyChar;
                        switch (key)
                        {
                            case '1':
                                state = 1;
                                break;
                            case '2':
                                state = 2;
                                break;
                            case '3':
                                state = 3;
                                break;
                            case '4':
                                state = 4;
                                break;
                            case '5':
                                state = 5;
                                break;
                        }
                        break;
                    case 1: //vypise seznam vozidel
                        Console.Clear();
                        Console.WriteLine("Seznam vozidel:");
                        Console.WriteLine("");
                        double overallValue = 0;
                        int count = 0;
                        foreach (Vehicle v in col.scrapList)
                        {
                            count++;
                            Console.WriteLine(types[v.Type-1]);
                            Console.WriteLine("Datum porizeni: {0}", v.Date.Date.ToString("d"));
                            Console.WriteLine("Znacka:         {0}", v.Brand);
                            Console.WriteLine("Pocet sedadel:  {0}", v.SeatsNumber);
                            Console.WriteLine("Spotreba:       {0}", v.Usage);
                            Console.WriteLine("Puvodni cena:   {0}", Math.Round((decimal)v.OriginalValue, 2));
                            Console.WriteLine("Aktualni cena:  {0}", Math.Round(v.ActualValue, 2));
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        foreach (Vehicle v in col.vehicleList)
                        {
                            count++;
                            overallValue += v.ActualValue;
                            Console.WriteLine(types[v.Type-1]);
                            Console.WriteLine("Datum porizeni: {0}", v.Date.Date.ToString("d"));
                            Console.WriteLine("Znacka:         {0}", v.Brand);
                            Console.WriteLine("Pocet sedadel:  {0}", v.SeatsNumber);
                            Console.WriteLine("Spotreba:       {0}", v.Usage);
                            Console.WriteLine("Puvodni cena:   {0}", Math.Round((decimal)v.OriginalValue, 2));
                            Console.WriteLine("Aktualni cena:  {0}", Math.Round(v.ActualValue, 2));
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        Console.WriteLine("Celkova hodnota: {0}Kc", overallValue);
                        Console.WriteLine("Celkem vozidel: {0}ks", count);
                        Console.WriteLine("");
                        Console.WriteLine("1. Zpet");
                        Console.WriteLine("");
                        key = Console.ReadKey().KeyChar;
                        if (key == '1') state = 0;
                        break;
                    case 2: //vypise seznam vozidel k sesrotovani
                        Console.Clear();
                        Console.WriteLine("Seznam vozidel k sesrotovani:");
                        Console.WriteLine("");
                        foreach (Vehicle v in col.scrapList)
                        {
                            Console.WriteLine(types[v.Type-1]);
                            Console.WriteLine("Datum porizeni: {0}", v.Date.Date.ToString("d"));
                            Console.WriteLine("Znacka:         {0}", v.Brand);
                            Console.WriteLine("Pocet sedadel:  {0}", v.SeatsNumber);
                            Console.WriteLine("Spotreba:       {0}", v.Usage);
                            Console.WriteLine("Puvodni cena:   {0}", Math.Round((decimal)v.OriginalValue, 2));
                            Console.WriteLine("Aktualni cena:  {0}", Math.Round(v.ActualValue, 2));
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        Console.WriteLine("1. Zpet");
                        Console.WriteLine("");
                        key = Console.ReadKey().KeyChar;
                        if (key == '1') state = 0;
                        break;
                    case 3: //pridani noveho vozidla
                        Console.Clear();
                        Console.WriteLine("Pridat nove vozidlo:");
                        Console.WriteLine("");

                        int type;
                        do
                        {
                            Console.Write("Typ vozidla (1: Auto, 2: Motorka, 3: Letadlo, 4: Lod): ");
                            type = Console.ReadKey().KeyChar - '0';
                            Console.WriteLine("");
                        } while (type < 1 || type > 4);
                        Console.WriteLine("");

                        DateTime date;
                        do
                        {
                            Console.Write("Datum porizeni: ");  
                        } while (!DateTime.TryParse(Console.ReadLine(), out date) || date.CompareTo(DateTime.Now) > 0);
                        Console.WriteLine("");

                        Console.Write("Znacka: "); 
                        string brand = Console.ReadLine();
                        Console.WriteLine("");

                        int seatsNumber = 0;
                        do
                        {
                            fail = false;
                            try
                            {
                                Console.Write("Pocet sedadel: ");
                                seatsNumber = Convert.ToInt32(Console.ReadLine());
                                if (seatsNumber < 0) fail = true;
                            }
                            catch (FormatException)
                            {
                                fail = true;
                            }
                            catch (OverflowException)
                            {
                                fail = true;
                            }
                        } while (fail);
                        Console.WriteLine();

                        int usage = 0;
                        do
                        {
                            fail = false;
                            try
                            {
                                Console.Write("Spotreba na 100km: ");
                                usage = Convert.ToInt32(Console.ReadLine());
                                if (usage < 0) fail = true;
                            }
                            catch (FormatException)
                            {
                                fail = true;
                            }
                            catch (OverflowException)
                            {
                                fail = true;
                            }
                        } while (fail);
                        Console.WriteLine();

                        int originalValue = 0;
                        do
                        {
                            fail = false;
                            try
                            {
                                Console.Write("Puvodni hodnota: ");
                                originalValue = Convert.ToInt32(Console.ReadLine());
                                if (originalValue < 0) fail = true;
                            }
                            catch (FormatException)
                            {
                                fail = true;
                            }
                            catch (OverflowException)
                            {
                                fail = true;
                            }
                        } while (fail);
                        Console.WriteLine("");

                        if (type == 1) {
                                Car newVehicle = new Car(date, originalValue, brand, seatsNumber, usage);
                                col.Add(newVehicle);
                        }
                        else if (type == 2) {
                                Motorcycle newVehicle = new Motorcycle(date, originalValue, brand, seatsNumber, usage);
                                col.Add(newVehicle);
                        }
                        else if (type == 3) {
                                Plane newVehicle = new Plane(date, originalValue, brand, seatsNumber, usage);
                                col.Add(newVehicle);
                        }
                        else {
                                Ship newVehicle = new Ship(date, originalValue, brand, seatsNumber, usage);
                                col.Add(newVehicle);
                        }
                        Console.WriteLine("");
                        Console.WriteLine("Vozidlo uspesne pridano!");
                        Console.WriteLine("");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        state = 0;
                        break;
                    case 4: //smazani vozidla
                        Console.Clear();
                        Console.WriteLine("Vymazat vozidlo:");
                        Console.WriteLine("");

                        int i = 0;
                        int j = 0;

                        foreach (Vehicle v in col.scrapList)
                        {
                            i++;
                            Console.WriteLine("{0}. "+types[v.Type - 1], i);
                            Console.WriteLine("Datum porizeni: {0}", v.Date.Date.ToString("d"));
                            Console.WriteLine("Znacka:         {0}", v.Brand);
                            Console.WriteLine("Pocet sedadel:  {0}", v.SeatsNumber);
                            Console.WriteLine("Spotreba:       {0}", v.Usage);
                            Console.WriteLine("Puvodni cena:   {0}", Math.Round((decimal)v.OriginalValue, 2));
                            Console.WriteLine("Aktualni cena:  {0}", Math.Round(v.ActualValue, 2));
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        foreach (Vehicle v in col.vehicleList)
                        {
                            j++;
                            Console.WriteLine("{0}. " + types[v.Type - 1], i+j);
                            Console.WriteLine("Datum porizeni: {0}", v.Date.Date.ToString("d"));
                            Console.WriteLine("Znacka:         {0}", v.Brand);
                            Console.WriteLine("Pocet sedadel:  {0}", v.SeatsNumber);
                            Console.WriteLine("Spotreba:       {0}", v.Usage);
                            Console.WriteLine("Puvodni cena:   {0}", Math.Round((decimal)v.OriginalValue, 2));
                            Console.WriteLine("Aktualni cena:  {0}", Math.Round(v.ActualValue, 2));
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        Console.WriteLine("{0}. Zpet", i+j+1);
                        Console.WriteLine("");

                        int number = 0;
                        do
                        {
                            fail = false;
                            try
                            {
                                number = Convert.ToInt32(Console.ReadLine());
                                if (number < 1 || number > i+j+1) fail = true;
                            }
                            catch (FormatException)
                            {
                                fail = true;
                            }
                            catch (OverflowException)
                            {
                                fail = true;
                            }
                        } while (fail);

                        if (number < i + j + 1)
                        {
                            if (number > i)
                            {
                                col.scrapList.RemoveAt(number - i - 1);
                            }
                            else
                            {
                                col.vehicleList.RemoveAt(number - 1);
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Vozidlo uspesne vymazano!");
                            Console.WriteLine("");
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                        }

                        state = 0;
                        break;

                }
            }

            //ulozi aktualni stav do xml souboru
            if (!XMLS.Save(col))
            {
                Console.WriteLine("Nepodarilo se ulozit do souboru.");
            }
           
        }
    }
}
