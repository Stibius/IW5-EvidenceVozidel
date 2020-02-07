namespace PresentationLayer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.vehicleTable = new System.Windows.Forms.DataGridView();
            this.InsertButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.vehicleTab = new System.Windows.Forms.TabPage();
            this.scrapTab = new System.Windows.Forms.TabPage();
            this.scrapTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleTable)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.vehicleTab.SuspendLayout();
            this.scrapTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrapTable)).BeginInit();
            this.SuspendLayout();
            // 
            // vehicleTable
            // 
            this.vehicleTable.AllowUserToAddRows = false;
            this.vehicleTable.AllowUserToDeleteRows = false;
            this.vehicleTable.AllowUserToResizeColumns = false;
            this.vehicleTable.AllowUserToResizeRows = false;
            this.vehicleTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vehicleTable.Location = new System.Drawing.Point(0, 0);
            this.vehicleTable.Name = "vehicleTable";
            this.vehicleTable.ReadOnly = true;
            this.vehicleTable.RowHeadersVisible = false;
            this.vehicleTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vehicleTable.Size = new System.Drawing.Size(803, 326);
            this.vehicleTable.TabIndex = 0;
            // 
            // InsertButton
            // 
            this.InsertButton.Location = new System.Drawing.Point(34, 374);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(116, 23);
            this.InsertButton.TabIndex = 1;
            this.InsertButton.Text = "Přidat nové vozidlo";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(174, 374);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(150, 23);
            this.RemoveButton.TabIndex = 2;
            this.RemoveButton.Text = "Vymazat označená vozidla";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.vehicleTab);
            this.tabControl1.Controls.Add(this.scrapTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(814, 355);
            this.tabControl1.TabIndex = 3;
            // 
            // vehicleTab
            // 
            this.vehicleTab.AutoScroll = true;
            this.vehicleTab.Controls.Add(this.vehicleTable);
            this.vehicleTab.Location = new System.Drawing.Point(4, 22);
            this.vehicleTab.Name = "vehicleTab";
            this.vehicleTab.Padding = new System.Windows.Forms.Padding(3);
            this.vehicleTab.Size = new System.Drawing.Size(806, 329);
            this.vehicleTab.TabIndex = 0;
            this.vehicleTab.Text = "Vozidla";
            this.vehicleTab.UseVisualStyleBackColor = true;
            // 
            // scrapTab
            // 
            this.scrapTab.AutoScroll = true;
            this.scrapTab.Controls.Add(this.scrapTable);
            this.scrapTab.Location = new System.Drawing.Point(4, 22);
            this.scrapTab.Name = "scrapTab";
            this.scrapTab.Padding = new System.Windows.Forms.Padding(3);
            this.scrapTab.Size = new System.Drawing.Size(806, 329);
            this.scrapTab.TabIndex = 1;
            this.scrapTab.Text = "Šrot";
            this.scrapTab.UseVisualStyleBackColor = true;
            // 
            // scrapTable
            // 
            this.scrapTable.AllowUserToAddRows = false;
            this.scrapTable.AllowUserToDeleteRows = false;
            this.scrapTable.AllowUserToResizeColumns = false;
            this.scrapTable.AllowUserToResizeRows = false;
            this.scrapTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scrapTable.Location = new System.Drawing.Point(0, 0);
            this.scrapTable.Name = "scrapTable";
            this.scrapTable.ReadOnly = true;
            this.scrapTable.RowHeadersVisible = false;
            this.scrapTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.scrapTable.Size = new System.Drawing.Size(803, 326);
            this.scrapTable.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 433);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.InsertButton);
            this.Name = "MainForm";
            this.Text = "Nikitova evidence vozidel";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vehicleTable)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.vehicleTab.ResumeLayout(false);
            this.scrapTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scrapTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView vehicleTable;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage vehicleTab;
        private System.Windows.Forms.TabPage scrapTab;
        private System.Windows.Forms.DataGridView scrapTable;
    }
}