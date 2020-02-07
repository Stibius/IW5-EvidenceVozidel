using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BusinessLayer
{
  
    //Abstraktni trida vozidlo, od ktere dedi tridy reprezentujici jednotlive druhy vozidel
    //Implementuje rozhrani INotifyPropertyChanged, aby se zmena projevila v DataGridView
    public abstract class Vehicle : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private int id; 

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        private string type;

        public string Type
        {
            get { return this.type; }
            set { this.type = value; this.NotifyPropertyChanged("Type"); }
        }

        private double depreciation;

        public double Depreciation
        {
            get { return this.depreciation; }
            set { this.depreciation = value; }
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
            set { this.originalValue = value;  }
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
                    return Math.Round(value, 2);
                }
            }
        }      
    }   
}
