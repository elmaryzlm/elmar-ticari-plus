namespace Elmar_Ticari_Plus
{
    partial class frmPersonelRaporlari
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
            this.btnRaporuGoruntule = new System.Windows.Forms.Button();
            this.lblBaslik = new System.Windows.Forms.Label();
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
            this.cmbPersonelAdlari.Location = new System.Drawing.Point(95, 36);
            this.cmbPersonelAdlari.Name = "cmbPersonelAdlari";
            this.cmbPersonelAdlari.Size = new System.Drawing.Size(291, 22);
            this.cmbPersonelAdlari.TabIndex = 1;
            this.cmbPersonelAdlari.Tag = "001";
            this.cmbPersonelAdlari.SelectedIndexChanged += new System.EventHandler(this.cmbPersonelAdlari_SelectedIndexChanged);
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(8, 41);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(82, 13);
            this.label73.TabIndex = 147;
            this.label73.Text = "Personel Seçimi";
            // 
            // btnRaporuGoruntule
            // 
            this.btnRaporuGoruntule.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRaporuGoruntule.Location = new System.Drawing.Point(250, 64);
            this.btnRaporuGoruntule.Name = "btnRaporuGoruntule";
            this.btnRaporuGoruntule.Size = new System.Drawing.Size(136, 25);
            this.btnRaporuGoruntule.TabIndex = 148;
            this.btnRaporuGoruntule.Text = "Raporu Görüntüle";
            this.btnRaporuGoruntule.UseVisualStyleBackColor = false;
            this.btnRaporuGoruntule.Click += new System.EventHandler(this.btnRaporuGoruntule_Click);
            // 
            // lblBaslik
            // 
            this.lblBaslik.BackColor = System.Drawing.Color.White;
            this.lblBaslik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.Image = global::Elmar_Ticari_Plus.Properties.Resources.V_Card_icon;
            this.lblBaslik.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(390, 29);
            this.lblBaslik.TabIndex = 149;
            this.lblBaslik.Text = "Personel Kişi Bilgileri Raporu";
            this.lblBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPersonelRaporlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(390, 98);
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.btnRaporuGoruntule);
            this.Controls.Add(this.cmbPersonelAdlari);
            this.Controls.Add(this.label73);
            this.Name = "frmPersonelRaporlari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Personel Raporu";
            this.Load += new System.EventHandler(this.frmPersonelRaporlari_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPersonelAdlari;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Button btnRaporuGoruntule;
        private System.Windows.Forms.Label lblBaslik;
    }
}