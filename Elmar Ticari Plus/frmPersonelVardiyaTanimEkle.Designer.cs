namespace Elmar_Ticari_Plus
{
    partial class frmPersonelVardiyaTanimEkle
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtVardiyaAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBaslangicSaati = new System.Windows.Forms.MaskedTextBox();
            this.txtBitisSaati = new System.Windows.Forms.MaskedTextBox();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSubeAdi = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vardiya Adı";
            // 
            // txtVardiyaAdi
            // 
            this.txtVardiyaAdi.BackColor = System.Drawing.Color.White;
            this.txtVardiyaAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtVardiyaAdi.ForeColor = System.Drawing.Color.Black;
            this.txtVardiyaAdi.Location = new System.Drawing.Point(106, 70);
            this.txtVardiyaAdi.Name = "txtVardiyaAdi";
            this.txtVardiyaAdi.Size = new System.Drawing.Size(138, 22);
            this.txtVardiyaAdi.TabIndex = 1;
            this.txtVardiyaAdi.Tag = "001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(6, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Başlangıç Saati";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(6, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bitiş Saati";
            // 
            // txtBaslangicSaati
            // 
            this.txtBaslangicSaati.BackColor = System.Drawing.Color.White;
            this.txtBaslangicSaati.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBaslangicSaati.ForeColor = System.Drawing.Color.Black;
            this.txtBaslangicSaati.Location = new System.Drawing.Point(106, 96);
            this.txtBaslangicSaati.Mask = "00:00";
            this.txtBaslangicSaati.Name = "txtBaslangicSaati";
            this.txtBaslangicSaati.Size = new System.Drawing.Size(41, 22);
            this.txtBaslangicSaati.TabIndex = 2;
            this.txtBaslangicSaati.Tag = "001";
            this.txtBaslangicSaati.ValidatingType = typeof(System.DateTime);
            // 
            // txtBitisSaati
            // 
            this.txtBitisSaati.BackColor = System.Drawing.Color.White;
            this.txtBitisSaati.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBitisSaati.ForeColor = System.Drawing.Color.Black;
            this.txtBitisSaati.Location = new System.Drawing.Point(106, 122);
            this.txtBitisSaati.Mask = "00:00";
            this.txtBitisSaati.Name = "txtBitisSaati";
            this.txtBitisSaati.Size = new System.Drawing.Size(41, 22);
            this.txtBitisSaati.TabIndex = 3;
            this.txtBitisSaati.Tag = "001";
            this.txtBitisSaati.ValidatingType = typeof(System.DateTime);
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
            this.lblBaslik.Size = new System.Drawing.Size(248, 57);
            this.lblBaslik.TabIndex = 82;
            this.lblBaslik.Text = "Yeni Vardiya Tanımla      ";
            this.lblBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(90, 185);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(78, 30);
            this.btnKaydet.TabIndex = 81;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-23, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(319, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "____________________________________________________";
            // 
            // cmbSubeAdi
            // 
            this.cmbSubeAdi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSubeAdi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSubeAdi.BackColor = System.Drawing.Color.White;
            this.cmbSubeAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbSubeAdi.ForeColor = System.Drawing.Color.Black;
            this.cmbSubeAdi.FormattingEnabled = true;
            this.cmbSubeAdi.Location = new System.Drawing.Point(106, 146);
            this.cmbSubeAdi.Name = "cmbSubeAdi";
            this.cmbSubeAdi.Size = new System.Drawing.Size(138, 23);
            this.cmbSubeAdi.TabIndex = 4;
            this.cmbSubeAdi.Tag = "001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(6, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 85;
            this.label5.Text = "Şube Adı";
            // 
            // frmPersonelVardiyaTanimEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 221);
            this.Controls.Add(this.cmbSubeAdi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtBitisSaati);
            this.Controls.Add(this.txtBaslangicSaati);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVardiyaAdi);
            this.Controls.Add(this.label1);
            this.Name = "frmPersonelVardiyaTanimEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Vardiya Tanımla";
            this.Load += new System.EventHandler(this.frmPersonelVardiyaTanimEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtVardiyaAdi;
        public System.Windows.Forms.MaskedTextBox txtBaslangicSaati;
        public System.Windows.Forms.MaskedTextBox txtBitisSaati;
        public System.Windows.Forms.ComboBox cmbSubeAdi;
    }
}