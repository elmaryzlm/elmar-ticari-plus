namespace Elmar_Ticari_Plus
{
    partial class frmTanimDepartman
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
            this.dgDepartmanTanim = new System.Windows.Forms.DataGridView();
            this.departmanid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmanAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEkle = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDepartmanAdi = new System.Windows.Forms.TextBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKayitSayisi = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgDepartmanTanim)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgDepartmanTanim
            // 
            this.dgDepartmanTanim.AllowUserToAddRows = false;
            this.dgDepartmanTanim.AllowUserToDeleteRows = false;
            this.dgDepartmanTanim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgDepartmanTanim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDepartmanTanim.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.departmanid,
            this.departmanAdi});
            this.dgDepartmanTanim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDepartmanTanim.Location = new System.Drawing.Point(0, 32);
            this.dgDepartmanTanim.Name = "dgDepartmanTanim";
            this.dgDepartmanTanim.RowHeadersWidth = 20;
            this.dgDepartmanTanim.Size = new System.Drawing.Size(317, 391);
            this.dgDepartmanTanim.TabIndex = 4;
            this.dgDepartmanTanim.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDepartmanTanim_CellEndEdit);
            // 
            // departmanid
            // 
            this.departmanid.HeaderText = "departmanid";
            this.departmanid.Name = "departmanid";
            this.departmanid.Visible = false;
            // 
            // departmanAdi
            // 
            this.departmanAdi.HeaderText = "Departman Adı";
            this.departmanAdi.Name = "departmanAdi";
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
            // panel2
            // 
            this.panel2.Controls.Add(this.txtDepartmanAdi);
            this.panel2.Controls.Add(this.btnSil);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnEkle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(317, 32);
            this.panel2.TabIndex = 41;
            // 
            // txtDepartmanAdi
            // 
            this.txtDepartmanAdi.BackColor = System.Drawing.Color.White;
            this.txtDepartmanAdi.ForeColor = System.Drawing.Color.Black;
            this.txtDepartmanAdi.Location = new System.Drawing.Point(78, 7);
            this.txtDepartmanAdi.Name = "txtDepartmanAdi";
            this.txtDepartmanAdi.Size = new System.Drawing.Size(150, 20);
            this.txtDepartmanAdi.TabIndex = 1;
            this.txtDepartmanAdi.Tag = "001";
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
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Departman Adı";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblKayitSayisi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 423);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(317, 22);
            this.statusStrip1.TabIndex = 42;
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
            // frmTanimDepartman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 445);
            this.Controls.Add(this.dgDepartmanTanim);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmTanimDepartman";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Departman Tanımla";
            this.Load += new System.EventHandler(this.frmTanimDepartman_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDepartmanTanim)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDepartmanTanim;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDepartmanAdi;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblKayitSayisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmanid;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmanAdi;
    }
}