namespace Elmar_Ticari_Plus
{
    partial class frmKasaParaTransferi
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
            this.cmbESubeler2 = new System.Windows.Forms.ComboBox();
            this.cmbEKullanicilar2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDovizKuru = new System.Windows.Forms.ComboBox();
            this.txtAcklama = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtDovizDegeri = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDovizliTutar = new System.Windows.Forms.TextBox();
            this.dtİslemTarihi = new System.Windows.Forms.DateTimePicker();
            this.label43 = new System.Windows.Forms.Label();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.lblDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.cmbESubeler = new System.Windows.Forms.ComboBox();
            this.cmbEKullanicilar = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbESubeler2
            // 
            this.cmbESubeler2.BackColor = System.Drawing.Color.White;
            this.cmbESubeler2.ForeColor = System.Drawing.Color.Black;
            this.cmbESubeler2.FormattingEnabled = true;
            this.cmbESubeler2.Location = new System.Drawing.Point(113, 248);
            this.cmbESubeler2.Name = "cmbESubeler2";
            this.cmbESubeler2.Size = new System.Drawing.Size(115, 21);
            this.cmbESubeler2.TabIndex = 156;
            this.cmbESubeler2.Tag = "001";
            this.cmbESubeler2.SelectedIndexChanged += new System.EventHandler(this.cmbESubeler2_SelectedIndexChanged);
            // 
            // cmbEKullanicilar2
            // 
            this.cmbEKullanicilar2.BackColor = System.Drawing.Color.White;
            this.cmbEKullanicilar2.ForeColor = System.Drawing.Color.Black;
            this.cmbEKullanicilar2.FormattingEnabled = true;
            this.cmbEKullanicilar2.Location = new System.Drawing.Point(228, 248);
            this.cmbEKullanicilar2.Name = "cmbEKullanicilar2";
            this.cmbEKullanicilar2.Size = new System.Drawing.Size(155, 21);
            this.cmbEKullanicilar2.TabIndex = 157;
            this.cmbEKullanicilar2.Tag = "001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(9, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 30);
            this.label1.TabIndex = 155;
            this.label1.Text = "Şube - Kullanıcı\r\n(Aktarılacak)";
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
            this.txtDovizKuru.Location = new System.Drawing.Point(113, 31);
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
            this.txtAcklama.Location = new System.Drawing.Point(113, 120);
            this.txtAcklama.Multiline = true;
            this.txtAcklama.Name = "txtAcklama";
            this.txtAcklama.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAcklama.Size = new System.Drawing.Size(269, 89);
            this.txtAcklama.TabIndex = 152;
            this.txtAcklama.Tag = "001";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label39.ForeColor = System.Drawing.Color.DarkRed;
            this.label39.Location = new System.Drawing.Point(9, 123);
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
            this.txtDovizDegeri.Location = new System.Drawing.Point(113, 52);
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
            this.label41.Location = new System.Drawing.Point(9, 34);
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
            this.label42.Location = new System.Drawing.Point(9, 55);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(66, 15);
            this.label42.TabIndex = 135;
            this.label42.Text = "Döviz Kuru";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(9, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 138;
            this.label8.Text = "İşlem Tarihi";
            // 
            // txtDovizliTutar
            // 
            this.txtDovizliTutar.BackColor = System.Drawing.Color.White;
            this.txtDovizliTutar.Enabled = false;
            this.txtDovizliTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDovizliTutar.ForeColor = System.Drawing.Color.Black;
            this.txtDovizliTutar.Location = new System.Drawing.Point(113, 74);
            this.txtDovizliTutar.Name = "txtDovizliTutar";
            this.txtDovizliTutar.ReadOnly = true;
            this.txtDovizliTutar.Size = new System.Drawing.Size(115, 22);
            this.txtDovizliTutar.TabIndex = 149;
            this.txtDovizliTutar.Tag = "001";
            this.txtDovizliTutar.Text = "0";
            this.txtDovizliTutar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtİslemTarihi
            // 
            this.dtİslemTarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtİslemTarihi.Location = new System.Drawing.Point(113, 97);
            this.dtİslemTarihi.Name = "dtİslemTarihi";
            this.dtİslemTarihi.Size = new System.Drawing.Size(269, 21);
            this.dtİslemTarihi.TabIndex = 151;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label43.ForeColor = System.Drawing.Color.DarkRed;
            this.label43.Location = new System.Drawing.Point(9, 77);
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
            this.txtTutar.Location = new System.Drawing.Point(113, 9);
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
            this.label45.Location = new System.Drawing.Point(9, 12);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(97, 15);
            this.label45.TabIndex = 128;
            this.label45.Text = "Aktarılacak Tutar";
            // 
            // lblDurum
            // 
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(34, 17);
            this.lblDurum.Text = "Hazır";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDurum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 373);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(384, 22);
            this.statusStrip1.TabIndex = 172;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // cmbESubeler
            // 
            this.cmbESubeler.BackColor = System.Drawing.Color.White;
            this.cmbESubeler.ForeColor = System.Drawing.Color.Black;
            this.cmbESubeler.FormattingEnabled = true;
            this.cmbESubeler.Location = new System.Drawing.Point(113, 211);
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
            this.cmbEKullanicilar.Location = new System.Drawing.Point(228, 211);
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
            this.label5.Location = new System.Drawing.Point(9, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 30);
            this.label5.TabIndex = 134;
            this.label5.Text = "Şube - Kullanıcı\r\n(Aktaran)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbESubeler2);
            this.panel1.Controls.Add(this.cmbEKullanicilar2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDovizKuru);
            this.panel1.Controls.Add(this.txtAcklama);
            this.panel1.Controls.Add(this.label39);
            this.panel1.Controls.Add(this.txtDovizDegeri);
            this.panel1.Controls.Add(this.label41);
            this.panel1.Controls.Add(this.label42);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtDovizliTutar);
            this.panel1.Controls.Add(this.dtİslemTarihi);
            this.panel1.Controls.Add(this.label43);
            this.panel1.Controls.Add(this.txtTutar);
            this.panel1.Controls.Add(this.label45);
            this.panel1.Controls.Add(this.cmbESubeler);
            this.panel1.Controls.Add(this.cmbEKullanicilar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 289);
            this.panel1.TabIndex = 174;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydet.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(147, 335);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(90, 32);
            this.btnKaydet.TabIndex = 158;
            this.btnKaydet.Tag = "0";
            this.btnKaydet.Text = "Kaydet[F4]";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
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
            this.panel3.Size = new System.Drawing.Size(384, 42);
            this.panel3.TabIndex = 176;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(52, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Şubeler Arası Para Transferi";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::Elmar_Ticari_Plus.Properties.Resources.transfer_icon2;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmKasaParaTransferi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(384, 395);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "frmKasaParaTransferi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Şubeler Arası Para Transferi";
            this.Load += new System.EventHandler(this.frmKasaParaTransferi_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbESubeler2;
        private System.Windows.Forms.ComboBox cmbEKullanicilar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtDovizKuru;
        private System.Windows.Forms.TextBox txtAcklama;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtDovizDegeri;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDovizliTutar;
        private System.Windows.Forms.DateTimePicker dtİslemTarihi;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtTutar;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ToolStripStatusLabel lblDurum;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ComboBox cmbESubeler;
        private System.Windows.Forms.ComboBox cmbEKullanicilar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}