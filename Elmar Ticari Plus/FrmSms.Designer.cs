namespace Elmar_Ticari_Plus
{
    partial class FrmSms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSms));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbUrunIndirimleri = new System.Windows.Forms.CheckBox();
            this.chbBayramMesaji = new System.Windows.Forms.CheckBox();
            this.chbBayramKampanyalari = new System.Windows.Forms.CheckBox();
            this.chbOzelGunler = new System.Windows.Forms.CheckBox();
            this.chbDogumGunleri = new System.Windows.Forms.CheckBox();
            this.chbCariBorc = new System.Windows.Forms.CheckBox();
            this.chbFaturasizSatis = new System.Windows.Forms.CheckBox();
            this.chbFaturaliSatis = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbMesajAdi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCariler = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBakiye = new System.Windows.Forms.Label();
            this.cmbBaslik = new System.Windows.Forms.ComboBox();
            this.txtTel = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMesaj = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGonder = new System.Windows.Forms.Button();
            this.dataGridViewRapor = new System.Windows.Forms.DataGridView();
            this.mesajTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Baslik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesajMetni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdiSoyadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FİRMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subeAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firmaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRapor)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 176);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(316, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(608, 176);
            this.panel5.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.chbUrunIndirimleri);
            this.groupBox1.Controls.Add(this.chbBayramMesaji);
            this.groupBox1.Controls.Add(this.chbBayramKampanyalari);
            this.groupBox1.Controls.Add(this.chbOzelGunler);
            this.groupBox1.Controls.Add(this.chbDogumGunleri);
            this.groupBox1.Controls.Add(this.chbCariBorc);
            this.groupBox1.Controls.Add(this.chbFaturasizSatis);
            this.groupBox1.Controls.Add(this.chbFaturaliSatis);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 176);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SMS YETKİLERİ";
            // 
            // chbUrunIndirimleri
            // 
            this.chbUrunIndirimleri.AutoSize = true;
            this.chbUrunIndirimleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chbUrunIndirimleri.Location = new System.Drawing.Point(11, 47);
            this.chbUrunIndirimleri.Name = "chbUrunIndirimleri";
            this.chbUrunIndirimleri.Size = new System.Drawing.Size(115, 20);
            this.chbUrunIndirimleri.TabIndex = 7;
            this.chbUrunIndirimleri.Text = "Ürün İndirimleri";
            this.chbUrunIndirimleri.UseVisualStyleBackColor = true;
            this.chbUrunIndirimleri.Click += new System.EventHandler(this.chbFaturaliSatis_Click);
            // 
            // chbBayramMesaji
            // 
            this.chbBayramMesaji.AutoSize = true;
            this.chbBayramMesaji.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chbBayramMesaji.Location = new System.Drawing.Point(11, 70);
            this.chbBayramMesaji.Name = "chbBayramMesaji";
            this.chbBayramMesaji.Size = new System.Drawing.Size(117, 20);
            this.chbBayramMesaji.TabIndex = 6;
            this.chbBayramMesaji.Text = "Bayram Mesajı";
            this.chbBayramMesaji.UseVisualStyleBackColor = true;
            this.chbBayramMesaji.Click += new System.EventHandler(this.chbFaturaliSatis_Click);
            // 
            // chbBayramKampanyalari
            // 
            this.chbBayramKampanyalari.AutoSize = true;
            this.chbBayramKampanyalari.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chbBayramKampanyalari.Location = new System.Drawing.Point(163, 70);
            this.chbBayramKampanyalari.Name = "chbBayramKampanyalari";
            this.chbBayramKampanyalari.Size = new System.Drawing.Size(160, 20);
            this.chbBayramKampanyalari.TabIndex = 5;
            this.chbBayramKampanyalari.Text = "Bayram Kampanyaları";
            this.chbBayramKampanyalari.UseVisualStyleBackColor = true;
            this.chbBayramKampanyalari.Click += new System.EventHandler(this.chbFaturaliSatis_Click);
            // 
            // chbOzelGunler
            // 
            this.chbOzelGunler.AutoSize = true;
            this.chbOzelGunler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chbOzelGunler.Location = new System.Drawing.Point(163, 93);
            this.chbOzelGunler.Name = "chbOzelGunler";
            this.chbOzelGunler.Size = new System.Drawing.Size(96, 20);
            this.chbOzelGunler.TabIndex = 4;
            this.chbOzelGunler.Text = "Özel Günler";
            this.chbOzelGunler.UseVisualStyleBackColor = true;
            this.chbOzelGunler.Click += new System.EventHandler(this.chbFaturaliSatis_Click);
            // 
            // chbDogumGunleri
            // 
            this.chbDogumGunleri.AutoSize = true;
            this.chbDogumGunleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chbDogumGunleri.Location = new System.Drawing.Point(11, 93);
            this.chbDogumGunleri.Name = "chbDogumGunleri";
            this.chbDogumGunleri.Size = new System.Drawing.Size(116, 20);
            this.chbDogumGunleri.TabIndex = 3;
            this.chbDogumGunleri.Text = "Doğum Günleri";
            this.chbDogumGunleri.UseVisualStyleBackColor = true;
            this.chbDogumGunleri.Click += new System.EventHandler(this.chbFaturaliSatis_Click);
            // 
            // chbCariBorc
            // 
            this.chbCariBorc.AutoSize = true;
            this.chbCariBorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chbCariBorc.Location = new System.Drawing.Point(163, 47);
            this.chbCariBorc.Name = "chbCariBorc";
            this.chbCariBorc.Size = new System.Drawing.Size(146, 20);
            this.chbCariBorc.TabIndex = 2;
            this.chbCariBorc.Text = "Cari Borç Hatırlatma";
            this.chbCariBorc.UseVisualStyleBackColor = true;
            this.chbCariBorc.Click += new System.EventHandler(this.chbFaturaliSatis_Click);
            // 
            // chbFaturasizSatis
            // 
            this.chbFaturasizSatis.AutoSize = true;
            this.chbFaturasizSatis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chbFaturasizSatis.Location = new System.Drawing.Point(163, 24);
            this.chbFaturasizSatis.Name = "chbFaturasizSatis";
            this.chbFaturasizSatis.Size = new System.Drawing.Size(114, 20);
            this.chbFaturasizSatis.TabIndex = 1;
            this.chbFaturasizSatis.Text = "Faturasız Satış";
            this.chbFaturasizSatis.UseVisualStyleBackColor = true;
            this.chbFaturasizSatis.Click += new System.EventHandler(this.chbFaturaliSatis_Click);
            // 
            // chbFaturaliSatis
            // 
            this.chbFaturaliSatis.AutoSize = true;
            this.chbFaturaliSatis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chbFaturaliSatis.Location = new System.Drawing.Point(11, 24);
            this.chbFaturaliSatis.Name = "chbFaturaliSatis";
            this.chbFaturaliSatis.Size = new System.Drawing.Size(104, 20);
            this.chbFaturaliSatis.TabIndex = 0;
            this.chbFaturaliSatis.Text = "Faturalı Satış";
            this.chbFaturaliSatis.UseVisualStyleBackColor = true;
            this.chbFaturaliSatis.Click += new System.EventHandler(this.chbFaturaliSatis_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cmbMesajAdi);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.cmbCariler);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.lblBakiye);
            this.panel4.Controls.Add(this.cmbBaslik);
            this.panel4.Controls.Add(this.txtTel);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(316, 176);
            this.panel4.TabIndex = 8;
            // 
            // cmbMesajAdi
            // 
            this.cmbMesajAdi.BackColor = System.Drawing.Color.White;
            this.cmbMesajAdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesajAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbMesajAdi.FormattingEnabled = true;
            this.cmbMesajAdi.Location = new System.Drawing.Point(99, 78);
            this.cmbMesajAdi.Name = "cmbMesajAdi";
            this.cmbMesajAdi.Size = new System.Drawing.Size(212, 23);
            this.cmbMesajAdi.TabIndex = 0;
            this.cmbMesajAdi.SelectedIndexChanged += new System.EventHandler(this.cmbMesajAdi_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(9, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cep";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(9, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Başlık";
            // 
            // cmbCariler
            // 
            this.cmbCariler.BackColor = System.Drawing.Color.White;
            this.cmbCariler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCariler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCariler.FormattingEnabled = true;
            this.cmbCariler.Location = new System.Drawing.Point(99, 49);
            this.cmbCariler.Name = "cmbCariler";
            this.cmbCariler.Size = new System.Drawing.Size(212, 23);
            this.cmbCariler.TabIndex = 6;
            this.cmbCariler.SelectedIndexChanged += new System.EventHandler(this.cmbCariler_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(9, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mesaj Adı";
            // 
            // lblBakiye
            // 
            this.lblBakiye.AutoSize = true;
            this.lblBakiye.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBakiye.ForeColor = System.Drawing.Color.DarkRed;
            this.lblBakiye.Location = new System.Drawing.Point(157, 9);
            this.lblBakiye.Name = "lblBakiye";
            this.lblBakiye.Size = new System.Drawing.Size(62, 20);
            this.lblBakiye.TabIndex = 4;
            this.lblBakiye.Text = "0 Adet";
            // 
            // cmbBaslik
            // 
            this.cmbBaslik.BackColor = System.Drawing.Color.White;
            this.cmbBaslik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaslik.FormattingEnabled = true;
            this.cmbBaslik.Items.AddRange(new object[] {
            "ELMAR YZLM"});
            this.cmbBaslik.Location = new System.Drawing.Point(99, 107);
            this.cmbBaslik.Name = "cmbBaslik";
            this.cmbBaslik.Size = new System.Drawing.Size(212, 21);
            this.cmbBaslik.TabIndex = 0;
            // 
            // txtTel
            // 
            this.txtTel.BackColor = System.Drawing.Color.White;
            this.txtTel.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtTel.Location = new System.Drawing.Point(99, 134);
            this.txtTel.Mask = "(999) 000-0000";
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(145, 20);
            this.txtTel.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(11, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cari";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(48, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kalan Bakiye:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtMesaj);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 176);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 548);
            this.panel2.TabIndex = 1;
            // 
            // txtMesaj
            // 
            this.txtMesaj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMesaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMesaj.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtMesaj.Location = new System.Drawing.Point(0, 0);
            this.txtMesaj.Multiline = true;
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.Size = new System.Drawing.Size(316, 504);
            this.txtMesaj.TabIndex = 3;
            this.txtMesaj.Text = "BİR MESAJ  YAZ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnGonder);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 504);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(316, 44);
            this.panel3.TabIndex = 2;
            // 
            // btnGonder
            // 
            this.btnGonder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGonder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGonder.ForeColor = System.Drawing.Color.Red;
            this.btnGonder.Image = ((System.Drawing.Image)(resources.GetObject("btnGonder.Image")));
            this.btnGonder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGonder.Location = new System.Drawing.Point(0, 8);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(316, 36);
            this.btnGonder.TabIndex = 3;
            this.btnGonder.Text = "GÖNDER";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // dataGridViewRapor
            // 
            this.dataGridViewRapor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRapor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mesajTarihi,
            this.Baslik,
            this.mesajMetni,
            this.AdiSoyadi,
            this.FİRMA,
            this.subeAdi,
            this.kAdi,
            this.firmaid});
            this.dataGridViewRapor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRapor.Location = new System.Drawing.Point(316, 176);
            this.dataGridViewRapor.Name = "dataGridViewRapor";
            this.dataGridViewRapor.Size = new System.Drawing.Size(608, 548);
            this.dataGridViewRapor.TabIndex = 5;
            // 
            // mesajTarihi
            // 
            this.mesajTarihi.HeaderText = "Tarih";
            this.mesajTarihi.Name = "mesajTarihi";
            // 
            // Baslik
            // 
            this.Baslik.HeaderText = "Başlık";
            this.Baslik.Name = "Baslik";
            // 
            // mesajMetni
            // 
            this.mesajMetni.HeaderText = "Mesaj";
            this.mesajMetni.Name = "mesajMetni";
            // 
            // AdiSoyadi
            // 
            this.AdiSoyadi.HeaderText = "Adı Soyadı";
            this.AdiSoyadi.Name = "AdiSoyadi";
            // 
            // FİRMA
            // 
            this.FİRMA.HeaderText = "Firma";
            this.FİRMA.Name = "FİRMA";
            // 
            // subeAdi
            // 
            this.subeAdi.HeaderText = "Şube";
            this.subeAdi.Name = "subeAdi";
            // 
            // kAdi
            // 
            this.kAdi.HeaderText = "Kullanıcı";
            this.kAdi.Name = "kAdi";
            // 
            // firmaid
            // 
            this.firmaid.HeaderText = "firmaid";
            this.firmaid.Name = "firmaid";
            this.firmaid.Visible = false;
            // 
            // FrmSms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 724);
            this.Controls.Add(this.dataGridViewRapor);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMS EKRANI";
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRapor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBakiye;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCariler;
        private System.Windows.Forms.MaskedTextBox txtTel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMesajAdi;
        private System.Windows.Forms.ComboBox cmbBaslik;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtMesaj;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbUrunIndirimleri;
        private System.Windows.Forms.CheckBox chbBayramMesaji;
        private System.Windows.Forms.CheckBox chbBayramKampanyalari;
        private System.Windows.Forms.CheckBox chbOzelGunler;
        private System.Windows.Forms.CheckBox chbDogumGunleri;
        private System.Windows.Forms.CheckBox chbCariBorc;
        private System.Windows.Forms.CheckBox chbFaturasizSatis;
        private System.Windows.Forms.CheckBox chbFaturaliSatis;
        private System.Windows.Forms.DataGridView dataGridViewRapor;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesajTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Baslik;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesajMetni;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdiSoyadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn FİRMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn subeAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn kAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn firmaid;
    }
}