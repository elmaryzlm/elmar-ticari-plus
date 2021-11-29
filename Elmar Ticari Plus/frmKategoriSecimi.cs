using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using elmarLibrary;
namespace Elmar_Ticari_Plus
{
    public partial class frmKategoriSecimi : Form
    {
        public frmKategoriSecimi()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(groupBox1);
            NesneGorselleri.kontrolEkle(grpKategoriEkle);
            NesneGorselleri.kontrolEkle(grpKategoriDuzenle);
        }
        public frmStokKartEkle _frmStokKartEkle;
        public frmYeniAyrintiliStokkartEkle _frmYeniAyrintiliStokkartEkle;
        public frmStokKartlari _frmStokKartlari;
        private void frmKategoriSecimi_Load(object sender, EventArgs e)
        {
            dgKategorilistele();
        }
        List<string> listKatNo = new List<string>();
        class katOzellik
        {
            public string katNo;
            public string kategoriAdi;
            public bool webdeGosterilsinmi;
            public bool vitrin;
            public katOzellik(string katNo, string kategoriAdi, string webdeGosterilsinmi,bool vitrin)
            {
                this.katNo = katNo;
                this.kategoriAdi = kategoriAdi;
                this.webdeGosterilsinmi = Convert.ToBoolean(Convert.ToByte(webdeGosterilsinmi));
                this.vitrin = vitrin;
            }
        }
        public void dgKategorilistele()
        {
            cmbUstKategoriAdi.Items.Clear();
            listKatNo.Clear();
            tv1.Nodes.Clear();
            TreeNode tn = new TreeNode();
            TreeNode tn2;
            int anaitemsayisi1 = -1, anaitemsayisi2 = -1, anaitemsayisi3 = -1, anaitemsayisi4 = -1, anaitemsayisi5 = -1;
            SqlDataReader dr = veri.getDatareader("select katNo,kategoriAdi, webdeGosterilsinmi,vitrin from sorKategori where firmaid = '" + firma.firmaid + "' order by katNo asc");
            while (dr.Read())
            {
                try
                {
                    listKatNo.Add(dr["katNo"].ToString());
                    cmbUstKategoriAdi.Items.Add(dr["kategoriAdi"].ToString());

                    tn2 = new TreeNode();
                    tn2.Text = dr["kategoriAdi"].ToString();
                    tn2.Tag = new katOzellik(dr["katNo"].ToString(), dr["kategoriAdi"].ToString(), dr["webdeGosterilsinmi"].ToString(), Convert.ToBoolean(dr["vitrin"]));
                    if (dr["katNo"].ToString().Length == 3)
                    {
                        tn = new TreeNode();
                        tn.Text = dr["kategoriAdi"].ToString();
                        tn.Tag = new katOzellik(dr["katNo"].ToString(), dr["kategoriAdi"].ToString(), dr["webdeGosterilsinmi"].ToString(), Convert.ToBoolean(dr["vitrin"]));
                        tv1.Nodes.Add(tn);
                        anaitemsayisi1++;
                        anaitemsayisi2 = -1;
                    }
                    else if (dr["katNo"].ToString().Length == 6)
                    {
                        tv1.Nodes[anaitemsayisi1].Nodes.Add(tn2);
                        anaitemsayisi2++;
                        anaitemsayisi3 = -1;
                    }
                    else if (dr["katNo"].ToString().Length == 9)
                    {
                        tv1.Nodes[anaitemsayisi1].Nodes[anaitemsayisi2].Nodes.Add(tn2);
                        anaitemsayisi3++;
                        anaitemsayisi4 = -1;
                    }
                    else if (dr["katNo"].ToString().Length == 12)
                    {
                        tv1.Nodes[anaitemsayisi1].Nodes[anaitemsayisi2].Nodes[anaitemsayisi3].Nodes.Add(tn2);
                        anaitemsayisi4++;
                        anaitemsayisi5 = -1;
                    }
                    else if (dr["katNo"].ToString().Length == 15)
                    {
                        tv1.Nodes[anaitemsayisi1].Nodes[anaitemsayisi2].Nodes[anaitemsayisi3].Nodes[anaitemsayisi4].Nodes.Add(tn2);
                        anaitemsayisi5++;
                    }
                    else if (dr["katNo"].ToString().Length == 18)
                    {
                        tv1.Nodes[anaitemsayisi1].Nodes[anaitemsayisi2].Nodes[anaitemsayisi3].Nodes[anaitemsayisi4].Nodes[anaitemsayisi5].Nodes.Add(tn2);
                    }
                }
                catch
                {
                }
            }

        }
        string tvKatno;
        bool tvWebdeGosterilsinmi;
        private void tv1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                tvKatno = ((katOzellik)(tv1.SelectedNode.Tag)).katNo;
                txtKategori.Text = tv1.SelectedNode.Text;
                tvWebdeGosterilsinmi = ((katOzellik)(tv1.SelectedNode.Tag)).webdeGosterilsinmi;
            }
            catch
            {
            }  
        }

        private void btnAktar_Click(object sender, EventArgs e)
        {
            if (_frmStokKartEkle != null)
            {
                try
                {
                    _frmStokKartEkle.cmbKategori.Text = txtKategori.Text;
                    _frmStokKartEkle.cmbKategori.Tag = tvKatno;
                }
                catch { }
            }
            else if (_frmYeniAyrintiliStokkartEkle != null)
            {
                try
                {
                    _frmYeniAyrintiliStokkartEkle.cmbKategori.Text = txtKategori.Text;
                    _frmYeniAyrintiliStokkartEkle.cmbKategori.Tag = tvKatno;
                }
                catch { }
            }
            else if (_frmStokKartlari != null)
            {
                try
                {
                    _frmStokKartlari.cmbKategori.Text = txtKategori.Text;
                }
                catch { }
            }
            this.Close();
            
        }
        private void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEklenecekKategoriAdi.Text == "")
                {
                    MessageBox.Show("Boş Değer Girdiniz", "Elmar Ticari");
                    txtEklenecekKategoriAdi.Select();
                    return;
                }
                veri.cmd("insert into tblKategori(katNo,kategoriAdi, webdeGosterilsinmi,vitrin, firmaid, subeid, kullaniciid) values( dbo.katNoolustur('" + firma.firmaid + "','" + tvKatno + "'),'" + txtEklenecekKategoriAdi.Text + "','"+Convert.ToByte(chkWebdeGosterilsinmi1.Checked)+ "','" + Convert.ToBoolean(chbVitrin.Checked) + "','" + firma.firmaid + "','" + firma.subeid + "','" + firma.kullaniciid + "')");
                dgKategorilistele();
                listeler.yukleKategori();
                if (_frmYeniAyrintiliStokkartEkle != null) _frmYeniAyrintiliStokkartEkle.baslangic();
                if (_frmStokKartEkle != null) _frmStokKartEkle.baslangic();
                btnKapat1_Click(sender, e);
            }
            catch (Exception hata)
            {
                MessageBox.Show("Ekleme işleminde hata oluştu. Hata metni: " + hata.Message, firma.programAdi);
            }
        }

        private void btnKategoriGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGuncelKategoriAdi.Text == "")
                {
                    MessageBox.Show("Boş Değer Girdiniz", "Elmar Ticari");
                    txtGuncelKategoriAdi.Select();
                    return;
                }
                string _katNo = "";
                if (cmbUstKategoriAdi.SelectedIndex >= 0) _katNo = listKatNo[cmbUstKategoriAdi.SelectedIndex];
                veri.cmd("update tblKategori set katNo = dbo.katNoolustur('" + firma.firmaid + "','" + _katNo + "'), kategoriAdi='" + txtGuncelKategoriAdi.Text + "', webdeGosterilsinmi = '" + Convert.ToByte(chkWebdeGosterilsinmi2.Checked) + "', vitrin='" +Convert.ToBoolean(chbVitrin.Checked) + "'  where katNo = '" + tvKatno + "' and firmaid='" + firma.firmaid + "'");
                dgKategorilistele();
                listeler.yukleKategori();
                if(_frmYeniAyrintiliStokkartEkle!=null)_frmYeniAyrintiliStokkartEkle.baslangic();
                if (_frmStokKartEkle != null) _frmStokKartEkle.baslangic();
                btnKapat2_Click(sender, e);
            }
            catch (Exception hata)
            {
                MessageBox.Show("Güncelleme işleminde hata oluştu. Hata metni: " + hata.Message, firma.programAdi);
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            

        }

        private void yeniAnaKategoriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tv1.Enabled = false;
            tvKatno = "";
            grpKategoriEkle.Visible = true;
            txtUstKategoriAdi.Clear();
            txtEklenecekKategoriAdi.Clear();
        }

        private void btnKapat1_Click(object sender, EventArgs e)
        {
            tv1.Enabled = true;
            grpKategoriEkle.Visible = false;
        }

        private void altKategoriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tv1.Enabled = false;
            grpKategoriEkle.Visible = true;
            txtEklenecekKategoriAdi.Clear();
            txtUstKategoriAdi.Text = txtKategori.Text;
        }

        private void kategoriyiGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tv1.Enabled = false;
            grpKategoriDuzenle.Visible = true;
            txtGuncelKategoriAdi.Text = txtKategori.Text;
            cmbUstKategoriAdi.SelectedIndex = -1;
            if (tvKatno.Length >= 3)
            {
                for (int i = 0; i < listKatNo.Count; i++)
                {
                    if (listKatNo[i] == tvKatno.Substring(0, tvKatno.Length - 3))
                    {
                        cmbUstKategoriAdi.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void btnKapat2_Click(object sender, EventArgs e)
        {
            tv1.Enabled = true;
            grpKategoriDuzenle.Visible = false;
        }

        private void kategoriyiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(txtKategori.Text + " adlı kategori silinsin mi ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    veri.cmd("update tblKategori set silindimi='1' where katNo = '" + tvKatno + "' and firmaid='" + firma.firmaid + "'");
                    dgKategorilistele();
                    listeler.yukleKategori();
                    if (_frmYeniAyrintiliStokkartEkle != null) _frmYeniAyrintiliStokkartEkle.baslangic();
                    if (_frmStokKartEkle != null) _frmStokKartEkle.baslangic(); ;
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Silme işleminde hata oluştu. Hata metni: " + hata.Message, firma.programAdi);
                }
            }
        }
    }
}