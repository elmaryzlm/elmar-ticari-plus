namespace Elmar_Ticari_Plus
{
    partial class frmSilinenSatislar
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
            this.btnSorgula = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtİslemTarihi2 = new System.Windows.Forms.DateTimePicker();
            this.dtİslemTarihi1 = new System.Windows.Forms.DateTimePicker();
            this.cmbKullanicilar = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.cmbSubeler = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgTicaretUrunler = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTicaretUrunler)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSorgula);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtİslemTarihi2);
            this.panel1.Controls.Add(this.dtİslemTarihi1);
            this.panel1.Controls.Add(this.cmbKullanicilar);
            this.panel1.Controls.Add(this.label56);
            this.panel1.Controls.Add(this.cmbSubeler);
            this.panel1.Controls.Add(this.label57);
            this.panel1.Controls.Add(this.label58);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 94);
            this.panel1.TabIndex = 0;
            // 
            // btnSorgula
            // 
            this.btnSorgula.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSorgula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSorgula.Location = new System.Drawing.Point(234, 62);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(95, 24);
            this.btnSorgula.TabIndex = 53;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = false;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tarih";
            // 
            // dtİslemTarihi2
            // 
            this.dtİslemTarihi2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtİslemTarihi2.Location = new System.Drawing.Point(151, 12);
            this.dtİslemTarihi2.Name = "dtİslemTarihi2";
            this.dtİslemTarihi2.Size = new System.Drawing.Size(77, 20);
            this.dtİslemTarihi2.TabIndex = 4;
            // 
            // dtİslemTarihi1
            // 
            this.dtİslemTarihi1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtİslemTarihi1.Location = new System.Drawing.Point(62, 12);
            this.dtİslemTarihi1.Name = "dtİslemTarihi1";
            this.dtİslemTarihi1.Size = new System.Drawing.Size(77, 20);
            this.dtİslemTarihi1.TabIndex = 3;
            // 
            // cmbKullanicilar
            // 
            this.cmbKullanicilar.BackColor = System.Drawing.Color.White;
            this.cmbKullanicilar.ForeColor = System.Drawing.Color.Black;
            this.cmbKullanicilar.FormattingEnabled = true;
            this.cmbKullanicilar.Location = new System.Drawing.Point(60, 65);
            this.cmbKullanicilar.Name = "cmbKullanicilar";
            this.cmbKullanicilar.Size = new System.Drawing.Size(168, 21);
            this.cmbKullanicilar.TabIndex = 3;
            this.cmbKullanicilar.Tag = "001";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label56.Location = new System.Drawing.Point(140, 16);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(11, 15);
            this.label56.TabIndex = 5;
            this.label56.Text = "-";
            // 
            // cmbSubeler
            // 
            this.cmbSubeler.BackColor = System.Drawing.Color.White;
            this.cmbSubeler.ForeColor = System.Drawing.Color.Black;
            this.cmbSubeler.FormattingEnabled = true;
            this.cmbSubeler.Location = new System.Drawing.Point(60, 38);
            this.cmbSubeler.Name = "cmbSubeler";
            this.cmbSubeler.Size = new System.Drawing.Size(168, 21);
            this.cmbSubeler.TabIndex = 0;
            this.cmbSubeler.Tag = "001";
            this.cmbSubeler.SelectedIndexChanged += new System.EventHandler(this.cmbSubeler_SelectedIndexChanged);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(14, 69);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(46, 13);
            this.label57.TabIndex = 2;
            this.label57.Text = "Kullanıcı";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(14, 42);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(32, 13);
            this.label58.TabIndex = 1;
            this.label58.Text = "Şube";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgTicaretUrunler);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1067, 290);
            this.panel2.TabIndex = 1;
            // 
            // dgTicaretUrunler
            // 
            this.dgTicaretUrunler.AllowUserToAddRows = false;
            this.dgTicaretUrunler.AllowUserToDeleteRows = false;
            this.dgTicaretUrunler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgTicaretUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTicaretUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTicaretUrunler.Location = new System.Drawing.Point(0, 0);
            this.dgTicaretUrunler.MultiSelect = false;
            this.dgTicaretUrunler.Name = "dgTicaretUrunler";
            this.dgTicaretUrunler.ReadOnly = true;
            this.dgTicaretUrunler.RowHeadersWidth = 20;
            this.dgTicaretUrunler.RowTemplate.Height = 20;
            this.dgTicaretUrunler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTicaretUrunler.Size = new System.Drawing.Size(1067, 290);
            this.dgTicaretUrunler.TabIndex = 10;
            // 
            // frmSilinenSatislar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 384);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmSilinenSatislar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSilinenSatislar";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTicaretUrunler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtİslemTarihi2;
        private System.Windows.Forms.DateTimePicker dtİslemTarihi1;
        private System.Windows.Forms.ComboBox cmbKullanicilar;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.ComboBox cmbSubeler;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.DataGridView dgTicaretUrunler;
    }
}