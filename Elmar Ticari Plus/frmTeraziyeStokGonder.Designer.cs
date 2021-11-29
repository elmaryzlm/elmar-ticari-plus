namespace Elmar_Ticari_Plus
{
    partial class frmTeraziyeStokGonder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExceleDosyaGonder = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgUrunListesi1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbFiyatTuru = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgUrunListesi2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTxt = new System.Windows.Forms.Button();
            this.stokid1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stokKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urunAdi1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birimFiyat1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEkle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pluNo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stokKodu1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stokid2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urunAdi2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birimFiyat2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCikar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUrunListesi1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUrunListesi2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTxt);
            this.panel1.Controls.Add(this.btnExceleDosyaGonder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 475);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 35);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnExceleDosyaGonder
            // 
            this.btnExceleDosyaGonder.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnExceleDosyaGonder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExceleDosyaGonder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExceleDosyaGonder.Image = global::Elmar_Ticari_Plus.Properties.Resources.excel_icon__1_;
            this.btnExceleDosyaGonder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExceleDosyaGonder.Location = new System.Drawing.Point(663, 0);
            this.btnExceleDosyaGonder.Name = "btnExceleDosyaGonder";
            this.btnExceleDosyaGonder.Size = new System.Drawing.Size(162, 35);
            this.btnExceleDosyaGonder.TabIndex = 54;
            this.btnExceleDosyaGonder.Text = "Excel Dosyasını Oluştur";
            this.btnExceleDosyaGonder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExceleDosyaGonder.UseVisualStyleBackColor = false;
            this.btnExceleDosyaGonder.Click += new System.EventHandler(this.btnExceleDosyaGonder_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgUrunListesi1);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgUrunListesi2);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(825, 475);
            this.splitContainer1.SplitterDistance = 412;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgUrunListesi1
            // 
            this.dgUrunListesi1.AllowUserToAddRows = false;
            this.dgUrunListesi1.AllowUserToDeleteRows = false;
            this.dgUrunListesi1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgUrunListesi1.ColumnHeadersHeight = 20;
            this.dgUrunListesi1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgUrunListesi1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stokid1,
            this.stokKodu,
            this.urunAdi1,
            this.birimFiyat1,
            this.btnEkle});
            this.dgUrunListesi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgUrunListesi1.Location = new System.Drawing.Point(0, 96);
            this.dgUrunListesi1.MultiSelect = false;
            this.dgUrunListesi1.Name = "dgUrunListesi1";
            this.dgUrunListesi1.ReadOnly = true;
            this.dgUrunListesi1.RowHeadersWidth = 20;
            this.dgUrunListesi1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUrunListesi1.Size = new System.Drawing.Size(412, 379);
            this.dgUrunListesi1.TabIndex = 13;
            this.dgUrunListesi1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUrunListesi1_CellClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtUrunAdi);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 71);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(412, 25);
            this.panel3.TabIndex = 16;
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.BackColor = System.Drawing.Color.White;
            this.txtUrunAdi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUrunAdi.ForeColor = System.Drawing.Color.Black;
            this.txtUrunAdi.Location = new System.Drawing.Point(105, 0);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(307, 20);
            this.txtUrunAdi.TabIndex = 21;
            this.txtUrunAdi.Tag = "001";
            this.txtUrunAdi.TextChanged += new System.EventHandler(this.txtUrunAdi_TextChanged);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ürün Adına Göre Ara";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cmbKategori);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(412, 25);
            this.panel4.TabIndex = 17;
            // 
            // cmbKategori
            // 
            this.cmbKategori.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbKategori.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbKategori.BackColor = System.Drawing.Color.White;
            this.cmbKategori.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbKategori.ForeColor = System.Drawing.Color.Black;
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(105, 0);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(307, 21);
            this.cmbKategori.TabIndex = 19;
            this.cmbKategori.Tag = "001";
            this.cmbKategori.SelectedIndexChanged += new System.EventHandler(this.cmbKategori_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Kategori";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbFiyatTuru);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(412, 25);
            this.panel2.TabIndex = 15;
            // 
            // cmbFiyatTuru
            // 
            this.cmbFiyatTuru.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFiyatTuru.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFiyatTuru.BackColor = System.Drawing.Color.White;
            this.cmbFiyatTuru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFiyatTuru.ForeColor = System.Drawing.Color.Black;
            this.cmbFiyatTuru.FormattingEnabled = true;
            this.cmbFiyatTuru.Location = new System.Drawing.Point(105, 0);
            this.cmbFiyatTuru.Name = "cmbFiyatTuru";
            this.cmbFiyatTuru.Size = new System.Drawing.Size(307, 21);
            this.cmbFiyatTuru.TabIndex = 19;
            this.cmbFiyatTuru.Tag = "001";
            this.cmbFiyatTuru.SelectedIndexChanged += new System.EventHandler(this.cmbFiyatTuru_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fiyat Türü:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(412, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "Firma Ürün Listesi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgUrunListesi2
            // 
            this.dgUrunListesi2.AllowUserToAddRows = false;
            this.dgUrunListesi2.AllowUserToDeleteRows = false;
            this.dgUrunListesi2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgUrunListesi2.ColumnHeadersHeight = 20;
            this.dgUrunListesi2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgUrunListesi2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pluNo2,
            this.stokKodu1,
            this.stokid2,
            this.urunAdi2,
            this.birimFiyat2,
            this.btnCikar});
            this.dgUrunListesi2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgUrunListesi2.Location = new System.Drawing.Point(0, 21);
            this.dgUrunListesi2.MultiSelect = false;
            this.dgUrunListesi2.Name = "dgUrunListesi2";
            this.dgUrunListesi2.RowHeadersWidth = 20;
            this.dgUrunListesi2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUrunListesi2.Size = new System.Drawing.Size(409, 454);
            this.dgUrunListesi2.TabIndex = 16;
            this.dgUrunListesi2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUrunListesi2_CellClick);
            this.dgUrunListesi2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUrunListesi2_CellEndEdit);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(409, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "Teraziye Gönderilecek Ürün Listesi";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnTxt
            // 
            this.btnTxt.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnTxt.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTxt.Image = global::Elmar_Ticari_Plus.Properties.Resources.excel_icon__1_;
            this.btnTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTxt.Location = new System.Drawing.Point(501, 0);
            this.btnTxt.Name = "btnTxt";
            this.btnTxt.Size = new System.Drawing.Size(162, 35);
            this.btnTxt.TabIndex = 55;
            this.btnTxt.Text = "Text Dosyasını Oluştur";
            this.btnTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTxt.UseVisualStyleBackColor = false;
            this.btnTxt.Click += new System.EventHandler(this.btnTxt_Click);
            // 
            // stokid1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.stokid1.DefaultCellStyle = dataGridViewCellStyle1;
            this.stokid1.HeaderText = "Stok ID";
            this.stokid1.Name = "stokid1";
            this.stokid1.ReadOnly = true;
            this.stokid1.Width = 68;
            // 
            // stokKodu
            // 
            this.stokKodu.HeaderText = "Stok Kodu";
            this.stokKodu.Name = "stokKodu";
            this.stokKodu.ReadOnly = true;
            this.stokKodu.Width = 82;
            // 
            // urunAdi1
            // 
            this.urunAdi1.HeaderText = "Ürün Adı";
            this.urunAdi1.Name = "urunAdi1";
            this.urunAdi1.ReadOnly = true;
            this.urunAdi1.Width = 73;
            // 
            // birimFiyat1
            // 
            this.birimFiyat1.HeaderText = "Birim Fiyat";
            this.birimFiyat1.Name = "birimFiyat1";
            this.birimFiyat1.ReadOnly = true;
            this.birimFiyat1.Width = 79;
            // 
            // btnEkle
            // 
            this.btnEkle.HeaderText = "";
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.ReadOnly = true;
            this.btnEkle.Width = 5;
            // 
            // pluNo2
            // 
            this.pluNo2.HeaderText = "PLU No";
            this.pluNo2.Name = "pluNo2";
            this.pluNo2.Width = 70;
            // 
            // stokKodu1
            // 
            this.stokKodu1.HeaderText = "Stok Kodu";
            this.stokKodu1.Name = "stokKodu1";
            this.stokKodu1.Width = 82;
            // 
            // stokid2
            // 
            this.stokid2.HeaderText = "Stok ID";
            this.stokid2.Name = "stokid2";
            this.stokid2.ReadOnly = true;
            this.stokid2.Width = 68;
            // 
            // urunAdi2
            // 
            this.urunAdi2.HeaderText = "Ürün Adı";
            this.urunAdi2.Name = "urunAdi2";
            this.urunAdi2.Width = 73;
            // 
            // birimFiyat2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.birimFiyat2.DefaultCellStyle = dataGridViewCellStyle2;
            this.birimFiyat2.HeaderText = "Birim Fiyat";
            this.birimFiyat2.Name = "birimFiyat2";
            this.birimFiyat2.Width = 79;
            // 
            // btnCikar
            // 
            this.btnCikar.HeaderText = "";
            this.btnCikar.Name = "btnCikar";
            this.btnCikar.Width = 5;
            // 
            // frmTeraziyeStokGonder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 510);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "frmTeraziyeStokGonder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Traziye Ürün Aktarım Modülü";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTeraziyeStokGonder_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUrunListesi1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUrunListesi2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.DataGridView dgUrunListesi1;
        private System.Windows.Forms.Button btnExceleDosyaGonder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dgUrunListesi2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFiyatTuru;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn urunAdi1;
        private System.Windows.Forms.DataGridViewTextBoxColumn birimFiyat1;
        private System.Windows.Forms.DataGridViewButtonColumn btnEkle;
        private System.Windows.Forms.DataGridViewTextBoxColumn pluNo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokKodu1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokid2;
        private System.Windows.Forms.DataGridViewTextBoxColumn urunAdi2;
        private System.Windows.Forms.DataGridViewTextBoxColumn birimFiyat2;
        private System.Windows.Forms.DataGridViewButtonColumn btnCikar;
    }
}