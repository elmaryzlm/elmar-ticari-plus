namespace Elmar_Ticari_Plus
{
    partial class frmLog
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
            this.label70 = new System.Windows.Forms.Label();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.label54 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.lblKayitSayisiF = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.grpİslemTarihi = new System.Windows.Forms.GroupBox();
            this.dtİslemTarihi2 = new System.Windows.Forms.DateTimePicker();
            this.dtİslemTarihi1 = new System.Windows.Forms.DateTimePicker();
            this.label56 = new System.Windows.Forms.Label();
            this.chkİslemTarihi = new System.Windows.Forms.CheckBox();
            this.cmbKullanicilar = new System.Windows.Forms.ComboBox();
            this.cmbSubeler = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnRaporGoruntule = new System.Windows.Forms.Button();
            this.dgLog = new System.Windows.Forms.DataGridView();
            this.logid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kullaniciid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kullaniciAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iliskiid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlAlt = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.cmbLogAciklamasi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtListelenecekLogSayisi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel18.SuspendLayout();
            this.grpİslemTarihi.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLog)).BeginInit();
            this.pnlAlt.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
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
            this.btnSorgula.Location = new System.Drawing.Point(3, 20);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(95, 24);
            this.btnSorgula.TabIndex = 13;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = false;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.White;
            this.label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label54.Dock = System.Windows.Forms.DockStyle.Top;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label54.Location = new System.Drawing.Point(0, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(559, 17);
            this.label54.TabIndex = 0;
            this.label54.Text = "Filtre Seçenekleri";
            this.label54.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.label82.Size = new System.Drawing.Size(151, 19);
            this.label82.TabIndex = 3;
            this.label82.Text = "Listelenen Log Sayısı";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel18.Controls.Add(this.lblKayitSayisiF);
            this.panel18.Controls.Add(this.label82);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel18.Location = new System.Drawing.Point(0, 460);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(693, 21);
            this.panel18.TabIndex = 11;
            // 
            // lblKayitSayisiF
            // 
            this.lblKayitSayisiF.BackColor = System.Drawing.Color.Transparent;
            this.lblKayitSayisiF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKayitSayisiF.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblKayitSayisiF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKayitSayisiF.ForeColor = System.Drawing.Color.DarkRed;
            this.lblKayitSayisiF.Location = new System.Drawing.Point(151, 0);
            this.lblKayitSayisiF.Name = "lblKayitSayisiF";
            this.lblKayitSayisiF.Size = new System.Drawing.Size(103, 19);
            this.lblKayitSayisiF.TabIndex = 4;
            this.lblKayitSayisiF.Text = "0";
            this.lblKayitSayisiF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(6, 19);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(32, 13);
            this.label58.TabIndex = 1;
            this.label58.Text = "Şube";
            // 
            // grpİslemTarihi
            // 
            this.grpİslemTarihi.Controls.Add(this.dtİslemTarihi2);
            this.grpİslemTarihi.Controls.Add(this.dtİslemTarihi1);
            this.grpİslemTarihi.Controls.Add(this.label56);
            this.grpİslemTarihi.Controls.Add(this.chkİslemTarihi);
            this.grpİslemTarihi.Location = new System.Drawing.Point(6, 33);
            this.grpİslemTarihi.Name = "grpİslemTarihi";
            this.grpİslemTarihi.Size = new System.Drawing.Size(274, 42);
            this.grpİslemTarihi.TabIndex = 5;
            this.grpİslemTarihi.TabStop = false;
            // 
            // dtİslemTarihi2
            // 
            this.dtİslemTarihi2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtİslemTarihi2.Location = new System.Drawing.Point(184, 16);
            this.dtİslemTarihi2.Name = "dtİslemTarihi2";
            this.dtİslemTarihi2.Size = new System.Drawing.Size(77, 20);
            this.dtİslemTarihi2.TabIndex = 7;
            this.dtİslemTarihi2.Tag = "001";
            // 
            // dtİslemTarihi1
            // 
            this.dtİslemTarihi1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtİslemTarihi1.Location = new System.Drawing.Point(95, 16);
            this.dtİslemTarihi1.Name = "dtİslemTarihi1";
            this.dtİslemTarihi1.Size = new System.Drawing.Size(77, 20);
            this.dtİslemTarihi1.TabIndex = 6;
            this.dtİslemTarihi1.Tag = "001";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label56.Location = new System.Drawing.Point(173, 20);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(11, 15);
            this.label56.TabIndex = 5;
            this.label56.Text = "-";
            // 
            // chkİslemTarihi
            // 
            this.chkİslemTarihi.AutoSize = true;
            this.chkİslemTarihi.Location = new System.Drawing.Point(8, 19);
            this.chkİslemTarihi.Name = "chkİslemTarihi";
            this.chkİslemTarihi.Size = new System.Drawing.Size(79, 17);
            this.chkİslemTarihi.TabIndex = 12;
            this.chkİslemTarihi.Text = "İşlem Tarihi";
            this.chkİslemTarihi.UseVisualStyleBackColor = true;
            // 
            // cmbKullanicilar
            // 
            this.cmbKullanicilar.BackColor = System.Drawing.Color.White;
            this.cmbKullanicilar.ForeColor = System.Drawing.Color.Black;
            this.cmbKullanicilar.FormattingEnabled = true;
            this.cmbKullanicilar.Location = new System.Drawing.Point(162, 15);
            this.cmbKullanicilar.Name = "cmbKullanicilar";
            this.cmbKullanicilar.Size = new System.Drawing.Size(89, 21);
            this.cmbKullanicilar.TabIndex = 11;
            this.cmbKullanicilar.Tag = "001";
            // 
            // cmbSubeler
            // 
            this.cmbSubeler.BackColor = System.Drawing.Color.White;
            this.cmbSubeler.ForeColor = System.Drawing.Color.Black;
            this.cmbSubeler.FormattingEnabled = true;
            this.cmbSubeler.Location = new System.Drawing.Point(36, 15);
            this.cmbSubeler.Name = "cmbSubeler";
            this.cmbSubeler.Size = new System.Drawing.Size(80, 21);
            this.cmbSubeler.TabIndex = 10;
            this.cmbSubeler.Tag = "001";
            this.cmbSubeler.SelectedIndexChanged += new System.EventHandler(this.cmbSubeler_SelectedIndexChanged);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(117, 19);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(46, 13);
            this.label57.TabIndex = 2;
            this.label57.Text = "Kullanıcı";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.cmbKullanicilar);
            this.groupBox9.Controls.Add(this.cmbSubeler);
            this.groupBox9.Controls.Add(this.label57);
            this.groupBox9.Controls.Add(this.label58);
            this.groupBox9.Location = new System.Drawing.Point(301, 33);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(258, 42);
            this.groupBox9.TabIndex = 9;
            this.groupBox9.TabStop = false;
            // 
            // btnRaporGoruntule
            // 
            this.btnRaporGoruntule.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRaporGoruntule.Location = new System.Drawing.Point(3, 45);
            this.btnRaporGoruntule.Name = "btnRaporGoruntule";
            this.btnRaporGoruntule.Size = new System.Drawing.Size(95, 23);
            this.btnRaporGoruntule.TabIndex = 14;
            this.btnRaporGoruntule.Text = "Rapor Görüntüle";
            this.btnRaporGoruntule.UseVisualStyleBackColor = false;
            this.btnRaporGoruntule.Visible = false;
            // 
            // dgLog
            // 
            this.dgLog.AllowUserToAddRows = false;
            this.dgLog.AllowUserToDeleteRows = false;
            this.dgLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.logid,
            this.aciklama,
            this.kullaniciid,
            this.tarih,
            this.kullaniciAdi,
            this.iliskiid});
            this.dgLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgLog.Location = new System.Drawing.Point(0, 10);
            this.dgLog.MultiSelect = false;
            this.dgLog.Name = "dgLog";
            this.dgLog.ReadOnly = true;
            this.dgLog.RowHeadersWidth = 20;
            this.dgLog.RowTemplate.Height = 20;
            this.dgLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLog.Size = new System.Drawing.Size(693, 450);
            this.dgLog.TabIndex = 1;
            // 
            // logid
            // 
            this.logid.HeaderText = "logid";
            this.logid.Name = "logid";
            this.logid.ReadOnly = true;
            this.logid.Visible = false;
            this.logid.Width = 35;
            // 
            // aciklama
            // 
            this.aciklama.HeaderText = "Açıklama";
            this.aciklama.Name = "aciklama";
            this.aciklama.ReadOnly = true;
            this.aciklama.Width = 75;
            // 
            // kullaniciid
            // 
            this.kullaniciid.HeaderText = "kullaniciid";
            this.kullaniciid.Name = "kullaniciid";
            this.kullaniciid.ReadOnly = true;
            this.kullaniciid.Visible = false;
            this.kullaniciid.Width = 78;
            // 
            // tarih
            // 
            this.tarih.HeaderText = "Tarih-Saat";
            this.tarih.Name = "tarih";
            this.tarih.ReadOnly = true;
            this.tarih.Width = 81;
            // 
            // kullaniciAdi
            // 
            this.kullaniciAdi.HeaderText = "Kullanıcı Adı";
            this.kullaniciAdi.Name = "kullaniciAdi";
            this.kullaniciAdi.ReadOnly = true;
            this.kullaniciAdi.Width = 89;
            // 
            // iliskiid
            // 
            this.iliskiid.HeaderText = "ID";
            this.iliskiid.Name = "iliskiid";
            this.iliskiid.ReadOnly = true;
            this.iliskiid.Width = 43;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 10);
            this.panel1.TabIndex = 8;
            this.panel1.Visible = false;
            // 
            // pnlAlt
            // 
            this.pnlAlt.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlAlt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlt.Controls.Add(this.panel16);
            this.pnlAlt.Controls.Add(this.panel12);
            this.pnlAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlt.Location = new System.Drawing.Point(0, 481);
            this.pnlAlt.Name = "pnlAlt";
            this.pnlAlt.Size = new System.Drawing.Size(693, 79);
            this.pnlAlt.TabIndex = 2;
            this.pnlAlt.TabStop = true;
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.label70);
            this.panel16.Controls.Add(this.btnSorgula);
            this.panel16.Controls.Add(this.btnRaporGoruntule);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(561, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(102, 77);
            this.panel16.TabIndex = 12;
            this.panel16.TabStop = true;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.cmbLogAciklamasi);
            this.panel12.Controls.Add(this.label2);
            this.panel12.Controls.Add(this.txtListelenecekLogSayisi);
            this.panel12.Controls.Add(this.label1);
            this.panel12.Controls.Add(this.label54);
            this.panel12.Controls.Add(this.grpİslemTarihi);
            this.panel12.Controls.Add(this.groupBox9);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(561, 77);
            this.panel12.TabIndex = 3;
            this.panel12.TabStop = true;
            // 
            // cmbLogAciklamasi
            // 
            this.cmbLogAciklamasi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLogAciklamasi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLogAciklamasi.BackColor = System.Drawing.Color.White;
            this.cmbLogAciklamasi.ForeColor = System.Drawing.Color.Black;
            this.cmbLogAciklamasi.FormattingEnabled = true;
            this.cmbLogAciklamasi.Items.AddRange(new object[] {
            "Açık Hesap Kaydı Düzenlendi",
            "Açık Hesap Kaydı Eklendi",
            "Açık Hesap Kaydı Silindi",
            "Adres Düzenlendi",
            "Adres Eklendi",
            "Adres Silindi",
            "Banka Düzenlendi",
            "Banka Eklendi",
            "Banka Hesabı Düzenlendi",
            "Banka Hesabı Eklendi",
            "Banka Hesabı Silindi",
            "Banka İşlemi Düzenlendi",
            "Banka İşlemi Eklendi",
            "Banka İşlemi Silindi",
            "Banka Silindi",
            "Birim Düzenlendi",
            "Birim Eklendi",
            "Birim Silindi",
            "Cari Düzenlendi",
            "Cari Eklendi",
            "Cari Silindi",
            "Çek-Senet Düzenlendi",
            "Çek-Senet Eklendi",
            "Çek-Senet Silindi",
            "Firma Bilgileri Düzenlendi",
            "Firma Eklendi",
            "Fiyat Düzenlendi",
            "Fiyat Eklendi",
            "Fiyat Silindi",
            "Gelir Düzenlendi",
            "Gelir Eklendi",
            "Gelir Silindi",
            "Kredi Kartı Düzenlendi",
            "Kredi Kartı Eklendi",
            "Kredi Kartı Silindi",
            "Kullanıcı Düzenlendi",
            "Kullanıcı Eklendi",
            "Kullanıcı Silindi",
            "Masraf Düzenlendi",
            "Masraf Eklendi",
            "Masraf Silindi",
            "Personel Düzenlendi",
            "Personel Eklendi",
            "Personel Görevi Düzenlendi",
            "Personel Görevi Eklendi",
            "Personel Görevi Silindi",
            "Personel İşe Başlatıldı",
            "Personel İşten Çıkartıldı",
            "Personel Maaşı Düzenlendi",
            "Personel Maaşı Silindi",
            "Personel Silindi",
            "Personel Vardiyası Düzenlendi",
            "Personel Vardiyası Silindi",
            "Personele Maaş Eklendi",
            "Personele Vardiya Eklendi",
            "Pos Düzenlendi",
            "Pos Eklendi",
            "Pos Silindi",
            "Pos Taksitleri Düzenlendi",
            "Programa Giriş Yapıldı",
            "Programdan Çıkış Yapıldı",
            "Stok Kartı Düzenlendi",
            "Stok Kartı Eklendi",
            "Stok Kartı Silindi",
            "Şube Düzenlendi",
            "Şube Eklendi",
            "Şube Silindi",
            "Taksit Düzenlendi",
            "Taksit Silindi",
            "Taksit Tanımlaması Yapıldı",
            "Ticari İşlem Düzenlendi (Satış-Alış-Teklif-Sip..)",
            "Ticari İşlem Silindi (Satış-Alış-Teklif-Sipariş..)",
            "Ticari İşlem Yapıldı (Satış-Alış-Teklif-Sipariş..)",
            "Vardiya Düzenlendi",
            "Vardiya Eklendi",
            "Vardiya Silindi"});
            this.cmbLogAciklamasi.Location = new System.Drawing.Point(101, 23);
            this.cmbLogAciklamasi.Name = "cmbLogAciklamasi";
            this.cmbLogAciklamasi.Size = new System.Drawing.Size(166, 21);
            this.cmbLogAciklamasi.TabIndex = 4;
            this.cmbLogAciklamasi.Tag = "001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Log Açıklaması";
            // 
            // txtListelenecekLogSayisi
            // 
            this.txtListelenecekLogSayisi.BackColor = System.Drawing.Color.White;
            this.txtListelenecekLogSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtListelenecekLogSayisi.ForeColor = System.Drawing.Color.Black;
            this.txtListelenecekLogSayisi.Location = new System.Drawing.Point(438, 22);
            this.txtListelenecekLogSayisi.Name = "txtListelenecekLogSayisi";
            this.txtListelenecekLogSayisi.Size = new System.Drawing.Size(114, 21);
            this.txtListelenecekLogSayisi.TabIndex = 8;
            this.txtListelenecekLogSayisi.Tag = "011";
            this.txtListelenecekLogSayisi.Text = "100";
            this.txtListelenecekLogSayisi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Listelenecek Kayıt Sayısı";
            // 
            // frmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 560);
            this.Controls.Add(this.dgLog);
            this.Controls.Add(this.panel18);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlAlt);
            this.Name = "frmLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Kullanıcı Logları";
            this.Load += new System.EventHandler(this.frmLog_Load);
            this.panel18.ResumeLayout(false);
            this.grpİslemTarihi.ResumeLayout(false);
            this.grpİslemTarihi.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLog)).EndInit();
            this.pnlAlt.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label lblKayitSayisiF;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.GroupBox grpİslemTarihi;
        private System.Windows.Forms.DateTimePicker dtİslemTarihi2;
        private System.Windows.Forms.DateTimePicker dtİslemTarihi1;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.CheckBox chkİslemTarihi;
        private System.Windows.Forms.ComboBox cmbKullanicilar;
        private System.Windows.Forms.ComboBox cmbSubeler;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnRaporGoruntule;
        private System.Windows.Forms.DataGridView dgLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn logid;
        private System.Windows.Forms.DataGridViewTextBoxColumn aciklama;
        private System.Windows.Forms.DataGridViewTextBoxColumn kullaniciid;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn kullaniciAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn iliskiid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlAlt;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.ComboBox cmbLogAciklamasi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtListelenecekLogSayisi;
        private System.Windows.Forms.Label label1;
    }
}