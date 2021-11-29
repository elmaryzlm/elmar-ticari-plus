namespace Elmar_Ticari_Plus
{
    partial class frmBankaHesapEkle
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
            this.txtAyrinti = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIban = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHesapNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtHesapAdi = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.grpHesapTuru = new System.Windows.Forms.GroupBox();
            this.cmbCariler = new System.Windows.Forms.ComboBox();
            this.rdCariHesabi = new System.Windows.Forms.RadioButton();
            this.rdKendiHesabim = new System.Windows.Forms.RadioButton();
            this.cmbBankalar = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubeNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpHesapTuru.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAyrinti
            // 
            this.txtAyrinti.BackColor = System.Drawing.Color.White;
            this.txtAyrinti.ForeColor = System.Drawing.Color.Black;
            this.txtAyrinti.Location = new System.Drawing.Point(61, 220);
            this.txtAyrinti.MaxLength = 250;
            this.txtAyrinti.Multiline = true;
            this.txtAyrinti.Name = "txtAyrinti";
            this.txtAyrinti.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAyrinti.Size = new System.Drawing.Size(307, 56);
            this.txtAyrinti.TabIndex = 10;
            this.txtAyrinti.Tag = "001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "Ayrıntı";
            // 
            // txtIban
            // 
            this.txtIban.BackColor = System.Drawing.Color.White;
            this.txtIban.ForeColor = System.Drawing.Color.Black;
            this.txtIban.Location = new System.Drawing.Point(61, 116);
            this.txtIban.Name = "txtIban";
            this.txtIban.Size = new System.Drawing.Size(303, 20);
            this.txtIban.TabIndex = 6;
            this.txtIban.Tag = "001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 87;
            this.label2.Text = "IBAN";
            // 
            // txtHesapNo
            // 
            this.txtHesapNo.BackColor = System.Drawing.Color.White;
            this.txtHesapNo.ForeColor = System.Drawing.Color.Black;
            this.txtHesapNo.Location = new System.Drawing.Point(61, 64);
            this.txtHesapNo.Name = "txtHesapNo";
            this.txtHesapNo.Size = new System.Drawing.Size(303, 20);
            this.txtHesapNo.TabIndex = 4;
            this.txtHesapNo.Tag = "001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = "Hesap No";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydet.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(293, 280);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(74, 30);
            this.btnKaydet.TabIndex = 11;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtHesapAdi
            // 
            this.txtHesapAdi.BackColor = System.Drawing.Color.White;
            this.txtHesapAdi.ForeColor = System.Drawing.Color.Black;
            this.txtHesapAdi.Location = new System.Drawing.Point(61, 38);
            this.txtHesapAdi.Name = "txtHesapAdi";
            this.txtHesapAdi.Size = new System.Drawing.Size(242, 20);
            this.txtHesapAdi.TabIndex = 3;
            this.txtHesapAdi.Tag = "001";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(-1, 42);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 13);
            this.label19.TabIndex = 82;
            this.label19.Text = "Hesap Adı";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(-1, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 13);
            this.label18.TabIndex = 81;
            this.label18.Text = "Banka Adı";
            // 
            // grpHesapTuru
            // 
            this.grpHesapTuru.Controls.Add(this.cmbCariler);
            this.grpHesapTuru.Controls.Add(this.rdCariHesabi);
            this.grpHesapTuru.Controls.Add(this.rdKendiHesabim);
            this.grpHesapTuru.Location = new System.Drawing.Point(2, 142);
            this.grpHesapTuru.Name = "grpHesapTuru";
            this.grpHesapTuru.Size = new System.Drawing.Size(366, 65);
            this.grpHesapTuru.TabIndex = 7;
            this.grpHesapTuru.TabStop = false;
            this.grpHesapTuru.Text = "Hesap Türü";
            // 
            // cmbCariler
            // 
            this.cmbCariler.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCariler.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCariler.BackColor = System.Drawing.Color.White;
            this.cmbCariler.Enabled = false;
            this.cmbCariler.ForeColor = System.Drawing.Color.Black;
            this.cmbCariler.FormattingEnabled = true;
            this.cmbCariler.Location = new System.Drawing.Point(99, 39);
            this.cmbCariler.Name = "cmbCariler";
            this.cmbCariler.Size = new System.Drawing.Size(263, 21);
            this.cmbCariler.TabIndex = 9;
            this.cmbCariler.Tag = "001";
            this.cmbCariler.SelectedIndexChanged += new System.EventHandler(this.cmbCariler_SelectedIndexChanged);
            // 
            // rdCariHesabi
            // 
            this.rdCariHesabi.AutoSize = true;
            this.rdCariHesabi.Location = new System.Drawing.Point(7, 40);
            this.rdCariHesabi.Name = "rdCariHesabi";
            this.rdCariHesabi.Size = new System.Drawing.Size(79, 17);
            this.rdCariHesabi.TabIndex = 8;
            this.rdCariHesabi.Text = "Cari Hesabı";
            this.rdCariHesabi.UseVisualStyleBackColor = true;
            this.rdCariHesabi.Click += new System.EventHandler(this.rdCariHesabi_Click);
            // 
            // rdKendiHesabim
            // 
            this.rdKendiHesabim.AutoSize = true;
            this.rdKendiHesabim.Checked = true;
            this.rdKendiHesabim.Location = new System.Drawing.Point(7, 20);
            this.rdKendiHesabim.Name = "rdKendiHesabim";
            this.rdKendiHesabim.Size = new System.Drawing.Size(96, 17);
            this.rdKendiHesabim.TabIndex = 7;
            this.rdKendiHesabim.TabStop = true;
            this.rdKendiHesabim.Text = "Kendi Hesabım";
            this.rdKendiHesabim.UseVisualStyleBackColor = true;
            this.rdKendiHesabim.Click += new System.EventHandler(this.rdKendiHesabim_Click);
            // 
            // cmbBankalar
            // 
            this.cmbBankalar.FormattingEnabled = true;
            this.cmbBankalar.Items.AddRange(new object[] {
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
            this.cmbBankalar.Location = new System.Drawing.Point(61, 12);
            this.cmbBankalar.Name = "cmbBankalar";
            this.cmbBankalar.Size = new System.Drawing.Size(304, 21);
            this.cmbBankalar.TabIndex = 1;
            this.cmbBankalar.Tag = "001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(302, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 90;
            this.label4.Text = "Ör: Pos hesabı";
            // 
            // txtSubeNo
            // 
            this.txtSubeNo.BackColor = System.Drawing.Color.White;
            this.txtSubeNo.ForeColor = System.Drawing.Color.Black;
            this.txtSubeNo.Location = new System.Drawing.Point(61, 90);
            this.txtSubeNo.Name = "txtSubeNo";
            this.txtSubeNo.Size = new System.Drawing.Size(303, 20);
            this.txtSubeNo.TabIndex = 5;
            this.txtSubeNo.Tag = "001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-1, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 92;
            this.label5.Text = "Şube No";
            // 
            // frmBankaHesapEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(376, 312);
            this.Controls.Add(this.txtSubeNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbBankalar);
            this.Controls.Add(this.grpHesapTuru);
            this.Controls.Add(this.txtAyrinti);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIban);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHesapNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtHesapAdi);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Name = "frmBankaHesapEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Yeni Banka Hesabı Tanımla";
            this.Load += new System.EventHandler(this.frmBankaHesapEkle_Load);
            this.grpHesapTuru.ResumeLayout(false);
            this.grpHesapTuru.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAyrinti;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIban;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHesapNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.TextBox txtHesapAdi;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox grpHesapTuru;
        private System.Windows.Forms.ComboBox cmbCariler;
        private System.Windows.Forms.RadioButton rdCariHesabi;
        private System.Windows.Forms.RadioButton rdKendiHesabim;
        private System.Windows.Forms.ComboBox cmbBankalar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubeNo;
        private System.Windows.Forms.Label label5;
    }
}