namespace Elmar_Ticari_Plus
{
    partial class frmOdemeVeTahsilat
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
            this.label45 = new System.Windows.Forms.Label();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtDovizliTutar = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.txtDovizDegeri = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtAcklama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEskiBakiye = new System.Windows.Forms.TextBox();
            this.txtİslemTutarı = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbESubeler = new System.Windows.Forms.ComboBox();
            this.cmbEKullanicilar = new System.Windows.Forms.ComboBox();
            this.btnCariAra = new System.Windows.Forms.Button();
            this.cmbCariler = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtİslemTarihi = new System.Windows.Forms.DateTimePicker();
            this.cmbislemTipi = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtDovizKuru = new System.Windows.Forms.ComboBox();
            this.lblPesinat = new System.Windows.Forms.Label();
            this.txtPesinat = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBelgeNo = new System.Windows.Forms.TextBox();
            this.btnCariEkle = new System.Windows.Forms.Button();
            this.lblDurumEskiBakiye = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtYeniBakiye = new System.Windows.Forms.TextBox();
            this.lblDurumYeniBakiye = new System.Windows.Forms.Label();
            this.btnKaydet2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnKaydetveYazdir2 = new System.Windows.Forms.Button();
            this.btnTemizle2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.vadeTarihi = new System.Windows.Forms.DateTimePicker();
            this.chbSenet = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label45.ForeColor = System.Drawing.Color.DarkRed;
            this.label45.Location = new System.Drawing.Point(3, 66);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(35, 15);
            this.label45.TabIndex = 0;
            this.label45.Text = "Tutar";
            // 
            // txtTutar
            // 
            this.txtTutar.BackColor = System.Drawing.Color.White;
            this.txtTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTutar.ForeColor = System.Drawing.Color.Black;
            this.txtTutar.Location = new System.Drawing.Point(106, 63);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(115, 22);
            this.txtTutar.TabIndex = 4;
            this.txtTutar.Tag = "221";
            this.txtTutar.Text = "0";
            this.txtTutar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTutar.TextChanged += new System.EventHandler(this.txtTutar_TextChanged);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label43.ForeColor = System.Drawing.Color.DarkRed;
            this.label43.Location = new System.Drawing.Point(3, 153);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(74, 15);
            this.label43.TabIndex = 0;
            this.label43.Text = "Dovizli Tutar";
            // 
            // txtDovizliTutar
            // 
            this.txtDovizliTutar.BackColor = System.Drawing.Color.White;
            this.txtDovizliTutar.Enabled = false;
            this.txtDovizliTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDovizliTutar.ForeColor = System.Drawing.Color.Black;
            this.txtDovizliTutar.Location = new System.Drawing.Point(106, 150);
            this.txtDovizliTutar.Name = "txtDovizliTutar";
            this.txtDovizliTutar.ReadOnly = true;
            this.txtDovizliTutar.Size = new System.Drawing.Size(115, 22);
            this.txtDovizliTutar.TabIndex = 8;
            this.txtDovizliTutar.Tag = "001";
            this.txtDovizliTutar.Text = "0";
            this.txtDovizliTutar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label42.ForeColor = System.Drawing.Color.DarkRed;
            this.label42.Location = new System.Drawing.Point(3, 131);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(66, 15);
            this.label42.TabIndex = 0;
            this.label42.Text = "Döviz Kuru";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label41.ForeColor = System.Drawing.Color.DarkRed;
            this.label41.Location = new System.Drawing.Point(3, 110);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(37, 15);
            this.label41.TabIndex = 0;
            this.label41.Text = "Doviz";
            // 
            // txtDovizDegeri
            // 
            this.txtDovizDegeri.BackColor = System.Drawing.Color.White;
            this.txtDovizDegeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDovizDegeri.ForeColor = System.Drawing.Color.Black;
            this.txtDovizDegeri.Location = new System.Drawing.Point(106, 128);
            this.txtDovizDegeri.Name = "txtDovizDegeri";
            this.txtDovizDegeri.Size = new System.Drawing.Size(115, 22);
            this.txtDovizDegeri.TabIndex = 7;
            this.txtDovizDegeri.Tag = "221";
            this.txtDovizDegeri.Text = "1";
            this.txtDovizDegeri.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDovizDegeri.TextChanged += new System.EventHandler(this.txtDovizDegeri_TextChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label39.ForeColor = System.Drawing.Color.DarkRed;
            this.label39.Location = new System.Drawing.Point(3, 239);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(57, 15);
            this.label39.TabIndex = 0;
            this.label39.Text = "Açıklama";
            // 
            // txtAcklama
            // 
            this.txtAcklama.BackColor = System.Drawing.Color.White;
            this.txtAcklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAcklama.ForeColor = System.Drawing.Color.Black;
            this.txtAcklama.Location = new System.Drawing.Point(106, 239);
            this.txtAcklama.Multiline = true;
            this.txtAcklama.Name = "txtAcklama";
            this.txtAcklama.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAcklama.Size = new System.Drawing.Size(269, 53);
            this.txtAcklama.TabIndex = 11;
            this.txtAcklama.Tag = "001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-21, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(547, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "_________________________________________________________________________________" +
    "_________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(2, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Eski Bakiye";
            // 
            // txtEskiBakiye
            // 
            this.txtEskiBakiye.BackColor = System.Drawing.Color.White;
            this.txtEskiBakiye.Enabled = false;
            this.txtEskiBakiye.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEskiBakiye.ForeColor = System.Drawing.Color.Black;
            this.txtEskiBakiye.Location = new System.Drawing.Point(106, 324);
            this.txtEskiBakiye.Name = "txtEskiBakiye";
            this.txtEskiBakiye.ReadOnly = true;
            this.txtEskiBakiye.Size = new System.Drawing.Size(137, 26);
            this.txtEskiBakiye.TabIndex = 66;
            this.txtEskiBakiye.TabStop = false;
            this.txtEskiBakiye.Tag = "001";
            this.txtEskiBakiye.Text = "0";
            this.txtEskiBakiye.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEskiBakiye.TextChanged += new System.EventHandler(this.txtEskiBakiye_TextChanged);
            // 
            // txtİslemTutarı
            // 
            this.txtİslemTutarı.BackColor = System.Drawing.Color.White;
            this.txtİslemTutarı.Enabled = false;
            this.txtİslemTutarı.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtİslemTutarı.ForeColor = System.Drawing.Color.Black;
            this.txtİslemTutarı.Location = new System.Drawing.Point(106, 350);
            this.txtİslemTutarı.Name = "txtİslemTutarı";
            this.txtİslemTutarı.ReadOnly = true;
            this.txtİslemTutarı.Size = new System.Drawing.Size(137, 26);
            this.txtİslemTutarı.TabIndex = 68;
            this.txtİslemTutarı.TabStop = false;
            this.txtİslemTutarı.Tag = "001";
            this.txtİslemTutarı.Text = "0";
            this.txtİslemTutarı.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtİslemTutarı.TextChanged += new System.EventHandler(this.txtEskiBakiye_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(2, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "İşlem Tutarı";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(2, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Şube - Kullanıcı";
            // 
            // cmbESubeler
            // 
            this.cmbESubeler.BackColor = System.Drawing.Color.White;
            this.cmbESubeler.ForeColor = System.Drawing.Color.Black;
            this.cmbESubeler.FormattingEnabled = true;
            this.cmbESubeler.Location = new System.Drawing.Point(106, 294);
            this.cmbESubeler.Name = "cmbESubeler";
            this.cmbESubeler.Size = new System.Drawing.Size(115, 21);
            this.cmbESubeler.TabIndex = 12;
            this.cmbESubeler.Tag = "001";
            this.cmbESubeler.SelectedIndexChanged += new System.EventHandler(this.cmbESubeler_SelectedIndexChanged);
            // 
            // cmbEKullanicilar
            // 
            this.cmbEKullanicilar.BackColor = System.Drawing.Color.White;
            this.cmbEKullanicilar.ForeColor = System.Drawing.Color.Black;
            this.cmbEKullanicilar.FormattingEnabled = true;
            this.cmbEKullanicilar.Location = new System.Drawing.Point(221, 294);
            this.cmbEKullanicilar.Name = "cmbEKullanicilar";
            this.cmbEKullanicilar.Size = new System.Drawing.Size(155, 21);
            this.cmbEKullanicilar.TabIndex = 13;
            this.cmbEKullanicilar.Tag = "001";
            // 
            // btnCariAra
            // 
            this.btnCariAra.Location = new System.Drawing.Point(336, 3);
            this.btnCariAra.Name = "btnCariAra";
            this.btnCariAra.Size = new System.Drawing.Size(24, 23);
            this.btnCariAra.TabIndex = 2;
            this.btnCariAra.Text = "...";
            this.btnCariAra.UseVisualStyleBackColor = false;
            this.btnCariAra.Visible = false;
            this.btnCariAra.Click += new System.EventHandler(this.btnCariAra_Click);
            // 
            // cmbCariler
            // 
            this.cmbCariler.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCariler.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCariler.BackColor = System.Drawing.Color.White;
            this.cmbCariler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCariler.ForeColor = System.Drawing.Color.Black;
            this.cmbCariler.FormattingEnabled = true;
            this.cmbCariler.Location = new System.Drawing.Point(59, 4);
            this.cmbCariler.Name = "cmbCariler";
            this.cmbCariler.Size = new System.Drawing.Size(277, 24);
            this.cmbCariler.TabIndex = 1;
            this.cmbCariler.Tag = "001";
            this.cmbCariler.SelectedIndexChanged += new System.EventHandler(this.cmbCariler_SelectedIndexChanged);
            this.cmbCariler.TextChanged += new System.EventHandler(this.cmbCariler_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(2, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cari Seçimi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-90, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(547, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "_________________________________________________________________________________" +
    "_________";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(3, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "İşlem Tarihi";
            // 
            // dtİslemTarihi
            // 
            this.dtİslemTarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtİslemTarihi.Location = new System.Drawing.Point(106, 195);
            this.dtİslemTarihi.Name = "dtİslemTarihi";
            this.dtİslemTarihi.Size = new System.Drawing.Size(269, 21);
            this.dtİslemTarihi.TabIndex = 10;
            // 
            // cmbislemTipi
            // 
            this.cmbislemTipi.BackColor = System.Drawing.Color.White;
            this.cmbislemTipi.ForeColor = System.Drawing.Color.Black;
            this.cmbislemTipi.FormattingEnabled = true;
            this.cmbislemTipi.Items.AddRange(new object[] {
            "Ödeme",
            "Tahsilat"});
            this.cmbislemTipi.Location = new System.Drawing.Point(106, 173);
            this.cmbislemTipi.Name = "cmbislemTipi";
            this.cmbislemTipi.Size = new System.Drawing.Size(115, 21);
            this.cmbislemTipi.TabIndex = 9;
            this.cmbislemTipi.Tag = "001";
            this.cmbislemTipi.Text = "Tahsilat";
            this.cmbislemTipi.SelectedIndexChanged += new System.EventHandler(this.txtTutar_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(3, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "İşlem Tipi";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDurum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 465);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(386, 22);
            this.statusStrip1.TabIndex = 82;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblDurum
            // 
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(34, 17);
            this.lblDurum.Text = "Hazır";
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
            this.txtDovizKuru.Location = new System.Drawing.Point(106, 107);
            this.txtDovizKuru.Name = "txtDovizKuru";
            this.txtDovizKuru.Size = new System.Drawing.Size(115, 21);
            this.txtDovizKuru.TabIndex = 6;
            this.txtDovizKuru.Tag = "001";
            this.txtDovizKuru.Text = "TL";
            this.txtDovizKuru.SelectedIndexChanged += new System.EventHandler(this.txtDovizKuru_SelectedIndexChanged);
            // 
            // lblPesinat
            // 
            this.lblPesinat.AutoSize = true;
            this.lblPesinat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPesinat.ForeColor = System.Drawing.Color.DarkRed;
            this.lblPesinat.Location = new System.Drawing.Point(3, 88);
            this.lblPesinat.Name = "lblPesinat";
            this.lblPesinat.Size = new System.Drawing.Size(48, 15);
            this.lblPesinat.TabIndex = 0;
            this.lblPesinat.Text = "Peşinat";
            this.lblPesinat.Visible = false;
            // 
            // txtPesinat
            // 
            this.txtPesinat.BackColor = System.Drawing.Color.White;
            this.txtPesinat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPesinat.ForeColor = System.Drawing.Color.Black;
            this.txtPesinat.Location = new System.Drawing.Point(106, 85);
            this.txtPesinat.Name = "txtPesinat";
            this.txtPesinat.Size = new System.Drawing.Size(115, 22);
            this.txtPesinat.TabIndex = 5;
            this.txtPesinat.Tag = "221";
            this.txtPesinat.Text = "0";
            this.txtPesinat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPesinat.Visible = false;
            this.txtPesinat.TextChanged += new System.EventHandler(this.txtTutar_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.DarkRed;
            this.label11.Location = new System.Drawing.Point(3, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 15);
            this.label11.TabIndex = 123;
            this.label11.Text = "Belge No";
            // 
            // txtBelgeNo
            // 
            this.txtBelgeNo.BackColor = System.Drawing.Color.White;
            this.txtBelgeNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBelgeNo.ForeColor = System.Drawing.Color.Black;
            this.txtBelgeNo.Location = new System.Drawing.Point(106, 40);
            this.txtBelgeNo.Name = "txtBelgeNo";
            this.txtBelgeNo.Size = new System.Drawing.Size(115, 22);
            this.txtBelgeNo.TabIndex = 3;
            this.txtBelgeNo.Tag = "001";
            this.txtBelgeNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCariEkle
            // 
            this.btnCariEkle.Image = global::Elmar_Ticari_Plus.Properties.Resources.genelEkle;
            this.btnCariEkle.Location = new System.Drawing.Point(359, 3);
            this.btnCariEkle.Name = "btnCariEkle";
            this.btnCariEkle.Size = new System.Drawing.Size(23, 23);
            this.btnCariEkle.TabIndex = 3;
            this.btnCariEkle.UseVisualStyleBackColor = false;
            this.btnCariEkle.Visible = false;
            this.btnCariEkle.Click += new System.EventHandler(this.btnCariEkle_Click);
            // 
            // lblDurumEskiBakiye
            // 
            this.lblDurumEskiBakiye.AutoSize = true;
            this.lblDurumEskiBakiye.Location = new System.Drawing.Point(249, 332);
            this.lblDurumEskiBakiye.Name = "lblDurumEskiBakiye";
            this.lblDurumEskiBakiye.Size = new System.Drawing.Size(10, 13);
            this.lblDurumEskiBakiye.TabIndex = 124;
            this.lblDurumEskiBakiye.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(2, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Yeni Bakiye";
            // 
            // txtYeniBakiye
            // 
            this.txtYeniBakiye.BackColor = System.Drawing.Color.White;
            this.txtYeniBakiye.Enabled = false;
            this.txtYeniBakiye.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYeniBakiye.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtYeniBakiye.Location = new System.Drawing.Point(106, 375);
            this.txtYeniBakiye.Name = "txtYeniBakiye";
            this.txtYeniBakiye.ReadOnly = true;
            this.txtYeniBakiye.Size = new System.Drawing.Size(137, 29);
            this.txtYeniBakiye.TabIndex = 70;
            this.txtYeniBakiye.TabStop = false;
            this.txtYeniBakiye.Tag = "001";
            this.txtYeniBakiye.Text = "0";
            this.txtYeniBakiye.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDurumYeniBakiye
            // 
            this.lblDurumYeniBakiye.AutoSize = true;
            this.lblDurumYeniBakiye.Location = new System.Drawing.Point(249, 385);
            this.lblDurumYeniBakiye.Name = "lblDurumYeniBakiye";
            this.lblDurumYeniBakiye.Size = new System.Drawing.Size(10, 13);
            this.lblDurumYeniBakiye.TabIndex = 125;
            this.lblDurumYeniBakiye.Text = "-";
            // 
            // btnKaydet2
            // 
            this.btnKaydet2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydet2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet2.ForeColor = System.Drawing.Color.Black;
            this.btnKaydet2.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydet2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet2.Location = new System.Drawing.Point(281, 425);
            this.btnKaydet2.Name = "btnKaydet2";
            this.btnKaydet2.Size = new System.Drawing.Size(99, 41);
            this.btnKaydet2.TabIndex = 11128;
            this.btnKaydet2.TabStop = false;
            this.btnKaydet2.Text = "[F4] Kaydet";
            this.btnKaydet2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet2.UseVisualStyleBackColor = false;
            this.btnKaydet2.Click += new System.EventHandler(this.btnKaydet2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(-18, 409);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(547, 13);
            this.label10.TabIndex = 11129;
            this.label10.Text = "_________________________________________________________________________________" +
    "_________";
            // 
            // btnKaydetveYazdir2
            // 
            this.btnKaydetveYazdir2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydetveYazdir2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydetveYazdir2.ForeColor = System.Drawing.Color.Black;
            this.btnKaydetveYazdir2.Image = global::Elmar_Ticari_Plus.Properties.Resources._2_Hot_Printer_icon;
            this.btnKaydetveYazdir2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydetveYazdir2.Location = new System.Drawing.Point(131, 425);
            this.btnKaydetveYazdir2.Name = "btnKaydetveYazdir2";
            this.btnKaydetveYazdir2.Size = new System.Drawing.Size(140, 41);
            this.btnKaydetveYazdir2.TabIndex = 11130;
            this.btnKaydetveYazdir2.TabStop = false;
            this.btnKaydetveYazdir2.Text = "Kaydet ve Yazdır";
            this.btnKaydetveYazdir2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydetveYazdir2.UseVisualStyleBackColor = false;
            this.btnKaydetveYazdir2.Click += new System.EventHandler(this.btnKaydetveYazdir2_Click);
            // 
            // btnTemizle2
            // 
            this.btnTemizle2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnTemizle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnTemizle2.ForeColor = System.Drawing.Color.Black;
            this.btnTemizle2.Image = global::Elmar_Ticari_Plus.Properties.Resources.Close_2_icon;
            this.btnTemizle2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTemizle2.Location = new System.Drawing.Point(5, 425);
            this.btnTemizle2.Name = "btnTemizle2";
            this.btnTemizle2.Size = new System.Drawing.Size(117, 41);
            this.btnTemizle2.TabIndex = 11131;
            this.btnTemizle2.TabStop = false;
            this.btnTemizle2.Text = "[ESC] Temizle";
            this.btnTemizle2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTemizle2.UseVisualStyleBackColor = false;
            this.btnTemizle2.Click += new System.EventHandler(this.btnTemizle2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.Color.DarkRed;
            this.label12.Location = new System.Drawing.Point(3, 221);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 15);
            this.label12.TabIndex = 11132;
            this.label12.Text = "Vade Tarihi";
            // 
            // vadeTarihi
            // 
            this.vadeTarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.vadeTarihi.Location = new System.Drawing.Point(107, 219);
            this.vadeTarihi.Name = "vadeTarihi";
            this.vadeTarihi.Size = new System.Drawing.Size(269, 21);
            this.vadeTarihi.TabIndex = 11133;
            // 
            // chbSenet
            // 
            this.chbSenet.AutoSize = true;
            this.chbSenet.Location = new System.Drawing.Point(164, 404);
            this.chbSenet.Name = "chbSenet";
            this.chbSenet.Size = new System.Drawing.Size(81, 17);
            this.chbSenet.TabIndex = 11134;
            this.chbSenet.Text = "Senet Çıkar";
            this.chbSenet.UseVisualStyleBackColor = true;
            // 
            // frmOdemeVeTahsilat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(386, 487);
            this.Controls.Add(this.chbSenet);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.vadeTarihi);
            this.Controls.Add(this.btnTemizle2);
            this.Controls.Add(this.btnKaydetveYazdir2);
            this.Controls.Add(this.btnKaydet2);
            this.Controls.Add(this.lblDurumYeniBakiye);
            this.Controls.Add(this.lblDurumEskiBakiye);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBelgeNo);
            this.Controls.Add(this.txtPesinat);
            this.Controls.Add(this.txtDovizKuru);
            this.Controls.Add(this.cmbCariler);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmbislemTipi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtİslemTarihi);
            this.Controls.Add(this.btnCariAra);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCariEkle);
            this.Controls.Add(this.cmbEKullanicilar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbESubeler);
            this.Controls.Add(this.txtYeniBakiye);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtİslemTutarı);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEskiBakiye);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.txtDovizliTutar);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.txtDovizDegeri);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.txtAcklama);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblPesinat);
            this.Controls.Add(this.label10);
            this.KeyPreview = true;
            this.Name = "frmOdemeVeTahsilat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ödeme ve Tahsilat Oluştur";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOdemeVeTahsilat_FormClosing);
            this.Load += new System.EventHandler(this.frmOdemeVeTahsilat_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOdemeVeTahsilat_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txtTutar;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtDovizliTutar;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtDovizDegeri;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtAcklama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEskiBakiye;
        private System.Windows.Forms.TextBox txtİslemTutarı;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbESubeler;
        private System.Windows.Forms.ComboBox cmbEKullanicilar;
        private System.Windows.Forms.Button btnCariAra;
        private System.Windows.Forms.ComboBox cmbCariler;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCariEkle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtİslemTarihi;
        private System.Windows.Forms.ComboBox cmbislemTipi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblDurum;
        private System.Windows.Forms.ComboBox txtDovizKuru;
        private System.Windows.Forms.Label lblPesinat;
        private System.Windows.Forms.TextBox txtPesinat;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBelgeNo;
        private System.Windows.Forms.Label lblDurumEskiBakiye;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtYeniBakiye;
        private System.Windows.Forms.Label lblDurumYeniBakiye;
        private System.Windows.Forms.Button btnKaydet2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnKaydetveYazdir2;
        private System.Windows.Forms.Button btnTemizle2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker vadeTarihi;
        private System.Windows.Forms.CheckBox chbSenet;
    }
}