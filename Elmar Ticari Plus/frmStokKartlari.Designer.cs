namespace Elmar_Ticari_Plus
{
    partial class frmStokKartlari
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgStokKart = new System.Windows.Forms.DataGridView();
            this.cnsStokkart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayrıntılıDüzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokKartınıSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silmeİşleminiGeriAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokKartınıPasifYapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokKartınıAktifYapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webdeGösterilsinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webdeGösterilmesinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemVitrin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMobil = new System.Windows.Forms.ToolStripMenuItem();
            this.stokKartDetaylarınıGösterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.listeyiYenileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barkoduYazdırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.btnBarkodYazdir = new System.Windows.Forms.Button();
            this.lblKayitSayisi = new System.Windows.Forms.Label();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.btnRaporGoruntule = new System.Windows.Forms.Button();
            this.label62 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.chbCanliStok = new System.Windows.Forms.CheckBox();
            this.cmbGecerliSatisFiyati = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnexcelaktar = new System.Windows.Forms.Button();
            this.cmbMarkalar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUrunKodu = new System.Windows.Forms.TextBox();
            this.cmbKullanici = new System.Windows.Forms.ComboBox();
            this.txtRaf = new System.Windows.Forms.TextBox();
            this.cmbSube = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.cmbUrunAdi = new System.Windows.Forms.ComboBox();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.txtSeriNo = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.txtStokkodu = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.chkSilinen = new System.Windows.Forms.CheckBox();
            this.chkWebdeGosterilecek = new System.Windows.Forms.CheckBox();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.chkAktifmi = new System.Windows.Forms.CheckBox();
            this.chkindirimYapilanStokKartlari = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.btnKategoriSec = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.cmbKdv = new System.Windows.Forms.ComboBox();
            this.cmbKdvTipi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.stokid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stokkodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rfidEtiketi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barkod1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urunAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alisFiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.satisFiyat1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kdv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kdvTipi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.katNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanliStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kategoriAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urunKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.garantiSuresi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markaAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rafAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ayrinti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aktifmi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobil = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Vitrin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.eklenmeTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.silindimi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgStokKart)).BeginInit();
            this.cnsStokkart.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgStokKart
            // 
            this.dgStokKart.AllowUserToAddRows = false;
            this.dgStokKart.AllowUserToDeleteRows = false;
            this.dgStokKart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgStokKart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStokKart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stokid,
            this.stokkodu,
            this.rfidEtiketi,
            this.barkod1,
            this.urunAdi,
            this.alisFiyat,
            this.satisFiyat1,
            this.kdv,
            this.kdvTipi,
            this.katNo,
            this.CanliStok,
            this.kategoriAdi,
            this.urunKodu,
            this.garantiSuresi,
            this.markaid,
            this.markaAdi,
            this.rafAdi,
            this.ayrinti,
            this.aktifmi,
            this.Mobil,
            this.Vitrin,
            this.eklenmeTarihi,
            this.silindimi});
            this.dgStokKart.ContextMenuStrip = this.cnsStokkart;
            this.dgStokKart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgStokKart.Location = new System.Drawing.Point(0, 0);
            this.dgStokKart.MultiSelect = false;
            this.dgStokKart.Name = "dgStokKart";
            this.dgStokKart.ReadOnly = true;
            this.dgStokKart.RowHeadersWidth = 20;
            this.dgStokKart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStokKart.Size = new System.Drawing.Size(913, 427);
            this.dgStokKart.TabIndex = 1;
            // 
            // cnsStokkart
            // 
            this.cnsStokkart.BackColor = System.Drawing.Color.Gainsboro;
            this.cnsStokkart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.düzenleToolStripMenuItem,
            this.ayrıntılıDüzenleToolStripMenuItem,
            this.stokKartınıSilToolStripMenuItem,
            this.silmeİşleminiGeriAlToolStripMenuItem,
            this.stokKartınıPasifYapToolStripMenuItem,
            this.stokKartınıAktifYapToolStripMenuItem,
            this.webdeGösterilsinToolStripMenuItem,
            this.webdeGösterilmesinToolStripMenuItem,
            this.toolStripMenuItemVitrin,
            this.toolStripMenuItemMobil,
            this.stokKartDetaylarınıGösterToolStripMenuItem,
            this.toolStripSeparator1,
            this.listeyiYenileToolStripMenuItem,
            this.barkoduYazdırToolStripMenuItem,
            this.raporGörüntüleToolStripMenuItem});
            this.cnsStokkart.Name = "cnsStokkart";
            this.cnsStokkart.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cnsStokkart.Size = new System.Drawing.Size(221, 318);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // ayrıntılıDüzenleToolStripMenuItem
            // 
            this.ayrıntılıDüzenleToolStripMenuItem.Name = "ayrıntılıDüzenleToolStripMenuItem";
            this.ayrıntılıDüzenleToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.ayrıntılıDüzenleToolStripMenuItem.Text = "Ayrıntılı Düzenle";
            this.ayrıntılıDüzenleToolStripMenuItem.Click += new System.EventHandler(this.ayrıntılıDüzenleToolStripMenuItem_Click);
            // 
            // stokKartınıSilToolStripMenuItem
            // 
            this.stokKartınıSilToolStripMenuItem.Name = "stokKartınıSilToolStripMenuItem";
            this.stokKartınıSilToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.stokKartınıSilToolStripMenuItem.Text = "Stok Kartını Sil";
            this.stokKartınıSilToolStripMenuItem.Click += new System.EventHandler(this.stokKartınıSilToolStripMenuItem_Click);
            // 
            // silmeİşleminiGeriAlToolStripMenuItem
            // 
            this.silmeİşleminiGeriAlToolStripMenuItem.Name = "silmeİşleminiGeriAlToolStripMenuItem";
            this.silmeİşleminiGeriAlToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.silmeİşleminiGeriAlToolStripMenuItem.Text = "Silme İşlemini Geri Al";
            this.silmeİşleminiGeriAlToolStripMenuItem.Click += new System.EventHandler(this.silmeİşleminiGeriAlToolStripMenuItem_Click);
            // 
            // stokKartınıPasifYapToolStripMenuItem
            // 
            this.stokKartınıPasifYapToolStripMenuItem.Name = "stokKartınıPasifYapToolStripMenuItem";
            this.stokKartınıPasifYapToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.stokKartınıPasifYapToolStripMenuItem.Text = "Stok Kartını Pasif Yap";
            this.stokKartınıPasifYapToolStripMenuItem.Click += new System.EventHandler(this.stokKartınıPasifYapToolStripMenuItem_Click);
            // 
            // stokKartınıAktifYapToolStripMenuItem
            // 
            this.stokKartınıAktifYapToolStripMenuItem.Name = "stokKartınıAktifYapToolStripMenuItem";
            this.stokKartınıAktifYapToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.stokKartınıAktifYapToolStripMenuItem.Text = "Stok Kartını Aktif Yap";
            this.stokKartınıAktifYapToolStripMenuItem.Click += new System.EventHandler(this.stokKartınıAktifYapToolStripMenuItem_Click);
            // 
            // webdeGösterilsinToolStripMenuItem
            // 
            this.webdeGösterilsinToolStripMenuItem.Name = "webdeGösterilsinToolStripMenuItem";
            this.webdeGösterilsinToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.webdeGösterilsinToolStripMenuItem.Text = "Webde Gösterilsin";
            this.webdeGösterilsinToolStripMenuItem.Click += new System.EventHandler(this.webdeGösterilsinToolStripMenuItem_Click);
            // 
            // webdeGösterilmesinToolStripMenuItem
            // 
            this.webdeGösterilmesinToolStripMenuItem.Name = "webdeGösterilmesinToolStripMenuItem";
            this.webdeGösterilmesinToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.webdeGösterilmesinToolStripMenuItem.Text = "Webde Gösterilmesin";
            this.webdeGösterilmesinToolStripMenuItem.Click += new System.EventHandler(this.webdeGösterilmesinToolStripMenuItem_Click);
            // 
            // toolStripMenuItemVitrin
            // 
            this.toolStripMenuItemVitrin.Name = "toolStripMenuItemVitrin";
            this.toolStripMenuItemVitrin.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItemVitrin.Text = "Vitrinde Göster";
            this.toolStripMenuItemVitrin.Click += new System.EventHandler(this.toolStripMenuItemVitrin_Click);
            // 
            // toolStripMenuItemMobil
            // 
            this.toolStripMenuItemMobil.Name = "toolStripMenuItemMobil";
            this.toolStripMenuItemMobil.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItemMobil.Text = "Mobilde Göster";
            this.toolStripMenuItemMobil.Click += new System.EventHandler(this.toolStripMenuItemMobil_Click);
            // 
            // stokKartDetaylarınıGösterToolStripMenuItem
            // 
            this.stokKartDetaylarınıGösterToolStripMenuItem.Name = "stokKartDetaylarınıGösterToolStripMenuItem";
            this.stokKartDetaylarınıGösterToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.stokKartDetaylarınıGösterToolStripMenuItem.Text = "Stok Kart Detaylarını  Göster";
            this.stokKartDetaylarınıGösterToolStripMenuItem.Click += new System.EventHandler(this.stokKartDetaylarınıGösterToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            // 
            // listeyiYenileToolStripMenuItem
            // 
            this.listeyiYenileToolStripMenuItem.Name = "listeyiYenileToolStripMenuItem";
            this.listeyiYenileToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.listeyiYenileToolStripMenuItem.Text = "Listeyi Yenile";
            this.listeyiYenileToolStripMenuItem.Click += new System.EventHandler(this.listeyiYenileToolStripMenuItem_Click);
            // 
            // barkoduYazdırToolStripMenuItem
            // 
            this.barkoduYazdırToolStripMenuItem.Name = "barkoduYazdırToolStripMenuItem";
            this.barkoduYazdırToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.barkoduYazdırToolStripMenuItem.Text = "Etiket Yazdır";
            this.barkoduYazdırToolStripMenuItem.Click += new System.EventHandler(this.barkoduYazdırToolStripMenuItem_Click);
            // 
            // raporGörüntüleToolStripMenuItem
            // 
            this.raporGörüntüleToolStripMenuItem.Name = "raporGörüntüleToolStripMenuItem";
            this.raporGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.raporGörüntüleToolStripMenuItem.Text = "Rapor Görüntüle";
            this.raporGörüntüleToolStripMenuItem.Click += new System.EventHandler(this.raporGörüntüleToolStripMenuItem_Click);
            // 
            // panel14
            // 
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel14.Controls.Add(this.panel15);
            this.panel14.Controls.Add(this.panel11);
            this.panel14.Controls.Add(this.cmbKdv);
            this.panel14.Controls.Add(this.cmbKdvTipi);
            this.panel14.Controls.Add(this.label1);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel14.Location = new System.Drawing.Point(0, 427);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(913, 130);
            this.panel14.TabIndex = 2;
            this.panel14.TabStop = true;
            // 
            // panel15
            // 
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel15.Controls.Add(this.btnBarkodYazdir);
            this.panel15.Controls.Add(this.lblKayitSayisi);
            this.panel15.Controls.Add(this.btnSorgula);
            this.panel15.Controls.Add(this.btnRaporGoruntule);
            this.panel15.Controls.Add(this.label62);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(738, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(98, 128);
            this.panel15.TabIndex = 20;
            this.panel15.TabStop = true;
            // 
            // btnBarkodYazdir
            // 
            this.btnBarkodYazdir.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnBarkodYazdir.Location = new System.Drawing.Point(0, 78);
            this.btnBarkodYazdir.Name = "btnBarkodYazdir";
            this.btnBarkodYazdir.Size = new System.Drawing.Size(96, 27);
            this.btnBarkodYazdir.TabIndex = 51;
            this.btnBarkodYazdir.Text = "Etiket Yazdır";
            this.btnBarkodYazdir.UseVisualStyleBackColor = false;
            this.btnBarkodYazdir.Click += new System.EventHandler(this.btnBarkodYazdir_Click);
            // 
            // lblKayitSayisi
            // 
            this.lblKayitSayisi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKayitSayisi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblKayitSayisi.Location = new System.Drawing.Point(0, 111);
            this.lblKayitSayisi.Name = "lblKayitSayisi";
            this.lblKayitSayisi.Size = new System.Drawing.Size(96, 15);
            this.lblKayitSayisi.TabIndex = 50;
            this.lblKayitSayisi.Text = "Kayıt Sayısı:";
            // 
            // btnSorgula
            // 
            this.btnSorgula.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSorgula.Location = new System.Drawing.Point(0, 21);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(96, 27);
            this.btnSorgula.TabIndex = 21;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = false;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // btnRaporGoruntule
            // 
            this.btnRaporGoruntule.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRaporGoruntule.Location = new System.Drawing.Point(0, 48);
            this.btnRaporGoruntule.Name = "btnRaporGoruntule";
            this.btnRaporGoruntule.Size = new System.Drawing.Size(96, 29);
            this.btnRaporGoruntule.TabIndex = 22;
            this.btnRaporGoruntule.Text = "Rapor Görüntüle";
            this.btnRaporGoruntule.UseVisualStyleBackColor = false;
            this.btnRaporGoruntule.Click += new System.EventHandler(this.btnRaporGoruntule_Click);
            // 
            // label62
            // 
            this.label62.BackColor = System.Drawing.Color.White;
            this.label62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label62.Dock = System.Windows.Forms.DockStyle.Top;
            this.label62.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label62.Location = new System.Drawing.Point(0, 0);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(96, 17);
            this.label62.TabIndex = 0;
            this.label62.Text = "Raporlama";
            this.label62.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.chbCanliStok);
            this.panel11.Controls.Add(this.cmbGecerliSatisFiyati);
            this.panel11.Controls.Add(this.label5);
            this.panel11.Controls.Add(this.btnexcelaktar);
            this.panel11.Controls.Add(this.cmbMarkalar);
            this.panel11.Controls.Add(this.label2);
            this.panel11.Controls.Add(this.txtUrunKodu);
            this.panel11.Controls.Add(this.cmbKullanici);
            this.panel11.Controls.Add(this.txtRaf);
            this.panel11.Controls.Add(this.cmbSube);
            this.panel11.Controls.Add(this.label4);
            this.panel11.Controls.Add(this.label66);
            this.panel11.Controls.Add(this.cmbUrunAdi);
            this.panel11.Controls.Add(this.label67);
            this.panel11.Controls.Add(this.label68);
            this.panel11.Controls.Add(this.txtSeriNo);
            this.panel11.Controls.Add(this.label64);
            this.panel11.Controls.Add(this.txtStokkodu);
            this.panel11.Controls.Add(this.label63);
            this.panel11.Controls.Add(this.label69);
            this.panel11.Controls.Add(this.chkSilinen);
            this.panel11.Controls.Add(this.chkWebdeGosterilecek);
            this.panel11.Controls.Add(this.txtBarkod);
            this.panel11.Controls.Add(this.chkAktifmi);
            this.panel11.Controls.Add(this.chkindirimYapilanStokKartlari);
            this.panel11.Controls.Add(this.label3);
            this.panel11.Controls.Add(this.cmbKategori);
            this.panel11.Controls.Add(this.btnKategoriSec);
            this.panel11.Controls.Add(this.label23);
            this.panel11.Controls.Add(this.label49);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(738, 128);
            this.panel11.TabIndex = 3;
            this.panel11.TabStop = true;
            // 
            // chbCanliStok
            // 
            this.chbCanliStok.AutoSize = true;
            this.chbCanliStok.Location = new System.Drawing.Point(523, 68);
            this.chbCanliStok.Name = "chbCanliStok";
            this.chbCanliStok.Size = new System.Drawing.Size(129, 17);
            this.chbCanliStok.TabIndex = 75;
            this.chbCanliStok.Text = "Canlı Stoğu Görüntüle";
            this.chbCanliStok.UseVisualStyleBackColor = true;
            // 
            // cmbGecerliSatisFiyati
            // 
            this.cmbGecerliSatisFiyati.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGecerliSatisFiyati.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGecerliSatisFiyati.BackColor = System.Drawing.Color.White;
            this.cmbGecerliSatisFiyati.ForeColor = System.Drawing.Color.Black;
            this.cmbGecerliSatisFiyati.FormattingEnabled = true;
            this.cmbGecerliSatisFiyati.Location = new System.Drawing.Point(288, 61);
            this.cmbGecerliSatisFiyati.Name = "cmbGecerliSatisFiyati";
            this.cmbGecerliSatisFiyati.Size = new System.Drawing.Size(219, 21);
            this.cmbGecerliSatisFiyati.TabIndex = 73;
            this.cmbGecerliSatisFiyati.Tag = "001";
            this.cmbGecerliSatisFiyati.SelectedIndexChanged += new System.EventHandler(this.cmbGecerliSatisFiyati_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 74;
            this.label5.Text = "Fyt. Tipi";
            // 
            // btnexcelaktar
            // 
            this.btnexcelaktar.Location = new System.Drawing.Point(522, 89);
            this.btnexcelaktar.Name = "btnexcelaktar";
            this.btnexcelaktar.Size = new System.Drawing.Size(159, 23);
            this.btnexcelaktar.TabIndex = 72;
            this.btnexcelaktar.Text = "EXCELE AKTAR";
            this.btnexcelaktar.UseVisualStyleBackColor = true;
            this.btnexcelaktar.Click += new System.EventHandler(this.btnexcelaktar_Click);
            // 
            // cmbMarkalar
            // 
            this.cmbMarkalar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMarkalar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMarkalar.BackColor = System.Drawing.Color.White;
            this.cmbMarkalar.ForeColor = System.Drawing.Color.Black;
            this.cmbMarkalar.FormattingEnabled = true;
            this.cmbMarkalar.Location = new System.Drawing.Point(288, 42);
            this.cmbMarkalar.Name = "cmbMarkalar";
            this.cmbMarkalar.Size = new System.Drawing.Size(219, 21);
            this.cmbMarkalar.TabIndex = 11;
            this.cmbMarkalar.Tag = "001";
            this.cmbMarkalar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Marka";
            // 
            // txtUrunKodu
            // 
            this.txtUrunKodu.BackColor = System.Drawing.Color.White;
            this.txtUrunKodu.ForeColor = System.Drawing.Color.Black;
            this.txtUrunKodu.Location = new System.Drawing.Point(54, 82);
            this.txtUrunKodu.Name = "txtUrunKodu";
            this.txtUrunKodu.Size = new System.Drawing.Size(184, 20);
            this.txtUrunKodu.TabIndex = 7;
            this.txtUrunKodu.Tag = "001";
            this.txtUrunKodu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);
            // 
            // cmbKullanici
            // 
            this.cmbKullanici.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbKullanici.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbKullanici.BackColor = System.Drawing.Color.White;
            this.cmbKullanici.ForeColor = System.Drawing.Color.Black;
            this.cmbKullanici.FormattingEnabled = true;
            this.cmbKullanici.Location = new System.Drawing.Point(411, 103);
            this.cmbKullanici.Name = "cmbKullanici";
            this.cmbKullanici.Size = new System.Drawing.Size(96, 21);
            this.cmbKullanici.TabIndex = 16;
            this.cmbKullanici.Tag = "001";
            this.cmbKullanici.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);
            // 
            // txtRaf
            // 
            this.txtRaf.BackColor = System.Drawing.Color.White;
            this.txtRaf.ForeColor = System.Drawing.Color.Black;
            this.txtRaf.Location = new System.Drawing.Point(288, 83);
            this.txtRaf.Name = "txtRaf";
            this.txtRaf.Size = new System.Drawing.Size(219, 20);
            this.txtRaf.TabIndex = 14;
            this.txtRaf.Tag = "001";
            this.txtRaf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);
            // 
            // cmbSube
            // 
            this.cmbSube.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSube.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSube.BackColor = System.Drawing.Color.White;
            this.cmbSube.ForeColor = System.Drawing.Color.Black;
            this.cmbSube.FormattingEnabled = true;
            this.cmbSube.Location = new System.Drawing.Point(288, 103);
            this.cmbSube.Name = "cmbSube";
            this.cmbSube.Size = new System.Drawing.Size(80, 21);
            this.cmbSube.TabIndex = 15;
            this.cmbSube.Tag = "001";
            this.cmbSube.SelectedIndexChanged += new System.EventHandler(this.cmbSube_SelectedIndexChanged);
            this.cmbSube.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Raf";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(366, 107);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(46, 13);
            this.label66.TabIndex = 2;
            this.label66.Text = "Kullanıcı";
            // 
            // cmbUrunAdi
            // 
            this.cmbUrunAdi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUrunAdi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUrunAdi.BackColor = System.Drawing.Color.White;
            this.cmbUrunAdi.ForeColor = System.Drawing.Color.Black;
            this.cmbUrunAdi.FormattingEnabled = true;
            this.cmbUrunAdi.Location = new System.Drawing.Point(54, 41);
            this.cmbUrunAdi.Name = "cmbUrunAdi";
            this.cmbUrunAdi.Size = new System.Drawing.Size(184, 21);
            this.cmbUrunAdi.TabIndex = 5;
            this.cmbUrunAdi.Tag = "001";
            this.cmbUrunAdi.SelectedIndexChanged += new System.EventHandler(this.cmbUrunAdi_SelectedIndexChanged);
            this.cmbUrunAdi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(244, 107);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(32, 13);
            this.label67.TabIndex = 1;
            this.label67.Text = "Şube";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(-1, 44);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(51, 13);
            this.label68.TabIndex = 22;
            this.label68.Text = "Ürün İsmi";
            // 
            // txtSeriNo
            // 
            this.txtSeriNo.BackColor = System.Drawing.Color.White;
            this.txtSeriNo.ForeColor = System.Drawing.Color.Black;
            this.txtSeriNo.Location = new System.Drawing.Point(54, 102);
            this.txtSeriNo.Name = "txtSeriNo";
            this.txtSeriNo.Size = new System.Drawing.Size(184, 20);
            this.txtSeriNo.TabIndex = 8;
            this.txtSeriNo.Tag = "001";
            this.txtSeriNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(-1, 105);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(42, 13);
            this.label64.TabIndex = 24;
            this.label64.Text = "Seri No";
            // 
            // txtStokkodu
            // 
            this.txtStokkodu.BackColor = System.Drawing.Color.White;
            this.txtStokkodu.ForeColor = System.Drawing.Color.Black;
            this.txtStokkodu.Location = new System.Drawing.Point(54, 62);
            this.txtStokkodu.Name = "txtStokkodu";
            this.txtStokkodu.Size = new System.Drawing.Size(184, 20);
            this.txtStokkodu.TabIndex = 6;
            this.txtStokkodu.Tag = "001";
            this.txtStokkodu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(-1, 65);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(54, 13);
            this.label63.TabIndex = 26;
            this.label63.Text = "StokKodu";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(-1, 24);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(41, 13);
            this.label69.TabIndex = 20;
            this.label69.Text = "Barkod";
            // 
            // chkSilinen
            // 
            this.chkSilinen.AutoSize = true;
            this.chkSilinen.Location = new System.Drawing.Point(523, 52);
            this.chkSilinen.Name = "chkSilinen";
            this.chkSilinen.Size = new System.Drawing.Size(159, 17);
            this.chkSilinen.TabIndex = 19;
            this.chkSilinen.Text = "Silinen Stok Kartlarını Göster";
            this.chkSilinen.UseVisualStyleBackColor = true;
            // 
            // chkWebdeGosterilecek
            // 
            this.chkWebdeGosterilecek.AutoSize = true;
            this.chkWebdeGosterilecek.Location = new System.Drawing.Point(523, 36);
            this.chkWebdeGosterilecek.Name = "chkWebdeGosterilecek";
            this.chkWebdeGosterilecek.Size = new System.Drawing.Size(217, 17);
            this.chkWebdeGosterilecek.TabIndex = 18;
            this.chkWebdeGosterilecek.Text = "Webde Gösterilecek Stok Kartları Göster";
            this.chkWebdeGosterilecek.UseVisualStyleBackColor = true;
            // 
            // txtBarkod
            // 
            this.txtBarkod.BackColor = System.Drawing.Color.White;
            this.txtBarkod.ForeColor = System.Drawing.Color.Black;
            this.txtBarkod.Location = new System.Drawing.Point(54, 21);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(184, 20);
            this.txtBarkod.TabIndex = 4;
            this.txtBarkod.Tag = "001";
            this.txtBarkod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);
            // 
            // chkAktifmi
            // 
            this.chkAktifmi.AutoSize = true;
            this.chkAktifmi.Location = new System.Drawing.Point(523, 20);
            this.chkAktifmi.Name = "chkAktifmi";
            this.chkAktifmi.Size = new System.Drawing.Size(193, 17);
            this.chkAktifmi.TabIndex = 17;
            this.chkAktifmi.Text = "Aktif Olmayan Stok Kartlarını Göster";
            this.chkAktifmi.UseVisualStyleBackColor = true;
            // 
            // chkindirimYapilanStokKartlari
            // 
            this.chkindirimYapilanStokKartlari.AutoSize = true;
            this.chkindirimYapilanStokKartlari.Location = new System.Drawing.Point(523, 19);
            this.chkindirimYapilanStokKartlari.Name = "chkindirimYapilanStokKartlari";
            this.chkindirimYapilanStokKartlari.Size = new System.Drawing.Size(196, 17);
            this.chkindirimYapilanStokKartlari.TabIndex = 43;
            this.chkindirimYapilanStokKartlari.Text = "İndirim Yapılan Stok Kartlarını Göster";
            this.chkindirimYapilanStokKartlari.UseVisualStyleBackColor = true;
            this.chkindirimYapilanStokKartlari.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Ürün Kodu";
            // 
            // cmbKategori
            // 
            this.cmbKategori.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbKategori.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbKategori.BackColor = System.Drawing.Color.White;
            this.cmbKategori.ForeColor = System.Drawing.Color.Black;
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(288, 20);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(193, 21);
            this.cmbKategori.TabIndex = 9;
            this.cmbKategori.Tag = "001";
            this.cmbKategori.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);
            // 
            // btnKategoriSec
            // 
            this.btnKategoriSec.Location = new System.Drawing.Point(483, 18);
            this.btnKategoriSec.Name = "btnKategoriSec";
            this.btnKategoriSec.Size = new System.Drawing.Size(24, 23);
            this.btnKategoriSec.TabIndex = 10;
            this.btnKategoriSec.Text = "...";
            this.btnKategoriSec.UseVisualStyleBackColor = false;
            this.btnKategoriSec.Click += new System.EventHandler(this.btnKategoriSec_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(244, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(46, 13);
            this.label23.TabIndex = 41;
            this.label23.Text = "Kategori";
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.Color.White;
            this.label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label49.Dock = System.Windows.Forms.DockStyle.Top;
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label49.Location = new System.Drawing.Point(0, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(736, 17);
            this.label49.TabIndex = 0;
            this.label49.Text = "Filtre Seçenekleri";
            this.label49.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbKdv
            // 
            this.cmbKdv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbKdv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbKdv.BackColor = System.Drawing.Color.White;
            this.cmbKdv.ForeColor = System.Drawing.Color.Black;
            this.cmbKdv.FormattingEnabled = true;
            this.cmbKdv.Items.AddRange(new object[] {
            "0",
            "1",
            "8",
            "18"});
            this.cmbKdv.Location = new System.Drawing.Point(844, 5);
            this.cmbKdv.Name = "cmbKdv";
            this.cmbKdv.Size = new System.Drawing.Size(64, 21);
            this.cmbKdv.TabIndex = 12;
            this.cmbKdv.Tag = "001";
            this.cmbKdv.Visible = false;
            this.cmbKdv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);
            // 
            // cmbKdvTipi
            // 
            this.cmbKdvTipi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbKdvTipi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbKdvTipi.BackColor = System.Drawing.Color.White;
            this.cmbKdvTipi.ForeColor = System.Drawing.Color.Black;
            this.cmbKdvTipi.FormattingEnabled = true;
            this.cmbKdvTipi.Items.AddRange(new object[] {
            "Dahil",
            "Hariç"});
            this.cmbKdvTipi.Location = new System.Drawing.Point(836, 25);
            this.cmbKdvTipi.Name = "cmbKdvTipi";
            this.cmbKdvTipi.Size = new System.Drawing.Size(72, 21);
            this.cmbKdvTipi.TabIndex = 13;
            this.cmbKdvTipi.Tag = "001";
            this.cmbKdvTipi.Visible = false;
            this.cmbKdvTipi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(854, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "KDV";
            this.label1.Visible = false;
            // 
            // stokid
            // 
            this.stokid.HeaderText = "stokid";
            this.stokid.Name = "stokid";
            this.stokid.ReadOnly = true;
            this.stokid.Visible = false;
            this.stokid.Width = 41;
            // 
            // stokkodu
            // 
            this.stokkodu.HeaderText = "St.Kod";
            this.stokkodu.Name = "stokkodu";
            this.stokkodu.ReadOnly = true;
            this.stokkodu.Width = 64;
            // 
            // rfidEtiketi
            // 
            this.rfidEtiketi.HeaderText = "rfidEtiketi";
            this.rfidEtiketi.Name = "rfidEtiketi";
            this.rfidEtiketi.ReadOnly = true;
            this.rfidEtiketi.Visible = false;
            this.rfidEtiketi.Width = 75;
            // 
            // barkod1
            // 
            this.barkod1.HeaderText = "Barkod";
            this.barkod1.Name = "barkod1";
            this.barkod1.ReadOnly = true;
            this.barkod1.Width = 66;
            // 
            // urunAdi
            // 
            this.urunAdi.HeaderText = "Ürün Adı";
            this.urunAdi.Name = "urunAdi";
            this.urunAdi.ReadOnly = true;
            this.urunAdi.Width = 73;
            // 
            // alisFiyat
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "n2";
            this.alisFiyat.DefaultCellStyle = dataGridViewCellStyle1;
            this.alisFiyat.HeaderText = "Alış F.";
            this.alisFiyat.Name = "alisFiyat";
            this.alisFiyat.ReadOnly = true;
            this.alisFiyat.Width = 60;
            // 
            // satisFiyat1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "n2";
            this.satisFiyat1.DefaultCellStyle = dataGridViewCellStyle2;
            this.satisFiyat1.HeaderText = "Satış F.";
            this.satisFiyat1.Name = "satisFiyat1";
            this.satisFiyat1.ReadOnly = true;
            this.satisFiyat1.Width = 67;
            // 
            // kdv
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.kdv.DefaultCellStyle = dataGridViewCellStyle3;
            this.kdv.HeaderText = "KDV";
            this.kdv.Name = "kdv";
            this.kdv.ReadOnly = true;
            this.kdv.Width = 54;
            // 
            // kdvTipi
            // 
            this.kdvTipi.HeaderText = "Tipi";
            this.kdvTipi.Name = "kdvTipi";
            this.kdvTipi.ReadOnly = true;
            this.kdvTipi.Width = 49;
            // 
            // katNo
            // 
            this.katNo.HeaderText = "katNo";
            this.katNo.Name = "katNo";
            this.katNo.ReadOnly = true;
            this.katNo.Visible = false;
            this.katNo.Width = 61;
            // 
            // CanliStok
            // 
            this.CanliStok.HeaderText = "Canlı Stok";
            this.CanliStok.Name = "CanliStok";
            this.CanliStok.ReadOnly = true;
            this.CanliStok.Visible = false;
            this.CanliStok.Width = 80;
            // 
            // kategoriAdi
            // 
            this.kategoriAdi.HeaderText = "Kategori";
            this.kategoriAdi.Name = "kategoriAdi";
            this.kategoriAdi.ReadOnly = true;
            this.kategoriAdi.Width = 71;
            // 
            // urunKodu
            // 
            this.urunKodu.HeaderText = "UrunKod";
            this.urunKodu.Name = "urunKodu";
            this.urunKodu.ReadOnly = true;
            this.urunKodu.Width = 74;
            // 
            // garantiSuresi
            // 
            this.garantiSuresi.HeaderText = "Garanti";
            this.garantiSuresi.Name = "garantiSuresi";
            this.garantiSuresi.ReadOnly = true;
            this.garantiSuresi.Visible = false;
            this.garantiSuresi.Width = 66;
            // 
            // markaid
            // 
            this.markaid.HeaderText = "markaid";
            this.markaid.Name = "markaid";
            this.markaid.ReadOnly = true;
            this.markaid.Visible = false;
            this.markaid.Width = 69;
            // 
            // markaAdi
            // 
            this.markaAdi.HeaderText = "Marka";
            this.markaAdi.Name = "markaAdi";
            this.markaAdi.ReadOnly = true;
            this.markaAdi.Width = 62;
            // 
            // rafAdi
            // 
            this.rafAdi.HeaderText = "Raf";
            this.rafAdi.Name = "rafAdi";
            this.rafAdi.ReadOnly = true;
            this.rafAdi.Width = 49;
            // 
            // ayrinti
            // 
            this.ayrinti.HeaderText = "Ayrıntı";
            this.ayrinti.Name = "ayrinti";
            this.ayrinti.ReadOnly = true;
            this.ayrinti.Width = 60;
            // 
            // aktifmi
            // 
            this.aktifmi.HeaderText = "Aktifmi";
            this.aktifmi.Name = "aktifmi";
            this.aktifmi.ReadOnly = true;
            this.aktifmi.Width = 63;
            // 
            // Mobil
            // 
            this.Mobil.HeaderText = "Mobil";
            this.Mobil.Name = "Mobil";
            this.Mobil.ReadOnly = true;
            this.Mobil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Mobil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Mobil.Width = 57;
            // 
            // Vitrin
            // 
            this.Vitrin.HeaderText = "Vitrin";
            this.Vitrin.Name = "Vitrin";
            this.Vitrin.ReadOnly = true;
            this.Vitrin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Vitrin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Vitrin.Width = 55;
            // 
            // eklenmeTarihi
            // 
            this.eklenmeTarihi.HeaderText = "Eklenme T.";
            this.eklenmeTarihi.Name = "eklenmeTarihi";
            this.eklenmeTarihi.ReadOnly = true;
            this.eklenmeTarihi.Width = 86;
            // 
            // silindimi
            // 
            this.silindimi.HeaderText = "Silindimi";
            this.silindimi.Name = "silindimi";
            this.silindimi.ReadOnly = true;
            this.silindimi.Width = 69;
            // 
            // frmStokKartlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 557);
            this.Controls.Add(this.dgStokKart);
            this.Controls.Add(this.panel14);
            this.Name = "frmStokKartlari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Stok Kart Görüntüle";
            this.Load += new System.EventHandler(this.frmStokKartlari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgStokKart)).EndInit();
            this.cnsStokkart.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgStokKart;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Button btnRaporGoruntule;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.ComboBox cmbKdvTipi;
        private System.Windows.Forms.ComboBox cmbKdv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStokkodu;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.TextBox txtSeriNo;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.ComboBox cmbUrunAdi;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.ComboBox cmbKullanici;
        private System.Windows.Forms.ComboBox cmbSube;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox txtRaf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkSilinen;
        private System.Windows.Forms.CheckBox chkWebdeGosterilecek;
        private System.Windows.Forms.CheckBox chkAktifmi;
        private System.Windows.Forms.CheckBox chkindirimYapilanStokKartlari;
        private System.Windows.Forms.TextBox txtUrunKodu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnKategoriSec;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblKayitSayisi;
        private System.Windows.Forms.ContextMenuStrip cnsStokkart;
        private System.Windows.Forms.ToolStripMenuItem stokKartınıSilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silmeİşleminiGeriAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokKartınıPasifYapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokKartınıAktifYapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webdeGösterilsinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webdeGösterilmesinToolStripMenuItem;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.ComboBox cmbMarkalar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem listeyiYenileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barkoduYazdırToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayrıntılıDüzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokKartDetaylarınıGösterToolStripMenuItem;
        public System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.Button btnBarkodYazdir;
        private System.Windows.Forms.ToolStripMenuItem raporGörüntüleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVitrin;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMobil;
        private System.Windows.Forms.Button btnexcelaktar;
        private System.Windows.Forms.ComboBox cmbGecerliSatisFiyati;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbCanliStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokid;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokkodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn rfidEtiketi;
        private System.Windows.Forms.DataGridViewTextBoxColumn barkod1;
        private System.Windows.Forms.DataGridViewTextBoxColumn urunAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn alisFiyat;
        private System.Windows.Forms.DataGridViewTextBoxColumn satisFiyat1;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdvTipi;
        private System.Windows.Forms.DataGridViewTextBoxColumn katNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CanliStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn kategoriAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn urunKodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn garantiSuresi;
        private System.Windows.Forms.DataGridViewTextBoxColumn markaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn markaAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn rafAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ayrinti;
        private System.Windows.Forms.DataGridViewTextBoxColumn aktifmi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Mobil;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Vitrin;
        private System.Windows.Forms.DataGridViewTextBoxColumn eklenmeTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn silindimi;
    }
}