namespace Elmar_Ticari_Plus
{
    partial class frmPersonelMaasListele
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbKalanGun = new System.Windows.Forms.ComboBox();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.dtKayitTarihi = new System.Windows.Forms.DateTimePicker();
            this.chkKayitTarihi = new System.Windows.Forms.CheckBox();
            this.cmbKullanicilar = new System.Windows.Forms.ComboBox();
            this.cmbSubeler = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.pnlAlt = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.btnYazdir = new System.Windows.Forms.Button();
            this.btnRaporGoruntule = new System.Windows.Forms.Button();
            this.label70 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.cmbislemTuru = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPersonelAdlari = new System.Windows.Forms.ComboBox();
            this.chkSilinenKayitlariGoster = new System.Windows.Forms.CheckBox();
            this.grpİslemTarihi = new System.Windows.Forms.GroupBox();
            this.label54 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgMaaslar = new System.Windows.Forms.DataGridView();
            this.maasid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personelid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personelAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.islemTuru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kayitTarihiDegisken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kayitSaatiDegisken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kayitTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnsMaas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silmeİşleminiGeriAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel18 = new System.Windows.Forms.Panel();
            this.label79 = new System.Windows.Forms.Label();
            this.lblBakiye = new System.Windows.Forms.Label();
            this.lblKayitSayisi = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.pnlAlt.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel12.SuspendLayout();
            this.grpİslemTarihi.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMaaslar)).BeginInit();
            this.cnsMaas.SuspendLayout();
            this.panel18.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Açıklama";
            // 
            // txtAciklama
            // 
            this.txtAciklama.BackColor = System.Drawing.Color.White;
            this.txtAciklama.ForeColor = System.Drawing.Color.Black;
            this.txtAciklama.Location = new System.Drawing.Point(74, 69);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(241, 20);
            this.txtAciklama.TabIndex = 6;
            this.txtAciklama.Tag = "001";
            this.txtAciklama.TextChanged += new System.EventHandler(this.btnSorgula_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbKalanGun);
            this.groupBox1.Controls.Add(this.txtTutar);
            this.groupBox1.Location = new System.Drawing.Point(323, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 39);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "Tutar";
            // 
            // cmbKalanGun
            // 
            this.cmbKalanGun.BackColor = System.Drawing.Color.White;
            this.cmbKalanGun.ForeColor = System.Drawing.Color.Black;
            this.cmbKalanGun.FormattingEnabled = true;
            this.cmbKalanGun.Items.AddRange(new object[] {
            "=",
            "<",
            "<=",
            ">",
            ">="});
            this.cmbKalanGun.Location = new System.Drawing.Point(38, 13);
            this.cmbKalanGun.Name = "cmbKalanGun";
            this.cmbKalanGun.Size = new System.Drawing.Size(60, 21);
            this.cmbKalanGun.TabIndex = 7;
            this.cmbKalanGun.Tag = "001";
            this.cmbKalanGun.Text = "=";
            this.cmbKalanGun.SelectedIndexChanged += new System.EventHandler(this.btnSorgula_Click);
            // 
            // txtTutar
            // 
            this.txtTutar.BackColor = System.Drawing.Color.White;
            this.txtTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTutar.ForeColor = System.Drawing.Color.Black;
            this.txtTutar.Location = new System.Drawing.Point(98, 13);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(76, 21);
            this.txtTutar.TabIndex = 8;
            this.txtTutar.Tag = "221";
            this.txtTutar.TextChanged += new System.EventHandler(this.btnSorgula_Click);
            // 
            // dtKayitTarihi
            // 
            this.dtKayitTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtKayitTarihi.Location = new System.Drawing.Point(85, 14);
            this.dtKayitTarihi.Name = "dtKayitTarihi";
            this.dtKayitTarihi.Size = new System.Drawing.Size(103, 20);
            this.dtKayitTarihi.TabIndex = 3;
            this.dtKayitTarihi.Tag = "001";
            this.dtKayitTarihi.ValueChanged += new System.EventHandler(this.btnSorgula_Click);
            // 
            // chkKayitTarihi
            // 
            this.chkKayitTarihi.AutoSize = true;
            this.chkKayitTarihi.Location = new System.Drawing.Point(8, 17);
            this.chkKayitTarihi.Name = "chkKayitTarihi";
            this.chkKayitTarihi.Size = new System.Drawing.Size(78, 17);
            this.chkKayitTarihi.TabIndex = 12;
            this.chkKayitTarihi.Text = "Kayıt Tarihi";
            this.chkKayitTarihi.UseVisualStyleBackColor = true;
            this.chkKayitTarihi.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // cmbKullanicilar
            // 
            this.cmbKullanicilar.BackColor = System.Drawing.Color.White;
            this.cmbKullanicilar.ForeColor = System.Drawing.Color.Black;
            this.cmbKullanicilar.FormattingEnabled = true;
            this.cmbKullanicilar.Location = new System.Drawing.Point(235, 14);
            this.cmbKullanicilar.Name = "cmbKullanicilar";
            this.cmbKullanicilar.Size = new System.Drawing.Size(135, 21);
            this.cmbKullanicilar.TabIndex = 10;
            this.cmbKullanicilar.Tag = "001";
            this.cmbKullanicilar.SelectedIndexChanged += new System.EventHandler(this.btnSorgula_Click);
            // 
            // cmbSubeler
            // 
            this.cmbSubeler.BackColor = System.Drawing.Color.White;
            this.cmbSubeler.ForeColor = System.Drawing.Color.Black;
            this.cmbSubeler.FormattingEnabled = true;
            this.cmbSubeler.Location = new System.Drawing.Point(38, 14);
            this.cmbSubeler.Name = "cmbSubeler";
            this.cmbSubeler.Size = new System.Drawing.Size(136, 21);
            this.cmbSubeler.TabIndex = 9;
            this.cmbSubeler.Tag = "001";
            this.cmbSubeler.SelectedIndexChanged += new System.EventHandler(this.cmbSubeler_SelectedIndexChanged);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(190, 17);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(46, 13);
            this.label57.TabIndex = 2;
            this.label57.Text = "Kullanıcı";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(2, 17);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(32, 13);
            this.label58.TabIndex = 1;
            this.label58.Text = "Şube";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "İşlem Türü";
            // 
            // btnSorgula
            // 
            this.btnSorgula.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSorgula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSorgula.Location = new System.Drawing.Point(3, 20);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(95, 28);
            this.btnSorgula.TabIndex = 12;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = false;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // pnlAlt
            // 
            this.pnlAlt.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlAlt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlt.Controls.Add(this.panel16);
            this.pnlAlt.Controls.Add(this.panel12);
            this.pnlAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlt.Location = new System.Drawing.Point(0, 423);
            this.pnlAlt.Name = "pnlAlt";
            this.pnlAlt.Size = new System.Drawing.Size(831, 119);
            this.pnlAlt.TabIndex = 2;
            this.pnlAlt.TabStop = true;
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.btnSorgula);
            this.panel16.Controls.Add(this.btnYazdir);
            this.panel16.Controls.Add(this.btnRaporGoruntule);
            this.panel16.Controls.Add(this.label70);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(706, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(102, 117);
            this.panel16.TabIndex = 11;
            this.panel16.TabStop = true;
            // 
            // btnYazdir
            // 
            this.btnYazdir.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnYazdir.Location = new System.Drawing.Point(3, 75);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(95, 26);
            this.btnYazdir.TabIndex = 14;
            this.btnYazdir.Text = "Yazdır";
            this.btnYazdir.UseVisualStyleBackColor = false;
            this.btnYazdir.Click += new System.EventHandler(this.btnYazdir_Click);
            // 
            // btnRaporGoruntule
            // 
            this.btnRaporGoruntule.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRaporGoruntule.Location = new System.Drawing.Point(3, 48);
            this.btnRaporGoruntule.Name = "btnRaporGoruntule";
            this.btnRaporGoruntule.Size = new System.Drawing.Size(95, 27);
            this.btnRaporGoruntule.TabIndex = 13;
            this.btnRaporGoruntule.Text = "Rapor Görüntüle";
            this.btnRaporGoruntule.UseVisualStyleBackColor = false;
            this.btnRaporGoruntule.Click += new System.EventHandler(this.btnRaporGoruntule_Click);
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label70.Dock = System.Windows.Forms.DockStyle.Top;
            this.label70.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label70.Location = new System.Drawing.Point(0, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(71, 17);
            this.label70.TabIndex = 0;
            this.label70.Text = "Raporlama";
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.cmbislemTuru);
            this.panel12.Controls.Add(this.groupBox1);
            this.panel12.Controls.Add(this.label5);
            this.panel12.Controls.Add(this.txtAciklama);
            this.panel12.Controls.Add(this.label2);
            this.panel12.Controls.Add(this.label1);
            this.panel12.Controls.Add(this.cmbPersonelAdlari);
            this.panel12.Controls.Add(this.chkSilinenKayitlariGoster);
            this.panel12.Controls.Add(this.grpİslemTarihi);
            this.panel12.Controls.Add(this.label54);
            this.panel12.Controls.Add(this.groupBox9);
            this.panel12.Controls.Add(this.label4);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(706, 117);
            this.panel12.TabIndex = 3;
            this.panel12.TabStop = true;
            // 
            // cmbislemTuru
            // 
            this.cmbislemTuru.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbislemTuru.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbislemTuru.BackColor = System.Drawing.Color.White;
            this.cmbislemTuru.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbislemTuru.ForeColor = System.Drawing.Color.Black;
            this.cmbislemTuru.FormattingEnabled = true;
            this.cmbislemTuru.Items.AddRange(new object[] {
            "Maaş Girişi",
            "Prim Girişi",
            "Maaş Ödemesi",
            "Prim Ödemesi",
            "Avans",
            "Kesinti",
            "İkramiye",
            "Yemek Ödemesi",
            "Yol Ödemesi"});
            this.cmbislemTuru.Location = new System.Drawing.Point(74, 45);
            this.cmbislemTuru.Name = "cmbislemTuru";
            this.cmbislemTuru.Size = new System.Drawing.Size(241, 22);
            this.cmbislemTuru.TabIndex = 5;
            this.cmbislemTuru.Tag = "001";
            this.cmbislemTuru.SelectedIndexChanged += new System.EventHandler(this.btnSorgula_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Personel Adı";
            // 
            // cmbPersonelAdlari
            // 
            this.cmbPersonelAdlari.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPersonelAdlari.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPersonelAdlari.BackColor = System.Drawing.Color.White;
            this.cmbPersonelAdlari.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbPersonelAdlari.ForeColor = System.Drawing.Color.Black;
            this.cmbPersonelAdlari.FormattingEnabled = true;
            this.cmbPersonelAdlari.Location = new System.Drawing.Point(74, 21);
            this.cmbPersonelAdlari.Name = "cmbPersonelAdlari";
            this.cmbPersonelAdlari.Size = new System.Drawing.Size(241, 22);
            this.cmbPersonelAdlari.TabIndex = 4;
            this.cmbPersonelAdlari.Tag = "001";
            this.cmbPersonelAdlari.SelectedIndexChanged += new System.EventHandler(this.btnSorgula_Click);
            // 
            // chkSilinenKayitlariGoster
            // 
            this.chkSilinenKayitlariGoster.AutoSize = true;
            this.chkSilinenKayitlariGoster.Location = new System.Drawing.Point(563, 98);
            this.chkSilinenKayitlariGoster.Name = "chkSilinenKayitlariGoster";
            this.chkSilinenKayitlariGoster.Size = new System.Drawing.Size(130, 17);
            this.chkSilinenKayitlariGoster.TabIndex = 15;
            this.chkSilinenKayitlariGoster.Text = "Silinen Kayıtları Göster";
            this.chkSilinenKayitlariGoster.UseVisualStyleBackColor = true;
            this.chkSilinenKayitlariGoster.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // grpİslemTarihi
            // 
            this.grpİslemTarihi.Controls.Add(this.dtKayitTarihi);
            this.grpİslemTarihi.Controls.Add(this.chkKayitTarihi);
            this.grpİslemTarihi.Location = new System.Drawing.Point(505, 14);
            this.grpİslemTarihi.Name = "grpİslemTarihi";
            this.grpİslemTarihi.Size = new System.Drawing.Size(200, 39);
            this.grpİslemTarihi.TabIndex = 13;
            this.grpİslemTarihi.TabStop = false;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label54.Dock = System.Windows.Forms.DockStyle.Top;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label54.Location = new System.Drawing.Point(0, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(104, 17);
            this.label54.TabIndex = 0;
            this.label54.Text = "Filtre Seçenekleri";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.cmbKullanicilar);
            this.groupBox9.Controls.Add(this.cmbSubeler);
            this.groupBox9.Controls.Add(this.label58);
            this.groupBox9.Controls.Add(this.label57);
            this.groupBox9.Location = new System.Drawing.Point(323, 48);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(384, 42);
            this.groupBox9.TabIndex = 14;
            this.groupBox9.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-4, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(739, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "_________________________________________________________________________________" +
    "_________________________________________";
            // 
            // dgMaaslar
            // 
            this.dgMaaslar.AllowUserToAddRows = false;
            this.dgMaaslar.AllowUserToDeleteRows = false;
            this.dgMaaslar.AllowUserToResizeColumns = false;
            this.dgMaaslar.AllowUserToResizeRows = false;
            this.dgMaaslar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgMaaslar.BackgroundColor = System.Drawing.Color.White;
            this.dgMaaslar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMaaslar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maasid,
            this.personelid,
            this.personelAdi,
            this.islemTuru,
            this.tutar,
            this.kayitTarihiDegisken,
            this.kayitSaatiDegisken,
            this.kayitTarihi,
            this.aciklama});
            this.dgMaaslar.ContextMenuStrip = this.cnsMaas;
            this.dgMaaslar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMaaslar.Location = new System.Drawing.Point(0, 0);
            this.dgMaaslar.MultiSelect = false;
            this.dgMaaslar.Name = "dgMaaslar";
            this.dgMaaslar.RowHeadersWidth = 10;
            this.dgMaaslar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgMaaslar.RowTemplate.Height = 20;
            this.dgMaaslar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMaaslar.Size = new System.Drawing.Size(831, 402);
            this.dgMaaslar.TabIndex = 1;
            // 
            // maasid
            // 
            this.maasid.HeaderText = "maasid";
            this.maasid.Name = "maasid";
            this.maasid.Visible = false;
            this.maasid.Width = 46;
            // 
            // personelid
            // 
            this.personelid.HeaderText = "personelid";
            this.personelid.Name = "personelid";
            this.personelid.Visible = false;
            this.personelid.Width = 61;
            // 
            // personelAdi
            // 
            this.personelAdi.HeaderText = "Personel Adı";
            this.personelAdi.Name = "personelAdi";
            this.personelAdi.ReadOnly = true;
            this.personelAdi.Width = 91;
            // 
            // islemTuru
            // 
            this.islemTuru.HeaderText = "İşlem Türü";
            this.islemTuru.Name = "islemTuru";
            this.islemTuru.ReadOnly = true;
            this.islemTuru.Width = 81;
            // 
            // tutar
            // 
            this.tutar.HeaderText = "Tutar";
            this.tutar.Name = "tutar";
            this.tutar.ReadOnly = true;
            this.tutar.Width = 57;
            // 
            // kayitTarihiDegisken
            // 
            this.kayitTarihiDegisken.HeaderText = "kayitTarihiDegisken";
            this.kayitTarihiDegisken.Name = "kayitTarihiDegisken";
            this.kayitTarihiDegisken.Visible = false;
            this.kayitTarihiDegisken.Width = 125;
            // 
            // kayitSaatiDegisken
            // 
            this.kayitSaatiDegisken.HeaderText = "kayitSaatiDegisken";
            this.kayitSaatiDegisken.Name = "kayitSaatiDegisken";
            this.kayitSaatiDegisken.Visible = false;
            this.kayitSaatiDegisken.Width = 123;
            // 
            // kayitTarihi
            // 
            this.kayitTarihi.HeaderText = "Kayıt Tarihi";
            this.kayitTarihi.Name = "kayitTarihi";
            this.kayitTarihi.ReadOnly = true;
            this.kayitTarihi.Width = 84;
            // 
            // aciklama
            // 
            this.aciklama.HeaderText = "Açıklama";
            this.aciklama.Name = "aciklama";
            this.aciklama.ReadOnly = true;
            this.aciklama.Width = 75;
            // 
            // cnsMaas
            // 
            this.cnsMaas.BackColor = System.Drawing.Color.Gainsboro;
            this.cnsMaas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.düzenleToolStripMenuItem,
            this.silToolStripMenuItem,
            this.silmeİşleminiGeriAlToolStripMenuItem});
            this.cnsMaas.Name = "cnsStokkart";
            this.cnsMaas.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cnsMaas.Size = new System.Drawing.Size(186, 70);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // silmeİşleminiGeriAlToolStripMenuItem
            // 
            this.silmeİşleminiGeriAlToolStripMenuItem.Name = "silmeİşleminiGeriAlToolStripMenuItem";
            this.silmeİşleminiGeriAlToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.silmeİşleminiGeriAlToolStripMenuItem.Text = "Silme İşlemini Geri Al";
            this.silmeİşleminiGeriAlToolStripMenuItem.Click += new System.EventHandler(this.silmeİşleminiGeriAlToolStripMenuItem_Click);
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel18.Controls.Add(this.label79);
            this.panel18.Controls.Add(this.lblBakiye);
            this.panel18.Controls.Add(this.lblKayitSayisi);
            this.panel18.Controls.Add(this.label82);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel18.Location = new System.Drawing.Point(0, 402);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(831, 21);
            this.panel18.TabIndex = 8;
            // 
            // label79
            // 
            this.label79.BackColor = System.Drawing.Color.Transparent;
            this.label79.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label79.Dock = System.Windows.Forms.DockStyle.Right;
            this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label79.ForeColor = System.Drawing.Color.Black;
            this.label79.Location = new System.Drawing.Point(664, 0);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(105, 19);
            this.label79.TabIndex = 6;
            this.label79.Text = "Toplam Bakiye";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBakiye
            // 
            this.lblBakiye.AutoSize = true;
            this.lblBakiye.BackColor = System.Drawing.Color.Transparent;
            this.lblBakiye.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBakiye.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBakiye.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBakiye.ForeColor = System.Drawing.Color.DarkRed;
            this.lblBakiye.Location = new System.Drawing.Point(769, 0);
            this.lblBakiye.Name = "lblBakiye";
            this.lblBakiye.Size = new System.Drawing.Size(60, 18);
            this.lblBakiye.TabIndex = 5;
            this.lblBakiye.Text = "0,00 TL";
            this.lblBakiye.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.lblKayitSayisi.Size = new System.Drawing.Size(81, 19);
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
            this.label82.Size = new System.Drawing.Size(91, 19);
            this.label82.TabIndex = 3;
            this.label82.Text = "Kayıt Sayısı: ";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPersonelMaasListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(831, 542);
            this.Controls.Add(this.dgMaaslar);
            this.Controls.Add(this.panel18);
            this.Controls.Add(this.pnlAlt);
            this.Name = "frmPersonelMaasListele";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Personel Maaş Listesi";
            this.Load += new System.EventHandler(this.frmPersonelMaasListele_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlAlt.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.grpİslemTarihi.ResumeLayout(false);
            this.grpİslemTarihi.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMaaslar)).EndInit();
            this.cnsMaas.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbKalanGun;
        private System.Windows.Forms.TextBox txtTutar;
        private System.Windows.Forms.DateTimePicker dtKayitTarihi;
        private System.Windows.Forms.CheckBox chkKayitTarihi;
        private System.Windows.Forms.ComboBox cmbKullanicilar;
        private System.Windows.Forms.ComboBox cmbSubeler;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.Panel pnlAlt;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button btnYazdir;
        private System.Windows.Forms.Button btnRaporGoruntule;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.ComboBox cmbislemTuru;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPersonelAdlari;
        private System.Windows.Forms.CheckBox chkSilinenKayitlariGoster;
        private System.Windows.Forms.GroupBox grpİslemTarihi;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgMaaslar;
        private System.Windows.Forms.ContextMenuStrip cnsMaas;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silmeİşleminiGeriAlToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn maasid;
        private System.Windows.Forms.DataGridViewTextBoxColumn personelid;
        private System.Windows.Forms.DataGridViewTextBoxColumn personelAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn islemTuru;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn kayitTarihiDegisken;
        private System.Windows.Forms.DataGridViewTextBoxColumn kayitSaatiDegisken;
        private System.Windows.Forms.DataGridViewTextBoxColumn kayitTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn aciklama;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label lblBakiye;
        private System.Windows.Forms.Label lblKayitSayisi;
        private System.Windows.Forms.Label label82;
    }
}