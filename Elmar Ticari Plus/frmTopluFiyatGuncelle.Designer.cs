namespace Elmar_Ticari_Plus
{
    partial class frmTopluFiyatGuncelle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCariadi = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtTarih2 = new System.Windows.Forms.DateTimePicker();
            this.dtTarih1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.grpOdemeTipi = new System.Windows.Forms.GroupBox();
            this.chkKrediKarti = new System.Windows.Forms.CheckBox();
            this.chkSenet = new System.Windows.Forms.CheckBox();
            this.chkPesin = new System.Windows.Forms.CheckBox();
            this.chkCek = new System.Windows.Forms.CheckBox();
            this.chkAcikHesap = new System.Windows.Forms.CheckBox();
            this.chkTaksit = new System.Windows.Forms.CheckBox();
            this.dgFiyat = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFiyatlariGuncelle = new System.Windows.Forms.Button();
            this.stokid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urunAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birimFiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpOdemeTipi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiyat)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 42);
            this.panel1.TabIndex = 79;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(52, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Toplu Fiş Fiyat Güncelle";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::Elmar_Ticari_Plus.Properties.Resources.Tag_2_icon;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Cari Seçimi";
            // 
            // cmbCariadi
            // 
            this.cmbCariadi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCariadi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCariadi.BackColor = System.Drawing.Color.White;
            this.cmbCariadi.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCariadi.ForeColor = System.Drawing.Color.Black;
            this.cmbCariadi.FormattingEnabled = true;
            this.cmbCariadi.Location = new System.Drawing.Point(106, 50);
            this.cmbCariadi.Name = "cmbCariadi";
            this.cmbCariadi.Size = new System.Drawing.Size(199, 22);
            this.cmbCariadi.TabIndex = 76;
            this.cmbCariadi.Tag = "001";
            this.cmbCariadi.SelectedIndexChanged += new System.EventHandler(this.cmbCariadi_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(197, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 16);
            this.label10.TabIndex = 27;
            this.label10.Text = "-";
            // 
            // dtTarih2
            // 
            this.dtTarih2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtTarih2.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtTarih2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTarih2.Location = new System.Drawing.Point(212, 102);
            this.dtTarih2.Name = "dtTarih2";
            this.dtTarih2.Size = new System.Drawing.Size(93, 20);
            this.dtTarih2.TabIndex = 5;
            this.dtTarih2.Tag = "001";
            // 
            // dtTarih1
            // 
            this.dtTarih1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtTarih1.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtTarih1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTarih1.Location = new System.Drawing.Point(106, 102);
            this.dtTarih1.Name = "dtTarih1";
            this.dtTarih1.Size = new System.Drawing.Size(91, 20);
            this.dtTarih1.TabIndex = 4;
            this.dtTarih1.Tag = "001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 13);
            this.label1.TabIndex = 77;
            this.label1.Text = "________________________________________________________________";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(17, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 80;
            this.label3.Text = "Tarih";
            // 
            // btnSorgula
            // 
            this.btnSorgula.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSorgula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSorgula.Location = new System.Drawing.Point(210, 128);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(95, 29);
            this.btnSorgula.TabIndex = 83;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = false;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // grpOdemeTipi
            // 
            this.grpOdemeTipi.Controls.Add(this.chkKrediKarti);
            this.grpOdemeTipi.Controls.Add(this.chkSenet);
            this.grpOdemeTipi.Controls.Add(this.chkPesin);
            this.grpOdemeTipi.Controls.Add(this.chkCek);
            this.grpOdemeTipi.Controls.Add(this.chkAcikHesap);
            this.grpOdemeTipi.Controls.Add(this.chkTaksit);
            this.grpOdemeTipi.Location = new System.Drawing.Point(12, 219);
            this.grpOdemeTipi.Name = "grpOdemeTipi";
            this.grpOdemeTipi.Size = new System.Drawing.Size(293, 57);
            this.grpOdemeTipi.TabIndex = 84;
            this.grpOdemeTipi.TabStop = false;
            this.grpOdemeTipi.Text = "Ödeme Tipi";
            this.grpOdemeTipi.Visible = false;
            // 
            // chkKrediKarti
            // 
            this.chkKrediKarti.AutoSize = true;
            this.chkKrediKarti.Checked = true;
            this.chkKrediKarti.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKrediKarti.Location = new System.Drawing.Point(199, 19);
            this.chkKrediKarti.Name = "chkKrediKarti";
            this.chkKrediKarti.Size = new System.Drawing.Size(74, 17);
            this.chkKrediKarti.TabIndex = 3;
            this.chkKrediKarti.Text = "Kredi Kartı";
            this.chkKrediKarti.UseVisualStyleBackColor = true;
            // 
            // chkSenet
            // 
            this.chkSenet.AutoSize = true;
            this.chkSenet.Checked = true;
            this.chkSenet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSenet.Location = new System.Drawing.Point(120, 36);
            this.chkSenet.Name = "chkSenet";
            this.chkSenet.Size = new System.Drawing.Size(54, 17);
            this.chkSenet.TabIndex = 7;
            this.chkSenet.Text = "Senet";
            this.chkSenet.UseVisualStyleBackColor = true;
            // 
            // chkPesin
            // 
            this.chkPesin.AutoSize = true;
            this.chkPesin.Checked = true;
            this.chkPesin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPesin.Location = new System.Drawing.Point(6, 17);
            this.chkPesin.Name = "chkPesin";
            this.chkPesin.Size = new System.Drawing.Size(52, 17);
            this.chkPesin.TabIndex = 2;
            this.chkPesin.Text = "Peşin";
            this.chkPesin.UseVisualStyleBackColor = true;
            // 
            // chkCek
            // 
            this.chkCek.AutoSize = true;
            this.chkCek.Checked = true;
            this.chkCek.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCek.Location = new System.Drawing.Point(199, 36);
            this.chkCek.Name = "chkCek";
            this.chkCek.Size = new System.Drawing.Size(45, 17);
            this.chkCek.TabIndex = 6;
            this.chkCek.Text = "Çek";
            this.chkCek.UseVisualStyleBackColor = true;
            // 
            // chkAcikHesap
            // 
            this.chkAcikHesap.AutoSize = true;
            this.chkAcikHesap.Checked = true;
            this.chkAcikHesap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAcikHesap.Location = new System.Drawing.Point(6, 36);
            this.chkAcikHesap.Name = "chkAcikHesap";
            this.chkAcikHesap.Size = new System.Drawing.Size(81, 17);
            this.chkAcikHesap.TabIndex = 4;
            this.chkAcikHesap.Text = "Açık Hesap";
            this.chkAcikHesap.UseVisualStyleBackColor = true;
            // 
            // chkTaksit
            // 
            this.chkTaksit.AutoSize = true;
            this.chkTaksit.Checked = true;
            this.chkTaksit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTaksit.Location = new System.Drawing.Point(120, 18);
            this.chkTaksit.Name = "chkTaksit";
            this.chkTaksit.Size = new System.Drawing.Size(55, 17);
            this.chkTaksit.TabIndex = 5;
            this.chkTaksit.Text = "Taksit";
            this.chkTaksit.UseVisualStyleBackColor = true;
            // 
            // dgFiyat
            // 
            this.dgFiyat.AllowUserToAddRows = false;
            this.dgFiyat.AllowUserToDeleteRows = false;
            this.dgFiyat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgFiyat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFiyat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stokid,
            this.urunAdi,
            this.birimFiyat});
            this.dgFiyat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgFiyat.Location = new System.Drawing.Point(0, 163);
            this.dgFiyat.Name = "dgFiyat";
            this.dgFiyat.RowHeadersWidth = 20;
            this.dgFiyat.Size = new System.Drawing.Size(310, 344);
            this.dgFiyat.TabIndex = 85;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnFiyatlariGuncelle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 507);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 32);
            this.panel2.TabIndex = 86;
            // 
            // btnFiyatlariGuncelle
            // 
            this.btnFiyatlariGuncelle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnFiyatlariGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFiyatlariGuncelle.Location = new System.Drawing.Point(84, 0);
            this.btnFiyatlariGuncelle.Name = "btnFiyatlariGuncelle";
            this.btnFiyatlariGuncelle.Size = new System.Drawing.Size(138, 29);
            this.btnFiyatlariGuncelle.TabIndex = 84;
            this.btnFiyatlariGuncelle.Text = "Fiyatları Güncelle";
            this.btnFiyatlariGuncelle.UseVisualStyleBackColor = false;
            this.btnFiyatlariGuncelle.Click += new System.EventHandler(this.btnFiyatlariGuncelle_Click);
            // 
            // stokid
            // 
            this.stokid.HeaderText = "stokid";
            this.stokid.Name = "stokid";
            this.stokid.Visible = false;
            // 
            // urunAdi
            // 
            this.urunAdi.HeaderText = "Ürün Adı";
            this.urunAdi.Name = "urunAdi";
            // 
            // birimFiyat
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.birimFiyat.DefaultCellStyle = dataGridViewCellStyle1;
            this.birimFiyat.HeaderText = "Birim Fiyat";
            this.birimFiyat.Name = "birimFiyat";
            // 
            // frmTopluFiyatGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 539);
            this.Controls.Add(this.dgFiyat);
            this.Controls.Add(this.grpOdemeTipi);
            this.Controls.Add(this.btnSorgula);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtTarih2);
            this.Controls.Add(this.dtTarih1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCariadi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Name = "frmTopluFiyatGuncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Toplu Fiş Fiyat Güncelle";
            this.Load += new System.EventHandler(this.frmTopluFiyatGuncelle_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpOdemeTipi.ResumeLayout(false);
            this.grpOdemeTipi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiyat)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCariadi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtTarih2;
        private System.Windows.Forms.DateTimePicker dtTarih1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.GroupBox grpOdemeTipi;
        private System.Windows.Forms.CheckBox chkKrediKarti;
        private System.Windows.Forms.CheckBox chkSenet;
        private System.Windows.Forms.CheckBox chkPesin;
        private System.Windows.Forms.CheckBox chkCek;
        private System.Windows.Forms.CheckBox chkAcikHesap;
        private System.Windows.Forms.CheckBox chkTaksit;
        private System.Windows.Forms.DataGridView dgFiyat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFiyatlariGuncelle;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokid;
        private System.Windows.Forms.DataGridViewTextBoxColumn urunAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn birimFiyat;
    }
}