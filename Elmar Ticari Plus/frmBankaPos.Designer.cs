namespace Elmar_Ticari_Plus
{
    partial class frmBankaPos
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yeniBankaTanımlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silmeİşleminiGeriAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.raporGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label70 = new System.Windows.Forms.Label();
            this.btnPosEkle = new System.Windows.Forms.Button();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.lblKayitSayisi3 = new System.Windows.Forms.Label();
            this.btnRaporGoruntule = new System.Windows.Forms.Button();
            this.dgBankaPos = new System.Windows.Forms.DataGridView();
            this.posid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankaHesapid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hesapAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ayrinti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label54 = new System.Windows.Forms.Label();
            this.grpBelgeNumarası = new System.Windows.Forms.GroupBox();
            this.txtPosAdi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAyrinti = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSilinenKayitlariGoster = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtTanimAdi = new System.Windows.Forms.TextBox();
            this.txtHesapAdi = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.pnlAlt = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgTaksitOranlari = new System.Windows.Forms.DataGridView();
            this.posTaksitid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taksitSayisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aylikOran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBankaPos)).BeginInit();
            this.panel12.SuspendLayout();
            this.grpBelgeNumarası.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.pnlAlt.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTaksitOranlari)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniBankaTanımlaToolStripMenuItem,
            this.toolStripSeparator1,
            this.düzenleToolStripMenuItem,
            this.silToolStripMenuItem,
            this.silmeİşleminiGeriAlToolStripMenuItem,
            this.toolStripSeparator2,
            this.raporGörüntüleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(186, 126);
            // 
            // yeniBankaTanımlaToolStripMenuItem
            // 
            this.yeniBankaTanımlaToolStripMenuItem.Name = "yeniBankaTanımlaToolStripMenuItem";
            this.yeniBankaTanımlaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.yeniBankaTanımlaToolStripMenuItem.Text = "Yeni Hesap Tanımla";
            this.yeniBankaTanımlaToolStripMenuItem.Click += new System.EventHandler(this.yeniBankaTanımlaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // silmeİşleminiGeriAlToolStripMenuItem
            // 
            this.silmeİşleminiGeriAlToolStripMenuItem.Name = "silmeİşleminiGeriAlToolStripMenuItem";
            this.silmeİşleminiGeriAlToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.silmeİşleminiGeriAlToolStripMenuItem.Text = "Silme İşlemini Geri Al";
            this.silmeİşleminiGeriAlToolStripMenuItem.Click += new System.EventHandler(this.silmeİşleminiGeriAlToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // raporGörüntüleToolStripMenuItem
            // 
            this.raporGörüntüleToolStripMenuItem.Name = "raporGörüntüleToolStripMenuItem";
            this.raporGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.raporGörüntüleToolStripMenuItem.Text = "Rapor Görüntüle";
            this.raporGörüntüleToolStripMenuItem.Click += new System.EventHandler(this.raporGörüntüleToolStripMenuItem_Click);
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.label70);
            this.panel16.Controls.Add(this.btnPosEkle);
            this.panel16.Controls.Add(this.btnSorgula);
            this.panel16.Controls.Add(this.lblKayitSayisi3);
            this.panel16.Controls.Add(this.btnRaporGoruntule);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(522, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(102, 101);
            this.panel16.TabIndex = 15;
            // 
            // label70
            // 
            this.label70.BackColor = System.Drawing.Color.White;
            this.label70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label70.Dock = System.Windows.Forms.DockStyle.Top;
            this.label70.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label70.Location = new System.Drawing.Point(0, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(100, 17);
            this.label70.TabIndex = 0;
            this.label70.Text = "Raporlama";
            this.label70.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPosEkle
            // 
            this.btnPosEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnPosEkle.Image = global::Elmar_Ticari_Plus.Properties.Resources.genelEkle;
            this.btnPosEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPosEkle.Location = new System.Drawing.Point(3, 62);
            this.btnPosEkle.Name = "btnPosEkle";
            this.btnPosEkle.Size = new System.Drawing.Size(95, 23);
            this.btnPosEkle.TabIndex = 53;
            this.btnPosEkle.Text = "Yeni Pos";
            this.btnPosEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPosEkle.UseVisualStyleBackColor = false;
            this.btnPosEkle.Click += new System.EventHandler(this.btnPosEkle_Click);
            // 
            // btnSorgula
            // 
            this.btnSorgula.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSorgula.Location = new System.Drawing.Point(3, 18);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(95, 23);
            this.btnSorgula.TabIndex = 52;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = false;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // lblKayitSayisi3
            // 
            this.lblKayitSayisi3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblKayitSayisi3.ForeColor = System.Drawing.Color.DarkRed;
            this.lblKayitSayisi3.Location = new System.Drawing.Point(0, 84);
            this.lblKayitSayisi3.Name = "lblKayitSayisi3";
            this.lblKayitSayisi3.Size = new System.Drawing.Size(100, 15);
            this.lblKayitSayisi3.TabIndex = 51;
            this.lblKayitSayisi3.Text = "Kayıt Sayısı:";
            // 
            // btnRaporGoruntule
            // 
            this.btnRaporGoruntule.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRaporGoruntule.Location = new System.Drawing.Point(3, 40);
            this.btnRaporGoruntule.Name = "btnRaporGoruntule";
            this.btnRaporGoruntule.Size = new System.Drawing.Size(95, 23);
            this.btnRaporGoruntule.TabIndex = 47;
            this.btnRaporGoruntule.Text = "Rapor Görüntüle";
            this.btnRaporGoruntule.UseVisualStyleBackColor = false;
            // 
            // dgBankaPos
            // 
            this.dgBankaPos.AllowUserToAddRows = false;
            this.dgBankaPos.AllowUserToDeleteRows = false;
            this.dgBankaPos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgBankaPos.ColumnHeadersHeight = 20;
            this.dgBankaPos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgBankaPos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.posid,
            this.bankaHesapid,
            this.hesapAdi,
            this.adi,
            this.posAdi,
            this.ayrinti});
            this.dgBankaPos.ContextMenuStrip = this.contextMenuStrip1;
            this.dgBankaPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBankaPos.Location = new System.Drawing.Point(0, 0);
            this.dgBankaPos.MultiSelect = false;
            this.dgBankaPos.Name = "dgBankaPos";
            this.dgBankaPos.ReadOnly = true;
            this.dgBankaPos.RowHeadersWidth = 20;
            this.dgBankaPos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBankaPos.Size = new System.Drawing.Size(540, 403);
            this.dgBankaPos.TabIndex = 9;
            this.dgBankaPos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBankaPos_CellClick);
            // 
            // posid
            // 
            this.posid.HeaderText = "posid";
            this.posid.Name = "posid";
            this.posid.ReadOnly = true;
            this.posid.Visible = false;
            this.posid.Width = 57;
            // 
            // bankaHesapid
            // 
            this.bankaHesapid.HeaderText = "bankaHesapid";
            this.bankaHesapid.Name = "bankaHesapid";
            this.bankaHesapid.ReadOnly = true;
            this.bankaHesapid.Visible = false;
            this.bankaHesapid.Width = 101;
            // 
            // hesapAdi
            // 
            this.hesapAdi.HeaderText = "Banka Hesap Adı";
            this.hesapAdi.Name = "hesapAdi";
            this.hesapAdi.ReadOnly = true;
            this.hesapAdi.Width = 115;
            // 
            // adi
            // 
            this.adi.HeaderText = "Tanım Adı";
            this.adi.Name = "adi";
            this.adi.ReadOnly = true;
            this.adi.Width = 79;
            // 
            // posAdi
            // 
            this.posAdi.HeaderText = "Pos Adı";
            this.posAdi.Name = "posAdi";
            this.posAdi.ReadOnly = true;
            this.posAdi.Width = 68;
            // 
            // ayrinti
            // 
            this.ayrinti.HeaderText = "Ayrıntı";
            this.ayrinti.Name = "ayrinti";
            this.ayrinti.ReadOnly = true;
            this.ayrinti.Width = 60;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.label54);
            this.panel12.Controls.Add(this.grpBelgeNumarası);
            this.panel12.Controls.Add(this.groupBox9);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(522, 101);
            this.panel12.TabIndex = 12;
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.White;
            this.label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label54.Dock = System.Windows.Forms.DockStyle.Top;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label54.Location = new System.Drawing.Point(0, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(520, 17);
            this.label54.TabIndex = 0;
            this.label54.Text = "Filtre Seçenekleri";
            this.label54.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grpBelgeNumarası
            // 
            this.grpBelgeNumarası.Controls.Add(this.txtPosAdi);
            this.grpBelgeNumarası.Controls.Add(this.label5);
            this.grpBelgeNumarası.Controls.Add(this.txtAyrinti);
            this.grpBelgeNumarası.Controls.Add(this.label2);
            this.grpBelgeNumarası.Controls.Add(this.chkSilinenKayitlariGoster);
            this.grpBelgeNumarası.Location = new System.Drawing.Point(264, 12);
            this.grpBelgeNumarası.Name = "grpBelgeNumarası";
            this.grpBelgeNumarası.Size = new System.Drawing.Size(251, 71);
            this.grpBelgeNumarası.TabIndex = 15;
            this.grpBelgeNumarası.TabStop = false;
            // 
            // txtPosAdi
            // 
            this.txtPosAdi.BackColor = System.Drawing.Color.White;
            this.txtPosAdi.ForeColor = System.Drawing.Color.Black;
            this.txtPosAdi.Location = new System.Drawing.Point(60, 10);
            this.txtPosAdi.Name = "txtPosAdi";
            this.txtPosAdi.Size = new System.Drawing.Size(184, 20);
            this.txtPosAdi.TabIndex = 8;
            this.txtPosAdi.Tag = "001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pos Adı";
            // 
            // txtAyrinti
            // 
            this.txtAyrinti.BackColor = System.Drawing.Color.White;
            this.txtAyrinti.ForeColor = System.Drawing.Color.Black;
            this.txtAyrinti.Location = new System.Drawing.Point(60, 32);
            this.txtAyrinti.Name = "txtAyrinti";
            this.txtAyrinti.Size = new System.Drawing.Size(184, 20);
            this.txtAyrinti.TabIndex = 9;
            this.txtAyrinti.Tag = "001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ayrıntı";
            // 
            // chkSilinenKayitlariGoster
            // 
            this.chkSilinenKayitlariGoster.AutoSize = true;
            this.chkSilinenKayitlariGoster.Location = new System.Drawing.Point(60, 53);
            this.chkSilinenKayitlariGoster.Name = "chkSilinenKayitlariGoster";
            this.chkSilinenKayitlariGoster.Size = new System.Drawing.Size(97, 17);
            this.chkSilinenKayitlariGoster.TabIndex = 15;
            this.chkSilinenKayitlariGoster.Text = "Silinmiş Kayıtlar";
            this.chkSilinenKayitlariGoster.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtTanimAdi);
            this.groupBox9.Controls.Add(this.txtHesapAdi);
            this.groupBox9.Controls.Add(this.label57);
            this.groupBox9.Controls.Add(this.label58);
            this.groupBox9.Location = new System.Drawing.Point(-1, 12);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(259, 73);
            this.groupBox9.TabIndex = 14;
            this.groupBox9.TabStop = false;
            // 
            // txtTanimAdi
            // 
            this.txtTanimAdi.BackColor = System.Drawing.Color.White;
            this.txtTanimAdi.ForeColor = System.Drawing.Color.Black;
            this.txtTanimAdi.Location = new System.Drawing.Point(69, 33);
            this.txtTanimAdi.Name = "txtTanimAdi";
            this.txtTanimAdi.Size = new System.Drawing.Size(184, 20);
            this.txtTanimAdi.TabIndex = 7;
            this.txtTanimAdi.Tag = "001";
            // 
            // txtHesapAdi
            // 
            this.txtHesapAdi.BackColor = System.Drawing.Color.White;
            this.txtHesapAdi.ForeColor = System.Drawing.Color.Black;
            this.txtHesapAdi.Location = new System.Drawing.Point(69, 10);
            this.txtHesapAdi.Name = "txtHesapAdi";
            this.txtHesapAdi.Size = new System.Drawing.Size(184, 20);
            this.txtHesapAdi.TabIndex = 6;
            this.txtHesapAdi.Tag = "001";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(9, 37);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(54, 13);
            this.label57.TabIndex = 2;
            this.label57.Text = "Tanım Adı";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(9, 13);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(56, 13);
            this.label58.TabIndex = 1;
            this.label58.Text = "Hesap Adı";
            // 
            // pnlAlt
            // 
            this.pnlAlt.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlAlt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlt.Controls.Add(this.panel16);
            this.pnlAlt.Controls.Add(this.panel12);
            this.pnlAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlt.Location = new System.Drawing.Point(0, 403);
            this.pnlAlt.Name = "pnlAlt";
            this.pnlAlt.Size = new System.Drawing.Size(711, 103);
            this.pnlAlt.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgTaksitOranlari);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(540, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 403);
            this.panel1.TabIndex = 11;
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
            this.dgTaksitOranlari.Size = new System.Drawing.Size(169, 381);
            this.dgTaksitOranlari.TabIndex = 10;
            this.dgTaksitOranlari.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTaksitOranlari_CellEndEdit);
            // 
            // posTaksitid
            // 
            this.posTaksitid.HeaderText = "posTaksitid";
            this.posTaksitid.Name = "posTaksitid";
            this.posTaksitid.Visible = false;
            // 
            // taksitSayisi
            // 
            this.taksitSayisi.HeaderText = "Taksit Sayısı";
            this.taksitSayisi.Name = "taksitSayisi";
            this.taksitSayisi.ReadOnly = true;
            // 
            // aylikOran
            // 
            this.aylikOran.HeaderText = "Aylık Oran";
            this.aylikOran.Name = "aylikOran";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Taksit Oranları";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmBankaPos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(711, 506);
            this.Controls.Add(this.dgBankaPos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlAlt);
            this.Name = "frmBankaPos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Banka Pos Tanımlamaları";
            this.Load += new System.EventHandler(this.frmBankaPos_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBankaPos)).EndInit();
            this.panel12.ResumeLayout(false);
            this.grpBelgeNumarası.ResumeLayout(false);
            this.grpBelgeNumarası.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.pnlAlt.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTaksitOranlari)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yeniBankaTanımlaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silmeİşleminiGeriAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem raporGörüntüleToolStripMenuItem;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button btnPosEkle;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.Label lblKayitSayisi3;
        private System.Windows.Forms.Button btnRaporGoruntule;
        private System.Windows.Forms.Label label70;
        public System.Windows.Forms.DataGridView dgBankaPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn posid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankaHesapid;
        private System.Windows.Forms.DataGridViewTextBoxColumn hesapAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn adi;
        private System.Windows.Forms.DataGridViewTextBoxColumn posAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ayrinti;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.GroupBox grpBelgeNumarası;
        private System.Windows.Forms.TextBox txtPosAdi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAyrinti;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkSilinenKayitlariGoster;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox txtTanimAdi;
        private System.Windows.Forms.TextBox txtHesapAdi;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Panel pnlAlt;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dgTaksitOranlari;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn posTaksitid;
        private System.Windows.Forms.DataGridViewTextBoxColumn taksitSayisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn aylikOran;
    }
}