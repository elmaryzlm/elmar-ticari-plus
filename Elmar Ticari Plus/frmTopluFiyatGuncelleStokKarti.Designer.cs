namespace Elmar_Ticari_Plus
{
    partial class frmTopluFiyatGuncelleStokKarti
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
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSatisFiyati = new System.Windows.Forms.TextBox();
            this.txtAlisFiyat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbKategori
            // 
            this.cmbKategori.BackColor = System.Drawing.Color.White;
            this.cmbKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbKategori.ForeColor = System.Drawing.Color.Black;
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Items.AddRange(new object[] {
            "TL",
            "DOLAR",
            "EURO"});
            this.cmbKategori.Location = new System.Drawing.Point(72, 2);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(193, 24);
            this.cmbKategori.TabIndex = 43;
            this.cmbKategori.Tag = "001";
            this.cmbKategori.SelectedIndexChanged += new System.EventHandler(this.cmbKategori_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(2, 6);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(46, 13);
            this.label23.TabIndex = 44;
            this.label23.Text = "Kategori";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(73, 83);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(192, 30);
            this.btnGuncelle.TabIndex = 45;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Satış Fiyatı %";
            // 
            // txtSatisFiyati
            // 
            this.txtSatisFiyati.BackColor = System.Drawing.Color.White;
            this.txtSatisFiyati.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSatisFiyati.ForeColor = System.Drawing.Color.Black;
            this.txtSatisFiyati.Location = new System.Drawing.Point(72, 27);
            this.txtSatisFiyati.Multiline = true;
            this.txtSatisFiyati.Name = "txtSatisFiyati";
            this.txtSatisFiyati.Size = new System.Drawing.Size(193, 24);
            this.txtSatisFiyati.TabIndex = 48;
            this.txtSatisFiyati.Tag = "521";
            this.txtSatisFiyati.Text = "0";
            this.txtSatisFiyati.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAlisFiyat
            // 
            this.txtAlisFiyat.BackColor = System.Drawing.Color.White;
            this.txtAlisFiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAlisFiyat.ForeColor = System.Drawing.Color.Black;
            this.txtAlisFiyat.Location = new System.Drawing.Point(72, 53);
            this.txtAlisFiyat.Multiline = true;
            this.txtAlisFiyat.Name = "txtAlisFiyat";
            this.txtAlisFiyat.Size = new System.Drawing.Size(193, 24);
            this.txtAlisFiyat.TabIndex = 50;
            this.txtAlisFiyat.Tag = "521";
            this.txtAlisFiyat.Text = "0";
            this.txtAlisFiyat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Alış Fiyatı %";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(271, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 48);
            this.label3.TabIndex = 51;
            this.label3.Text = "Alış Fiyatında Değişme \r\nYoksa  Alış Fiyatına 0 \r\nYazınız\r\n";
            // 
            // frmTopluFiyatGuncelleStokKarti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 121);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAlisFiyat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSatisFiyati);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.label23);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTopluFiyatGuncelleStokKarti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Toplu Fiyat Güncelle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSatisFiyati;
        private System.Windows.Forms.TextBox txtAlisFiyat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}