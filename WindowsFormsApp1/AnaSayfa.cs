using DevExpress.DataAccess.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading;
using System.Timers;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class AnaSayfa : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


    
            public AnaSayfa()
        {
            InitializeComponent();
            //labelDolar.Text = "USD:";
            //labelEuro.Text = "EUR:";
            //labelGramAltın.Text = "Gram Altın:";
            //lblceyrekAltın.Text = "Çeyrek Altın:";
            //labelYarımAltın.Text = "Yarım Altın:";
            //lblTamAltın.Text = "Tam Altın:";
            //labelCumhuriyetAltini.Text = "Cumhuriyet Altın:";
            //labelSterlin.Text = "Sterlin:";
            this.panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);
            this.panel1.MouseUp += new MouseEventHandler(panel1_MouseUp);
            this.panel1.MouseMove += new MouseEventHandler(panel1_MouseMove);
           
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {
           
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {
            if (panelKurlarıYenile.Visible == true)
            {
                panelKurlarıYenile.Visible = false;
            }
            else
            {
                panelKurlarıYenile.Visible = true;
            }
        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string url = "https://bigpara.hurriyet.com.tr/altin/";
            WebClient client = new WebClient();
            string xmlData = client.DownloadString(url);

            // Parse XML data
            XDocument doc = XDocument.Parse(xmlData);
            XElement ratesElement = doc.Element("Kurlar");

            // Update label values
        //    labelDolar.Text = "USD: " + GetRateValue(ratesElement, "USD");
        //    labelEuro.Text = "EUR: " + GetRateValue(ratesElement, "EUR");
        //    labelGramAltın.Text = "Gram Altın: " + GetRateValue(ratesElement, "Altın");
        //    lblceyrekAltın.Text = "Çeyrek Altın: " + GetRateValue(ratesElement, "Çeyrek");
        //    labelYarımAltın.Text = "Yarım Altın: " + GetRateValue(ratesElement, "Yarım");
        //    lblTamAltın.Text = "Tam Altın: " + GetRateValue(ratesElement, "Tam");
        //    labelCumhuriyetAltini.Text = "Cumhuriyet Altın: " + GetRateValue(ratesElement, "Cumhuriyet");
        //    labelSterlin.Text = "Sterlin: " + GetRateValue(ratesElement, "Sterlin");
        }
        private string GetRateValue(XElement ratesElement, string currency)
        {
            XElement rateElement = ratesElement.Element(currency);
            if (rateElement != null)
            {
                return rateElement.Attribute("Alis").Value + " - " + rateElement.Attribute("Satis").Value;
            }
            else
            {
                return "N/A";
            }
        }
    }
}
