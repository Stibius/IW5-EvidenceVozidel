using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using DataLayer;
using System.Data.SqlClient;
using System.ComponentModel;

namespace BusinessLayer
{
    // Obsahuje kolekce vozidel a operace nad nimi
    public class VehicleCollection  
    {
        //kolekce vozidel
        public BindingList<Vehicle> vehicleList;
        public BindingList<Vehicle> scrapList;

        //prevede vozidla, u kterych klesla cena na 0, do srotu
        private void Check()
        {
            for (int i = 0; i < vehicleList.Count; i++)
            {
                if (vehicleList[i].ActualValue == 0)
                {
                    scrapList.Add(vehicleList[i]);
                    vehicleList.RemoveAt(i);
                    i--;
                }  
            }
        }

        //Seradi vozidla ve vehicleList sestupne podle aktualni hodnoty
        public void Sort()
        {
            //v kazdem pruchodu se ze zbyvajicich hodnot vybere nejvyssi, da se na konec a puvodni vyskyt se smaze
            for (int i = 0; i < this.vehicleList.Count; i++)
            {
                double highestValue = 0;
                int highestValueIndex = 0;

                for (int j = 0; j < this.vehicleList.Count - i; j++)
                {
                    if (this.vehicleList[j].ActualValue > highestValue)
                    {
                        highestValue = this.vehicleList[j].ActualValue;
                        highestValueIndex = j;
                    }
                }

                this.vehicleList.Add(this.vehicleList[highestValueIndex]);
                this.vehicleList.RemoveAt(highestValueIndex);
            }
        }

        //Vlozi nove vozidlo do spravne kolekce na sve misto podle aktualni hodnoty
        public void Insert(Vehicle v)
        {
            vehicleList.Add(v);
            this.Sort();
            Check();
        }

        //Vlozi nove vozidlo do kolekce i do databaze
        //Pri neuspechu vraci false
        public bool InsertDatabase(Vehicle v, SqlConnection conn)
        {
            this.Insert(v);
            return DatabaseAccess.Insert(v.Type, v.Date, v.OriginalValue, v.Brand, v.SeatsNumber, v.Usage, conn);
        }

        //Odstrani vozidlo dane svym ID z kolekce i z databze
        //Pokud neni dane ID nalezeno nebo se nepodari mazani z databaze, vraci false
        public bool Remove(int ID, SqlConnection conn)
        {
            int i = -1;
            foreach (Vehicle v in vehicleList)
            {
                i++;
                if (v.ID == ID)
                {
                    if (!DatabaseAccess.Remove(ID, conn)) return false;
                    vehicleList.RemoveAt(i); 
                    return true;
                }
            }

            i = -1;
            foreach (Vehicle v in scrapList)
            {
                i++;
                if (v.ID == ID)
                {
                    if (!DatabaseAccess.Remove(ID, conn)) return false;
                    scrapList.RemoveAt(i); 
                    return true;
                }
            }
            return false;
        }
            
        //Nacte data z databaze a nahraje je do kolekci
        public void Load(SqlConnection conn)
        {
            int rowNumber = 1;
            ArrayList row = new ArrayList();

            //nacita se po radcich
            while ((row = DatabaseAccess.LoadRow(rowNumber, conn)).Count != 0)
            {
                int id = (int)row[0];
                string type = (string)row[1];
                DateTime date = (DateTime)row[2];
                int originalValue = (int)row[3];
                string brand = (string)row[4];
                int seatsNumber = (int)row[5];
                double usage = (double)row[6];

                if (type == "Automobil")
                {
                    Car newVehicle = new Car(date, originalValue, brand, seatsNumber, usage);
                    newVehicle.ID = id;
                    this.Insert(newVehicle);
                }
                else if (type == "Motocykl")
                {
                    Motorcycle newVehicle = new Motorcycle(date, originalValue, brand, seatsNumber, usage);
                    newVehicle.ID = id;
                    this.Insert(newVehicle);
                }
                else if (type == "Letadlo")
                {
                    Plane newVehicle = new Plane(date, originalValue, brand, seatsNumber, usage);
                    newVehicle.ID = id;
                    this.Insert(newVehicle);
                }
                else if (type == "Loď")
                {
                    Ship newVehicle = new Ship(date, originalValue, brand, seatsNumber, usage);
                    newVehicle.ID = id;
                    this.Insert(newVehicle);
                }
                rowNumber++;
            }  
        }

        public VehicleCollection()
        {
            this.vehicleList = new BindingList<Vehicle>();
            this.scrapList = new BindingList<Vehicle>();
        }
    }
}



