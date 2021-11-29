namespace Elmar_Ticari_Plus
{
    partial class frmOtoparkAracListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOtoparkAracListesi));
            this.lwAracListesi = new System.Windows.Forms.ListView();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblSayac = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lwAracListesi
            // 
            this.lwAracListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lwAracListesi.GridLines = true;
            this.lwAracListesi.HideSelection = false;
            this.lwAracListesi.LargeImageList = this.ımageList1;
            this.lwAracListesi.Location = new System.Drawing.Point(0, 0);
            this.lwAracListesi.Name = "lwAracListesi";
            this.lwAracListesi.ShowItemToolTips = true;
            this.lwAracListesi.Size = new System.Drawing.Size(780, 455);
            this.lwAracListesi.SmallImageList = this.ımageList1;
            this.lwAracListesi.StateImageList = this.ımageList1;
            this.lwAracListesi.TabIndex = 0;
            this.lwAracListesi.UseCompatibleStateImageBehavior = false;
            this.lwAracListesi.View = System.Windows.Forms.View.List;
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "abone2.png");
            this.ımageList1.Images.SetKeyName(1, "Yeni-Park.png");
            // 
            // lblSayac
            // 
            this.lblSayac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSayac.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSayac.Location = new System.Drawing.Point(0, 455);
            this.lblSayac.Name = "lblSayac";
            this.lblSayac.Size = new System.Drawing.Size(780, 23);
            this.lblSayac.TabIndex = 1;
            this.lblSayac.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmOtoparkAracListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 478);
            this.Controls.Add(this.lwAracListesi);
            this.Controls.Add(this.lblSayac);
            this.Name = "frmOtoparkAracListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Otoparktaki Araç Listesi";
            this.Load += new System.EventHandler(this.frmOtoparkAracListesi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSayac;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.ListView lwAracListesi;
    }
}