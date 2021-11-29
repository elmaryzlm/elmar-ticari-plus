namespace Elmar_Ticari_Plus
{
    partial class frmMesajGonderGrup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMesajGonderGrup));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAllSelect = new System.Windows.Forms.Button();
            this.btnAllUnSelect = new System.Windows.Forms.Button();
            this.btnGonder = new System.Windows.Forms.Button();
            this.lblBakiye = new System.Windows.Forms.Label();
            this.txtMesaj = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCariGruplari = new System.Windows.Forms.ComboBox();
            this.cmbBaslik = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMesajAdi = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAllSelect);
            this.panel1.Controls.Add(this.btnAllUnSelect);
            this.panel1.Controls.Add(this.btnGonder);
            this.panel1.Controls.Add(this.lblBakiye);
            this.panel1.Controls.Add(this.txtMesaj);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbCariGruplari);
            this.panel1.Controls.Add(this.cmbBaslik);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbMesajAdi);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 106);
            this.panel1.TabIndex = 0;
            // 
            // btnAllSelect
            // 
            this.btnAllSelect.Location = new System.Drawing.Point(443, 32);
            this.btnAllSelect.Name = "btnAllSelect";
            this.btnAllSelect.Size = new System.Drawing.Size(99, 32);
            this.btnAllSelect.TabIndex = 6;
            this.btnAllSelect.Tag = "";
            this.btnAllSelect.Text = "Tümünü Seç";
            this.btnAllSelect.UseVisualStyleBackColor = true;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // btnAllUnSelect
            // 
            this.btnAllUnSelect.Location = new System.Drawing.Point(543, 32);
            this.btnAllUnSelect.Name = "btnAllUnSelect";
            this.btnAllUnSelect.Size = new System.Drawing.Size(99, 32);
            this.btnAllUnSelect.TabIndex = 7;
            this.btnAllUnSelect.Tag = "";
            this.btnAllUnSelect.Text = "Seçimi Kaldır";
            this.btnAllUnSelect.UseVisualStyleBackColor = true;
            this.btnAllUnSelect.Click += new System.EventHandler(this.btnAllUnSelect_Click);
            // 
            // btnGonder
            // 
            this.btnGonder.Image = ((System.Drawing.Image)(resources.GetObject("btnGonder.Image")));
            this.btnGonder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGonder.Location = new System.Drawing.Point(443, 67);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(199, 36);
            this.btnGonder.TabIndex = 2;
            this.btnGonder.Text = "Gönder";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // lblBakiye
            // 
            this.lblBakiye.AutoSize = true;
            this.lblBakiye.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBakiye.ForeColor = System.Drawing.Color.DarkRed;
            this.lblBakiye.Location = new System.Drawing.Point(71, 7);
            this.lblBakiye.Name = "lblBakiye";
            this.lblBakiye.Size = new System.Drawing.Size(47, 15);
            this.lblBakiye.TabIndex = 3;
            this.lblBakiye.Text = "0 Adet";
            // 
            // txtMesaj
            // 
            this.txtMesaj.Location = new System.Drawing.Point(222, 3);
            this.txtMesaj.MaxLength = 130;
            this.txtMesaj.Multiline = true;
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.Size = new System.Drawing.Size(215, 100);
            this.txtMesaj.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Kalan Bak.";
            // 
            // cmbCariGruplari
            // 
            this.cmbCariGruplari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCariGruplari.FormattingEnabled = true;
            this.cmbCariGruplari.Items.AddRange(new object[] {
            "08508409893",
            "ELMAR YZLM"});
            this.cmbCariGruplari.Location = new System.Drawing.Point(71, 82);
            this.cmbCariGruplari.Name = "cmbCariGruplari";
            this.cmbCariGruplari.Size = new System.Drawing.Size(145, 21);
            this.cmbCariGruplari.TabIndex = 0;
            this.cmbCariGruplari.SelectedIndexChanged += new System.EventHandler(this.cmbCariGruplari_SelectedIndexChanged);
            // 
            // cmbBaslik
            // 
            this.cmbBaslik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaslik.FormattingEnabled = true;
            this.cmbBaslik.Items.AddRange(new object[] {
            "08508409893",
            "ELMAR YZLM"});
            this.cmbBaslik.Location = new System.Drawing.Point(71, 55);
            this.cmbBaslik.Name = "cmbBaslik";
            this.cmbBaslik.Size = new System.Drawing.Size(145, 21);
            this.cmbBaslik.TabIndex = 0;
            this.cmbBaslik.SelectedIndexChanged += new System.EventHandler(this.cmbMesajAdi_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cari Grubu";
            // 
            // cmbMesajAdi
            // 
            this.cmbMesajAdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesajAdi.FormattingEnabled = true;
            this.cmbMesajAdi.Location = new System.Drawing.Point(71, 28);
            this.cmbMesajAdi.Name = "cmbMesajAdi";
            this.cmbMesajAdi.Size = new System.Drawing.Size(145, 21);
            this.cmbMesajAdi.TabIndex = 0;
            this.cmbMesajAdi.SelectedIndexChanged += new System.EventHandler(this.cmbMesajAdi_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Başlık";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mesaj Adı";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(653, 196);
            this.dataGridView1.TabIndex = 1;
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            // 
            // frmMesajGonderGrup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(653, 302);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "frmMesajGonderGrup";
            this.Text = "Mesaj Gönder";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMesajAdi;
        private System.Windows.Forms.TextBox txtMesaj;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBakiye;
        private System.Windows.Forms.ComboBox cmbBaslik;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.Button btnAllSelect;
        private System.Windows.Forms.Button btnAllUnSelect;
        private System.Windows.Forms.ComboBox cmbCariGruplari;
        private System.Windows.Forms.Label label2;
    }
}