namespace Elmar_Ticari_Plus
{
    partial class frmTanimBirim
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
            this.btnEkle = new System.Windows.Forms.Button();
            this.dgBirimTanim = new System.Windows.Forms.DataGridView();
            this.birimid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birimAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSil = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBirimAdi = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKayitSayisi = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgBirimTanim)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnEkle.Location = new System.Drawing.Point(232, 6);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(47, 23);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // dgBirimTanim
            // 
            this.dgBirimTanim.AllowUserToAddRows = false;
            this.dgBirimTanim.AllowUserToDeleteRows = false;
            this.dgBirimTanim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgBirimTanim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBirimTanim.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.birimid,
            this.birimAdi});
            this.dgBirimTanim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBirimTanim.Location = new System.Drawing.Point(0, 32);
            this.dgBirimTanim.Name = "dgBirimTanim";
            this.dgBirimTanim.RowHeadersWidth = 20;
            this.dgBirimTanim.Size = new System.Drawing.Size(319, 342);
            this.dgBirimTanim.TabIndex = 36;
            this.dgBirimTanim.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgBirimTanim_CellBeginEdit);
            this.dgBirimTanim.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBirimTanim_CellEndEdit);
            // 
            // birimid
            // 
            this.birimid.HeaderText = "birimid";
            this.birimid.Name = "birimid";
            this.birimid.Visible = false;
            // 
            // birimAdi
            // 
            this.birimAdi.HeaderText = "Birim Adı";
            this.birimAdi.Name = "birimAdi";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSil);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtBirimAdi);
            this.panel2.Controls.Add(this.btnEkle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 32);
            this.panel2.TabIndex = 38;
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSil.Location = new System.Drawing.Point(280, 6);
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
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Birim Adı: ";
            // 
            // txtBirimAdi
            // 
            this.txtBirimAdi.BackColor = System.Drawing.Color.White;
            this.txtBirimAdi.ForeColor = System.Drawing.Color.Black;
            this.txtBirimAdi.Location = new System.Drawing.Point(56, 7);
            this.txtBirimAdi.Name = "txtBirimAdi";
            this.txtBirimAdi.Size = new System.Drawing.Size(172, 20);
            this.txtBirimAdi.TabIndex = 1;
            this.txtBirimAdi.Tag = "001";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblKayitSayisi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 352);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(319, 22);
            this.statusStrip1.TabIndex = 39;
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
            // frmTanimBirim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 374);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgBirimTanim);
            this.Controls.Add(this.panel2);
            this.Name = "frmTanimBirim";
            this.Text = "Birim Tanımları";
            this.Load += new System.EventHandler(this.frmTanimBirim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBirimTanim)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.DataGridView dgBirimTanim;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBirimAdi;
        private System.Windows.Forms.ToolStripStatusLabel lblKayitSayisi;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.DataGridViewTextBoxColumn birimid;
        private System.Windows.Forms.DataGridViewTextBoxColumn birimAdi;
    }
}