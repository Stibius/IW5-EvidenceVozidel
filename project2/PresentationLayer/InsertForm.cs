using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLayer;
using System.Data.SqlClient;

namespace PresentationLayer
{
    //form pro vkladani vozidel
    public partial class InsertForm : Form
    {
        private MainForm mainForm;

        public MainForm MainForm
        {
            get { return this.mainForm; }
            set { this.mainForm = value; }
        }

        public InsertForm()
        {
            InitializeComponent(); 
        }

        private void SaveForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Date.MaxDate = DateTime.Today; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //pri stisknuti tlacitka ZRUSIT
        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //pri stisknuti tlacitka ULOZIT
        private void InsertButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                typeError.Clear();
                valueError.Clear();
                brandError.Clear();
                bool error = false;

                if (this.Type.Text == "")
                {
                    typeError.SetError(this.Type, "Musíte vybrat typ vozidla.");
                    error = true;
                }

                DateTime date = this.Date.Value;

                int originalValue = 0;

                try
                {
                    originalValue = Convert.ToInt32(this.OriginalValue.Text);
                    if (originalValue < 0)
                    {
                        valueError.SetError(this.OriginalValue, "Musíte zadat celé nezáporné číslo.");
                        error = true;
                    }
                }
                catch (FormatException)
                {
                    try
                    {
                        valueError.SetError(this.OriginalValue, "Musíte zadat celé nezáporné číslo.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    error = true;
                }
                catch (OverflowException)
                {
                    try
                    {
                        valueError.SetError(this.OriginalValue, "Musíte zadat celé nezáporné číslo.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    error = true;
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                string brand = this.Brand.Text;

                if (brand == "")
                {
                    brandError.SetError(this.Brand, "Musíte zadat značku vozidla.");
                    error = true;
                }

                int seatsNumber = (int)this.SeatsNumber.Value;

                int usage = (int)this.Usage.Value;

                //uzivatel zadal korektni udaje
                if (!error)
                {
                    SqlConnection conn = new SqlConnection(
                        @"Data Source=.\SQLEXPRESS;AttachDbFilename="+System.Environment.CurrentDirectory+"\\Vehicles.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

                    if (this.Type.Text == "Automobil")
                    {
                        Car newVehicle = new Car(date, originalValue, brand, seatsNumber, usage);
                        if (!mainForm.Col.InsertDatabase(newVehicle, conn))
                        {
                            MessageBox.Show("Při vkládání došlo k výjimce!");
                        }
                    }
                    else if (this.Type.Text == "Motocykl")
                    {
                        Motorcycle newVehicle = new Motorcycle(date, originalValue, brand, seatsNumber, usage);
                        if (!mainForm.Col.InsertDatabase(newVehicle, conn))
                        {
                            MessageBox.Show("Při vkládání došlo k výjimce!");
                        }
                    }
                    else if (this.Type.Text == "Letadlo")
                    {
                        Plane newVehicle = new Plane(date, originalValue, brand, seatsNumber, usage);
                        if (!mainForm.Col.InsertDatabase(newVehicle, conn))
                        {
                            MessageBox.Show("Při vkládání došlo k výjimce!");
                        }
                    }
                    else
                    {
                        Ship newVehicle = new Ship(date, originalValue, brand, seatsNumber, usage);
                        if (!mainForm.Col.InsertDatabase(newVehicle, conn))
                        {
                            MessageBox.Show("Při vkládání došlo k výjimce!");
                        }
                    }
                    MessageBox.Show("Úspěšně vloženo!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
