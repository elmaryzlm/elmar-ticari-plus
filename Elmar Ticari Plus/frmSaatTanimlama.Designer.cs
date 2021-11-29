namespace Elmar_Ticari_Plus
{
    partial class frmOtoparkSaatTanimlama
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBaslangicSaati = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBitisSaati = new System.Windows.Forms.TextBox();
            this.lblKayitSayisi = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtFiyat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEkle = new System.Windows.Forms.Button();
            this.dgSaatTanimlama = new System.Windows.Forms.DataGridView();
            this.SaatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaslangicSaati = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BitisSaati = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSaatTanimlama)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Bitiş Saati";
            // 
            // txtBaslangicSaati
            // 
            this.txtBaslangicSaati.BackColor = System.Drawing.Color.White;
            this.txtBaslangicSaati.ForeColor = System.Drawing.Color.Black;
            this.txtBaslangicSaati.Location = new System.Drawing.Point(95, 13);
            this.txtBaslangicSaati.Name = "txtBaslangicSaati";
            this.txtBaslangicSaati.Size = new System.Drawing.Size(68, 20);
            this.txtBaslangicSaati.TabIndex = 48;
            this.txtBaslangicSaati.Tag = "001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Başlangıç Saati";
            // 
            // txtBitisSaati
            // 
            this.txtBitisSaati.BackColor = System.Drawing.Color.White;
            this.txtBitisSaati.ForeColor = System.Drawing.Color.Black;
            this.txtBitisSaati.Location = new System.Drawing.Point(236, 13);
            this.txtBitisSaati.Name = "txtBitisSaati";
            this.txtBitisSaati.Size = new System.Drawing.Size(68, 20);
            this.txtBitisSaati.TabIndex = 50;
            this.txtBitisSaati.Tag = "001";
            // 
            // lblKayitSayisi
            // 
            this.lblKayitSayisi.Name = "lblKayitSayisi";
            this.lblKayitSayisi.Size = new System.Drawing.Size(13, 17);
            this.lblKayitSayisi.Text = "0";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblKayitSayisi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(566, 22);
            this.statusStrip1.TabIndex = 51;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(71, 17);
            this.toolStripStatusLabel1.Text = "Kayıt Sayısı: ";
            // 
            // txtFiyat
            // 
            this.txtFiyat.BackColor = System.Drawing.Color.White;
            this.txtFiyat.ForeColor = System.Drawing.Color.Black;
            this.txtFiyat.Location = new System.Drawing.Point(353, 13);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Size = new System.Drawing.Size(68, 20);
            this.txtFiyat.TabIndex = 46;
            this.txtFiyat.Tag = "001";
            this.txtFiyat.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Fiyat";
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSil.Location = new System.Drawing.Point(480, 11);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(35, 23);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtBitisSaati);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtBaslangicSaati);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtFiyat);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnSil);
            this.panel2.Controls.Add(this.btnEkle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(566, 44);
            this.panel2.TabIndex = 50;
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnEkle.Location = new System.Drawing.Point(432, 11);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(47, 23);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // dgSaatTanimlama
            // 
            this.dgSaatTanimlama.AllowUserToAddRows = false;
            this.dgSaatTanimlama.AllowUserToDeleteRows = false;
            this.dgSaatTanimlama.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSaatTanimlama.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSaatTanimlama.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SaatID,
            this.BaslangicSaati,
            this.BitisSaati,
            this.Fiyat});
            this.dgSaatTanimlama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSaatTanimlama.Location = new System.Drawing.Point(0, 44);
            this.dgSaatTanimlama.Name = "dgSaatTanimlama";
            this.dgSaatTanimlama.RowHeadersWidth = 20;
            this.dgSaatTanimlama.Size = new System.Drawing.Size(566, 485);
            this.dgSaatTanimlama.TabIndex = 52;
            this.dgSaatTanimlama.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSaatTanimlama_CellEndEdit);
            // 
            // SaatID
            // 
            this.SaatID.HeaderText = "SaatID";
            this.SaatID.Name = "SaatID";
            this.SaatID.Visible = false;
            // 
            // BaslangicSaati
            // 
            this.BaslangicSaati.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BaslangicSaati.HeaderText = "Başlangıç Saati";
            this.BaslangicSaati.Name = "BaslangicSaati";
            // 
            // BitisSaati
            // 
            this.BitisSaati.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle2.Format = "n2";
            this.BitisSaati.DefaultCellStyle = dataGridViewCellStyle2;
            this.BitisSaati.HeaderText = "Bitiş Saati";
            this.BitisSaati.Name = "BitisSaati";
            // 
            // Fiyat
            // 
            this.Fiyat.HeaderText = "Fiyat";
            this.Fiyat.Name = "Fiyat";
            // 
            // frmOtoparkSaatTanimlama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 551);
            this.Controls.Add(this.dgSaatTanimlama);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Name = "frmOtoparkSaatTanimlama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmSaatTanimlama";
            this.Load += new System.EventHandler(this.frmOtoparkSaatTanimlama_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSaatTanimlama)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBaslangicSaati;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBitisSaati;
        private System.Windows.Forms.ToolStripStatusLabel lblKayitSayisi;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox txtFiyat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.DataGridView dgSaatTanimlama;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaatID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaslangicSaati;
        private System.Windows.Forms.DataGridViewTextBoxColumn BitisSaati;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fiyat;
    }
}