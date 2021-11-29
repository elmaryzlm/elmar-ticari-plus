namespace Elmar_Ticari_Plus
{
    partial class FrmTopluSms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTopluSms));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCariGrubu = new System.Windows.Forms.ComboBox();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAllSelect = new System.Windows.Forms.Button();
            this.btnAllUnSelect = new System.Windows.Forms.Button();
            this.btnGonder = new System.Windows.Forms.Button();
            this.txtMesaj = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBakiye = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cariid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soyadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gsm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sec = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnAllSelect);
            this.panel1.Controls.Add(this.btnAllUnSelect);
            this.panel1.Controls.Add(this.btnGonder);
            this.panel1.Controls.Add(this.txtMesaj);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblBakiye);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 277);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCariGrubu);
            this.groupBox1.Controls.Add(this.btnSorgula);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(64, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 71);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listede Arama Yap";
            // 
            // cmbCariGrubu
            // 
            this.cmbCariGrubu.FormattingEnabled = true;
            this.cmbCariGrubu.Location = new System.Drawing.Point(263, 19);
            this.cmbCariGrubu.Name = "cmbCariGrubu";
            this.cmbCariGrubu.Size = new System.Drawing.Size(143, 21);
            this.cmbCariGrubu.TabIndex = 22;
            // 
            // btnSorgula
            // 
            this.btnSorgula.Location = new System.Drawing.Point(331, 45);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(75, 23);
            this.btnSorgula.TabIndex = 21;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = true;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Grup Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Cari Adı";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(67, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 20);
            this.textBox1.TabIndex = 17;
            // 
            // btnAllSelect
            // 
            this.btnAllSelect.BackColor = System.Drawing.Color.Transparent;
            this.btnAllSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnAllSelect.Image")));
            this.btnAllSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllSelect.Location = new System.Drawing.Point(479, 85);
            this.btnAllSelect.Name = "btnAllSelect";
            this.btnAllSelect.Size = new System.Drawing.Size(167, 36);
            this.btnAllSelect.TabIndex = 11;
            this.btnAllSelect.Tag = "";
            this.btnAllSelect.Text = "Tümünü Seç";
            this.btnAllSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAllSelect.UseVisualStyleBackColor = false;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // btnAllUnSelect
            // 
            this.btnAllUnSelect.BackColor = System.Drawing.Color.Transparent;
            this.btnAllUnSelect.Image = global::Elmar_Ticari_Plus.Properties.Resources.Close_2_icon;
            this.btnAllUnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllUnSelect.Location = new System.Drawing.Point(479, 121);
            this.btnAllUnSelect.Name = "btnAllUnSelect";
            this.btnAllUnSelect.Size = new System.Drawing.Size(167, 36);
            this.btnAllUnSelect.TabIndex = 12;
            this.btnAllUnSelect.Tag = "";
            this.btnAllUnSelect.Text = "Seçimi Kaldır";
            this.btnAllUnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAllUnSelect.UseVisualStyleBackColor = false;
            this.btnAllUnSelect.Click += new System.EventHandler(this.btnAllUnSelect_Click);
            // 
            // btnGonder
            // 
            this.btnGonder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGonder.ForeColor = System.Drawing.Color.Red;
            this.btnGonder.Image = ((System.Drawing.Image)(resources.GetObject("btnGonder.Image")));
            this.btnGonder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGonder.Location = new System.Drawing.Point(479, 157);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(167, 36);
            this.btnGonder.TabIndex = 4;
            this.btnGonder.Text = "GÖNDER";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // txtMesaj
            // 
            this.txtMesaj.Location = new System.Drawing.Point(64, 33);
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.Size = new System.Drawing.Size(410, 157);
            this.txtMesaj.TabIndex = 3;
            this.txtMesaj.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mesaj";
            // 
            // lblBakiye
            // 
            this.lblBakiye.AutoSize = true;
            this.lblBakiye.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBakiye.Location = new System.Drawing.Point(60, 9);
            this.lblBakiye.Name = "lblBakiye";
            this.lblBakiye.Size = new System.Drawing.Size(67, 20);
            this.lblBakiye.TabIndex = 1;
            this.lblBakiye.Text = "Bakiye:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bakiye:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 277);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(787, 262);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cariid,
            this.adi,
            this.soyadi,
            this.grupAdi,
            this.gsm,
            this.sec});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 100;
            this.dataGridView1.Size = new System.Drawing.Size(787, 262);
            this.dataGridView1.TabIndex = 1;
            // 
            // cariid
            // 
            this.cariid.HeaderText = "cariid";
            this.cariid.Name = "cariid";
            this.cariid.Visible = false;
            // 
            // adi
            // 
            this.adi.HeaderText = "Adı";
            this.adi.Name = "adi";
            this.adi.ReadOnly = true;
            // 
            // soyadi
            // 
            this.soyadi.HeaderText = "Soyadı";
            this.soyadi.Name = "soyadi";
            this.soyadi.ReadOnly = true;
            // 
            // grupAdi
            // 
            this.grupAdi.HeaderText = "Grubu";
            this.grupAdi.Name = "grupAdi";
            // 
            // gsm
            // 
            this.gsm.HeaderText = "Gsm";
            this.gsm.Name = "gsm";
            // 
            // sec
            // 
            this.sec.HeaderText = "Seç";
            this.sec.Name = "sec";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(481, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Gönderilen SMS Sayısı:";
            // 
            // FrmTopluSms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 539);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmTopluSms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTopluSms";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblBakiye;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtMesaj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.Button btnAllSelect;
        private System.Windows.Forms.Button btnAllUnSelect;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.DataGridViewTextBoxColumn cariid;
        private System.Windows.Forms.DataGridViewTextBoxColumn adi;
        private System.Windows.Forms.DataGridViewTextBoxColumn soyadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn gsm;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sec;
        private System.Windows.Forms.ComboBox cmbCariGrubu;
        private System.Windows.Forms.Label label5;
    }
}