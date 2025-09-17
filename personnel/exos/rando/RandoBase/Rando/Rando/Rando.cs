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
            List<Trackpoint> trackpoints = new List<Trackpoint>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Ballade_châtaignère_🌰.gpx");

            XmlNodeList nodes = xmlDoc.GetElementsByTagName("trkpt");

            foreach (XmlNode node in nodes)
            {
                trackpoints.Add(new Trackpoint(double.Parse(node.Attributes["lat"].Value), double.Parse(node.Attributes["lon"].Value), double.Parse(node["ele"].InnerText)));
            }

            trackpoints.ForEach(trackpoint => Trace.WriteLine(trackpoint));

            Pen myPen = new Pen(Color.Red);
            myPen.Width = 2;

            List<PointF> points = trackpoints.Select(t => new PointF((float)(t.longitude), (float)(t.latitude))).ToList();
            points.ForEach(point => Trace.WriteLine(point));
            this.CreateGraphics().DrawLines(myPen, points.ToArray());

        } 
    }
}
