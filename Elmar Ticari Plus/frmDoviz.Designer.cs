namespace Elmar_Ticari_Plus
{
    partial class frmDoviz
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDolarAlis = new System.Windows.Forms.TextBox();
            this.txtDolarSatis = new System.Windows.Forms.TextBox();
            this.txtEuroAlis = new System.Windows.Forms.TextBox();
            this.txtEuroSatis = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dolar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Euro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Alış";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Satış";
            // 
            // txtDolarAlis
            // 
            this.txtDolarAlis.Location = new System.Drawing.Point(61, 38);
            this.txtDolarAlis.Name = "txtDolarAlis";
            this.txtDolarAlis.Size = new System.Drawing.Size(55, 20);
            this.txtDolarAlis.TabIndex = 0;
            this.txtDolarAlis.Tag = "021";
            // 
            // txtDolarSatis
            // 
            this.txtDolarSatis.Location = new System.Drawing.Point(161, 38);
            this.txtDolarSatis.Name = "txtDolarSatis";
            this.txtDolarSatis.Size = new System.Drawing.Size(55, 20);
            this.txtDolarSatis.TabIndex = 1;
            this.txtDolarSatis.Tag = "021";
            // 
            // txtEuroAlis
            // 
            this.txtEuroAlis.Location = new System.Drawing.Point(61, 70);
            this.txtEuroAlis.Name = "txtEuroAlis";
            this.txtEuroAlis.Size = new System.Drawing.Size(55, 20);
            this.txtEuroAlis.TabIndex = 2;
            this.txtEuroAlis.Tag = "021";
            // 
            // txtEuroSatis
            // 
            this.txtEuroSatis.Location = new System.Drawing.Point(161, 70);
            this.txtEuroSatis.Name = "txtEuroSatis";
            this.txtEuroSatis.Size = new System.Drawing.Size(55, 20);
            this.txtEuroSatis.TabIndex = 3;
            this.txtEuroSatis.Tag = "021";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(61, 99);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(155, 32);
            this.btnKaydet.TabIndex = 4;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // frmDoviz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 134);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtEuroSatis);
            this.Controls.Add(this.txtDolarSatis);
            this.Controls.Add(this.txtEuroAlis);
            this.Controls.Add(this.txtDolarAlis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDoviz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Döviz Ayarları";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDolarAlis;
        private System.Windows.Forms.TextBox txtDolarSatis;
        private System.Windows.Forms.TextBox txtEuroAlis;
        private System.Windows.Forms.TextBox txtEuroSatis;
        private System.Windows.Forms.Button btnKaydet;
    }
}