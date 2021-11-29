namespace Elmar_Ticari_Plus
{
    partial class frmPersonelGorevEkle
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
            this.cmbPersonelAdlari = new System.Windows.Forms.ComboBox();
            this.label73 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGorevAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGorevTanimi = new System.Windows.Forms.TextBox();
            this.dtBaslangicTarihi = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBaslangicSaati = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.dtSonlanmaTarihi = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSonlanmaSaati = new System.Windows.Forms.MaskedTextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbPersonelAdlari
            // 
            this.cmbPersonelAdlari.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPersonelAdlari.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPersonelAdlari.BackColor = System.Drawing.Color.White;
            this.cmbPersonelAdlari.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbPersonelAdlari.ForeColor = System.Drawing.Color.Black;
            this.cmbPersonelAdlari.FormattingEnabled = true;
            this.cmbPersonelAdlari.Location = new System.Drawing.Point(88, 12);
            this.cmbPersonelAdlari.Name = "cmbPersonelAdlari";
            this.cmbPersonelAdlari.Size = new System.Drawing.Size(353, 22);
            this.cmbPersonelAdlari.TabIndex = 1;
            this.cmbPersonelAdlari.Tag = "001";
            this.cmbPersonelAdlari.SelectedIndexChanged += new System.EventHandler(this.cmbPersonelAdlari_SelectedIndexChanged);
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(0, 15);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(84, 13);
            this.label73.TabIndex = 37;
            this.label73.Text = "Görevli Personel";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(0, 198);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(50, 13);
            this.label77.TabIndex = 35;
            this.label77.Text = "Açıklama";
            // 
            // txtAciklama
            // 
            this.txtAciklama.BackColor = System.Drawing.Color.White;
            this.txtAciklama.ForeColor = System.Drawing.Color.Black;
            this.txtAciklama.Location = new System.Drawing.Point(88, 195);
            this.txtAciklama.MaxLength = 200;
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAciklama.Size = new System.Drawing.Size(353, 73);
            this.txtAciklama.TabIndex = 8;
            this.txtAciklama.Tag = "001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Görev Adı";
            // 
            // txtGorevAdi
            // 
            this.txtGorevAdi.BackColor = System.Drawing.Color.White;
            this.txtGorevAdi.ForeColor = System.Drawing.Color.Black;
            this.txtGorevAdi.Location = new System.Drawing.Point(88, 40);
            this.txtGorevAdi.MaxLength = 50;
            this.txtGorevAdi.Name = "txtGorevAdi";
            this.txtGorevAdi.Size = new System.Drawing.Size(353, 20);
            this.txtGorevAdi.TabIndex = 2;
            this.txtGorevAdi.Tag = "001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Görev Tanımı";
            // 
            // txtGorevTanimi
            // 
            this.txtGorevTanimi.BackColor = System.Drawing.Color.White;
            this.txtGorevTanimi.ForeColor = System.Drawing.Color.Black;
            this.txtGorevTanimi.Location = new System.Drawing.Point(88, 66);
            this.txtGorevTanimi.MaxLength = 200;
            this.txtGorevTanimi.Multiline = true;
            this.txtGorevTanimi.Name = "txtGorevTanimi";
            this.txtGorevTanimi.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGorevTanimi.Size = new System.Drawing.Size(353, 73);
            this.txtGorevTanimi.TabIndex = 3;
            this.txtGorevTanimi.Tag = "001";
            // 
            // dtBaslangicTarihi
            // 
            this.dtBaslangicTarihi.Location = new System.Drawing.Point(88, 145);
            this.dtBaslangicTarihi.Name = "dtBaslangicTarihi";
            this.dtBaslangicTarihi.Size = new System.Drawing.Size(177, 20);
            this.dtBaslangicTarihi.TabIndex = 4;
            this.dtBaslangicTarihi.Tag = "001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Başlama Tarihi";
            // 
            // txtBaslangicSaati
            // 
            this.txtBaslangicSaati.BackColor = System.Drawing.Color.White;
            this.txtBaslangicSaati.ForeColor = System.Drawing.Color.Black;
            this.txtBaslangicSaati.Location = new System.Drawing.Point(406, 144);
            this.txtBaslangicSaati.Mask = "90:00";
            this.txtBaslangicSaati.Name = "txtBaslangicSaati";
            this.txtBaslangicSaati.Size = new System.Drawing.Size(35, 20);
            this.txtBaslangicSaati.TabIndex = 6;
            this.txtBaslangicSaati.Tag = "001";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(301, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 15);
            this.label9.TabIndex = 135;
            this.label9.Text = "Başlama Saati";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(0, 174);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(83, 13);
            this.label78.TabIndex = 36;
            this.label78.Text = "Sonlanma Tarihi";
            // 
            // dtSonlanmaTarihi
            // 
            this.dtSonlanmaTarihi.Location = new System.Drawing.Point(88, 171);
            this.dtSonlanmaTarihi.Name = "dtSonlanmaTarihi";
            this.dtSonlanmaTarihi.Size = new System.Drawing.Size(177, 20);
            this.dtSonlanmaTarihi.TabIndex = 5;
            this.dtSonlanmaTarihi.Tag = "001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(301, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 137;
            this.label4.Text = "Sonlanma Saati";
            // 
            // txtSonlanmaSaati
            // 
            this.txtSonlanmaSaati.BackColor = System.Drawing.Color.White;
            this.txtSonlanmaSaati.ForeColor = System.Drawing.Color.Black;
            this.txtSonlanmaSaati.Location = new System.Drawing.Point(406, 170);
            this.txtSonlanmaSaati.Mask = "90:00";
            this.txtSonlanmaSaati.Name = "txtSonlanmaSaati";
            this.txtSonlanmaSaati.Size = new System.Drawing.Size(35, 20);
            this.txtSonlanmaSaati.TabIndex = 7;
            this.txtSonlanmaSaati.Tag = "001";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(187, 274);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(77, 29);
            this.btnKaydet.TabIndex = 9;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // frmPersonelGorevEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(445, 305);
            this.Controls.Add(this.txtSonlanmaSaati);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBaslangicSaati);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtBaslangicTarihi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGorevTanimi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGorevAdi);
            this.Controls.Add(this.cmbPersonelAdlari);
            this.Controls.Add(this.label73);
            this.Controls.Add(this.label77);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.dtSonlanmaTarihi);
            this.Controls.Add(this.label78);
            this.Name = "frmPersonelGorevEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Personele Görev Tanımla";
            this.Load += new System.EventHandler(this.frmPersonelGorevEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPersonelAdlari;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGorevAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGorevTanimi;
        private System.Windows.Forms.DateTimePicker dtBaslangicTarihi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtBaslangicSaati;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.DateTimePicker dtSonlanmaTarihi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtSonlanmaSaati;
        private System.Windows.Forms.Button btnKaydet;
    }
}