namespace Elmar_Ticari_Plus
{
    partial class frmYukle
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
            this.p1 = new System.Windows.Forms.ProgressBar();
            this.label10 = new System.Windows.Forms.Label();
            this.lblBilgi = new System.Windows.Forms.Label();
            this.tmrFormAc = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // p1
            // 
            this.p1.Location = new System.Drawing.Point(12, 22);
            this.p1.Maximum = 12;
            this.p1.Minimum = 1;
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(260, 23);
            this.p1.Step = 1;
            this.p1.TabIndex = 0;
            this.p1.Value = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.DarkRed;
            this.label10.Location = new System.Drawing.Point(86, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Lütfen Bekleyin..";
            // 
            // lblBilgi
            // 
            this.lblBilgi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBilgi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBilgi.Location = new System.Drawing.Point(12, 47);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(260, 45);
            this.lblBilgi.TabIndex = 2;
            this.lblBilgi.Text = "Hazır";
            // 
            // tmrFormAc
            // 
            this.tmrFormAc.Enabled = true;
            this.tmrFormAc.Interval = 150;
            this.tmrFormAc.Tick += new System.EventHandler(this.tmrFormAc_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Elmar_Ticari_Plus.Properties.Resources.icon;
            this.pictureBox1.Location = new System.Drawing.Point(0, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // frmYukle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 238);
            this.Controls.Add(this.lblBilgi);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmYukle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BMS Muhasebe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmYukle_FormClosing);
            this.Load += new System.EventHandler(this.frmYukle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar p1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblBilgi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer tmrFormAc;
    }
}