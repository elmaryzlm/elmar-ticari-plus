namespace Elmar_Ticari_Plus
{
    partial class frmFirmaSubeBilgileri
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
            this.dgSubeler = new System.Windows.Forms.DataGridView();
            this.subeid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subeAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bolgeid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bolgeAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gsm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vergiDaire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vergiNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.altBilgiNotu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eklenmeTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBolge = new System.Windows.Forms.TextBox();
            this.txtBolgeSec = new System.Windows.Forms.Button();
            this.txtSubeAdi = new System.Windows.Forms.TextBox();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.MaskedTextBox();
            this.txtGsm = new System.Windows.Forms.MaskedTextBox();
            this.txtTel = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtVergiDairesi = new System.Windows.Forms.TextBox();
            this.txtVergiNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAltBilgiNotu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDegistir = new System.Windows.Forms.Button();
            this.btnİptal = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.txtEklenmeTarihi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlBilgileri = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubeler)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlBilgileri.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgSubeler
            // 
            this.dgSubeler.AllowUserToAddRows = false;
            this.dgSubeler.AllowUserToDeleteRows = false;
            this.dgSubeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSubeler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.subeid,
            this.subeAdi,
            this.bolgeid,
            this.bolgeAdi,
            this.adres,
            this.tel,
            this.gsm,
            this.fax,
            this.email,
            this.vergiDaire,
            this.vergiNo,
            this.altBilgiNotu,
            this.eklenmeTarihi});
            this.dgSubeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSubeler.Location = new System.Drawing.Point(0, 0);
            this.dgSubeler.MultiSelect = false;
            this.dgSubeler.Name = "dgSubeler";
            this.dgSubeler.ReadOnly = true;
            this.dgSubeler.RowHeadersWidth = 20;
            this.dgSubeler.RowTemplate.Height = 20;
            this.dgSubeler.Size = new System.Drawing.Size(203, 287);
            this.dgSubeler.TabIndex = 0;
            this.dgSubeler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSubeler_CellClick);
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
            this.subeAdi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.subeAdi.HeaderText = "Şube Adı";
            this.subeAdi.Name = "subeAdi";
            this.subeAdi.ReadOnly = true;
            // 
            // bolgeid
            // 
            this.bolgeid.HeaderText = "bolgeid";
            this.bolgeid.Name = "bolgeid";
            this.bolgeid.ReadOnly = true;
            this.bolgeid.Visible = false;
            // 
            // bolgeAdi
            // 
            this.bolgeAdi.HeaderText = "Bölge Adı";
            this.bolgeAdi.Name = "bolgeAdi";
            this.bolgeAdi.ReadOnly = true;
            this.bolgeAdi.Visible = false;
            // 
            // adres
            // 
            this.adres.HeaderText = "Adres";
            this.adres.Name = "adres";
            this.adres.ReadOnly = true;
            this.adres.Visible = false;
            // 
            // tel
            // 
            this.tel.HeaderText = "Tel";
            this.tel.Name = "tel";
            this.tel.ReadOnly = true;
            this.tel.Visible = false;
            // 
            // gsm
            // 
            this.gsm.HeaderText = "Gsm";
            this.gsm.Name = "gsm";
            this.gsm.ReadOnly = true;
            this.gsm.Visible = false;
            // 
            // fax
            // 
            this.fax.HeaderText = "fax";
            this.fax.Name = "fax";
            this.fax.ReadOnly = true;
            this.fax.Visible = false;
            // 
            // email
            // 
            this.email.HeaderText = "E-Mail";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Visible = false;
            // 
            // vergiDaire
            // 
            this.vergiDaire.HeaderText = "VD.";
            this.vergiDaire.Name = "vergiDaire";
            this.vergiDaire.ReadOnly = true;
            this.vergiDaire.Visible = false;
            // 
            // vergiNo
            // 
            this.vergiNo.HeaderText = "VN.";
            this.vergiNo.Name = "vergiNo";
            this.vergiNo.ReadOnly = true;
            this.vergiNo.Visible = false;
            // 
            // altBilgiNotu
            // 
            this.altBilgiNotu.HeaderText = "Alt Bilgi Notu";
            this.altBilgiNotu.Name = "altBilgiNotu";
            this.altBilgiNotu.ReadOnly = true;
            this.altBilgiNotu.Visible = false;
            // 
            // eklenmeTarihi
            // 
            this.eklenmeTarihi.HeaderText = "Eklenme Tarihi";
            this.eklenmeTarihi.Name = "eklenmeTarihi";
            this.eklenmeTarihi.ReadOnly = true;
            this.eklenmeTarihi.Visible = false;
            // 
            // txtBolge
            // 
            this.txtBolge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBolge.Location = new System.Drawing.Point(63, 114);
            this.txtBolge.Name = "txtBolge";
            this.txtBolge.ReadOnly = true;
            this.txtBolge.Size = new System.Drawing.Size(203, 21);
            this.txtBolge.TabIndex = 64;
            this.txtBolge.Tag = "00";
            // 
            // txtBolgeSec
            // 
            this.txtBolgeSec.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBolgeSec.Location = new System.Drawing.Point(266, 112);
            this.txtBolgeSec.Name = "txtBolgeSec";
            this.txtBolgeSec.Size = new System.Drawing.Size(24, 23);
            this.txtBolgeSec.TabIndex = 63;
            this.txtBolgeSec.Text = "...";
            this.txtBolgeSec.UseVisualStyleBackColor = false;
            this.txtBolgeSec.Click += new System.EventHandler(this.txtBolgeSec_Click);
            // 
            // txtSubeAdi
            // 
            this.txtSubeAdi.BackColor = System.Drawing.Color.White;
            this.txtSubeAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSubeAdi.ForeColor = System.Drawing.Color.Black;
            this.txtSubeAdi.Location = new System.Drawing.Point(63, 13);
            this.txtSubeAdi.Name = "txtSubeAdi";
            this.txtSubeAdi.Size = new System.Drawing.Size(227, 21);
            this.txtSubeAdi.TabIndex = 1;
            this.txtSubeAdi.Tag = "001";
            // 
            // txtAdres
            // 
            this.txtAdres.BackColor = System.Drawing.Color.White;
            this.txtAdres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAdres.ForeColor = System.Drawing.Color.Black;
            this.txtAdres.Location = new System.Drawing.Point(63, 135);
            this.txtAdres.Multiline = true;
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAdres.Size = new System.Drawing.Size(229, 43);
            this.txtAdres.TabIndex = 6;
            this.txtAdres.Tag = "001";
            // 
            // txtFax
            // 
            this.txtFax.BackColor = System.Drawing.Color.White;
            this.txtFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFax.ForeColor = System.Drawing.Color.Black;
            this.txtFax.Location = new System.Drawing.Point(63, 92);
            this.txtFax.Mask = "(999) 000-0000";
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(100, 21);
            this.txtFax.TabIndex = 5;
            this.txtFax.Tag = "001";
            // 
            // txtGsm
            // 
            this.txtGsm.BackColor = System.Drawing.Color.White;
            this.txtGsm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGsm.ForeColor = System.Drawing.Color.Black;
            this.txtGsm.Location = new System.Drawing.Point(63, 73);
            this.txtGsm.Mask = "(999) 000-0000";
            this.txtGsm.Name = "txtGsm";
            this.txtGsm.Size = new System.Drawing.Size(100, 21);
            this.txtGsm.TabIndex = 4;
            this.txtGsm.Tag = "001";
            // 
            // txtTel
            // 
            this.txtTel.BackColor = System.Drawing.Color.White;
            this.txtTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTel.ForeColor = System.Drawing.Color.Black;
            this.txtTel.Location = new System.Drawing.Point(63, 53);
            this.txtTel.Mask = "(999) 000-0000";
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(100, 21);
            this.txtTel.TabIndex = 3;
            this.txtTel.Tag = "001";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(63, 33);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(227, 21);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Tag = "001";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(7, 117);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(34, 13);
            this.label39.TabIndex = 62;
            this.label39.Text = "Bölge";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 95);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(24, 13);
            this.label22.TabIndex = 59;
            this.label22.Text = "Fax";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 75);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(28, 13);
            this.label21.TabIndex = 58;
            this.label21.Text = "Gsm";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 56);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(22, 13);
            this.label20.TabIndex = 57;
            this.label20.Text = "Tel";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 37);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(36, 13);
            this.label19.TabIndex = 56;
            this.label19.Text = "E-Mail";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 13);
            this.label18.TabIndex = 55;
            this.label18.Text = "Şube Adı";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(7, 138);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(34, 13);
            this.label25.TabIndex = 61;
            this.label25.Text = "Adres";
            // 
            // txtVergiDairesi
            // 
            this.txtVergiDairesi.BackColor = System.Drawing.Color.White;
            this.txtVergiDairesi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtVergiDairesi.ForeColor = System.Drawing.Color.Black;
            this.txtVergiDairesi.Location = new System.Drawing.Point(63, 179);
            this.txtVergiDairesi.Name = "txtVergiDairesi";
            this.txtVergiDairesi.Size = new System.Drawing.Size(229, 21);
            this.txtVergiDairesi.TabIndex = 7;
            this.txtVergiDairesi.Tag = "001";
            // 
            // txtVergiNo
            // 
            this.txtVergiNo.BackColor = System.Drawing.Color.White;
            this.txtVergiNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtVergiNo.ForeColor = System.Drawing.Color.Black;
            this.txtVergiNo.Location = new System.Drawing.Point(63, 199);
            this.txtVergiNo.Name = "txtVergiNo";
            this.txtVergiNo.Size = new System.Drawing.Size(229, 21);
            this.txtVergiNo.TabIndex = 8;
            this.txtVergiNo.Tag = "001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Vergi No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "V.Daire";
            // 
            // txtAltBilgiNotu
            // 
            this.txtAltBilgiNotu.BackColor = System.Drawing.Color.White;
            this.txtAltBilgiNotu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAltBilgiNotu.ForeColor = System.Drawing.Color.Black;
            this.txtAltBilgiNotu.Location = new System.Drawing.Point(76, 240);
            this.txtAltBilgiNotu.Name = "txtAltBilgiNotu";
            this.txtAltBilgiNotu.Size = new System.Drawing.Size(216, 21);
            this.txtAltBilgiNotu.TabIndex = 9;
            this.txtAltBilgiNotu.Tag = "001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = "Alt Bilgi Notu";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDegistir);
            this.groupBox1.Controls.Add(this.btnİptal);
            this.groupBox1.Controls.Add(this.btnSil);
            this.groupBox1.Controls.Add(this.btnKaydet);
            this.groupBox1.Controls.Add(this.btnEkle);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 287);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 38);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // btnDegistir
            // 
            this.btnDegistir.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDegistir.Image = global::Elmar_Ticari_Plus.Properties.Resources.Pencil_icon;
            this.btnDegistir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDegistir.Location = new System.Drawing.Point(189, 3);
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
            this.btnİptal.Location = new System.Drawing.Point(372, 3);
            this.btnİptal.Name = "btnİptal";
            this.btnİptal.Size = new System.Drawing.Size(77, 32);
            this.btnİptal.TabIndex = 12;
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
            this.btnSil.Location = new System.Drawing.Point(125, 3);
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
            this.btnKaydet.Location = new System.Drawing.Point(283, 3);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(90, 32);
            this.btnKaydet.TabIndex = 11;
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
            this.btnEkle.Location = new System.Drawing.Point(51, 3);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 32);
            this.btnEkle.TabIndex = 50;
            this.btnEkle.Text = "Ekle[F2]";
            this.btnEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // txtEklenmeTarihi
            // 
            this.txtEklenmeTarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEklenmeTarihi.Location = new System.Drawing.Point(63, 220);
            this.txtEklenmeTarihi.Name = "txtEklenmeTarihi";
            this.txtEklenmeTarihi.ReadOnly = true;
            this.txtEklenmeTarihi.Size = new System.Drawing.Size(100, 21);
            this.txtEklenmeTarihi.TabIndex = 72;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Kayıt Tarihi";
            // 
            // pnlBilgileri
            // 
            this.pnlBilgileri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBilgileri.Controls.Add(this.label18);
            this.pnlBilgileri.Controls.Add(this.label25);
            this.pnlBilgileri.Controls.Add(this.label19);
            this.pnlBilgileri.Controls.Add(this.txtEklenmeTarihi);
            this.pnlBilgileri.Controls.Add(this.label20);
            this.pnlBilgileri.Controls.Add(this.label4);
            this.pnlBilgileri.Controls.Add(this.label21);
            this.pnlBilgileri.Controls.Add(this.label22);
            this.pnlBilgileri.Controls.Add(this.txtAltBilgiNotu);
            this.pnlBilgileri.Controls.Add(this.label39);
            this.pnlBilgileri.Controls.Add(this.label3);
            this.pnlBilgileri.Controls.Add(this.txtEmail);
            this.pnlBilgileri.Controls.Add(this.txtVergiDairesi);
            this.pnlBilgileri.Controls.Add(this.txtTel);
            this.pnlBilgileri.Controls.Add(this.txtVergiNo);
            this.pnlBilgileri.Controls.Add(this.txtGsm);
            this.pnlBilgileri.Controls.Add(this.label1);
            this.pnlBilgileri.Controls.Add(this.txtFax);
            this.pnlBilgileri.Controls.Add(this.label2);
            this.pnlBilgileri.Controls.Add(this.txtAdres);
            this.pnlBilgileri.Controls.Add(this.txtBolge);
            this.pnlBilgileri.Controls.Add(this.txtSubeAdi);
            this.pnlBilgileri.Controls.Add(this.txtBolgeSec);
            this.pnlBilgileri.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBilgileri.Enabled = false;
            this.pnlBilgileri.Location = new System.Drawing.Point(203, 0);
            this.pnlBilgileri.Name = "pnlBilgileri";
            this.pnlBilgileri.Size = new System.Drawing.Size(299, 287);
            this.pnlBilgileri.TabIndex = 76;
            // 
            // frmFirmaSubeBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(502, 325);
            this.Controls.Add(this.dgSubeler);
            this.Controls.Add(this.pnlBilgileri);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFirmaSubeBilgileri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Şube Bilgileri |  Ekle, Düzenle, Sil";
            this.Load += new System.EventHandler(this.frmFirmaSubeBilgileri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSubeler)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.pnlBilgileri.ResumeLayout(false);
            this.pnlBilgileri.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSubeler;
        public System.Windows.Forms.TextBox txtBolge;
        private System.Windows.Forms.Button txtBolgeSec;
        private System.Windows.Forms.TextBox txtSubeAdi;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.MaskedTextBox txtFax;
        private System.Windows.Forms.MaskedTextBox txtGsm;
        private System.Windows.Forms.MaskedTextBox txtTel;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtVergiDairesi;
        private System.Windows.Forms.TextBox txtVergiNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAltBilgiNotu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDegistir;
        private System.Windows.Forms.Button btnİptal;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.TextBox txtEklenmeTarihi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlBilgileri;
        private System.Windows.Forms.DataGridViewTextBoxColumn subeid;
        private System.Windows.Forms.DataGridViewTextBoxColumn subeAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn bolgeid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bolgeAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn adres;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn gsm;
        private System.Windows.Forms.DataGridViewTextBoxColumn fax;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn vergiDaire;
        private System.Windows.Forms.DataGridViewTextBoxColumn vergiNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn altBilgiNotu;
        private System.Windows.Forms.DataGridViewTextBoxColumn eklenmeTarihi;
    }
}