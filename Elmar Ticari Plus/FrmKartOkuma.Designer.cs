namespace Elmar_Ticari_Plus
{
    partial class FrmKartOkuma
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtCariAdi = new System.Windows.Forms.TextBox();
            this.txtBakiye = new System.Windows.Forms.TextBox();
            this.txtMiktar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKalan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.dgCariRaporu = new System.Windows.Forms.DataGridView();
            this.eklenmetarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soyadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cariAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCariRaporu)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(25, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "BAKİYE";
            // 
            // txtCariAdi
            // 
            this.txtCariAdi.Location = new System.Drawing.Point(28, 30);
            this.txtCariAdi.Multiline = true;
            this.txtCariAdi.Name = "txtCariAdi";
            this.txtCariAdi.Size = new System.Drawing.Size(337, 33);
            this.txtCariAdi.TabIndex = 6;
            // 
            // txtBakiye
            // 
            this.txtBakiye.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBakiye.Location = new System.Drawing.Point(28, 100);
            this.txtBakiye.Multiline = true;
            this.txtBakiye.Name = "txtBakiye";
            this.txtBakiye.Size = new System.Drawing.Size(94, 41);
            this.txtBakiye.TabIndex = 7;
            // 
            // txtMiktar
            // 
            this.txtMiktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMiktar.Location = new System.Drawing.Point(162, 102);
            this.txtMiktar.Multiline = true;
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(61, 39);
            this.txtMiktar.TabIndex = 9;
            this.txtMiktar.Text = "1";
            this.txtMiktar.TextChanged += new System.EventHandler(this.txtMiktar_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(160, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "MİKTAR";
            // 
            // txtKalan
            // 
            this.txtKalan.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKalan.Location = new System.Drawing.Point(265, 102);
            this.txtKalan.Multiline = true;
            this.txtKalan.Name = "txtKalan";
            this.txtKalan.Size = new System.Drawing.Size(100, 39);
            this.txtKalan.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(279, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "KALAN";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnKaydet);
            this.groupBox1.Controls.Add(this.txtCariAdi);
            this.groupBox1.Controls.Add(this.txtKalan);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMiktar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtBakiye);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 195);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cari Kart Bligileri";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(289, 147);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(76, 29);
            this.btnKaydet.TabIndex = 25;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // dgCariRaporu
            // 
            this.dgCariRaporu.AllowUserToOrderColumns = true;
            this.dgCariRaporu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCariRaporu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cariAdi,
            this.soyadi,
            this.miktar,
            this.eklenmetarihi});
            this.dgCariRaporu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCariRaporu.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgCariRaporu.Location = new System.Drawing.Point(0, 195);
            this.dgCariRaporu.Name = "dgCariRaporu";
            this.dgCariRaporu.Size = new System.Drawing.Size(491, 429);
            this.dgCariRaporu.TabIndex = 13;
            // 
            // eklenmetarihi
            // 
            this.eklenmetarihi.HeaderText = "Tarih";
            this.eklenmetarihi.Name = "eklenmetarihi";
            // 
            // miktar
            // 
            this.miktar.HeaderText = "Bakiye";
            this.miktar.Name = "miktar";
            // 
            // soyadi
            // 
            this.soyadi.HeaderText = "Soyadı";
            this.soyadi.Name = "soyadi";
            // 
            // cariAdi
            // 
            this.cariAdi.HeaderText = "Cari Adı";
            this.cariAdi.Name = "cariAdi";
            // 
            // FrmKartOkuma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 624);
            this.Controls.Add(this.dgCariRaporu);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmKartOkuma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Kart Okutma Ekranı";
            this.Load += new System.EventHandler(this.FrmKartOkuma_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCariRaporu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCariAdi;
        private System.Windows.Forms.TextBox txtBakiye;
        private System.Windows.Forms.TextBox txtMiktar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKalan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.DataGridView dgCariRaporu;
        private System.Windows.Forms.DataGridViewTextBoxColumn cariAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn soyadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn miktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn eklenmetarihi;
    }
}