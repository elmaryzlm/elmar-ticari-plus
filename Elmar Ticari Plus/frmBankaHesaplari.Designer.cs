namespace Elmar_Ticari_Plus
{
    partial class frmBankaHesaplari
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
            this.btnSorgula = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label54 = new System.Windows.Forms.Label();
            this.grpHesapTuru = new System.Windows.Forms.GroupBox();
            this.rdCariHesaplarim = new System.Windows.Forms.RadioButton();
            this.rdKendiHesaplarim = new System.Windows.Forms.RadioButton();
            this.rdTumu = new System.Windows.Forms.RadioButton();
            this.grpBelgeNumarası = new System.Windows.Forms.GroupBox();
            this.txtAyrinti = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtiban = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSilinenKayitlariGoster = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtBankaAdi = new System.Windows.Forms.ComboBox();
            this.txtHesapNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHesapAdi = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.btnHesapEkle = new System.Windows.Forms.Button();
            this.lblKayitSayisi3 = new System.Windows.Forms.Label();
            this.dgBankaHesaplari = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yeniBankaTanımlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silmeİşleminiGeriAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.raporGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label70 = new System.Windows.Forms.Label();
            this.btnRaporGoruntule = new System.Windows.Forms.Button();
            this.pnlAlt = new System.Windows.Forms.Panel();
            this.bankaHesapid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankaAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hesapAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hesapNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cariid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cariAdiSoyadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hesapTuru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ayrinti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel12.SuspendLayout();
            this.grpHesapTuru.SuspendLayout();
            this.grpBelgeNumarası.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBankaHesaplari)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel16.SuspendLayout();
            this.pnlAlt.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSorgula
            // 
            this.btnSorgula.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSorgula.Location = new System.Drawing.Point(3, 21);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(95, 23);
            this.btnSorgula.TabIndex = 52;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = false;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.label54);
            this.panel12.Controls.Add(this.grpHesapTuru);
            this.panel12.Controls.Add(this.grpBelgeNumarası);
            this.panel12.Controls.Add(this.groupBox9);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(606, 108);
            this.panel12.TabIndex = 12;
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.White;
            this.label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label54.Dock = System.Windows.Forms.DockStyle.Top;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label54.Location = new System.Drawing.Point(0, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(604, 17);
            this.label54.TabIndex = 0;
            this.label54.Text = "Filtre Seçenekleri";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpHesapTuru
            // 
            this.grpHesapTuru.Controls.Add(this.rdCariHesaplarim);
            this.grpHesapTuru.Controls.Add(this.rdKendiHesaplarim);
            this.grpHesapTuru.Controls.Add(this.rdTumu);
            this.grpHesapTuru.Location = new System.Drawing.Point(482, 15);
            this.grpHesapTuru.Name = "grpHesapTuru";
            this.grpHesapTuru.Size = new System.Drawing.Size(119, 87);
            this.grpHesapTuru.TabIndex = 91;
            this.grpHesapTuru.TabStop = false;
            this.grpHesapTuru.Text = "Hesap Türü";
            // 
            // rdCariHesaplarim
            // 
            this.rdCariHesaplarim.AutoSize = true;
            this.rdCariHesaplarim.Location = new System.Drawing.Point(7, 59);
            this.rdCariHesaplarim.Name = "rdCariHesaplarim";
            this.rdCariHesaplarim.Size = new System.Drawing.Size(98, 17);
            this.rdCariHesaplarim.TabIndex = 2;
            this.rdCariHesaplarim.Text = "Cari Hesaplarım";
            this.rdCariHesaplarim.UseVisualStyleBackColor = true;
            // 
            // rdKendiHesaplarim
            // 
            this.rdKendiHesaplarim.AutoSize = true;
            this.rdKendiHesaplarim.Location = new System.Drawing.Point(7, 41);
            this.rdKendiHesaplarim.Name = "rdKendiHesaplarim";
            this.rdKendiHesaplarim.Size = new System.Drawing.Size(107, 17);
            this.rdKendiHesaplarim.TabIndex = 1;
            this.rdKendiHesaplarim.Text = "Kendi Hesaplarım";
            this.rdKendiHesaplarim.UseVisualStyleBackColor = true;
            // 
            // rdTumu
            // 
            this.rdTumu.AutoSize = true;
            this.rdTumu.Checked = true;
            this.rdTumu.Location = new System.Drawing.Point(7, 22);
            this.rdTumu.Name = "rdTumu";
            this.rdTumu.Size = new System.Drawing.Size(52, 17);
            this.rdTumu.TabIndex = 0;
            this.rdTumu.TabStop = true;
            this.rdTumu.Text = "Tümü";
            this.rdTumu.UseVisualStyleBackColor = true;
            // 
            // grpBelgeNumarası
            // 
            this.grpBelgeNumarası.Controls.Add(this.txtAyrinti);
            this.grpBelgeNumarası.Controls.Add(this.label2);
            this.grpBelgeNumarası.Controls.Add(this.txtiban);
            this.grpBelgeNumarası.Controls.Add(this.label1);
            this.grpBelgeNumarası.Controls.Add(this.chkSilinenKayitlariGoster);
            this.grpBelgeNumarası.Location = new System.Drawing.Point(232, 16);
            this.grpBelgeNumarası.Name = "grpBelgeNumarası";
            this.grpBelgeNumarası.Size = new System.Drawing.Size(248, 86);
            this.grpBelgeNumarası.TabIndex = 15;
            this.grpBelgeNumarası.TabStop = false;
            // 
            // txtAyrinti
            // 
            this.txtAyrinti.BackColor = System.Drawing.Color.White;
            this.txtAyrinti.ForeColor = System.Drawing.Color.Black;
            this.txtAyrinti.Location = new System.Drawing.Point(60, 36);
            this.txtAyrinti.Multiline = true;
            this.txtAyrinti.Name = "txtAyrinti";
            this.txtAyrinti.Size = new System.Drawing.Size(126, 44);
            this.txtAyrinti.TabIndex = 3;
            this.txtAyrinti.Tag = "001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ayrıntı";
            // 
            // txtiban
            // 
            this.txtiban.BackColor = System.Drawing.Color.White;
            this.txtiban.ForeColor = System.Drawing.Color.Black;
            this.txtiban.Location = new System.Drawing.Point(60, 13);
            this.txtiban.Name = "txtiban";
            this.txtiban.Size = new System.Drawing.Size(184, 20);
            this.txtiban.TabIndex = 1;
            this.txtiban.Tag = "001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IBAN";
            // 
            // chkSilinenKayitlariGoster
            // 
            this.chkSilinenKayitlariGoster.AutoSize = true;
            this.chkSilinenKayitlariGoster.Location = new System.Drawing.Point(187, 46);
            this.chkSilinenKayitlariGoster.Name = "chkSilinenKayitlariGoster";
            this.chkSilinenKayitlariGoster.Size = new System.Drawing.Size(60, 30);
            this.chkSilinenKayitlariGoster.TabIndex = 15;
            this.chkSilinenKayitlariGoster.Text = "Silinmiş\r\nKayıtlar";
            this.chkSilinenKayitlariGoster.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtBankaAdi);
            this.groupBox9.Controls.Add(this.txtHesapNo);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.txtHesapAdi);
            this.groupBox9.Controls.Add(this.label57);
            this.groupBox9.Controls.Add(this.label58);
            this.groupBox9.Location = new System.Drawing.Point(-1, 16);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(232, 86);
            this.groupBox9.TabIndex = 14;
            this.groupBox9.TabStop = false;
            // 
            // txtBankaAdi
            // 
            this.txtBankaAdi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBankaAdi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtBankaAdi.BackColor = System.Drawing.Color.White;
            this.txtBankaAdi.ForeColor = System.Drawing.Color.Black;
            this.txtBankaAdi.FormattingEnabled = true;
            this.txtBankaAdi.Items.AddRange(new object[] {
            "Adabank A.Ş.",
            "Akbank T.A.Ş.",
            "Aktif Yatırım Bankası A.Ş.",
            "Alternatifbank A.Ş.",
            "Anadolubank A.Ş.",
            "Arap Türk Bankası A.Ş.",
            "Bank Mellat",
            "BankPozitif Kredi ve Kalkınma Bankası A.Ş.",
            "Birleşik Fon Bankası A.Ş.",
            "Burgan Bank A.Ş.",
            "Citibank A.Ş.",
            "Denizbank A.Ş.",
            "Deutsche Bank A.Ş.",
            "Diler Yatırım Bankası A.Ş.",
            "Fibabanka A.Ş.",
            "Finans Bank A.Ş.",
            "GSD Yatırım Bankası A.Ş.",
            "Habib Bank Limited",
            "HSBC Bank A.Ş.",
            "ING Bank A.Ş.",
            "İller Bankası A.Ş.",
            "İstanbul Takas ve Saklama Bankası A.Ş.",
            "JPMorgan Chase Bank N.A.",
            "Merrill Lynch Yatırım Bank A.Ş.",
            "Nurol Yatırım Bankası A.Ş.",
            "Odea Bank A.Ş.",
            "Portigon AG",
            "Société Générale (SA)",
            "Standard Chartered Yatırım Bankası Türk A.Ş.",
            "Şekerbank T.A.Ş.",
            "Taib Yatırım Bank A.Ş.",
            "Tekstil Bankası A.Ş.",
            "The Royal Bank of Scotland Plc.",
            "Turkish Bank A.Ş.",
            "Turkland Bank A.Ş.",
            "Türk Ekonomi Bankası A.Ş.",
            "Türk Eximbank",
            "Türkiye Cumhuriyeti Ziraat Bankası A.Ş.",
            "Türkiye Garanti Bankası A.Ş.",
            "Türkiye Halk Bankası A.Ş.",
            "Türkiye İş Bankası A.Ş.",
            "Türkiye Kalkınma Bankası A.Ş.",
            "Türkiye Sınai Kalkınma Bankası A.Ş.",
            "Türkiye Vakıflar Bankası T.A.O.",
            "Yapı ve Kredi Bankası A.Ş."});
            this.txtBankaAdi.Location = new System.Drawing.Point(69, 14);
            this.txtBankaAdi.Name = "txtBankaAdi";
            this.txtBankaAdi.Size = new System.Drawing.Size(157, 21);
            this.txtBankaAdi.TabIndex = 17;
            this.txtBankaAdi.Tag = "001";
            // 
            // txtHesapNo
            // 
            this.txtHesapNo.BackColor = System.Drawing.Color.White;
            this.txtHesapNo.ForeColor = System.Drawing.Color.Black;
            this.txtHesapNo.Location = new System.Drawing.Point(69, 60);
            this.txtHesapNo.Name = "txtHesapNo";
            this.txtHesapNo.Size = new System.Drawing.Size(157, 20);
            this.txtHesapNo.TabIndex = 8;
            this.txtHesapNo.Tag = "001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Hesap No";
            // 
            // txtHesapAdi
            // 
            this.txtHesapAdi.BackColor = System.Drawing.Color.White;
            this.txtHesapAdi.ForeColor = System.Drawing.Color.Black;
            this.txtHesapAdi.Location = new System.Drawing.Point(69, 37);
            this.txtHesapAdi.Name = "txtHesapAdi";
            this.txtHesapAdi.Size = new System.Drawing.Size(157, 20);
            this.txtHesapAdi.TabIndex = 7;
            this.txtHesapAdi.Tag = "001";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(9, 41);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(56, 13);
            this.label57.TabIndex = 2;
            this.label57.Text = "Hesap Adı";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(9, 17);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(56, 13);
            this.label58.TabIndex = 1;
            this.label58.Text = "Banka Adı";
            // 
            // btnHesapEkle
            // 
            this.btnHesapEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnHesapEkle.Image = global::Elmar_Ticari_Plus.Properties.Resources.genelEkle;
            this.btnHesapEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHesapEkle.Location = new System.Drawing.Point(3, 65);
            this.btnHesapEkle.Name = "btnHesapEkle";
            this.btnHesapEkle.Size = new System.Drawing.Size(95, 23);
            this.btnHesapEkle.TabIndex = 53;
            this.btnHesapEkle.Text = "Yeni Hesap";
            this.btnHesapEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHesapEkle.UseVisualStyleBackColor = false;
            this.btnHesapEkle.Click += new System.EventHandler(this.btnHesapEkle_Click);
            // 
            // lblKayitSayisi3
            // 
            this.lblKayitSayisi3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblKayitSayisi3.ForeColor = System.Drawing.Color.DarkRed;
            this.lblKayitSayisi3.Location = new System.Drawing.Point(0, 91);
            this.lblKayitSayisi3.Name = "lblKayitSayisi3";
            this.lblKayitSayisi3.Size = new System.Drawing.Size(100, 15);
            this.lblKayitSayisi3.TabIndex = 51;
            this.lblKayitSayisi3.Text = "Kayıt Sayısı:";
            // 
            // dgBankaHesaplari
            // 
            this.dgBankaHesaplari.AllowUserToAddRows = false;
            this.dgBankaHesaplari.AllowUserToDeleteRows = false;
            this.dgBankaHesaplari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgBankaHesaplari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgBankaHesaplari.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bankaHesapid,
            this.bankaid,
            this.bankaAdi,
            this.hesapAdi,
            this.subeNo,
            this.hesapNo,
            this.iban,
            this.cariid,
            this.cariAdiSoyadi,
            this.hesapTuru,
            this.ayrinti});
            this.dgBankaHesaplari.ContextMenuStrip = this.contextMenuStrip1;
            this.dgBankaHesaplari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBankaHesaplari.Location = new System.Drawing.Point(0, 0);
            this.dgBankaHesaplari.MultiSelect = false;
            this.dgBankaHesaplari.Name = "dgBankaHesaplari";
            this.dgBankaHesaplari.ReadOnly = true;
            this.dgBankaHesaplari.RowHeadersWidth = 20;
            this.dgBankaHesaplari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBankaHesaplari.Size = new System.Drawing.Size(795, 403);
            this.dgBankaHesaplari.TabIndex = 7;
            this.dgBankaHesaplari.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBankaHesaplari_CellContentClick);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(186, 126);
            // 
            // yeniBankaTanımlaToolStripMenuItem
            // 
            this.yeniBankaTanımlaToolStripMenuItem.Name = "yeniBankaTanımlaToolStripMenuItem";
            this.yeniBankaTanımlaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.yeniBankaTanımlaToolStripMenuItem.Text = "Yeni Hesap Tanımla";
            this.yeniBankaTanımlaToolStripMenuItem.Click += new System.EventHandler(this.yeniBankaTanımlaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // raporGörüntüleToolStripMenuItem
            // 
            this.raporGörüntüleToolStripMenuItem.Name = "raporGörüntüleToolStripMenuItem";
            this.raporGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.raporGörüntüleToolStripMenuItem.Text = "Rapor Görüntüle";
            this.raporGörüntüleToolStripMenuItem.Click += new System.EventHandler(this.raporGörüntüleToolStripMenuItem_Click);
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.label70);
            this.panel16.Controls.Add(this.btnHesapEkle);
            this.panel16.Controls.Add(this.btnSorgula);
            this.panel16.Controls.Add(this.lblKayitSayisi3);
            this.panel16.Controls.Add(this.btnRaporGoruntule);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(606, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(102, 108);
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
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRaporGoruntule
            // 
            this.btnRaporGoruntule.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRaporGoruntule.Location = new System.Drawing.Point(3, 43);
            this.btnRaporGoruntule.Name = "btnRaporGoruntule";
            this.btnRaporGoruntule.Size = new System.Drawing.Size(95, 23);
            this.btnRaporGoruntule.TabIndex = 47;
            this.btnRaporGoruntule.Text = "Rapor Görüntüle";
            this.btnRaporGoruntule.UseVisualStyleBackColor = false;
            // 
            // pnlAlt
            // 
            this.pnlAlt.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlAlt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlt.Controls.Add(this.panel16);
            this.pnlAlt.Controls.Add(this.panel12);
            this.pnlAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlt.Location = new System.Drawing.Point(0, 403);
            this.pnlAlt.Name = "pnlAlt";
            this.pnlAlt.Size = new System.Drawing.Size(795, 110);
            this.pnlAlt.TabIndex = 8;
            // 
            // bankaHesapid
            // 
            this.bankaHesapid.HeaderText = "bankaHesapid";
            this.bankaHesapid.Name = "bankaHesapid";
            this.bankaHesapid.ReadOnly = true;
            this.bankaHesapid.Visible = false;
            this.bankaHesapid.Width = 101;
            // 
            // bankaid
            // 
            this.bankaid.HeaderText = "bankaid";
            this.bankaid.Name = "bankaid";
            this.bankaid.ReadOnly = true;
            this.bankaid.Visible = false;
            this.bankaid.Width = 70;
            // 
            // bankaAdi
            // 
            this.bankaAdi.HeaderText = "Banka Adı";
            this.bankaAdi.Name = "bankaAdi";
            this.bankaAdi.ReadOnly = true;
            this.bankaAdi.Width = 81;
            // 
            // hesapAdi
            // 
            this.hesapAdi.HeaderText = "Hesap Adı";
            this.hesapAdi.Name = "hesapAdi";
            this.hesapAdi.ReadOnly = true;
            this.hesapAdi.Width = 81;
            // 
            // subeNo
            // 
            this.subeNo.HeaderText = "Şube No";
            this.subeNo.Name = "subeNo";
            this.subeNo.ReadOnly = true;
            this.subeNo.Width = 74;
            // 
            // hesapNo
            // 
            this.hesapNo.HeaderText = "Hesap No";
            this.hesapNo.Name = "hesapNo";
            this.hesapNo.ReadOnly = true;
            this.hesapNo.Width = 80;
            // 
            // iban
            // 
            this.iban.HeaderText = "IBAN";
            this.iban.Name = "iban";
            this.iban.ReadOnly = true;
            this.iban.Width = 57;
            // 
            // cariid
            // 
            this.cariid.HeaderText = "cariid";
            this.cariid.Name = "cariid";
            this.cariid.ReadOnly = true;
            this.cariid.Visible = false;
            this.cariid.Width = 57;
            // 
            // cariAdiSoyadi
            // 
            this.cariAdiSoyadi.HeaderText = "Cari Adı Soyadı";
            this.cariAdiSoyadi.Name = "cariAdiSoyadi";
            this.cariAdiSoyadi.ReadOnly = true;
            this.cariAdiSoyadi.Width = 103;
            // 
            // hesapTuru
            // 
            this.hesapTuru.HeaderText = "Hesap Türü";
            this.hesapTuru.Name = "hesapTuru";
            this.hesapTuru.ReadOnly = true;
            this.hesapTuru.Width = 88;
            // 
            // ayrinti
            // 
            this.ayrinti.HeaderText = "Ayrıntı";
            this.ayrinti.Name = "ayrinti";
            this.ayrinti.ReadOnly = true;
            this.ayrinti.Width = 60;
            // 
            // frmBankaHesaplari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(795, 513);
            this.Controls.Add(this.dgBankaHesaplari);
            this.Controls.Add(this.pnlAlt);
            this.Name = "frmBankaHesaplari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Banka Hesapları";
            this.Load += new System.EventHandler(this.frmBankaHesaplari_Load);
            this.panel12.ResumeLayout(false);
            this.grpHesapTuru.ResumeLayout(false);
            this.grpHesapTuru.PerformLayout();
            this.grpBelgeNumarası.ResumeLayout(false);
            this.grpBelgeNumarası.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBankaHesaplari)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.pnlAlt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.GroupBox grpBelgeNumarası;
        private System.Windows.Forms.TextBox txtAyrinti;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtiban;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSilinenKayitlariGoster;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button btnHesapEkle;
        private System.Windows.Forms.Label lblKayitSayisi3;
        public System.Windows.Forms.DataGridView dgBankaHesaplari;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yeniBankaTanımlaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silmeİşleminiGeriAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem raporGörüntüleToolStripMenuItem;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button btnRaporGoruntule;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Panel pnlAlt;
        private System.Windows.Forms.TextBox txtHesapNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHesapAdi;
        private System.Windows.Forms.GroupBox grpHesapTuru;
        private System.Windows.Forms.RadioButton rdCariHesaplarim;
        private System.Windows.Forms.RadioButton rdKendiHesaplarim;
        private System.Windows.Forms.RadioButton rdTumu;
        private System.Windows.Forms.ComboBox txtBankaAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankaHesapid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankaAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn hesapAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn subeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn hesapNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn iban;
        private System.Windows.Forms.DataGridViewTextBoxColumn cariid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cariAdiSoyadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn hesapTuru;
        private System.Windows.Forms.DataGridViewTextBoxColumn ayrinti;
    }
}