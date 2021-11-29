namespace Elmar_Ticari_Plus
{
    partial class frmBankaPosTaksitleriGoruntule
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBankaPosTaksitleriGoruntule));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlAna = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBonusCard = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnAxess = new System.Windows.Forms.Button();
            this.btnMaximumCard = new System.Windows.Forms.Button();
            this.btnCardFinans = new System.Windows.Forms.Button();
            this.btnHalkBank = new System.Windows.Forms.Button();
            this.btnTurkiyeFinans = new System.Windows.Forms.Button();
            this.btnWorldCard = new System.Windows.Forms.Button();
            this.btnKuveytTurk = new System.Windows.Forms.Button();
            this.btnBankAsya = new System.Windows.Forms.Button();
            this.btnHsbcAdvantage = new System.Windows.Forms.Button();
            this.btnDiger = new System.Windows.Forms.Button();
            this.dgTaksitOranlari = new System.Windows.Forms.DataGridView();
            this.posTaksitid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taksitSayisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taksitTutari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toplamTutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picSeciliPos = new System.Windows.Forms.PictureBox();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAcikHesapTutari = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNakit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtİslemTarihi = new System.Windows.Forms.DateTimePicker();
            this.cmbEKullanicilar = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbESubeler = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtAcklama = new System.Windows.Forms.TextBox();
            this.txtDovizKuru = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtDovizliTutar = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.txtDovizDegeri = new System.Windows.Forms.TextBox();
            this.cmbCariler = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.pnlAna.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTaksitOranlari)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSeciliPos)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAna
            // 
            this.pnlAna.AutoScroll = true;
            this.pnlAna.BackColor = System.Drawing.Color.Silver;
            this.pnlAna.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAna.Controls.Add(this.btnBonusCard);
            this.pnlAna.Controls.Add(this.btnAxess);
            this.pnlAna.Controls.Add(this.btnMaximumCard);
            this.pnlAna.Controls.Add(this.btnCardFinans);
            this.pnlAna.Controls.Add(this.btnHalkBank);
            this.pnlAna.Controls.Add(this.btnTurkiyeFinans);
            this.pnlAna.Controls.Add(this.btnWorldCard);
            this.pnlAna.Controls.Add(this.btnKuveytTurk);
            this.pnlAna.Controls.Add(this.btnBankAsya);
            this.pnlAna.Controls.Add(this.btnHsbcAdvantage);
            this.pnlAna.Controls.Add(this.btnDiger);
            this.pnlAna.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAna.Location = new System.Drawing.Point(0, 309);
            this.pnlAna.Name = "pnlAna";
            this.pnlAna.Size = new System.Drawing.Size(105, 143);
            this.pnlAna.TabIndex = 0;
            // 
            // btnBonusCard
            // 
            this.btnBonusCard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBonusCard.ImageKey = "bonus.png";
            this.btnBonusCard.ImageList = this.ımageList1;
            this.btnBonusCard.Location = new System.Drawing.Point(3, 3);
            this.btnBonusCard.Name = "btnBonusCard";
            this.btnBonusCard.Size = new System.Drawing.Size(80, 32);
            this.btnBonusCard.TabIndex = 1;
            this.btnBonusCard.Tag = "Bonus Card";
            this.btnBonusCard.UseVisualStyleBackColor = true;
            this.btnBonusCard.Visible = false;
            this.btnBonusCard.Click += new System.EventHandler(this.btnBonusCard_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "Advantage.png");
            this.ımageList1.Images.SetKeyName(1, "Axess.png");
            this.ımageList1.Images.SetKeyName(2, "bonus.png");
            this.ımageList1.Images.SetKeyName(3, "Card Finans.png");
            this.ımageList1.Images.SetKeyName(4, "Maximum.png");
            this.ımageList1.Images.SetKeyName(5, "World.png");
            this.ımageList1.Images.SetKeyName(6, "paraf.png");
            this.ımageList1.Images.SetKeyName(7, "ANADOLUBANKrenkli.jpg");
            this.ımageList1.Images.SetKeyName(8, "teb bonus.gif");
            this.ımageList1.Images.SetKeyName(9, "teb world.gif");
            this.ımageList1.Images.SetKeyName(10, "Türkiye Finanas.png");
            this.ımageList1.Images.SetKeyName(11, "kuveyt turk.png");
            this.ımageList1.Images.SetKeyName(12, "Bank Asya.jpg");
            this.ımageList1.Images.SetKeyName(13, "HSBC Advantage.png");
            this.ımageList1.Images.SetKeyName(14, "Vakıf Bank.jpg");
            this.ımageList1.Images.SetKeyName(15, "Denizbank Bonus.gif");
            this.ımageList1.Images.SetKeyName(16, "ing Bank.gif");
            // 
            // btnAxess
            // 
            this.btnAxess.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAxess.ImageKey = "Axess.png";
            this.btnAxess.ImageList = this.ımageList1;
            this.btnAxess.Location = new System.Drawing.Point(3, 41);
            this.btnAxess.Name = "btnAxess";
            this.btnAxess.Size = new System.Drawing.Size(80, 32);
            this.btnAxess.TabIndex = 2;
            this.btnAxess.Tag = "Axess";
            this.btnAxess.UseVisualStyleBackColor = true;
            this.btnAxess.Visible = false;
            this.btnAxess.Click += new System.EventHandler(this.btnBonusCard_Click);
            // 
            // btnMaximumCard
            // 
            this.btnMaximumCard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMaximumCard.ImageKey = "Maximum.png";
            this.btnMaximumCard.ImageList = this.ımageList1;
            this.btnMaximumCard.Location = new System.Drawing.Point(3, 79);
            this.btnMaximumCard.Name = "btnMaximumCard";
            this.btnMaximumCard.Size = new System.Drawing.Size(80, 32);
            this.btnMaximumCard.TabIndex = 3;
            this.btnMaximumCard.Tag = "Maximum Card";
            this.btnMaximumCard.UseVisualStyleBackColor = true;
            this.btnMaximumCard.Visible = false;
            this.btnMaximumCard.Click += new System.EventHandler(this.btnBonusCard_Click);
            // 
            // btnCardFinans
            // 
            this.btnCardFinans.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCardFinans.ImageKey = "Card Finans.png";
            this.btnCardFinans.ImageList = this.ımageList1;
            this.btnCardFinans.Location = new System.Drawing.Point(3, 117);
            this.btnCardFinans.Name = "btnCardFinans";
            this.btnCardFinans.Size = new System.Drawing.Size(80, 32);
            this.btnCardFinans.TabIndex = 5;
            this.btnCardFinans.Tag = "Card Finans";
            this.btnCardFinans.UseVisualStyleBackColor = true;
            this.btnCardFinans.Visible = false;
            this.btnCardFinans.Click += new System.EventHandler(this.btnBonusCard_Click);
            // 
            // btnHalkBank
            // 
            this.btnHalkBank.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHalkBank.ImageKey = "paraf.png";
            this.btnHalkBank.ImageList = this.ımageList1;
            this.btnHalkBank.Location = new System.Drawing.Point(3, 155);
            this.btnHalkBank.Name = "btnHalkBank";
            this.btnHalkBank.Size = new System.Drawing.Size(80, 32);
            this.btnHalkBank.TabIndex = 6;
            this.btnHalkBank.Tag = "Paraf";
            this.btnHalkBank.UseVisualStyleBackColor = true;
            this.btnHalkBank.Visible = false;
            this.btnHalkBank.Click += new System.EventHandler(this.btnBonusCard_Click);
            // 
            // btnTurkiyeFinans
            // 
            this.btnTurkiyeFinans.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTurkiyeFinans.ImageKey = "Türkiye Finanas.png";
            this.btnTurkiyeFinans.ImageList = this.ımageList1;
            this.btnTurkiyeFinans.Location = new System.Drawing.Point(3, 193);
            this.btnTurkiyeFinans.Name = "btnTurkiyeFinans";
            this.btnTurkiyeFinans.Size = new System.Drawing.Size(80, 32);
            this.btnTurkiyeFinans.TabIndex = 8;
            this.btnTurkiyeFinans.Tag = "Türkiye Finans";
            this.btnTurkiyeFinans.UseVisualStyleBackColor = true;
            this.btnTurkiyeFinans.Visible = false;
            this.btnTurkiyeFinans.Click += new System.EventHandler(this.btnBonusCard_Click);
            // 
            // btnWorldCard
            // 
            this.btnWorldCard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnWorldCard.ImageKey = "World.png";
            this.btnWorldCard.ImageList = this.ımageList1;
            this.btnWorldCard.Location = new System.Drawing.Point(3, 231);
            this.btnWorldCard.Name = "btnWorldCard";
            this.btnWorldCard.Size = new System.Drawing.Size(80, 32);
            this.btnWorldCard.TabIndex = 10;
            this.btnWorldCard.Tag = "World Card";
            this.btnWorldCard.UseVisualStyleBackColor = true;
            this.btnWorldCard.Visible = false;
            this.btnWorldCard.Click += new System.EventHandler(this.btnBonusCard_Click);
            // 
            // btnKuveytTurk
            // 
            this.btnKuveytTurk.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnKuveytTurk.ImageKey = "kuveyt turk.png";
            this.btnKuveytTurk.ImageList = this.ımageList1;
            this.btnKuveytTurk.Location = new System.Drawing.Point(3, 269);
            this.btnKuveytTurk.Name = "btnKuveytTurk";
            this.btnKuveytTurk.Size = new System.Drawing.Size(80, 32);
            this.btnKuveytTurk.TabIndex = 11;
            this.btnKuveytTurk.Tag = "Kuveyt Türk";
            this.btnKuveytTurk.UseVisualStyleBackColor = true;
            this.btnKuveytTurk.Visible = false;
            this.btnKuveytTurk.Click += new System.EventHandler(this.btnBonusCard_Click);
            // 
            // btnBankAsya
            // 
            this.btnBankAsya.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBankAsya.ImageKey = "Bank Asya.jpg";
            this.btnBankAsya.ImageList = this.ımageList1;
            this.btnBankAsya.Location = new System.Drawing.Point(3, 307);
            this.btnBankAsya.Name = "btnBankAsya";
            this.btnBankAsya.Size = new System.Drawing.Size(80, 32);
            this.btnBankAsya.TabIndex = 12;
            this.btnBankAsya.Tag = "Asya Card";
            this.btnBankAsya.UseVisualStyleBackColor = true;
            this.btnBankAsya.Visible = false;
            this.btnBankAsya.Click += new System.EventHandler(this.btnBonusCard_Click);
            // 
            // btnHsbcAdvantage
            // 
            this.btnHsbcAdvantage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHsbcAdvantage.ImageKey = "HSBC Advantage.png";
            this.btnHsbcAdvantage.ImageList = this.ımageList1;
            this.btnHsbcAdvantage.Location = new System.Drawing.Point(3, 345);
            this.btnHsbcAdvantage.Name = "btnHsbcAdvantage";
            this.btnHsbcAdvantage.Size = new System.Drawing.Size(80, 32);
            this.btnHsbcAdvantage.TabIndex = 13;
            this.btnHsbcAdvantage.Tag = "Advantage";
            this.btnHsbcAdvantage.UseVisualStyleBackColor = true;
            this.btnHsbcAdvantage.Visible = false;
            this.btnHsbcAdvantage.Click += new System.EventHandler(this.btnBonusCard_Click);
            // 
            // btnDiger
            // 
            this.btnDiger.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDiger.ImageKey = "(none)";
            this.btnDiger.ImageList = this.ımageList1;
            this.btnDiger.Location = new System.Drawing.Point(3, 383);
            this.btnDiger.Name = "btnDiger";
            this.btnDiger.Size = new System.Drawing.Size(80, 32);
            this.btnDiger.TabIndex = 17;
            this.btnDiger.Tag = "12";
            this.btnDiger.Text = "Diğer";
            this.btnDiger.UseVisualStyleBackColor = true;
            this.btnDiger.Visible = false;
            this.btnDiger.Click += new System.EventHandler(this.btnBonusCard_Click);
            // 
            // dgTaksitOranlari
            // 
            this.dgTaksitOranlari.AllowUserToAddRows = false;
            this.dgTaksitOranlari.AllowUserToDeleteRows = false;
            this.dgTaksitOranlari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgTaksitOranlari.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.posTaksitid,
            this.taksitSayisi,
            this.taksitTutari,
            this.toplamTutar});
            this.dgTaksitOranlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTaksitOranlari.Location = new System.Drawing.Point(105, 309);
            this.dgTaksitOranlari.MultiSelect = false;
            this.dgTaksitOranlari.Name = "dgTaksitOranlari";
            this.dgTaksitOranlari.ReadOnly = true;
            this.dgTaksitOranlari.RowHeadersWidth = 20;
            this.dgTaksitOranlari.RowTemplate.Height = 21;
            this.dgTaksitOranlari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTaksitOranlari.Size = new System.Drawing.Size(283, 143);
            this.dgTaksitOranlari.TabIndex = 1;
            // 
            // posTaksitid
            // 
            this.posTaksitid.HeaderText = "posTaksitid";
            this.posTaksitid.Name = "posTaksitid";
            this.posTaksitid.ReadOnly = true;
            this.posTaksitid.Visible = false;
            // 
            // taksitSayisi
            // 
            this.taksitSayisi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.taksitSayisi.HeaderText = "Taksit";
            this.taksitSayisi.Name = "taksitSayisi";
            this.taksitSayisi.ReadOnly = true;
            this.taksitSayisi.Width = 61;
            // 
            // taksitTutari
            // 
            this.taksitTutari.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.taksitTutari.DefaultCellStyle = dataGridViewCellStyle5;
            this.taksitTutari.HeaderText = "Taksit Tutarı";
            this.taksitTutari.Name = "taksitTutari";
            this.taksitTutari.ReadOnly = true;
            // 
            // toplamTutar
            // 
            this.toplamTutar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.toplamTutar.DefaultCellStyle = dataGridViewCellStyle6;
            this.toplamTutar.HeaderText = "Toplam Tutar";
            this.toplamTutar.Name = "toplamTutar";
            this.toplamTutar.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.picSeciliPos);
            this.panel1.Controls.Add(this.lblBaslik);
            this.panel1.Location = new System.Drawing.Point(556, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 63);
            this.panel1.TabIndex = 2;
            // 
            // picSeciliPos
            // 
            this.picSeciliPos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSeciliPos.Location = new System.Drawing.Point(0, 5);
            this.picSeciliPos.Name = "picSeciliPos";
            this.picSeciliPos.Size = new System.Drawing.Size(72, 26);
            this.picSeciliPos.TabIndex = 0;
            this.picSeciliPos.TabStop = false;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.ForeColor = System.Drawing.Color.Black;
            this.lblBaslik.Location = new System.Drawing.Point(72, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(218, 32);
            this.lblBaslik.TabIndex = 1;
            this.lblBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtAcikHesapTutari);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtNakit);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.dtİslemTarihi);
            this.panel3.Controls.Add(this.cmbEKullanicilar);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cmbESubeler);
            this.panel3.Controls.Add(this.label39);
            this.panel3.Controls.Add(this.txtAcklama);
            this.panel3.Controls.Add(this.txtDovizKuru);
            this.panel3.Controls.Add(this.label45);
            this.panel3.Controls.Add(this.txtTutar);
            this.panel3.Controls.Add(this.label43);
            this.panel3.Controls.Add(this.txtDovizliTutar);
            this.panel3.Controls.Add(this.label42);
            this.panel3.Controls.Add(this.label41);
            this.panel3.Controls.Add(this.txtDovizDegeri);
            this.panel3.Controls.Add(this.cmbCariler);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(388, 309);
            this.panel3.TabIndex = 5;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(4, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "A. H. Aktarılacak";
            // 
            // txtAcikHesapTutari
            // 
            this.txtAcikHesapTutari.BackColor = System.Drawing.Color.White;
            this.txtAcikHesapTutari.Enabled = false;
            this.txtAcikHesapTutari.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAcikHesapTutari.ForeColor = System.Drawing.Color.Black;
            this.txtAcikHesapTutari.Location = new System.Drawing.Point(109, 78);
            this.txtAcikHesapTutari.Name = "txtAcikHesapTutari";
            this.txtAcikHesapTutari.Size = new System.Drawing.Size(115, 22);
            this.txtAcikHesapTutari.TabIndex = 25;
            this.txtAcikHesapTutari.Tag = "221";
            this.txtAcikHesapTutari.Text = "0";
            this.txtAcikHesapTutari.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(4, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Peşin";
            // 
            // txtNakit
            // 
            this.txtNakit.BackColor = System.Drawing.Color.White;
            this.txtNakit.Enabled = false;
            this.txtNakit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtNakit.ForeColor = System.Drawing.Color.Black;
            this.txtNakit.Location = new System.Drawing.Point(109, 56);
            this.txtNakit.Name = "txtNakit";
            this.txtNakit.Size = new System.Drawing.Size(115, 22);
            this.txtNakit.TabIndex = 23;
            this.txtNakit.Tag = "221";
            this.txtNakit.Text = "0";
            this.txtNakit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNakit.TextChanged += new System.EventHandler(this.txtNakit_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(4, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "İşlem Tarihi";
            // 
            // dtİslemTarihi
            // 
            this.dtİslemTarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtİslemTarihi.Location = new System.Drawing.Point(109, 169);
            this.dtİslemTarihi.Name = "dtİslemTarihi";
            this.dtİslemTarihi.Size = new System.Drawing.Size(269, 21);
            this.dtİslemTarihi.TabIndex = 7;
            this.dtİslemTarihi.Tag = "001";
            // 
            // cmbEKullanicilar
            // 
            this.cmbEKullanicilar.BackColor = System.Drawing.Color.White;
            this.cmbEKullanicilar.ForeColor = System.Drawing.Color.Black;
            this.cmbEKullanicilar.FormattingEnabled = true;
            this.cmbEKullanicilar.Location = new System.Drawing.Point(224, 283);
            this.cmbEKullanicilar.Name = "cmbEKullanicilar";
            this.cmbEKullanicilar.Size = new System.Drawing.Size(155, 21);
            this.cmbEKullanicilar.TabIndex = 10;
            this.cmbEKullanicilar.TabStop = false;
            this.cmbEKullanicilar.Tag = "001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(4, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "Şube - Kullanıcı";
            // 
            // cmbESubeler
            // 
            this.cmbESubeler.BackColor = System.Drawing.Color.White;
            this.cmbESubeler.ForeColor = System.Drawing.Color.Black;
            this.cmbESubeler.FormattingEnabled = true;
            this.cmbESubeler.Location = new System.Drawing.Point(109, 283);
            this.cmbESubeler.Name = "cmbESubeler";
            this.cmbESubeler.Size = new System.Drawing.Size(115, 21);
            this.cmbESubeler.TabIndex = 9;
            this.cmbESubeler.TabStop = false;
            this.cmbESubeler.Tag = "001";
            this.cmbESubeler.SelectedIndexChanged += new System.EventHandler(this.cmbESubeler_SelectedIndexChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label39.ForeColor = System.Drawing.Color.DarkRed;
            this.label39.Location = new System.Drawing.Point(4, 195);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(57, 15);
            this.label39.TabIndex = 22;
            this.label39.Text = "Açıklama";
            // 
            // txtAcklama
            // 
            this.txtAcklama.BackColor = System.Drawing.Color.White;
            this.txtAcklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAcklama.ForeColor = System.Drawing.Color.Black;
            this.txtAcklama.Location = new System.Drawing.Point(109, 192);
            this.txtAcklama.Multiline = true;
            this.txtAcklama.Name = "txtAcklama";
            this.txtAcklama.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAcklama.Size = new System.Drawing.Size(269, 89);
            this.txtAcklama.TabIndex = 8;
            this.txtAcklama.Tag = "001";
            // 
            // txtDovizKuru
            // 
            this.txtDovizKuru.BackColor = System.Drawing.Color.White;
            this.txtDovizKuru.ForeColor = System.Drawing.Color.Black;
            this.txtDovizKuru.FormattingEnabled = true;
            this.txtDovizKuru.Items.AddRange(new object[] {
            "TL",
            "USD",
            "EURO"});
            this.txtDovizKuru.Location = new System.Drawing.Point(109, 102);
            this.txtDovizKuru.Name = "txtDovizKuru";
            this.txtDovizKuru.Size = new System.Drawing.Size(115, 21);
            this.txtDovizKuru.TabIndex = 4;
            this.txtDovizKuru.Tag = "001";
            this.txtDovizKuru.Text = "TL";
            this.txtDovizKuru.SelectedIndexChanged += new System.EventHandler(this.txtDovizKuru_SelectedIndexChanged);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label45.ForeColor = System.Drawing.Color.DarkRed;
            this.label45.Location = new System.Drawing.Point(4, 37);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(91, 15);
            this.label45.TabIndex = 9;
            this.label45.Text = "Çekilecek Tutar";
            // 
            // txtTutar
            // 
            this.txtTutar.BackColor = System.Drawing.Color.White;
            this.txtTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTutar.ForeColor = System.Drawing.Color.Black;
            this.txtTutar.Location = new System.Drawing.Point(109, 34);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(115, 22);
            this.txtTutar.TabIndex = 2;
            this.txtTutar.Tag = "221";
            this.txtTutar.Text = "0";
            this.txtTutar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTutar.TextChanged += new System.EventHandler(this.txtTutar_TextChanged);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label43.ForeColor = System.Drawing.Color.DarkRed;
            this.label43.Location = new System.Drawing.Point(4, 148);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(74, 15);
            this.label43.TabIndex = 10;
            this.label43.Text = "Dovizli Tutar";
            // 
            // txtDovizliTutar
            // 
            this.txtDovizliTutar.BackColor = System.Drawing.Color.White;
            this.txtDovizliTutar.Enabled = false;
            this.txtDovizliTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDovizliTutar.ForeColor = System.Drawing.Color.Black;
            this.txtDovizliTutar.Location = new System.Drawing.Point(109, 145);
            this.txtDovizliTutar.Name = "txtDovizliTutar";
            this.txtDovizliTutar.ReadOnly = true;
            this.txtDovizliTutar.Size = new System.Drawing.Size(115, 22);
            this.txtDovizliTutar.TabIndex = 6;
            this.txtDovizliTutar.Tag = "001";
            this.txtDovizliTutar.Text = "0";
            this.txtDovizliTutar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDovizliTutar.TextChanged += new System.EventHandler(this.txtDovizliTutar_TextChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label42.ForeColor = System.Drawing.Color.DarkRed;
            this.label42.Location = new System.Drawing.Point(4, 126);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(66, 15);
            this.label42.TabIndex = 11;
            this.label42.Text = "Döviz Kuru";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label41.ForeColor = System.Drawing.Color.DarkRed;
            this.label41.Location = new System.Drawing.Point(4, 105);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(37, 15);
            this.label41.TabIndex = 12;
            this.label41.Text = "Doviz";
            // 
            // txtDovizDegeri
            // 
            this.txtDovizDegeri.BackColor = System.Drawing.Color.White;
            this.txtDovizDegeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDovizDegeri.ForeColor = System.Drawing.Color.Black;
            this.txtDovizDegeri.Location = new System.Drawing.Point(109, 123);
            this.txtDovizDegeri.Name = "txtDovizDegeri";
            this.txtDovizDegeri.Size = new System.Drawing.Size(115, 22);
            this.txtDovizDegeri.TabIndex = 5;
            this.txtDovizDegeri.Tag = "221";
            this.txtDovizDegeri.Text = "1";
            this.txtDovizDegeri.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDovizDegeri.TextChanged += new System.EventHandler(this.txtDovizDegeri_TextChanged);
            // 
            // cmbCariler
            // 
            this.cmbCariler.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCariler.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCariler.BackColor = System.Drawing.Color.White;
            this.cmbCariler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCariler.ForeColor = System.Drawing.Color.Black;
            this.cmbCariler.FormattingEnabled = true;
            this.cmbCariler.Location = new System.Drawing.Point(72, 3);
            this.cmbCariler.Name = "cmbCariler";
            this.cmbCariler.Size = new System.Drawing.Size(306, 24);
            this.cmbCariler.TabIndex = 1;
            this.cmbCariler.Tag = "001";
            this.cmbCariler.SelectedIndexChanged += new System.EventHandler(this.cmbCariler_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(4, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Cari Seçimi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-87, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(547, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "_________________________________________________________________________________" +
    "_________";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnKaydet);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 452);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(388, 32);
            this.panel2.TabIndex = 11;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Location = new System.Drawing.Point(308, 0);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(81, 32);
            this.btnKaydet.TabIndex = 12;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // frmBankaPosTaksitleriGoruntule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(388, 484);
            this.Controls.Add(this.dgTaksitOranlari);
            this.Controls.Add(this.pnlAna);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmBankaPosTaksitleriGoruntule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Pos Taksitlerini Görüntüle";
            this.Load += new System.EventHandler(this.frmBankaPosTaksitleriGoruntule_Load);
            this.pnlAna.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTaksitOranlari)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSeciliPos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlAna;
        private System.Windows.Forms.Button btnBonusCard;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Button btnAxess;
        private System.Windows.Forms.Button btnMaximumCard;
        private System.Windows.Forms.Button btnCardFinans;
        private System.Windows.Forms.Button btnHalkBank;
        private System.Windows.Forms.Button btnTurkiyeFinans;
        private System.Windows.Forms.Button btnWorldCard;
        private System.Windows.Forms.Button btnKuveytTurk;
        private System.Windows.Forms.Button btnBankAsya;
        private System.Windows.Forms.Button btnHsbcAdvantage;
        private System.Windows.Forms.DataGridView dgTaksitOranlari;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.PictureBox picSeciliPos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnDiger;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbCariler;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox txtDovizKuru;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txtTutar;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtDovizliTutar;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtDovizDegeri;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtİslemTarihi;
        private System.Windows.Forms.ComboBox cmbEKullanicilar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbESubeler;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtAcklama;
        private System.Windows.Forms.DataGridViewTextBoxColumn posTaksitid;
        private System.Windows.Forms.DataGridViewTextBoxColumn taksitSayisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn taksitTutari;
        private System.Windows.Forms.DataGridViewTextBoxColumn toplamTutar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNakit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAcikHesapTutari;
    }
}