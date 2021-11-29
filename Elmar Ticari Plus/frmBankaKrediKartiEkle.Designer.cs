namespace Elmar_Ticari_Plus
{
    partial class frmBankaKrediKartiEkle
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtKartLimiti = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSonOdemeGunu = new System.Windows.Forms.NumericUpDown();
            this.txtHesapKesim = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.cmbBankaHesabi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnBankaHesabiEkle = new System.Windows.Forms.Button();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSonOdemeGunu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapKesim)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAyrinti
            // 
            this.txtAyrinti.BackColor = System.Drawing.Color.White;
            this.txtAyrinti.ForeColor = System.Drawing.Color.Black;
            this.txtAyrinti.Location = new System.Drawing.Point(17, 163);
            this.txtAyrinti.Multiline = true;
            this.txtAyrinti.Name = "txtAyrinti";
            this.txtAyrinti.Size = new System.Drawing.Size(334, 109);
            this.txtAyrinti.TabIndex = 6;
            this.txtAyrinti.Tag = "001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ayrıntı";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtKartLimiti);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.txtSonOdemeGunu);
            this.groupBox9.Controls.Add(this.txtHesapKesim);
            this.groupBox9.Controls.Add(this.label4);
            this.groupBox9.Controls.Add(this.label58);
            this.groupBox9.Location = new System.Drawing.Point(12, 54);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(208, 83);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            // 
            // txtKartLimiti
            // 
            this.txtKartLimiti.BackColor = System.Drawing.Color.White;
            this.txtKartLimiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKartLimiti.ForeColor = System.Drawing.Color.Black;
            this.txtKartLimiti.Location = new System.Drawing.Point(113, 58);
            this.txtKartLimiti.Name = "txtKartLimiti";
            this.txtKartLimiti.Size = new System.Drawing.Size(89, 22);
            this.txtKartLimiti.TabIndex = 5;
            this.txtKartLimiti.Tag = "221";
            this.txtKartLimiti.Text = "0";
            this.txtKartLimiti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Kart Limiti";
            // 
            // txtSonOdemeGunu
            // 
            this.txtSonOdemeGunu.BackColor = System.Drawing.Color.White;
            this.txtSonOdemeGunu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSonOdemeGunu.ForeColor = System.Drawing.Color.Black;
            this.txtSonOdemeGunu.Location = new System.Drawing.Point(113, 34);
            this.txtSonOdemeGunu.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.txtSonOdemeGunu.Name = "txtSonOdemeGunu";
            this.txtSonOdemeGunu.Size = new System.Drawing.Size(89, 22);
            this.txtSonOdemeGunu.TabIndex = 4;
            this.txtSonOdemeGunu.Tag = "001";
            // 
            // txtHesapKesim
            // 
            this.txtHesapKesim.BackColor = System.Drawing.Color.White;
            this.txtHesapKesim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtHesapKesim.ForeColor = System.Drawing.Color.Black;
            this.txtHesapKesim.Location = new System.Drawing.Point(113, 10);
            this.txtHesapKesim.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.txtHesapKesim.Name = "txtHesapKesim";
            this.txtHesapKesim.Size = new System.Drawing.Size(89, 22);
            this.txtHesapKesim.TabIndex = 3;
            this.txtHesapKesim.Tag = "001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Son Ödeme Günü";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(7, 13);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(98, 13);
            this.label58.TabIndex = 1;
            this.label58.Text = "Hesap Kesim Günü";
            // 
            // cmbBankaHesabi
            // 
            this.cmbBankaHesabi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBankaHesabi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBankaHesabi.BackColor = System.Drawing.Color.White;
            this.cmbBankaHesabi.ForeColor = System.Drawing.Color.Black;
            this.cmbBankaHesabi.FormattingEnabled = true;
            this.cmbBankaHesabi.Location = new System.Drawing.Point(17, 27);
            this.cmbBankaHesabi.Name = "cmbBankaHesabi";
            this.cmbBankaHesabi.Size = new System.Drawing.Size(310, 21);
            this.cmbBankaHesabi.TabIndex = 1;
            this.cmbBankaHesabi.Tag = "001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Banka Hesabı";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(148, 275);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 29);
            this.btnKaydet.TabIndex = 7;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnBankaHesabiEkle
            // 
            this.btnBankaHesabiEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnBankaHesabiEkle.Image = global::Elmar_Ticari_Plus.Properties.Resources.genelEkle;
            this.btnBankaHesabiEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBankaHesabiEkle.Location = new System.Drawing.Point(327, 26);
            this.btnBankaHesabiEkle.Name = "btnBankaHesabiEkle";
            this.btnBankaHesabiEkle.Size = new System.Drawing.Size(24, 22);
            this.btnBankaHesabiEkle.TabIndex = 54;
            this.btnBankaHesabiEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBankaHesabiEkle.UseVisualStyleBackColor = false;
            this.btnBankaHesabiEkle.Click += new System.EventHandler(this.btnBankaHesabiEkle_Click);
            // 
            // frmBankaKrediKartiEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(355, 306);
            this.Controls.Add(this.btnBankaHesabiEkle);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtAyrinti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBankaHesabi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox9);
            this.Name = "frmBankaKrediKartiEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Yeni Kredi Kartı Tanımla";
            this.Load += new System.EventHandler(this.frmBankaKrediKartiEkle_Load);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSonOdemeGunu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapKesim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAyrinti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox txtKartLimiti;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown txtSonOdemeGunu;
        private System.Windows.Forms.NumericUpDown txtHesapKesim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnBankaHesabiEkle;
        public System.Windows.Forms.ComboBox cmbBankaHesabi;
    }
}