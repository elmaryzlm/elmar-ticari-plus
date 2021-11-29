namespace Elmar_Ticari_Plus
{
    partial class frmPersonelYabanciDilEkle
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
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtPersonelAdi = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDilAdi = new System.Windows.Forms.ComboBox();
            this.cmbOkuma = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbYazma = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbKonusma = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbOgrenildigiYer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydet.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(185, 290);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(70, 32);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Tag = "0";
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtPersonelAdi
            // 
            this.txtPersonelAdi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPersonelAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPersonelAdi.ForeColor = System.Drawing.Color.Black;
            this.txtPersonelAdi.Location = new System.Drawing.Point(8, 34);
            this.txtPersonelAdi.MaxLength = 35;
            this.txtPersonelAdi.Name = "txtPersonelAdi";
            this.txtPersonelAdi.ReadOnly = true;
            this.txtPersonelAdi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPersonelAdi.Size = new System.Drawing.Size(244, 21);
            this.txtPersonelAdi.TabIndex = 40;
            this.txtPersonelAdi.TabStop = false;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.Color.DarkRed;
            this.label70.Location = new System.Drawing.Point(8, 16);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(145, 15);
            this.label70.TabIndex = 89;
            this.label70.Text = "İşlem Yapılacak Personel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(8, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 90;
            this.label1.Text = "Dil Adı";
            // 
            // cmbDilAdi
            // 
            this.cmbDilAdi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDilAdi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDilAdi.BackColor = System.Drawing.Color.White;
            this.cmbDilAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbDilAdi.ForeColor = System.Drawing.Color.Black;
            this.cmbDilAdi.FormattingEnabled = true;
            this.cmbDilAdi.Items.AddRange(new object[] {
            "Abhazca",
            "Acarca",
            "Afrikaans",
            "Akatça",
            "Almanca",
            "Aragonca",
            "Arbereşçe",
            "Aramice",
            "Aranese",
            "Arapça",
            "Arnavutça",
            "Auvergnat dili",
            "Aynu dili",
            "Azerbaycan Türkçesi",
            "Baskça",
            "Bantu",
            "Bengali",
            "Bretonca",
            "Beyaz Rusça",
            "Boşnakça",
            "Bulgarca",
            "Burgonyaca",
            "Champenois",
            "Çağatayca",
            "Çekçe",
            "Çince",
            "Çingene Dili",
            "Danca",
            "Dalmaçyaca",
            "Endonezyaca",
            "Ermenice",
            "Eski İngilizce",
            "Estonca",
            "Eyak",
            "Farsça",
            "Filipince",
            "Fince",
            "Flemenkçe",
            "Fransızca",
            "Galce",
            "Galiçyaca",
            "Gotça",
            "Hintçe",
            "Hırvatça",
            "Hollandaca",
            "İbranice",
            "İngilizce",
            "İran Dilleri",
            "İrlandaca",
            "İskoç dili",
            "İspanyolca",
            "İsveççe",
            "İtalyanca",
            "İzlandaca",
            "Japonca",
            "Kabardeyce",
            "Kalaallisut",
            "Kapa",
            "Karluk",
            "Kartça",
            "Katalanca",
            "Kazak Türkçesi",
            "Kazan Tatar Türkçesi",
            "Khmer",
            "Kırgız Türkçesi",
            "Kırım Tatar Türkçesi",
            "Korece",
            "Korsikaca",
            "Kurmanci",
            "Kürtçe",
            "Ladino",
            "Lakça",
            "Latince",
            "Lehçe (dil)",
            "Letonyaca",
            "Litvanyaca",
            "Macarca",
            "Malay dili",
            "Maltaca",
            "Adam dili",
            "Moğolca",
            "Moldovca",
            "Norveççe",
            "Osetçe",
            "Osmanlı Türkçesi",
            "Özbek Türkçesi",
            "Papiamento",
            "Peştuca",
            "Portekizce",
            "Romanş",
            "Romeika",
            "Rumence",
            "Rusça",
            "Saho",
            "Sanskritçe",
            "Sırpça",
            "Sicilyaca",
            "Slovakça",
            "Slovence",
            "Soğdca",
            "Sorb dili",
            "Strence",
            "Süryanice",
            "Tacikçe",
            "Takalotça",
            "Tai",
            "Tayvanca",
            "Tupi",
            "Turan Dili",
            "Tuvaca",
            "Türkçe",
            "Türkiye Türkçesi",
            "Türkmen Türkçesi",
            "Ukrayna dili",
            "Urduca",
            "Uygur Türkçesi",
            "Valensiyaca",
            "Yakutça",
            "Yidiş",
            "Yunanca",
            "Zazaca",
            "Zentce"});
            this.cmbDilAdi.Location = new System.Drawing.Point(8, 85);
            this.cmbDilAdi.MaxLength = 10;
            this.cmbDilAdi.Name = "cmbDilAdi";
            this.cmbDilAdi.Size = new System.Drawing.Size(247, 23);
            this.cmbDilAdi.TabIndex = 1;
            this.cmbDilAdi.Tag = "001";
            // 
            // cmbOkuma
            // 
            this.cmbOkuma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbOkuma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbOkuma.BackColor = System.Drawing.Color.White;
            this.cmbOkuma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbOkuma.ForeColor = System.Drawing.Color.Black;
            this.cmbOkuma.FormattingEnabled = true;
            this.cmbOkuma.Items.AddRange(new object[] {
            "Başlangıç",
            "Temel",
            "Orta",
            "İyi",
            "İleri"});
            this.cmbOkuma.Location = new System.Drawing.Point(8, 129);
            this.cmbOkuma.MaxLength = 10;
            this.cmbOkuma.Name = "cmbOkuma";
            this.cmbOkuma.Size = new System.Drawing.Size(247, 23);
            this.cmbOkuma.TabIndex = 2;
            this.cmbOkuma.Tag = "001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(8, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 92;
            this.label2.Text = "Okuma";
            // 
            // cmbYazma
            // 
            this.cmbYazma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbYazma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbYazma.BackColor = System.Drawing.Color.White;
            this.cmbYazma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbYazma.ForeColor = System.Drawing.Color.Black;
            this.cmbYazma.FormattingEnabled = true;
            this.cmbYazma.Items.AddRange(new object[] {
            "Başlangıç",
            "Temel",
            "Orta",
            "İyi",
            "İleri"});
            this.cmbYazma.Location = new System.Drawing.Point(8, 173);
            this.cmbYazma.MaxLength = 10;
            this.cmbYazma.Name = "cmbYazma";
            this.cmbYazma.Size = new System.Drawing.Size(247, 23);
            this.cmbYazma.TabIndex = 3;
            this.cmbYazma.Tag = "001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(8, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 94;
            this.label3.Text = "Yazma";
            // 
            // cmbKonusma
            // 
            this.cmbKonusma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbKonusma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbKonusma.BackColor = System.Drawing.Color.White;
            this.cmbKonusma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbKonusma.ForeColor = System.Drawing.Color.Black;
            this.cmbKonusma.FormattingEnabled = true;
            this.cmbKonusma.Items.AddRange(new object[] {
            "Başlangıç",
            "Temel",
            "Orta",
            "İyi",
            "İleri"});
            this.cmbKonusma.Location = new System.Drawing.Point(8, 217);
            this.cmbKonusma.MaxLength = 10;
            this.cmbKonusma.Name = "cmbKonusma";
            this.cmbKonusma.Size = new System.Drawing.Size(247, 23);
            this.cmbKonusma.TabIndex = 4;
            this.cmbKonusma.Tag = "001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(8, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 96;
            this.label4.Text = "Konuşma";
            // 
            // cmbOgrenildigiYer
            // 
            this.cmbOgrenildigiYer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbOgrenildigiYer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbOgrenildigiYer.BackColor = System.Drawing.Color.White;
            this.cmbOgrenildigiYer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbOgrenildigiYer.ForeColor = System.Drawing.Color.Black;
            this.cmbOgrenildigiYer.FormattingEnabled = true;
            this.cmbOgrenildigiYer.Items.AddRange(new object[] {
            "Okul",
            "Kurs",
            "Kişisel",
            "Yurt Dışı",
            "Diğer"});
            this.cmbOgrenildigiYer.Location = new System.Drawing.Point(8, 261);
            this.cmbOgrenildigiYer.MaxLength = 10;
            this.cmbOgrenildigiYer.Name = "cmbOgrenildigiYer";
            this.cmbOgrenildigiYer.Size = new System.Drawing.Size(247, 23);
            this.cmbOgrenildigiYer.TabIndex = 5;
            this.cmbOgrenildigiYer.Tag = "001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(8, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 15);
            this.label5.TabIndex = 98;
            this.label5.Text = "Öğrenildiği Yer";
            // 
            // frmPersonelYabanciDilEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(268, 329);
            this.Controls.Add(this.cmbOgrenildigiYer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbKonusma);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbYazma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbOkuma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDilAdi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label70);
            this.Controls.Add(this.txtPersonelAdi);
            this.Controls.Add(this.btnKaydet);
            this.Name = "frmPersonelYabanciDilEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Yabancı Dil Ekle";
            this.Load += new System.EventHandler(this.frmPersonelYabanciDilEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKaydet;
        public System.Windows.Forms.TextBox txtPersonelAdi;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDilAdi;
        private System.Windows.Forms.ComboBox cmbOkuma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbYazma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbKonusma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbOgrenildigiYer;
        private System.Windows.Forms.Label label5;

    }
}