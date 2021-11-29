namespace Elmar_Ticari_Plus
{
    partial class frmTaksitOde
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
            this.cmbCariler = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.cmbislemTipi = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtİslemTarihi = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbEKullanicilar = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbESubeler = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnKaydet = new System.Windows.Forms.ToolStripButton();
            this.btnTemizle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtDovizliTutar = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.txtDovizDegeri = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtAcklama = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDovizKuru = new System.Windows.Forms.ComboBox();
            this.dgTaksitGor = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPesinatDoviz = new System.Windows.Forms.Label();
            this.btnCiktiOnizleme = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTaksitGor)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCariler
            // 
            this.cmbCariler.BackColor = System.Drawing.Color.White;
            this.cmbCariler.ForeColor = System.Drawing.Color.Black;
            this.cmbCariler.FormattingEnabled = true;
            this.cmbCariler.Location = new System.Drawing.Point(60, 5);
            this.cmbCariler.Name = "cmbCariler";
            this.cmbCariler.Size = new System.Drawing.Size(291, 21);
            this.cmbCariler.TabIndex = 2;
            this.cmbCariler.Tag = "001";
            this.cmbCariler.SelectedIndexChanged += new System.EventHandler(this.cmbCariler_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDurum,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 327);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(834, 22);
            this.statusStrip1.TabIndex = 113;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblDurum
            // 
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(34, 17);
            this.lblDurum.Text = "Hazır";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // cmbislemTipi
            // 
            this.cmbislemTipi.BackColor = System.Drawing.Color.White;
            this.cmbislemTipi.ForeColor = System.Drawing.Color.Black;
            this.cmbislemTipi.FormattingEnabled = true;
            this.cmbislemTipi.Items.AddRange(new object[] {
            "Ödeme",
            "Tahsilat"});
            this.cmbislemTipi.Location = new System.Drawing.Point(107, 137);
            this.cmbislemTipi.Name = "cmbislemTipi";
            this.cmbislemTipi.Size = new System.Drawing.Size(115, 21);
            this.cmbislemTipi.TabIndex = 6;
            this.cmbislemTipi.Tag = "001";
            this.cmbislemTipi.Text = "Tahsilat";
            this.cmbislemTipi.SelectedIndexChanged += new System.EventHandler(this.cmbislemTipi_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(3, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 112;
            this.label9.Text = "İşlem Tipi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(3, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 110;
            this.label8.Text = "İşlem Tarihi";
            // 
            // dtİslemTarihi
            // 
            this.dtİslemTarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtİslemTarihi.Location = new System.Drawing.Point(107, 159);
            this.dtİslemTarihi.Name = "dtİslemTarihi";
            this.dtİslemTarihi.Size = new System.Drawing.Size(244, 21);
            this.dtİslemTarihi.TabIndex = 7;
            this.dtİslemTarihi.Tag = "001";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 105;
            this.label6.Text = "Cari Seçimi";
            // 
            // cmbEKullanicilar
            // 
            this.cmbEKullanicilar.BackColor = System.Drawing.Color.White;
            this.cmbEKullanicilar.ForeColor = System.Drawing.Color.Black;
            this.cmbEKullanicilar.FormattingEnabled = true;
            this.cmbEKullanicilar.Location = new System.Drawing.Point(222, 272);
            this.cmbEKullanicilar.Name = "cmbEKullanicilar";
            this.cmbEKullanicilar.Size = new System.Drawing.Size(129, 21);
            this.cmbEKullanicilar.TabIndex = 10;
            this.cmbEKullanicilar.Tag = "001";
            this.cmbEKullanicilar.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(3, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 103;
            this.label5.Text = "Şube - Kullanıcı";
            this.label5.Visible = false;
            // 
            // cmbESubeler
            // 
            this.cmbESubeler.BackColor = System.Drawing.Color.White;
            this.cmbESubeler.ForeColor = System.Drawing.Color.Black;
            this.cmbESubeler.FormattingEnabled = true;
            this.cmbESubeler.Location = new System.Drawing.Point(107, 272);
            this.cmbESubeler.Name = "cmbESubeler";
            this.cmbESubeler.Size = new System.Drawing.Size(115, 21);
            this.cmbESubeler.TabIndex = 9;
            this.cmbESubeler.Tag = "001";
            this.cmbESubeler.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnKaydet,
            this.btnTemizle,
            this.btnCiktiOnizleme,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(834, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Image = global::Elmar_Ticari_Plus.Properties.Resources.genelEkle;
            this.btnKaydet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(63, 22);
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.ToolTipText = "Bilgileri Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnTemizle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Image = global::Elmar_Ticari_Plus.Properties.Resources.faturaiptal1;
            this.btnTemizle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(66, 22);
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.ToolTipText = "Bilgileri Kaydet";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-20, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(547, 13);
            this.label1.TabIndex = 95;
            this.label1.Text = "_________________________________________________________________________________" +
    "_________";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label45.ForeColor = System.Drawing.Color.DarkRed;
            this.label45.Location = new System.Drawing.Point(3, 51);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(68, 15);
            this.label45.TabIndex = 94;
            this.label45.Text = "İşlem Tutar";
            // 
            // txtTutar
            // 
            this.txtTutar.BackColor = System.Drawing.Color.White;
            this.txtTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTutar.ForeColor = System.Drawing.Color.Black;
            this.txtTutar.Location = new System.Drawing.Point(107, 48);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(115, 22);
            this.txtTutar.TabIndex = 3;
            this.txtTutar.Tag = "221";
            this.txtTutar.Text = "0";
            this.txtTutar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTutar.TextChanged += new System.EventHandler(this.txtDovizDegeri_TextChanged);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label43.ForeColor = System.Drawing.Color.DarkRed;
            this.label43.Location = new System.Drawing.Point(3, 117);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(74, 15);
            this.label43.TabIndex = 92;
            this.label43.Text = "Dovizli Tutar";
            // 
            // txtDovizliTutar
            // 
            this.txtDovizliTutar.BackColor = System.Drawing.Color.White;
            this.txtDovizliTutar.Enabled = false;
            this.txtDovizliTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDovizliTutar.ForeColor = System.Drawing.Color.Black;
            this.txtDovizliTutar.Location = new System.Drawing.Point(107, 114);
            this.txtDovizliTutar.Name = "txtDovizliTutar";
            this.txtDovizliTutar.ReadOnly = true;
            this.txtDovizliTutar.Size = new System.Drawing.Size(115, 22);
            this.txtDovizliTutar.TabIndex = 91;
            this.txtDovizliTutar.TabStop = false;
            this.txtDovizliTutar.Tag = "001";
            this.txtDovizliTutar.Text = "0";
            this.txtDovizliTutar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDovizliTutar.TextChanged += new System.EventHandler(this.txtDovizliTutar_TextChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label42.ForeColor = System.Drawing.Color.DarkRed;
            this.label42.Location = new System.Drawing.Point(3, 94);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(66, 15);
            this.label42.TabIndex = 90;
            this.label42.Text = "Döviz Kuru";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label41.ForeColor = System.Drawing.Color.DarkRed;
            this.label41.Location = new System.Drawing.Point(3, 73);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(37, 15);
            this.label41.TabIndex = 89;
            this.label41.Text = "Doviz";
            // 
            // txtDovizDegeri
            // 
            this.txtDovizDegeri.BackColor = System.Drawing.Color.White;
            this.txtDovizDegeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDovizDegeri.ForeColor = System.Drawing.Color.Black;
            this.txtDovizDegeri.Location = new System.Drawing.Point(107, 91);
            this.txtDovizDegeri.Name = "txtDovizDegeri";
            this.txtDovizDegeri.Size = new System.Drawing.Size(115, 22);
            this.txtDovizDegeri.TabIndex = 5;
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
            this.label39.Location = new System.Drawing.Point(3, 185);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(57, 15);
            this.label39.TabIndex = 86;
            this.label39.Text = "Açıklama";
            // 
            // txtAcklama
            // 
            this.txtAcklama.BackColor = System.Drawing.Color.White;
            this.txtAcklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAcklama.ForeColor = System.Drawing.Color.Black;
            this.txtAcklama.Location = new System.Drawing.Point(107, 182);
            this.txtAcklama.Multiline = true;
            this.txtAcklama.Name = "txtAcklama";
            this.txtAcklama.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAcklama.Size = new System.Drawing.Size(244, 89);
            this.txtAcklama.TabIndex = 8;
            this.txtAcklama.Tag = "001";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-89, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(547, 13);
            this.label7.TabIndex = 108;
            this.label7.Text = "_________________________________________________________________________________" +
    "_________";
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
            this.txtDovizKuru.Location = new System.Drawing.Point(107, 70);
            this.txtDovizKuru.Name = "txtDovizKuru";
            this.txtDovizKuru.Size = new System.Drawing.Size(115, 21);
            this.txtDovizKuru.TabIndex = 4;
            this.txtDovizKuru.Tag = "001";
            this.txtDovizKuru.Text = "TL";
            this.txtDovizKuru.SelectedIndexChanged += new System.EventHandler(this.txtDovizKuru_SelectedIndexChanged);
            // 
            // dgTaksitGor
            // 
            this.dgTaksitGor.AllowUserToAddRows = false;
            this.dgTaksitGor.AllowUserToDeleteRows = false;
            this.dgTaksitGor.AllowUserToResizeColumns = false;
            this.dgTaksitGor.AllowUserToResizeRows = false;
            this.dgTaksitGor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgTaksitGor.BackgroundColor = System.Drawing.Color.White;
            this.dgTaksitGor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTaksitGor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTaksitGor.Location = new System.Drawing.Point(354, 25);
            this.dgTaksitGor.Name = "dgTaksitGor";
            this.dgTaksitGor.RowHeadersWidth = 10;
            this.dgTaksitGor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgTaksitGor.RowTemplate.Height = 20;
            this.dgTaksitGor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTaksitGor.Size = new System.Drawing.Size(480, 302);
            this.dgTaksitGor.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbCariler);
            this.panel1.Controls.Add(this.lblPesinatDoviz);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtDovizKuru);
            this.panel1.Controls.Add(this.txtAcklama);
            this.panel1.Controls.Add(this.label39);
            this.panel1.Controls.Add(this.txtDovizDegeri);
            this.panel1.Controls.Add(this.cmbislemTipi);
            this.panel1.Controls.Add(this.label41);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label42);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtDovizliTutar);
            this.panel1.Controls.Add(this.dtİslemTarihi);
            this.panel1.Controls.Add(this.label43);
            this.panel1.Controls.Add(this.txtTutar);
            this.panel1.Controls.Add(this.cmbEKullanicilar);
            this.panel1.Controls.Add(this.label45);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbESubeler);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 302);
            this.panel1.TabIndex = 1;
            this.panel1.TabStop = true;
            // 
            // lblPesinatDoviz
            // 
            this.lblPesinatDoviz.AutoSize = true;
            this.lblPesinatDoviz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPesinatDoviz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPesinatDoviz.ForeColor = System.Drawing.Color.DarkRed;
            this.lblPesinatDoviz.Location = new System.Drawing.Point(222, 118);
            this.lblPesinatDoviz.Name = "lblPesinatDoviz";
            this.lblPesinatDoviz.Size = new System.Drawing.Size(23, 17);
            this.lblPesinatDoviz.TabIndex = 115;
            this.lblPesinatDoviz.Text = "TL";
            // 
            // btnCiktiOnizleme
            // 
            this.btnCiktiOnizleme.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCiktiOnizleme.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCiktiOnizleme.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCiktiOnizleme.Image = global::Elmar_Ticari_Plus.Properties.Resources.print_icon;
            this.btnCiktiOnizleme.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCiktiOnizleme.Name = "btnCiktiOnizleme";
            this.btnCiktiOnizleme.Size = new System.Drawing.Size(101, 22);
            this.btnCiktiOnizleme.Text = "Çıktı Önizleme";
            this.btnCiktiOnizleme.ToolTipText = "Bilgileri Kaydet";
            this.btnCiktiOnizleme.Click += new System.EventHandler(this.btnCiktiOnizleme_Click);
            // 
            // frmTaksitOde
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(834, 349);
            this.Controls.Add(this.dgTaksitGor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmTaksitOde";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Taksit Öde \\ Taksit Tahsil Et";
            this.Load += new System.EventHandler(this.frmTaksitOde_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTaksitGor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCariler;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblDurum;
        private System.Windows.Forms.ComboBox cmbislemTipi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtİslemTarihi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbEKullanicilar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbESubeler;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnKaydet;
        private System.Windows.Forms.ToolStripButton btnTemizle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txtTutar;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtDovizliTutar;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtDovizDegeri;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtAcklama;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox txtDovizKuru;
        private System.Windows.Forms.DataGridView dgTaksitGor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Label lblPesinatDoviz;
        private System.Windows.Forms.ToolStripButton btnCiktiOnizleme;
    }
}