namespace Elmar_Ticari_Plus
{
    partial class frmMizanRaporu
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKullanici = new System.Windows.Forms.ComboBox();
            this.btnRaporla = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbSubeler = new System.Windows.Forms.ComboBox();
            this.dtTarih1 = new System.Windows.Forms.DateTimePicker();
            this.dtTarih2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(259, 38);
            this.panel3.TabIndex = 79;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(52, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Mizan Raporu";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::Elmar_Ticari_Plus.Properties.Resources.tahsilatodeme;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Kullanıcı";
            // 
            // cmbKullanici
            // 
            this.cmbKullanici.BackColor = System.Drawing.Color.White;
            this.cmbKullanici.ForeColor = System.Drawing.Color.Black;
            this.cmbKullanici.FormattingEnabled = true;
            this.cmbKullanici.Location = new System.Drawing.Point(90, 133);
            this.cmbKullanici.Name = "cmbKullanici";
            this.cmbKullanici.Size = new System.Drawing.Size(165, 21);
            this.cmbKullanici.TabIndex = 59;
            this.cmbKullanici.Tag = "001";
            this.cmbKullanici.Text = "Tümü";
            // 
            // btnRaporla
            // 
            this.btnRaporla.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporla.Image = global::Elmar_Ticari_Plus.Properties.Resources.tahsilatodeme;
            this.btnRaporla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRaporla.Location = new System.Drawing.Point(58, 162);
            this.btnRaporla.Name = "btnRaporla";
            this.btnRaporla.Size = new System.Drawing.Size(146, 41);
            this.btnRaporla.TabIndex = 42;
            this.btnRaporla.Text = "Raporu Görüntüle";
            this.btnRaporla.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRaporla.UseVisualStyleBackColor = false;
            this.btnRaporla.Click += new System.EventHandler(this.btnRaporla_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtTarih2);
            this.groupBox1.Controls.Add(this.dtTarih1);
            this.groupBox1.Controls.Add(this.cmbKullanici);
            this.groupBox1.Controls.Add(this.cmbSubeler);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.btnRaporla);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 209);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sorgulama Seçenekleri";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(10, 112);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 13);
            this.label17.TabIndex = 36;
            this.label17.Text = "Şube";
            // 
            // cmbSubeler
            // 
            this.cmbSubeler.BackColor = System.Drawing.Color.White;
            this.cmbSubeler.ForeColor = System.Drawing.Color.Black;
            this.cmbSubeler.FormattingEnabled = true;
            this.cmbSubeler.Location = new System.Drawing.Point(90, 107);
            this.cmbSubeler.Name = "cmbSubeler";
            this.cmbSubeler.Size = new System.Drawing.Size(165, 21);
            this.cmbSubeler.TabIndex = 35;
            this.cmbSubeler.Tag = "001";
            this.cmbSubeler.Text = "Tümü";
            this.cmbSubeler.SelectedIndexChanged += new System.EventHandler(this.cmbSubeler_SelectedIndexChanged);
            // 
            // dtTarih1
            // 
            this.dtTarih1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtTarih1.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtTarih1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTarih1.Location = new System.Drawing.Point(90, 57);
            this.dtTarih1.Name = "dtTarih1";
            this.dtTarih1.Size = new System.Drawing.Size(165, 20);
            this.dtTarih1.TabIndex = 25;
            // 
            // dtTarih2
            // 
            this.dtTarih2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtTarih2.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtTarih2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTarih2.Location = new System.Drawing.Point(90, 82);
            this.dtTarih2.Name = "dtTarih2";
            this.dtTarih2.Size = new System.Drawing.Size(165, 20);
            this.dtTarih2.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "Başlangıç Tarihi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Bitiş Tarihi";
            // 
            // frmMizanRaporu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 209);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMizanRaporu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Mizan Raporu";
            this.Load += new System.EventHandler(this.frmMizanRaporu_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKullanici;
        private System.Windows.Forms.Button btnRaporla;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtTarih2;
        private System.Windows.Forms.DateTimePicker dtTarih1;
        private System.Windows.Forms.ComboBox cmbSubeler;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label17;
    }
}