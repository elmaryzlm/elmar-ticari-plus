namespace Elmar_Ticari_Plus
{
    partial class frmSicakSatisAktarimModulu
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDosyaSecimi = new System.Windows.Forms.Button();
            this.txtYol = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdAnaYazilimToPDA = new System.Windows.Forms.RadioButton();
            this.rdPDAtoAnaYazilim = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.btnAktarimiBaslat = new System.Windows.Forms.Button();
            this.p1 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(369, 87);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(112, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 85);
            this.label1.TabIndex = 1;
            this.label1.Text = "PDA Veri Tabanı Aktarım Sihirbazına Hoşgeldiniz.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::Elmar_Ticari_Plus.Properties.Resources.PDA_icon;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDosyaSecimi);
            this.groupBox1.Controls.Add(this.txtYol);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 70);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adım 1: Veri Tabanı Yol Seçimi";
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
            this.btnDosyaSecimi.Click += new System.EventHandler(this.btnDosyaSecimi_Click);
            // 
            // txtYol
            // 
            this.txtYol.Enabled = false;
            this.txtYol.Location = new System.Drawing.Point(7, 31);
            this.txtYol.Name = "txtYol";
            this.txtYol.Size = new System.Drawing.Size(249, 21);
            this.txtYol.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdAnaYazilimToPDA);
            this.groupBox2.Controls.Add(this.rdPDAtoAnaYazilim);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(12, 308);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 97);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adım 4: Aktarım Türü";
            // 
            // rdAnaYazilimToPDA
            // 
            this.rdAnaYazilimToPDA.AutoSize = true;
            this.rdAnaYazilimToPDA.Checked = true;
            this.rdAnaYazilimToPDA.Location = new System.Drawing.Point(7, 59);
            this.rdAnaYazilimToPDA.Name = "rdAnaYazilimToPDA";
            this.rdAnaYazilimToPDA.Size = new System.Drawing.Size(273, 19);
            this.rdAnaYazilimToPDA.TabIndex = 1;
            this.rdAnaYazilimToPDA.TabStop = true;
            this.rdAnaYazilimToPDA.Text = "Ana Yazılımından PDA Yazılımına aktarım yap";
            this.rdAnaYazilimToPDA.UseVisualStyleBackColor = true;
            // 
            // rdPDAtoAnaYazilim
            // 
            this.rdPDAtoAnaYazilim.AutoSize = true;
            this.rdPDAtoAnaYazilim.Location = new System.Drawing.Point(7, 34);
            this.rdPDAtoAnaYazilim.Name = "rdPDAtoAnaYazilim";
            this.rdPDAtoAnaYazilim.Size = new System.Drawing.Size(266, 19);
            this.rdPDAtoAnaYazilim.TabIndex = 0;
            this.rdPDAtoAnaYazilim.Text = "PDA Yazılımından  Ana Yazılıma aktarım yap";
            this.rdPDAtoAnaYazilim.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtSifre);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtKullaniciAdi);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(12, 199);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(356, 93);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Adım 2: Aktarım Yapılacak PDA Kullanıcısı";
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
            this.txtSifre.Location = new System.Drawing.Point(83, 57);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(173, 21);
            this.txtSifre.TabIndex = 2;
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
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(83, 30);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(173, 21);
            this.txtKullaniciAdi.TabIndex = 0;
            // 
            // btnAktarimiBaslat
            // 
            this.btnAktarimiBaslat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAktarimiBaslat.Image = global::Elmar_Ticari_Plus.Properties.Resources.Transfer_icon;
            this.btnAktarimiBaslat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAktarimiBaslat.Location = new System.Drawing.Point(129, 410);
            this.btnAktarimiBaslat.Name = "btnAktarimiBaslat";
            this.btnAktarimiBaslat.Size = new System.Drawing.Size(127, 37);
            this.btnAktarimiBaslat.TabIndex = 7;
            this.btnAktarimiBaslat.Text = "Aktarımı Başlat";
            this.btnAktarimiBaslat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAktarimiBaslat.UseVisualStyleBackColor = false;
            this.btnAktarimiBaslat.Click += new System.EventHandler(this.btnAktarimiBaslat_Click);
            // 
            // p1
            // 
            this.p1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p1.Location = new System.Drawing.Point(0, 450);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(369, 23);
            this.p1.TabIndex = 8;
            // 
            // frmSicakSatisAktarimModulu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 473);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnAktarimiBaslat);
            this.Name = "frmSicakSatisAktarimModulu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sıcak Satış Aktarım Modülü";
            this.Load += new System.EventHandler(this.frmSicakSatisAktarimModulu_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDosyaSecimi;
        private System.Windows.Forms.TextBox txtYol;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdAnaYazilimToPDA;
        private System.Windows.Forms.RadioButton rdPDAtoAnaYazilim;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Button btnAktarimiBaslat;
        private System.Windows.Forms.ProgressBar p1;
    }
}