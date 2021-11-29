namespace Elmar_Ticari_Plus
{
    partial class frmOtoparkGirisCikisRaporu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgGirisCikis = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtToplamHizmetTutari = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.dt2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlaka = new System.Windows.Forms.TextBox();
            this.txtAboneAdi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdTumu = new System.Windows.Forms.RadioButton();
            this.rdGiris = new System.Windows.Forms.RadioButton();
            this.rdCikis = new System.Windows.Forms.RadioButton();
            this.label54 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label70 = new System.Windows.Forms.Label();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.btnYazdir = new System.Windows.Forms.Button();
            this.btnRaporGoruntule = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKayitSayisi = new System.Windows.Forms.TextBox();
            this.plaka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aboneAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.islemTuru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toplam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgGirisCikis)).BeginInit();
            this.panel7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel16.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgGirisCikis
            // 
            this.dgGirisCikis.AllowUserToAddRows = false;
            this.dgGirisCikis.AllowUserToDeleteRows = false;
            this.dgGirisCikis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgGirisCikis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgGirisCikis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGirisCikis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.plaka,
            this.aboneAdi,
            this.tarih,
            this.saat,
            this.islemTuru,
            this.toplam});
            this.dgGirisCikis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgGirisCikis.Location = new System.Drawing.Point(0, 0);
            this.dgGirisCikis.MultiSelect = false;
            this.dgGirisCikis.Name = "dgGirisCikis";
            this.dgGirisCikis.ReadOnly = true;
            this.dgGirisCikis.RowHeadersWidth = 10;
            this.dgGirisCikis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgGirisCikis.Size = new System.Drawing.Size(689, 357);
            this.dgGirisCikis.TabIndex = 44;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.txtKayitSayisi);
            this.panel7.Controls.Add(this.panel16);
            this.panel7.Controls.Add(this.groupBox2);
            this.panel7.Controls.Add(this.label54);
            this.panel7.Controls.Add(this.groupBox1);
            this.panel7.Controls.Add(this.txtAboneAdi);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.txtPlaka);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.label12);
            this.panel7.Controls.Add(this.txtToplamHizmetTutari);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 357);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(689, 136);
            this.panel7.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(411, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 15);
            this.label12.TabIndex = 44;
            this.label12.Text = "Toplam Kazanç";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtToplamHizmetTutari
            // 
            this.txtToplamHizmetTutari.BackColor = System.Drawing.Color.White;
            this.txtToplamHizmetTutari.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtToplamHizmetTutari.ForeColor = System.Drawing.Color.Black;
            this.txtToplamHizmetTutari.Location = new System.Drawing.Point(507, 108);
            this.txtToplamHizmetTutari.Name = "txtToplamHizmetTutari";
            this.txtToplamHizmetTutari.ReadOnly = true;
            this.txtToplamHizmetTutari.Size = new System.Drawing.Size(77, 21);
            this.txtToplamHizmetTutari.TabIndex = 43;
            this.txtToplamHizmetTutari.Tag = "000";
            this.txtToplamHizmetTutari.Text = "0";
            this.txtToplamHizmetTutari.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Başlangıç Tarihi";
            // 
            // dt1
            // 
            this.dt1.Location = new System.Drawing.Point(88, 15);
            this.dt1.Name = "dt1";
            this.dt1.Size = new System.Drawing.Size(171, 20);
            this.dt1.TabIndex = 46;
            // 
            // dt2
            // 
            this.dt2.Location = new System.Drawing.Point(88, 35);
            this.dt2.Name = "dt2";
            this.dt2.Size = new System.Drawing.Size(171, 20);
            this.dt2.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Bitiş Tarihi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Plaka";
            // 
            // txtPlaka
            // 
            this.txtPlaka.Location = new System.Drawing.Point(99, 87);
            this.txtPlaka.Name = "txtPlaka";
            this.txtPlaka.Size = new System.Drawing.Size(171, 20);
            this.txtPlaka.TabIndex = 50;
            // 
            // txtAboneAdi
            // 
            this.txtAboneAdi.Location = new System.Drawing.Point(99, 108);
            this.txtAboneAdi.Name = "txtAboneAdi";
            this.txtAboneAdi.Size = new System.Drawing.Size(171, 20);
            this.txtAboneAdi.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Abone Adı";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dt1);
            this.groupBox1.Controls.Add(this.dt2);
            this.groupBox1.Location = new System.Drawing.Point(11, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 60);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tarih";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdCikis);
            this.groupBox2.Controls.Add(this.rdGiris);
            this.groupBox2.Controls.Add(this.rdTumu);
            this.groupBox2.Location = new System.Drawing.Point(294, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(80, 106);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "İşlem Türü";
            // 
            // rdTumu
            // 
            this.rdTumu.AutoSize = true;
            this.rdTumu.Checked = true;
            this.rdTumu.Location = new System.Drawing.Point(10, 27);
            this.rdTumu.Name = "rdTumu";
            this.rdTumu.Size = new System.Drawing.Size(52, 17);
            this.rdTumu.TabIndex = 0;
            this.rdTumu.TabStop = true;
            this.rdTumu.Text = "Tümü";
            this.rdTumu.UseVisualStyleBackColor = true;
            // 
            // rdGiris
            // 
            this.rdGiris.AutoSize = true;
            this.rdGiris.Location = new System.Drawing.Point(10, 51);
            this.rdGiris.Name = "rdGiris";
            this.rdGiris.Size = new System.Drawing.Size(45, 17);
            this.rdGiris.TabIndex = 1;
            this.rdGiris.Text = "Giriş";
            this.rdGiris.UseVisualStyleBackColor = true;
            // 
            // rdCikis
            // 
            this.rdCikis.AutoSize = true;
            this.rdCikis.Location = new System.Drawing.Point(10, 74);
            this.rdCikis.Name = "rdCikis";
            this.rdCikis.Size = new System.Drawing.Size(47, 17);
            this.rdCikis.TabIndex = 2;
            this.rdCikis.Text = "Çıkış";
            this.rdCikis.UseVisualStyleBackColor = true;
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.White;
            this.label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label54.Dock = System.Windows.Forms.DockStyle.Top;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label54.Location = new System.Drawing.Point(0, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(689, 17);
            this.label54.TabIndex = 54;
            this.label54.Text = "Filtre Seçenekleri";
            this.label54.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.label70);
            this.panel16.Controls.Add(this.btnSorgula);
            this.panel16.Controls.Add(this.btnYazdir);
            this.panel16.Controls.Add(this.btnRaporGoruntule);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel16.Location = new System.Drawing.Point(587, 17);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(102, 119);
            this.panel16.TabIndex = 55;
            // 
            // label70
            // 
            this.label70.BackColor = System.Drawing.Color.White;
            this.label70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label70.Dock = System.Windows.Forms.DockStyle.Top;
            this.label70.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label70.Location = new System.Drawing.Point(0, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(100, 17);
            this.label70.TabIndex = 0;
            this.label70.Text = "Raporlama";
            this.label70.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSorgula
            // 
            this.btnSorgula.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSorgula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSorgula.Location = new System.Drawing.Point(3, 19);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(95, 24);
            this.btnSorgula.TabIndex = 52;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = false;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // btnYazdir
            // 
            this.btnYazdir.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnYazdir.Enabled = false;
            this.btnYazdir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYazdir.Location = new System.Drawing.Point(3, 88);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(95, 27);
            this.btnYazdir.TabIndex = 49;
            this.btnYazdir.Text = "Yazdır";
            this.btnYazdir.UseVisualStyleBackColor = false;
            // 
            // btnRaporGoruntule
            // 
            this.btnRaporGoruntule.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRaporGoruntule.Enabled = false;
            this.btnRaporGoruntule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporGoruntule.Location = new System.Drawing.Point(3, 43);
            this.btnRaporGoruntule.Name = "btnRaporGoruntule";
            this.btnRaporGoruntule.Size = new System.Drawing.Size(95, 44);
            this.btnRaporGoruntule.TabIndex = 47;
            this.btnRaporGoruntule.Text = "Rapor Görüntüle";
            this.btnRaporGoruntule.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(411, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 57;
            this.label5.Text = "Kayıt Sayısı";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKayitSayisi
            // 
            this.txtKayitSayisi.BackColor = System.Drawing.Color.White;
            this.txtKayitSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKayitSayisi.ForeColor = System.Drawing.Color.Black;
            this.txtKayitSayisi.Location = new System.Drawing.Point(507, 86);
            this.txtKayitSayisi.Name = "txtKayitSayisi";
            this.txtKayitSayisi.ReadOnly = true;
            this.txtKayitSayisi.Size = new System.Drawing.Size(77, 21);
            this.txtKayitSayisi.TabIndex = 56;
            this.txtKayitSayisi.Tag = "000";
            this.txtKayitSayisi.Text = "0";
            this.txtKayitSayisi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // plaka
            // 
            this.plaka.HeaderText = "Plaka";
            this.plaka.Name = "plaka";
            this.plaka.ReadOnly = true;
            this.plaka.Width = 59;
            // 
            // aboneAdi
            // 
            this.aboneAdi.HeaderText = "Abone Adı";
            this.aboneAdi.Name = "aboneAdi";
            this.aboneAdi.ReadOnly = true;
            this.aboneAdi.Width = 81;
            // 
            // tarih
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.tarih.DefaultCellStyle = dataGridViewCellStyle1;
            this.tarih.HeaderText = "İşlem Tarihi";
            this.tarih.Name = "tarih";
            this.tarih.ReadOnly = true;
            this.tarih.Width = 85;
            // 
            // saat
            // 
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            this.saat.DefaultCellStyle = dataGridViewCellStyle2;
            this.saat.HeaderText = "Saati";
            this.saat.Name = "saat";
            this.saat.ReadOnly = true;
            this.saat.Width = 56;
            // 
            // islemTuru
            // 
            this.islemTuru.HeaderText = "İşlem Türü";
            this.islemTuru.Name = "islemTuru";
            this.islemTuru.ReadOnly = true;
            this.islemTuru.Width = 81;
            // 
            // toplam
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "n2";
            this.toplam.DefaultCellStyle = dataGridViewCellStyle3;
            this.toplam.HeaderText = "Toplam";
            this.toplam.Name = "toplam";
            this.toplam.ReadOnly = true;
            this.toplam.Width = 67;
            // 
            // frmOtoparkGirisCikisRaporu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 493);
            this.Controls.Add(this.dgGirisCikis);
            this.Controls.Add(this.panel7);
            this.Name = "frmOtoparkGirisCikisRaporu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Otopark Giriş-Çıkış Raporu";
            this.Load += new System.EventHandler(this.frmOtoparkGirisCikisRaporu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgGirisCikis)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgGirisCikis;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtToplamHizmetTutari;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dt2;
        private System.Windows.Forms.DateTimePicker dt1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAboneAdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlaka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdCikis;
        private System.Windows.Forms.RadioButton rdGiris;
        private System.Windows.Forms.RadioButton rdTumu;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.Button btnYazdir;
        private System.Windows.Forms.Button btnRaporGoruntule;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKayitSayisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn plaka;
        private System.Windows.Forms.DataGridViewTextBoxColumn aboneAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn saat;
        private System.Windows.Forms.DataGridViewTextBoxColumn islemTuru;
        private System.Windows.Forms.DataGridViewTextBoxColumn toplam;
    }
}