using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elmar_Ticari_Plus
{
    public partial class frmUrunAlimFiyatlari : Form
    {
        public frmUrunAlimFiyatlari(long cariID, long stokID)
        {
            InitializeComponent();
            string sql = @"select eklenmeTarihi as Tarih, AdiSoyadi as Cari, Barkod, urunAdi as [Ürün Adı], Miktar, Birim, katsayi as Katsayı, birimFiyat as [Birim Fiyat], KDV, kdvTipi as [KDV Tipi], İsk1, İsk2, İsk3, ABS(AraTop) as [Ara Toplam], ABS(KdvTop) as [Kdv Toplam], ABS(Toplam) as Toplam from sorTicaret
                           where islemTuru like '%alış%' and silindimi=0 and stokid=" + stokID + " and firmaid=" + firma.firmaid;
            if (cariID != 0) sql += "and cariid=" + cariID;
            sql += " order by eklenmeTarihi desc";
            dataGridView1.DataSource = veri.getdatatable(sql);
        }
    }
}