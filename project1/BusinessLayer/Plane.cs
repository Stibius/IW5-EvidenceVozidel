using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace BusinessLayer
{
    /// <summary>
    /// Letadlo
    /// </summary>
    public class Plane : Vehicle
    {
        public Plane(DateTime _date, int _originalValue, string _brand, int _seatsNumber, double _usage)
        {
            this.Type = 3;
            this.Depreciation = 0.10;
            this.Date = _date;
            this.OriginalValue = _originalValue;
            this.Brand = _brand;
            this.SeatsNumber = _seatsNumber;
            this.Usage = _usage;
        }

        public Plane()
        {
        }
    }
}
