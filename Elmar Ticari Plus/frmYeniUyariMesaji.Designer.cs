namespace Elmar_Ticari_Plus
{
    partial class frmYeniUyariMesaji
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
            this.txtUyariMetni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.cmbKullanicilar = new System.Windows.Forms.ComboBox();
            this.cmbSubeler = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUyariMetni
            // 
            this.txtUyariMetni.BackColor = System.Drawing.Color.White;
            this.txtUyariMetni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUyariMetni.ForeColor = System.Drawing.Color.Black;
            this.txtUyariMetni.Location = new System.Drawing.Point(79, 28);
            this.txtUyariMetni.Name = "txtUyariMetni";
            this.txtUyariMetni.Size = new System.Drawing.Size(337, 21);
            this.txtUyariMetni.TabIndex = 9;
            this.txtUyariMetni.Tag = "001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Uyarı Metni";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuncelle.Location = new System.Drawing.Point(175, 119);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(78, 34);
            this.btnGuncelle.TabIndex = 13;
            this.btnGuncelle.Text = "Kaydet";
            this.btnGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // cmbKullanicilar
            // 
            this.cmbKullanicilar.BackColor = System.Drawing.Color.White;
            this.cmbKullanicilar.ForeColor = System.Drawing.Color.Black;
            this.cmbKullanicilar.FormattingEnabled = true;
            this.cmbKullanicilar.Location = new System.Drawing.Point(79, 83);
            this.cmbKullanicilar.Name = "cmbKullanicilar";
            this.cmbKullanicilar.Size = new System.Drawing.Size(337, 21);
            this.cmbKullanicilar.TabIndex = 3;
            this.cmbKullanicilar.Tag = "001";
            // 
            // cmbSubeler
            // 
            this.cmbSubeler.BackColor = System.Drawing.Color.White;
            this.cmbSubeler.ForeColor = System.Drawing.Color.Black;
            this.cmbSubeler.FormattingEnabled = true;
            this.cmbSubeler.Location = new System.Drawing.Point(79, 55);
            this.cmbSubeler.Name = "cmbSubeler";
            this.cmbSubeler.Size = new System.Drawing.Size(337, 21);
            this.cmbSubeler.TabIndex = 0;
            this.cmbSubeler.Tag = "001";
            this.cmbSubeler.SelectedIndexChanged += new System.EventHandler(this.cmbSubeler_SelectedIndexChanged);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(18, 87);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(46, 13);
            this.label57.TabIndex = 2;
            this.label57.Text = "Kullanıcı";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(18, 59);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(32, 13);
            this.label58.TabIndex = 1;
            this.label58.Text = "Şube";
            // 
            // frmYeniUyariMesaji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 165);
            this.Controls.Add(this.cmbKullanicilar);
            this.Controls.Add(this.cmbSubeler);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.txtUyariMetni);
            this.Controls.Add(this.label1);
            this.Name = "frmYeniUyariMesaji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Uyarı Mesajı Ekle";
            this.Load += new System.EventHandler(this.frmYeniUyariMesaji_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUyariMetni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.ComboBox cmbKullanicilar;
        private System.Windows.Forms.ComboBox cmbSubeler;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
    }
}