namespace Elmar_Mesaj_Paneli
{
    partial class frmMesajlar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMesajlar));
            this.dgMesajlar = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbSubeler = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgKullanicilar = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSubeYenile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgMesajlar)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgKullanicilar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgMesajlar
            // 
            this.dgMesajlar.AllowUserToAddRows = false;
            this.dgMesajlar.AllowUserToDeleteRows = false;
            this.dgMesajlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMesajlar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgMesajlar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgMesajlar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgMesajlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMesajlar.ColumnHeadersVisible = false;
            this.dgMesajlar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column5,
            this.Column4});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMesajlar.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgMesajlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMesajlar.Location = new System.Drawing.Point(0, 0);
            this.dgMesajlar.MultiSelect = false;
            this.dgMesajlar.Name = "dgMesajlar";
            this.dgMesajlar.ReadOnly = true;
            this.dgMesajlar.RowHeadersWidth = 4;
            this.dgMesajlar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgMesajlar.RowTemplate.Height = 40;
            this.dgMesajlar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMesajlar.Size = new System.Drawing.Size(660, 523);
            this.dgMesajlar.TabIndex = 30;
            this.dgMesajlar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMesajlar_CellDoubleClick);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgMesajlar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(220, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(660, 523);
            this.panel3.TabIndex = 7;
            // 
            // cmbSubeler
            // 
            this.cmbSubeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSubeler.FormattingEnabled = true;
            this.cmbSubeler.Location = new System.Drawing.Point(32, 0);
            this.cmbSubeler.Name = "cmbSubeler";
            this.cmbSubeler.Size = new System.Drawing.Size(154, 21);
            this.cmbSubeler.TabIndex = 0;
            this.cmbSubeler.SelectedIndexChanged += new System.EventHandler(this.cmbSubeler_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgKullanicilar);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 523);
            this.panel2.TabIndex = 6;
            // 
            // dgKullanicilar
            // 
            this.dgKullanicilar.AllowUserToAddRows = false;
            this.dgKullanicilar.AllowUserToDeleteRows = false;
            this.dgKullanicilar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgKullanicilar.BackgroundColor = System.Drawing.Color.White;
            this.dgKullanicilar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgKullanicilar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgKullanicilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKullanicilar.ColumnHeadersVisible = false;
            this.dgKullanicilar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgKullanicilar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgKullanicilar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgKullanicilar.Location = new System.Drawing.Point(0, 23);
            this.dgKullanicilar.MultiSelect = false;
            this.dgKullanicilar.Name = "dgKullanicilar";
            this.dgKullanicilar.ReadOnly = true;
            this.dgKullanicilar.RowHeadersWidth = 4;
            this.dgKullanicilar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgKullanicilar.RowTemplate.Height = 25;
            this.dgKullanicilar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgKullanicilar.Size = new System.Drawing.Size(216, 474);
            this.dgKullanicilar.TabIndex = 32;
            this.dgKullanicilar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgKullanicilar_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "kullaniciid";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "kAdi";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.cmbSubeler);
            this.panel1.Controls.Add(this.btnSubeYenile);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 23);
            this.panel1.TabIndex = 31;
            // 
            // btnSubeYenile
            // 
            this.btnSubeYenile.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSubeYenile.Image = global::Elmar_Mesaj_Paneli.Properties.Resources.Refresh_icon;
            this.btnSubeYenile.Location = new System.Drawing.Point(186, 0);
            this.btnSubeYenile.Name = "btnSubeYenile";
            this.btnSubeYenile.Size = new System.Drawing.Size(30, 23);
            this.btnSubeYenile.TabIndex = 3;
            this.btnSubeYenile.UseVisualStyleBackColor = false;
            this.btnSubeYenile.Click += new System.EventHandler(this.btnSubeYenile_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Şube";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(0, 497);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "☻ : Açık | ☺ : Kapalı";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.UseCompatibleTextRendering = true;
            // 
            // frmMesajlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 523);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMesajlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elmar Ticari Plus | Mesajlarım";
            this.Load += new System.EventHandler(this.frmMesajlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMesajlar)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgKullanicilar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMesajlar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbSubeler;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgKullanicilar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnSubeYenile;
    }
}