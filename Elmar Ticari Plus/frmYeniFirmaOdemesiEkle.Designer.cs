namespace Elmar_Ticari_Plus
{
    partial class frmYeniFirmaOdemesiEkle
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
            this.cmbislemTipi = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtİslemTarihi = new System.Windows.Forms.DateTimePicker();
            this.cmbKullanicilar = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSubeler = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtAcklama = new System.Windows.Forms.TextBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtVadeTarihi = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // cmbislemTipi
            // 
            this.cmbislemTipi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbislemTipi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbislemTipi.BackColor = System.Drawing.Color.White;
            this.cmbislemTipi.ForeColor = System.Drawing.Color.Black;
            this.cmbislemTipi.FormattingEnabled = true;
            this.cmbislemTipi.Items.AddRange(new object[] {
            "Alacak",
            "Borç",
            "Ödeme",
            "Tahsilat"});
            this.cmbislemTipi.Location = new System.Drawing.Point(120, 36);
            this.cmbislemTipi.Name = "cmbislemTipi";
            this.cmbislemTipi.Size = new System.Drawing.Size(115, 21);
            this.cmbislemTipi.TabIndex = 28;
            this.cmbislemTipi.Tag = "001";
            this.cmbislemTipi.Text = "Alacak";
            this.cmbislemTipi.SelectedIndexChanged += new System.EventHandler(this.cmbislemTipi_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(16, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "İşlem Tipi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(16, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 21;
            this.label8.Text = "İşlem Tarihi";
            // 
            // dtİslemTarihi
            // 
            this.dtİslemTarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtİslemTarihi.Location = new System.Drawing.Point(120, 58);
            this.dtİslemTarihi.Name = "dtİslemTarihi";
            this.dtİslemTarihi.Size = new System.Drawing.Size(269, 21);
            this.dtİslemTarihi.TabIndex = 29;
            // 
            // cmbKullanicilar
            // 
            this.cmbKullanicilar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbKullanicilar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbKullanicilar.BackColor = System.Drawing.Color.White;
            this.cmbKullanicilar.ForeColor = System.Drawing.Color.Black;
            this.cmbKullanicilar.FormattingEnabled = true;
            this.cmbKullanicilar.Location = new System.Drawing.Point(235, 195);
            this.cmbKullanicilar.Name = "cmbKullanicilar";
            this.cmbKullanicilar.Size = new System.Drawing.Size(155, 21);
            this.cmbKullanicilar.TabIndex = 32;
            this.cmbKullanicilar.Tag = "001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(16, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Şube - Kullanıcı";
            // 
            // cmbSubeler
            // 
            this.cmbSubeler.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSubeler.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSubeler.BackColor = System.Drawing.Color.White;
            this.cmbSubeler.ForeColor = System.Drawing.Color.Black;
            this.cmbSubeler.FormattingEnabled = true;
            this.cmbSubeler.Location = new System.Drawing.Point(120, 195);
            this.cmbSubeler.Name = "cmbSubeler";
            this.cmbSubeler.Size = new System.Drawing.Size(115, 21);
            this.cmbSubeler.TabIndex = 31;
            this.cmbSubeler.Tag = "001";
            this.cmbSubeler.SelectedIndexChanged += new System.EventHandler(this.cmbSubeler_SelectedIndexChanged);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label45.ForeColor = System.Drawing.Color.DarkRed;
            this.label45.Location = new System.Drawing.Point(16, 15);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(35, 15);
            this.label45.TabIndex = 14;
            this.label45.Text = "Tutar";
            // 
            // txtTutar
            // 
            this.txtTutar.BackColor = System.Drawing.Color.White;
            this.txtTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTutar.ForeColor = System.Drawing.Color.Black;
            this.txtTutar.Location = new System.Drawing.Point(120, 12);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(115, 22);
            this.txtTutar.TabIndex = 23;
            this.txtTutar.Tag = "221";
            this.txtTutar.Text = "0";
            this.txtTutar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label39.ForeColor = System.Drawing.Color.DarkRed;
            this.label39.Location = new System.Drawing.Point(16, 107);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(57, 15);
            this.label39.TabIndex = 15;
            this.label39.Text = "Açıklama";
            // 
            // txtAcklama
            // 
            this.txtAcklama.BackColor = System.Drawing.Color.White;
            this.txtAcklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAcklama.ForeColor = System.Drawing.Color.Black;
            this.txtAcklama.Location = new System.Drawing.Point(120, 104);
            this.txtAcklama.Multiline = true;
            this.txtAcklama.Name = "txtAcklama";
            this.txtAcklama.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAcklama.Size = new System.Drawing.Size(269, 89);
            this.txtAcklama.TabIndex = 30;
            this.txtAcklama.Tag = "001";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuncelle.Location = new System.Drawing.Point(157, 227);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(78, 34);
            this.btnGuncelle.TabIndex = 33;
            this.btnGuncelle.Text = "Kaydet";
            this.btnGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(16, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 34;
            this.label1.Text = "Vâde Tarihi";
            // 
            // dtVadeTarihi
            // 
            this.dtVadeTarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtVadeTarihi.Location = new System.Drawing.Point(120, 81);
            this.dtVadeTarihi.Name = "dtVadeTarihi";
            this.dtVadeTarihi.Size = new System.Drawing.Size(269, 21);
            this.dtVadeTarihi.TabIndex = 35;
            // 
            // frmYeniFirmaOdemesiEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 264);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtVadeTarihi);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.cmbislemTipi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtİslemTarihi);
            this.Controls.Add(this.cmbKullanicilar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSubeler);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.txtAcklama);
            this.Name = "frmYeniFirmaOdemesiEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yeni Firma Ödeme Kaydı Oluştur";
            this.Load += new System.EventHandler(this.frmYeniFirmaOdemesiEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbislemTipi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtİslemTarihi;
        private System.Windows.Forms.ComboBox cmbKullanicilar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSubeler;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txtTutar;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtAcklama;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtVadeTarihi;
    }
}