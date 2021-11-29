namespace Elmar_Ticari_Plus
{
    partial class frmCekSenetEkle
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
            this.pnlCari = new System.Windows.Forms.Panel();
            this.cmbCariler = new System.Windows.Forms.ComboBox();
            this.btnCariAra = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCariEkle = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtVadeTarihi = new System.Windows.Forms.DateTimePicker();
            this.dtKayitTarihi = new System.Windows.Forms.DateTimePicker();
            this.txtSeriNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlCekNo = new System.Windows.Forms.Panel();
            this.txtCekSenetNo = new System.Windows.Forms.TextBox();
            this.lblCekSenetBaslik = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtTutari = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtDovizKuru = new System.Windows.Forms.TextBox();
            this.cmbDoviz = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtDovizliTutar = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtSube = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBanka = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgAlanHesap = new System.Windows.Forms.DataGridView();
            this.bankaHesapid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankaAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subeKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hesapAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hesapNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBanka = new System.Windows.Forms.GroupBox();
            this.pnlCari.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlCekNo.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAlanHesap)).BeginInit();
            this.pnlBanka.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCari
            // 
            this.pnlCari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCari.Controls.Add(this.cmbCariler);
            this.pnlCari.Controls.Add(this.btnCariAra);
            this.pnlCari.Controls.Add(this.label1);
            this.pnlCari.Controls.Add(this.btnCariEkle);
            this.pnlCari.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCari.Location = new System.Drawing.Point(0, 35);
            this.pnlCari.Name = "pnlCari";
            this.pnlCari.Size = new System.Drawing.Size(500, 33);
            this.pnlCari.TabIndex = 10;
            // 
            // cmbCariler
            // 
            this.cmbCariler.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCariler.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCariler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCariler.FormattingEnabled = true;
            this.cmbCariler.Location = new System.Drawing.Point(60, 4);
            this.cmbCariler.Name = "cmbCariler";
            this.cmbCariler.Size = new System.Drawing.Size(388, 23);
            this.cmbCariler.TabIndex = 3;
            this.cmbCariler.SelectedIndexChanged += new System.EventHandler(this.cmbCariler_SelectedIndexChanged);
            // 
            // btnCariAra
            // 
            this.btnCariAra.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCariAra.Location = new System.Drawing.Point(449, 3);
            this.btnCariAra.Name = "btnCariAra";
            this.btnCariAra.Size = new System.Drawing.Size(24, 23);
            this.btnCariAra.TabIndex = 6;
            this.btnCariAra.Text = "...";
            this.btnCariAra.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cari Seçimi";
            // 
            // btnCariEkle
            // 
            this.btnCariEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCariEkle.Image = global::Elmar_Ticari_Plus.Properties.Resources.genelEkle;
            this.btnCariEkle.Location = new System.Drawing.Point(473, 3);
            this.btnCariEkle.Name = "btnCariEkle";
            this.btnCariEkle.Size = new System.Drawing.Size(23, 23);
            this.btnCariEkle.TabIndex = 5;
            this.btnCariEkle.UseVisualStyleBackColor = false;
            this.btnCariEkle.Click += new System.EventHandler(this.btnCariEkle_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblBaslik);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 35);
            this.panel1.TabIndex = 9;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.Location = new System.Drawing.Point(35, 8);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(120, 20);
            this.lblBaslik.TabIndex = 1;
            this.lblBaslik.Text = "Çek-Senet Ekle";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::Elmar_Ticari_Plus.Properties.Resources.ksenet1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtVadeTarihi);
            this.groupBox2.Controls.Add(this.dtKayitTarihi);
            this.groupBox2.Location = new System.Drawing.Point(245, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 63);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tarihler";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Vâde Tarihi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Kayıt Tarihi";
            // 
            // dtVadeTarihi
            // 
            this.dtVadeTarihi.Location = new System.Drawing.Point(69, 37);
            this.dtVadeTarihi.Name = "dtVadeTarihi";
            this.dtVadeTarihi.Size = new System.Drawing.Size(178, 20);
            this.dtVadeTarihi.TabIndex = 18;
            // 
            // dtKayitTarihi
            // 
            this.dtKayitTarihi.Location = new System.Drawing.Point(69, 15);
            this.dtKayitTarihi.Name = "dtKayitTarihi";
            this.dtKayitTarihi.Size = new System.Drawing.Size(178, 20);
            this.dtKayitTarihi.TabIndex = 17;
            // 
            // txtSeriNo
            // 
            this.txtSeriNo.Location = new System.Drawing.Point(74, 3);
            this.txtSeriNo.Name = "txtSeriNo";
            this.txtSeriNo.Size = new System.Drawing.Size(147, 20);
            this.txtSeriNo.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Seri No";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.pnlCekNo);
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Controls.Add(this.panel7);
            this.flowLayoutPanel1.Controls.Add(this.panel8);
            this.flowLayoutPanel1.Controls.Add(this.panel9);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(14, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(225, 186);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSeriNo);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 26);
            this.panel2.TabIndex = 17;
            // 
            // pnlCekNo
            // 
            this.pnlCekNo.Controls.Add(this.txtCekSenetNo);
            this.pnlCekNo.Controls.Add(this.lblCekSenetBaslik);
            this.pnlCekNo.Location = new System.Drawing.Point(0, 26);
            this.pnlCekNo.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCekNo.Name = "pnlCekNo";
            this.pnlCekNo.Size = new System.Drawing.Size(224, 26);
            this.pnlCekNo.TabIndex = 18;
            this.pnlCekNo.Visible = false;
            // 
            // txtCekSenetNo
            // 
            this.txtCekSenetNo.Location = new System.Drawing.Point(74, 3);
            this.txtCekSenetNo.Name = "txtCekSenetNo";
            this.txtCekSenetNo.Size = new System.Drawing.Size(147, 20);
            this.txtCekSenetNo.TabIndex = 0;
            // 
            // lblCekSenetBaslik
            // 
            this.lblCekSenetBaslik.AutoSize = true;
            this.lblCekSenetBaslik.Location = new System.Drawing.Point(5, 6);
            this.lblCekSenetBaslik.Name = "lblCekSenetBaslik";
            this.lblCekSenetBaslik.Size = new System.Drawing.Size(43, 13);
            this.lblCekSenetBaslik.TabIndex = 13;
            this.lblCekSenetBaslik.Text = "Çek No";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtTutari);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Location = new System.Drawing.Point(0, 52);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(224, 26);
            this.panel6.TabIndex = 20;
            // 
            // txtTutari
            // 
            this.txtTutari.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTutari.Location = new System.Drawing.Point(74, 3);
            this.txtTutari.Name = "txtTutari";
            this.txtTutari.Size = new System.Drawing.Size(147, 21);
            this.txtTutari.TabIndex = 0;
            this.txtTutari.Tag = "221";
            this.txtTutari.Text = "0";
            this.txtTutari.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTutari.TextChanged += new System.EventHandler(this.txtTutari_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Tutarı";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtDovizKuru);
            this.panel7.Controls.Add(this.cmbDoviz);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Location = new System.Drawing.Point(0, 78);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(224, 26);
            this.panel7.TabIndex = 21;
            // 
            // txtDovizKuru
            // 
            this.txtDovizKuru.Location = new System.Drawing.Point(143, 3);
            this.txtDovizKuru.Name = "txtDovizKuru";
            this.txtDovizKuru.Size = new System.Drawing.Size(78, 20);
            this.txtDovizKuru.TabIndex = 14;
            this.txtDovizKuru.Tag = "221";
            this.txtDovizKuru.Text = "1";
            this.txtDovizKuru.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDovizKuru.TextChanged += new System.EventHandler(this.txtTutari_TextChanged);
            // 
            // cmbDoviz
            // 
            this.cmbDoviz.FormattingEnabled = true;
            this.cmbDoviz.Items.AddRange(new object[] {
            "TL",
            "USD",
            "Euro"});
            this.cmbDoviz.Location = new System.Drawing.Point(74, 3);
            this.cmbDoviz.Name = "cmbDoviz";
            this.cmbDoviz.Size = new System.Drawing.Size(69, 21);
            this.cmbDoviz.TabIndex = 14;
            this.cmbDoviz.Text = "TL";
            this.cmbDoviz.SelectedIndexChanged += new System.EventHandler(this.cmbDoviz_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Doviz";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtDovizliTutar);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Location = new System.Drawing.Point(0, 104);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(224, 26);
            this.panel8.TabIndex = 22;
            // 
            // txtDovizliTutar
            // 
            this.txtDovizliTutar.Location = new System.Drawing.Point(74, 3);
            this.txtDovizliTutar.Name = "txtDovizliTutar";
            this.txtDovizliTutar.ReadOnly = true;
            this.txtDovizliTutar.Size = new System.Drawing.Size(147, 20);
            this.txtDovizliTutar.TabIndex = 14;
            this.txtDovizliTutar.Text = "0";
            this.txtDovizliTutar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Dovizli Tutar";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.txtSube);
            this.panel9.Controls.Add(this.label5);
            this.panel9.Controls.Add(this.cmbBanka);
            this.panel9.Controls.Add(this.label4);
            this.panel9.Location = new System.Drawing.Point(0, 130);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(224, 51);
            this.panel9.TabIndex = 23;
            this.panel9.Visible = false;
            // 
            // txtSube
            // 
            this.txtSube.Location = new System.Drawing.Point(74, 26);
            this.txtSube.Name = "txtSube";
            this.txtSube.Size = new System.Drawing.Size(147, 20);
            this.txtSube.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Şube";
            // 
            // cmbBanka
            // 
            this.cmbBanka.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBanka.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBanka.FormattingEnabled = true;
            this.cmbBanka.Location = new System.Drawing.Point(74, 3);
            this.cmbBanka.Name = "cmbBanka";
            this.cmbBanka.Size = new System.Drawing.Size(147, 21);
            this.cmbBanka.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Banka";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtAciklama);
            this.groupBox3.Location = new System.Drawing.Point(245, 84);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(252, 114);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Açıklama";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAciklama.Location = new System.Drawing.Point(3, 16);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAciklama.Size = new System.Drawing.Size(246, 95);
            this.txtAciklama.TabIndex = 0;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(206, 3);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(104, 31);
            this.btnKaydet.TabIndex = 18;
            this.btnKaydet.Text = "Kaydet [F4]";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.flowLayoutPanel1);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 68);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(500, 203);
            this.panel4.TabIndex = 163;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnKaydet);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 269);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(500, 37);
            this.panel5.TabIndex = 28;
            // 
            // dgAlanHesap
            // 
            this.dgAlanHesap.AllowUserToAddRows = false;
            this.dgAlanHesap.AllowUserToDeleteRows = false;
            this.dgAlanHesap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgAlanHesap.ColumnHeadersHeight = 20;
            this.dgAlanHesap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgAlanHesap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bankaHesapid,
            this.bankaid,
            this.bankaAdi,
            this.subeKodu,
            this.hesapAdi,
            this.hesapNo});
            this.dgAlanHesap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAlanHesap.Location = new System.Drawing.Point(3, 16);
            this.dgAlanHesap.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.dgAlanHesap.MultiSelect = false;
            this.dgAlanHesap.Name = "dgAlanHesap";
            this.dgAlanHesap.ReadOnly = true;
            this.dgAlanHesap.RowHeadersWidth = 20;
            this.dgAlanHesap.RowTemplate.Height = 20;
            this.dgAlanHesap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAlanHesap.Size = new System.Drawing.Size(494, 0);
            this.dgAlanHesap.TabIndex = 31;
            this.dgAlanHesap.TabStop = false;
            // 
            // bankaHesapid
            // 
            this.bankaHesapid.HeaderText = "bankaHesapid";
            this.bankaHesapid.Name = "bankaHesapid";
            this.bankaHesapid.ReadOnly = true;
            this.bankaHesapid.Visible = false;
            this.bankaHesapid.Width = 101;
            // 
            // bankaid
            // 
            this.bankaid.HeaderText = "bankaid";
            this.bankaid.Name = "bankaid";
            this.bankaid.ReadOnly = true;
            this.bankaid.Visible = false;
            this.bankaid.Width = 70;
            // 
            // bankaAdi
            // 
            this.bankaAdi.HeaderText = "Banka-Şube";
            this.bankaAdi.Name = "bankaAdi";
            this.bankaAdi.ReadOnly = true;
            this.bankaAdi.Width = 91;
            // 
            // subeKodu
            // 
            this.subeKodu.HeaderText = "Şube Kodu";
            this.subeKodu.Name = "subeKodu";
            this.subeKodu.ReadOnly = true;
            this.subeKodu.Width = 85;
            // 
            // hesapAdi
            // 
            this.hesapAdi.HeaderText = "Hesap Adı";
            this.hesapAdi.Name = "hesapAdi";
            this.hesapAdi.ReadOnly = true;
            this.hesapAdi.Width = 81;
            // 
            // hesapNo
            // 
            this.hesapNo.HeaderText = "Hesap No";
            this.hesapNo.Name = "hesapNo";
            this.hesapNo.ReadOnly = true;
            this.hesapNo.Width = 80;
            // 
            // pnlBanka
            // 
            this.pnlBanka.Controls.Add(this.dgAlanHesap);
            this.pnlBanka.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBanka.Location = new System.Drawing.Point(0, 271);
            this.pnlBanka.Name = "pnlBanka";
            this.pnlBanka.Size = new System.Drawing.Size(500, 0);
            this.pnlBanka.TabIndex = 162;
            this.pnlBanka.TabStop = false;
            this.pnlBanka.Text = "Banka Hesabı Secimi";
            this.pnlBanka.Visible = false;
            // 
            // frmCekSenetEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(500, 306);
            this.Controls.Add(this.pnlBanka);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlCari);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmCekSenetEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Çek-Senet Ekle";
            this.Load += new System.EventHandler(this.frmCekSenetEkle_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCekSenetEkle_KeyDown);
            this.pnlCari.ResumeLayout(false);
            this.pnlCari.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlCekNo.ResumeLayout(false);
            this.pnlCekNo.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAlanHesap)).EndInit();
            this.pnlBanka.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCari;
        private System.Windows.Forms.Button btnCariAra;
        private System.Windows.Forms.ComboBox cmbCariler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCariEkle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtVadeTarihi;
        private System.Windows.Forms.DateTimePicker dtKayitTarihi;
        private System.Windows.Forms.TextBox txtSeriNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlCekNo;
        private System.Windows.Forms.TextBox txtCekSenetNo;
        private System.Windows.Forms.Label lblCekSenetBaslik;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtTutari;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox cmbDoviz;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtDovizliTutar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.TextBox txtDovizKuru;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbBanka;
        private System.Windows.Forms.TextBox txtSube;
        public System.Windows.Forms.DataGridView dgAlanHesap;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankaHesapid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankaAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn subeKodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn hesapAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn hesapNo;
        private System.Windows.Forms.GroupBox pnlBanka;
    }
}