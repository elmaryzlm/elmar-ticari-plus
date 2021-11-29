namespace Elmar_Ticari_Plus
{
    partial class frmPersonelListele
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
            this.dgPersonelBilgileri = new System.Windows.Forms.DataGridView();
            this.pnlFiltre = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFiltre = new System.Windows.Forms.Button();
            this.dgFiltre = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblKayitSayisi = new System.Windows.Forms.Label();
            this.btnYazdir = new System.Windows.Forms.Button();
            this.btnRaporGoruntule = new System.Windows.Forms.Button();
            this.filtreDegiskenAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filtreAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turu = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.filtre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.veritipi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonelBilgileri)).BeginInit();
            this.pnlFiltre.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiltre)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgPersonelBilgileri
            // 
            this.dgPersonelBilgileri.AllowUserToAddRows = false;
            this.dgPersonelBilgileri.AllowUserToDeleteRows = false;
            this.dgPersonelBilgileri.AllowUserToResizeColumns = false;
            this.dgPersonelBilgileri.AllowUserToResizeRows = false;
            this.dgPersonelBilgileri.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPersonelBilgileri.BackgroundColor = System.Drawing.Color.White;
            this.dgPersonelBilgileri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPersonelBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPersonelBilgileri.Location = new System.Drawing.Point(308, 0);
            this.dgPersonelBilgileri.MultiSelect = false;
            this.dgPersonelBilgileri.Name = "dgPersonelBilgileri";
            this.dgPersonelBilgileri.ReadOnly = true;
            this.dgPersonelBilgileri.RowHeadersWidth = 10;
            this.dgPersonelBilgileri.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgPersonelBilgileri.RowTemplate.Height = 20;
            this.dgPersonelBilgileri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPersonelBilgileri.Size = new System.Drawing.Size(613, 550);
            this.dgPersonelBilgileri.TabIndex = 3;
            // 
            // pnlFiltre
            // 
            this.pnlFiltre.AutoSize = true;
            this.pnlFiltre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFiltre.Controls.Add(this.panel1);
            this.pnlFiltre.Controls.Add(this.dgFiltre);
            this.pnlFiltre.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFiltre.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltre.Name = "pnlFiltre";
            this.pnlFiltre.Size = new System.Drawing.Size(308, 578);
            this.pnlFiltre.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFiltre);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(290, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(14, 574);
            this.panel1.TabIndex = 4;
            // 
            // btnFiltre
            // 
            this.btnFiltre.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnFiltre.Location = new System.Drawing.Point(0, 236);
            this.btnFiltre.Name = "btnFiltre";
            this.btnFiltre.Size = new System.Drawing.Size(17, 99);
            this.btnFiltre.TabIndex = 3;
            this.btnFiltre.Text = "<";
            this.btnFiltre.UseVisualStyleBackColor = false;
            this.btnFiltre.Click += new System.EventHandler(this.btnFiltre_Click);
            // 
            // dgFiltre
            // 
            this.dgFiltre.AllowUserToAddRows = false;
            this.dgFiltre.AllowUserToDeleteRows = false;
            this.dgFiltre.AllowUserToResizeColumns = false;
            this.dgFiltre.AllowUserToResizeRows = false;
            this.dgFiltre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgFiltre.BackgroundColor = System.Drawing.Color.White;
            this.dgFiltre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFiltre.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filtreDegiskenAdi,
            this.filtreAdi,
            this.turu,
            this.filtre,
            this.veritipi});
            this.dgFiltre.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgFiltre.Location = new System.Drawing.Point(0, 0);
            this.dgFiltre.MultiSelect = false;
            this.dgFiltre.Name = "dgFiltre";
            this.dgFiltre.RowHeadersWidth = 10;
            this.dgFiltre.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgFiltre.RowTemplate.Height = 20;
            this.dgFiltre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFiltre.Size = new System.Drawing.Size(290, 574);
            this.dgFiltre.TabIndex = 2;
            this.dgFiltre.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFiltre_CellEndEdit);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblKayitSayisi);
            this.panel2.Controls.Add(this.btnYazdir);
            this.panel2.Controls.Add(this.btnRaporGoruntule);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(308, 550);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(613, 28);
            this.panel2.TabIndex = 5;
            // 
            // lblKayitSayisi
            // 
            this.lblKayitSayisi.ForeColor = System.Drawing.Color.DarkRed;
            this.lblKayitSayisi.Location = new System.Drawing.Point(181, 7);
            this.lblKayitSayisi.Name = "lblKayitSayisi";
            this.lblKayitSayisi.Size = new System.Drawing.Size(100, 15);
            this.lblKayitSayisi.TabIndex = 51;
            this.lblKayitSayisi.Text = "Kayıt Sayısı:";
            // 
            // btnYazdir
            // 
            this.btnYazdir.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnYazdir.Location = new System.Drawing.Point(107, 2);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(68, 23);
            this.btnYazdir.TabIndex = 49;
            this.btnYazdir.Text = "Yazdır";
            this.btnYazdir.UseVisualStyleBackColor = false;
            // 
            // btnRaporGoruntule
            // 
            this.btnRaporGoruntule.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRaporGoruntule.Location = new System.Drawing.Point(6, 2);
            this.btnRaporGoruntule.Name = "btnRaporGoruntule";
            this.btnRaporGoruntule.Size = new System.Drawing.Size(95, 23);
            this.btnRaporGoruntule.TabIndex = 47;
            this.btnRaporGoruntule.Text = "Rapor Görüntüle";
            this.btnRaporGoruntule.UseVisualStyleBackColor = false;
            // 
            // filtreDegiskenAdi
            // 
            this.filtreDegiskenAdi.HeaderText = "Filtrenin Değişken Adı";
            this.filtreDegiskenAdi.Name = "filtreDegiskenAdi";
            this.filtreDegiskenAdi.Visible = false;
            this.filtreDegiskenAdi.Width = 115;
            // 
            // filtreAdi
            // 
            this.filtreAdi.HeaderText = "Filtre Adı";
            this.filtreAdi.Name = "filtreAdi";
            this.filtreAdi.ReadOnly = true;
            this.filtreAdi.Width = 72;
            // 
            // turu
            // 
            this.turu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.turu.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.turu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.turu.HeaderText = "Türü";
            this.turu.MaxDropDownItems = 100;
            this.turu.Name = "turu";
            this.turu.Width = 35;
            // 
            // filtre
            // 
            this.filtre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.filtre.HeaderText = "Filtre";
            this.filtre.MaxInputLength = 300;
            this.filtre.Name = "filtre";
            // 
            // veritipi
            // 
            this.veritipi.HeaderText = "veritipi";
            this.veritipi.Name = "veritipi";
            this.veritipi.Visible = false;
            this.veritipi.Width = 62;
            // 
            // frmPersonelListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(921, 578);
            this.Controls.Add(this.dgPersonelBilgileri);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlFiltre);
            this.Name = "frmPersonelListele";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Personel Listele | Filtreleme";
            this.Load += new System.EventHandler(this.frmPersonelListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonelBilgileri)).EndInit();
            this.pnlFiltre.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFiltre)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPersonelBilgileri;
        private System.Windows.Forms.Panel pnlFiltre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFiltre;
        private System.Windows.Forms.DataGridView dgFiltre;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblKayitSayisi;
        private System.Windows.Forms.Button btnYazdir;
        private System.Windows.Forms.Button btnRaporGoruntule;
        private System.Windows.Forms.DataGridViewTextBoxColumn filtreDegiskenAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn filtreAdi;
        private System.Windows.Forms.DataGridViewComboBoxColumn turu;
        private System.Windows.Forms.DataGridViewTextBoxColumn filtre;
        private System.Windows.Forms.DataGridViewTextBoxColumn veritipi;
    }
}