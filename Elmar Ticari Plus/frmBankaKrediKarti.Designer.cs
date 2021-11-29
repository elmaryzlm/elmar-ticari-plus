namespace Elmar_Ticari_Plus
{
    partial class frmBankaKrediKarti
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
            this.chkSilinenKayitlariGoster = new System.Windows.Forms.CheckBox();
            this.label54 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtKartLimiti = new System.Windows.Forms.TextBox();
            this.cmbKartLimiti = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSonOdemeGunu = new System.Windows.Forms.NumericUpDown();
            this.txtHesapKesim = new System.Windows.Forms.NumericUpDown();
            this.cmbSonOdemeGunu = new System.Windows.Forms.ComboBox();
            this.cmbHesapKesim = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.pnlAlt = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label70 = new System.Windows.Forms.Label();
            this.btnKrediKartiEkle = new System.Windows.Forms.Button();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.lblKayitSayisi3 = new System.Windows.Forms.Label();
            this.btnRaporGoruntule = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAyrinti = new System.Windows.Forms.TextBox();
            this.txtBankaHesapAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yeniBankaTanımlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silmeİşleminiGeriAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.raporGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgBankaKrediKarti = new System.Windows.Forms.DataGridView();
            this.krediKartid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankaHesapid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankaHesapAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankaAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hesapKesim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sonOdeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kartLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ayrinti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSonOdemeGunu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapKesim)).BeginInit();
            this.pnlAlt.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel12.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBankaKrediKarti)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSilinenKayitlariGoster
            // 
            this.chkSilinenKayitlariGoster.AutoSize = true;
            this.chkSilinenKayitlariGoster.Location = new System.Drawing.Point(307, 55);
            this.chkSilinenKayitlariGoster.Name = "chkSilinenKayitlariGoster";
            this.chkSilinenKayitlariGoster.Size = new System.Drawing.Size(97, 17);
            this.chkSilinenKayitlariGoster.TabIndex = 15;
            this.chkSilinenKayitlariGoster.Text = "Silinmiş Kayıtlar";
            this.chkSilinenKayitlariGoster.UseVisualStyleBackColor = true;
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.White;
            this.label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label54.Dock = System.Windows.Forms.DockStyle.Top;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label54.Location = new System.Drawing.Point(0, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(632, 17);
            this.label54.TabIndex = 0;
            this.label54.Text = "Filtre Seçenekleri";
            this.label54.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtKartLimiti);
            this.groupBox9.Controls.Add(this.cmbKartLimiti);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.txtSonOdemeGunu);
            this.groupBox9.Controls.Add(this.txtHesapKesim);
            this.groupBox9.Controls.Add(this.cmbSonOdemeGunu);
            this.groupBox9.Controls.Add(this.cmbHesapKesim);
            this.groupBox9.Controls.Add(this.label4);
            this.groupBox9.Controls.Add(this.label58);
            this.groupBox9.Location = new System.Drawing.Point(421, 21);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(208, 83);
            this.groupBox9.TabIndex = 14;
            this.groupBox9.TabStop = false;
            // 
            // txtKartLimiti
            // 
            this.txtKartLimiti.BackColor = System.Drawing.Color.White;
            this.txtKartLimiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKartLimiti.ForeColor = System.Drawing.Color.Black;
            this.txtKartLimiti.Location = new System.Drawing.Point(144, 58);
            this.txtKartLimiti.Name = "txtKartLimiti";
            this.txtKartLimiti.Size = new System.Drawing.Size(58, 22);
            this.txtKartLimiti.TabIndex = 16;
            this.txtKartLimiti.Tag = "221";
            this.txtKartLimiti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbKartLimiti
            // 
            this.cmbKartLimiti.BackColor = System.Drawing.Color.White;
            this.cmbKartLimiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbKartLimiti.ForeColor = System.Drawing.Color.Black;
            this.cmbKartLimiti.FormattingEnabled = true;
            this.cmbKartLimiti.Items.AddRange(new object[] {
            "=",
            "!=",
            "<",
            ">",
            "<=",
            ">="});
            this.cmbKartLimiti.Location = new System.Drawing.Point(102, 58);
            this.cmbKartLimiti.Name = "cmbKartLimiti";
            this.cmbKartLimiti.Size = new System.Drawing.Size(41, 23);
            this.cmbKartLimiti.TabIndex = 15;
            this.cmbKartLimiti.Tag = "001";
            this.cmbKartLimiti.Text = ">=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Kart Limiti";
            // 
            // txtSonOdemeGunu
            // 
            this.txtSonOdemeGunu.BackColor = System.Drawing.Color.White;
            this.txtSonOdemeGunu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSonOdemeGunu.ForeColor = System.Drawing.Color.Black;
            this.txtSonOdemeGunu.Location = new System.Drawing.Point(144, 34);
            this.txtSonOdemeGunu.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.txtSonOdemeGunu.Name = "txtSonOdemeGunu";
            this.txtSonOdemeGunu.Size = new System.Drawing.Size(58, 22);
            this.txtSonOdemeGunu.TabIndex = 13;
            this.txtSonOdemeGunu.Tag = "001";
            // 
            // txtHesapKesim
            // 
            this.txtHesapKesim.BackColor = System.Drawing.Color.White;
            this.txtHesapKesim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtHesapKesim.ForeColor = System.Drawing.Color.Black;
            this.txtHesapKesim.Location = new System.Drawing.Point(144, 10);
            this.txtHesapKesim.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.txtHesapKesim.Name = "txtHesapKesim";
            this.txtHesapKesim.Size = new System.Drawing.Size(58, 22);
            this.txtHesapKesim.TabIndex = 12;
            this.txtHesapKesim.Tag = "001";
            // 
            // cmbSonOdemeGunu
            // 
            this.cmbSonOdemeGunu.BackColor = System.Drawing.Color.White;
            this.cmbSonOdemeGunu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbSonOdemeGunu.ForeColor = System.Drawing.Color.Black;
            this.cmbSonOdemeGunu.FormattingEnabled = true;
            this.cmbSonOdemeGunu.Items.AddRange(new object[] {
            "=",
            "!=",
            "<",
            ">",
            "<=",
            ">="});
            this.cmbSonOdemeGunu.Location = new System.Drawing.Point(102, 34);
            this.cmbSonOdemeGunu.Name = "cmbSonOdemeGunu";
            this.cmbSonOdemeGunu.Size = new System.Drawing.Size(41, 23);
            this.cmbSonOdemeGunu.TabIndex = 11;
            this.cmbSonOdemeGunu.Tag = "001";
            this.cmbSonOdemeGunu.Text = ">=";
            // 
            // cmbHesapKesim
            // 
            this.cmbHesapKesim.BackColor = System.Drawing.Color.White;
            this.cmbHesapKesim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbHesapKesim.ForeColor = System.Drawing.Color.Black;
            this.cmbHesapKesim.FormattingEnabled = true;
            this.cmbHesapKesim.Items.AddRange(new object[] {
            "=",
            "!=",
            "<",
            ">",
            "<=",
            ">="});
            this.cmbHesapKesim.Location = new System.Drawing.Point(102, 9);
            this.cmbHesapKesim.Name = "cmbHesapKesim";
            this.cmbHesapKesim.Size = new System.Drawing.Size(41, 23);
            this.cmbHesapKesim.TabIndex = 8;
            this.cmbHesapKesim.Tag = "001";
            this.cmbHesapKesim.Text = ">=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Son Ödeme Günü";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(6, 13);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(98, 13);
            this.label58.TabIndex = 1;
            this.label58.Text = "Hesap Kesim Günü";
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
            this.pnlAlt.Size = new System.Drawing.Size(808, 112);
            this.pnlAlt.TabIndex = 13;
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.label70);
            this.panel16.Controls.Add(this.btnKrediKartiEkle);
            this.panel16.Controls.Add(this.btnSorgula);
            this.panel16.Controls.Add(this.lblKayitSayisi3);
            this.panel16.Controls.Add(this.btnRaporGoruntule);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(634, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(102, 110);
            this.panel16.TabIndex = 15;
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
            // btnKrediKartiEkle
            // 
            this.btnKrediKartiEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKrediKartiEkle.Image = global::Elmar_Ticari_Plus.Properties.Resources.genelEkle;
            this.btnKrediKartiEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKrediKartiEkle.Location = new System.Drawing.Point(3, 64);
            this.btnKrediKartiEkle.Name = "btnKrediKartiEkle";
            this.btnKrediKartiEkle.Size = new System.Drawing.Size(95, 23);
            this.btnKrediKartiEkle.TabIndex = 53;
            this.btnKrediKartiEkle.Text = "Yeni K.Kartı";
            this.btnKrediKartiEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKrediKartiEkle.UseVisualStyleBackColor = false;
            this.btnKrediKartiEkle.Click += new System.EventHandler(this.btnKrediKartiEkle_Click);
            // 
            // btnSorgula
            // 
            this.btnSorgula.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSorgula.Location = new System.Drawing.Point(3, 20);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(95, 23);
            this.btnSorgula.TabIndex = 52;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = false;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // lblKayitSayisi3
            // 
            this.lblKayitSayisi3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblKayitSayisi3.ForeColor = System.Drawing.Color.DarkRed;
            this.lblKayitSayisi3.Location = new System.Drawing.Point(0, 93);
            this.lblKayitSayisi3.Name = "lblKayitSayisi3";
            this.lblKayitSayisi3.Size = new System.Drawing.Size(100, 15);
            this.lblKayitSayisi3.TabIndex = 51;
            this.lblKayitSayisi3.Text = "Kayıt Sayısı:";
            // 
            // btnRaporGoruntule
            // 
            this.btnRaporGoruntule.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRaporGoruntule.Location = new System.Drawing.Point(3, 42);
            this.btnRaporGoruntule.Name = "btnRaporGoruntule";
            this.btnRaporGoruntule.Size = new System.Drawing.Size(95, 23);
            this.btnRaporGoruntule.TabIndex = 47;
            this.btnRaporGoruntule.Text = "Rapor Görüntüle";
            this.btnRaporGoruntule.UseVisualStyleBackColor = false;
            this.btnRaporGoruntule.Click += new System.EventHandler(this.btnRaporGoruntule_Click);
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.label54);
            this.panel12.Controls.Add(this.groupBox1);
            this.panel12.Controls.Add(this.groupBox9);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(634, 110);
            this.panel12.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAyrinti);
            this.groupBox1.Controls.Add(this.txtBankaHesapAdi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkSilinenKayitlariGoster);
            this.groupBox1.Location = new System.Drawing.Point(10, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 73);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // txtAyrinti
            // 
            this.txtAyrinti.BackColor = System.Drawing.Color.White;
            this.txtAyrinti.ForeColor = System.Drawing.Color.Black;
            this.txtAyrinti.Location = new System.Drawing.Point(97, 33);
            this.txtAyrinti.Name = "txtAyrinti";
            this.txtAyrinti.Size = new System.Drawing.Size(307, 20);
            this.txtAyrinti.TabIndex = 7;
            this.txtAyrinti.Tag = "001";
            // 
            // txtBankaHesapAdi
            // 
            this.txtBankaHesapAdi.BackColor = System.Drawing.Color.White;
            this.txtBankaHesapAdi.ForeColor = System.Drawing.Color.Black;
            this.txtBankaHesapAdi.Location = new System.Drawing.Point(97, 10);
            this.txtBankaHesapAdi.Name = "txtBankaHesapAdi";
            this.txtBankaHesapAdi.Size = new System.Drawing.Size(307, 20);
            this.txtBankaHesapAdi.TabIndex = 6;
            this.txtBankaHesapAdi.Tag = "001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ayrıntı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Banka-Hesap Adı";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniBankaTanımlaToolStripMenuItem,
            this.toolStripSeparator1,
            this.düzenleToolStripMenuItem,
            this.silToolStripMenuItem,
            this.silmeİşleminiGeriAlToolStripMenuItem,
            this.toolStripSeparator2,
            this.raporGörüntüleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(201, 126);
            // 
            // yeniBankaTanımlaToolStripMenuItem
            // 
            this.yeniBankaTanımlaToolStripMenuItem.Name = "yeniBankaTanımlaToolStripMenuItem";
            this.yeniBankaTanımlaToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.yeniBankaTanımlaToolStripMenuItem.Text = "Yeni Kredi Kartı Tanımla";
            this.yeniBankaTanımlaToolStripMenuItem.Click += new System.EventHandler(this.yeniBankaTanımlaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(197, 6);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // silmeİşleminiGeriAlToolStripMenuItem
            // 
            this.silmeİşleminiGeriAlToolStripMenuItem.Name = "silmeİşleminiGeriAlToolStripMenuItem";
            this.silmeİşleminiGeriAlToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.silmeİşleminiGeriAlToolStripMenuItem.Text = "Silme İşlemini Geri Al";
            this.silmeİşleminiGeriAlToolStripMenuItem.Click += new System.EventHandler(this.silmeİşleminiGeriAlToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
            // 
            // raporGörüntüleToolStripMenuItem
            // 
            this.raporGörüntüleToolStripMenuItem.Name = "raporGörüntüleToolStripMenuItem";
            this.raporGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.raporGörüntüleToolStripMenuItem.Text = "Rapor Görüntüle";
            this.raporGörüntüleToolStripMenuItem.Click += new System.EventHandler(this.raporGörüntüleToolStripMenuItem_Click);
            // 
            // dgBankaKrediKarti
            // 
            this.dgBankaKrediKarti.AllowUserToAddRows = false;
            this.dgBankaKrediKarti.AllowUserToDeleteRows = false;
            this.dgBankaKrediKarti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgBankaKrediKarti.ColumnHeadersHeight = 20;
            this.dgBankaKrediKarti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgBankaKrediKarti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.krediKartid,
            this.bankaHesapid,
            this.bankaHesapAdi,
            this.bankaAdi,
            this.hesapKesim,
            this.sonOdeme,
            this.kartLimit,
            this.ayrinti});
            this.dgBankaKrediKarti.ContextMenuStrip = this.contextMenuStrip1;
            this.dgBankaKrediKarti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBankaKrediKarti.Location = new System.Drawing.Point(0, 0);
            this.dgBankaKrediKarti.MultiSelect = false;
            this.dgBankaKrediKarti.Name = "dgBankaKrediKarti";
            this.dgBankaKrediKarti.ReadOnly = true;
            this.dgBankaKrediKarti.RowHeadersWidth = 20;
            this.dgBankaKrediKarti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBankaKrediKarti.Size = new System.Drawing.Size(808, 508);
            this.dgBankaKrediKarti.TabIndex = 12;
            // 
            // krediKartid
            // 
            this.krediKartid.HeaderText = "krediKartid";
            this.krediKartid.Name = "krediKartid";
            this.krediKartid.ReadOnly = true;
            this.krediKartid.Visible = false;
            this.krediKartid.Width = 82;
            // 
            // bankaHesapid
            // 
            this.bankaHesapid.HeaderText = "bankaHesapid";
            this.bankaHesapid.Name = "bankaHesapid";
            this.bankaHesapid.ReadOnly = true;
            this.bankaHesapid.Visible = false;
            this.bankaHesapid.Width = 101;
            // 
            // bankaHesapAdi
            // 
            this.bankaHesapAdi.HeaderText = "bankaHesapAdi";
            this.bankaHesapAdi.Name = "bankaHesapAdi";
            this.bankaHesapAdi.ReadOnly = true;
            this.bankaHesapAdi.Visible = false;
            this.bankaHesapAdi.Width = 108;
            // 
            // bankaAdi
            // 
            this.bankaAdi.HeaderText = "Banka-Hesap Adı";
            this.bankaAdi.Name = "bankaAdi";
            this.bankaAdi.ReadOnly = true;
            this.bankaAdi.Width = 115;
            // 
            // hesapKesim
            // 
            this.hesapKesim.HeaderText = "H.Kesim Günü";
            this.hesapKesim.Name = "hesapKesim";
            this.hesapKesim.ReadOnly = true;
            // 
            // sonOdeme
            // 
            this.sonOdeme.HeaderText = "Son Ödeme Günü";
            this.sonOdeme.Name = "sonOdeme";
            this.sonOdeme.ReadOnly = true;
            this.sonOdeme.Width = 117;
            // 
            // kartLimit
            // 
            this.kartLimit.HeaderText = "Kart Litimi";
            this.kartLimit.Name = "kartLimit";
            this.kartLimit.ReadOnly = true;
            this.kartLimit.Width = 77;
            // 
            // ayrinti
            // 
            this.ayrinti.HeaderText = "Ayrıntı";
            this.ayrinti.Name = "ayrinti";
            this.ayrinti.ReadOnly = true;
            this.ayrinti.Width = 60;
            // 
            // frmBankaKrediKarti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 508);
            this.Controls.Add(this.pnlAlt);
            this.Controls.Add(this.dgBankaKrediKarti);
            this.Name = "frmBankaKrediKarti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Kredi Kartlarım";
            this.Load += new System.EventHandler(this.frmBankaKrediKarti_Load);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSonOdemeGunu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapKesim)).EndInit();
            this.pnlAlt.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBankaKrediKarti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSilinenKayitlariGoster;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Panel pnlAlt;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button btnKrediKartiEkle;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.Label lblKayitSayisi3;
        private System.Windows.Forms.Button btnRaporGoruntule;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAyrinti;
        private System.Windows.Forms.TextBox txtBankaHesapAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yeniBankaTanımlaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silmeİşleminiGeriAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem raporGörüntüleToolStripMenuItem;
        public System.Windows.Forms.DataGridView dgBankaKrediKarti;
        private System.Windows.Forms.ComboBox cmbHesapKesim;
        private System.Windows.Forms.NumericUpDown txtSonOdemeGunu;
        private System.Windows.Forms.NumericUpDown txtHesapKesim;
        private System.Windows.Forms.ComboBox cmbSonOdemeGunu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKartLimiti;
        private System.Windows.Forms.ComboBox cmbKartLimiti;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn krediKartid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankaHesapid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankaHesapAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankaAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn hesapKesim;
        private System.Windows.Forms.DataGridViewTextBoxColumn sonOdeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn kartLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ayrinti;
    }
}