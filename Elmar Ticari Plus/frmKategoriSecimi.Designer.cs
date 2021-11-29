namespace Elmar_Ticari_Plus
{
    partial class frmKategoriSecimi
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
            this.components = new System.ComponentModel.Container();
            this.txtKategori = new System.Windows.Forms.TextBox();
            this.btnAktar = new System.Windows.Forms.Button();
            this.tv1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yeniAnaKategoriEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altKategoriEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kategoriyiGüncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kategoriyiSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpKategoriEkle = new System.Windows.Forms.GroupBox();
            this.chkWebdeGosterilsinmi1 = new System.Windows.Forms.CheckBox();
            this.btnKapat1 = new System.Windows.Forms.Button();
            this.txtUstKategoriAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEklenecekKategoriAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKategoriEkle = new System.Windows.Forms.Button();
            this.grpKategoriDuzenle = new System.Windows.Forms.GroupBox();
            this.cmbUstKategoriAdi = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkWebdeGosterilsinmi2 = new System.Windows.Forms.CheckBox();
            this.btnKapat2 = new System.Windows.Forms.Button();
            this.txtGuncelKategoriAdi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnKategoriGuncelle = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSeciliKategoriyiSil = new System.Windows.Forms.Button();
            this.btnSeciliKategoriyiGuncelle = new System.Windows.Forms.Button();
            this.btnYeniAltKategoriEkle = new System.Windows.Forms.Button();
            this.btnYeniAnaKategoriEkle = new System.Windows.Forms.Button();
            this.chbVitrin = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpKategoriEkle.SuspendLayout();
            this.grpKategoriDuzenle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtKategori
            // 
            this.txtKategori.BackColor = System.Drawing.Color.White;
            this.txtKategori.Enabled = false;
            this.txtKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKategori.ForeColor = System.Drawing.Color.Black;
            this.txtKategori.Location = new System.Drawing.Point(85, 10);
            this.txtKategori.MaxLength = 249;
            this.txtKategori.Name = "txtKategori";
            this.txtKategori.ReadOnly = true;
            this.txtKategori.Size = new System.Drawing.Size(381, 21);
            this.txtKategori.TabIndex = 17;
            this.txtKategori.Tag = "001";
            // 
            // btnAktar
            // 
            this.btnAktar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAktar.Location = new System.Drawing.Point(468, 9);
            this.btnAktar.Name = "btnAktar";
            this.btnAktar.Size = new System.Drawing.Size(80, 23);
            this.btnAktar.TabIndex = 19;
            this.btnAktar.Text = ">>Aktar>>";
            this.btnAktar.UseVisualStyleBackColor = false;
            this.btnAktar.Click += new System.EventHandler(this.btnAktar_Click);
            // 
            // tv1
            // 
            this.tv1.ContextMenuStrip = this.contextMenuStrip1;
            this.tv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv1.Location = new System.Drawing.Point(0, 37);
            this.tv1.Name = "tv1";
            this.tv1.Size = new System.Drawing.Size(550, 486);
            this.tv1.TabIndex = 44;
            this.tv1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv1_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniAnaKategoriEkleToolStripMenuItem,
            this.altKategoriEkleToolStripMenuItem,
            this.kategoriyiGüncelleToolStripMenuItem,
            this.kategoriyiSilToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 92);
            // 
            // yeniAnaKategoriEkleToolStripMenuItem
            // 
            this.yeniAnaKategoriEkleToolStripMenuItem.Name = "yeniAnaKategoriEkleToolStripMenuItem";
            this.yeniAnaKategoriEkleToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.yeniAnaKategoriEkleToolStripMenuItem.Text = "Yeni Ana Kategori Ekle";
            this.yeniAnaKategoriEkleToolStripMenuItem.Click += new System.EventHandler(this.yeniAnaKategoriEkleToolStripMenuItem_Click);
            // 
            // altKategoriEkleToolStripMenuItem
            // 
            this.altKategoriEkleToolStripMenuItem.Name = "altKategoriEkleToolStripMenuItem";
            this.altKategoriEkleToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.altKategoriEkleToolStripMenuItem.Text = "Alt Kategori Ekle";
            this.altKategoriEkleToolStripMenuItem.Click += new System.EventHandler(this.altKategoriEkleToolStripMenuItem_Click);
            // 
            // kategoriyiGüncelleToolStripMenuItem
            // 
            this.kategoriyiGüncelleToolStripMenuItem.Name = "kategoriyiGüncelleToolStripMenuItem";
            this.kategoriyiGüncelleToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.kategoriyiGüncelleToolStripMenuItem.Text = "Kategoriyi Güncelle";
            this.kategoriyiGüncelleToolStripMenuItem.Click += new System.EventHandler(this.kategoriyiGüncelleToolStripMenuItem_Click);
            // 
            // kategoriyiSilToolStripMenuItem
            // 
            this.kategoriyiSilToolStripMenuItem.Name = "kategoriyiSilToolStripMenuItem";
            this.kategoriyiSilToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.kategoriyiSilToolStripMenuItem.Text = "Kategoriyi Sil";
            this.kategoriyiSilToolStripMenuItem.Click += new System.EventHandler(this.kategoriyiSilToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.btnAktar);
            this.groupBox1.Controls.Add(this.txtKategori);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 37);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Brown;
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Kategori Adı";
            // 
            // grpKategoriEkle
            // 
            this.grpKategoriEkle.BackColor = System.Drawing.Color.Gainsboro;
            this.grpKategoriEkle.Controls.Add(this.checkBox1);
            this.grpKategoriEkle.Controls.Add(this.chkWebdeGosterilsinmi1);
            this.grpKategoriEkle.Controls.Add(this.btnKapat1);
            this.grpKategoriEkle.Controls.Add(this.txtUstKategoriAdi);
            this.grpKategoriEkle.Controls.Add(this.label2);
            this.grpKategoriEkle.Controls.Add(this.txtEklenecekKategoriAdi);
            this.grpKategoriEkle.Controls.Add(this.label1);
            this.grpKategoriEkle.Controls.Add(this.btnKategoriEkle);
            this.grpKategoriEkle.Location = new System.Drawing.Point(174, 122);
            this.grpKategoriEkle.Name = "grpKategoriEkle";
            this.grpKategoriEkle.Size = new System.Drawing.Size(206, 173);
            this.grpKategoriEkle.TabIndex = 45;
            this.grpKategoriEkle.TabStop = false;
            this.grpKategoriEkle.Text = "Yeni Kategori Ekle";
            this.grpKategoriEkle.Visible = false;
            // 
            // chkWebdeGosterilsinmi1
            // 
            this.chkWebdeGosterilsinmi1.AutoSize = true;
            this.chkWebdeGosterilsinmi1.Location = new System.Drawing.Point(7, 139);
            this.chkWebdeGosterilsinmi1.Name = "chkWebdeGosterilsinmi1";
            this.chkWebdeGosterilsinmi1.Size = new System.Drawing.Size(112, 17);
            this.chkWebdeGosterilsinmi1.TabIndex = 26;
            this.chkWebdeGosterilsinmi1.Text = "Webde Gösterilsin";
            this.chkWebdeGosterilsinmi1.UseVisualStyleBackColor = true;
            // 
            // btnKapat1
            // 
            this.btnKapat1.Location = new System.Drawing.Point(186, 0);
            this.btnKapat1.Name = "btnKapat1";
            this.btnKapat1.Size = new System.Drawing.Size(20, 23);
            this.btnKapat1.TabIndex = 23;
            this.btnKapat1.Text = "X";
            this.btnKapat1.UseVisualStyleBackColor = false;
            this.btnKapat1.Click += new System.EventHandler(this.btnKapat1_Click);
            // 
            // txtUstKategoriAdi
            // 
            this.txtUstKategoriAdi.BackColor = System.Drawing.Color.White;
            this.txtUstKategoriAdi.Enabled = false;
            this.txtUstKategoriAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUstKategoriAdi.ForeColor = System.Drawing.Color.Black;
            this.txtUstKategoriAdi.Location = new System.Drawing.Point(6, 54);
            this.txtUstKategoriAdi.MaxLength = 249;
            this.txtUstKategoriAdi.Name = "txtUstKategoriAdi";
            this.txtUstKategoriAdi.ReadOnly = true;
            this.txtUstKategoriAdi.Size = new System.Drawing.Size(196, 21);
            this.txtUstKategoriAdi.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Üst Kategori Adı";
            // 
            // txtEklenecekKategoriAdi
            // 
            this.txtEklenecekKategoriAdi.BackColor = System.Drawing.Color.White;
            this.txtEklenecekKategoriAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEklenecekKategoriAdi.ForeColor = System.Drawing.Color.Black;
            this.txtEklenecekKategoriAdi.Location = new System.Drawing.Point(6, 111);
            this.txtEklenecekKategoriAdi.MaxLength = 249;
            this.txtEklenecekKategoriAdi.Name = "txtEklenecekKategoriAdi";
            this.txtEklenecekKategoriAdi.Size = new System.Drawing.Size(196, 21);
            this.txtEklenecekKategoriAdi.TabIndex = 19;
            this.txtEklenecekKategoriAdi.Tag = "001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(6, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Eklenecek Kategori Adı";
            // 
            // btnKategoriEkle
            // 
            this.btnKategoriEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKategoriEkle.Location = new System.Drawing.Point(126, 136);
            this.btnKategoriEkle.Name = "btnKategoriEkle";
            this.btnKategoriEkle.Size = new System.Drawing.Size(75, 23);
            this.btnKategoriEkle.TabIndex = 0;
            this.btnKategoriEkle.Text = "Kaydet";
            this.btnKategoriEkle.UseVisualStyleBackColor = false;
            this.btnKategoriEkle.Click += new System.EventHandler(this.btnKategoriEkle_Click);
            // 
            // grpKategoriDuzenle
            // 
            this.grpKategoriDuzenle.BackColor = System.Drawing.Color.Gainsboro;
            this.grpKategoriDuzenle.Controls.Add(this.chbVitrin);
            this.grpKategoriDuzenle.Controls.Add(this.cmbUstKategoriAdi);
            this.grpKategoriDuzenle.Controls.Add(this.label4);
            this.grpKategoriDuzenle.Controls.Add(this.chkWebdeGosterilsinmi2);
            this.grpKategoriDuzenle.Controls.Add(this.btnKapat2);
            this.grpKategoriDuzenle.Controls.Add(this.txtGuncelKategoriAdi);
            this.grpKategoriDuzenle.Controls.Add(this.label5);
            this.grpKategoriDuzenle.Controls.Add(this.btnKategoriGuncelle);
            this.grpKategoriDuzenle.Location = new System.Drawing.Point(174, 123);
            this.grpKategoriDuzenle.Name = "grpKategoriDuzenle";
            this.grpKategoriDuzenle.Size = new System.Drawing.Size(206, 171);
            this.grpKategoriDuzenle.TabIndex = 46;
            this.grpKategoriDuzenle.TabStop = false;
            this.grpKategoriDuzenle.Text = "Kategori Düzenle";
            this.grpKategoriDuzenle.Visible = false;
            // 
            // cmbUstKategoriAdi
            // 
            this.cmbUstKategoriAdi.BackColor = System.Drawing.Color.White;
            this.cmbUstKategoriAdi.ForeColor = System.Drawing.Color.Black;
            this.cmbUstKategoriAdi.FormattingEnabled = true;
            this.cmbUstKategoriAdi.Location = new System.Drawing.Point(7, 48);
            this.cmbUstKategoriAdi.Name = "cmbUstKategoriAdi";
            this.cmbUstKategoriAdi.Size = new System.Drawing.Size(196, 21);
            this.cmbUstKategoriAdi.TabIndex = 27;
            this.cmbUstKategoriAdi.Tag = "001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Brown;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "Üst Kategori Adı";
            // 
            // chkWebdeGosterilsinmi2
            // 
            this.chkWebdeGosterilsinmi2.AutoSize = true;
            this.chkWebdeGosterilsinmi2.Location = new System.Drawing.Point(6, 130);
            this.chkWebdeGosterilsinmi2.Name = "chkWebdeGosterilsinmi2";
            this.chkWebdeGosterilsinmi2.Size = new System.Drawing.Size(112, 17);
            this.chkWebdeGosterilsinmi2.TabIndex = 25;
            this.chkWebdeGosterilsinmi2.Text = "Webde Gösterilsin";
            this.chkWebdeGosterilsinmi2.UseVisualStyleBackColor = true;
            // 
            // btnKapat2
            // 
            this.btnKapat2.Location = new System.Drawing.Point(186, 0);
            this.btnKapat2.Name = "btnKapat2";
            this.btnKapat2.Size = new System.Drawing.Size(20, 23);
            this.btnKapat2.TabIndex = 24;
            this.btnKapat2.Text = "X";
            this.btnKapat2.UseVisualStyleBackColor = false;
            this.btnKapat2.Click += new System.EventHandler(this.btnKapat2_Click);
            // 
            // txtGuncelKategoriAdi
            // 
            this.txtGuncelKategoriAdi.BackColor = System.Drawing.Color.White;
            this.txtGuncelKategoriAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelKategoriAdi.ForeColor = System.Drawing.Color.Black;
            this.txtGuncelKategoriAdi.Location = new System.Drawing.Point(6, 101);
            this.txtGuncelKategoriAdi.MaxLength = 249;
            this.txtGuncelKategoriAdi.Name = "txtGuncelKategoriAdi";
            this.txtGuncelKategoriAdi.Size = new System.Drawing.Size(196, 21);
            this.txtGuncelKategoriAdi.TabIndex = 19;
            this.txtGuncelKategoriAdi.Tag = "001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Brown;
            this.label5.Location = new System.Drawing.Point(6, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "Güncel Kategori Adı";
            // 
            // btnKategoriGuncelle
            // 
            this.btnKategoriGuncelle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKategoriGuncelle.Location = new System.Drawing.Point(128, 128);
            this.btnKategoriGuncelle.Name = "btnKategoriGuncelle";
            this.btnKategoriGuncelle.Size = new System.Drawing.Size(75, 23);
            this.btnKategoriGuncelle.TabIndex = 0;
            this.btnKategoriGuncelle.Text = "Kaydet";
            this.btnKategoriGuncelle.UseVisualStyleBackColor = false;
            this.btnKategoriGuncelle.Click += new System.EventHandler(this.btnKategoriGuncelle_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSeciliKategoriyiSil);
            this.panel1.Controls.Add(this.btnSeciliKategoriyiGuncelle);
            this.panel1.Controls.Add(this.btnYeniAltKategoriEkle);
            this.panel1.Controls.Add(this.btnYeniAnaKategoriEkle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 523);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 32);
            this.panel1.TabIndex = 47;
            // 
            // btnSeciliKategoriyiSil
            // 
            this.btnSeciliKategoriyiSil.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSeciliKategoriyiSil.Location = new System.Drawing.Point(421, 3);
            this.btnSeciliKategoriyiSil.Name = "btnSeciliKategoriyiSil";
            this.btnSeciliKategoriyiSil.Size = new System.Drawing.Size(123, 23);
            this.btnSeciliKategoriyiSil.TabIndex = 4;
            this.btnSeciliKategoriyiSil.Text = "Seçili Kategoriyi Sil";
            this.btnSeciliKategoriyiSil.UseVisualStyleBackColor = false;
            this.btnSeciliKategoriyiSil.Click += new System.EventHandler(this.kategoriyiSilToolStripMenuItem_Click);
            // 
            // btnSeciliKategoriyiGuncelle
            // 
            this.btnSeciliKategoriyiGuncelle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSeciliKategoriyiGuncelle.Location = new System.Drawing.Point(279, 3);
            this.btnSeciliKategoriyiGuncelle.Name = "btnSeciliKategoriyiGuncelle";
            this.btnSeciliKategoriyiGuncelle.Size = new System.Drawing.Size(136, 23);
            this.btnSeciliKategoriyiGuncelle.TabIndex = 3;
            this.btnSeciliKategoriyiGuncelle.Text = "Seçili Kategoriyi Güncelle";
            this.btnSeciliKategoriyiGuncelle.UseVisualStyleBackColor = false;
            this.btnSeciliKategoriyiGuncelle.Click += new System.EventHandler(this.kategoriyiGüncelleToolStripMenuItem_Click);
            // 
            // btnYeniAltKategoriEkle
            // 
            this.btnYeniAltKategoriEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnYeniAltKategoriEkle.Location = new System.Drawing.Point(145, 3);
            this.btnYeniAltKategoriEkle.Name = "btnYeniAltKategoriEkle";
            this.btnYeniAltKategoriEkle.Size = new System.Drawing.Size(128, 23);
            this.btnYeniAltKategoriEkle.TabIndex = 2;
            this.btnYeniAltKategoriEkle.Text = "Yeni Alt Kategori Ekle";
            this.btnYeniAltKategoriEkle.UseVisualStyleBackColor = false;
            this.btnYeniAltKategoriEkle.Click += new System.EventHandler(this.altKategoriEkleToolStripMenuItem_Click);
            // 
            // btnYeniAnaKategoriEkle
            // 
            this.btnYeniAnaKategoriEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnYeniAnaKategoriEkle.Location = new System.Drawing.Point(3, 3);
            this.btnYeniAnaKategoriEkle.Name = "btnYeniAnaKategoriEkle";
            this.btnYeniAnaKategoriEkle.Size = new System.Drawing.Size(136, 23);
            this.btnYeniAnaKategoriEkle.TabIndex = 1;
            this.btnYeniAnaKategoriEkle.Text = "Yeni Ana Kategori Ekle";
            this.btnYeniAnaKategoriEkle.UseVisualStyleBackColor = false;
            this.btnYeniAnaKategoriEkle.Click += new System.EventHandler(this.yeniAnaKategoriEkleToolStripMenuItem_Click);
            // 
            // chbVitrin
            // 
            this.chbVitrin.AutoSize = true;
            this.chbVitrin.Location = new System.Drawing.Point(6, 147);
            this.chbVitrin.Name = "chbVitrin";
            this.chbVitrin.Size = new System.Drawing.Size(112, 17);
            this.chbVitrin.TabIndex = 28;
            this.chbVitrin.Text = "Vitrinde Gösterilsin";
            this.chbVitrin.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 154);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 17);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "Vitrinde Gösterilsin";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // frmKategoriSecimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 555);
            this.Controls.Add(this.grpKategoriDuzenle);
            this.Controls.Add(this.grpKategoriEkle);
            this.Controls.Add(this.tv1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(566, 594);
            this.MinimumSize = new System.Drawing.Size(566, 594);
            this.Name = "frmKategoriSecimi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Kategori Seçimi";
            this.Load += new System.EventHandler(this.frmKategoriSecimi_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpKategoriEkle.ResumeLayout(false);
            this.grpKategoriEkle.PerformLayout();
            this.grpKategoriDuzenle.ResumeLayout(false);
            this.grpKategoriDuzenle.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtKategori;
        private System.Windows.Forms.Button btnAktar;
        private System.Windows.Forms.TreeView tv1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpKategoriEkle;
        private System.Windows.Forms.Button btnKategoriEkle;
        private System.Windows.Forms.TextBox txtUstKategoriAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEklenecekKategoriAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpKategoriDuzenle;
        private System.Windows.Forms.TextBox txtGuncelKategoriAdi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnKategoriGuncelle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yeniAnaKategoriEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altKategoriEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kategoriyiGüncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kategoriyiSilToolStripMenuItem;
        private System.Windows.Forms.Button btnKapat1;
        private System.Windows.Forms.Button btnKapat2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSeciliKategoriyiSil;
        private System.Windows.Forms.Button btnSeciliKategoriyiGuncelle;
        private System.Windows.Forms.Button btnYeniAltKategoriEkle;
        private System.Windows.Forms.Button btnYeniAnaKategoriEkle;
        private System.Windows.Forms.CheckBox chkWebdeGosterilsinmi1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkWebdeGosterilsinmi2;
        private System.Windows.Forms.ComboBox cmbUstKategoriAdi;
        private System.Windows.Forms.CheckBox chbVitrin;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}