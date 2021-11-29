namespace Elmar_Ticari_Plus
{
    partial class frmBankaPosEkle
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
            this.txtTanimAdi = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAyrinti = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPosAdi = new System.Windows.Forms.ComboBox();
            this.cmbBankaHesabi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgTaksitOranlari = new System.Windows.Forms.DataGridView();
            this.posTaksitid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taksitSayisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aylikOran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTaksitOranlari)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTanimAdi
            // 
            this.txtTanimAdi.BackColor = System.Drawing.Color.White;
            this.txtTanimAdi.ForeColor = System.Drawing.Color.Black;
            this.txtTanimAdi.Location = new System.Drawing.Point(9, 68);
            this.txtTanimAdi.Name = "txtTanimAdi";
            this.txtTanimAdi.Size = new System.Drawing.Size(343, 20);
            this.txtTanimAdi.TabIndex = 2;
            this.txtTanimAdi.Tag = "001";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(9, 52);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(54, 13);
            this.label57.TabIndex = 10;
            this.label57.Text = "Tanım Adı";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Pos Adı";
            // 
            // txtAyrinti
            // 
            this.txtAyrinti.BackColor = System.Drawing.Color.White;
            this.txtAyrinti.ForeColor = System.Drawing.Color.Black;
            this.txtAyrinti.Location = new System.Drawing.Point(9, 153);
            this.txtAyrinti.Multiline = true;
            this.txtAyrinti.Name = "txtAyrinti";
            this.txtAyrinti.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAyrinti.Size = new System.Drawing.Size(343, 116);
            this.txtAyrinti.TabIndex = 4;
            this.txtAyrinti.Tag = "001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ayrıntı";
            // 
            // cmbPosAdi
            // 
            this.cmbPosAdi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPosAdi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPosAdi.BackColor = System.Drawing.Color.White;
            this.cmbPosAdi.ForeColor = System.Drawing.Color.Black;
            this.cmbPosAdi.FormattingEnabled = true;
            this.cmbPosAdi.Items.AddRange(new object[] {
            "BonusCard",
            "Axess",
            "Maximum Card",
            "TEB World",
            "Cardfinans",
            "Halkbank - Advantage",
            "Anadolu Bank",
            "T.Finans Kredi Kartı",
            "Teb Bonus",
            "WorldCard",
            "KuveytTürk Kredi Kartı",
            "Bank Asya Kredi Kartı",
            "HSBC Advantage Card",
            "Vakıf Bank World Card",
            "DenizBank Bonus",
            "ING Bank",
            "Diğer"});
            this.cmbPosAdi.Location = new System.Drawing.Point(9, 25);
            this.cmbPosAdi.Name = "cmbPosAdi";
            this.cmbPosAdi.Size = new System.Drawing.Size(343, 21);
            this.cmbPosAdi.TabIndex = 1;
            this.cmbPosAdi.Tag = "001";
            // 
            // cmbBankaHesabi
            // 
            this.cmbBankaHesabi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBankaHesabi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBankaHesabi.BackColor = System.Drawing.Color.White;
            this.cmbBankaHesabi.ForeColor = System.Drawing.Color.Black;
            this.cmbBankaHesabi.FormattingEnabled = true;
            this.cmbBankaHesabi.Location = new System.Drawing.Point(9, 110);
            this.cmbBankaHesabi.Name = "cmbBankaHesabi";
            this.cmbBankaHesabi.Size = new System.Drawing.Size(343, 21);
            this.cmbBankaHesabi.TabIndex = 3;
            this.cmbBankaHesabi.Tag = "001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Banka Hesabı";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgTaksitOranlari);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(359, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(157, 316);
            this.panel1.TabIndex = 20;
            // 
            // dgTaksitOranlari
            // 
            this.dgTaksitOranlari.AllowUserToAddRows = false;
            this.dgTaksitOranlari.AllowUserToDeleteRows = false;
            this.dgTaksitOranlari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTaksitOranlari.ColumnHeadersHeight = 20;
            this.dgTaksitOranlari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgTaksitOranlari.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.posTaksitid,
            this.taksitSayisi,
            this.aylikOran});
            this.dgTaksitOranlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTaksitOranlari.Location = new System.Drawing.Point(0, 20);
            this.dgTaksitOranlari.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.dgTaksitOranlari.MultiSelect = false;
            this.dgTaksitOranlari.Name = "dgTaksitOranlari";
            this.dgTaksitOranlari.RowHeadersWidth = 20;
            this.dgTaksitOranlari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTaksitOranlari.Size = new System.Drawing.Size(155, 294);
            this.dgTaksitOranlari.TabIndex = 10;
            // 
            // posTaksitid
            // 
            this.posTaksitid.HeaderText = "posTaksitid";
            this.posTaksitid.Name = "posTaksitid";
            this.posTaksitid.Visible = false;
            // 
            // taksitSayisi
            // 
            this.taksitSayisi.HeaderText = "Taksit S.";
            this.taksitSayisi.Name = "taksitSayisi";
            this.taksitSayisi.ReadOnly = true;
            // 
            // aylikOran
            // 
            this.aylikOran.HeaderText = "Aylık Oran";
            this.aylikOran.Name = "aylikOran";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Taksit Oranları";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbBankaHesabi);
            this.panel2.Controls.Add(this.txtAyrinti);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label57);
            this.panel2.Controls.Add(this.cmbPosAdi);
            this.panel2.Controls.Add(this.txtTanimAdi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 281);
            this.panel2.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnKaydet);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 281);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(359, 35);
            this.panel3.TabIndex = 22;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydet.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(146, 2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(64, 28);
            this.btnKaydet.TabIndex = 24;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // frmBankaPosEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(516, 316);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "frmBankaPosEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Yeni Banka Pos Ekle";
            this.Load += new System.EventHandler(this.frmBankaPosEkle_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTaksitOranlari)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTanimAdi;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAyrinti;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPosAdi;
        private System.Windows.Forms.ComboBox cmbBankaHesabi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dgTaksitOranlari;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn posTaksitid;
        private System.Windows.Forms.DataGridViewTextBoxColumn taksitSayisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn aylikOran;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnKaydet;
    }
}