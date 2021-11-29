namespace Elmar_Ticari_Plus
{
    partial class frmPersonelVardiyaTanim
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
            this.dgPersonelVardiyalari = new System.Windows.Forms.DataGridView();
            this.vardiyaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vardiyaAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baslangicSaati = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bitisSaati = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subeid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subeAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duzenle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.sil = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel18 = new System.Windows.Forms.Panel();
            this.btnHesapEkle = new System.Windows.Forms.Button();
            this.lblKayitSayisi = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.cmbSubeAdi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVardiyaAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonelVardiyalari)).BeginInit();
            this.panel18.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgPersonelVardiyalari
            // 
            this.dgPersonelVardiyalari.AllowUserToAddRows = false;
            this.dgPersonelVardiyalari.AllowUserToDeleteRows = false;
            this.dgPersonelVardiyalari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPersonelVardiyalari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPersonelVardiyalari.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vardiyaid,
            this.vardiyaAdi,
            this.baslangicSaati,
            this.bitisSaati,
            this.subeid,
            this.subeAdi,
            this.duzenle,
            this.sil});
            this.dgPersonelVardiyalari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPersonelVardiyalari.Location = new System.Drawing.Point(0, 0);
            this.dgPersonelVardiyalari.MultiSelect = false;
            this.dgPersonelVardiyalari.Name = "dgPersonelVardiyalari";
            this.dgPersonelVardiyalari.ReadOnly = true;
            this.dgPersonelVardiyalari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPersonelVardiyalari.Size = new System.Drawing.Size(429, 360);
            this.dgPersonelVardiyalari.TabIndex = 1;
            this.dgPersonelVardiyalari.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPersonelVardiyalari_CellClick);
            // 
            // vardiyaid
            // 
            this.vardiyaid.HeaderText = "vardiyaid";
            this.vardiyaid.Name = "vardiyaid";
            this.vardiyaid.ReadOnly = true;
            this.vardiyaid.Visible = false;
            this.vardiyaid.Width = 74;
            // 
            // vardiyaAdi
            // 
            this.vardiyaAdi.HeaderText = "Vardiya Adı";
            this.vardiyaAdi.Name = "vardiyaAdi";
            this.vardiyaAdi.ReadOnly = true;
            this.vardiyaAdi.Width = 85;
            // 
            // baslangicSaati
            // 
            this.baslangicSaati.HeaderText = "Başlangıç";
            this.baslangicSaati.Name = "baslangicSaati";
            this.baslangicSaati.ReadOnly = true;
            this.baslangicSaati.Width = 78;
            // 
            // bitisSaati
            // 
            this.bitisSaati.HeaderText = "Bitiş";
            this.bitisSaati.Name = "bitisSaati";
            this.bitisSaati.ReadOnly = true;
            this.bitisSaati.Width = 51;
            // 
            // subeid
            // 
            this.subeid.HeaderText = "subeid";
            this.subeid.Name = "subeid";
            this.subeid.ReadOnly = true;
            this.subeid.Visible = false;
            this.subeid.Width = 63;
            // 
            // subeAdi
            // 
            this.subeAdi.HeaderText = "Şube Adı";
            this.subeAdi.Name = "subeAdi";
            this.subeAdi.ReadOnly = true;
            this.subeAdi.Width = 75;
            // 
            // duzenle
            // 
            this.duzenle.HeaderText = "";
            this.duzenle.Name = "duzenle";
            this.duzenle.ReadOnly = true;
            this.duzenle.Width = 5;
            // 
            // sil
            // 
            this.sil.HeaderText = "";
            this.sil.Name = "sil";
            this.sil.ReadOnly = true;
            this.sil.Width = 5;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel18.Controls.Add(this.btnHesapEkle);
            this.panel18.Controls.Add(this.lblKayitSayisi);
            this.panel18.Controls.Add(this.label82);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel18.Location = new System.Drawing.Point(0, 403);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(429, 26);
            this.panel18.TabIndex = 5;
            this.panel18.TabStop = true;
            // 
            // btnHesapEkle
            // 
            this.btnHesapEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnHesapEkle.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnHesapEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHesapEkle.Image = global::Elmar_Ticari_Plus.Properties.Resources.genelEkle;
            this.btnHesapEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHesapEkle.Location = new System.Drawing.Point(277, 0);
            this.btnHesapEkle.Name = "btnHesapEkle";
            this.btnHesapEkle.Size = new System.Drawing.Size(150, 24);
            this.btnHesapEkle.TabIndex = 6;
            this.btnHesapEkle.Text = "Yeni Vardiya Tanımla";
            this.btnHesapEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHesapEkle.UseVisualStyleBackColor = false;
            this.btnHesapEkle.Click += new System.EventHandler(this.btnHesapEkle_Click);
            // 
            // lblKayitSayisi
            // 
            this.lblKayitSayisi.BackColor = System.Drawing.Color.Transparent;
            this.lblKayitSayisi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKayitSayisi.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblKayitSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKayitSayisi.ForeColor = System.Drawing.Color.DarkRed;
            this.lblKayitSayisi.Location = new System.Drawing.Point(91, 0);
            this.lblKayitSayisi.Name = "lblKayitSayisi";
            this.lblKayitSayisi.Size = new System.Drawing.Size(94, 24);
            this.lblKayitSayisi.TabIndex = 4;
            this.lblKayitSayisi.Text = "0";
            this.lblKayitSayisi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label82
            // 
            this.label82.BackColor = System.Drawing.Color.Transparent;
            this.label82.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label82.Dock = System.Windows.Forms.DockStyle.Left;
            this.label82.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label82.ForeColor = System.Drawing.Color.Black;
            this.label82.Location = new System.Drawing.Point(0, 0);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(91, 24);
            this.label82.TabIndex = 3;
            this.label82.Text = "Kayıt Sayısı: ";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSubeAdi
            // 
            this.cmbSubeAdi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSubeAdi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSubeAdi.BackColor = System.Drawing.Color.White;
            this.cmbSubeAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbSubeAdi.ForeColor = System.Drawing.Color.Black;
            this.cmbSubeAdi.FormattingEnabled = true;
            this.cmbSubeAdi.Location = new System.Drawing.Point(278, 14);
            this.cmbSubeAdi.Name = "cmbSubeAdi";
            this.cmbSubeAdi.Size = new System.Drawing.Size(148, 23);
            this.cmbSubeAdi.TabIndex = 4;
            this.cmbSubeAdi.Tag = "001";
            this.cmbSubeAdi.SelectedIndexChanged += new System.EventHandler(this.cmbSubeAdi_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(222, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Şube Adı";
            // 
            // txtVardiyaAdi
            // 
            this.txtVardiyaAdi.BackColor = System.Drawing.Color.White;
            this.txtVardiyaAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtVardiyaAdi.ForeColor = System.Drawing.Color.Black;
            this.txtVardiyaAdi.Location = new System.Drawing.Point(74, 15);
            this.txtVardiyaAdi.Name = "txtVardiyaAdi";
            this.txtVardiyaAdi.Size = new System.Drawing.Size(129, 21);
            this.txtVardiyaAdi.TabIndex = 3;
            this.txtVardiyaAdi.Tag = "001";
            this.txtVardiyaAdi.TextChanged += new System.EventHandler(this.txtVardiyaAdi_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vardiya Adı";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtVardiyaAdi);
            this.groupBox1.Controls.Add(this.cmbSubeAdi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(0, 360);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 43);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtre";
            // 
            // frmPersonelVardiyaTanim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 429);
            this.Controls.Add(this.dgPersonelVardiyalari);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel18);
            this.Name = "frmPersonelVardiyaTanim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Vardiya Tanımları";
            this.Load += new System.EventHandler(this.frmPersonelVardiyaTanim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonelVardiyalari)).EndInit();
            this.panel18.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPersonelVardiyalari;
        private System.Windows.Forms.DataGridViewTextBoxColumn vardiyaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn vardiyaAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn baslangicSaati;
        private System.Windows.Forms.DataGridViewTextBoxColumn bitisSaati;
        private System.Windows.Forms.DataGridViewTextBoxColumn subeid;
        private System.Windows.Forms.DataGridViewTextBoxColumn subeAdi;
        private System.Windows.Forms.DataGridViewButtonColumn duzenle;
        private System.Windows.Forms.DataGridViewButtonColumn sil;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label lblKayitSayisi;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Button btnHesapEkle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSubeAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVardiyaAdi;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}