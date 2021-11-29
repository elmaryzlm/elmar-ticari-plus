namespace Elmar_Ticari_Plus
{
    partial class frmBankaKrediKartiileOdeme
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
            this.lblPesinat = new System.Windows.Forms.Label();
            this.txtPesinat = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtDovizDegeri = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.txtDovizliTutar = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgAlanHesap = new System.Windows.Forms.DataGridView();
            this.krediKartid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankaHesapid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankaAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hesapKesim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sonOdeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kartLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTaksitSayisi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDovizKuru = new System.Windows.Forms.ComboBox();
            this.txtAcklama = new System.Windows.Forms.TextBox();
            this.cmbCariler = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtİslemTarihi = new System.Windows.Forms.DateTimePicker();
            this.btnCariAra = new System.Windows.Forms.Button();
            this.btnCariEkle = new System.Windows.Forms.Button();
            this.cmbESubeler = new System.Windows.Forms.ComboBox();
            this.cmbEKullanicilar = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnKaydet = new System.Windows.Forms.ToolStripButton();
            this.btnKrediKartihesabiTanimla = new System.Windows.Forms.ToolStripButton();
            this.btnTemizle = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgAlanHesap)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPesinat
            // 
            this.lblPesinat.AutoSize = true;
            this.lblPesinat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPesinat.ForeColor = System.Drawing.Color.DarkRed;
            this.lblPesinat.Location = new System.Drawing.Point(230, 41);
            this.lblPesinat.Name = "lblPesinat";
            this.lblPesinat.Size = new System.Drawing.Size(48, 15);
            this.lblPesinat.TabIndex = 126;
            this.lblPesinat.Text = "Peşinat";
            this.lblPesinat.Visible = false;
            // 
            // txtPesinat
            // 
            this.txtPesinat.BackColor = System.Drawing.Color.White;
            this.txtPesinat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPesinat.ForeColor = System.Drawing.Color.Black;
            this.txtPesinat.Location = new System.Drawing.Point(277, 38);
            this.txtPesinat.Name = "txtPesinat";
            this.txtPesinat.Size = new System.Drawing.Size(105, 22);
            this.txtPesinat.TabIndex = 146;
            this.txtPesinat.Tag = "221";
            this.txtPesinat.Text = "0";
            this.txtPesinat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPesinat.Visible = false;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label39.ForeColor = System.Drawing.Color.DarkRed;
            this.label39.Location = new System.Drawing.Point(9, 174);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(57, 15);
            this.label39.TabIndex = 140;
            this.label39.Text = "Açıklama";
            // 
            // txtDovizDegeri
            // 
            this.txtDovizDegeri.BackColor = System.Drawing.Color.White;
            this.txtDovizDegeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDovizDegeri.ForeColor = System.Drawing.Color.Black;
            this.txtDovizDegeri.Location = new System.Drawing.Point(113, 81);
            this.txtDovizDegeri.Name = "txtDovizDegeri";
            this.txtDovizDegeri.Size = new System.Drawing.Size(115, 22);
            this.txtDovizDegeri.TabIndex = 148;
            this.txtDovizDegeri.Tag = "221";
            this.txtDovizDegeri.Text = "1";
            this.txtDovizDegeri.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDovizDegeri.TextChanged += new System.EventHandler(this.txtTutar_TextChanged);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label41.ForeColor = System.Drawing.Color.DarkRed;
            this.label41.Location = new System.Drawing.Point(9, 63);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(37, 15);
            this.label41.TabIndex = 137;
            this.label41.Text = "Doviz";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label42.ForeColor = System.Drawing.Color.DarkRed;
            this.label42.Location = new System.Drawing.Point(9, 84);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(66, 15);
            this.label42.TabIndex = 135;
            this.label42.Text = "Döviz Kuru";
            // 
            // txtDovizliTutar
            // 
            this.txtDovizliTutar.BackColor = System.Drawing.Color.White;
            this.txtDovizliTutar.Enabled = false;
            this.txtDovizliTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDovizliTutar.ForeColor = System.Drawing.Color.Black;
            this.txtDovizliTutar.Location = new System.Drawing.Point(113, 103);
            this.txtDovizliTutar.Name = "txtDovizliTutar";
            this.txtDovizliTutar.ReadOnly = true;
            this.txtDovizliTutar.Size = new System.Drawing.Size(115, 22);
            this.txtDovizliTutar.TabIndex = 149;
            this.txtDovizliTutar.Tag = "001";
            this.txtDovizliTutar.Text = "0";
            this.txtDovizliTutar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label43.ForeColor = System.Drawing.Color.DarkRed;
            this.label43.Location = new System.Drawing.Point(9, 106);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(74, 15);
            this.label43.TabIndex = 127;
            this.label43.Text = "Dovizli Tutar";
            // 
            // txtTutar
            // 
            this.txtTutar.BackColor = System.Drawing.Color.White;
            this.txtTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTutar.ForeColor = System.Drawing.Color.Black;
            this.txtTutar.Location = new System.Drawing.Point(113, 38);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(115, 22);
            this.txtTutar.TabIndex = 145;
            this.txtTutar.Tag = "221";
            this.txtTutar.Text = "0";
            this.txtTutar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTutar.TextChanged += new System.EventHandler(this.txtTutar_TextChanged);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label45.ForeColor = System.Drawing.Color.DarkRed;
            this.label45.Location = new System.Drawing.Point(9, 41);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(35, 15);
            this.label45.TabIndex = 128;
            this.label45.Text = "Tutar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-83, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(547, 13);
            this.label7.TabIndex = 133;
            this.label7.Text = "_________________________________________________________________________________" +
    "_________";
            // 
            // dgAlanHesap
            // 
            this.dgAlanHesap.AllowUserToAddRows = false;
            this.dgAlanHesap.AllowUserToDeleteRows = false;
            this.dgAlanHesap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgAlanHesap.ColumnHeadersHeight = 20;
            this.dgAlanHesap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgAlanHesap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.krediKartid,
            this.bankaHesapid,
            this.bankaAdi,
            this.hesapKesim,
            this.sonOdeme,
            this.kartLimit});
            this.dgAlanHesap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAlanHesap.Location = new System.Drawing.Point(3, 16);
            this.dgAlanHesap.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.dgAlanHesap.MultiSelect = false;
            this.dgAlanHesap.Name = "dgAlanHesap";
            this.dgAlanHesap.ReadOnly = true;
            this.dgAlanHesap.RowHeadersWidth = 20;
            this.dgAlanHesap.RowTemplate.Height = 20;
            this.dgAlanHesap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAlanHesap.Size = new System.Drawing.Size(391, 162);
            this.dgAlanHesap.TabIndex = 30;
            this.dgAlanHesap.TabStop = false;
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
            // bankaAdi
            // 
            this.bankaAdi.HeaderText = "Banka Adı";
            this.bankaAdi.Name = "bankaAdi";
            this.bankaAdi.ReadOnly = true;
            this.bankaAdi.Width = 81;
            // 
            // hesapKesim
            // 
            this.hesapKesim.HeaderText = "Hesap Kesim";
            this.hesapKesim.Name = "hesapKesim";
            this.hesapKesim.ReadOnly = true;
            this.hesapKesim.Width = 94;
            // 
            // sonOdeme
            // 
            this.sonOdeme.HeaderText = "Son Ödeme";
            this.sonOdeme.Name = "sonOdeme";
            this.sonOdeme.ReadOnly = true;
            this.sonOdeme.Width = 88;
            // 
            // kartLimit
            // 
            this.kartLimit.HeaderText = "Kart Limit";
            this.kartLimit.Name = "kartLimit";
            this.kartLimit.ReadOnly = true;
            this.kartLimit.Width = 75;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgAlanHesap);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 312);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 181);
            this.groupBox1.TabIndex = 165;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "KrediSeçimi Kartı";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTaksitSayisi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblPesinat);
            this.panel1.Controls.Add(this.txtPesinat);
            this.panel1.Controls.Add(this.txtDovizKuru);
            this.panel1.Controls.Add(this.txtAcklama);
            this.panel1.Controls.Add(this.cmbCariler);
            this.panel1.Controls.Add(this.label39);
            this.panel1.Controls.Add(this.txtDovizDegeri);
            this.panel1.Controls.Add(this.label41);
            this.panel1.Controls.Add(this.label42);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtDovizliTutar);
            this.panel1.Controls.Add(this.dtİslemTarihi);
            this.panel1.Controls.Add(this.label43);
            this.panel1.Controls.Add(this.btnCariAra);
            this.panel1.Controls.Add(this.txtTutar);
            this.panel1.Controls.Add(this.label45);
            this.panel1.Controls.Add(this.btnCariEkle);
            this.panel1.Controls.Add(this.cmbESubeler);
            this.panel1.Controls.Add(this.cmbEKullanicilar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 287);
            this.panel1.TabIndex = 166;
            // 
            // txtTaksitSayisi
            // 
            this.txtTaksitSayisi.BackColor = System.Drawing.Color.White;
            this.txtTaksitSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTaksitSayisi.ForeColor = System.Drawing.Color.Black;
            this.txtTaksitSayisi.Location = new System.Drawing.Point(113, 126);
            this.txtTaksitSayisi.Name = "txtTaksitSayisi";
            this.txtTaksitSayisi.ReadOnly = true;
            this.txtTaksitSayisi.Size = new System.Drawing.Size(115, 22);
            this.txtTaksitSayisi.TabIndex = 150;
            this.txtTaksitSayisi.Tag = "001";
            this.txtTaksitSayisi.Text = "1";
            this.txtTaksitSayisi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(9, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 155;
            this.label1.Text = "Taksit Sayısı";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(9, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 136;
            this.label6.Text = "Cari Seçimi";
            // 
            // txtDovizKuru
            // 
            this.txtDovizKuru.BackColor = System.Drawing.Color.White;
            this.txtDovizKuru.ForeColor = System.Drawing.Color.Black;
            this.txtDovizKuru.FormattingEnabled = true;
            this.txtDovizKuru.Items.AddRange(new object[] {
            "TL",
            "USD",
            "EURO"});
            this.txtDovizKuru.Location = new System.Drawing.Point(113, 60);
            this.txtDovizKuru.Name = "txtDovizKuru";
            this.txtDovizKuru.Size = new System.Drawing.Size(115, 21);
            this.txtDovizKuru.TabIndex = 147;
            this.txtDovizKuru.Tag = "001";
            this.txtDovizKuru.Text = "TL";
            this.txtDovizKuru.SelectedIndexChanged += new System.EventHandler(this.txtDovizKuru_SelectedIndexChanged);
            // 
            // txtAcklama
            // 
            this.txtAcklama.BackColor = System.Drawing.Color.White;
            this.txtAcklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAcklama.ForeColor = System.Drawing.Color.Black;
            this.txtAcklama.Location = new System.Drawing.Point(113, 171);
            this.txtAcklama.Multiline = true;
            this.txtAcklama.Name = "txtAcklama";
            this.txtAcklama.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAcklama.Size = new System.Drawing.Size(269, 89);
            this.txtAcklama.TabIndex = 152;
            this.txtAcklama.Tag = "001";
            // 
            // cmbCariler
            // 
            this.cmbCariler.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCariler.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCariler.BackColor = System.Drawing.Color.White;
            this.cmbCariler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCariler.ForeColor = System.Drawing.Color.Black;
            this.cmbCariler.FormattingEnabled = true;
            this.cmbCariler.Location = new System.Drawing.Point(66, 4);
            this.cmbCariler.Name = "cmbCariler";
            this.cmbCariler.Size = new System.Drawing.Size(277, 24);
            this.cmbCariler.TabIndex = 141;
            this.cmbCariler.Tag = "001";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(9, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 138;
            this.label8.Text = "İşlem Tarihi";
            // 
            // dtİslemTarihi
            // 
            this.dtİslemTarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtİslemTarihi.Location = new System.Drawing.Point(113, 148);
            this.dtİslemTarihi.Name = "dtİslemTarihi";
            this.dtİslemTarihi.Size = new System.Drawing.Size(269, 21);
            this.dtİslemTarihi.TabIndex = 151;
            // 
            // btnCariAra
            // 
            this.btnCariAra.Location = new System.Drawing.Point(343, 3);
            this.btnCariAra.Name = "btnCariAra";
            this.btnCariAra.Size = new System.Drawing.Size(24, 23);
            this.btnCariAra.TabIndex = 142;
            this.btnCariAra.Text = "...";
            this.btnCariAra.UseVisualStyleBackColor = false;
            this.btnCariAra.Visible = false;
            // 
            // btnCariEkle
            // 
            this.btnCariEkle.Image = global::Elmar_Ticari_Plus.Properties.Resources.genelEkle;
            this.btnCariEkle.Location = new System.Drawing.Point(366, 3);
            this.btnCariEkle.Name = "btnCariEkle";
            this.btnCariEkle.Size = new System.Drawing.Size(23, 23);
            this.btnCariEkle.TabIndex = 143;
            this.btnCariEkle.UseVisualStyleBackColor = false;
            this.btnCariEkle.Visible = false;
            // 
            // cmbESubeler
            // 
            this.cmbESubeler.BackColor = System.Drawing.Color.White;
            this.cmbESubeler.ForeColor = System.Drawing.Color.Black;
            this.cmbESubeler.FormattingEnabled = true;
            this.cmbESubeler.Location = new System.Drawing.Point(113, 262);
            this.cmbESubeler.Name = "cmbESubeler";
            this.cmbESubeler.Size = new System.Drawing.Size(115, 21);
            this.cmbESubeler.TabIndex = 153;
            this.cmbESubeler.Tag = "001";
            this.cmbESubeler.SelectedIndexChanged += new System.EventHandler(this.cmbESubeler_SelectedIndexChanged);
            // 
            // cmbEKullanicilar
            // 
            this.cmbEKullanicilar.BackColor = System.Drawing.Color.White;
            this.cmbEKullanicilar.ForeColor = System.Drawing.Color.Black;
            this.cmbEKullanicilar.FormattingEnabled = true;
            this.cmbEKullanicilar.Location = new System.Drawing.Point(228, 262);
            this.cmbEKullanicilar.Name = "cmbEKullanicilar";
            this.cmbEKullanicilar.Size = new System.Drawing.Size(155, 21);
            this.cmbEKullanicilar.TabIndex = 154;
            this.cmbEKullanicilar.Tag = "001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(9, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 134;
            this.label5.Text = "Şube - Kullanıcı";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDurum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 493);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(397, 22);
            this.statusStrip1.TabIndex = 164;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblDurum
            // 
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(34, 17);
            this.lblDurum.Text = "Hazır";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnKaydet,
            this.btnKrediKartihesabiTanimla,
            this.btnTemizle,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(397, 25);
            this.toolStrip1.TabIndex = 163;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(63, 22);
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.ToolTipText = "Bilgileri Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnKrediKartihesabiTanimla
            // 
            this.btnKrediKartihesabiTanimla.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKrediKartihesabiTanimla.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKrediKartihesabiTanimla.Image = global::Elmar_Ticari_Plus.Properties.Resources.genelEkle;
            this.btnKrediKartihesabiTanimla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnKrediKartihesabiTanimla.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.btnKrediKartihesabiTanimla.Name = "btnKrediKartihesabiTanimla";
            this.btnKrediKartihesabiTanimla.Size = new System.Drawing.Size(161, 22);
            this.btnKrediKartihesabiTanimla.Text = "Kredi kartı Hesabı Tanımla";
            this.btnKrediKartihesabiTanimla.ToolTipText = "Bilgileri Kaydet";
            this.btnKrediKartihesabiTanimla.Click += new System.EventHandler(this.btnKrediKartihesabiTanimla_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnTemizle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Image = global::Elmar_Ticari_Plus.Properties.Resources.faturaiptal1;
            this.btnTemizle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(65, 22);
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.ToolTipText = "Bilgileri Kaydet";
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // frmBankaKrediKartiileOdeme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 515);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmBankaKrediKartiileOdeme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Kredi Kartı ile Ödeme Yap";
            this.Load += new System.EventHandler(this.frmBankaKrediKartiileOdeme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAlanHesap)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPesinat;
        private System.Windows.Forms.TextBox txtPesinat;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtDovizDegeri;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtDovizliTutar;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtTutar;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.DataGridView dgAlanHesap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox txtDovizKuru;
        private System.Windows.Forms.TextBox txtAcklama;
        private System.Windows.Forms.ComboBox cmbCariler;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtİslemTarihi;
        private System.Windows.Forms.Button btnCariAra;
        private System.Windows.Forms.Button btnCariEkle;
        private System.Windows.Forms.ComboBox cmbESubeler;
        private System.Windows.Forms.ComboBox cmbEKullanicilar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblDurum;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnKaydet;
        private System.Windows.Forms.ToolStripButton btnKrediKartihesabiTanimla;
        private System.Windows.Forms.ToolStripButton btnTemizle;
        private System.Windows.Forms.DataGridViewTextBoxColumn krediKartid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankaHesapid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankaAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn hesapKesim;
        private System.Windows.Forms.DataGridViewTextBoxColumn sonOdeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn kartLimit;
        private System.Windows.Forms.TextBox txtTaksitSayisi;
        private System.Windows.Forms.Label label1;
    }
}