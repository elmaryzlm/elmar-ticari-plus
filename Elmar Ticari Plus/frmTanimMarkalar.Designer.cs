namespace Elmar_Ticari_Plus
{
    partial class frmTanimMarkalar
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
            this.dgMarkaTanim = new System.Windows.Forms.DataGridView();
            this.markaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markaAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEkle = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMarkaAdi = new System.Windows.Forms.TextBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKayitSayisi = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgMarkaTanim)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgMarkaTanim
            // 
            this.dgMarkaTanim.AllowUserToAddRows = false;
            this.dgMarkaTanim.AllowUserToDeleteRows = false;
            this.dgMarkaTanim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMarkaTanim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMarkaTanim.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.markaid,
            this.markaAdi});
            this.dgMarkaTanim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMarkaTanim.Location = new System.Drawing.Point(0, 32);
            this.dgMarkaTanim.Name = "dgMarkaTanim";
            this.dgMarkaTanim.RowHeadersWidth = 20;
            this.dgMarkaTanim.Size = new System.Drawing.Size(319, 313);
            this.dgMarkaTanim.TabIndex = 43;
            this.dgMarkaTanim.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMarkaTanim_CellEndEdit);
            // 
            // markaid
            // 
            this.markaid.HeaderText = "markaid";
            this.markaid.Name = "markaid";
            this.markaid.Visible = false;
            // 
            // markaAdi
            // 
            this.markaAdi.HeaderText = "Marka Adı";
            this.markaAdi.Name = "markaAdi";
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnEkle.Location = new System.Drawing.Point(232, 6);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(47, 23);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtMarkaAdi);
            this.panel2.Controls.Add(this.btnSil);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnEkle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 32);
            this.panel2.TabIndex = 44;
            // 
            // txtMarkaAdi
            // 
            this.txtMarkaAdi.BackColor = System.Drawing.Color.White;
            this.txtMarkaAdi.ForeColor = System.Drawing.Color.Black;
            this.txtMarkaAdi.Location = new System.Drawing.Point(56, 7);
            this.txtMarkaAdi.Name = "txtMarkaAdi";
            this.txtMarkaAdi.Size = new System.Drawing.Size(172, 20);
            this.txtMarkaAdi.TabIndex = 1;
            this.txtMarkaAdi.Tag = "001";
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
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Marka Adı: ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblKayitSayisi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 345);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(319, 22);
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
            // frmTanimMarkalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 367);
            this.Controls.Add(this.dgMarkaTanim);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmTanimMarkalar";
            this.Text = "Marka Tanımları";
            this.Load += new System.EventHandler(this.frmTanimMarkalar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMarkaTanim)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMarkaTanim;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMarkaAdi;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblKayitSayisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn markaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn markaAdi;
    }
}