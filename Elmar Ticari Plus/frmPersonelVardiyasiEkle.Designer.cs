namespace Elmar_Ticari_Plus
{
    partial class frmPersonelVardiyasiEkle
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
            this.label4 = new System.Windows.Forms.Label();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPersonel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbVardiya = new System.Windows.Forms.ComboBox();
            this.dtBaslangicTarihi = new System.Windows.Forms.DateTimePicker();
            this.dtBitisTarihi = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTatilGunleri = new System.Windows.Forms.TextBox();
            this.btnVardiyaEkle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-17, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(451, 13);
            this.label4.TabIndex = 94;
            this.label4.Text = "__________________________________________________________________________";
            // 
            // lblBaslik
            // 
            this.lblBaslik.BackColor = System.Drawing.Color.White;
            this.lblBaslik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.Image = global::Elmar_Ticari_Plus.Properties.Resources.Time_Timer_icon;
            this.lblBaslik.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(334, 57);
            this.lblBaslik.TabIndex = 93;
            this.lblBaslik.Text = "Yeni Personel Vardiyası Tanımla      ";
            this.lblBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(130, 220);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(78, 30);
            this.btnKaydet.TabIndex = 7;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(7, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 89;
            this.label3.Text = "Bitiş Tarihi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(7, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 88;
            this.label2.Text = "Başlangıç Tarihi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(7, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 86;
            this.label1.Text = "Vardiya Adı";
            // 
            // cmbPersonel
            // 
            this.cmbPersonel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPersonel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPersonel.BackColor = System.Drawing.Color.White;
            this.cmbPersonel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbPersonel.ForeColor = System.Drawing.Color.Black;
            this.cmbPersonel.FormattingEnabled = true;
            this.cmbPersonel.Location = new System.Drawing.Point(111, 71);
            this.cmbPersonel.Name = "cmbPersonel";
            this.cmbPersonel.Size = new System.Drawing.Size(214, 23);
            this.cmbPersonel.TabIndex = 1;
            this.cmbPersonel.Tag = "001";
            this.cmbPersonel.SelectedIndexChanged += new System.EventHandler(this.cmbPersonel_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(7, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 98;
            this.label6.Text = "Personel Adı";
            // 
            // cmbVardiya
            // 
            this.cmbVardiya.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVardiya.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVardiya.BackColor = System.Drawing.Color.White;
            this.cmbVardiya.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbVardiya.ForeColor = System.Drawing.Color.Black;
            this.cmbVardiya.FormattingEnabled = true;
            this.cmbVardiya.Location = new System.Drawing.Point(111, 99);
            this.cmbVardiya.Name = "cmbVardiya";
            this.cmbVardiya.Size = new System.Drawing.Size(191, 23);
            this.cmbVardiya.TabIndex = 2;
            this.cmbVardiya.Tag = "001";
            this.cmbVardiya.SelectedIndexChanged += new System.EventHandler(this.cmbVardiya_SelectedIndexChanged);
            // 
            // dtBaslangicTarihi
            // 
            this.dtBaslangicTarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtBaslangicTarihi.Location = new System.Drawing.Point(111, 127);
            this.dtBaslangicTarihi.Name = "dtBaslangicTarihi";
            this.dtBaslangicTarihi.Size = new System.Drawing.Size(214, 21);
            this.dtBaslangicTarihi.TabIndex = 4;
            this.dtBaslangicTarihi.Tag = "001";
            // 
            // dtBitisTarihi
            // 
            this.dtBitisTarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtBitisTarihi.Location = new System.Drawing.Point(111, 153);
            this.dtBitisTarihi.Name = "dtBitisTarihi";
            this.dtBitisTarihi.Size = new System.Drawing.Size(214, 21);
            this.dtBitisTarihi.TabIndex = 5;
            this.dtBitisTarihi.Tag = "001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(7, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 102;
            this.label5.Text = "Tatil Günleri";
            // 
            // txtTatilGunleri
            // 
            this.txtTatilGunleri.BackColor = System.Drawing.Color.White;
            this.txtTatilGunleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTatilGunleri.ForeColor = System.Drawing.Color.Black;
            this.txtTatilGunleri.Location = new System.Drawing.Point(111, 179);
            this.txtTatilGunleri.Name = "txtTatilGunleri";
            this.txtTatilGunleri.Size = new System.Drawing.Size(214, 22);
            this.txtTatilGunleri.TabIndex = 6;
            this.txtTatilGunleri.Tag = "001";
            // 
            // btnVardiyaEkle
            // 
            this.btnVardiyaEkle.Image = global::Elmar_Ticari_Plus.Properties.Resources.genelEkle;
            this.btnVardiyaEkle.Location = new System.Drawing.Point(302, 99);
            this.btnVardiyaEkle.Name = "btnVardiyaEkle";
            this.btnVardiyaEkle.Size = new System.Drawing.Size(23, 23);
            this.btnVardiyaEkle.TabIndex = 3;
            this.btnVardiyaEkle.UseVisualStyleBackColor = false;
            this.btnVardiyaEkle.Click += new System.EventHandler(this.btnVardiyaEkle_Click);
            // 
            // frmPersonelVardiyasiEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 253);
            this.Controls.Add(this.btnVardiyaEkle);
            this.Controls.Add(this.txtTatilGunleri);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtBitisTarihi);
            this.Controls.Add(this.dtBaslangicTarihi);
            this.Controls.Add(this.cmbVardiya);
            this.Controls.Add(this.cmbPersonel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "frmPersonelVardiyasiEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Personel Vardiyası Tanımla";
            this.Load += new System.EventHandler(this.frmPersonelVardiyasiEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cmbPersonel;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cmbVardiya;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DateTimePicker dtBaslangicTarihi;
        public System.Windows.Forms.DateTimePicker dtBitisTarihi;
        public System.Windows.Forms.TextBox txtTatilGunleri;
        private System.Windows.Forms.Button btnVardiyaEkle;
    }
}