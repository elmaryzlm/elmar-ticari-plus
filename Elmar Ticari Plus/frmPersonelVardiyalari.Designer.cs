namespace Elmar_Ticari_Plus
{
    partial class frmPersonelVardiyalari
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
            this.personelVardiyaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personelid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personelAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vardiyaid2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vardiyaAdi2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baslangicTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bitisTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tatilGunu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subeid2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subeAdi2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duzenle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.sil = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlAlt = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.lblKayitSayisi = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.btnRaporGoruntule = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnHesapEkle = new System.Windows.Forms.Button();
            this.cmbSubeler = new System.Windows.Forms.ComboBox();
            this.label58 = new System.Windows.Forms.Label();
            this.cmbVardiya = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPersonel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.chkSilinenKayitlariGoster = new System.Windows.Forms.CheckBox();
            this.grpİslemTarihi = new System.Windows.Forms.GroupBox();
            this.dtİslemTarihi2 = new System.Windows.Forms.DateTimePicker();
            this.dtİslemTarihi1 = new System.Windows.Forms.DateTimePicker();
            this.label56 = new System.Windows.Forms.Label();
            this.chkİslemTarihi = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonelVardiyalari)).BeginInit();
            this.pnlAlt.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel12.SuspendLayout();
            this.grpİslemTarihi.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgPersonelVardiyalari
            // 
            this.dgPersonelVardiyalari.AllowUserToAddRows = false;
            this.dgPersonelVardiyalari.AllowUserToDeleteRows = false;
            this.dgPersonelVardiyalari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPersonelVardiyalari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgPersonelVardiyalari.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.personelVardiyaid,
            this.personelid,
            this.personelAdi,
            this.vardiyaid2,
            this.vardiyaAdi2,
            this.baslangicTarihi,
            this.bitisTarihi,
            this.tatilGunu,
            this.subeid2,
            this.subeAdi2,
            this.duzenle,
            this.sil});
            this.dgPersonelVardiyalari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPersonelVardiyalari.Location = new System.Drawing.Point(0, 0);
            this.dgPersonelVardiyalari.MultiSelect = false;
            this.dgPersonelVardiyalari.Name = "dgPersonelVardiyalari";
            this.dgPersonelVardiyalari.ReadOnly = true;
            this.dgPersonelVardiyalari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPersonelVardiyalari.Size = new System.Drawing.Size(750, 396);
            this.dgPersonelVardiyalari.TabIndex = 1;
            this.dgPersonelVardiyalari.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPersonelVardiyalari_CellClick);
            // 
            // personelVardiyaid
            // 
            this.personelVardiyaid.HeaderText = "personelVardiyaid";
            this.personelVardiyaid.Name = "personelVardiyaid";
            this.personelVardiyaid.ReadOnly = true;
            this.personelVardiyaid.Visible = false;
            this.personelVardiyaid.Width = 115;
            // 
            // personelid
            // 
            this.personelid.HeaderText = "personelid";
            this.personelid.Name = "personelid";
            this.personelid.ReadOnly = true;
            this.personelid.Visible = false;
            this.personelid.Width = 80;
            // 
            // personelAdi
            // 
            this.personelAdi.HeaderText = "Personel Adı";
            this.personelAdi.Name = "personelAdi";
            this.personelAdi.ReadOnly = true;
            this.personelAdi.Width = 91;
            // 
            // vardiyaid2
            // 
            this.vardiyaid2.HeaderText = "vardiyaid";
            this.vardiyaid2.Name = "vardiyaid2";
            this.vardiyaid2.ReadOnly = true;
            this.vardiyaid2.Visible = false;
            this.vardiyaid2.Width = 74;
            // 
            // vardiyaAdi2
            // 
            this.vardiyaAdi2.HeaderText = "Vardiya Adı";
            this.vardiyaAdi2.Name = "vardiyaAdi2";
            this.vardiyaAdi2.ReadOnly = true;
            this.vardiyaAdi2.Width = 85;
            // 
            // baslangicTarihi
            // 
            this.baslangicTarihi.HeaderText = "Başlangıç Tarihi";
            this.baslangicTarihi.Name = "baslangicTarihi";
            this.baslangicTarihi.ReadOnly = true;
            this.baslangicTarihi.Width = 107;
            // 
            // bitisTarihi
            // 
            this.bitisTarihi.HeaderText = "Bitiş Tarihi";
            this.bitisTarihi.Name = "bitisTarihi";
            this.bitisTarihi.ReadOnly = true;
            this.bitisTarihi.Width = 80;
            // 
            // tatilGunu
            // 
            this.tatilGunu.HeaderText = "Tatil Günü";
            this.tatilGunu.Name = "tatilGunu";
            this.tatilGunu.ReadOnly = true;
            this.tatilGunu.Width = 81;
            // 
            // subeid2
            // 
            this.subeid2.HeaderText = "subeid";
            this.subeid2.Name = "subeid2";
            this.subeid2.ReadOnly = true;
            this.subeid2.Visible = false;
            this.subeid2.Width = 63;
            // 
            // subeAdi2
            // 
            this.subeAdi2.HeaderText = "Şube Adı";
            this.subeAdi2.Name = "subeAdi2";
            this.subeAdi2.ReadOnly = true;
            this.subeAdi2.Width = 75;
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
            // pnlAlt
            // 
            this.pnlAlt.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlAlt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlt.Controls.Add(this.panel16);
            this.pnlAlt.Controls.Add(this.panel12);
            this.pnlAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlt.Location = new System.Drawing.Point(0, 396);
            this.pnlAlt.Name = "pnlAlt";
            this.pnlAlt.Size = new System.Drawing.Size(750, 109);
            this.pnlAlt.TabIndex = 2;
            this.pnlAlt.TabStop = true;
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.lblKayitSayisi);
            this.panel16.Controls.Add(this.label70);
            this.panel16.Controls.Add(this.btnSorgula);
            this.panel16.Controls.Add(this.btnRaporGoruntule);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(461, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(102, 107);
            this.panel16.TabIndex = 8;
            this.panel16.TabStop = true;
            // 
            // lblKayitSayisi
            // 
            this.lblKayitSayisi.BackColor = System.Drawing.Color.Transparent;
            this.lblKayitSayisi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKayitSayisi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblKayitSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKayitSayisi.ForeColor = System.Drawing.Color.DarkRed;
            this.lblKayitSayisi.Location = new System.Drawing.Point(0, 85);
            this.lblKayitSayisi.Name = "lblKayitSayisi";
            this.lblKayitSayisi.Size = new System.Drawing.Size(100, 20);
            this.lblKayitSayisi.TabIndex = 54;
            this.lblKayitSayisi.Text = "Kayıt Sayısı: 0";
            this.lblKayitSayisi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label70
            // 
            this.label70.BackColor = System.Drawing.Color.White;
            this.label70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label70.Dock = System.Windows.Forms.DockStyle.Top;
            this.label70.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label70.Location = new System.Drawing.Point(0, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(100, 17);
            this.label70.TabIndex = 0;
            this.label70.Text = "Raporlama";
            this.label70.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSorgula
            // 
            this.btnSorgula.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSorgula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSorgula.Location = new System.Drawing.Point(3, 22);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(95, 24);
            this.btnSorgula.TabIndex = 9;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = false;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // btnRaporGoruntule
            // 
            this.btnRaporGoruntule.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRaporGoruntule.Location = new System.Drawing.Point(3, 47);
            this.btnRaporGoruntule.Name = "btnRaporGoruntule";
            this.btnRaporGoruntule.Size = new System.Drawing.Size(95, 23);
            this.btnRaporGoruntule.TabIndex = 10;
            this.btnRaporGoruntule.Text = "Rapor Görüntüle";
            this.btnRaporGoruntule.UseVisualStyleBackColor = false;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.btnHesapEkle);
            this.panel12.Controls.Add(this.cmbSubeler);
            this.panel12.Controls.Add(this.label58);
            this.panel12.Controls.Add(this.cmbVardiya);
            this.panel12.Controls.Add(this.label2);
            this.panel12.Controls.Add(this.cmbPersonel);
            this.panel12.Controls.Add(this.label1);
            this.panel12.Controls.Add(this.label54);
            this.panel12.Controls.Add(this.chkSilinenKayitlariGoster);
            this.panel12.Controls.Add(this.grpİslemTarihi);
            this.panel12.Controls.Add(this.label4);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(461, 107);
            this.panel12.TabIndex = 3;
            this.panel12.TabStop = true;
            // 
            // btnHesapEkle
            // 
            this.btnHesapEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnHesapEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHesapEkle.Image = global::Elmar_Ticari_Plus.Properties.Resources.genelEkle;
            this.btnHesapEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHesapEkle.Location = new System.Drawing.Point(275, 81);
            this.btnHesapEkle.Name = "btnHesapEkle";
            this.btnHesapEkle.Size = new System.Drawing.Size(181, 24);
            this.btnHesapEkle.TabIndex = 7;
            this.btnHesapEkle.Text = "Personel Vardiyası Tanımla";
            this.btnHesapEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHesapEkle.UseVisualStyleBackColor = false;
            this.btnHesapEkle.Click += new System.EventHandler(this.btnHesapEkle_Click);
            // 
            // cmbSubeler
            // 
            this.cmbSubeler.BackColor = System.Drawing.Color.White;
            this.cmbSubeler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbSubeler.ForeColor = System.Drawing.Color.Black;
            this.cmbSubeler.FormattingEnabled = true;
            this.cmbSubeler.Location = new System.Drawing.Point(290, 48);
            this.cmbSubeler.Name = "cmbSubeler";
            this.cmbSubeler.Size = new System.Drawing.Size(166, 23);
            this.cmbSubeler.TabIndex = 6;
            this.cmbSubeler.Tag = "001";
            this.cmbSubeler.SelectedIndexChanged += new System.EventHandler(this.cmbSubeler_SelectedIndexChanged);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(234, 54);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(32, 13);
            this.label58.TabIndex = 1;
            this.label58.Text = "Şube";
            this.label58.Click += new System.EventHandler(this.label58_Click);
            // 
            // cmbVardiya
            // 
            this.cmbVardiya.BackColor = System.Drawing.Color.White;
            this.cmbVardiya.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbVardiya.ForeColor = System.Drawing.Color.Black;
            this.cmbVardiya.FormattingEnabled = true;
            this.cmbVardiya.Location = new System.Drawing.Point(57, 47);
            this.cmbVardiya.Name = "cmbVardiya";
            this.cmbVardiya.Size = new System.Drawing.Size(164, 23);
            this.cmbVardiya.TabIndex = 5;
            this.cmbVardiya.Tag = "001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(2, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 47;
            this.label2.Text = "Vardiya";
            // 
            // cmbPersonel
            // 
            this.cmbPersonel.BackColor = System.Drawing.Color.White;
            this.cmbPersonel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbPersonel.ForeColor = System.Drawing.Color.Black;
            this.cmbPersonel.FormattingEnabled = true;
            this.cmbPersonel.Location = new System.Drawing.Point(57, 23);
            this.cmbPersonel.Name = "cmbPersonel";
            this.cmbPersonel.Size = new System.Drawing.Size(164, 23);
            this.cmbPersonel.TabIndex = 4;
            this.cmbPersonel.Tag = "001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(2, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 45;
            this.label1.Text = "Personel";
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.White;
            this.label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label54.Dock = System.Windows.Forms.DockStyle.Top;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label54.Location = new System.Drawing.Point(0, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(459, 17);
            this.label54.TabIndex = 0;
            this.label54.Text = "Filtre Seçenekleri";
            this.label54.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkSilinenKayitlariGoster
            // 
            this.chkSilinenKayitlariGoster.AutoSize = true;
            this.chkSilinenKayitlariGoster.Location = new System.Drawing.Point(57, 86);
            this.chkSilinenKayitlariGoster.Name = "chkSilinenKayitlariGoster";
            this.chkSilinenKayitlariGoster.Size = new System.Drawing.Size(130, 17);
            this.chkSilinenKayitlariGoster.TabIndex = 15;
            this.chkSilinenKayitlariGoster.Text = "Silinen Kayıtları Göster";
            this.chkSilinenKayitlariGoster.UseVisualStyleBackColor = true;
            // 
            // grpİslemTarihi
            // 
            this.grpİslemTarihi.Controls.Add(this.dtİslemTarihi2);
            this.grpİslemTarihi.Controls.Add(this.dtİslemTarihi1);
            this.grpİslemTarihi.Controls.Add(this.label56);
            this.grpİslemTarihi.Controls.Add(this.chkİslemTarihi);
            this.grpİslemTarihi.Location = new System.Drawing.Point(227, 10);
            this.grpİslemTarihi.Name = "grpİslemTarihi";
            this.grpİslemTarihi.Size = new System.Drawing.Size(234, 42);
            this.grpİslemTarihi.TabIndex = 13;
            this.grpİslemTarihi.TabStop = false;
            this.grpİslemTarihi.Visible = false;
            // 
            // dtİslemTarihi2
            // 
            this.dtİslemTarihi2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtİslemTarihi2.Location = new System.Drawing.Point(152, 16);
            this.dtİslemTarihi2.Name = "dtİslemTarihi2";
            this.dtİslemTarihi2.Size = new System.Drawing.Size(77, 20);
            this.dtİslemTarihi2.TabIndex = 4;
            // 
            // dtİslemTarihi1
            // 
            this.dtİslemTarihi1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtİslemTarihi1.Location = new System.Drawing.Point(63, 16);
            this.dtİslemTarihi1.Name = "dtİslemTarihi1";
            this.dtİslemTarihi1.Size = new System.Drawing.Size(77, 20);
            this.dtİslemTarihi1.TabIndex = 3;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label56.Location = new System.Drawing.Point(141, 20);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(11, 15);
            this.label56.TabIndex = 5;
            this.label56.Text = "-";
            // 
            // chkİslemTarihi
            // 
            this.chkİslemTarihi.AutoSize = true;
            this.chkİslemTarihi.Location = new System.Drawing.Point(7, 19);
            this.chkİslemTarihi.Name = "chkİslemTarihi";
            this.chkİslemTarihi.Size = new System.Drawing.Size(52, 17);
            this.chkİslemTarihi.TabIndex = 12;
            this.chkİslemTarihi.Text = "Tarihi";
            this.chkİslemTarihi.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-8, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(529, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "_________________________________________________________________________________" +
    "______";
            // 
            // frmPersonelVardiyalari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 505);
            this.Controls.Add(this.dgPersonelVardiyalari);
            this.Controls.Add(this.pnlAlt);
            this.Name = "frmPersonelVardiyalari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Personel Vardiyaları Listesi";
            this.Load += new System.EventHandler(this.frmPersonelVardiyalari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonelVardiyalari)).EndInit();
            this.pnlAlt.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.grpİslemTarihi.ResumeLayout(false);
            this.grpİslemTarihi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPersonelVardiyalari;
        private System.Windows.Forms.Panel pnlAlt;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.Button btnRaporGoruntule;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.ComboBox cmbSubeler;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.ComboBox cmbVardiya;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPersonel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.CheckBox chkSilinenKayitlariGoster;
        private System.Windows.Forms.GroupBox grpİslemTarihi;
        private System.Windows.Forms.DateTimePicker dtİslemTarihi2;
        private System.Windows.Forms.DateTimePicker dtİslemTarihi1;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.CheckBox chkİslemTarihi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblKayitSayisi;
        private System.Windows.Forms.Button btnHesapEkle;
        private System.Windows.Forms.DataGridViewTextBoxColumn personelVardiyaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn personelid;
        private System.Windows.Forms.DataGridViewTextBoxColumn personelAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn vardiyaid2;
        private System.Windows.Forms.DataGridViewTextBoxColumn vardiyaAdi2;
        private System.Windows.Forms.DataGridViewTextBoxColumn baslangicTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn bitisTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tatilGunu;
        private System.Windows.Forms.DataGridViewTextBoxColumn subeid2;
        private System.Windows.Forms.DataGridViewTextBoxColumn subeAdi2;
        private System.Windows.Forms.DataGridViewButtonColumn duzenle;
        private System.Windows.Forms.DataGridViewButtonColumn sil;
    }
}