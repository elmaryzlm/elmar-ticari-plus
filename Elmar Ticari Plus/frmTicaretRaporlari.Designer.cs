namespace Elmar_Ticari_Plus
{
    partial class frmTicaretRaporlari
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgTicaretRapor = new System.Windows.Forms.DataGridView();
            this.ticaretAyrintiid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Durumu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cariid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adiSoyadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.odemeTuru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.islemTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.islemTuru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AraTop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KdvTop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iskonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yuzdeisk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nakliyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iscilik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenelToplam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fiiliSevkTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faturaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.belgeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.irsaliyeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vergiDaire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vergiNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faturaAciklamasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.islemAciklamasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hesabaislendimi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eklenmeTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subeid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kullaniciid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnsStokkart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.işlemiDüzenleGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kayıdaAitÜrünleriGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.işlemiSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silmeİşleminiGeriAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.işlemiDondurKasayaİşlemezToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dondurmaİşleminiGeriAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.faturayıİptalEtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eFaturayıKabulEtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eFaturayıRedEtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eFaturayıYazdırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlAlt = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label70 = new System.Windows.Forms.Label();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.btnYazdir = new System.Windows.Forms.Button();
            this.btnRaporGoruntule = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.chbEFatura = new System.Windows.Forms.CheckBox();
            this.cmbIslemTipi = new System.Windows.Forms.ComboBox();
            this.lblYapilacakIslem = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.chkSilinenKayitlariGoster = new System.Windows.Forms.CheckBox();
            this.chkWebKayitlariniGoster = new System.Windows.Forms.CheckBox();
            this.chkHesabaİslenmeyenKayitlariGoster = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabİslemTuruneGore = new System.Windows.Forms.TabPage();
            this.chbKesilenFaturalar = new System.Windows.Forms.CheckBox();
            this.chkStokTransferi = new System.Windows.Forms.CheckBox();
            this.chbIptalEdilenFaturalar = new System.Windows.Forms.CheckBox();
            this.grpİslemTipi = new System.Windows.Forms.GroupBox();
            this.chkDigerİslemler = new System.Windows.Forms.CheckBox();
            this.chkİadeİslemleri = new System.Windows.Forms.CheckBox();
            this.chkFaturaliİslemler = new System.Windows.Forms.CheckBox();
            this.grpOdemeTipi = new System.Windows.Forms.GroupBox();
            this.chkKrediKarti = new System.Windows.Forms.CheckBox();
            this.chkSenet = new System.Windows.Forms.CheckBox();
            this.chkPesin = new System.Windows.Forms.CheckBox();
            this.chkCek = new System.Windows.Forms.CheckBox();
            this.chkAcikHesap = new System.Windows.Forms.CheckBox();
            this.chkTaksit = new System.Windows.Forms.CheckBox();
            this.tabBelgeyeGore = new System.Windows.Forms.TabPage();
            this.grpBelgeNumarası = new System.Windows.Forms.GroupBox();
            this.txtİrsaliyeNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBelgeNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFaturaNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpİslemTarihi = new System.Windows.Forms.GroupBox();
            this.dtİslemTarihi2 = new System.Windows.Forms.DateTimePicker();
            this.dtİslemTarihi1 = new System.Windows.Forms.DateTimePicker();
            this.label56 = new System.Windows.Forms.Label();
            this.chkİslemTarihi = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.cmbKullanicilar = new System.Windows.Forms.ComboBox();
            this.cmbSubeler = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.lblToplamIskonto = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.lblBakiyeF = new System.Windows.Forms.Label();
            this.lblKayitSayisiF = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgTicaretRapor)).BeginInit();
            this.cnsStokkart.SuspendLayout();
            this.pnlAlt.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel12.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabİslemTuruneGore.SuspendLayout();
            this.grpİslemTipi.SuspendLayout();
            this.grpOdemeTipi.SuspendLayout();
            this.tabBelgeyeGore.SuspendLayout();
            this.grpBelgeNumarası.SuspendLayout();
            this.grpİslemTarihi.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.panel18.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 10);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // dgTicaretRapor
            // 
            this.dgTicaretRapor.AllowUserToAddRows = false;
            this.dgTicaretRapor.AllowUserToDeleteRows = false;
            this.dgTicaretRapor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgTicaretRapor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTicaretRapor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ticaretAyrintiid,
            this.Durumu,
            this.cariid,
            this.adiSoyadi,
            this.odemeTuru,
            this.islemTarihi,
            this.islemTuru,
            this.AraTop,
            this.KdvTop,
            this.iskonto,
            this.yuzdeisk,
            this.nakliyat,
            this.iscilik,
            this.GenelToplam,
            this.fiiliSevkTarihi,
            this.faturaNo,
            this.belgeNo,
            this.irsaliyeNo,
            this.vergiDaire,
            this.vergiNo,
            this.adres,
            this.faturaAciklamasi,
            this.islemAciklamasi,
            this.hesabaislendimi,
            this.onay,
            this.eklenmeTarihi,
            this.subeid,
            this.kullaniciid});
            this.dgTicaretRapor.ContextMenuStrip = this.cnsStokkart;
            this.dgTicaretRapor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTicaretRapor.Location = new System.Drawing.Point(0, 10);
            this.dgTicaretRapor.MultiSelect = false;
            this.dgTicaretRapor.Name = "dgTicaretRapor";
            this.dgTicaretRapor.ReadOnly = true;
            this.dgTicaretRapor.RowHeadersWidth = 20;
            this.dgTicaretRapor.RowTemplate.Height = 20;
            this.dgTicaretRapor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTicaretRapor.Size = new System.Drawing.Size(1044, 369);
            this.dgTicaretRapor.TabIndex = 2;
            this.dgTicaretRapor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTicaretRapor_CellContentClick);
            this.dgTicaretRapor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTicaretRapor_CellDoubleClick);
            this.dgTicaretRapor.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgTicaretRapor_RowsAdded);
            this.dgTicaretRapor.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgTicaretRapor_UserAddedRow);
            // 
            // ticaretAyrintiid
            // 
            this.ticaretAyrintiid.HeaderText = "T. ID";
            this.ticaretAyrintiid.Name = "ticaretAyrintiid";
            this.ticaretAyrintiid.ReadOnly = true;
            this.ticaretAyrintiid.Width = 56;
            // 
            // Durumu
            // 
            this.Durumu.HeaderText = "Durumu";
            this.Durumu.Name = "Durumu";
            this.Durumu.ReadOnly = true;
            this.Durumu.Width = 69;
            // 
            // cariid
            // 
            this.cariid.HeaderText = "cariid";
            this.cariid.Name = "cariid";
            this.cariid.ReadOnly = true;
            this.cariid.Visible = false;
            this.cariid.Width = 57;
            // 
            // adiSoyadi
            // 
            this.adiSoyadi.HeaderText = "Cari Adı";
            this.adiSoyadi.Name = "adiSoyadi";
            this.adiSoyadi.ReadOnly = true;
            this.adiSoyadi.Width = 68;
            // 
            // odemeTuru
            // 
            this.odemeTuru.HeaderText = "Ödeme Türü";
            this.odemeTuru.Name = "odemeTuru";
            this.odemeTuru.ReadOnly = true;
            this.odemeTuru.Width = 91;
            // 
            // islemTarihi
            // 
            dataGridViewCellStyle1.NullValue = null;
            this.islemTarihi.DefaultCellStyle = dataGridViewCellStyle1;
            this.islemTarihi.HeaderText = "İşlem Tarihi";
            this.islemTarihi.Name = "islemTarihi";
            this.islemTarihi.ReadOnly = true;
            this.islemTarihi.Width = 85;
            // 
            // islemTuru
            // 
            this.islemTuru.HeaderText = "İşlem Türü";
            this.islemTuru.Name = "islemTuru";
            this.islemTuru.ReadOnly = true;
            this.islemTuru.Width = 81;
            // 
            // AraTop
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = "0";
            this.AraTop.DefaultCellStyle = dataGridViewCellStyle2;
            this.AraTop.HeaderText = "AraTop";
            this.AraTop.Name = "AraTop";
            this.AraTop.ReadOnly = true;
            this.AraTop.Width = 67;
            // 
            // KdvTop
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = "0";
            this.KdvTop.DefaultCellStyle = dataGridViewCellStyle3;
            this.KdvTop.HeaderText = "KdvTop";
            this.KdvTop.Name = "KdvTop";
            this.KdvTop.ReadOnly = true;
            this.KdvTop.Width = 70;
            // 
            // iskonto
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.NullValue = "0";
            this.iskonto.DefaultCellStyle = dataGridViewCellStyle4;
            this.iskonto.HeaderText = "TL Top Isk";
            this.iskonto.Name = "iskonto";
            this.iskonto.ReadOnly = true;
            this.iskonto.Width = 84;
            // 
            // yuzdeisk
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "n2";
            dataGridViewCellStyle5.NullValue = "0";
            this.yuzdeisk.DefaultCellStyle = dataGridViewCellStyle5;
            this.yuzdeisk.HeaderText = "% Top Isk";
            this.yuzdeisk.Name = "yuzdeisk";
            this.yuzdeisk.ReadOnly = true;
            this.yuzdeisk.Width = 79;
            // 
            // nakliyat
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.NullValue = "0";
            this.nakliyat.DefaultCellStyle = dataGridViewCellStyle6;
            this.nakliyat.HeaderText = "Nakliyat";
            this.nakliyat.Name = "nakliyat";
            this.nakliyat.ReadOnly = true;
            this.nakliyat.Width = 70;
            // 
            // iscilik
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.NullValue = "0";
            this.iscilik.DefaultCellStyle = dataGridViewCellStyle7;
            this.iscilik.HeaderText = "İşcilik";
            this.iscilik.Name = "iscilik";
            this.iscilik.ReadOnly = true;
            this.iscilik.Width = 58;
            // 
            // GenelToplam
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle8.NullValue = "0";
            this.GenelToplam.DefaultCellStyle = dataGridViewCellStyle8;
            this.GenelToplam.HeaderText = "Genel Top";
            this.GenelToplam.Name = "GenelToplam";
            this.GenelToplam.ReadOnly = true;
            this.GenelToplam.Width = 82;
            // 
            // fiiliSevkTarihi
            // 
            this.fiiliSevkTarihi.HeaderText = "fiiliSevkTarihi";
            this.fiiliSevkTarihi.Name = "fiiliSevkTarihi";
            this.fiiliSevkTarihi.ReadOnly = true;
            this.fiiliSevkTarihi.Visible = false;
            this.fiiliSevkTarihi.Width = 94;
            // 
            // faturaNo
            // 
            this.faturaNo.HeaderText = "Fatura No";
            this.faturaNo.Name = "faturaNo";
            this.faturaNo.ReadOnly = true;
            this.faturaNo.Width = 79;
            // 
            // belgeNo
            // 
            this.belgeNo.HeaderText = "Belge No";
            this.belgeNo.Name = "belgeNo";
            this.belgeNo.ReadOnly = true;
            this.belgeNo.Width = 76;
            // 
            // irsaliyeNo
            // 
            this.irsaliyeNo.HeaderText = "İrsaliye No";
            this.irsaliyeNo.Name = "irsaliyeNo";
            this.irsaliyeNo.ReadOnly = true;
            this.irsaliyeNo.Width = 81;
            // 
            // vergiDaire
            // 
            this.vergiDaire.HeaderText = "VD";
            this.vergiDaire.Name = "vergiDaire";
            this.vergiDaire.ReadOnly = true;
            this.vergiDaire.Visible = false;
            this.vergiDaire.Width = 47;
            // 
            // vergiNo
            // 
            this.vergiNo.HeaderText = "VN";
            this.vergiNo.Name = "vergiNo";
            this.vergiNo.ReadOnly = true;
            this.vergiNo.Visible = false;
            this.vergiNo.Width = 47;
            // 
            // adres
            // 
            this.adres.HeaderText = "Adres";
            this.adres.Name = "adres";
            this.adres.ReadOnly = true;
            this.adres.Visible = false;
            this.adres.Width = 59;
            // 
            // faturaAciklamasi
            // 
            this.faturaAciklamasi.HeaderText = "Fatura Açıklaması";
            this.faturaAciklamasi.Name = "faturaAciklamasi";
            this.faturaAciklamasi.ReadOnly = true;
            this.faturaAciklamasi.Visible = false;
            this.faturaAciklamasi.Width = 115;
            // 
            // islemAciklamasi
            // 
            this.islemAciklamasi.HeaderText = "İ.Açıklaması";
            this.islemAciklamasi.Name = "islemAciklamasi";
            this.islemAciklamasi.ReadOnly = true;
            this.islemAciklamasi.Width = 88;
            // 
            // hesabaislendimi
            // 
            this.hesabaislendimi.HeaderText = "Aktifmi";
            this.hesabaislendimi.Name = "hesabaislendimi";
            this.hesabaislendimi.ReadOnly = true;
            this.hesabaislendimi.Width = 63;
            // 
            // onay
            // 
            this.onay.HeaderText = "Onay";
            this.onay.Name = "onay";
            this.onay.ReadOnly = true;
            this.onay.Width = 57;
            // 
            // eklenmeTarihi
            // 
            this.eklenmeTarihi.HeaderText = "eklenmeTarihi";
            this.eklenmeTarihi.Name = "eklenmeTarihi";
            this.eklenmeTarihi.ReadOnly = true;
            this.eklenmeTarihi.Visible = false;
            this.eklenmeTarihi.Width = 98;
            // 
            // subeid
            // 
            this.subeid.HeaderText = "subeid";
            this.subeid.Name = "subeid";
            this.subeid.ReadOnly = true;
            this.subeid.Visible = false;
            this.subeid.Width = 63;
            // 
            // kullaniciid
            // 
            this.kullaniciid.HeaderText = "kullaniciid";
            this.kullaniciid.Name = "kullaniciid";
            this.kullaniciid.ReadOnly = true;
            this.kullaniciid.Visible = false;
            this.kullaniciid.Width = 78;
            // 
            // cnsStokkart
            // 
            this.cnsStokkart.BackColor = System.Drawing.Color.Gainsboro;
            this.cnsStokkart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.işlemiDüzenleGörüntüleToolStripMenuItem,
            this.kayıdaAitÜrünleriGörüntüleToolStripMenuItem,
            this.toolStripSeparator1,
            this.işlemiSilToolStripMenuItem,
            this.silmeİşleminiGeriAlToolStripMenuItem,
            this.işlemiDondurKasayaİşlemezToolStripMenuItem,
            this.dondurmaİşleminiGeriAlToolStripMenuItem,
            this.faturayıİptalEtToolStripMenuItem,
            this.eFaturayıKabulEtToolStripMenuItem,
            this.eFaturayıRedEtToolStripMenuItem,
            this.eFaturayıYazdırToolStripMenuItem});
            this.cnsStokkart.Name = "cnsStokkart";
            this.cnsStokkart.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cnsStokkart.Size = new System.Drawing.Size(372, 230);
            // 
            // işlemiDüzenleGörüntüleToolStripMenuItem
            // 
            this.işlemiDüzenleGörüntüleToolStripMenuItem.Name = "işlemiDüzenleGörüntüleToolStripMenuItem";
            this.işlemiDüzenleGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(371, 22);
            this.işlemiDüzenleGörüntüleToolStripMenuItem.Text = "İşlemi Düzenle/ Görüntüle";
            this.işlemiDüzenleGörüntüleToolStripMenuItem.Click += new System.EventHandler(this.işlemiDüzenleGörüntüleToolStripMenuItem_Click);
            // 
            // kayıdaAitÜrünleriGörüntüleToolStripMenuItem
            // 
            this.kayıdaAitÜrünleriGörüntüleToolStripMenuItem.Name = "kayıdaAitÜrünleriGörüntüleToolStripMenuItem";
            this.kayıdaAitÜrünleriGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(371, 22);
            this.kayıdaAitÜrünleriGörüntüleToolStripMenuItem.Text = "Kayıda ait Ürünleri Görüntüle";
            this.kayıdaAitÜrünleriGörüntüleToolStripMenuItem.Click += new System.EventHandler(this.kayıdaAitÜrünleriGörüntüleToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(368, 6);
            // 
            // işlemiSilToolStripMenuItem
            // 
            this.işlemiSilToolStripMenuItem.Name = "işlemiSilToolStripMenuItem";
            this.işlemiSilToolStripMenuItem.Size = new System.Drawing.Size(371, 22);
            this.işlemiSilToolStripMenuItem.Text = "İşlemi Sil";
            this.işlemiSilToolStripMenuItem.Click += new System.EventHandler(this.işlemiSilToolStripMenuItem_Click);
            // 
            // silmeİşleminiGeriAlToolStripMenuItem
            // 
            this.silmeİşleminiGeriAlToolStripMenuItem.Name = "silmeİşleminiGeriAlToolStripMenuItem";
            this.silmeİşleminiGeriAlToolStripMenuItem.Size = new System.Drawing.Size(371, 22);
            this.silmeİşleminiGeriAlToolStripMenuItem.Text = "Silme İşlemini Geri Al";
            this.silmeİşleminiGeriAlToolStripMenuItem.Click += new System.EventHandler(this.silmeİşleminiGeriAlToolStripMenuItem_Click);
            // 
            // işlemiDondurKasayaİşlemezToolStripMenuItem
            // 
            this.işlemiDondurKasayaİşlemezToolStripMenuItem.Name = "işlemiDondurKasayaİşlemezToolStripMenuItem";
            this.işlemiDondurKasayaİşlemezToolStripMenuItem.Size = new System.Drawing.Size(371, 22);
            this.işlemiDondurKasayaİşlemezToolStripMenuItem.Text = "İşlemi Hesaba İşlensin Olarak Ayarla (Kasaya Yansır)";
            this.işlemiDondurKasayaİşlemezToolStripMenuItem.Click += new System.EventHandler(this.işlemiDondurKasayaİşlemezToolStripMenuItem_Click);
            // 
            // dondurmaİşleminiGeriAlToolStripMenuItem
            // 
            this.dondurmaİşleminiGeriAlToolStripMenuItem.Name = "dondurmaİşleminiGeriAlToolStripMenuItem";
            this.dondurmaİşleminiGeriAlToolStripMenuItem.Size = new System.Drawing.Size(371, 22);
            this.dondurmaİşleminiGeriAlToolStripMenuItem.Text = "İşlemi Hesaba İşlenmesi Olarak Ayarla (Kasaya yansımaz)";
            this.dondurmaİşleminiGeriAlToolStripMenuItem.Click += new System.EventHandler(this.dondurmaİşleminiGeriAlToolStripMenuItem_Click);
            // 
            // faturayıİptalEtToolStripMenuItem
            // 
            this.faturayıİptalEtToolStripMenuItem.Name = "faturayıİptalEtToolStripMenuItem";
            this.faturayıİptalEtToolStripMenuItem.Size = new System.Drawing.Size(371, 22);
            this.faturayıİptalEtToolStripMenuItem.Text = "Faturayı İptal Et";
            this.faturayıİptalEtToolStripMenuItem.Click += new System.EventHandler(this.faturayıİptalEtToolStripMenuItem_Click);
            // 
            // eFaturayıKabulEtToolStripMenuItem
            // 
            this.eFaturayıKabulEtToolStripMenuItem.Name = "eFaturayıKabulEtToolStripMenuItem";
            this.eFaturayıKabulEtToolStripMenuItem.Size = new System.Drawing.Size(371, 22);
            this.eFaturayıKabulEtToolStripMenuItem.Text = "E-Faturayı Kabul Et";
            this.eFaturayıKabulEtToolStripMenuItem.Click += new System.EventHandler(this.eFaturayıKabulEtToolStripMenuItem_Click);
            // 
            // eFaturayıRedEtToolStripMenuItem
            // 
            this.eFaturayıRedEtToolStripMenuItem.Name = "eFaturayıRedEtToolStripMenuItem";
            this.eFaturayıRedEtToolStripMenuItem.Size = new System.Drawing.Size(371, 22);
            this.eFaturayıRedEtToolStripMenuItem.Text = "E-Faturayı Red Et";
            // 
            // eFaturayıYazdırToolStripMenuItem
            // 
            this.eFaturayıYazdırToolStripMenuItem.Name = "eFaturayıYazdırToolStripMenuItem";
            this.eFaturayıYazdırToolStripMenuItem.Size = new System.Drawing.Size(371, 22);
            this.eFaturayıYazdırToolStripMenuItem.Text = "E-Faturayı Yazdır";
            this.eFaturayıYazdırToolStripMenuItem.Click += new System.EventHandler(this.eFaturayıYazdırToolStripMenuItem_Click);
            // 
            // pnlAlt
            // 
            this.pnlAlt.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlAlt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlt.Controls.Add(this.panel16);
            this.pnlAlt.Controls.Add(this.panel12);
            this.pnlAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlt.Location = new System.Drawing.Point(0, 399);
            this.pnlAlt.Name = "pnlAlt";
            this.pnlAlt.Size = new System.Drawing.Size(1044, 150);
            this.pnlAlt.TabIndex = 5;
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.label70);
            this.panel16.Controls.Add(this.btnSorgula);
            this.panel16.Controls.Add(this.btnYazdir);
            this.panel16.Controls.Add(this.btnRaporGoruntule);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(776, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(102, 148);
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
            // btnSorgula
            // 
            this.btnSorgula.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSorgula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSorgula.Location = new System.Drawing.Point(3, 22);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(95, 24);
            this.btnSorgula.TabIndex = 52;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = false;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // btnYazdir
            // 
            this.btnYazdir.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnYazdir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYazdir.Location = new System.Drawing.Point(3, 93);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(95, 27);
            this.btnYazdir.TabIndex = 49;
            this.btnYazdir.Text = "Yazdır";
            this.btnYazdir.UseVisualStyleBackColor = false;
            this.btnYazdir.Click += new System.EventHandler(this.btnYazdir_Click);
            // 
            // btnRaporGoruntule
            // 
            this.btnRaporGoruntule.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRaporGoruntule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporGoruntule.Location = new System.Drawing.Point(3, 47);
            this.btnRaporGoruntule.Name = "btnRaporGoruntule";
            this.btnRaporGoruntule.Size = new System.Drawing.Size(95, 44);
            this.btnRaporGoruntule.TabIndex = 47;
            this.btnRaporGoruntule.Text = "Rapor Görüntüle";
            this.btnRaporGoruntule.UseVisualStyleBackColor = false;
            this.btnRaporGoruntule.Click += new System.EventHandler(this.btnRaporGoruntule_Click);
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.chbEFatura);
            this.panel12.Controls.Add(this.cmbIslemTipi);
            this.panel12.Controls.Add(this.lblYapilacakIslem);
            this.panel12.Controls.Add(this.label54);
            this.panel12.Controls.Add(this.chkSilinenKayitlariGoster);
            this.panel12.Controls.Add(this.chkWebKayitlariniGoster);
            this.panel12.Controls.Add(this.chkHesabaİslenmeyenKayitlariGoster);
            this.panel12.Controls.Add(this.tabControl1);
            this.panel12.Controls.Add(this.grpİslemTarihi);
            this.panel12.Controls.Add(this.groupBox9);
            this.panel12.Controls.Add(this.label4);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(776, 148);
            this.panel12.TabIndex = 12;
            this.panel12.Paint += new System.Windows.Forms.PaintEventHandler(this.panel12_Paint);
            // 
            // chbEFatura
            // 
            this.chbEFatura.AutoSize = true;
            this.chbEFatura.Location = new System.Drawing.Point(664, 129);
            this.chbEFatura.Name = "chbEFatura";
            this.chbEFatura.Size = new System.Drawing.Size(66, 17);
            this.chbEFatura.TabIndex = 46;
            this.chbEFatura.Text = "E-Fatura";
            this.chbEFatura.UseVisualStyleBackColor = true;
            // 
            // cmbIslemTipi
            // 
            this.cmbIslemTipi.BackColor = System.Drawing.Color.White;
            this.cmbIslemTipi.ForeColor = System.Drawing.Color.Black;
            this.cmbIslemTipi.FormattingEnabled = true;
            this.cmbIslemTipi.Items.AddRange(new object[] {
            "Alış",
            "Satış"});
            this.cmbIslemTipi.Location = new System.Drawing.Point(401, 88);
            this.cmbIslemTipi.Name = "cmbIslemTipi";
            this.cmbIslemTipi.Size = new System.Drawing.Size(80, 21);
            this.cmbIslemTipi.TabIndex = 44;
            this.cmbIslemTipi.Tag = "001";
            this.cmbIslemTipi.Visible = false;
            // 
            // lblYapilacakIslem
            // 
            this.lblYapilacakIslem.AutoSize = true;
            this.lblYapilacakIslem.Location = new System.Drawing.Point(314, 93);
            this.lblYapilacakIslem.Name = "lblYapilacakIslem";
            this.lblYapilacakIslem.Size = new System.Drawing.Size(81, 13);
            this.lblYapilacakIslem.TabIndex = 45;
            this.lblYapilacakIslem.Text = "Yapılacak İşlem";
            this.lblYapilacakIslem.Visible = false;
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.White;
            this.label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label54.Dock = System.Windows.Forms.DockStyle.Top;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label54.Location = new System.Drawing.Point(0, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(774, 17);
            this.label54.TabIndex = 0;
            this.label54.Text = "Filtre Seçenekleri";
            this.label54.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkSilinenKayitlariGoster
            // 
            this.chkSilinenKayitlariGoster.AutoSize = true;
            this.chkSilinenKayitlariGoster.Location = new System.Drawing.Point(336, 130);
            this.chkSilinenKayitlariGoster.Name = "chkSilinenKayitlariGoster";
            this.chkSilinenKayitlariGoster.Size = new System.Drawing.Size(130, 17);
            this.chkSilinenKayitlariGoster.TabIndex = 15;
            this.chkSilinenKayitlariGoster.Text = "Silinen Kayıtları Göster";
            this.chkSilinenKayitlariGoster.UseVisualStyleBackColor = true;
            // 
            // chkWebKayitlariniGoster
            // 
            this.chkWebKayitlariniGoster.AutoSize = true;
            this.chkWebKayitlariniGoster.Location = new System.Drawing.Point(206, 130);
            this.chkWebKayitlariniGoster.Name = "chkWebKayitlariniGoster";
            this.chkWebKayitlariniGoster.Size = new System.Drawing.Size(130, 17);
            this.chkWebKayitlariniGoster.TabIndex = 17;
            this.chkWebKayitlariniGoster.Text = "Web Kayıtlarını Göster";
            this.chkWebKayitlariniGoster.UseVisualStyleBackColor = true;
            // 
            // chkHesabaİslenmeyenKayitlariGoster
            // 
            this.chkHesabaİslenmeyenKayitlariGoster.AutoSize = true;
            this.chkHesabaİslenmeyenKayitlariGoster.Location = new System.Drawing.Point(471, 129);
            this.chkHesabaİslenmeyenKayitlariGoster.Name = "chkHesabaİslenmeyenKayitlariGoster";
            this.chkHesabaİslenmeyenKayitlariGoster.Size = new System.Drawing.Size(192, 17);
            this.chkHesabaİslenmeyenKayitlariGoster.TabIndex = 16;
            this.chkHesabaİslenmeyenKayitlariGoster.Text = "Hesaba İşlenmeyen Kayıtları Göster";
            this.chkHesabaİslenmeyenKayitlariGoster.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabİslemTuruneGore);
            this.tabControl1.Controls.Add(this.tabBelgeyeGore);
            this.tabControl1.Location = new System.Drawing.Point(2, 21);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(298, 128);
            this.tabControl1.TabIndex = 6;
            // 
            // tabİslemTuruneGore
            // 
            this.tabİslemTuruneGore.BackColor = System.Drawing.Color.Gainsboro;
            this.tabİslemTuruneGore.Controls.Add(this.chbKesilenFaturalar);
            this.tabİslemTuruneGore.Controls.Add(this.chkStokTransferi);
            this.tabİslemTuruneGore.Controls.Add(this.chbIptalEdilenFaturalar);
            this.tabİslemTuruneGore.Controls.Add(this.grpİslemTipi);
            this.tabİslemTuruneGore.Controls.Add(this.grpOdemeTipi);
            this.tabİslemTuruneGore.Location = new System.Drawing.Point(4, 4);
            this.tabİslemTuruneGore.Name = "tabİslemTuruneGore";
            this.tabİslemTuruneGore.Padding = new System.Windows.Forms.Padding(3);
            this.tabİslemTuruneGore.Size = new System.Drawing.Size(290, 102);
            this.tabİslemTuruneGore.TabIndex = 0;
            this.tabİslemTuruneGore.Text = "İşlem Tipine Göre";
            // 
            // chbKesilenFaturalar
            // 
            this.chbKesilenFaturalar.AutoSize = true;
            this.chbKesilenFaturalar.Location = new System.Drawing.Point(162, 79);
            this.chbKesilenFaturalar.Name = "chbKesilenFaturalar";
            this.chbKesilenFaturalar.Size = new System.Drawing.Size(104, 17);
            this.chbKesilenFaturalar.TabIndex = 43;
            this.chbKesilenFaturalar.Text = "Kesilen Faturalar";
            this.chbKesilenFaturalar.UseVisualStyleBackColor = true;
            // 
            // chkStokTransferi
            // 
            this.chkStokTransferi.AutoSize = true;
            this.chkStokTransferi.Location = new System.Drawing.Point(11, 68);
            this.chkStokTransferi.Name = "chkStokTransferi";
            this.chkStokTransferi.Size = new System.Drawing.Size(92, 17);
            this.chkStokTransferi.TabIndex = 42;
            this.chkStokTransferi.Text = "Stok Transferi";
            this.chkStokTransferi.UseVisualStyleBackColor = true;
            this.chkStokTransferi.Visible = false;
            // 
            // chbIptalEdilenFaturalar
            // 
            this.chbIptalEdilenFaturalar.AutoSize = true;
            this.chbIptalEdilenFaturalar.Location = new System.Drawing.Point(162, 64);
            this.chbIptalEdilenFaturalar.Name = "chbIptalEdilenFaturalar";
            this.chbIptalEdilenFaturalar.Size = new System.Drawing.Size(122, 17);
            this.chbIptalEdilenFaturalar.TabIndex = 41;
            this.chbIptalEdilenFaturalar.Text = "İptal Edilen Faturalar";
            this.chbIptalEdilenFaturalar.UseVisualStyleBackColor = true;
            this.chbIptalEdilenFaturalar.CheckedChanged += new System.EventHandler(this.chbIptalEdilenFaturalar_CheckedChanged);
            // 
            // grpİslemTipi
            // 
            this.grpİslemTipi.Controls.Add(this.chkDigerİslemler);
            this.grpİslemTipi.Controls.Add(this.chkİadeİslemleri);
            this.grpİslemTipi.Controls.Add(this.chkFaturaliİslemler);
            this.grpİslemTipi.Location = new System.Drawing.Point(156, 0);
            this.grpİslemTipi.Name = "grpİslemTipi";
            this.grpİslemTipi.Size = new System.Drawing.Size(128, 93);
            this.grpİslemTipi.TabIndex = 40;
            this.grpİslemTipi.TabStop = false;
            this.grpİslemTipi.Text = "İşlem Tipi";
            // 
            // chkDigerİslemler
            // 
            this.chkDigerİslemler.AutoSize = true;
            this.chkDigerİslemler.Checked = true;
            this.chkDigerİslemler.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDigerİslemler.Location = new System.Drawing.Point(6, 48);
            this.chkDigerİslemler.Name = "chkDigerİslemler";
            this.chkDigerİslemler.Size = new System.Drawing.Size(89, 17);
            this.chkDigerİslemler.TabIndex = 10;
            this.chkDigerİslemler.Text = "Diğer İşlemler";
            this.chkDigerİslemler.UseVisualStyleBackColor = true;
            // 
            // chkİadeİslemleri
            // 
            this.chkİadeİslemleri.AutoSize = true;
            this.chkİadeİslemleri.Checked = true;
            this.chkİadeİslemleri.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkİadeİslemleri.Location = new System.Drawing.Point(6, 32);
            this.chkİadeİslemleri.Name = "chkİadeİslemleri";
            this.chkİadeİslemleri.Size = new System.Drawing.Size(87, 17);
            this.chkİadeİslemleri.TabIndex = 9;
            this.chkİadeİslemleri.Text = "İade İşlemleri";
            this.chkİadeİslemleri.UseVisualStyleBackColor = true;
            // 
            // chkFaturaliİslemler
            // 
            this.chkFaturaliİslemler.AutoSize = true;
            this.chkFaturaliİslemler.Checked = true;
            this.chkFaturaliİslemler.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFaturaliİslemler.Location = new System.Drawing.Point(6, 16);
            this.chkFaturaliİslemler.Name = "chkFaturaliİslemler";
            this.chkFaturaliİslemler.Size = new System.Drawing.Size(98, 17);
            this.chkFaturaliİslemler.TabIndex = 2;
            this.chkFaturaliİslemler.Text = "Faturalı İşlemler";
            this.chkFaturaliİslemler.UseVisualStyleBackColor = true;
            // 
            // grpOdemeTipi
            // 
            this.grpOdemeTipi.Controls.Add(this.chkKrediKarti);
            this.grpOdemeTipi.Controls.Add(this.chkSenet);
            this.grpOdemeTipi.Controls.Add(this.chkPesin);
            this.grpOdemeTipi.Controls.Add(this.chkCek);
            this.grpOdemeTipi.Controls.Add(this.chkAcikHesap);
            this.grpOdemeTipi.Controls.Add(this.chkTaksit);
            this.grpOdemeTipi.Location = new System.Drawing.Point(5, 0);
            this.grpOdemeTipi.Name = "grpOdemeTipi";
            this.grpOdemeTipi.Size = new System.Drawing.Size(143, 70);
            this.grpOdemeTipi.TabIndex = 13;
            this.grpOdemeTipi.TabStop = false;
            this.grpOdemeTipi.Text = "Ödeme Tipi";
            // 
            // chkKrediKarti
            // 
            this.chkKrediKarti.AutoSize = true;
            this.chkKrediKarti.Checked = true;
            this.chkKrediKarti.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKrediKarti.Location = new System.Drawing.Point(6, 32);
            this.chkKrediKarti.Name = "chkKrediKarti";
            this.chkKrediKarti.Size = new System.Drawing.Size(74, 17);
            this.chkKrediKarti.TabIndex = 3;
            this.chkKrediKarti.Text = "Kredi Kartı";
            this.chkKrediKarti.UseVisualStyleBackColor = true;
            // 
            // chkSenet
            // 
            this.chkSenet.AutoSize = true;
            this.chkSenet.Checked = true;
            this.chkSenet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSenet.Location = new System.Drawing.Point(86, 48);
            this.chkSenet.Name = "chkSenet";
            this.chkSenet.Size = new System.Drawing.Size(54, 17);
            this.chkSenet.TabIndex = 7;
            this.chkSenet.Text = "Senet";
            this.chkSenet.UseVisualStyleBackColor = true;
            // 
            // chkPesin
            // 
            this.chkPesin.AutoSize = true;
            this.chkPesin.Checked = true;
            this.chkPesin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPesin.Location = new System.Drawing.Point(6, 17);
            this.chkPesin.Name = "chkPesin";
            this.chkPesin.Size = new System.Drawing.Size(52, 17);
            this.chkPesin.TabIndex = 2;
            this.chkPesin.Text = "Peşin";
            this.chkPesin.UseVisualStyleBackColor = true;
            // 
            // chkCek
            // 
            this.chkCek.AutoSize = true;
            this.chkCek.Checked = true;
            this.chkCek.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCek.Location = new System.Drawing.Point(86, 33);
            this.chkCek.Name = "chkCek";
            this.chkCek.Size = new System.Drawing.Size(45, 17);
            this.chkCek.TabIndex = 6;
            this.chkCek.Text = "Çek";
            this.chkCek.UseVisualStyleBackColor = true;
            // 
            // chkAcikHesap
            // 
            this.chkAcikHesap.AutoSize = true;
            this.chkAcikHesap.Checked = true;
            this.chkAcikHesap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAcikHesap.Location = new System.Drawing.Point(6, 48);
            this.chkAcikHesap.Name = "chkAcikHesap";
            this.chkAcikHesap.Size = new System.Drawing.Size(81, 17);
            this.chkAcikHesap.TabIndex = 4;
            this.chkAcikHesap.Text = "Açık Hesap";
            this.chkAcikHesap.UseVisualStyleBackColor = true;
            // 
            // chkTaksit
            // 
            this.chkTaksit.AutoSize = true;
            this.chkTaksit.Checked = true;
            this.chkTaksit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTaksit.Location = new System.Drawing.Point(86, 18);
            this.chkTaksit.Name = "chkTaksit";
            this.chkTaksit.Size = new System.Drawing.Size(55, 17);
            this.chkTaksit.TabIndex = 5;
            this.chkTaksit.Text = "Taksit";
            this.chkTaksit.UseVisualStyleBackColor = true;
            // 
            // tabBelgeyeGore
            // 
            this.tabBelgeyeGore.BackColor = System.Drawing.Color.Gainsboro;
            this.tabBelgeyeGore.Controls.Add(this.grpBelgeNumarası);
            this.tabBelgeyeGore.Location = new System.Drawing.Point(4, 4);
            this.tabBelgeyeGore.Name = "tabBelgeyeGore";
            this.tabBelgeyeGore.Padding = new System.Windows.Forms.Padding(3);
            this.tabBelgeyeGore.Size = new System.Drawing.Size(290, 102);
            this.tabBelgeyeGore.TabIndex = 1;
            this.tabBelgeyeGore.Text = "Belgeye Göre";
            // 
            // grpBelgeNumarası
            // 
            this.grpBelgeNumarası.Controls.Add(this.txtİrsaliyeNo);
            this.grpBelgeNumarası.Controls.Add(this.label3);
            this.grpBelgeNumarası.Controls.Add(this.txtBelgeNo);
            this.grpBelgeNumarası.Controls.Add(this.label2);
            this.grpBelgeNumarası.Controls.Add(this.txtFaturaNo);
            this.grpBelgeNumarası.Controls.Add(this.label1);
            this.grpBelgeNumarası.Location = new System.Drawing.Point(3, 3);
            this.grpBelgeNumarası.Name = "grpBelgeNumarası";
            this.grpBelgeNumarası.Size = new System.Drawing.Size(165, 81);
            this.grpBelgeNumarası.TabIndex = 15;
            this.grpBelgeNumarası.TabStop = false;
            this.grpBelgeNumarası.Text = "Belge Numarası";
            // 
            // txtİrsaliyeNo
            // 
            this.txtİrsaliyeNo.BackColor = System.Drawing.Color.White;
            this.txtİrsaliyeNo.ForeColor = System.Drawing.Color.Black;
            this.txtİrsaliyeNo.Location = new System.Drawing.Point(60, 57);
            this.txtİrsaliyeNo.Name = "txtİrsaliyeNo";
            this.txtİrsaliyeNo.Size = new System.Drawing.Size(100, 20);
            this.txtİrsaliyeNo.TabIndex = 5;
            this.txtİrsaliyeNo.Tag = "001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "İrsaliye No";
            // 
            // txtBelgeNo
            // 
            this.txtBelgeNo.BackColor = System.Drawing.Color.White;
            this.txtBelgeNo.ForeColor = System.Drawing.Color.Black;
            this.txtBelgeNo.Location = new System.Drawing.Point(60, 37);
            this.txtBelgeNo.Name = "txtBelgeNo";
            this.txtBelgeNo.Size = new System.Drawing.Size(100, 20);
            this.txtBelgeNo.TabIndex = 3;
            this.txtBelgeNo.Tag = "001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Belge No";
            // 
            // txtFaturaNo
            // 
            this.txtFaturaNo.BackColor = System.Drawing.Color.White;
            this.txtFaturaNo.ForeColor = System.Drawing.Color.Black;
            this.txtFaturaNo.Location = new System.Drawing.Point(60, 17);
            this.txtFaturaNo.Name = "txtFaturaNo";
            this.txtFaturaNo.Size = new System.Drawing.Size(100, 20);
            this.txtFaturaNo.TabIndex = 1;
            this.txtFaturaNo.Tag = "001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fatura No";
            // 
            // grpİslemTarihi
            // 
            this.grpİslemTarihi.Controls.Add(this.dtİslemTarihi2);
            this.grpİslemTarihi.Controls.Add(this.dtİslemTarihi1);
            this.grpİslemTarihi.Controls.Add(this.label56);
            this.grpİslemTarihi.Controls.Add(this.chkİslemTarihi);
            this.grpİslemTarihi.Location = new System.Drawing.Point(308, 18);
            this.grpİslemTarihi.Name = "grpİslemTarihi";
            this.grpİslemTarihi.Size = new System.Drawing.Size(258, 42);
            this.grpİslemTarihi.TabIndex = 13;
            this.grpİslemTarihi.TabStop = false;
            // 
            // dtİslemTarihi2
            // 
            this.dtİslemTarihi2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtİslemTarihi2.Location = new System.Drawing.Point(172, 16);
            this.dtİslemTarihi2.Name = "dtİslemTarihi2";
            this.dtİslemTarihi2.Size = new System.Drawing.Size(77, 20);
            this.dtİslemTarihi2.TabIndex = 4;
            // 
            // dtİslemTarihi1
            // 
            this.dtİslemTarihi1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtİslemTarihi1.Location = new System.Drawing.Point(83, 16);
            this.dtİslemTarihi1.Name = "dtİslemTarihi1";
            this.dtİslemTarihi1.Size = new System.Drawing.Size(77, 20);
            this.dtİslemTarihi1.TabIndex = 3;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label56.Location = new System.Drawing.Point(161, 20);
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
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.cmbKullanicilar);
            this.groupBox9.Controls.Add(this.cmbSubeler);
            this.groupBox9.Controls.Add(this.label57);
            this.groupBox9.Controls.Add(this.label58);
            this.groupBox9.Location = new System.Drawing.Point(308, 56);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(258, 32);
            this.groupBox9.TabIndex = 14;
            this.groupBox9.TabStop = false;
            // 
            // cmbKullanicilar
            // 
            this.cmbKullanicilar.BackColor = System.Drawing.Color.White;
            this.cmbKullanicilar.ForeColor = System.Drawing.Color.Black;
            this.cmbKullanicilar.FormattingEnabled = true;
            this.cmbKullanicilar.Location = new System.Drawing.Point(162, 5);
            this.cmbKullanicilar.Name = "cmbKullanicilar";
            this.cmbKullanicilar.Size = new System.Drawing.Size(89, 21);
            this.cmbKullanicilar.TabIndex = 3;
            this.cmbKullanicilar.Tag = "001";
            // 
            // cmbSubeler
            // 
            this.cmbSubeler.BackColor = System.Drawing.Color.White;
            this.cmbSubeler.ForeColor = System.Drawing.Color.Black;
            this.cmbSubeler.FormattingEnabled = true;
            this.cmbSubeler.Location = new System.Drawing.Point(36, 5);
            this.cmbSubeler.Name = "cmbSubeler";
            this.cmbSubeler.Size = new System.Drawing.Size(80, 21);
            this.cmbSubeler.TabIndex = 0;
            this.cmbSubeler.Tag = "001";
            this.cmbSubeler.SelectedIndexChanged += new System.EventHandler(this.cmbSubeler_SelectedIndexChanged);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(117, 9);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(46, 13);
            this.label57.TabIndex = 2;
            this.label57.Text = "Kullanıcı";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(6, 9);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(32, 13);
            this.label58.TabIndex = 1;
            this.label58.Text = "Şube";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(285, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(385, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "_______________________________________________________________";
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel18.Controls.Add(this.progressBar1);
            this.panel18.Controls.Add(this.label6);
            this.panel18.Controls.Add(this.lblToplamIskonto);
            this.panel18.Controls.Add(this.label7);
            this.panel18.Controls.Add(this.label79);
            this.panel18.Controls.Add(this.lblBakiyeF);
            this.panel18.Controls.Add(this.lblKayitSayisiF);
            this.panel18.Controls.Add(this.label82);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel18.Location = new System.Drawing.Point(0, 379);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(1044, 20);
            this.panel18.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(178, -1);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(522, 20);
            this.progressBar1.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(706, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Toplam iskonto";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblToplamIskonto
            // 
            this.lblToplamIskonto.AutoSize = true;
            this.lblToplamIskonto.BackColor = System.Drawing.Color.Transparent;
            this.lblToplamIskonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblToplamIskonto.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblToplamIskonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamIskonto.ForeColor = System.Drawing.Color.DarkRed;
            this.lblToplamIskonto.Location = new System.Drawing.Point(811, 0);
            this.lblToplamIskonto.Name = "lblToplamIskonto";
            this.lblToplamIskonto.Size = new System.Drawing.Size(50, 17);
            this.lblToplamIskonto.TabIndex = 10;
            this.lblToplamIskonto.Text = "0,00 TL";
            this.lblToplamIskonto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Right;
            this.label7.Location = new System.Drawing.Point(861, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "   ";
            // 
            // label79
            // 
            this.label79.BackColor = System.Drawing.Color.Transparent;
            this.label79.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label79.Dock = System.Windows.Forms.DockStyle.Right;
            this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label79.ForeColor = System.Drawing.Color.Black;
            this.label79.Location = new System.Drawing.Point(877, 0);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(105, 18);
            this.label79.TabIndex = 6;
            this.label79.Text = "Genel Toplam";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBakiyeF
            // 
            this.lblBakiyeF.AutoSize = true;
            this.lblBakiyeF.BackColor = System.Drawing.Color.Transparent;
            this.lblBakiyeF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBakiyeF.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBakiyeF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBakiyeF.ForeColor = System.Drawing.Color.DarkRed;
            this.lblBakiyeF.Location = new System.Drawing.Point(982, 0);
            this.lblBakiyeF.Name = "lblBakiyeF";
            this.lblBakiyeF.Size = new System.Drawing.Size(60, 18);
            this.lblBakiyeF.TabIndex = 5;
            this.lblBakiyeF.Text = "0,00 TL";
            this.lblBakiyeF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKayitSayisiF
            // 
            this.lblKayitSayisiF.BackColor = System.Drawing.Color.Transparent;
            this.lblKayitSayisiF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKayitSayisiF.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblKayitSayisiF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKayitSayisiF.ForeColor = System.Drawing.Color.DarkRed;
            this.lblKayitSayisiF.Location = new System.Drawing.Point(91, 0);
            this.lblKayitSayisiF.Name = "lblKayitSayisiF";
            this.lblKayitSayisiF.Size = new System.Drawing.Size(81, 18);
            this.lblKayitSayisiF.TabIndex = 4;
            this.lblKayitSayisiF.Text = "0";
            this.lblKayitSayisiF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.label82.Size = new System.Drawing.Size(91, 18);
            this.label82.TabIndex = 3;
            this.label82.Text = "Kayıt Sayısı: ";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frmTicaretRaporlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 549);
            this.Controls.Add(this.dgTicaretRapor);
            this.Controls.Add(this.panel18);
            this.Controls.Add(this.pnlAlt);
            this.Controls.Add(this.panel1);
            this.Name = "frmTicaretRaporlari";
            this.Text = "Satış Raporları";
            this.Load += new System.EventHandler(this.frmTicaretRaporlari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTicaretRapor)).EndInit();
            this.cnsStokkart.ResumeLayout(false);
            this.pnlAlt.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabİslemTuruneGore.ResumeLayout(false);
            this.tabİslemTuruneGore.PerformLayout();
            this.grpİslemTipi.ResumeLayout(false);
            this.grpİslemTipi.PerformLayout();
            this.grpOdemeTipi.ResumeLayout(false);
            this.grpOdemeTipi.PerformLayout();
            this.tabBelgeyeGore.ResumeLayout(false);
            this.grpBelgeNumarası.ResumeLayout(false);
            this.grpBelgeNumarası.PerformLayout();
            this.grpİslemTarihi.ResumeLayout(false);
            this.grpİslemTarihi.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgTicaretRapor;
        private System.Windows.Forms.Panel pnlAlt;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button btnYazdir;
        private System.Windows.Forms.Button btnRaporGoruntule;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.GroupBox grpİslemTarihi;
        private System.Windows.Forms.DateTimePicker dtİslemTarihi2;
        private System.Windows.Forms.DateTimePicker dtİslemTarihi1;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.CheckBox chkİslemTarihi;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.ComboBox cmbKullanicilar;
        private System.Windows.Forms.ComboBox cmbSubeler;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.GroupBox grpOdemeTipi;
        private System.Windows.Forms.CheckBox chkKrediKarti;
        private System.Windows.Forms.CheckBox chkSenet;
        private System.Windows.Forms.CheckBox chkPesin;
        private System.Windows.Forms.CheckBox chkCek;
        private System.Windows.Forms.CheckBox chkAcikHesap;
        private System.Windows.Forms.CheckBox chkTaksit;
        private System.Windows.Forms.GroupBox grpBelgeNumarası;
        private System.Windows.Forms.TextBox txtİrsaliyeNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBelgeNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFaturaNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabİslemTuruneGore;
        private System.Windows.Forms.TabPage tabBelgeyeGore;
        private System.Windows.Forms.GroupBox grpİslemTipi;
        private System.Windows.Forms.CheckBox chkİadeİslemleri;
        private System.Windows.Forms.CheckBox chkFaturaliİslemler;
        private System.Windows.Forms.CheckBox chkWebKayitlariniGoster;
        private System.Windows.Forms.CheckBox chkHesabaİslenmeyenKayitlariGoster;
        private System.Windows.Forms.CheckBox chkSilinenKayitlariGoster;
        private System.Windows.Forms.ContextMenuStrip cnsStokkart;
        private System.Windows.Forms.ToolStripMenuItem işlemiDüzenleGörüntüleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem işlemiSilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silmeİşleminiGeriAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem işlemiDondurKasayaİşlemezToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dondurmaİşleminiGeriAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem faturayıİptalEtToolStripMenuItem;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.CheckBox chkDigerİslemler;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem kayıdaAitÜrünleriGörüntüleToolStripMenuItem;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label lblBakiyeF;
        private System.Windows.Forms.Label lblKayitSayisiF;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblToplamIskonto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbIslemTipi;
        private System.Windows.Forms.Label lblYapilacakIslem;
        private System.Windows.Forms.CheckBox chbIptalEdilenFaturalar;
        private System.Windows.Forms.CheckBox chkStokTransferi;
        private System.Windows.Forms.CheckBox chbKesilenFaturalar;
        private System.Windows.Forms.CheckBox chbEFatura;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticaretAyrintiid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Durumu;
        private System.Windows.Forms.DataGridViewTextBoxColumn cariid;
        private System.Windows.Forms.DataGridViewTextBoxColumn adiSoyadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn odemeTuru;
        private System.Windows.Forms.DataGridViewTextBoxColumn islemTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn islemTuru;
        private System.Windows.Forms.DataGridViewTextBoxColumn AraTop;
        private System.Windows.Forms.DataGridViewTextBoxColumn KdvTop;
        private System.Windows.Forms.DataGridViewTextBoxColumn iskonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn yuzdeisk;
        private System.Windows.Forms.DataGridViewTextBoxColumn nakliyat;
        private System.Windows.Forms.DataGridViewTextBoxColumn iscilik;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenelToplam;
        private System.Windows.Forms.DataGridViewTextBoxColumn fiiliSevkTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn faturaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn belgeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn irsaliyeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn vergiDaire;
        private System.Windows.Forms.DataGridViewTextBoxColumn vergiNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn adres;
        private System.Windows.Forms.DataGridViewTextBoxColumn faturaAciklamasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn islemAciklamasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn hesabaislendimi;
        private System.Windows.Forms.DataGridViewTextBoxColumn onay;
        private System.Windows.Forms.DataGridViewTextBoxColumn eklenmeTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn subeid;
        private System.Windows.Forms.DataGridViewTextBoxColumn kullaniciid;
        private System.Windows.Forms.ToolStripMenuItem eFaturayıKabulEtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eFaturayıRedEtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eFaturayıYazdırToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}