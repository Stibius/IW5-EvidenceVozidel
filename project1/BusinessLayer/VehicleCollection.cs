using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Text;

namespace BusinessLayer
{
    /// <summary>
    /// Obsahuje kolekce vozidel
    /// </summary>
    public class VehicleCollection  
    {
        //seznamy vozidel
        public List<Vehicle> vehicleList;
        public List<Vehicle> scrapList;

        //prevede vozidla, u kterych klesla cena na 0, do srotu
        public void Check()
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

        //prida nove vozidlo na patricne misto podle ceny
        public void Add(Vehicle v)
        {
            vehicleList.Add(v);
            vehicleList.Sort(); 
        }

        public VehicleCollection()
        {
            this.vehicleList = new List<Vehicle>();
            this.scrapList = new List<Vehicle>();
        }
    }
}



