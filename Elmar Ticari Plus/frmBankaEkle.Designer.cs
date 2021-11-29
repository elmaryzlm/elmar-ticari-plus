namespace Elmar_Ticari_Plus
{
    partial class frmBankaEkle
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
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtFax = new System.Windows.Forms.MaskedTextBox();
            this.txtTel = new System.Windows.Forms.MaskedTextBox();
            this.txtSubeAdi = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtilce = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubeKodu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBankaAdi = new System.Windows.Forms.ComboBox();
            this.txtSehir = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtAdres
            // 
            this.txtAdres.BackColor = System.Drawing.Color.White;
            this.txtAdres.ForeColor = System.Drawing.Color.Black;
            this.txtAdres.Location = new System.Drawing.Point(64, 192);
            this.txtAdres.Multiline = true;
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAdres.Size = new System.Drawing.Size(262, 64);
            this.txtAdres.TabIndex = 8;
            this.txtAdres.Tag = "001";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Location = new System.Drawing.Point(251, 324);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 26);
            this.btnKaydet.TabIndex = 10;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtFax
            // 
            this.txtFax.BackColor = System.Drawing.Color.White;
            this.txtFax.ForeColor = System.Drawing.Color.Black;
            this.txtFax.Location = new System.Drawing.Point(64, 166);
            this.txtFax.Mask = "(999) 000-0000";
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(127, 20);
            this.txtFax.TabIndex = 7;
            this.txtFax.Tag = "001";
            // 
            // txtTel
            // 
            this.txtTel.BackColor = System.Drawing.Color.White;
            this.txtTel.ForeColor = System.Drawing.Color.Black;
            this.txtTel.Location = new System.Drawing.Point(64, 140);
            this.txtTel.Mask = "(999) 000-0000";
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(127, 20);
            this.txtTel.TabIndex = 6;
            this.txtTel.Tag = "001";
            // 
            // txtSubeAdi
            // 
            this.txtSubeAdi.BackColor = System.Drawing.Color.White;
            this.txtSubeAdi.ForeColor = System.Drawing.Color.Black;
            this.txtSubeAdi.Location = new System.Drawing.Point(64, 38);
            this.txtSubeAdi.Name = "txtSubeAdi";
            this.txtSubeAdi.Size = new System.Drawing.Size(262, 20);
            this.txtSubeAdi.TabIndex = 2;
            this.txtSubeAdi.Tag = "001";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 167);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(24, 13);
            this.label22.TabIndex = 55;
            this.label22.Text = "Fax";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 142);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(22, 13);
            this.label20.TabIndex = 53;
            this.label20.Text = "Tel";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 42);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 13);
            this.label19.TabIndex = 52;
            this.label19.Text = "Şube Adı";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 13);
            this.label18.TabIndex = 51;
            this.label18.Text = "Banka Adı";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 195);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(34, 13);
            this.label25.TabIndex = 63;
            this.label25.Text = "Adres";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "Şehir";
            // 
            // txtilce
            // 
            this.txtilce.BackColor = System.Drawing.Color.White;
            this.txtilce.ForeColor = System.Drawing.Color.Black;
            this.txtilce.Location = new System.Drawing.Point(64, 114);
            this.txtilce.Name = "txtilce";
            this.txtilce.Size = new System.Drawing.Size(128, 20);
            this.txtilce.TabIndex = 5;
            this.txtilce.Tag = "001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "İlçe";
            // 
            // txtAciklama
            // 
            this.txtAciklama.BackColor = System.Drawing.Color.White;
            this.txtAciklama.ForeColor = System.Drawing.Color.Black;
            this.txtAciklama.Location = new System.Drawing.Point(64, 262);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAciklama.Size = new System.Drawing.Size(262, 56);
            this.txtAciklama.TabIndex = 9;
            this.txtAciklama.Tag = "001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Açıklama";
            // 
            // txtSubeKodu
            // 
            this.txtSubeKodu.BackColor = System.Drawing.Color.White;
            this.txtSubeKodu.ForeColor = System.Drawing.Color.Black;
            this.txtSubeKodu.Location = new System.Drawing.Point(64, 62);
            this.txtSubeKodu.Name = "txtSubeKodu";
            this.txtSubeKodu.Size = new System.Drawing.Size(262, 20);
            this.txtSubeKodu.TabIndex = 3;
            this.txtSubeKodu.Tag = "001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Şube Kodu";
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
            this.txtBankaAdi.Location = new System.Drawing.Point(64, 13);
            this.txtBankaAdi.Name = "txtBankaAdi";
            this.txtBankaAdi.Size = new System.Drawing.Size(262, 21);
            this.txtBankaAdi.TabIndex = 1;
            this.txtBankaAdi.Tag = "001";
            // 
            // txtSehir
            // 
            this.txtSehir.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSehir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtSehir.BackColor = System.Drawing.Color.White;
            this.txtSehir.ForeColor = System.Drawing.Color.Black;
            this.txtSehir.FormattingEnabled = true;
            this.txtSehir.Items.AddRange(new object[] {
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
            this.txtSehir.Location = new System.Drawing.Point(64, 87);
            this.txtSehir.Name = "txtSehir";
            this.txtSehir.Size = new System.Drawing.Size(127, 21);
            this.txtSehir.TabIndex = 4;
            this.txtSehir.Tag = "001";
            // 
            // frmBankaEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(335, 355);
            this.Controls.Add(this.txtSehir);
            this.Controls.Add(this.txtBankaAdi);
            this.Controls.Add(this.txtSubeKodu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtilce);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtSubeAdi);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label25);
            this.Name = "frmBankaEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Yeni Banka Tanımla";
            this.Load += new System.EventHandler(this.frmBankaEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.MaskedTextBox txtFax;
        private System.Windows.Forms.MaskedTextBox txtTel;
        private System.Windows.Forms.TextBox txtSubeAdi;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtilce;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubeKodu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtBankaAdi;
        private System.Windows.Forms.ComboBox txtSehir;
    }
}