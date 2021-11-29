namespace Elmar_Ticari_Plus
{
    partial class frmTanimCariGrubu
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
            this.dgCariGrubu = new System.Windows.Forms.DataGridView();
            this.cariGrupid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEkle = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCariGrupAdi = new System.Windows.Forms.TextBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKayitSayisi = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgCariGrubu)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgCariGrubu
            // 
            this.dgCariGrubu.AllowUserToAddRows = false;
            this.dgCariGrubu.AllowUserToDeleteRows = false;
            this.dgCariGrubu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCariGrubu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCariGrubu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cariGrupid,
            this.grupAdi});
            this.dgCariGrubu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCariGrubu.Location = new System.Drawing.Point(0, 32);
            this.dgCariGrubu.Name = "dgCariGrubu";
            this.dgCariGrubu.RowHeadersWidth = 20;
            this.dgCariGrubu.Size = new System.Drawing.Size(321, 313);
            this.dgCariGrubu.TabIndex = 46;
            this.dgCariGrubu.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCariGrubu_CellEndEdit);
            // 
            // cariGrupid
            // 
            this.cariGrupid.HeaderText = "cariGrupid";
            this.cariGrupid.Name = "cariGrupid";
            this.cariGrupid.Visible = false;
            // 
            // grupAdi
            // 
            this.grupAdi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grupAdi.HeaderText = "Cari Grubu Adı";
            this.grupAdi.Name = "grupAdi";
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnEkle.Location = new System.Drawing.Point(232, 5);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(47, 23);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCariGrupAdi);
            this.panel2.Controls.Add(this.btnSil);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnEkle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(321, 32);
            this.panel2.TabIndex = 47;
            // 
            // txtCariGrupAdi
            // 
            this.txtCariGrupAdi.BackColor = System.Drawing.Color.White;
            this.txtCariGrupAdi.ForeColor = System.Drawing.Color.Black;
            this.txtCariGrupAdi.Location = new System.Drawing.Point(80, 7);
            this.txtCariGrupAdi.Name = "txtCariGrupAdi";
            this.txtCariGrupAdi.Size = new System.Drawing.Size(148, 20);
            this.txtCariGrupAdi.TabIndex = 1;
            this.txtCariGrupAdi.Tag = "001";
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSil.Location = new System.Drawing.Point(280, 5);
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
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cari Grup Adı";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblKayitSayisi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 345);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(321, 22);
            this.statusStrip1.TabIndex = 48;
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
            // frmTanimCariGrubu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 367);
            this.Controls.Add(this.dgCariGrubu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmTanimCariGrubu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Cari Grubu Tanımlamaları";
            this.Load += new System.EventHandler(this.frmTanimCariGrubu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCariGrubu)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCariGrubu;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCariGrupAdi;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblKayitSayisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn cariGrupid;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupAdi;
    }
}