using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
namespace Elmar_Ticari_Plus
{
    public partial class frmBolgeSecimi : Form
    {
        public frmBolgeSecimi()
        {
            InitializeComponent();
        }

        private void frmBolgeSecimi_Load(object sender, EventArgs e)
        {
            illeriListele();
            NesneGorselleri.form(this, true);
        }

        public frmTicaret _frmTicaret;
        public frmCariKartEkle _frmCariKartEkle;
        public frmCariKartislemleri _frmCariKartislemleri;
        public frmFirmaSubeBilgileri _frmFirmaSubeBilgileri;
        public frmCariAlacakBorcRaporlari _frmCariAlacakBorcRaporlari;
        public frmOtoparkAboneEkle _frmOtoparkAboneEkle;
      

        public void illeriListele()
        {
            tv1.Nodes.Clear();
            TreeNode tn2;
            SqlDataReader dr = veri.getDatareader("select bolgeid,bolgeAdi from sorBolgeler where len(bolgeid)=2 order by bolgeid asc");
            while (dr.Read())
            {
                try
                {
                    tn2 = new TreeNode();
                    tn2.Text = dr["bolgeAdi"].ToString();
                    tn2.Tag = dr["bolgeid"].ToString();
                    tn2.Nodes.Add("");
                    tv1.Nodes.Add(tn2);                    
                }
                catch
                {
                }
            }
        }

        public void ilceleriListele()
        {
            tv1.SelectedNode.Nodes.Clear();
            TreeNode tn2;
            string tire = "__";
            if (tv1.SelectedNode.Tag.ToString().Length == 4) tire = "_____";
            SqlDataReader dr = veri.getDatareader("select bolgeid,bolgeAdi from sorBolgeler where bolgeid like '"+tv1.SelectedNode.Tag.ToString()+tire+"' order by bolgeAdi asc");
            while (dr.Read())
            {
                try
                {
                    tn2 = new TreeNode();
                    tn2.Text = dr["bolgeAdi"].ToString();
                    tn2.Tag = dr["bolgeid"].ToString();
                    if (tn2.Tag.ToString().Length<=4) tn2.Nodes.Add("");
                    tv1.SelectedNode.Nodes.Add(tn2);                    
                }
                catch
                {
                }
            }
        }

        private void tv1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            tv1.SelectedNode = e.Node;                        
            ilceleriListele();
        }

        private void tv1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtBolge.Tag = e.Node.Tag.ToString();
            if (e.Node.Tag.ToString().Length == 2) txtBolge.Text = e.Node.Text.ToString();
            else if (e.Node.Tag.ToString().Length == 4) txtBolge.Text = e.Node.Parent.Text.ToString()+" - " + e.Node.Text.ToString();
            else if (e.Node.Tag.ToString().Length == 9) txtBolge.Text = e.Node.Parent.Parent.Text.ToString() + " - " + e.Node.Parent.Text.ToString() + " - " + e.Node.Text.ToString(); ;
            //txtKategori.Text = veri.getdatacell("select dbo.fonkBolgeAdiGetir('" + e.Node.Tag.ToString() + "')");
        }

        private void btnAktar_Click(object sender, EventArgs e)
        {
            if (_frmTicaret != null)
            {
                _frmTicaret.txtCBolge.Text = txtBolge.Text;
                _frmTicaret.txtCBolge.Tag = txtBolge.Tag.ToString();
            }
            else if (_frmCariKartEkle != null)
            { 
                _frmCariKartEkle.txtBolge.Text = txtBolge.Text;
                _frmCariKartEkle.txtBolge.Tag = txtBolge.Tag.ToString();
            }
          
            else if (_frmCariKartislemleri != null)
            {
                _frmCariKartislemleri.txtBolge.Text = txtBolge.Text;
                _frmCariKartislemleri.txtBolge.Tag = txtBolge.Tag.ToString();
            }
            else if (_frmFirmaSubeBilgileri != null)
            {
                _frmFirmaSubeBilgileri.txtBolge.Text = txtBolge.Text;
                _frmFirmaSubeBilgileri.txtBolge.Tag = txtBolge.Tag.ToString();
            }
            else if (_frmCariAlacakBorcRaporlari != null)
            {
                _frmCariAlacakBorcRaporlari.txtBolge.Text = txtBolge.Text;
                _frmCariAlacakBorcRaporlari.txtBolge.Tag = txtBolge.Tag.ToString();
            }
            else if (_frmOtoparkAboneEkle != null)
            {
                _frmOtoparkAboneEkle.txtBolge.Text = txtBolge.Text;
                _frmOtoparkAboneEkle.txtBolge.Tag = txtBolge.Tag.ToString();
            }
            this.Close();
        }

        private void tv1_DoubleClick(object sender, EventArgs e)
        {
            //btnAktar_Click(sender, e);
        }

        private void txtBolge_TextChanged(object sender, EventArgs e)
        {

        }        
    }
}
