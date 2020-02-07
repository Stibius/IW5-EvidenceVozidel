using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessLayer;

namespace PresentationLayer
{
    //hlavni form aplikace
    public partial class MainForm : Form
    {
        private VehicleCollection col = new VehicleCollection();

        public VehicleCollection Col
        {
            get { return this.col; }
            set { this.col = value; }
        }

        private SqlConnection conn = new SqlConnection(
                    @"Data Source=.\SQLEXPRESS;AttachDbFilename="+System.Environment.CurrentDirectory+"\\Vehicles.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        public MainForm()
        {
            InitializeComponent();     
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                col.Load(conn); //nacteni dat z databaze

                //nastaveni DataSourcu DataGridViewu
                this.vehicleTable.DataSource = col.vehicleList;
                this.scrapTable.DataSource = col.scrapList;

                //prejmenovani nadpisu sloupcu do cestiny
                this.vehicleTable.Columns[0].Visible = false;
                this.vehicleTable.Columns[1].HeaderText = "Typ";
                this.vehicleTable.Columns[2].HeaderText = "Odpis";
                this.vehicleTable.Columns[3].HeaderText = "Značka";
                this.vehicleTable.Columns[4].HeaderText = "Počet míst";
                this.vehicleTable.Columns[5].HeaderText = "Spotřeba/100km";
                this.vehicleTable.Columns[6].HeaderText = "Datum pořízení";
                this.vehicleTable.Columns[7].HeaderText = "Původní hodnota";
                this.vehicleTable.Columns[8].HeaderText = "Aktuální hodnota";

                this.scrapTable.Columns[0].Visible = false;
                this.scrapTable.Columns[1].HeaderText = "Typ";
                this.scrapTable.Columns[2].HeaderText = "Odpis";
                this.scrapTable.Columns[3].HeaderText = "Značka";
                this.scrapTable.Columns[4].HeaderText = "Počet míst";
                this.scrapTable.Columns[5].HeaderText = "Spotřeba/100km";
                this.scrapTable.Columns[6].HeaderText = "Datum pořízení";
                this.scrapTable.Columns[7].HeaderText = "Původní hodnota";
                this.scrapTable.Columns[8].HeaderText = "Aktuální hodnota";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }     
        }

        //pri kliknuti na tlacitko Pridat nove vozidlo
        private void InsertButton_Click(object sender, EventArgs e)
        {
            InsertForm insertForm = new InsertForm();
            insertForm.MainForm = this; //abych mohl pristupovat ke kolekcim v tomto formu
            insertForm.Show();
        }

        //pri kliknuti na tlacitko Vymazat oznacena vozidla
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                //podle toho, jaka tabulka je prave zobrazena, se bude pracovat s prislusnou kolekci
                if (this.tabControl1.SelectedTab == vehicleTab)
                {
                    int selectedRowsCount = this.vehicleTable.SelectedRows.Count;

                    if (selectedRowsCount == 0) return; //zadny radek neni oznaceny

                    if (MessageBox.Show("Opravdu chcete vymazat označené záznamy?", "Sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int[] ids = new int[selectedRowsCount]; //pole IDcek mazanych zaznamu

                        //naplni pole
                        for (int i = 0; i < selectedRowsCount; i++)
                        {
                            ids[i] = Convert.ToInt32(this.vehicleTable.SelectedRows[i].Cells[0].Value);
                        }

                        //odstraneni danych zaznamu
                        for (int i = 0; i < selectedRowsCount; i++)
                        {
                            col.Remove(ids[i], conn);
                        }
                    }
                }
                else
                {
                    int selectedRowsCount = this.scrapTable.SelectedRows.Count;

                    if (selectedRowsCount == 0) return; //zadny radek neni oznaceny

                    if (MessageBox.Show("Opravdu chcete vymazat označené záznamy?", "Sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int[] ids = new int[selectedRowsCount]; //pole IDcek mazanych zaznamu

                        //naplni pole
                        for (int i = 0; i < selectedRowsCount; i++)
                        {
                            ids[i] = Convert.ToInt32(this.scrapTable.SelectedRows[i].Cells[0].Value);
                        }

                        //odstraneni danych zaznamu
                        for (int i = 0; i < selectedRowsCount; i++)
                        {
                            col.Remove(ids[i], conn);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
