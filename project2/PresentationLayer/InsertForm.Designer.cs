namespace PresentationLayer
{
    partial class InsertForm
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
            this.components = new System.ComponentModel.Container();
            this.Type = new System.Windows.Forms.ComboBox();
            this.Date = new System.Windows.Forms.DateTimePicker();
            this.OriginalValue = new System.Windows.Forms.TextBox();
            this.Brand = new System.Windows.Forms.TextBox();
            this.SeatsNumber = new System.Windows.Forms.NumericUpDown();
            this.Usage = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.InsertButton = new System.Windows.Forms.Button();
            this.CancButton = new System.Windows.Forms.Button();
            this.insertLabel = new System.Windows.Forms.Label();
            this.typeError = new System.Windows.Forms.ErrorProvider(this.components);
            this.valueError = new System.Windows.Forms.ErrorProvider(this.components);
            this.brandError = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SeatsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Usage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brandError)).BeginInit();
            this.SuspendLayout();
            // 
            // Type
            // 
            this.Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Type.FormattingEnabled = true;
            this.Type.Items.AddRange(new object[] {
            "Automobil",
            "Motocykl",
            "Letadlo",
            "Loď"});
            this.Type.Location = new System.Drawing.Point(128, 66);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(161, 21);
            this.Type.TabIndex = 2;
            // 
            // Date
            // 
            this.Date.Location = new System.Drawing.Point(128, 93);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(161, 20);
            this.Date.TabIndex = 4;
            // 
            // OriginalValue
            // 
            this.OriginalValue.Location = new System.Drawing.Point(128, 120);
            this.OriginalValue.Name = "OriginalValue";
            this.OriginalValue.Size = new System.Drawing.Size(161, 20);
            this.OriginalValue.TabIndex = 5;
            // 
            // Brand
            // 
            this.Brand.Location = new System.Drawing.Point(128, 147);
            this.Brand.Name = "Brand";
            this.Brand.Size = new System.Drawing.Size(161, 20);
            this.Brand.TabIndex = 6;
            // 
            // SeatsNumber
            // 
            this.SeatsNumber.Location = new System.Drawing.Point(128, 174);
            this.SeatsNumber.Name = "SeatsNumber";
            this.SeatsNumber.Size = new System.Drawing.Size(161, 20);
            this.SeatsNumber.TabIndex = 7;
            // 
            // Usage
            // 
            this.Usage.Location = new System.Drawing.Point(128, 201);
            this.Usage.Name = "Usage";
            this.Usage.Size = new System.Drawing.Size(161, 20);
            this.Usage.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Typ vozidla:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Datum pořízení:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Původní cena:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Značka:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Počet sedadel:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Spotřeba na 100km:";
            // 
            // InsertButton
            // 
            this.InsertButton.Location = new System.Drawing.Point(79, 256);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(75, 23);
            this.InsertButton.TabIndex = 15;
            this.InsertButton.Text = "ULOŽIT";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // CancButton
            // 
            this.CancButton.Location = new System.Drawing.Point(188, 256);
            this.CancButton.Name = "CancButton";
            this.CancButton.Size = new System.Drawing.Size(75, 23);
            this.CancButton.TabIndex = 16;
            this.CancButton.Text = "ZRUŠIT";
            this.CancButton.UseVisualStyleBackColor = true;
            this.CancButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // insertLabel
            // 
            this.insertLabel.AutoSize = true;
            this.insertLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.insertLabel.Location = new System.Drawing.Point(94, 20);
            this.insertLabel.Name = "insertLabel";
            this.insertLabel.Size = new System.Drawing.Size(159, 20);
            this.insertLabel.TabIndex = 20;
            this.insertLabel.Text = "Přidat nové vozidlo";
            // 
            // typeError
            // 
            this.typeError.BlinkRate = 0;
            this.typeError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.typeError.ContainerControl = this;
            // 
            // valueError
            // 
            this.valueError.BlinkRate = 0;
            this.valueError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.valueError.ContainerControl = this;
            // 
            // brandError
            // 
            this.brandError.BlinkRate = 0;
            this.brandError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.brandError.ContainerControl = this;
            // 
            // InsertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 325);
            this.Controls.Add(this.insertLabel);
            this.Controls.Add(this.CancButton);
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Usage);
            this.Controls.Add(this.SeatsNumber);
            this.Controls.Add(this.Brand);
            this.Controls.Add(this.OriginalValue);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.Type);
            this.Name = "InsertForm";
            this.Text = "Přidat nové vozidlo";
            this.Load += new System.EventHandler(this.SaveForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SeatsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Usage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brandError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Type;
        private System.Windows.Forms.DateTimePicker Date;
        private System.Windows.Forms.TextBox OriginalValue;
        private System.Windows.Forms.TextBox Brand;
        private System.Windows.Forms.NumericUpDown SeatsNumber;
        private System.Windows.Forms.NumericUpDown Usage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.Button CancButton;
        private System.Windows.Forms.Label insertLabel;
        private System.Windows.Forms.ErrorProvider typeError;
        private System.Windows.Forms.ErrorProvider valueError;
        private System.Windows.Forms.ErrorProvider brandError;
    }
}

