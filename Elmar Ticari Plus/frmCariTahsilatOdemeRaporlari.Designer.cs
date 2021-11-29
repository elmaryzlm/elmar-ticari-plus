namespace Elmar_Ticari_Plus
{
    partial class frmCariTahsilatOdemeRaporlari
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
            this.rdTumtarihler = new System.Windows.Forms.RadioButton();
            this.rdCariadi = new System.Windows.Forms.RadioButton();
            this.rdCarigrup = new System.Windows.Forms.RadioButton();
            this.rdCaritumu = new System.Windows.Forms.RadioButton();
            this.cmbCarigrubu = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.chkEBorc = new System.Windows.Forms.CheckBox();
            this.chkEAlisiade = new System.Windows.Forms.CheckBox();
            this.chkEAlacak = new System.Windows.Forms.CheckBox();
            this.chkETahsilat = new System.Windows.Forms.CheckBox();
            this.chkESatisiade = new System.Windows.Forms.CheckBox();
            this.chkEOdeme = new System.Windows.Forms.CheckBox();
            this.chkEAlis = new System.Windows.Forms.CheckBox();
            this.chkESatis = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkEPos = new System.Windows.Forms.CheckBox();
            this.chkEKrediKarti = new System.Windows.Forms.CheckBox();
            this.chkESenet = new System.Windows.Forms.CheckBox();
            this.chkEPesin = new System.Windows.Forms.CheckBox();
            this.chkETaksit = new System.Windows.Forms.CheckBox();
            this.chkECek = new System.Windows.Forms.CheckBox();
            this.chkEAcikHesap = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdArtanSiralama = new System.Windows.Forms.RadioButton();
            this.rdAzalanSiralama = new System.Windows.Forms.RadioButton();
            this.cmbCariadi = new System.Windows.Forms.ComboBox();
            this.pnlTarih = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.dtTarih2 = new System.Windows.Forms.DateTimePicker();
            this.dtTarih1 = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbSubeler = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdTariharaligi = new System.Windows.Forms.RadioButton();
            this.btnRaporla = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkEEFT = new System.Windows.Forms.CheckBox();
            this.chkEHavale = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlTarih.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rdTumtarihler
            // 
            this.rdTumtarihler.AutoSize = true;
            this.rdTumtarihler.Checked = true;
            this.rdTumtarihler.Location = new System.Drawing.Point(1, 2);
            this.rdTumtarihler.Name = "rdTumtarihler";
            this.rdTumtarihler.Size = new System.Drawing.Size(80, 17);
            this.rdTumtarihler.TabIndex = 43;
            this.rdTumtarihler.TabStop = true;
            this.rdTumtarihler.Text = "Tüm tarihler";
            this.rdTumtarihler.UseVisualStyleBackColor = true;
            this.rdTumtarihler.CheckedChanged += new System.EventHandler(this.rdTumtarihler_CheckedChanged);
            // 
            // rdCariadi
            // 
            this.rdCariadi.AutoSize = true;
            this.rdCariadi.Location = new System.Drawing.Point(4, 56);
            this.rdCariadi.Name = "rdCariadi";
            this.rdCariadi.Size = new System.Drawing.Size(61, 17);
            this.rdCariadi.TabIndex = 53;
            this.rdCariadi.Text = "Cari Adı";
            this.rdCariadi.UseVisualStyleBackColor = true;
            this.rdCariadi.CheckedChanged += new System.EventHandler(this.rdCaritumu_CheckedChanged);
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
            this.cmbCarigrubu.Size = new System.Drawing.Size(261, 22);
            this.cmbCarigrubu.TabIndex = 46;
            this.cmbCarigrubu.Tag = "001";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox12);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.pnlTarih);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.cmbSubeler);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnRaporla);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 358);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sorgulama Seçenekleri";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.chkEEFT);
            this.groupBox12.Controls.Add(this.chkEHavale);
            this.groupBox12.Controls.Add(this.chkEBorc);
            this.groupBox12.Controls.Add(this.chkEAlisiade);
            this.groupBox12.Controls.Add(this.chkEAlacak);
            this.groupBox12.Controls.Add(this.chkETahsilat);
            this.groupBox12.Controls.Add(this.chkESatisiade);
            this.groupBox12.Controls.Add(this.chkEOdeme);
            this.groupBox12.Controls.Add(this.chkEAlis);
            this.groupBox12.Controls.Add(this.chkESatis);
            this.groupBox12.Location = new System.Drawing.Point(163, 75);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(147, 100);
            this.groupBox12.TabIndex = 58;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "İşlem Tipi-2";
            // 
            // chkEBorc
            // 
            this.chkEBorc.AutoSize = true;
            this.chkEBorc.Checked = true;
            this.chkEBorc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEBorc.Location = new System.Drawing.Point(77, 65);
            this.chkEBorc.Name = "chkEBorc";
            this.chkEBorc.Size = new System.Drawing.Size(48, 17);
            this.chkEBorc.TabIndex = 9;
            this.chkEBorc.Text = "Borç";
            this.chkEBorc.UseVisualStyleBackColor = true;
            // 
            // chkEAlisiade
            // 
            this.chkEAlisiade.AutoSize = true;
            this.chkEAlisiade.Checked = true;
            this.chkEAlisiade.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEAlisiade.Location = new System.Drawing.Point(77, 33);
            this.chkEAlisiade.Name = "chkEAlisiade";
            this.chkEAlisiade.Size = new System.Drawing.Size(66, 17);
            this.chkEAlisiade.TabIndex = 8;
            this.chkEAlisiade.Text = "Alış İade";
            this.chkEAlisiade.UseVisualStyleBackColor = true;
            // 
            // chkEAlacak
            // 
            this.chkEAlacak.AutoSize = true;
            this.chkEAlacak.Checked = true;
            this.chkEAlacak.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEAlacak.Location = new System.Drawing.Point(6, 65);
            this.chkEAlacak.Name = "chkEAlacak";
            this.chkEAlacak.Size = new System.Drawing.Size(59, 17);
            this.chkEAlacak.TabIndex = 8;
            this.chkEAlacak.Text = "Alacak";
            this.chkEAlacak.UseVisualStyleBackColor = true;
            // 
            // chkETahsilat
            // 
            this.chkETahsilat.AutoSize = true;
            this.chkETahsilat.Checked = true;
            this.chkETahsilat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkETahsilat.Location = new System.Drawing.Point(6, 49);
            this.chkETahsilat.Name = "chkETahsilat";
            this.chkETahsilat.Size = new System.Drawing.Size(63, 17);
            this.chkETahsilat.TabIndex = 4;
            this.chkETahsilat.Text = "Tahsilat";
            this.chkETahsilat.UseVisualStyleBackColor = true;
            // 
            // chkESatisiade
            // 
            this.chkESatisiade.AutoSize = true;
            this.chkESatisiade.Checked = true;
            this.chkESatisiade.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkESatisiade.Location = new System.Drawing.Point(6, 33);
            this.chkESatisiade.Name = "chkESatisiade";
            this.chkESatisiade.Size = new System.Drawing.Size(73, 17);
            this.chkESatisiade.TabIndex = 7;
            this.chkESatisiade.Text = "Satış İade";
            this.chkESatisiade.UseVisualStyleBackColor = true;
            // 
            // chkEOdeme
            // 
            this.chkEOdeme.AutoSize = true;
            this.chkEOdeme.Checked = true;
            this.chkEOdeme.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEOdeme.Location = new System.Drawing.Point(77, 49);
            this.chkEOdeme.Name = "chkEOdeme";
            this.chkEOdeme.Size = new System.Drawing.Size(60, 17);
            this.chkEOdeme.TabIndex = 5;
            this.chkEOdeme.Text = "Ödeme";
            this.chkEOdeme.UseVisualStyleBackColor = true;
            // 
            // chkEAlis
            // 
            this.chkEAlis.AutoSize = true;
            this.chkEAlis.Checked = true;
            this.chkEAlis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEAlis.Location = new System.Drawing.Point(77, 17);
            this.chkEAlis.Name = "chkEAlis";
            this.chkEAlis.Size = new System.Drawing.Size(42, 17);
            this.chkEAlis.TabIndex = 3;
            this.chkEAlis.Text = "Alış";
            this.chkEAlis.UseVisualStyleBackColor = true;
            // 
            // chkESatis
            // 
            this.chkESatis.AutoSize = true;
            this.chkESatis.Checked = true;
            this.chkESatis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkESatis.Location = new System.Drawing.Point(6, 17);
            this.chkESatis.Name = "chkESatis";
            this.chkESatis.Size = new System.Drawing.Size(49, 17);
            this.chkESatis.TabIndex = 2;
            this.chkESatis.Text = "Satış";
            this.chkESatis.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkEPos);
            this.groupBox2.Controls.Add(this.chkEKrediKarti);
            this.groupBox2.Controls.Add(this.chkESenet);
            this.groupBox2.Controls.Add(this.chkEPesin);
            this.groupBox2.Controls.Add(this.chkETaksit);
            this.groupBox2.Controls.Add(this.chkECek);
            this.groupBox2.Controls.Add(this.chkEAcikHesap);
            this.groupBox2.Location = new System.Drawing.Point(9, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 84);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "İşlem Tipi-1";
            // 
            // chkEPos
            // 
            this.chkEPos.AutoSize = true;
            this.chkEPos.Checked = true;
            this.chkEPos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEPos.Location = new System.Drawing.Point(76, 33);
            this.chkEPos.Name = "chkEPos";
            this.chkEPos.Size = new System.Drawing.Size(44, 17);
            this.chkEPos.TabIndex = 8;
            this.chkEPos.Text = "Pos";
            this.chkEPos.UseVisualStyleBackColor = true;
            // 
            // chkEKrediKarti
            // 
            this.chkEKrediKarti.AutoSize = true;
            this.chkEKrediKarti.Checked = true;
            this.chkEKrediKarti.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEKrediKarti.Location = new System.Drawing.Point(6, 33);
            this.chkEKrediKarti.Name = "chkEKrediKarti";
            this.chkEKrediKarti.Size = new System.Drawing.Size(74, 17);
            this.chkEKrediKarti.TabIndex = 3;
            this.chkEKrediKarti.Text = "Kredi Kartı";
            this.chkEKrediKarti.UseVisualStyleBackColor = true;
            // 
            // chkESenet
            // 
            this.chkESenet.AutoSize = true;
            this.chkESenet.Checked = true;
            this.chkESenet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkESenet.Location = new System.Drawing.Point(6, 65);
            this.chkESenet.Name = "chkESenet";
            this.chkESenet.Size = new System.Drawing.Size(54, 17);
            this.chkESenet.TabIndex = 7;
            this.chkESenet.Text = "Senet";
            this.chkESenet.UseVisualStyleBackColor = true;
            // 
            // chkEPesin
            // 
            this.chkEPesin.AutoSize = true;
            this.chkEPesin.Checked = true;
            this.chkEPesin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEPesin.Location = new System.Drawing.Point(6, 17);
            this.chkEPesin.Name = "chkEPesin";
            this.chkEPesin.Size = new System.Drawing.Size(52, 17);
            this.chkEPesin.TabIndex = 2;
            this.chkEPesin.Text = "Peşin";
            this.chkEPesin.UseVisualStyleBackColor = true;
            // 
            // chkETaksit
            // 
            this.chkETaksit.AutoSize = true;
            this.chkETaksit.Checked = true;
            this.chkETaksit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkETaksit.Location = new System.Drawing.Point(6, 49);
            this.chkETaksit.Name = "chkETaksit";
            this.chkETaksit.Size = new System.Drawing.Size(55, 17);
            this.chkETaksit.TabIndex = 5;
            this.chkETaksit.Text = "Taksit";
            this.chkETaksit.UseVisualStyleBackColor = true;
            // 
            // chkECek
            // 
            this.chkECek.AutoSize = true;
            this.chkECek.Checked = true;
            this.chkECek.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkECek.Location = new System.Drawing.Point(76, 49);
            this.chkECek.Name = "chkECek";
            this.chkECek.Size = new System.Drawing.Size(45, 17);
            this.chkECek.TabIndex = 6;
            this.chkECek.Text = "Çek";
            this.chkECek.UseVisualStyleBackColor = true;
            // 
            // chkEAcikHesap
            // 
            this.chkEAcikHesap.AutoSize = true;
            this.chkEAcikHesap.Checked = true;
            this.chkEAcikHesap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEAcikHesap.Location = new System.Drawing.Point(76, 17);
            this.chkEAcikHesap.Name = "chkEAcikHesap";
            this.chkEAcikHesap.Size = new System.Drawing.Size(72, 17);
            this.chkEAcikHesap.TabIndex = 4;
            this.chkEAcikHesap.Text = "Açık Hsp.";
            this.chkEAcikHesap.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.rdCariadi);
            this.panel2.Controls.Add(this.rdCarigrup);
            this.panel2.Controls.Add(this.rdCaritumu);
            this.panel2.Controls.Add(this.cmbCarigrubu);
            this.panel2.Controls.Add(this.cmbCariadi);
            this.panel2.Location = new System.Drawing.Point(5, 206);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(356, 105);
            this.panel2.TabIndex = 56;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rdArtanSiralama);
            this.panel4.Controls.Add(this.rdAzalanSiralama);
            this.panel4.Location = new System.Drawing.Point(86, 78);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(262, 19);
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
            // cmbCariadi
            // 
            this.cmbCariadi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCariadi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCariadi.BackColor = System.Drawing.Color.White;
            this.cmbCariadi.Enabled = false;
            this.cmbCariadi.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCariadi.ForeColor = System.Drawing.Color.Black;
            this.cmbCariadi.FormattingEnabled = true;
            this.cmbCariadi.Location = new System.Drawing.Point(87, 53);
            this.cmbCariadi.Name = "cmbCariadi";
            this.cmbCariadi.Size = new System.Drawing.Size(261, 22);
            this.cmbCariadi.TabIndex = 37;
            this.cmbCariadi.Tag = "001";
            // 
            // pnlTarih
            // 
            this.pnlTarih.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTarih.Controls.Add(this.label10);
            this.pnlTarih.Controls.Add(this.dtTarih2);
            this.pnlTarih.Controls.Add(this.dtTarih1);
            this.pnlTarih.Enabled = false;
            this.pnlTarih.Location = new System.Drawing.Point(91, 40);
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
            this.label17.Location = new System.Drawing.Point(26, 185);
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
            this.cmbSubeler.Location = new System.Drawing.Point(92, 179);
            this.cmbSubeler.Name = "cmbSubeler";
            this.cmbSubeler.Size = new System.Drawing.Size(218, 21);
            this.cmbSubeler.TabIndex = 35;
            this.cmbSubeler.Tag = "001";
            this.cmbSubeler.Text = "Tümü";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdTariharaligi);
            this.panel1.Controls.Add(this.rdTumtarihler);
            this.panel1.Location = new System.Drawing.Point(9, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(85, 55);
            this.panel1.TabIndex = 55;
            // 
            // rdTariharaligi
            // 
            this.rdTariharaligi.AutoSize = true;
            this.rdTariharaligi.Location = new System.Drawing.Point(1, 32);
            this.rdTariharaligi.Name = "rdTariharaligi";
            this.rdTariharaligi.Size = new System.Drawing.Size(80, 17);
            this.rdTariharaligi.TabIndex = 44;
            this.rdTariharaligi.Text = "Tarih Aralığı";
            this.rdTariharaligi.UseVisualStyleBackColor = true;
            this.rdTariharaligi.CheckedChanged += new System.EventHandler(this.rdTumtarihler_CheckedChanged);
            // 
            // btnRaporla
            // 
            this.btnRaporla.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporla.Image = global::Elmar_Ticari_Plus.Properties.Resources.tahsilatodeme;
            this.btnRaporla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRaporla.Location = new System.Drawing.Point(112, 314);
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
            this.panel3.Size = new System.Drawing.Size(363, 42);
            this.panel3.TabIndex = 75;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(52, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Cari Tahsilat - Ödeme Raporu";
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
            // chkEEFT
            // 
            this.chkEEFT.AutoSize = true;
            this.chkEEFT.Checked = true;
            this.chkEEFT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEEFT.Location = new System.Drawing.Point(77, 81);
            this.chkEEFT.Name = "chkEEFT";
            this.chkEEFT.Size = new System.Drawing.Size(46, 17);
            this.chkEEFT.TabIndex = 13;
            this.chkEEFT.Text = "EFT";
            this.chkEEFT.UseVisualStyleBackColor = true;
            // 
            // chkEHavale
            // 
            this.chkEHavale.AutoSize = true;
            this.chkEHavale.Checked = true;
            this.chkEHavale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEHavale.Location = new System.Drawing.Point(6, 81);
            this.chkEHavale.Name = "chkEHavale";
            this.chkEHavale.Size = new System.Drawing.Size(60, 17);
            this.chkEHavale.TabIndex = 14;
            this.chkEHavale.Text = "Havale";
            this.chkEHavale.UseVisualStyleBackColor = true;
            // 
            // frmCariTahsilatOdemeRaporlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 400);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Name = "frmCariTahsilatOdemeRaporlari";
            this.Text = "Tahsilat - Ödeme Raporu";
            this.Load += new System.EventHandler(this.frmCariTahsilatOdemeRaporlari_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdTumtarihler;
        private System.Windows.Forms.RadioButton rdCariadi;
        private System.Windows.Forms.RadioButton rdCarigrup;
        private System.Windows.Forms.RadioButton rdCaritumu;
        private System.Windows.Forms.ComboBox cmbCarigrubu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbCariadi;
        private System.Windows.Forms.Panel pnlTarih;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtTarih2;
        private System.Windows.Forms.DateTimePicker dtTarih1;
        private System.Windows.Forms.Button btnRaporla;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbSubeler;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdTariharaligi;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.CheckBox chkEBorc;
        private System.Windows.Forms.CheckBox chkEAlacak;
        private System.Windows.Forms.CheckBox chkEOdeme;
        private System.Windows.Forms.CheckBox chkETahsilat;
        private System.Windows.Forms.CheckBox chkESatisiade;
        private System.Windows.Forms.CheckBox chkEAlis;
        private System.Windows.Forms.CheckBox chkESatis;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkEKrediKarti;
        private System.Windows.Forms.CheckBox chkESenet;
        private System.Windows.Forms.CheckBox chkEPesin;
        private System.Windows.Forms.CheckBox chkECek;
        private System.Windows.Forms.CheckBox chkEAcikHesap;
        private System.Windows.Forms.CheckBox chkETaksit;
        private System.Windows.Forms.RadioButton rdAzalanSiralama;
        private System.Windows.Forms.RadioButton rdArtanSiralama;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chkEAlisiade;
        private System.Windows.Forms.CheckBox chkEPos;
        private System.Windows.Forms.CheckBox chkEEFT;
        private System.Windows.Forms.CheckBox chkEHavale;
    }
}