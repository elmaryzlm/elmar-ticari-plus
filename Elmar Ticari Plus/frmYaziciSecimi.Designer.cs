namespace Elmar_Ticari_Plus
{
    partial class frmYaziciSecimi
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
            this.label11 = new System.Windows.Forms.Label();
            this.cmbYazicilistesi = new System.Windows.Forms.ComboBox();
            this.btnDokumaniYazdir = new System.Windows.Forms.Button();
            this.btnYazdirma = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(101, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(191, 20);
            this.label11.TabIndex = 11127;
            this.label11.Text = "Yazdırılacak Yazıcı Seçimi";
            // 
            // cmbYazicilistesi
            // 
            this.cmbYazicilistesi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYazicilistesi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbYazicilistesi.FormattingEnabled = true;
            this.cmbYazicilistesi.Location = new System.Drawing.Point(105, 37);
            this.cmbYazicilistesi.Name = "cmbYazicilistesi";
            this.cmbYazicilistesi.Size = new System.Drawing.Size(216, 28);
            this.cmbYazicilistesi.TabIndex = 11126;
            this.cmbYazicilistesi.Tag = "faturaliSatisyaziciadi";
            // 
            // btnDokumaniYazdir
            // 
            this.btnDokumaniYazdir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDokumaniYazdir.Image = global::Elmar_Ticari_Plus.Properties.Resources._2_Hot_Printer_icon__1_;
            this.btnDokumaniYazdir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDokumaniYazdir.Location = new System.Drawing.Point(194, 71);
            this.btnDokumaniYazdir.Name = "btnDokumaniYazdir";
            this.btnDokumaniYazdir.Size = new System.Drawing.Size(93, 35);
            this.btnDokumaniYazdir.TabIndex = 11128;
            this.btnDokumaniYazdir.Text = "Yazdır";
            this.btnDokumaniYazdir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDokumaniYazdir.UseVisualStyleBackColor = true;
            this.btnDokumaniYazdir.Click += new System.EventHandler(this.btnDokumaniYazdir_Click);
            // 
            // btnYazdirma
            // 
            this.btnYazdirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYazdirma.Location = new System.Drawing.Point(128, 71);
            this.btnYazdirma.Name = "btnYazdirma";
            this.btnYazdirma.Size = new System.Drawing.Size(60, 35);
            this.btnYazdirma.TabIndex = 11129;
            this.btnYazdirma.Text = "İptal";
            this.btnYazdirma.UseVisualStyleBackColor = true;
            this.btnYazdirma.Click += new System.EventHandler(this.btnYazdirma_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Elmar_Ticari_Plus.Properties.Resources.Printer_Default_icon;
            this.pictureBox1.Location = new System.Drawing.Point(12, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 11130;
            this.pictureBox1.TabStop = false;
            // 
            // frmYaziciSecimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 119);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnYazdirma);
            this.Controls.Add(this.btnDokumaniYazdir);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbYazicilistesi);
            this.Name = "frmYaziciSecimi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yazıcı Seçimi";
            this.Load += new System.EventHandler(this.frmYaziciSecimi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbYazicilistesi;
        private System.Windows.Forms.Button btnDokumaniYazdir;
        private System.Windows.Forms.Button btnYazdirma;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}