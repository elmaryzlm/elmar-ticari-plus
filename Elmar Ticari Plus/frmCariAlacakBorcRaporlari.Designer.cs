namespace Elmar_Ticari_Plus
{
    partial class frmCariAlacakBorcRaporlari
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdArtanSiralama = new System.Windows.Forms.RadioButton();
            this.rdAzalanSiralama = new System.Windows.Forms.RadioButton();
            this.rdCarigrup = new System.Windows.Forms.RadioButton();
            this.rdCaritumu = new System.Windows.Forms.RadioButton();
            this.cmbCarigrubu = new System.Windows.Forms.ComboBox();
            this.pnlTarih = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.dtTarih2 = new System.Windows.Forms.DateTimePicker();
            this.dtTarih1 = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbSubeler = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdVadesiGecenler = new System.Windows.Forms.RadioButton();
            this.rdTarihAraligi = new System.Windows.Forms.RadioButton();
            this.rdTumu = new System.Windows.Forms.RadioButton();
            this.btnRaporla = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKullanici = new System.Windows.Forms.ComboBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.chkBakiyesiSifirOlanlar = new System.Windows.Forms.CheckBox();
            this.chkBorc = new System.Windows.Forms.CheckBox();
            this.chkAlacak = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkPasifCariler = new System.Windows.Forms.CheckBox();
            this.chkSilinenCariler = new System.Windows.Forms.CheckBox();
            this.txtBolge = new System.Windows.Forms.TextBox();
            this.btnBolgeSec = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            this.btnBolgeTemizle = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlTarih.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.rdCarigrup);
            this.panel2.Controls.Add(this.rdCaritumu);
            this.panel2.Controls.Add(this.cmbCarigrubu);
            this.panel2.Location = new System.Drawing.Point(9, 214);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(306, 81);
            this.panel2.TabIndex = 56;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rdArtanSiralama);
            this.panel4.Controls.Add(this.rdAzalanSiralama);
            this.panel4.Location = new System.Drawing.Point(86, 55);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(215, 19);
            this.panel4.TabIndex = 76;
            // 
            // rdArtanSiralama
            // 
            this.rdArtanSiralama.AutoSize = true;
            this.rdArtanSiralama.Checked = true;
            this.rdArtanSiralama.Location = new System.Drawing.Point(3, 3);
            this.rdArtanSiralama.Name = "rdArtanSiralama";
            this.rdArtanSiralama.Size = new System.Drawing.Size(93, 17);
            this.rdArtanSiralama.TabIndex = 74;
            this.rdArtanSiralama.TabStop = true;
            this.rdArtanSiralama.Text = "Artan Sıralama";
            this.rdArtanSiralama.UseVisualStyleBackColor = true;
            // 
            // rdAzalanSiralama
            // 
            this.rdAzalanSiralama.AutoSize = true;
            this.rdAzalanSiralama.Location = new System.Drawing.Point(102, 3);
            this.rdAzalanSiralama.Name = "rdAzalanSiralama";
            this.rdAzalanSiralama.Size = new System.Drawing.Size(100, 17);
            this.rdAzalanSiralama.TabIndex = 75;
            this.rdAzalanSiralama.Text = "Azalan Sıralama";
            this.rdAzalanSiralama.UseVisualStyleBackColor = true;
            // 
            // rdCarigrup
            // 
            this.rdCarigrup.AutoSize = true;
            this.rdCarigrup.Location = new System.Drawing.Point(4, 31);
            this.rdCarigrup.Name = "rdCarigrup";
            this.rdCarigrup.Size = new System.Drawing.Size(75, 17);
            this.rdCarigrup.TabIndex = 52;
            this.rdCarigrup.Text = "Cari Grubu";
            this.rdCarigrup.UseVisualStyleBackColor = true;
            this.rdCarigrup.CheckedChanged += new System.EventHandler(this.rdCaritumu_CheckedChanged);
            // 
            // rdCaritumu
            // 
            this.rdCaritumu.AutoSize = true;
            this.rdCaritumu.Checked = true;
            this.rdCaritumu.Location = new System.Drawing.Point(4, 7);
            this.rdCaritumu.Name = "rdCaritumu";
            this.rdCaritumu.Size = new System.Drawing.Size(78, 17);
            this.rdCaritumu.TabIndex = 50;
            this.rdCaritumu.TabStop = true;
            this.rdCaritumu.Text = "Tüm Cariler";
            this.rdCaritumu.UseVisualStyleBackColor = true;
            this.rdCaritumu.CheckedChanged += new System.EventHandler(this.rdCaritumu_CheckedChanged);
            // 
            // cmbCarigrubu
            // 
            this.cmbCarigrubu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCarigrubu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCarigrubu.BackColor = System.Drawing.Color.White;
            this.cmbCarigrubu.Enabled = false;
            this.cmbCarigrubu.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCarigrubu.ForeColor = System.Drawing.Color.Black;
            this.cmbCarigrubu.FormattingEnabled = true;
            this.cmbCarigrubu.Location = new System.Drawing.Point(87, 28);
            this.cmbCarigrubu.Name = "cmbCarigrubu";
            this.cmbCarigrubu.Size = new System.Drawing.Size(214, 22);
            this.cmbCarigrubu.TabIndex = 46;
            this.cmbCarigrubu.Tag = "001";
            // 
            // pnlTarih
            // 
            this.pnlTarih.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTarih.Controls.Add(this.label10);
            this.pnlTarih.Controls.Add(this.dtTarih2);
            this.pnlTarih.Controls.Add(this.dtTarih1);
            this.pnlTarih.Enabled = false;
            this.pnlTarih.Location = new System.Drawing.Point(106, 93);
            this.pnlTarih.Name = "pnlTarih";
            this.pnlTarih.Size = new System.Drawing.Size(209, 33);
            this.pnlTarih.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(96, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 16);
            this.label10.TabIndex = 27;
            this.label10.Text = "-";
            // 
            // dtTarih2
            // 
            this.dtTarih2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtTarih2.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtTarih2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTarih2.Location = new System.Drawing.Point(111, 5);
            this.dtTarih2.Name = "dtTarih2";
            this.dtTarih2.Size = new System.Drawing.Size(93, 20);
            this.dtTarih2.TabIndex = 26;
            // 
            // dtTarih1
            // 
            this.dtTarih1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtTarih1.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtTarih1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTarih1.Location = new System.Drawing.Point(3, 5);
            this.dtTarih1.Name = "dtTarih1";
            this.dtTarih1.Size = new System.Drawing.Size(93, 20);
            this.dtTarih1.TabIndex = 25;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(11, 350);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 13);
            this.label17.TabIndex = 36;
            this.label17.Text = "Şube";
            // 
            // cmbSubeler
            // 
            this.cmbSubeler.BackColor = System.Drawing.Color.White;
            this.cmbSubeler.ForeColor = System.Drawing.Color.Black;
            this.cmbSubeler.FormattingEnabled = true;
            this.cmbSubeler.Location = new System.Drawing.Point(58, 344);
            this.cmbSubeler.Name = "cmbSubeler";
            this.cmbSubeler.Size = new System.Drawing.Size(257, 21);
            this.cmbSubeler.TabIndex = 35;
            this.cmbSubeler.Tag = "001";
            this.cmbSubeler.Text = "Tümü";
            this.cmbSubeler.SelectedIndexChanged += new System.EventHandler(this.cmbSubeler_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdVadesiGecenler);
            this.panel1.Controls.Add(this.rdTarihAraligi);
            this.panel1.Controls.Add(this.rdTumu);
            this.panel1.Location = new System.Drawing.Point(9, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 75);
            this.panel1.TabIndex = 55;
            // 
            // rdVadesiGecenler
            // 
            this.rdVadesiGecenler.AutoSize = true;
            this.rdVadesiGecenler.Location = new System.Drawing.Point(0, 26);
            this.rdVadesiGecenler.Name = "rdVadesiGecenler";
            this.rdVadesiGecenler.Size = new System.Drawing.Size(103, 17);
            this.rdVadesiGecenler.TabIndex = 45;
            this.rdVadesiGecenler.Text = "Vadesi Geçenler";
            this.rdVadesiGecenler.UseVisualStyleBackColor = true;
            this.rdVadesiGecenler.CheckedChanged += new System.EventHandler(this.rdTumu_CheckedChanged);
            // 
            // rdTarihAraligi
            // 
            this.rdTarihAraligi.AutoSize = true;
            this.rdTarihAraligi.Location = new System.Drawing.Point(0, 50);
            this.rdTarihAraligi.Name = "rdTarihAraligi";
            this.rdTarihAraligi.Size = new System.Drawing.Size(80, 17);
            this.rdTarihAraligi.TabIndex = 44;
            this.rdTarihAraligi.Text = "Tarih Aralığı";
            this.rdTarihAraligi.UseVisualStyleBackColor = true;
            this.rdTarihAraligi.CheckedChanged += new System.EventHandler(this.rdTumu_CheckedChanged);
            // 
            // rdTumu
            // 
            this.rdTumu.AutoSize = true;
            this.rdTumu.Checked = true;
            this.rdTumu.Location = new System.Drawing.Point(0, 2);
            this.rdTumu.Name = "rdTumu";
            this.rdTumu.Size = new System.Drawing.Size(52, 17);
            this.rdTumu.TabIndex = 43;
            this.rdTumu.TabStop = true;
            this.rdTumu.Text = "Tümü";
            this.rdTumu.UseVisualStyleBackColor = true;
            this.rdTumu.CheckedChanged += new System.EventHandler(this.rdTumu_CheckedChanged);
            // 
            // btnRaporla
            // 
            this.btnRaporla.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporla.Image = global::Elmar_Ticari_Plus.Properties.Resources.tahsilatodeme;
            this.btnRaporla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRaporla.Location = new System.Drawing.Point(86, 396);
            this.btnRaporla.Name = "btnRaporla";
            this.btnRaporla.Size = new System.Drawing.Size(146, 41);
            this.btnRaporla.TabIndex = 42;
            this.btnRaporla.Text = "Raporu Görüntüle";
            this.btnRaporla.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRaporla.UseVisualStyleBackColor = false;
            this.btnRaporla.Click += new System.EventHandler(this.btnRaporla_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(319, 42);
            this.panel3.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(52, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Cari Alacak Borç Raporları";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::Elmar_Ticari_Plus.Properties.Resources.tahsilatodeme;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBolgeTemizle);
            this.groupBox1.Controls.Add(this.txtBolge);
            this.groupBox1.Controls.Add(this.btnBolgeSec);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbKullanici);
            this.groupBox1.Controls.Add(this.groupBox12);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.pnlTarih);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.cmbSubeler);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnRaporla);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 442);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sorgulama Seçenekleri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Kullanıcı";
            // 
            // cmbKullanici
            // 
            this.cmbKullanici.BackColor = System.Drawing.Color.White;
            this.cmbKullanici.ForeColor = System.Drawing.Color.Black;
            this.cmbKullanici.FormattingEnabled = true;
            this.cmbKullanici.Location = new System.Drawing.Point(58, 368);
            this.cmbKullanici.Name = "cmbKullanici";
            this.cmbKullanici.Size = new System.Drawing.Size(257, 21);
            this.cmbKullanici.TabIndex = 59;
            this.cmbKullanici.Tag = "001";
            this.cmbKullanici.Text = "Tümü";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.chkBakiyesiSifirOlanlar);
            this.groupBox12.Controls.Add(this.chkBorc);
            this.groupBox12.Controls.Add(this.chkAlacak);
            this.groupBox12.Location = new System.Drawing.Point(9, 148);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(137, 61);
            this.groupBox12.TabIndex = 58;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Durum";
            // 
            // chkBakiyesiSifirOlanlar
            // 
            this.chkBakiyesiSifirOlanlar.AutoSize = true;
            this.chkBakiyesiSifirOlanlar.Location = new System.Drawing.Point(6, 39);
            this.chkBakiyesiSifirOlanlar.Name = "chkBakiyesiSifirOlanlar";
            this.chkBakiyesiSifirOlanlar.Size = new System.Drawing.Size(121, 17);
            this.chkBakiyesiSifirOlanlar.TabIndex = 10;
            this.chkBakiyesiSifirOlanlar.Text = "Bakiyesi Sıfır Olanlar";
            this.chkBakiyesiSifirOlanlar.UseVisualStyleBackColor = true;
            // 
            // chkBorc
            // 
            this.chkBorc.AutoSize = true;
            this.chkBorc.Checked = true;
            this.chkBorc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBorc.Location = new System.Drawing.Point(77, 19);
            this.chkBorc.Name = "chkBorc";
            this.chkBorc.Size = new System.Drawing.Size(48, 17);
            this.chkBorc.TabIndex = 9;
            this.chkBorc.Text = "Borç";
            this.chkBorc.UseVisualStyleBackColor = true;
            // 
            // chkAlacak
            // 
            this.chkAlacak.AutoSize = true;
            this.chkAlacak.Checked = true;
            this.chkAlacak.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAlacak.Location = new System.Drawing.Point(6, 19);
            this.chkAlacak.Name = "chkAlacak";
            this.chkAlacak.Size = new System.Drawing.Size(59, 17);
            this.chkAlacak.TabIndex = 8;
            this.chkAlacak.Text = "Alacak";
            this.chkAlacak.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkPasifCariler);
            this.groupBox2.Controls.Add(this.chkSilinenCariler);
            this.groupBox2.Location = new System.Drawing.Point(178, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(102, 61);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            // 
            // chkPasifCariler
            // 
            this.chkPasifCariler.AutoSize = true;
            this.chkPasifCariler.Location = new System.Drawing.Point(6, 18);
            this.chkPasifCariler.Name = "chkPasifCariler";
            this.chkPasifCariler.Size = new System.Drawing.Size(81, 17);
            this.chkPasifCariler.TabIndex = 4;
            this.chkPasifCariler.Text = "Pasif Cariler";
            this.chkPasifCariler.UseVisualStyleBackColor = true;
            // 
            // chkSilinenCariler
            // 
            this.chkSilinenCariler.AutoSize = true;
            this.chkSilinenCariler.Location = new System.Drawing.Point(6, 35);
            this.chkSilinenCariler.Name = "chkSilinenCariler";
            this.chkSilinenCariler.Size = new System.Drawing.Size(89, 17);
            this.chkSilinenCariler.TabIndex = 5;
            this.chkSilinenCariler.Text = "Silinen Cariler";
            this.chkSilinenCariler.UseVisualStyleBackColor = true;
            // 
            // txtBolge
            // 
            this.txtBolge.Location = new System.Drawing.Point(58, 319);
            this.txtBolge.Name = "txtBolge";
            this.txtBolge.ReadOnly = true;
            this.txtBolge.Size = new System.Drawing.Size(207, 20);
            this.txtBolge.TabIndex = 63;
            this.txtBolge.Tag = "00";
            // 
            // btnBolgeSec
            // 
            this.btnBolgeSec.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnBolgeSec.Location = new System.Drawing.Point(266, 318);
            this.btnBolgeSec.Name = "btnBolgeSec";
            this.btnBolgeSec.Size = new System.Drawing.Size(24, 23);
            this.btnBolgeSec.TabIndex = 61;
            this.btnBolgeSec.Text = "...";
            this.btnBolgeSec.UseVisualStyleBackColor = false;
            this.btnBolgeSec.Click += new System.EventHandler(this.btnBolgeSec_Click);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(12, 325);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(34, 13);
            this.label39.TabIndex = 62;
            this.label39.Text = "Bölge";
            // 
            // btnBolgeTemizle
            // 
            this.btnBolgeTemizle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnBolgeTemizle.Image = global::Elmar_Ticari_Plus.Properties.Resources.page_remove_icon;
            this.btnBolgeTemizle.Location = new System.Drawing.Point(291, 318);
            this.btnBolgeTemizle.Name = "btnBolgeTemizle";
            this.btnBolgeTemizle.Size = new System.Drawing.Size(24, 23);
            this.btnBolgeTemizle.TabIndex = 64;
            this.btnBolgeTemizle.UseVisualStyleBackColor = false;
            this.btnBolgeTemizle.Click += new System.EventHandler(this.btnBolgeTemizle_Click);
            // 
            // frmCariAlacakBorcRaporlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 442);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCariAlacakBorcRaporlari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alacak Borç Raporları";
            this.Load += new System.EventHandler(this.frmCariAlacakBorcRaporlari_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlTarih.ResumeLayout(false);
            this.pnlTarih.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdArtanSiralama;
        private System.Windows.Forms.RadioButton rdAzalanSiralama;
        private System.Windows.Forms.RadioButton rdCarigrup;
        private System.Windows.Forms.RadioButton rdCaritumu;
        private System.Windows.Forms.ComboBox cmbCarigrubu;
        private System.Windows.Forms.Panel pnlTarih;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtTarih2;
        private System.Windows.Forms.DateTimePicker dtTarih1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbSubeler;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdVadesiGecenler;
        private System.Windows.Forms.RadioButton rdTarihAraligi;
        private System.Windows.Forms.RadioButton rdTumu;
        private System.Windows.Forms.Button btnRaporla;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKullanici;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.CheckBox chkBakiyesiSifirOlanlar;
        private System.Windows.Forms.CheckBox chkBorc;
        private System.Windows.Forms.CheckBox chkAlacak;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkPasifCariler;
        private System.Windows.Forms.CheckBox chkSilinenCariler;
        private System.Windows.Forms.Button btnBolgeTemizle;
        public System.Windows.Forms.TextBox txtBolge;
        private System.Windows.Forms.Button btnBolgeSec;
        private System.Windows.Forms.Label label39;
    }
}