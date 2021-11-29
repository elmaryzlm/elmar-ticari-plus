namespace Elmar_Ticari_Plus
{
    partial class frmTanimSatis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTanimSatis));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdStokKontrolleriYapilsinUyariVersin = new System.Windows.Forms.RadioButton();
            this.rdStokKontrolleriYapilmasin = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rdStokKontrolleriYapilsinEngellesin = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnKaydet1 = new System.Windows.Forms.Button();
            this.cmbSatisFiyati = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKaydet2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdStokKontrolleriYapilsinUyariVersin);
            this.groupBox2.Controls.Add(this.rdStokKontrolleriYapilmasin);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.rdStokKontrolleriYapilsinEngellesin);
            this.groupBox2.Location = new System.Drawing.Point(276, 333);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 195);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stok Kontrolleri";
            // 
            // rdStokKontrolleriYapilsinUyariVersin
            // 
            this.rdStokKontrolleriYapilsinUyariVersin.Location = new System.Drawing.Point(4, 120);
            this.rdStokKontrolleriYapilsinUyariVersin.Name = "rdStokKontrolleriYapilsinUyariVersin";
            this.rdStokKontrolleriYapilsinUyariVersin.Size = new System.Drawing.Size(267, 34);
            this.rdStokKontrolleriYapilsinUyariVersin.TabIndex = 5;
            this.rdStokKontrolleriYapilsinUyariVersin.TabStop = true;
            this.rdStokKontrolleriYapilsinUyariVersin.Text = "Stok Kontrolleri Yapılsın. Eğer Stoğumda üründen yoksa uyarı versin.";
            this.rdStokKontrolleriYapilsinUyariVersin.UseVisualStyleBackColor = true;
            // 
            // rdStokKontrolleriYapilmasin
            // 
            this.rdStokKontrolleriYapilmasin.Location = new System.Drawing.Point(4, 96);
            this.rdStokKontrolleriYapilmasin.Name = "rdStokKontrolleriYapilmasin";
            this.rdStokKontrolleriYapilmasin.Size = new System.Drawing.Size(267, 24);
            this.rdStokKontrolleriYapilmasin.TabIndex = 4;
            this.rdStokKontrolleriYapilmasin.TabStop = true;
            this.rdStokKontrolleriYapilmasin.Text = "Stok Kontrolleri Yapılmasın";
            this.rdStokKontrolleriYapilmasin.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(5, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 78);
            this.label4.TabIndex = 3;
            this.label4.Text = resources.GetString("label4.Text");
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdStokKontrolleriYapilsinEngellesin
            // 
            this.rdStokKontrolleriYapilsinEngellesin.Location = new System.Drawing.Point(4, 146);
            this.rdStokKontrolleriYapilsinEngellesin.Name = "rdStokKontrolleriYapilsinEngellesin";
            this.rdStokKontrolleriYapilsinEngellesin.Size = new System.Drawing.Size(267, 48);
            this.rdStokKontrolleriYapilsinEngellesin.TabIndex = 6;
            this.rdStokKontrolleriYapilsinEngellesin.TabStop = true;
            this.rdStokKontrolleriYapilsinEngellesin.Text = "Stok Kontrolleri Yapılsın. Eğer Stoğumda üründen yoksa satış engellensin.";
            this.rdStokKontrolleriYapilsinEngellesin.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnKaydet1);
            this.groupBox1.Controls.Add(this.cmbSatisFiyati);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(275, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 124);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Satış Fiyatı Seçimi";
            // 
            // btnKaydet1
            // 
            this.btnKaydet1.BackColor = System.Drawing.Color.GhostWhite;
            this.btnKaydet1.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydet1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet1.Location = new System.Drawing.Point(199, 96);
            this.btnKaydet1.Name = "btnKaydet1";
            this.btnKaydet1.Size = new System.Drawing.Size(66, 26);
            this.btnKaydet1.TabIndex = 8;
            this.btnKaydet1.Text = "Kaydet";
            this.btnKaydet1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet1.UseVisualStyleBackColor = false;
            this.btnKaydet1.Click += new System.EventHandler(this.btnKaydet1_Click);
            // 
            // cmbSatisFiyati
            // 
            this.cmbSatisFiyati.BackColor = System.Drawing.Color.White;
            this.cmbSatisFiyati.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbSatisFiyati.FormattingEnabled = true;
            this.cmbSatisFiyati.Location = new System.Drawing.Point(80, 69);
            this.cmbSatisFiyati.Name = "cmbSatisFiyati";
            this.cmbSatisFiyati.Size = new System.Drawing.Size(185, 23);
            this.cmbSatisFiyati.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(9, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Satış Fiyatı";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(6, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 52);
            this.label2.TabIndex = 3;
            this.label2.Text = "      Bu kullanıcı ile yapılacak satışlarda hangi satış fiyatının kullanılmasını " +
    "istersiniz ?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnKaydet2
            // 
            this.btnKaydet2.BackColor = System.Drawing.Color.GhostWhite;
            this.btnKaydet2.Image = global::Elmar_Ticari_Plus.Properties.Resources.Actions_document_save_icon;
            this.btnKaydet2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet2.Location = new System.Drawing.Point(484, 523);
            this.btnKaydet2.Name = "btnKaydet2";
            this.btnKaydet2.Size = new System.Drawing.Size(66, 26);
            this.btnKaydet2.TabIndex = 7;
            this.btnKaydet2.Text = "Kaydet";
            this.btnKaydet2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKaydet2.UseVisualStyleBackColor = false;
            this.btnKaydet2.Click += new System.EventHandler(this.btnKaydet2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(236, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(434, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "_____________________________________________________________";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Faturasız_Satış_Fiyatı",
            "Faturalı_Satış_Fiyatı",
            "İade_Satış_Fiyatı",
            "Teklif_Fiyatı"});
            this.comboBox1.Location = new System.Drawing.Point(146, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "İşlem Yapılacak Menü";
            // 
            // frmTanimSatis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(918, 565);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnKaydet2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTanimSatis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Satış Ayarları";
            this.Load += new System.EventHandler(this.frmTanimSatis_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdStokKontrolleriYapilsinUyariVersin;
        private System.Windows.Forms.RadioButton rdStokKontrolleriYapilmasin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdStokKontrolleriYapilsinEngellesin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSatisFiyati;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnKaydet2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnKaydet1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
    }
}