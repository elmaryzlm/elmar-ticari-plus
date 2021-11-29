namespace Elmar_Ticari_Plus
{
    partial class frmCariEkstresi
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
            this.btnOnizleme = new System.Windows.Forms.Button();
            this.rdCarigrup = new System.Windows.Forms.RadioButton();
            this.rdCaribolge = new System.Windows.Forms.RadioButton();
            this.cmbCaribolgesi = new System.Windows.Forms.ComboBox();
            this.cmbCarigrubu = new System.Windows.Forms.ComboBox();
            this.cmbCariadi = new System.Windows.Forms.ComboBox();
            this.pnlTarih = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.dtTarih2 = new System.Windows.Forms.DateTimePicker();
            this.dtTarih1 = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.rdTariharaligi = new System.Windows.Forms.RadioButton();
            this.rdTumtarihler = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSubeler = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdArtanSiralama = new System.Windows.Forms.RadioButton();
            this.rdAzalanSiralama = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlTarih.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOnizleme
            // 
            this.btnOnizleme.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOnizleme.Image = global::Elmar_Ticari_Plus.Properties.Resources.tahsilatodeme;
            this.btnOnizleme.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOnizleme.Location = new System.Drawing.Point(83, 190);
            this.btnOnizleme.Name = "btnOnizleme";
            this.btnOnizleme.Size = new System.Drawing.Size(152, 40);
            this.btnOnizleme.TabIndex = 67;
            this.btnOnizleme.Text = "Raporu Görüntüle";
            this.btnOnizleme.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOnizleme.UseVisualStyleBackColor = false;
            this.btnOnizleme.Click += new System.EventHandler(this.btnOnizleme_Click);
            // 
            // rdCarigrup
            // 
            this.rdCarigrup.AutoSize = true;
            this.rdCarigrup.Location = new System.Drawing.Point(48, 265);
            this.rdCarigrup.Name = "rdCarigrup";
            this.rdCarigrup.Size = new System.Drawing.Size(75, 17);
            this.rdCarigrup.TabIndex = 52;
            this.rdCarigrup.Text = "Cari Grubu";
            this.rdCarigrup.UseVisualStyleBackColor = true;
            this.rdCarigrup.Visible = false;
            // 
            // rdCaribolge
            // 
            this.rdCaribolge.AutoSize = true;
            this.rdCaribolge.Location = new System.Drawing.Point(48, 229);
            this.rdCaribolge.Name = "rdCaribolge";
            this.rdCaribolge.Size = new System.Drawing.Size(80, 17);
            this.rdCaribolge.TabIndex = 51;
            this.rdCaribolge.Text = "Cari Bölgesi";
            this.rdCaribolge.UseVisualStyleBackColor = true;
            this.rdCaribolge.Visible = false;
            // 
            // cmbCaribolgesi
            // 
            this.cmbCaribolgesi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCaribolgesi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCaribolgesi.BackColor = System.Drawing.Color.White;
            this.cmbCaribolgesi.Enabled = false;
            this.cmbCaribolgesi.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCaribolgesi.ForeColor = System.Drawing.Color.Black;
            this.cmbCaribolgesi.FormattingEnabled = true;
            this.cmbCaribolgesi.Location = new System.Drawing.Point(131, 224);
            this.cmbCaribolgesi.Name = "cmbCaribolgesi";
            this.cmbCaribolgesi.Size = new System.Drawing.Size(261, 22);
            this.cmbCaribolgesi.TabIndex = 48;
            this.cmbCaribolgesi.Visible = false;
            // 
            // cmbCarigrubu
            // 
            this.cmbCarigrubu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCarigrubu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCarigrubu.BackColor = System.Drawing.Color.White;
            this.cmbCarigrubu.Enabled = false;
            this.cmbCarigrubu.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCarigrubu.ForeColor = System.Drawing.Color.Black;
            this.cmbCarigrubu.FormattingEnabled = true;
            this.cmbCarigrubu.Location = new System.Drawing.Point(131, 260);
            this.cmbCarigrubu.Name = "cmbCarigrubu";
            this.cmbCarigrubu.Size = new System.Drawing.Size(261, 22);
            this.cmbCarigrubu.TabIndex = 46;
            this.cmbCarigrubu.Visible = false;
            // 
            // cmbCariadi
            // 
            this.cmbCariadi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCariadi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCariadi.BackColor = System.Drawing.Color.White;
            this.cmbCariadi.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCariadi.ForeColor = System.Drawing.Color.Black;
            this.cmbCariadi.FormattingEnabled = true;
            this.cmbCariadi.Location = new System.Drawing.Point(103, 110);
            this.cmbCariadi.Name = "cmbCariadi";
            this.cmbCariadi.Size = new System.Drawing.Size(209, 22);
            this.cmbCariadi.TabIndex = 6;
            this.cmbCariadi.Tag = "001";
            this.cmbCariadi.SelectedIndexChanged += new System.EventHandler(this.cmbCariadi_SelectedIndexChanged);
            // 
            // pnlTarih
            // 
            this.pnlTarih.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTarih.Controls.Add(this.label10);
            this.pnlTarih.Controls.Add(this.dtTarih2);
            this.pnlTarih.Controls.Add(this.dtTarih1);
            this.pnlTarih.Location = new System.Drawing.Point(103, 67);
            this.pnlTarih.Name = "pnlTarih";
            this.pnlTarih.Size = new System.Drawing.Size(209, 33);
            this.pnlTarih.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(96, 9);
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
            this.dtTarih2.Location = new System.Drawing.Point(111, 5);
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
            this.dtTarih1.Location = new System.Drawing.Point(3, 5);
            this.dtTarih1.Name = "dtTarih1";
            this.dtTarih1.Size = new System.Drawing.Size(93, 20);
            this.dtTarih1.TabIndex = 4;
            this.dtTarih1.Tag = "001";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(9, 141);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 13);
            this.label17.TabIndex = 61;
            this.label17.Text = "Şube";
            // 
            // rdTariharaligi
            // 
            this.rdTariharaligi.AutoSize = true;
            this.rdTariharaligi.Location = new System.Drawing.Point(12, 75);
            this.rdTariharaligi.Name = "rdTariharaligi";
            this.rdTariharaligi.Size = new System.Drawing.Size(80, 17);
            this.rdTariharaligi.TabIndex = 2;
            this.rdTariharaligi.Text = "Tarih Aralığı";
            this.rdTariharaligi.UseVisualStyleBackColor = true;
            this.rdTariharaligi.CheckedChanged += new System.EventHandler(this.rdTumtarihler_CheckedChanged);
            // 
            // rdTumtarihler
            // 
            this.rdTumtarihler.AutoSize = true;
            this.rdTumtarihler.Location = new System.Drawing.Point(12, 46);
            this.rdTumtarihler.Name = "rdTumtarihler";
            this.rdTumtarihler.Size = new System.Drawing.Size(80, 17);
            this.rdTumtarihler.TabIndex = 1;
            this.rdTumtarihler.Text = "Tüm tarihler";
            this.rdTumtarihler.UseVisualStyleBackColor = true;
            this.rdTumtarihler.CheckedChanged += new System.EventHandler(this.rdTumtarihler_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(-5, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "________________________________________________________________";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(-27, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(391, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = "________________________________________________________________";
            // 
            // cmbSubeler
            // 
            this.cmbSubeler.BackColor = System.Drawing.Color.White;
            this.cmbSubeler.ForeColor = System.Drawing.Color.Black;
            this.cmbSubeler.FormattingEnabled = true;
            this.cmbSubeler.Location = new System.Drawing.Point(103, 138);
            this.cmbSubeler.Name = "cmbSubeler";
            this.cmbSubeler.Size = new System.Drawing.Size(209, 21);
            this.cmbSubeler.TabIndex = 7;
            this.cmbSubeler.Tag = "001";
            this.cmbSubeler.SelectedIndexChanged += new System.EventHandler(this.cmbSubeler_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Cari Seçimi";
            // 
            // rdArtanSiralama
            // 
            this.rdArtanSiralama.AutoSize = true;
            this.rdArtanSiralama.Checked = true;
            this.rdArtanSiralama.Location = new System.Drawing.Point(103, 165);
            this.rdArtanSiralama.Name = "rdArtanSiralama";
            this.rdArtanSiralama.Size = new System.Drawing.Size(93, 17);
            this.rdArtanSiralama.TabIndex = 8;
            this.rdArtanSiralama.TabStop = true;
            this.rdArtanSiralama.Text = "Artan Sıralama";
            this.rdArtanSiralama.UseVisualStyleBackColor = true;
            // 
            // rdAzalanSiralama
            // 
            this.rdAzalanSiralama.AutoSize = true;
            this.rdAzalanSiralama.Location = new System.Drawing.Point(202, 165);
            this.rdAzalanSiralama.Name = "rdAzalanSiralama";
            this.rdAzalanSiralama.Size = new System.Drawing.Size(100, 17);
            this.rdAzalanSiralama.TabIndex = 9;
            this.rdAzalanSiralama.Text = "Azalan Sıralama";
            this.rdAzalanSiralama.UseVisualStyleBackColor = true;
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
            this.panel1.Size = new System.Drawing.Size(316, 42);
            this.panel1.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(52, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Cari Hesap Ekstre Raporu";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::Elmar_Ticari_Plus.Properties.Resources.tahsilatodeme;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmCariEkstresi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 231);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rdAzalanSiralama);
            this.Controls.Add(this.rdArtanSiralama);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdTariharaligi);
            this.Controls.Add(this.rdTumtarihler);
            this.Controls.Add(this.btnOnizleme);
            this.Controls.Add(this.cmbCariadi);
            this.Controls.Add(this.rdCarigrup);
            this.Controls.Add(this.pnlTarih);
            this.Controls.Add(this.rdCaribolge);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmbCaribolgesi);
            this.Controls.Add(this.cmbSubeler);
            this.Controls.Add(this.cmbCarigrubu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "frmCariEkstresi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Cari Hesap Ekstresi";
            this.Load += new System.EventHandler(this.frmCariEkstresi_Load);
            this.pnlTarih.ResumeLayout(false);
            this.pnlTarih.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOnizleme;
        private System.Windows.Forms.RadioButton rdCarigrup;
        private System.Windows.Forms.RadioButton rdCaribolge;
        private System.Windows.Forms.ComboBox cmbCaribolgesi;
        private System.Windows.Forms.ComboBox cmbCarigrubu;
        private System.Windows.Forms.ComboBox cmbCariadi;
        private System.Windows.Forms.Panel pnlTarih;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtTarih2;
        private System.Windows.Forms.DateTimePicker dtTarih1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RadioButton rdTariharaligi;
        private System.Windows.Forms.RadioButton rdTumtarihler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSubeler;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdArtanSiralama;
        private System.Windows.Forms.RadioButton rdAzalanSiralama;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}