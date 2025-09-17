using System.Diagnostics;
using System.Xml;

namespace Rando
{
    public partial class Rando : Form
    {
        public Rando()
        {
            InitializeComponent();
        }

        private void Rando_Form_Paint(object sender, PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Red);
            myPen.Width = 2;

            Point[] points = new Point[4] { new Point(30,50), new Point(50,10), new Point(80,50), new Point(111,400) };
            this.CreateGraphics().DrawLines(myPen, points);

            List<Trackpoint> trackpoints = new List<Trackpoint>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("gemmikandersteg.gpx");

            XmlNodeList nodes = xmlDoc.GetElementsByTagName("trkpt");

            foreach (XmlNode node in nodes) 
            {
                trackpoints.Add(new Trackpoint(double.Parse(node.Attributes["lat"].Value), double.Parse(node.Attributes["lon"].Value), double.Parse(node["ele"].InnerText)));
            }

            trackpoints.ForEach(trackpoint => Trace.WriteLine(trackpoint));
        }
    }
}
