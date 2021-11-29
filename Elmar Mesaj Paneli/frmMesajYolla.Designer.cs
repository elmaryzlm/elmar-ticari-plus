namespace Elmar_Mesaj_Paneli
{
    partial class frmMesajYolla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMesajYolla));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblGönderen = new System.Windows.Forms.Label();
            this.btnGonder = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtGiden = new System.Windows.Forms.RichTextBox();
            this.txtGelen = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblGönderen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 50);
            this.panel1.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::Elmar_Mesaj_Paneli.Properties.Resources.Messages_icon;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblGönderen
            // 
            this.lblGönderen.AutoSize = true;
            this.lblGönderen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGönderen.Location = new System.Drawing.Point(55, 4);
            this.lblGönderen.Name = "lblGönderen";
            this.lblGönderen.Size = new System.Drawing.Size(85, 18);
            this.lblGönderen.TabIndex = 1;
            this.lblGönderen.Text = "Gönderen :";
            // 
            // btnGonder
            // 
            this.btnGonder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGonder.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGonder.Location = new System.Drawing.Point(642, 0);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(64, 57);
            this.btnGonder.TabIndex = 4;
            this.btnGonder.Text = "Gönder";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtGiden);
            this.panel2.Controls.Add(this.btnGonder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 482);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(706, 57);
            this.panel2.TabIndex = 12;
            // 
            // txtGiden
            // 
            this.txtGiden.AutoWordSelection = true;
            this.txtGiden.BackColor = System.Drawing.Color.White;
            this.txtGiden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGiden.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGiden.Location = new System.Drawing.Point(0, 0);
            this.txtGiden.MaxLength = 500;
            this.txtGiden.Name = "txtGiden";
            this.txtGiden.Size = new System.Drawing.Size(642, 57);
            this.txtGiden.TabIndex = 11;
            this.txtGiden.Text = "";
            this.txtGiden.TextChanged += new System.EventHandler(this.txtGiden_TextChanged);
            this.txtGiden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGiden_KeyDown);
            // 
            // txtGelen
            // 
            this.txtGelen.AutoWordSelection = true;
            this.txtGelen.BackColor = System.Drawing.Color.White;
            this.txtGelen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGelen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGelen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGelen.HideSelection = false;
            this.txtGelen.Location = new System.Drawing.Point(0, 50);
            this.txtGelen.Name = "txtGelen";
            this.txtGelen.ReadOnly = true;
            this.txtGelen.Size = new System.Drawing.Size(706, 432);
            this.txtGelen.TabIndex = 13;
            this.txtGelen.Text = "";
            // 
            // frmMesajYolla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 539);
            this.Controls.Add(this.txtGelen);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMesajYolla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mesaj Yolla";
            this.Load += new System.EventHandler(this.frmMesajYolla_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblGönderen;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox txtGiden;
        private System.Windows.Forms.RichTextBox txtGelen;
    }
}