namespace Elmar_Ticari_Plus
{
    partial class frmPersonelMaasGirisi
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
            this.txtislemSaati = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtislemTarihi = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPersonelAdlari = new System.Windows.Forms.ComboBox();
            this.label73 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.cmbislemTuru = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.lblislemAciklamasi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtislemSaati
            // 
            this.txtislemSaati.BackColor = System.Drawing.Color.White;
            this.txtislemSaati.ForeColor = System.Drawing.Color.Black;
            this.txtislemSaati.Location = new System.Drawing.Point(341, 81);
            this.txtislemSaati.Mask = "90:00";
            this.txtislemSaati.Name = "txtislemSaati";
            this.txtislemSaati.Size = new System.Drawing.Size(35, 20);
            this.txtislemSaati.TabIndex = 5;
            this.txtislemSaati.Tag = "001";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(272, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 15);
            this.label9.TabIndex = 152;
            this.label9.Text = "İşlem Saati";
            // 
            // dtislemTarihi
            // 
            this.dtislemTarihi.Location = new System.Drawing.Point(85, 82);
            this.dtislemTarihi.Name = "dtislemTarihi";
            this.dtislemTarihi.Size = new System.Drawing.Size(177, 20);
            this.dtislemTarihi.TabIndex = 4;
            this.dtislemTarihi.Tag = "001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 151;
            this.label3.Text = "İşlem Tarihi";
            // 
            // cmbPersonelAdlari
            // 
            this.cmbPersonelAdlari.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPersonelAdlari.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPersonelAdlari.BackColor = System.Drawing.Color.White;
            this.cmbPersonelAdlari.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbPersonelAdlari.ForeColor = System.Drawing.Color.Black;
            this.cmbPersonelAdlari.FormattingEnabled = true;
            this.cmbPersonelAdlari.Location = new System.Drawing.Point(85, 5);
            this.cmbPersonelAdlari.Name = "cmbPersonelAdlari";
            this.cmbPersonelAdlari.Size = new System.Drawing.Size(291, 22);
            this.cmbPersonelAdlari.TabIndex = 1;
            this.cmbPersonelAdlari.Tag = "001";
            this.cmbPersonelAdlari.SelectedIndexChanged += new System.EventHandler(this.cmbPersonelAdlari_SelectedIndexChanged);
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(2, 8);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(82, 13);
            this.label73.TabIndex = 145;
            this.label73.Text = "Personel Seçimi";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(2, 106);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(50, 13);
            this.label77.TabIndex = 143;
            this.label77.Text = "Açıklama";
            // 
            // txtAciklama
            // 
            this.txtAciklama.BackColor = System.Drawing.Color.White;
            this.txtAciklama.ForeColor = System.Drawing.Color.Black;
            this.txtAciklama.Location = new System.Drawing.Point(85, 106);
            this.txtAciklama.MaxLength = 200;
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAciklama.Size = new System.Drawing.Size(291, 111);
            this.txtAciklama.TabIndex = 6;
            this.txtAciklama.Tag = "001";
            // 
            // cmbislemTuru
            // 
            this.cmbislemTuru.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbislemTuru.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbislemTuru.BackColor = System.Drawing.Color.White;
            this.cmbislemTuru.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbislemTuru.ForeColor = System.Drawing.Color.Black;
            this.cmbislemTuru.FormattingEnabled = true;
            this.cmbislemTuru.Items.AddRange(new object[] {
            "Maaş Girişi",
            "Prim Girişi",
            "Maaş Ödemesi",
            "Prim Ödemesi",
            "Avans",
            "Kesinti",
            "İkramiye",
            "Yemek Ödemesi",
            "Yol Ödemesi"});
            this.cmbislemTuru.Location = new System.Drawing.Point(85, 33);
            this.cmbislemTuru.Name = "cmbislemTuru";
            this.cmbislemTuru.Size = new System.Drawing.Size(140, 22);
            this.cmbislemTuru.TabIndex = 2;
            this.cmbislemTuru.Tag = "001";
            this.cmbislemTuru.SelectedIndexChanged += new System.EventHandler(this.cmbislemTuru_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 157;
            this.label5.Text = "İşlem Türü";
            // 
            // txtTutar
            // 
            this.txtTutar.BackColor = System.Drawing.Color.White;
            this.txtTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTutar.ForeColor = System.Drawing.Color.Black;
            this.txtTutar.Location = new System.Drawing.Point(85, 58);
            this.txtTutar.MaxLength = 50;
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(177, 21);
            this.txtTutar.TabIndex = 3;
            this.txtTutar.Tag = "221";
            this.txtTutar.Text = "0";
            this.txtTutar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 147;
            this.label1.Text = "Tutar";
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Image = global::Elmar_Ticari_Plus.Properties.Resources.page_remove_icon;
            this.btnTemizle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTemizle.Location = new System.Drawing.Point(225, 223);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(78, 29);
            this.btnTemizle.TabIndex = 8;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEkle.Location = new System.Drawing.Point(304, 223);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(72, 29);
            this.btnEkle.TabIndex = 7;
            this.btnEkle.Text = "Kaydet";
            this.btnEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // lblislemAciklamasi
            // 
            this.lblislemAciklamasi.AutoSize = true;
            this.lblislemAciklamasi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblislemAciklamasi.Location = new System.Drawing.Point(228, 39);
            this.lblislemAciklamasi.Name = "lblislemAciklamasi";
            this.lblislemAciklamasi.Size = new System.Drawing.Size(2, 15);
            this.lblislemAciklamasi.TabIndex = 162;
            // 
            // frmPersonelMaasGirisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(380, 258);
            this.Controls.Add(this.lblislemAciklamasi);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.cmbislemTuru);
            this.Controls.Add(this.txtislemSaati);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtislemTarihi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.cmbPersonelAdlari);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label73);
            this.Controls.Add(this.label77);
            this.Name = "frmPersonelMaasGirisi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Personel Maaş Girişi";
            this.Load += new System.EventHandler(this.frmPersonelMaasGirisi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtislemSaati;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtislemTarihi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPersonelAdlari;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.ComboBox cmbislemTuru;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTutar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Label lblislemAciklamasi;
    }
}