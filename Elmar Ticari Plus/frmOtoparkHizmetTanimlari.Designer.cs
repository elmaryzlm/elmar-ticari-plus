namespace Elmar_Ticari_Plus
{
    partial class frmOtoparkHizmetTanimlari
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
            this.dgHizmetTanim = new System.Windows.Forms.DataGridView();
            this.hizmetid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEkle = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFiyat = new System.Windows.Forms.TextBox();
            this.txtHizmetAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKayitSayisi = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgHizmetTanim)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgHizmetTanim
            // 
            this.dgHizmetTanim.AllowUserToAddRows = false;
            this.dgHizmetTanim.AllowUserToDeleteRows = false;
            this.dgHizmetTanim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgHizmetTanim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHizmetTanim.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hizmetid,
            this.adi,
            this.fiyat});
            this.dgHizmetTanim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgHizmetTanim.Location = new System.Drawing.Point(0, 32);
            this.dgHizmetTanim.Name = "dgHizmetTanim";
            this.dgHizmetTanim.RowHeadersWidth = 20;
            this.dgHizmetTanim.Size = new System.Drawing.Size(370, 355);
            this.dgHizmetTanim.TabIndex = 43;
            this.dgHizmetTanim.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgHizmetTanim_CellEndEdit);
            // 
            // hizmetid
            // 
            this.hizmetid.HeaderText = "hizmetid";
            this.hizmetid.Name = "hizmetid";
            this.hizmetid.Visible = false;
            // 
            // adi
            // 
            this.adi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.adi.HeaderText = "Hizmet Adı";
            this.adi.Name = "adi";
            // 
            // fiyat
            // 
            this.fiyat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle1.Format = "n2";
            this.fiyat.DefaultCellStyle = dataGridViewCellStyle1;
            this.fiyat.HeaderText = "B.Fiyat";
            this.fiyat.Name = "fiyat";
            this.fiyat.Width = 64;
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnEkle.Location = new System.Drawing.Point(286, 5);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(47, 23);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtFiyat);
            this.panel2.Controls.Add(this.txtHizmetAdi);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnSil);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnEkle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(370, 32);
            this.panel2.TabIndex = 44;
            // 
            // txtFiyat
            // 
            this.txtFiyat.BackColor = System.Drawing.Color.White;
            this.txtFiyat.ForeColor = System.Drawing.Color.Black;
            this.txtFiyat.Location = new System.Drawing.Point(210, 7);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Size = new System.Drawing.Size(68, 20);
            this.txtFiyat.TabIndex = 46;
            this.txtFiyat.Tag = "001";
            this.txtFiyat.Text = "0";
            // 
            // txtHizmetAdi
            // 
            this.txtHizmetAdi.BackColor = System.Drawing.Color.White;
            this.txtHizmetAdi.ForeColor = System.Drawing.Color.Black;
            this.txtHizmetAdi.Location = new System.Drawing.Point(57, 7);
            this.txtHizmetAdi.Name = "txtHizmetAdi";
            this.txtHizmetAdi.Size = new System.Drawing.Size(113, 20);
            this.txtHizmetAdi.TabIndex = 1;
            this.txtHizmetAdi.Tag = "001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Fiyat";
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSil.Location = new System.Drawing.Point(334, 5);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(35, 23);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hizmet Adı";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblKayitSayisi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 387);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(370, 22);
            this.statusStrip1.TabIndex = 45;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(71, 17);
            this.toolStripStatusLabel1.Text = "Kayıt Sayısı: ";
            // 
            // lblKayitSayisi
            // 
            this.lblKayitSayisi.Name = "lblKayitSayisi";
            this.lblKayitSayisi.Size = new System.Drawing.Size(13, 17);
            this.lblKayitSayisi.Text = "0";
            // 
            // frmOtoparkHizmetTanimlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 409);
            this.Controls.Add(this.dgHizmetTanim);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmOtoparkHizmetTanimlari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Hizmet Tanımları";
            this.Load += new System.EventHandler(this.frmOtoparkHizmetTanimlari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgHizmetTanim)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgHizmetTanim;
        private System.Windows.Forms.DataGridViewTextBoxColumn hizmetid;
        private System.Windows.Forms.DataGridViewTextBoxColumn adi;
        private System.Windows.Forms.DataGridViewTextBoxColumn fiyat;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.TextBox txtFiyat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHizmetAdi;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblKayitSayisi;
    }
}