namespace Elmar_Ticari_Plus
{
    partial class frmBankalar
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
            this.dgBankalar = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yeniBankaTanımlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silmeİşleminiGeriAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.raporGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlAlt = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label70 = new System.Windows.Forms.Label();
            this.btnBankaEkle = new System.Windows.Forms.Button();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.lblKayitSayisi3 = new System.Windows.Forms.Label();
            this.btnRaporGoruntule = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label54 = new System.Windows.Forms.Label();
            this.grpBelgeNumarası = new System.Windows.Forms.GroupBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSubeAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSilinenKayitlariGoster = new System.Windows.Forms.CheckBox();
            this.chkFirmamTarafindanEklenmisOlanKayitlar = new System.Windows.Forms.CheckBox();
            this.chkTaslaktaMevcutBulunanKayitlar = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtil = new System.Windows.Forms.ComboBox();
            this.txtBankaAdi = new System.Windows.Forms.ComboBox();
            this.txtilce = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bankaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sec = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bankaAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subeAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.il = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ilce = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firmaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgBankalar)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlAlt.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel12.SuspendLayout();
            this.grpBelgeNumarası.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgBankalar
            // 
            this.dgBankalar.AllowUserToAddRows = false;
            this.dgBankalar.AllowUserToDeleteRows = false;
            this.dgBankalar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgBankalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBankalar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bankaid,
            this.sec,
            this.bankaAdi,
            this.subeAdi,
            this.il,
            this.ilce,
            this.adres,
            this.tel,
            this.faks,
            this.aciklama,
            this.firmaid});
            this.dgBankalar.ContextMenuStrip = this.contextMenuStrip1;
            this.dgBankalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBankalar.Location = new System.Drawing.Point(0, 0);
            this.dgBankalar.MultiSelect = false;
            this.dgBankalar.Name = "dgBankalar";
            this.dgBankalar.ReadOnly = true;
            this.dgBankalar.RowHeadersWidth = 20;
            this.dgBankalar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBankalar.Size = new System.Drawing.Size(840, 387);
            this.dgBankalar.TabIndex = 3;
            this.dgBankalar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBankalar_CellClick);
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
            this.yeniBankaTanımlaToolStripMenuItem.Text = "Yeni Banka Tanımla";
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
            // pnlAlt
            // 
            this.pnlAlt.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlAlt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlt.Controls.Add(this.panel16);
            this.pnlAlt.Controls.Add(this.panel12);
            this.pnlAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlt.Location = new System.Drawing.Point(0, 387);
            this.pnlAlt.Name = "pnlAlt";
            this.pnlAlt.Size = new System.Drawing.Size(840, 132);
            this.pnlAlt.TabIndex = 6;
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.label70);
            this.panel16.Controls.Add(this.btnBankaEkle);
            this.panel16.Controls.Add(this.btnSorgula);
            this.panel16.Controls.Add(this.lblKayitSayisi3);
            this.panel16.Controls.Add(this.btnRaporGoruntule);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(522, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(102, 130);
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
            // btnBankaEkle
            // 
            this.btnBankaEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnBankaEkle.Image = global::Elmar_Ticari_Plus.Properties.Resources.genelEkle;
            this.btnBankaEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBankaEkle.Location = new System.Drawing.Point(3, 74);
            this.btnBankaEkle.Name = "btnBankaEkle";
            this.btnBankaEkle.Size = new System.Drawing.Size(95, 23);
            this.btnBankaEkle.TabIndex = 53;
            this.btnBankaEkle.Text = "Yeni Banka";
            this.btnBankaEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBankaEkle.UseVisualStyleBackColor = false;
            this.btnBankaEkle.Click += new System.EventHandler(this.btnBankaEkle_Click);
            // 
            // btnSorgula
            // 
            this.btnSorgula.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSorgula.Location = new System.Drawing.Point(3, 25);
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
            this.lblKayitSayisi3.Location = new System.Drawing.Point(0, 113);
            this.lblKayitSayisi3.Name = "lblKayitSayisi3";
            this.lblKayitSayisi3.Size = new System.Drawing.Size(100, 15);
            this.lblKayitSayisi3.TabIndex = 51;
            this.lblKayitSayisi3.Text = "Kayıt Sayısı:";
            // 
            // btnRaporGoruntule
            // 
            this.btnRaporGoruntule.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRaporGoruntule.Location = new System.Drawing.Point(3, 49);
            this.btnRaporGoruntule.Name = "btnRaporGoruntule";
            this.btnRaporGoruntule.Size = new System.Drawing.Size(95, 23);
            this.btnRaporGoruntule.TabIndex = 47;
            this.btnRaporGoruntule.Text = "Rapor Görüntüle";
            this.btnRaporGoruntule.UseVisualStyleBackColor = false;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.label54);
            this.panel12.Controls.Add(this.grpBelgeNumarası);
            this.panel12.Controls.Add(this.chkSilinenKayitlariGoster);
            this.panel12.Controls.Add(this.chkFirmamTarafindanEklenmisOlanKayitlar);
            this.panel12.Controls.Add(this.chkTaslaktaMevcutBulunanKayitlar);
            this.panel12.Controls.Add(this.groupBox9);
            this.panel12.Controls.Add(this.label4);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(522, 130);
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
            this.label54.Size = new System.Drawing.Size(520, 17);
            this.label54.TabIndex = 0;
            this.label54.Text = "Filtre Seçenekleri";
            this.label54.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grpBelgeNumarası
            // 
            this.grpBelgeNumarası.Controls.Add(this.txtAciklama);
            this.grpBelgeNumarası.Controls.Add(this.label3);
            this.grpBelgeNumarası.Controls.Add(this.txtAdres);
            this.grpBelgeNumarası.Controls.Add(this.label2);
            this.grpBelgeNumarası.Controls.Add(this.txtSubeAdi);
            this.grpBelgeNumarası.Controls.Add(this.label1);
            this.grpBelgeNumarası.Location = new System.Drawing.Point(264, 16);
            this.grpBelgeNumarası.Name = "grpBelgeNumarası";
            this.grpBelgeNumarası.Size = new System.Drawing.Size(251, 86);
            this.grpBelgeNumarası.TabIndex = 15;
            this.grpBelgeNumarası.TabStop = false;
            // 
            // txtAciklama
            // 
            this.txtAciklama.BackColor = System.Drawing.Color.White;
            this.txtAciklama.ForeColor = System.Drawing.Color.Black;
            this.txtAciklama.Location = new System.Drawing.Point(60, 59);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(184, 20);
            this.txtAciklama.TabIndex = 3;
            this.txtAciklama.Tag = "001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Açıklama";
            // 
            // txtAdres
            // 
            this.txtAdres.BackColor = System.Drawing.Color.White;
            this.txtAdres.ForeColor = System.Drawing.Color.Black;
            this.txtAdres.Location = new System.Drawing.Point(60, 36);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(184, 20);
            this.txtAdres.TabIndex = 2;
            this.txtAdres.Tag = "001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Adres";
            // 
            // txtSubeAdi
            // 
            this.txtSubeAdi.BackColor = System.Drawing.Color.White;
            this.txtSubeAdi.ForeColor = System.Drawing.Color.Black;
            this.txtSubeAdi.Location = new System.Drawing.Point(60, 13);
            this.txtSubeAdi.Name = "txtSubeAdi";
            this.txtSubeAdi.Size = new System.Drawing.Size(184, 20);
            this.txtSubeAdi.TabIndex = 1;
            this.txtSubeAdi.Tag = "001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Şube Adı";
            // 
            // chkSilinenKayitlariGoster
            // 
            this.chkSilinenKayitlariGoster.AutoSize = true;
            this.chkSilinenKayitlariGoster.Location = new System.Drawing.Point(416, 111);
            this.chkSilinenKayitlariGoster.Name = "chkSilinenKayitlariGoster";
            this.chkSilinenKayitlariGoster.Size = new System.Drawing.Size(97, 17);
            this.chkSilinenKayitlariGoster.TabIndex = 15;
            this.chkSilinenKayitlariGoster.Text = "Silinmiş Kayıtlar";
            this.chkSilinenKayitlariGoster.UseVisualStyleBackColor = true;
            // 
            // chkFirmamTarafindanEklenmisOlanKayitlar
            // 
            this.chkFirmamTarafindanEklenmisOlanKayitlar.AutoSize = true;
            this.chkFirmamTarafindanEklenmisOlanKayitlar.Checked = true;
            this.chkFirmamTarafindanEklenmisOlanKayitlar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFirmamTarafindanEklenmisOlanKayitlar.Location = new System.Drawing.Point(194, 111);
            this.chkFirmamTarafindanEklenmisOlanKayitlar.Name = "chkFirmamTarafindanEklenmisOlanKayitlar";
            this.chkFirmamTarafindanEklenmisOlanKayitlar.Size = new System.Drawing.Size(216, 17);
            this.chkFirmamTarafindanEklenmisOlanKayitlar.TabIndex = 2;
            this.chkFirmamTarafindanEklenmisOlanKayitlar.Text = "Firmam tarafından Eklenmiş Olan Kayıtlar";
            this.chkFirmamTarafindanEklenmisOlanKayitlar.UseVisualStyleBackColor = true;
            // 
            // chkTaslaktaMevcutBulunanKayitlar
            // 
            this.chkTaslaktaMevcutBulunanKayitlar.AutoSize = true;
            this.chkTaslaktaMevcutBulunanKayitlar.Checked = true;
            this.chkTaslaktaMevcutBulunanKayitlar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTaslaktaMevcutBulunanKayitlar.Location = new System.Drawing.Point(3, 111);
            this.chkTaslaktaMevcutBulunanKayitlar.Name = "chkTaslaktaMevcutBulunanKayitlar";
            this.chkTaslaktaMevcutBulunanKayitlar.Size = new System.Drawing.Size(185, 17);
            this.chkTaslaktaMevcutBulunanKayitlar.TabIndex = 10;
            this.chkTaslaktaMevcutBulunanKayitlar.Text = "Taslakta Mevcut Bulunan Kayıtlar";
            this.chkTaslaktaMevcutBulunanKayitlar.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtil);
            this.groupBox9.Controls.Add(this.txtBankaAdi);
            this.groupBox9.Controls.Add(this.txtilce);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.label57);
            this.groupBox9.Controls.Add(this.label58);
            this.groupBox9.Location = new System.Drawing.Point(-1, 16);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(259, 86);
            this.groupBox9.TabIndex = 14;
            this.groupBox9.TabStop = false;
            // 
            // txtil
            // 
            this.txtil.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtil.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtil.BackColor = System.Drawing.Color.White;
            this.txtil.ForeColor = System.Drawing.Color.Black;
            this.txtil.FormattingEnabled = true;
            this.txtil.Items.AddRange(new object[] {
            "Adana",
            "Adıyaman",
            "Afyonkarahisar",
            "Ağrı",
            "Aksaray",
            "Amasya",
            "Ankara",
            "Antalya",
            "Ardahan",
            "Artvin",
            "Aydın",
            "Balıkesir",
            "Bartın",
            "Batman",
            "Bayburt",
            "Bilecik",
            "Bingöl",
            "Bitlis",
            "Bolu",
            "Burdur",
            "Bursa",
            "Çanakkale",
            "Çankırı",
            "Çorum",
            "Denizli",
            "Diyarbakır",
            "Düzce",
            "Edirne",
            "Elazığ",
            "Erzincan",
            "Erzurum",
            "Eskişehir",
            "Gaziantep",
            "Giresun",
            "Gümüşhane",
            "Hakkari",
            "Hatay",
            "Iğdır",
            "Isparta",
            "İstanbul",
            "İzmir",
            "Kahramanmaraş",
            "Karabük",
            "Karaman",
            "Kars",
            "Kastamonu",
            "Kayseri",
            "Kırıkkale",
            "Kırklareli",
            "Kırşehir",
            "Kilis",
            "Kocaeli",
            "Konya",
            "Kütahya",
            "Malatya",
            "Manisa",
            "Mardin",
            "Mersin",
            "Muğla",
            "Muş",
            "Nevşehir",
            "Niğde",
            "Ordu",
            "Osmaniye",
            "Rize",
            "Sakarya",
            "Samsun",
            "Siirt",
            "Sinop",
            "Sivas",
            "Şanlıurfa",
            "Şırnak",
            "Tekirdağ",
            "Tokat",
            "Trabzon",
            "Tunceli",
            "Uşak",
            "Van",
            "Yalova",
            "Yozgat",
            "Zonguldak"});
            this.txtil.Location = new System.Drawing.Point(69, 37);
            this.txtil.Name = "txtil";
            this.txtil.Size = new System.Drawing.Size(184, 21);
            this.txtil.TabIndex = 17;
            this.txtil.Tag = "001";
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
            this.txtBankaAdi.Location = new System.Drawing.Point(69, 13);
            this.txtBankaAdi.Name = "txtBankaAdi";
            this.txtBankaAdi.Size = new System.Drawing.Size(184, 21);
            this.txtBankaAdi.TabIndex = 16;
            this.txtBankaAdi.Tag = "001";
            // 
            // txtilce
            // 
            this.txtilce.BackColor = System.Drawing.Color.White;
            this.txtilce.ForeColor = System.Drawing.Color.Black;
            this.txtilce.Location = new System.Drawing.Point(69, 60);
            this.txtilce.Name = "txtilce";
            this.txtilce.Size = new System.Drawing.Size(184, 20);
            this.txtilce.TabIndex = 18;
            this.txtilce.Tag = "001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "İlçe";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(9, 41);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(12, 13);
            this.label57.TabIndex = 2;
            this.label57.Text = "İl";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-2, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(517, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "_________________________________________________________________________________" +
    "____";
            // 
            // bankaid
            // 
            this.bankaid.HeaderText = "bankaid";
            this.bankaid.Name = "bankaid";
            this.bankaid.ReadOnly = true;
            this.bankaid.Visible = false;
            this.bankaid.Width = 51;
            // 
            // sec
            // 
            this.sec.HeaderText = "";
            this.sec.Name = "sec";
            this.sec.ReadOnly = true;
            this.sec.Visible = false;
            this.sec.Width = 5;
            // 
            // bankaAdi
            // 
            this.bankaAdi.HeaderText = "Banka Adı";
            this.bankaAdi.Name = "bankaAdi";
            this.bankaAdi.ReadOnly = true;
            this.bankaAdi.Width = 81;
            // 
            // subeAdi
            // 
            this.subeAdi.HeaderText = "Şube Adı";
            this.subeAdi.Name = "subeAdi";
            this.subeAdi.ReadOnly = true;
            this.subeAdi.Width = 75;
            // 
            // il
            // 
            this.il.HeaderText = "İl";
            this.il.Name = "il";
            this.il.ReadOnly = true;
            this.il.Width = 37;
            // 
            // ilce
            // 
            this.ilce.HeaderText = "İlçe";
            this.ilce.Name = "ilce";
            this.ilce.ReadOnly = true;
            this.ilce.Width = 49;
            // 
            // adres
            // 
            this.adres.HeaderText = "Adres";
            this.adres.Name = "adres";
            this.adres.ReadOnly = true;
            this.adres.Width = 59;
            // 
            // tel
            // 
            this.tel.HeaderText = "Tel";
            this.tel.Name = "tel";
            this.tel.ReadOnly = true;
            this.tel.Width = 47;
            // 
            // faks
            // 
            this.faks.HeaderText = "Fax";
            this.faks.Name = "faks";
            this.faks.ReadOnly = true;
            this.faks.Width = 49;
            // 
            // aciklama
            // 
            this.aciklama.HeaderText = "Açıklama";
            this.aciklama.Name = "aciklama";
            this.aciklama.ReadOnly = true;
            this.aciklama.Width = 75;
            // 
            // firmaid
            // 
            this.firmaid.HeaderText = "firmaid";
            this.firmaid.Name = "firmaid";
            this.firmaid.ReadOnly = true;
            this.firmaid.Visible = false;
            this.firmaid.Width = 62;
            // 
            // frmBankalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 519);
            this.Controls.Add(this.dgBankalar);
            this.Controls.Add(this.pnlAlt);
            this.Name = "frmBankalar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Bankalar Listesi, Banka Ekle";
            this.Load += new System.EventHandler(this.frmBankalar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBankalar)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlAlt.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.grpBelgeNumarası.ResumeLayout(false);
            this.grpBelgeNumarası.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAlt;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.Label lblKayitSayisi3;
        private System.Windows.Forms.Button btnRaporGoruntule;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.CheckBox chkSilinenKayitlariGoster;
        private System.Windows.Forms.GroupBox grpBelgeNumarası;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSubeAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.CheckBox chkTaslaktaMevcutBulunanKayitlar;
        private System.Windows.Forms.CheckBox chkFirmamTarafindanEklenmisOlanKayitlar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBankaEkle;
        private System.Windows.Forms.TextBox txtilce;
        public System.Windows.Forms.DataGridView dgBankalar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yeniBankaTanımlaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem raporGörüntüleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silmeİşleminiGeriAlToolStripMenuItem;
        private System.Windows.Forms.ComboBox txtBankaAdi;
        private System.Windows.Forms.ComboBox txtil;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankaid;
        private System.Windows.Forms.DataGridViewButtonColumn sec;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankaAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn subeAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn il;
        private System.Windows.Forms.DataGridViewTextBoxColumn ilce;
        private System.Windows.Forms.DataGridViewTextBoxColumn adres;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn faks;
        private System.Windows.Forms.DataGridViewTextBoxColumn aciklama;
        private System.Windows.Forms.DataGridViewTextBoxColumn firmaid;
    }
}