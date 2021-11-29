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
    public partial class FrmCariyeSatilanUrunFiyatlari : Form
    {
        private long cariID;
        private long stokID;

        public FrmCariyeSatilanUrunFiyatlari(long cariID, long stokID)
        {
            InitializeComponent();
            string sql = @"select eklenmeTarihi as [Satış Tarihi], Barkod, urunAdi as [Ürün Adı], Miktar, Birim, katsayi as Katsayı, birimFiyat as [Birim Fiyat], KDV, kdvTipi as [KDV Tipi], İsk1, İsk2, İsk3, ABS(AraTop) as [Ara Toplam], ABS(KdvTop) as [Kdv Toplam], ABS(Toplam) as Toplam from sorTicaret
                           where islemTuru like '%satış%'
                           and cariid=" + cariID + " and silindimi=0 and stokid=" + stokID + " and firmaid=" + firma.firmaid +
                           " order by eklenmeTarihi desc";
            dataGridView1.DataSource = veri.getdatatable(sql);
        }
    }
}