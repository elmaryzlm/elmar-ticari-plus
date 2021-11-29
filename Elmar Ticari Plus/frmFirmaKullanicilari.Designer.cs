namespace Elmar_Ticari_Plus
{
    partial class frmFirmaKullanicilari
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
            this.pnlBilgileri = new System.Windows.Forms.Panel();
            this.chkGirisizni = new System.Windows.Forms.CheckBox();
            this.cmbSube = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbGorevi = new System.Windows.Forms.ComboBox();
            this.txtAdiSoyadi = new System.Windows.Forms.TextBox();
            this.txtEklenmeTarihi = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.txtOnlinemi = new System.Windows.Forms.TextBox();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnDegistir = new System.Windows.Forms.Button();
            this.btnİptal = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgKullanicilar = new System.Windows.Forms.DataGridView();
            this.kullaniciid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sifre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adiSoyadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gorevi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onlinemi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eklenmeTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subeid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subeAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.girisizni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBilgileri.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKullanicilar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBilgileri
            // 
            this.pnlBilgileri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBilgileri.Controls.Add(this.chkGirisizni);
            this.pnlBilgileri.Controls.Add(this.cmbSube);
            this.pnlBilgileri.Controls.Add(this.label3);
            this.pnlBilgileri.Controls.Add(this.cmbGorevi);
            this.pnlBilgileri.Controls.Add(this.txtAdiSoyadi);
            this.pnlBilgileri.Controls.Add(this.txtEklenmeTarihi);
            this.pnlBilgileri.Controls.Add(this.txtSifre);
            this.pnlBilgileri.Controls.Add(this.txtOnlinemi);
            this.pnlBilgileri.Controls.Add(this.txtKullaniciAdi);
            this.pnlBilgileri.Controls.Add(this.label4);
            this.pnlBilgileri.Controls.Add(this.label1);
            this.pnlBilgileri.Controls.Add(this.label2);
            this.pnlBilgileri.Controls.Add(this.label7);
            this.pnlBilgileri.Controls.Add(this.label6);
            this.pnlBilgileri.Controls.Add(this.label18);
            this.pnlBilgileri.Controls.Add(this.label19);
            this.pnlBilgileri.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBilgileri.Enabled = false;
            this.pnlBilgileri.Location = new System.Drawing.Point(424, 0);
            this.pnlBilgileri.Name = "pnlBilgileri";
            this.pnlBilgileri.Size = new System.Drawing.Size(284, 299);
            this.pnlBilgileri.TabIndex = 1;
            // 
            // chkGirisizni
            // 
            this.chkGirisizni.AutoSize = true;
            this.chkGirisizni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkGirisizni.Location = new System.Drawing.Point(68, 148);
            this.chkGirisizni.Name = "chkGirisizni";
            this.chkGirisizni.Size = new System.Drawing.Size(15, 14);
            this.chkGirisizni.TabIndex = 83;
            this.chkGirisizni.UseVisualStyleBackColor = true;
            // 
            // cmbSube
            // 
            this.cmbSube.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSube.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSube.BackColor = System.Drawing.Color.White;
            this.cmbSube.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbSube.ForeColor = System.Drawing.Color.Black;
            this.cmbSube.FormattingEnabled = true;
            this.cmbSube.Location = new System.Drawing.Point(67, 99);
            this.cmbSube.Name = "cmbSube";
            this.cmbSube.Size = new System.Drawing.Size(211, 23);
            this.cmbSube.TabIndex = 6;
            this.cmbSube.Tag = "001";
            this.cmbSube.SelectedIndexChanged += new System.EventHandler(this.cmbSube_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 82;
            this.label3.Text = "Şubesi";
            // 
            // cmbGorevi
            // 
            this.cmbGorevi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGorevi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGorevi.BackColor = System.Drawing.Color.White;
            this.cmbGorevi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbGorevi.ForeColor = System.Drawing.Color.Black;
            this.cmbGorevi.FormattingEnabled = true;
            this.cmbGorevi.Items.AddRange(new object[] {
            "Yönetici",
            "Muhasebeci",
            "Satış Elemanı",
            "Personel Sorumlusu",
            "Stok Sorumlusu"});
            this.cmbGorevi.Location = new System.Drawing.Point(67, 76);
            this.cmbGorevi.Name = "cmbGorevi";
            this.cmbGorevi.Size = new System.Drawing.Size(211, 23);
            this.cmbGorevi.TabIndex = 5;
            this.cmbGorevi.Tag = "001";
            // 
            // txtAdiSoyadi
            // 
            this.txtAdiSoyadi.BackColor = System.Drawing.Color.White;
            this.txtAdiSoyadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAdiSoyadi.ForeColor = System.Drawing.Color.Black;
            this.txtAdiSoyadi.Location = new System.Drawing.Point(67, 55);
            this.txtAdiSoyadi.Name = "txtAdiSoyadi";
            this.txtAdiSoyadi.Size = new System.Drawing.Size(211, 21);
            this.txtAdiSoyadi.TabIndex = 4;
            this.txtAdiSoyadi.Tag = "001";
            // 
            // txtEklenmeTarihi
            // 
            this.txtEklenmeTarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEklenmeTarihi.Location = new System.Drawing.Point(67, 165);
            this.txtEklenmeTarihi.Name = "txtEklenmeTarihi";
            this.txtEklenmeTarihi.ReadOnly = true;
            this.txtEklenmeTarihi.Size = new System.Drawing.Size(94, 21);
            this.txtEklenmeTarihi.TabIndex = 72;
            // 
            // txtSifre
            // 
            this.txtSifre.BackColor = System.Drawing.Color.White;
            this.txtSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSifre.ForeColor = System.Drawing.Color.Black;
            this.txtSifre.Location = new System.Drawing.Point(67, 34);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(211, 21);
            this.txtSifre.TabIndex = 3;
            this.txtSifre.Tag = "001";
            // 
            // txtOnlinemi
            // 
            this.txtOnlinemi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtOnlinemi.Location = new System.Drawing.Point(67, 123);
            this.txtOnlinemi.Name = "txtOnlinemi";
            this.txtOnlinemi.ReadOnly = true;
            this.txtOnlinemi.Size = new System.Drawing.Size(94, 21);
            this.txtOnlinemi.TabIndex = 7;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.BackColor = System.Drawing.Color.White;
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKullaniciAdi.ForeColor = System.Drawing.Color.Black;
            this.txtKullaniciAdi.Location = new System.Drawing.Point(67, 13);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(211, 21);
            this.txtKullaniciAdi.TabIndex = 2;
            this.txtKullaniciAdi.Tag = "001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Kayıt Tarihi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Giriş İzni";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Onlinemi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 79;
            this.label7.Text = "Görevi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 77;
            this.label6.Text = "Adı Soyadı";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 13);
            this.label18.TabIndex = 55;
            this.label18.Text = "Kullanıcı Adı";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 38);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(28, 13);
            this.label19.TabIndex = 56;
            this.label19.Text = "Şifre";
            // 
            // btnDegistir
            // 
            this.btnDegistir.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDegistir.Image = global::Elmar_Ticari_Plus.Properties.Resources.Pencil_icon;
            this.btnDegistir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDegistir.Location = new System.Drawing.Point(286, 3);
            this.btnDegistir.Name = "btnDegistir";
            this.btnDegistir.Size = new System.Drawing.Size(95, 32);
            this.btnDegistir.TabIndex = 52;
            this.btnDegistir.Text = "Değiştir[F3]";
            this.btnDegistir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDegistir.UseVisualStyleBackColor = false;
            this.btnDegistir.Click += new System.EventHandler(this.btnDegistir_Click);
            // 
            // btnİptal
            // 
            this.btnİptal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnİptal.Image = global::Elmar_Ticari_Plus.Properties.Resources.Delete_icon;
            this.btnİptal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnİptal.Location = new System.Drawing.Point(469, 3);
            this.btnİptal.Name = "btnİptal";
            this.btnİptal.Size = new System.Drawing.Size(77, 32);
            this.btnİptal.TabIndex = 49;
            this.btnİptal.Text = "İptal [F9]";
            this.btnİptal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnİptal.UseVisualStyleBackColor = false;
            this.btnİptal.Click += new System.EventHandler(this.btnİptal_Click);
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Image = global::Elmar_Ticari_Plus.Properties.Resources.Close_2_icon;
            this.btnSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSil.Location = new System.Drawing.Point(222, 3);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(65, 32);
            this.btnSil.TabIndex = 51;
            this.btnSil.Text = "Sil[F7]";
            this.btnSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(380, 3);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(90, 32);
            this.btnKaydet.TabIndex = 48;
            this.btnKaydet.Tag = "0";
            this.btnKaydet.Text = "Kaydet[F4]";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.Image = global::Elmar_Ticari_Plus.Properties.Resources.genelEkle;
            this.btnEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEkle.Location = new System.Drawing.Point(148, 3);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 32);
            this.btnEkle.TabIndex = 50;
            this.btnEkle.Text = "Ekle[F2]";
            this.btnEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDegistir);
            this.groupBox1.Controls.Add(this.btnİptal);
            this.groupBox1.Controls.Add(this.btnSil);
            this.groupBox1.Controls.Add(this.btnKaydet);
            this.groupBox1.Controls.Add(this.btnEkle);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 299);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(708, 38);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            // 
            // dgKullanicilar
            // 
            this.dgKullanicilar.AllowUserToAddRows = false;
            this.dgKullanicilar.AllowUserToDeleteRows = false;
            this.dgKullanicilar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgKullanicilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKullanicilar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kullaniciid,
            this.kAdi,
            this.sifre,
            this.adiSoyadi,
            this.gorevi,
            this.onlinemi,
            this.eklenmeTarihi,
            this.subeid,
            this.subeAdi,
            this.girisizni});
            this.dgKullanicilar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgKullanicilar.Location = new System.Drawing.Point(0, 0);
            this.dgKullanicilar.MultiSelect = false;
            this.dgKullanicilar.Name = "dgKullanicilar";
            this.dgKullanicilar.ReadOnly = true;
            this.dgKullanicilar.RowHeadersWidth = 20;
            this.dgKullanicilar.RowTemplate.Height = 20;
            this.dgKullanicilar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgKullanicilar.Size = new System.Drawing.Size(424, 299);
            this.dgKullanicilar.TabIndex = 77;
            this.dgKullanicilar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgKullanicilar_CellClick);
            // 
            // kullaniciid
            // 
            this.kullaniciid.HeaderText = "kullaniciid";
            this.kullaniciid.Name = "kullaniciid";
            this.kullaniciid.ReadOnly = true;
            this.kullaniciid.Visible = false;
            // 
            // kAdi
            // 
            this.kAdi.HeaderText = "Kullanıcı Adı";
            this.kAdi.Name = "kAdi";
            this.kAdi.ReadOnly = true;
            // 
            // sifre
            // 
            this.sifre.HeaderText = "Şifre";
            this.sifre.Name = "sifre";
            this.sifre.ReadOnly = true;
            this.sifre.Visible = false;
            // 
            // adiSoyadi
            // 
            this.adiSoyadi.HeaderText = "Adı Soyadı";
            this.adiSoyadi.Name = "adiSoyadi";
            this.adiSoyadi.ReadOnly = true;
            // 
            // gorevi
            // 
            this.gorevi.HeaderText = "Görevi";
            this.gorevi.Name = "gorevi";
            this.gorevi.ReadOnly = true;
            // 
            // onlinemi
            // 
            this.onlinemi.HeaderText = "Online";
            this.onlinemi.Name = "onlinemi";
            this.onlinemi.ReadOnly = true;
            this.onlinemi.Visible = false;
            // 
            // eklenmeTarihi
            // 
            this.eklenmeTarihi.HeaderText = "Eklenme Tarihi";
            this.eklenmeTarihi.Name = "eklenmeTarihi";
            this.eklenmeTarihi.ReadOnly = true;
            this.eklenmeTarihi.Visible = false;
            // 
            // subeid
            // 
            this.subeid.HeaderText = "subeid";
            this.subeid.Name = "subeid";
            this.subeid.ReadOnly = true;
            this.subeid.Visible = false;
            // 
            // subeAdi
            // 
            this.subeAdi.HeaderText = "Şube Adı";
            this.subeAdi.Name = "subeAdi";
            this.subeAdi.ReadOnly = true;
            // 
            // girisizni
            // 
            this.girisizni.HeaderText = "Giriş İzni";
            this.girisizni.Name = "girisizni";
            this.girisizni.ReadOnly = true;
            this.girisizni.Visible = false;
            // 
            // frmFirmaKullanicilari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(708, 337);
            this.Controls.Add(this.dgKullanicilar);
            this.Controls.Add(this.pnlBilgileri);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFirmaKullanicilari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Kullanıcı Bilgileri | Ekle, Düzenle, Sil";
            this.Load += new System.EventHandler(this.frmFirmaKullanicilari_Load);
            this.pnlBilgileri.ResumeLayout(false);
            this.pnlBilgileri.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgKullanicilar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBilgileri;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtEklenmeTarihi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.TextBox txtOnlinemi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Button btnDegistir;
        private System.Windows.Forms.Button btnİptal;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgKullanicilar;
        private System.Windows.Forms.ComboBox cmbGorevi;
        private System.Windows.Forms.TextBox txtAdiSoyadi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSube;
        private System.Windows.Forms.DataGridViewTextBoxColumn kullaniciid;
        private System.Windows.Forms.DataGridViewTextBoxColumn kAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn sifre;
        private System.Windows.Forms.DataGridViewTextBoxColumn adiSoyadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn gorevi;
        private System.Windows.Forms.DataGridViewTextBoxColumn onlinemi;
        private System.Windows.Forms.DataGridViewTextBoxColumn eklenmeTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn subeid;
        private System.Windows.Forms.DataGridViewTextBoxColumn subeAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn girisizni;
        private System.Windows.Forms.CheckBox chkGirisizni;
    }
}