using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace BusinessLayer
{
    /// <summary>
    /// Abstraktni trida vozidlo
    /// </summary>
    [Serializable()]
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Motorcycle))]
    [XmlInclude(typeof(Plane))]
    [XmlInclude(typeof(Ship))]
    public abstract class Vehicle : IComparable
    {
        private int type;

        public int Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        private double depreciation;

        public double Depreciation
        {
            get { return this.depreciation; }
            set { this.depreciation = value; }
        }

        private DateTime date;
        
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        private int originalValue;

        public int OriginalValue
        {
            get { return this.originalValue; }
            set { this.originalValue = value; }
        }

        private string brand;

        public string Brand
        {
            get { return this.brand; }
            set { this.brand = value; }
        }

        private int seatsNumber;

        public int SeatsNumber
        {
            get { return this.seatsNumber; }
            set { this.seatsNumber = value; }
        }

        private double usage;

        public double Usage
        {
            get { return this.usage; }
            set { this.usage = value; }
        }

        //spocita aktualni hodnotu
        public double ActualValue
        {
            get {
                double value = originalValue - (((double)(DateTime.Now - date).Days / 365) * depreciation * originalValue);
                if (value < 0)
                {
                    return 0;
                }
                else
                {
                    return value;
                }
            }
           
        }

        public int CompareTo(object obj)
        {
            if (obj is Vehicle)
            {
                Vehicle temp = (Vehicle)obj;

                return this.ActualValue.CompareTo(temp.ActualValue);
            }

            throw new ArgumentException("object is not a Vehicle");
        }    
    }
    
}
