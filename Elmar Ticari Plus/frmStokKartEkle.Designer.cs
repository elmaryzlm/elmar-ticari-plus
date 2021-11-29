namespace Elmar_Ticari_Plus
{
    partial class frmStokKartEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStokKartEkle));
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.btnKategoriBul = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbKdvTipi = new System.Windows.Forms.ComboBox();
            this.cmbKdv = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.txtUrunismi = new System.Windows.Forms.TextBox();
            this.chkWebdeGosterilsinmi = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbMobil = new System.Windows.Forms.CheckBox();
            this.chbVitrin = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAdet = new System.Windows.Forms.TextBox();
            this.btnBarkodUret = new System.Windows.Forms.Button();
            this.btnKaydetYeni = new System.Windows.Forms.Button();
            this.txtKarOrani = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAlisFiyat = new System.Windows.Forms.TextBox();
            this.txtKar = new System.Windows.Forms.TextBox();
            this.txtSatisFiyat = new System.Windows.Forms.TextBox();
            this.cmbBirim = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.pnlUst = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.pnlUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbKategori
            // 
            this.cmbKategori.BackColor = System.Drawing.Color.White;
            this.cmbKategori.ForeColor = System.Drawing.Color.Black;
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Items.AddRange(new object[] {
            "TL",
            "DOLAR",
            "EURO"});
            this.cmbKategori.Location = new System.Drawing.Point(73, 44);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(193, 21);
            this.cmbKategori.TabIndex = 4;
            this.cmbKategori.Tag = "001";
            this.cmbKategori.SelectedIndexChanged += new System.EventHandler(this.cmbKategori_SelectedIndexChanged);
            // 
            // btnKategoriBul
            // 
            this.btnKategoriBul.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKategoriBul.Location = new System.Drawing.Point(268, 43);
            this.btnKategoriBul.Name = "btnKategoriBul";
            this.btnKategoriBul.Size = new System.Drawing.Size(24, 23);
            this.btnKategoriBul.TabIndex = 0;
            this.btnKategoriBul.TabStop = false;
            this.btnKategoriBul.Text = "...";
            this.btnKategoriBul.UseVisualStyleBackColor = false;
            this.btnKategoriBul.Click += new System.EventHandler(this.btnKategoriBul_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 48);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(46, 13);
            this.label23.TabIndex = 41;
            this.label23.Text = "Kategori";
            // 
            // cmbKdvTipi
            // 
            this.cmbKdvTipi.BackColor = System.Drawing.Color.White;
            this.cmbKdvTipi.ForeColor = System.Drawing.Color.Black;
            this.cmbKdvTipi.FormattingEnabled = true;
            this.cmbKdvTipi.Items.AddRange(new object[] {
            "Dahil",
            "Hariç"});
            this.cmbKdvTipi.Location = new System.Drawing.Point(211, 107);
            this.cmbKdvTipi.Name = "cmbKdvTipi";
            this.cmbKdvTipi.Size = new System.Drawing.Size(80, 21);
            this.cmbKdvTipi.TabIndex = 8;
            this.cmbKdvTipi.Tag = "001";
            this.cmbKdvTipi.Text = "Dahil";
            // 
            // cmbKdv
            // 
            this.cmbKdv.BackColor = System.Drawing.Color.White;
            this.cmbKdv.ForeColor = System.Drawing.Color.Black;
            this.cmbKdv.FormattingEnabled = true;
            this.cmbKdv.Items.AddRange(new object[] {
            "0",
            "1",
            "5",
            "8",
            "18"});
            this.cmbKdv.Location = new System.Drawing.Point(73, 107);
            this.cmbKdv.Name = "cmbKdv";
            this.cmbKdv.Size = new System.Drawing.Size(85, 21);
            this.cmbKdv.TabIndex = 7;
            this.cmbKdv.Tag = "001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "KDV";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(3, 27);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(51, 13);
            this.label69.TabIndex = 20;
            this.label69.Text = "Ürün İsmi";
            // 
            // txtUrunismi
            // 
            this.txtUrunismi.BackColor = System.Drawing.Color.White;
            this.txtUrunismi.ForeColor = System.Drawing.Color.Black;
            this.txtUrunismi.Location = new System.Drawing.Point(73, 24);
            this.txtUrunismi.Name = "txtUrunismi";
            this.txtUrunismi.Size = new System.Drawing.Size(218, 20);
            this.txtUrunismi.TabIndex = 3;
            this.txtUrunismi.Tag = "001";
            this.txtUrunismi.Leave += new System.EventHandler(this.txtUrunismi_Leave);
            // 
            // chkWebdeGosterilsinmi
            // 
            this.chkWebdeGosterilsinmi.AutoSize = true;
            this.chkWebdeGosterilsinmi.Location = new System.Drawing.Point(73, 175);
            this.chkWebdeGosterilsinmi.Name = "chkWebdeGosterilsinmi";
            this.chkWebdeGosterilsinmi.Size = new System.Drawing.Size(112, 17);
            this.chkWebdeGosterilsinmi.TabIndex = 18;
            this.chkWebdeGosterilsinmi.TabStop = false;
            this.chkWebdeGosterilsinmi.Text = "Webde Gösterilsin";
            this.chkWebdeGosterilsinmi.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chbMobil);
            this.panel1.Controls.Add(this.chbVitrin);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtAdet);
            this.panel1.Controls.Add(this.btnBarkodUret);
            this.panel1.Controls.Add(this.btnKaydetYeni);
            this.panel1.Controls.Add(this.txtKarOrani);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btnKaydet);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtAlisFiyat);
            this.panel1.Controls.Add(this.txtKar);
            this.panel1.Controls.Add(this.txtSatisFiyat);
            this.panel1.Controls.Add(this.cmbBirim);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtBarkod);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.chkWebdeGosterilsinmi);
            this.panel1.Controls.Add(this.label69);
            this.panel1.Controls.Add(this.txtUrunismi);
            this.panel1.Controls.Add(this.cmbKategori);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.btnKategoriBul);
            this.panel1.Controls.Add(this.cmbKdv);
            this.panel1.Controls.Add(this.cmbKdvTipi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 251);
            this.panel1.TabIndex = 1;
            this.panel1.TabStop = true;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // chbMobil
            // 
            this.chbMobil.AutoSize = true;
            this.chbMobil.Location = new System.Drawing.Point(73, 191);
            this.chbMobil.Name = "chbMobil";
            this.chbMobil.Size = new System.Drawing.Size(97, 17);
            this.chbMobil.TabIndex = 7785;
            this.chbMobil.TabStop = false;
            this.chbMobil.Text = "Mobilde Göster";
            this.chbMobil.UseVisualStyleBackColor = true;
            // 
            // chbVitrin
            // 
            this.chbVitrin.AutoSize = true;
            this.chbVitrin.Location = new System.Drawing.Point(73, 209);
            this.chbVitrin.Name = "chbVitrin";
            this.chbVitrin.Size = new System.Drawing.Size(95, 17);
            this.chbVitrin.TabIndex = 7784;
            this.chbVitrin.TabStop = false;
            this.chbVitrin.Text = "Vitrinde Göster";
            this.chbVitrin.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(71, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 13);
            this.label4.TabIndex = 7783;
            this.label4.Text = "Adet kısmı peşin alış olarak hesaba işlenecek";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 7782;
            this.label2.Text = "Adet";
            // 
            // txtAdet
            // 
            this.txtAdet.Location = new System.Drawing.Point(73, 149);
            this.txtAdet.Name = "txtAdet";
            this.txtAdet.Size = new System.Drawing.Size(217, 20);
            this.txtAdet.TabIndex = 7781;
            this.txtAdet.Text = "0";
            // 
            // btnBarkodUret
            // 
            this.btnBarkodUret.Image = ((System.Drawing.Image)(resources.GetObject("btnBarkodUret.Image")));
            this.btnBarkodUret.Location = new System.Drawing.Point(267, 0);
            this.btnBarkodUret.Name = "btnBarkodUret";
            this.btnBarkodUret.Size = new System.Drawing.Size(24, 24);
            this.btnBarkodUret.TabIndex = 7780;
            this.btnBarkodUret.Text = " ";
            this.btnBarkodUret.UseVisualStyleBackColor = true;
            this.btnBarkodUret.Click += new System.EventHandler(this.btnBarkodUret_Click);
            // 
            // btnKaydetYeni
            // 
            this.btnKaydetYeni.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydetYeni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydetYeni.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydetYeni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydetYeni.Location = new System.Drawing.Point(191, 176);
            this.btnKaydetYeni.Name = "btnKaydetYeni";
            this.btnKaydetYeni.Size = new System.Drawing.Size(99, 49);
            this.btnKaydetYeni.TabIndex = 7779;
            this.btnKaydetYeni.Text = "Kaydet";
            this.btnKaydetYeni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydetYeni.UseVisualStyleBackColor = false;
            this.btnKaydetYeni.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtKarOrani
            // 
            this.txtKarOrani.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtKarOrani.ForeColor = System.Drawing.Color.Black;
            this.txtKarOrani.Location = new System.Drawing.Point(73, 86);
            this.txtKarOrani.Name = "txtKarOrani";
            this.txtKarOrani.ReadOnly = true;
            this.txtKarOrani.Size = new System.Drawing.Size(85, 20);
            this.txtKarOrani.TabIndex = 7777;
            this.txtKarOrani.TabStop = false;
            this.txtKarOrani.Tag = "";
            this.txtKarOrani.Text = "0";
            this.txtKarOrani.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7778;
            this.label3.Text = "KDV Tipi";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(3, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 15);
            this.label10.TabIndex = 69;
            this.label10.Tag = "";
            this.label10.Text = "Kar Oranı %";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(-17, 193);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(71, 32);
            this.btnKaydet.TabIndex = 10;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Visible = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(159, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 15);
            this.label11.TabIndex = 1;
            this.label11.Tag = "";
            this.label11.Text = "Kar";
            // 
            // txtAlisFiyat
            // 
            this.txtAlisFiyat.BackColor = System.Drawing.Color.White;
            this.txtAlisFiyat.ForeColor = System.Drawing.Color.Black;
            this.txtAlisFiyat.Location = new System.Drawing.Point(73, 65);
            this.txtAlisFiyat.Name = "txtAlisFiyat";
            this.txtAlisFiyat.Size = new System.Drawing.Size(85, 20);
            this.txtAlisFiyat.TabIndex = 5;
            this.txtAlisFiyat.Tag = "521";
            this.txtAlisFiyat.Text = "0";
            this.txtAlisFiyat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAlisFiyat.TextChanged += new System.EventHandler(this.txtAlisFiyat_TextChanged);
            // 
            // txtKar
            // 
            this.txtKar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtKar.ForeColor = System.Drawing.Color.Black;
            this.txtKar.Location = new System.Drawing.Point(211, 86);
            this.txtKar.Name = "txtKar";
            this.txtKar.ReadOnly = true;
            this.txtKar.Size = new System.Drawing.Size(81, 20);
            this.txtKar.TabIndex = 15;
            this.txtKar.TabStop = false;
            this.txtKar.Tag = "";
            this.txtKar.Text = "0";
            this.txtKar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSatisFiyat
            // 
            this.txtSatisFiyat.BackColor = System.Drawing.Color.White;
            this.txtSatisFiyat.ForeColor = System.Drawing.Color.Black;
            this.txtSatisFiyat.Location = new System.Drawing.Point(211, 65);
            this.txtSatisFiyat.Name = "txtSatisFiyat";
            this.txtSatisFiyat.Size = new System.Drawing.Size(81, 20);
            this.txtSatisFiyat.TabIndex = 6;
            this.txtSatisFiyat.Tag = "521";
            this.txtSatisFiyat.Text = "0";
            this.txtSatisFiyat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSatisFiyat.TextChanged += new System.EventHandler(this.txtAlisFiyat_TextChanged);
            // 
            // cmbBirim
            // 
            this.cmbBirim.BackColor = System.Drawing.Color.White;
            this.cmbBirim.ForeColor = System.Drawing.Color.Black;
            this.cmbBirim.FormattingEnabled = true;
            this.cmbBirim.Items.AddRange(new object[] {
            "Adet",
            "Litre",
            "Koli"});
            this.cmbBirim.Location = new System.Drawing.Point(73, 128);
            this.cmbBirim.Name = "cmbBirim";
            this.cmbBirim.Size = new System.Drawing.Size(218, 21);
            this.cmbBirim.TabIndex = 9;
            this.cmbBirim.Tag = "001";
            this.cmbBirim.SelectedIndexChanged += new System.EventHandler(this.cmbBirim_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 62;
            this.label13.Text = "Birim";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(159, 68);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 13);
            this.label21.TabIndex = 60;
            this.label21.Text = "Satış Fiyat";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 58;
            this.label15.Text = "Barkod";
            // 
            // txtBarkod
            // 
            this.txtBarkod.BackColor = System.Drawing.Color.White;
            this.txtBarkod.ForeColor = System.Drawing.Color.Black;
            this.txtBarkod.Location = new System.Drawing.Point(73, 4);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(193, 20);
            this.txtBarkod.TabIndex = 2;
            this.txtBarkod.Tag = "001";
            this.txtBarkod.Leave += new System.EventHandler(this.txtBarkod_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 68);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 13);
            this.label19.TabIndex = 56;
            this.label19.Text = "Alış Fiyat";
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.ForeColor = System.Drawing.Color.Black;
            this.lblBaslik.Location = new System.Drawing.Point(54, 14);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(173, 20);
            this.lblBaslik.TabIndex = 2;
            this.lblBaslik.Text = "Yeni Stok Kartı Tanımla";
            // 
            // pnlUst
            // 
            this.pnlUst.BackColor = System.Drawing.Color.White;
            this.pnlUst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUst.Controls.Add(this.lblBaslik);
            this.pnlUst.Controls.Add(this.pictureBox1);
            this.pnlUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUst.Location = new System.Drawing.Point(0, 0);
            this.pnlUst.Name = "pnlUst";
            this.pnlUst.Size = new System.Drawing.Size(306, 49);
            this.pnlUst.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::Elmar_Ticari_Plus.Properties.Resources.Stokkart_Ekle;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmStokKartEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(306, 300);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlUst);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmStokKartEkle";
            this.Text = "Stok Kartı Ekle";
            this.Load += new System.EventHandler(this.frmStokKartEkle_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlUst.ResumeLayout(false);
            this.pnlUst.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKategoriBul;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbKdvTipi;
        private System.Windows.Forms.ComboBox cmbKdv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.TextBox txtUrunismi;
        private System.Windows.Forms.CheckBox chkWebdeGosterilsinmi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.TextBox txtAlisFiyat;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Panel pnlUst;
        private System.Windows.Forms.TextBox txtKar;
        private System.Windows.Forms.TextBox txtKarOrani;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSatisFiyat;
        private System.Windows.Forms.ComboBox cmbBirim;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnKaydetYeni;
        private System.Windows.Forms.Button btnBarkodUret;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAdet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbMobil;
        private System.Windows.Forms.CheckBox chbVitrin;
    }
}