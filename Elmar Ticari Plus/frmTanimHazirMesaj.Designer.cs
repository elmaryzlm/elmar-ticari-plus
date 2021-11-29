namespace Elmar_Ticari_Plus
{
    partial class frmTanimHazirMesaj
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
            this.dgHazirMesaj = new System.Windows.Forms.DataGridView();
            this.hazirMesajID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesajAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesajIcerik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesajSaati = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEkle = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMesaj = new System.Windows.Forms.TextBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKayitSayisi = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtHazirMesajAdi = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgHazirMesaj)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgHazirMesaj
            // 
            this.dgHazirMesaj.AllowUserToAddRows = false;
            this.dgHazirMesaj.AllowUserToDeleteRows = false;
            this.dgHazirMesaj.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgHazirMesaj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHazirMesaj.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hazirMesajID,
            this.mesajAdi,
            this.mesajIcerik,
            this.mesajSaati});
            this.dgHazirMesaj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgHazirMesaj.Location = new System.Drawing.Point(0, 100);
            this.dgHazirMesaj.Name = "dgHazirMesaj";
            this.dgHazirMesaj.RowHeadersWidth = 20;
            this.dgHazirMesaj.Size = new System.Drawing.Size(407, 423);
            this.dgHazirMesaj.TabIndex = 1;
            this.dgHazirMesaj.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgHazirMesaj_CellEndEdit);
            // 
            // hazirMesajID
            // 
            this.hazirMesajID.HeaderText = "hazirMesajID";
            this.hazirMesajID.Name = "hazirMesajID";
            this.hazirMesajID.Visible = false;
            // 
            // mesajAdi
            // 
            this.mesajAdi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mesajAdi.HeaderText = "Hazır Mesaj Adı";
            this.mesajAdi.Name = "mesajAdi";
            // 
            // mesajIcerik
            // 
            this.mesajIcerik.HeaderText = "Mesaj";
            this.mesajIcerik.Name = "mesajIcerik";
            // 
            // mesajSaati
            // 
            this.mesajSaati.HeaderText = "Saat";
            this.mesajSaati.Name = "mesajSaati";
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnEkle.Location = new System.Drawing.Point(174, 68);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(47, 23);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtHazirMesajAdi);
            this.panel2.Controls.Add(this.maskedTextBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtMesaj);
            this.panel2.Controls.Add(this.btnSil);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnEkle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(407, 100);
            this.panel2.TabIndex = 0;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(119, 68);
            this.maskedTextBox1.Mask = "00:00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(49, 20);
            this.maskedTextBox1.TabIndex = 5;
            this.maskedTextBox1.Text = "1100";
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mesaj Gönderme Saati";
            // 
            // txtMesaj
            // 
            this.txtMesaj.BackColor = System.Drawing.Color.White;
            this.txtMesaj.ForeColor = System.Drawing.Color.Black;
            this.txtMesaj.Location = new System.Drawing.Point(119, 30);
            this.txtMesaj.MaxLength = 130;
            this.txtMesaj.Multiline = true;
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.Size = new System.Drawing.Size(148, 31);
            this.txtMesaj.TabIndex = 1;
            this.txtMesaj.Tag = "001";
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSil.Location = new System.Drawing.Point(227, 68);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(35, 23);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mesaj";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hazır Mesaj Adı";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblKayitSayisi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 523);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(407, 22);
            this.statusStrip1.TabIndex = 51;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(71, 17);
            this.toolStripStatusLabel1.Text = "Kayıt Sayısı: ";
            // 
            // lblKayitSayisi
            // 
            this.lblKayitSayisi.Name = "lblKayitSayisi";
            this.lblKayitSayisi.Size = new System.Drawing.Size(13, 17);
            this.lblKayitSayisi.Text = "0";
            // 
            // txtHazirMesajAdi
            // 
            this.txtHazirMesajAdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtHazirMesajAdi.FormattingEnabled = true;
            this.txtHazirMesajAdi.Items.AddRange(new object[] {
            "TAHSİLAT",
            "ÖDEME",
            "BORÇ",
            "SATIŞ",
            "İNDİRİM"});
            this.txtHazirMesajAdi.Location = new System.Drawing.Point(119, 3);
            this.txtHazirMesajAdi.Name = "txtHazirMesajAdi";
            this.txtHazirMesajAdi.Size = new System.Drawing.Size(148, 21);
            this.txtHazirMesajAdi.TabIndex = 6;
            // 
            // frmTanimHazirMesaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 545);
            this.Controls.Add(this.dgHazirMesaj);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmTanimHazirMesaj";
            this.Text = "Hazır Mesaj Tanımla";
            ((System.ComponentModel.ISupportInitialize)(this.dgHazirMesaj)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgHazirMesaj;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblKayitSayisi;
        private System.Windows.Forms.TextBox txtMesaj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn hazirMesajID;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesajAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesajIcerik;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesajSaati;
        private System.Windows.Forms.ComboBox txtHazirMesajAdi;
    }
}