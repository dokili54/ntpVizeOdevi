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
        }
    }
}
