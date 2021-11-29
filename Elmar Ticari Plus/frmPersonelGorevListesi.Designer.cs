namespace Elmar_Ticari_Plus
{
    partial class frmPersonelGorevListesi
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
            this.dgGorevler = new System.Windows.Forms.DataGridView();
            this.gorevid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personelid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personelAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gorevAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gorevTanimi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gorevBaslangicTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gorevBitisTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baslangicSaati = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bitisSaati = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kalanGun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yorumSayisi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gorevBittimi = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.aciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAlt = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.lblKayitSayisi3 = new System.Windows.Forms.Label();
            this.btnYazdir = new System.Windows.Forms.Button();
            this.btnRaporGoruntule = new System.Windows.Forms.Button();
            this.label70 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbYorumSayisi = new System.Windows.Forms.ComboBox();
            this.txtYorumSayisi = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbKalanGun = new System.Windows.Forms.ComboBox();
            this.txtKalanGun = new System.Windows.Forms.TextBox();
            this.chkBitenGorevleriGoster = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGorevTanimi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGorevAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPersonelAdlari = new System.Windows.Forms.ComboBox();
            this.chkSilinenKayitlariGoster = new System.Windows.Forms.CheckBox();
            this.grpİslemTarihi = new System.Windows.Forms.GroupBox();
            this.dtBitisTarihi = new System.Windows.Forms.DateTimePicker();
            this.chkBitisTarihi = new System.Windows.Forms.CheckBox();
            this.dtBaslangictarihi = new System.Windows.Forms.DateTimePicker();
            this.chkBaslangicTarihi = new System.Windows.Forms.CheckBox();
            this.label54 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.cmbKullanicilar = new System.Windows.Forms.ComboBox();
            this.cmbSubeler = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSil = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPersonelAdi2 = new System.Windows.Forms.TextBox();
            this.txtSonlanmaSaati = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBaslangicSaati = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtBaslangicTarihi2 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtGorevTanimi2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtGorevAdi2 = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtAciklama2 = new System.Windows.Forms.TextBox();
            this.dtBitisTarihi2 = new System.Windows.Forms.DateTimePicker();
            this.label78 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgGorevler)).BeginInit();
            this.pnlAlt.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel12.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpİslemTarihi.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgGorevler
            // 
            this.dgGorevler.AllowUserToAddRows = false;
            this.dgGorevler.AllowUserToDeleteRows = false;
            this.dgGorevler.AllowUserToResizeColumns = false;
            this.dgGorevler.AllowUserToResizeRows = false;
            this.dgGorevler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgGorevler.BackgroundColor = System.Drawing.Color.White;
            this.dgGorevler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGorevler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gorevid,
            this.personelid,
            this.personelAdi,
            this.gorevAdi,
            this.gorevTanimi,
            this.gorevBaslangicTarihi,
            this.gorevBitisTarihi,
            this.baslangicSaati,
            this.bitisSaati,
            this.kalanGun,
            this.yorumSayisi,
            this.gorevBittimi,
            this.aciklama});
            this.dgGorevler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgGorevler.Location = new System.Drawing.Point(0, 0);
            this.dgGorevler.MultiSelect = false;
            this.dgGorevler.Name = "dgGorevler";
            this.dgGorevler.RowHeadersWidth = 10;
            this.dgGorevler.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgGorevler.RowTemplate.Height = 20;
            this.dgGorevler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgGorevler.Size = new System.Drawing.Size(412, 379);
            this.dgGorevler.TabIndex = 1;
            this.dgGorevler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgGorevler_CellClick);
            this.dgGorevler.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgGorevler_CellEndEdit);
            // 
            // gorevid
            // 
            this.gorevid.HeaderText = "gorevid";
            this.gorevid.Name = "gorevid";
            this.gorevid.Visible = false;
            this.gorevid.Width = 48;
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
            // gorevAdi
            // 
            this.gorevAdi.HeaderText = "Görev Adı";
            this.gorevAdi.Name = "gorevAdi";
            this.gorevAdi.ReadOnly = true;
            this.gorevAdi.Width = 79;
            // 
            // gorevTanimi
            // 
            this.gorevTanimi.HeaderText = "Görev Tanımı";
            this.gorevTanimi.Name = "gorevTanimi";
            this.gorevTanimi.ReadOnly = true;
            this.gorevTanimi.Visible = false;
            this.gorevTanimi.Width = 95;
            // 
            // gorevBaslangicTarihi
            // 
            this.gorevBaslangicTarihi.HeaderText = "Başlangıç Tarihi";
            this.gorevBaslangicTarihi.Name = "gorevBaslangicTarihi";
            this.gorevBaslangicTarihi.ReadOnly = true;
            this.gorevBaslangicTarihi.Visible = false;
            this.gorevBaslangicTarihi.Width = 107;
            // 
            // gorevBitisTarihi
            // 
            this.gorevBitisTarihi.HeaderText = "Bitiş Tarihi";
            this.gorevBitisTarihi.Name = "gorevBitisTarihi";
            this.gorevBitisTarihi.ReadOnly = true;
            this.gorevBitisTarihi.Visible = false;
            this.gorevBitisTarihi.Width = 80;
            // 
            // baslangicSaati
            // 
            this.baslangicSaati.HeaderText = "Başlangıç Saati";
            this.baslangicSaati.Name = "baslangicSaati";
            this.baslangicSaati.ReadOnly = true;
            this.baslangicSaati.Visible = false;
            this.baslangicSaati.Width = 105;
            // 
            // bitisSaati
            // 
            this.bitisSaati.HeaderText = "Bitiş Saati";
            this.bitisSaati.Name = "bitisSaati";
            this.bitisSaati.ReadOnly = true;
            this.bitisSaati.Visible = false;
            this.bitisSaati.Width = 78;
            // 
            // kalanGun
            // 
            this.kalanGun.HeaderText = "Kalan";
            this.kalanGun.Name = "kalanGun";
            this.kalanGun.ReadOnly = true;
            this.kalanGun.Width = 59;
            // 
            // yorumSayisi
            // 
            this.yorumSayisi.HeaderText = "";
            this.yorumSayisi.Name = "yorumSayisi";
            this.yorumSayisi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.yorumSayisi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.yorumSayisi.Visible = false;
            this.yorumSayisi.Width = 19;
            // 
            // gorevBittimi
            // 
            this.gorevBittimi.HeaderText = "Görev Bittimi";
            this.gorevBittimi.Name = "gorevBittimi";
            this.gorevBittimi.Width = 72;
            // 
            // aciklama
            // 
            this.aciklama.HeaderText = "Açıklama";
            this.aciklama.Name = "aciklama";
            this.aciklama.ReadOnly = true;
            this.aciklama.Visible = false;
            this.aciklama.Width = 75;
            // 
            // pnlAlt
            // 
            this.pnlAlt.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlAlt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlt.Controls.Add(this.panel16);
            this.pnlAlt.Controls.Add(this.panel12);
            this.pnlAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlt.Location = new System.Drawing.Point(0, 379);
            this.pnlAlt.Name = "pnlAlt";
            this.pnlAlt.Size = new System.Drawing.Size(831, 140);
            this.pnlAlt.TabIndex = 13;
            this.pnlAlt.TabStop = true;
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.btnSorgula);
            this.panel16.Controls.Add(this.lblKayitSayisi3);
            this.panel16.Controls.Add(this.btnYazdir);
            this.panel16.Controls.Add(this.btnRaporGoruntule);
            this.panel16.Controls.Add(this.label70);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(706, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(102, 138);
            this.panel16.TabIndex = 25;
            this.panel16.TabStop = true;
            // 
            // btnSorgula
            // 
            this.btnSorgula.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSorgula.Location = new System.Drawing.Point(3, 28);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(95, 23);
            this.btnSorgula.TabIndex = 2;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = false;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // lblKayitSayisi3
            // 
            this.lblKayitSayisi3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblKayitSayisi3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblKayitSayisi3.ForeColor = System.Drawing.Color.DarkRed;
            this.lblKayitSayisi3.Location = new System.Drawing.Point(0, 115);
            this.lblKayitSayisi3.Name = "lblKayitSayisi3";
            this.lblKayitSayisi3.Size = new System.Drawing.Size(100, 21);
            this.lblKayitSayisi3.TabIndex = 51;
            this.lblKayitSayisi3.Text = "Kayıt Sayısı:";
            this.lblKayitSayisi3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnYazdir
            // 
            this.btnYazdir.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnYazdir.Location = new System.Drawing.Point(3, 76);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(95, 23);
            this.btnYazdir.TabIndex = 28;
            this.btnYazdir.Text = "Yazdır";
            this.btnYazdir.UseVisualStyleBackColor = false;
            // 
            // btnRaporGoruntule
            // 
            this.btnRaporGoruntule.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRaporGoruntule.Location = new System.Drawing.Point(3, 52);
            this.btnRaporGoruntule.Name = "btnRaporGoruntule";
            this.btnRaporGoruntule.Size = new System.Drawing.Size(95, 23);
            this.btnRaporGoruntule.TabIndex = 27;
            this.btnRaporGoruntule.Text = "Rapor Görüntüle";
            this.btnRaporGoruntule.UseVisualStyleBackColor = false;
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
            this.panel12.Controls.Add(this.groupBox2);
            this.panel12.Controls.Add(this.groupBox1);
            this.panel12.Controls.Add(this.chkBitenGorevleriGoster);
            this.panel12.Controls.Add(this.label5);
            this.panel12.Controls.Add(this.txtAciklama);
            this.panel12.Controls.Add(this.label3);
            this.panel12.Controls.Add(this.txtGorevTanimi);
            this.panel12.Controls.Add(this.label2);
            this.panel12.Controls.Add(this.txtGorevAdi);
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
            this.panel12.Size = new System.Drawing.Size(706, 138);
            this.panel12.TabIndex = 14;
            this.panel12.TabStop = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbYorumSayisi);
            this.groupBox2.Controls.Add(this.txtYorumSayisi);
            this.groupBox2.Location = new System.Drawing.Point(519, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 39);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "Yorum Sayısı";
            // 
            // cmbYorumSayisi
            // 
            this.cmbYorumSayisi.BackColor = System.Drawing.Color.White;
            this.cmbYorumSayisi.ForeColor = System.Drawing.Color.Black;
            this.cmbYorumSayisi.FormattingEnabled = true;
            this.cmbYorumSayisi.Items.AddRange(new object[] {
            "=",
            "<",
            "<=",
            ">",
            ">="});
            this.cmbYorumSayisi.Location = new System.Drawing.Point(74, 13);
            this.cmbYorumSayisi.Name = "cmbYorumSayisi";
            this.cmbYorumSayisi.Size = new System.Drawing.Size(49, 21);
            this.cmbYorumSayisi.TabIndex = 21;
            this.cmbYorumSayisi.Tag = "001";
            this.cmbYorumSayisi.Text = "=";
            this.cmbYorumSayisi.SelectedIndexChanged += new System.EventHandler(this.btnSorgula_Click);
            // 
            // txtYorumSayisi
            // 
            this.txtYorumSayisi.BackColor = System.Drawing.Color.White;
            this.txtYorumSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYorumSayisi.ForeColor = System.Drawing.Color.Black;
            this.txtYorumSayisi.Location = new System.Drawing.Point(123, 13);
            this.txtYorumSayisi.Name = "txtYorumSayisi";
            this.txtYorumSayisi.Size = new System.Drawing.Size(59, 21);
            this.txtYorumSayisi.TabIndex = 22;
            this.txtYorumSayisi.Tag = "011";
            this.txtYorumSayisi.TextChanged += new System.EventHandler(this.btnSorgula_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbKalanGun);
            this.groupBox1.Controls.Add(this.txtKalanGun);
            this.groupBox1.Location = new System.Drawing.Point(325, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 39);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "Kalan Gün";
            // 
            // cmbKalanGun
            // 
            this.cmbKalanGun.BackColor = System.Drawing.Color.White;
            this.cmbKalanGun.ForeColor = System.Drawing.Color.Black;
            this.cmbKalanGun.FormattingEnabled = true;
            this.cmbKalanGun.Items.AddRange(new object[] {
            "<",
            "<=",
            "=",
            ">",
            ">="});
            this.cmbKalanGun.Location = new System.Drawing.Point(69, 13);
            this.cmbKalanGun.Name = "cmbKalanGun";
            this.cmbKalanGun.Size = new System.Drawing.Size(60, 21);
            this.cmbKalanGun.TabIndex = 19;
            this.cmbKalanGun.Tag = "001";
            this.cmbKalanGun.Text = "=";
            this.cmbKalanGun.SelectedIndexChanged += new System.EventHandler(this.btnSorgula_Click);
            // 
            // txtKalanGun
            // 
            this.txtKalanGun.BackColor = System.Drawing.Color.White;
            this.txtKalanGun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKalanGun.ForeColor = System.Drawing.Color.Black;
            this.txtKalanGun.Location = new System.Drawing.Point(129, 13);
            this.txtKalanGun.Name = "txtKalanGun";
            this.txtKalanGun.Size = new System.Drawing.Size(55, 21);
            this.txtKalanGun.TabIndex = 20;
            this.txtKalanGun.Tag = "011";
            this.txtKalanGun.TextChanged += new System.EventHandler(this.btnSorgula_Click);
            // 
            // chkBitenGorevleriGoster
            // 
            this.chkBitenGorevleriGoster.AutoSize = true;
            this.chkBitenGorevleriGoster.Location = new System.Drawing.Point(333, 118);
            this.chkBitenGorevleriGoster.Name = "chkBitenGorevleriGoster";
            this.chkBitenGorevleriGoster.Size = new System.Drawing.Size(129, 17);
            this.chkBitenGorevleriGoster.TabIndex = 51;
            this.chkBitenGorevleriGoster.Text = "Biten Görevleri Göster";
            this.chkBitenGorevleriGoster.UseVisualStyleBackColor = true;
            this.chkBitenGorevleriGoster.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Açıklama";
            // 
            // txtAciklama
            // 
            this.txtAciklama.BackColor = System.Drawing.Color.White;
            this.txtAciklama.ForeColor = System.Drawing.Color.Black;
            this.txtAciklama.Location = new System.Drawing.Point(74, 92);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(241, 20);
            this.txtAciklama.TabIndex = 18;
            this.txtAciklama.Tag = "001";
            this.txtAciklama.TextChanged += new System.EventHandler(this.btnSorgula_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Görev Tanımı";
            // 
            // txtGorevTanimi
            // 
            this.txtGorevTanimi.BackColor = System.Drawing.Color.White;
            this.txtGorevTanimi.ForeColor = System.Drawing.Color.Black;
            this.txtGorevTanimi.Location = new System.Drawing.Point(74, 69);
            this.txtGorevTanimi.Name = "txtGorevTanimi";
            this.txtGorevTanimi.Size = new System.Drawing.Size(241, 20);
            this.txtGorevTanimi.TabIndex = 17;
            this.txtGorevTanimi.Tag = "001";
            this.txtGorevTanimi.TextChanged += new System.EventHandler(this.btnSorgula_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Görev Adı";
            // 
            // txtGorevAdi
            // 
            this.txtGorevAdi.BackColor = System.Drawing.Color.White;
            this.txtGorevAdi.ForeColor = System.Drawing.Color.Black;
            this.txtGorevAdi.Location = new System.Drawing.Point(74, 46);
            this.txtGorevAdi.Name = "txtGorevAdi";
            this.txtGorevAdi.Size = new System.Drawing.Size(241, 20);
            this.txtGorevAdi.TabIndex = 16;
            this.txtGorevAdi.Tag = "001";
            this.txtGorevAdi.TextChanged += new System.EventHandler(this.btnSorgula_Click);
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
            this.cmbPersonelAdlari.TabIndex = 15;
            this.cmbPersonelAdlari.Tag = "001";
            this.cmbPersonelAdlari.SelectedIndexChanged += new System.EventHandler(this.btnSorgula_Click);
            // 
            // chkSilinenKayitlariGoster
            // 
            this.chkSilinenKayitlariGoster.AutoSize = true;
            this.chkSilinenKayitlariGoster.Location = new System.Drawing.Point(524, 118);
            this.chkSilinenKayitlariGoster.Name = "chkSilinenKayitlariGoster";
            this.chkSilinenKayitlariGoster.Size = new System.Drawing.Size(130, 17);
            this.chkSilinenKayitlariGoster.TabIndex = 15;
            this.chkSilinenKayitlariGoster.Text = "Silinen Kayıtları Göster";
            this.chkSilinenKayitlariGoster.UseVisualStyleBackColor = true;
            this.chkSilinenKayitlariGoster.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // grpİslemTarihi
            // 
            this.grpİslemTarihi.Controls.Add(this.dtBitisTarihi);
            this.grpİslemTarihi.Controls.Add(this.chkBitisTarihi);
            this.grpİslemTarihi.Controls.Add(this.dtBaslangictarihi);
            this.grpİslemTarihi.Controls.Add(this.chkBaslangicTarihi);
            this.grpİslemTarihi.Location = new System.Drawing.Point(325, 49);
            this.grpİslemTarihi.Name = "grpİslemTarihi";
            this.grpİslemTarihi.Size = new System.Drawing.Size(193, 62);
            this.grpİslemTarihi.TabIndex = 13;
            this.grpİslemTarihi.TabStop = false;
            // 
            // dtBitisTarihi
            // 
            this.dtBitisTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBitisTarihi.Location = new System.Drawing.Point(107, 36);
            this.dtBitisTarihi.Name = "dtBitisTarihi";
            this.dtBitisTarihi.Size = new System.Drawing.Size(77, 20);
            this.dtBitisTarihi.TabIndex = 13;
            this.dtBitisTarihi.ValueChanged += new System.EventHandler(this.btnSorgula_Click);
            // 
            // chkBitisTarihi
            // 
            this.chkBitisTarihi.AutoSize = true;
            this.chkBitisTarihi.Location = new System.Drawing.Point(8, 39);
            this.chkBitisTarihi.Name = "chkBitisTarihi";
            this.chkBitisTarihi.Size = new System.Drawing.Size(74, 17);
            this.chkBitisTarihi.TabIndex = 16;
            this.chkBitisTarihi.Text = "Bitiş Tarihi";
            this.chkBitisTarihi.UseVisualStyleBackColor = true;
            this.chkBitisTarihi.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // dtBaslangictarihi
            // 
            this.dtBaslangictarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBaslangictarihi.Location = new System.Drawing.Point(107, 14);
            this.dtBaslangictarihi.Name = "dtBaslangictarihi";
            this.dtBaslangictarihi.Size = new System.Drawing.Size(77, 20);
            this.dtBaslangictarihi.TabIndex = 3;
            this.dtBaslangictarihi.ValueChanged += new System.EventHandler(this.btnSorgula_Click);
            // 
            // chkBaslangicTarihi
            // 
            this.chkBaslangicTarihi.AutoSize = true;
            this.chkBaslangicTarihi.Location = new System.Drawing.Point(8, 17);
            this.chkBaslangicTarihi.Name = "chkBaslangicTarihi";
            this.chkBaslangicTarihi.Size = new System.Drawing.Size(101, 17);
            this.chkBaslangicTarihi.TabIndex = 12;
            this.chkBaslangicTarihi.Text = "Başlangıç Tarihi";
            this.chkBaslangicTarihi.UseVisualStyleBackColor = true;
            this.chkBaslangicTarihi.Click += new System.EventHandler(this.btnSorgula_Click);
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
            this.groupBox9.Controls.Add(this.label57);
            this.groupBox9.Controls.Add(this.label58);
            this.groupBox9.Location = new System.Drawing.Point(519, 49);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(186, 62);
            this.groupBox9.TabIndex = 14;
            this.groupBox9.TabStop = false;
            // 
            // cmbKullanicilar
            // 
            this.cmbKullanicilar.BackColor = System.Drawing.Color.White;
            this.cmbKullanicilar.ForeColor = System.Drawing.Color.Black;
            this.cmbKullanicilar.FormattingEnabled = true;
            this.cmbKullanicilar.Location = new System.Drawing.Point(46, 36);
            this.cmbKullanicilar.Name = "cmbKullanicilar";
            this.cmbKullanicilar.Size = new System.Drawing.Size(136, 21);
            this.cmbKullanicilar.TabIndex = 24;
            this.cmbKullanicilar.Tag = "001";
            this.cmbKullanicilar.SelectedIndexChanged += new System.EventHandler(this.btnSorgula_Click);
            // 
            // cmbSubeler
            // 
            this.cmbSubeler.BackColor = System.Drawing.Color.White;
            this.cmbSubeler.ForeColor = System.Drawing.Color.Black;
            this.cmbSubeler.FormattingEnabled = true;
            this.cmbSubeler.Location = new System.Drawing.Point(46, 13);
            this.cmbSubeler.Name = "cmbSubeler";
            this.cmbSubeler.Size = new System.Drawing.Size(136, 21);
            this.cmbSubeler.TabIndex = 23;
            this.cmbSubeler.Tag = "001";
            this.cmbSubeler.SelectedIndexChanged += new System.EventHandler(this.cmbSubeler_SelectedIndexChanged);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(2, 40);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-4, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(739, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "_________________________________________________________________________________" +
    "_________________________________________";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSil);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtPersonelAdi2);
            this.panel1.Controls.Add(this.txtSonlanmaSaati);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtBaslangicSaati);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.dtBaslangicTarihi2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtGorevTanimi2);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtGorevAdi2);
            this.panel1.Controls.Add(this.label73);
            this.panel1.Controls.Add(this.label77);
            this.panel1.Controls.Add(this.btnKaydet);
            this.panel1.Controls.Add(this.txtAciklama2);
            this.panel1.Controls.Add(this.dtBitisTarihi2);
            this.panel1.Controls.Add(this.label78);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(412, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 379);
            this.panel1.TabIndex = 2;
            this.panel1.TabStop = true;
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Image = global::Elmar_Ticari_Plus.Properties.Resources.Close_2_icon;
            this.btnSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSil.Location = new System.Drawing.Point(300, 338);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(81, 29);
            this.btnSil.TabIndex = 12;
            this.btnSil.Text = "Kaydı Sil";
            this.btnSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.ForeColor = System.Drawing.Color.DarkRed;
            this.label13.Location = new System.Drawing.Point(110, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(195, 16);
            this.label13.TabIndex = 157;
            this.label13.Text = "Seçili Görev Kaydına Ait Bilgiler";
            // 
            // txtPersonelAdi2
            // 
            this.txtPersonelAdi2.Location = new System.Drawing.Point(89, 41);
            this.txtPersonelAdi2.Name = "txtPersonelAdi2";
            this.txtPersonelAdi2.ReadOnly = true;
            this.txtPersonelAdi2.Size = new System.Drawing.Size(325, 20);
            this.txtPersonelAdi2.TabIndex = 4;
            // 
            // txtSonlanmaSaati
            // 
            this.txtSonlanmaSaati.BackColor = System.Drawing.Color.White;
            this.txtSonlanmaSaati.ForeColor = System.Drawing.Color.Black;
            this.txtSonlanmaSaati.Location = new System.Drawing.Point(379, 212);
            this.txtSonlanmaSaati.Mask = "90:00";
            this.txtSonlanmaSaati.Name = "txtSonlanmaSaati";
            this.txtSonlanmaSaati.Size = new System.Drawing.Size(35, 20);
            this.txtSonlanmaSaati.TabIndex = 9;
            this.txtSonlanmaSaati.Tag = "001";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(274, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 15);
            this.label8.TabIndex = 154;
            this.label8.Text = "Sonlanma Saati";
            // 
            // txtBaslangicSaati
            // 
            this.txtBaslangicSaati.BackColor = System.Drawing.Color.White;
            this.txtBaslangicSaati.ForeColor = System.Drawing.Color.Black;
            this.txtBaslangicSaati.Location = new System.Drawing.Point(379, 186);
            this.txtBaslangicSaati.Mask = "90:00";
            this.txtBaslangicSaati.Name = "txtBaslangicSaati";
            this.txtBaslangicSaati.Size = new System.Drawing.Size(35, 20);
            this.txtBaslangicSaati.TabIndex = 7;
            this.txtBaslangicSaati.Tag = "001";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(274, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 15);
            this.label9.TabIndex = 152;
            this.label9.Text = "Başlama Saati";
            // 
            // dtBaslangicTarihi2
            // 
            this.dtBaslangicTarihi2.Location = new System.Drawing.Point(89, 187);
            this.dtBaslangicTarihi2.Name = "dtBaslangicTarihi2";
            this.dtBaslangicTarihi2.Size = new System.Drawing.Size(177, 20);
            this.dtBaslangicTarihi2.TabIndex = 6;
            this.dtBaslangicTarihi2.Tag = "001";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1, 190);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 151;
            this.label10.Text = "Başlama Tarihi";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 149;
            this.label11.Text = "Görev Tanımı";
            // 
            // txtGorevTanimi2
            // 
            this.txtGorevTanimi2.BackColor = System.Drawing.Color.White;
            this.txtGorevTanimi2.ForeColor = System.Drawing.Color.Black;
            this.txtGorevTanimi2.Location = new System.Drawing.Point(89, 94);
            this.txtGorevTanimi2.MaxLength = 200;
            this.txtGorevTanimi2.Multiline = true;
            this.txtGorevTanimi2.Name = "txtGorevTanimi2";
            this.txtGorevTanimi2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGorevTanimi2.Size = new System.Drawing.Size(325, 87);
            this.txtGorevTanimi2.TabIndex = 5;
            this.txtGorevTanimi2.Tag = "001";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 147;
            this.label12.Text = "Görev Adı";
            // 
            // txtGorevAdi2
            // 
            this.txtGorevAdi2.BackColor = System.Drawing.Color.White;
            this.txtGorevAdi2.ForeColor = System.Drawing.Color.Black;
            this.txtGorevAdi2.Location = new System.Drawing.Point(89, 68);
            this.txtGorevAdi2.MaxLength = 50;
            this.txtGorevAdi2.Name = "txtGorevAdi2";
            this.txtGorevAdi2.Size = new System.Drawing.Size(325, 20);
            this.txtGorevAdi2.TabIndex = 4;
            this.txtGorevAdi2.Tag = "001";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(1, 43);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(84, 13);
            this.label73.TabIndex = 145;
            this.label73.Text = "Görevli Personel";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(1, 240);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(50, 13);
            this.label77.TabIndex = 143;
            this.label77.Text = "Açıklama";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(141, 338);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(155, 29);
            this.btnKaydet.TabIndex = 11;
            this.btnKaydet.Text = "Değişiklikleri Kaydet";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtAciklama2
            // 
            this.txtAciklama2.BackColor = System.Drawing.Color.White;
            this.txtAciklama2.ForeColor = System.Drawing.Color.Black;
            this.txtAciklama2.Location = new System.Drawing.Point(89, 239);
            this.txtAciklama2.MaxLength = 200;
            this.txtAciklama2.Multiline = true;
            this.txtAciklama2.Name = "txtAciklama2";
            this.txtAciklama2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAciklama2.Size = new System.Drawing.Size(325, 93);
            this.txtAciklama2.TabIndex = 10;
            this.txtAciklama2.Tag = "001";
            // 
            // dtBitisTarihi2
            // 
            this.dtBitisTarihi2.Location = new System.Drawing.Point(89, 213);
            this.dtBitisTarihi2.Name = "dtBitisTarihi2";
            this.dtBitisTarihi2.Size = new System.Drawing.Size(177, 20);
            this.dtBitisTarihi2.TabIndex = 8;
            this.dtBitisTarihi2.Tag = "001";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(1, 216);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(83, 13);
            this.label78.TabIndex = 144;
            this.label78.Text = "Sonlanma Tarihi";
            // 
            // frmPersonelGorevListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(831, 519);
            this.Controls.Add(this.dgGorevler);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlAlt);
            this.Name = "frmPersonelGorevListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Personel Görev Listesi";
            this.Load += new System.EventHandler(this.frmPersonelGorevListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgGorevler)).EndInit();
            this.pnlAlt.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpİslemTarihi.ResumeLayout(false);
            this.grpİslemTarihi.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAlt;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.Label lblKayitSayisi3;
        private System.Windows.Forms.Button btnYazdir;
        private System.Windows.Forms.Button btnRaporGoruntule;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.CheckBox chkSilinenKayitlariGoster;
        private System.Windows.Forms.GroupBox grpİslemTarihi;
        private System.Windows.Forms.DateTimePicker dtBaslangictarihi;
        private System.Windows.Forms.CheckBox chkBaslangicTarihi;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.ComboBox cmbKullanicilar;
        private System.Windows.Forms.ComboBox cmbSubeler;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPersonelAdlari;
        private System.Windows.Forms.CheckBox chkBitenGorevleriGoster;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGorevTanimi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGorevAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtBitisTarihi;
        private System.Windows.Forms.CheckBox chkBitisTarihi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKalanGun;
        private System.Windows.Forms.ComboBox cmbKalanGun;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbYorumSayisi;
        private System.Windows.Forms.TextBox txtYorumSayisi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPersonelAdi2;
        private System.Windows.Forms.MaskedTextBox txtSonlanmaSaati;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox txtBaslangicSaati;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtBaslangicTarihi2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtGorevTanimi2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtGorevAdi2;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.TextBox txtAciklama2;
        private System.Windows.Forms.DateTimePicker dtBitisTarihi2;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.DataGridView dgGorevler;
        private System.Windows.Forms.DataGridViewTextBoxColumn gorevid;
        private System.Windows.Forms.DataGridViewTextBoxColumn personelid;
        private System.Windows.Forms.DataGridViewTextBoxColumn personelAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn gorevAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn gorevTanimi;
        private System.Windows.Forms.DataGridViewTextBoxColumn gorevBaslangicTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn gorevBitisTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn baslangicSaati;
        private System.Windows.Forms.DataGridViewTextBoxColumn bitisSaati;
        private System.Windows.Forms.DataGridViewTextBoxColumn kalanGun;
        private System.Windows.Forms.DataGridViewButtonColumn yorumSayisi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gorevBittimi;
        private System.Windows.Forms.DataGridViewTextBoxColumn aciklama;
        private System.Windows.Forms.Button btnSil;
    }
}