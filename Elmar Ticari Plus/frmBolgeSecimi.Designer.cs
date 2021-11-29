namespace Elmar_Ticari_Plus
{
    partial class frmBolgeSecimi
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
            this.tv1 = new System.Windows.Forms.TreeView();
            this.txtBolge = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAktar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv1
            // 
            this.tv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv1.Location = new System.Drawing.Point(0, 37);
            this.tv1.Name = "tv1";
            this.tv1.Size = new System.Drawing.Size(480, 632);
            this.tv1.TabIndex = 46;
            this.tv1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tv1_AfterExpand);
            this.tv1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv1_AfterSelect);
            this.tv1.DoubleClick += new System.EventHandler(this.tv1_DoubleClick);
            // 
            // txtBolge
            // 
            this.txtBolge.BackColor = System.Drawing.Color.White;
            this.txtBolge.Enabled = false;
            this.txtBolge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBolge.ForeColor = System.Drawing.Color.Black;
            this.txtBolge.Location = new System.Drawing.Point(67, 10);
            this.txtBolge.MaxLength = 249;
            this.txtBolge.Name = "txtBolge";
            this.txtBolge.ReadOnly = true;
            this.txtBolge.Size = new System.Drawing.Size(328, 21);
            this.txtBolge.TabIndex = 17;
            this.txtBolge.Tag = "00";
            this.txtBolge.TextChanged += new System.EventHandler(this.txtBolge_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.btnAktar);
            this.groupBox1.Controls.Add(this.txtBolge);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 37);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            // 
            // btnAktar
            // 
            this.btnAktar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAktar.Location = new System.Drawing.Point(396, 9);
            this.btnAktar.Name = "btnAktar";
            this.btnAktar.Size = new System.Drawing.Size(80, 23);
            this.btnAktar.TabIndex = 19;
            this.btnAktar.Text = ">>Aktar>>";
            this.btnAktar.UseVisualStyleBackColor = false;
            this.btnAktar.Click += new System.EventHandler(this.btnAktar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Brown;
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Bölge Adı";
            // 
            // frmBolgeSecimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 669);
            this.Controls.Add(this.tv1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBolgeSecimi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Bölge Seçimi";
            this.Load += new System.EventHandler(this.frmBolgeSecimi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv1;
        private System.Windows.Forms.TextBox txtBolge;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAktar;
    }
}