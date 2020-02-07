using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace BusinessLayer
{
    //Motorka
    public class Motorcycle : Vehicle
    {
        public Motorcycle(DateTime _date, int _originalValue, string _brand, int _seatsNumber, double _usage)
        {
            this.Type = "Motocykl";
            this.Depreciation = 0.35;
            this.Date = _date;
            this.OriginalValue = _originalValue;
            this.Brand = _brand;
            this.SeatsNumber = _seatsNumber;
            this.Usage = _usage;
        }

        public Motorcycle()
        {
        } 
    }
}
