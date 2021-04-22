using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ntpVizeOdevi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            havaDurumu();
        }

        public void havaDurumu()
        {
            XmlDocument dosya = new XmlDocument();
            string link = "https://www.mgm.gov.tr/FTPDATA/analiz/sonSOA.xml";
            dosya.Load(link);
            XmlNodeList iller = dosya.DocumentElement.SelectNodes("sehirler");
            foreach (XmlNode sehirler in iller)
            {
                if (!combo_Sehir.Items.Contains(sehirler.SelectSingleNode("ili").InnerText))
                {
                    combo_Sehir.Items.Add(sehirler.SelectSingleNode("ili").InnerText);
                }
            }
            combo_Sehir.Sorted = true;

            foreach (XmlNode item in iller)
            {
                string ili=item.SelectSingleNode("ili").InnerText;
                if (ili == combo_Sehir.Text)
                {
                    string sehirAdi = item.SelectSingleNode("ili").InnerText;
                    string durum = item.SelectSingleNode("Durum").InnerText;
                    int maks =Convert.ToInt32( item.SelectSingleNode("Mak").InnerText);
                    string bolge = item.SelectSingleNode("Bolge").InnerText;

                    txt_SehirAdi.Text = sehirAdi;
                    txt_Durum.Text = durum;
                    txt_Maks.Text = maks.ToString()+"°C";
                    txt_Bolge.Text = bolge;

                    if (maks >= 20 && maks < 30)
                    {
                        txt_Durum.Text = "Parçalı Bulutlu";
                    }
                    else if (maks <= 20)
                    {
                        txt_Durum.Text = "Parçalı Az Bulutlu";
                    }
                    else
                    {
                        txt_Durum.Text = "Güneşli";
                    }
                }
            }
        }

        private void combo_Sehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            havaDurumu();
        }
    }
}
