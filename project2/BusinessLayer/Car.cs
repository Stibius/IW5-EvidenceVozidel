using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    //Auto
    public class Car : Vehicle
    {
        public Car(DateTime _date, int _originalValue, string _brand, int _seatsNumber, double _usage)
        {
            this.Type = "Automobil";
            this.Depreciation = 0.25;
            this.Date = _date;
            this.OriginalValue = _originalValue;
            this.Brand = _brand;
            this.SeatsNumber = _seatsNumber;
            this.Usage = _usage;
        }

        public Car()
        {
        }   
    }
}
