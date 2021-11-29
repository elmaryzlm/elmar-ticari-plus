namespace Elmar_Ticari_Plus
{
    partial class frmOtoparkAboneler
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRaporOnizle = new System.Windows.Forms.Button();
            this.btnTahsilat = new System.Windows.Forms.Button();
            this.btnDevir = new System.Windows.Forms.Button();
            this.btnListeyiYenile = new System.Windows.Forms.Button();
            this.btnAboneSil = new System.Windows.Forms.Button();
            this.btnAboneDuzenle = new System.Windows.Forms.Button();
            this.btnYeniAboneEkle = new System.Windows.Forms.Button();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.dgAboneListesi = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblKayitSayisi = new System.Windows.Forms.Label();
            this.aboneid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cariid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soyadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plaka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markaModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAboneListesi)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRaporOnizle);
            this.panel1.Controls.Add(this.btnTahsilat);
            this.panel1.Controls.Add(this.btnDevir);
            this.panel1.Controls.Add(this.btnListeyiYenile);
            this.panel1.Controls.Add(this.btnAboneSil);
            this.panel1.Controls.Add(this.btnAboneDuzenle);
            this.panel1.Controls.Add(this.btnYeniAboneEkle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(135, 445);
            this.panel1.TabIndex = 0;
            // 
            // btnRaporOnizle
            // 
            this.btnRaporOnizle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRaporOnizle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRaporOnizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporOnizle.Image = global::Elmar_Ticari_Plus.Properties.Resources.fatrapor1;
            this.btnRaporOnizle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRaporOnizle.Location = new System.Drawing.Point(0, 294);
            this.btnRaporOnizle.Name = "btnRaporOnizle";
            this.btnRaporOnizle.Size = new System.Drawing.Size(135, 49);
            this.btnRaporOnizle.TabIndex = 14;
            this.btnRaporOnizle.Text = "Rapor Önizle";
            this.btnRaporOnizle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRaporOnizle.UseVisualStyleBackColor = false;
            this.btnRaporOnizle.Visible = false;
            // 
            // btnTahsilat
            // 
            this.btnTahsilat.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnTahsilat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTahsilat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTahsilat.Image = global::Elmar_Ticari_Plus.Properties.Resources.payment_icon;
            this.btnTahsilat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTahsilat.Location = new System.Drawing.Point(0, 245);
            this.btnTahsilat.Name = "btnTahsilat";
            this.btnTahsilat.Size = new System.Drawing.Size(135, 49);
            this.btnTahsilat.TabIndex = 12;
            this.btnTahsilat.Text = "Abone Tahsilat İşlemi";
            this.btnTahsilat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTahsilat.UseVisualStyleBackColor = false;
            this.btnTahsilat.Click += new System.EventHandler(this.btnTahsilat_Click);
            // 
            // btnDevir
            // 
            this.btnDevir.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnDevir.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDevir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDevir.Image = global::Elmar_Ticari_Plus.Properties.Resources.yen_coins_icon__1_;
            this.btnDevir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDevir.Location = new System.Drawing.Point(0, 196);
            this.btnDevir.Name = "btnDevir";
            this.btnDevir.Size = new System.Drawing.Size(135, 49);
            this.btnDevir.TabIndex = 11;
            this.btnDevir.Text = "Abone Devir \r\nİşlemi";
            this.btnDevir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDevir.UseVisualStyleBackColor = false;
            this.btnDevir.Click += new System.EventHandler(this.btnDevir_Click);
            // 
            // btnListeyiYenile
            // 
            this.btnListeyiYenile.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnListeyiYenile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnListeyiYenile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnListeyiYenile.Image = global::Elmar_Ticari_Plus.Properties.Resources.Windows_Live_Mesh_icon;
            this.btnListeyiYenile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListeyiYenile.Location = new System.Drawing.Point(0, 147);
            this.btnListeyiYenile.Name = "btnListeyiYenile";
            this.btnListeyiYenile.Size = new System.Drawing.Size(135, 49);
            this.btnListeyiYenile.TabIndex = 13;
            this.btnListeyiYenile.Text = "Listeyi Yenile";
            this.btnListeyiYenile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListeyiYenile.UseVisualStyleBackColor = false;
            this.btnListeyiYenile.Click += new System.EventHandler(this.btnListeyiYenile_Click);
            // 
            // btnAboneSil
            // 
            this.btnAboneSil.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAboneSil.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAboneSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAboneSil.Image = global::Elmar_Ticari_Plus.Properties.Resources.Close_2_icon;
            this.btnAboneSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAboneSil.Location = new System.Drawing.Point(0, 98);
            this.btnAboneSil.Name = "btnAboneSil";
            this.btnAboneSil.Size = new System.Drawing.Size(135, 49);
            this.btnAboneSil.TabIndex = 10;
            this.btnAboneSil.Text = "Aboneyi Sil";
            this.btnAboneSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAboneSil.UseVisualStyleBackColor = false;
            this.btnAboneSil.Click += new System.EventHandler(this.btnAboneSil_Click);
            // 
            // btnAboneDuzenle
            // 
            this.btnAboneDuzenle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAboneDuzenle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAboneDuzenle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAboneDuzenle.Image = global::Elmar_Ticari_Plus.Properties.Resources.Pencil_icon;
            this.btnAboneDuzenle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAboneDuzenle.Location = new System.Drawing.Point(0, 49);
            this.btnAboneDuzenle.Name = "btnAboneDuzenle";
            this.btnAboneDuzenle.Size = new System.Drawing.Size(135, 49);
            this.btnAboneDuzenle.TabIndex = 9;
            this.btnAboneDuzenle.Text = "Aboneyi Düzenle";
            this.btnAboneDuzenle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAboneDuzenle.UseVisualStyleBackColor = false;
            this.btnAboneDuzenle.Click += new System.EventHandler(this.btnAboneDuzenle_Click);
            // 
            // btnYeniAboneEkle
            // 
            this.btnYeniAboneEkle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnYeniAboneEkle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnYeniAboneEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYeniAboneEkle.Image = global::Elmar_Ticari_Plus.Properties.Resources.genelEkle;
            this.btnYeniAboneEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYeniAboneEkle.Location = new System.Drawing.Point(0, 0);
            this.btnYeniAboneEkle.Name = "btnYeniAboneEkle";
            this.btnYeniAboneEkle.Size = new System.Drawing.Size(135, 49);
            this.btnYeniAboneEkle.TabIndex = 8;
            this.btnYeniAboneEkle.Text = "Yeni Abone Ekle";
            this.btnYeniAboneEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnYeniAboneEkle.UseVisualStyleBackColor = false;
            this.btnYeniAboneEkle.Click += new System.EventHandler(this.btnYeniAboneEkle_Click);
            // 
            // lblBaslik
            // 
            this.lblBaslik.BackColor = System.Drawing.Color.White;
            this.lblBaslik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.Image = global::Elmar_Ticari_Plus.Properties.Resources.Users_Folder_Black_icon;
            this.lblBaslik.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(735, 47);
            this.lblBaslik.TabIndex = 94;
            this.lblBaslik.Text = "              Otopark Abone Listesi | Abone İşlemleri";
            this.lblBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgAboneListesi
            // 
            this.dgAboneListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAboneListesi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aboneid,
            this.cariid,
            this.adi,
            this.soyadi,
            this.plaka,
            this.markaModel});
            this.dgAboneListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAboneListesi.Location = new System.Drawing.Point(135, 47);
            this.dgAboneListesi.MultiSelect = false;
            this.dgAboneListesi.Name = "dgAboneListesi";
            this.dgAboneListesi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAboneListesi.Size = new System.Drawing.Size(600, 418);
            this.dgAboneListesi.TabIndex = 95;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblKayitSayisi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(135, 465);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 27);
            this.panel2.TabIndex = 96;
            // 
            // lblKayitSayisi
            // 
            this.lblKayitSayisi.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblKayitSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKayitSayisi.Location = new System.Drawing.Point(0, 0);
            this.lblKayitSayisi.Name = "lblKayitSayisi";
            this.lblKayitSayisi.Size = new System.Drawing.Size(82, 27);
            this.lblKayitSayisi.TabIndex = 0;
            this.lblKayitSayisi.Text = "Kayıt Sayısı: 0";
            this.lblKayitSayisi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // aboneid
            // 
            this.aboneid.HeaderText = "aboneid";
            this.aboneid.Name = "aboneid";
            this.aboneid.Visible = false;
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
            // plaka
            // 
            this.plaka.HeaderText = "Plaka";
            this.plaka.Name = "plaka";
            this.plaka.ReadOnly = true;
            // 
            // markaModel
            // 
            this.markaModel.HeaderText = "Marka-Model";
            this.markaModel.Name = "markaModel";
            this.markaModel.ReadOnly = true;
            // 
            // frmOtoparkAboneler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 492);
            this.Controls.Add(this.dgAboneListesi);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblBaslik);
            this.Name = "frmOtoparkAboneler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Aboneler";
            this.Load += new System.EventHandler(this.frmOtoparkAboneler_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAboneListesi)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTahsilat;
        private System.Windows.Forms.Button btnDevir;
        private System.Windows.Forms.Button btnAboneSil;
        private System.Windows.Forms.Button btnAboneDuzenle;
        private System.Windows.Forms.Button btnYeniAboneEkle;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Button btnListeyiYenile;
        private System.Windows.Forms.DataGridView dgAboneListesi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRaporOnizle;
        private System.Windows.Forms.Label lblKayitSayisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn aboneid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cariid;
        private System.Windows.Forms.DataGridViewTextBoxColumn adi;
        private System.Windows.Forms.DataGridViewTextBoxColumn soyadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn plaka;
        private System.Windows.Forms.DataGridViewTextBoxColumn markaModel;
    }
}