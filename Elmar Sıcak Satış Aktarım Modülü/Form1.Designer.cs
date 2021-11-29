namespace Elmar_Sıcak_Satış_Aktarım_Modülü
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtYol = new System.Windows.Forms.TextBox();
            this.btnDosyaSecimi = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdPDAtoAnaYazilim = new System.Windows.Forms.RadioButton();
            this.rdAnaYazilimToPDA = new System.Windows.Forms.RadioButton();
            this.btnAktarimiBaslat = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 87);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(112, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 85);
            this.label1.TabIndex = 1;
            this.label1.Text = "PDA Veri Tabanı Aktarım Sihirbazına Hoşgeldiniz.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDosyaSecimi);
            this.groupBox1.Controls.Add(this.txtYol);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 70);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adım 1: Veri Tabanı Yol Seçimi";
            // 
            // txtYol
            // 
            this.txtYol.Enabled = false;
            this.txtYol.Location = new System.Drawing.Point(7, 31);
            this.txtYol.Name = "txtYol";
            this.txtYol.Size = new System.Drawing.Size(249, 21);
            this.txtYol.TabIndex = 0;
            // 
            // btnDosyaSecimi
            // 
            this.btnDosyaSecimi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDosyaSecimi.Location = new System.Drawing.Point(257, 30);
            this.btnDosyaSecimi.Name = "btnDosyaSecimi";
            this.btnDosyaSecimi.Size = new System.Drawing.Size(97, 23);
            this.btnDosyaSecimi.TabIndex = 1;
            this.btnDosyaSecimi.Text = "Dosya Seçimi";
            this.btnDosyaSecimi.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdAnaYazilimToPDA);
            this.groupBox2.Controls.Add(this.rdPDAtoAnaYazilim);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(12, 297);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 97);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adım 4: Aktarım Türü";
            // 
            // rdPDAtoAnaYazilim
            // 
            this.rdPDAtoAnaYazilim.AutoSize = true;
            this.rdPDAtoAnaYazilim.Checked = true;
            this.rdPDAtoAnaYazilim.Location = new System.Drawing.Point(7, 34);
            this.rdPDAtoAnaYazilim.Name = "rdPDAtoAnaYazilim";
            this.rdPDAtoAnaYazilim.Size = new System.Drawing.Size(266, 19);
            this.rdPDAtoAnaYazilim.TabIndex = 0;
            this.rdPDAtoAnaYazilim.TabStop = true;
            this.rdPDAtoAnaYazilim.Text = "PDA Yazılımından  Ana Yazılıma aktarım yap";
            this.rdPDAtoAnaYazilim.UseVisualStyleBackColor = true;
            // 
            // rdAnaYazilimToPDA
            // 
            this.rdAnaYazilimToPDA.AutoSize = true;
            this.rdAnaYazilimToPDA.Location = new System.Drawing.Point(7, 59);
            this.rdAnaYazilimToPDA.Name = "rdAnaYazilimToPDA";
            this.rdAnaYazilimToPDA.Size = new System.Drawing.Size(273, 19);
            this.rdAnaYazilimToPDA.TabIndex = 1;
            this.rdAnaYazilimToPDA.Text = "Ana Yazılımından PDA Yazılımına aktarım yap";
            this.rdAnaYazilimToPDA.UseVisualStyleBackColor = true;
            // 
            // btnAktarimiBaslat
            // 
            this.btnAktarimiBaslat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAktarimiBaslat.Image = global::Elmar_Sıcak_Satış_Aktarım_Modülü.Properties.Resources.Transfer_icon;
            this.btnAktarimiBaslat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAktarimiBaslat.Location = new System.Drawing.Point(129, 400);
            this.btnAktarimiBaslat.Name = "btnAktarimiBaslat";
            this.btnAktarimiBaslat.Size = new System.Drawing.Size(127, 37);
            this.btnAktarimiBaslat.TabIndex = 2;
            this.btnAktarimiBaslat.Text = "Aktarımı Başlat";
            this.btnAktarimiBaslat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAktarimiBaslat.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::Elmar_Sıcak_Satış_Aktarım_Modülü.Properties.Resources.PDA_icon;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtSifre);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtKullaniciAdi);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(12, 188);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(356, 93);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Adım 2: Kullanıcı Girişi";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Enabled = false;
            this.txtKullaniciAdi.Location = new System.Drawing.Point(83, 30);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(173, 21);
            this.txtKullaniciAdi.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kullanıcı Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Şifre";
            // 
            // txtSifre
            // 
            this.txtSifre.Enabled = false;
            this.txtSifre.Location = new System.Drawing.Point(83, 57);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(173, 21);
            this.txtSifre.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 446);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnAktarimiBaslat);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elmar Saha Satışı | Veri Tabanı Aktarım Modülü";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDosyaSecimi;
        private System.Windows.Forms.TextBox txtYol;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdAnaYazilimToPDA;
        private System.Windows.Forms.RadioButton rdPDAtoAnaYazilim;
        private System.Windows.Forms.Button btnAktarimiBaslat;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
    }
}

