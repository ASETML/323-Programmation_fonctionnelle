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

            Pen myPen = new Pen(Color.Red);
            myPen.Width = 2;

            List<PointF> points = trackpoints.Select(t => new PointF((float)(t.longitude), (float)(t.latitude))).ToList();
            //points.ForEach(point => Trace.WriteLine(point));
            this.CreateGraphics().DrawLines(myPen, points.ToArray());

            //Calcul de la longueur du tracé avec aggregate
            double length = 0;
            Func<Trackpoint, Trackpoint, Trackpoint> calculateLength = (a, b) =>
            {
                //Pythagore
                //length += Math.Sqrt(Math.Pow(a.latitude - b.latitude, 2) + Math.Pow(a.longitude - b.longitude, 2));

                //Version 3d
                length += Math.Sqrt(Math.Pow(Math.Sqrt(Math.Pow(a.latitude - b.latitude, 2) + Math.Pow(a.longitude - b.longitude, 2)), 2) + Math.Pow(a.elevation - b.elevation, 2));
                //Trace.WriteLine(length);
                return b;
            };

            trackpoints.Aggregate(trackpoints.First(), (a, b) => calculateLength(a, b));

            Trace.WriteLine(length);

            length = 0;
            //Calcul de la longueur du tracé avec zip et skip
            trackpoints
                .Select(t => new Trackpoint(t.latitude, t.longitude, t.elevation))
                .Zip(trackpoints.Skip(1).Select(t => new Trackpoint(t.latitude, t.longitude, t.elevation)))
                .ToList()
                .ForEach(i => calculateLength(i.ToTuple().Item1, i.ToTuple().Item2));

            Trace.WriteLine(length);

            Color[] gradient = new Color[]
            {
                Color.FromArgb(255, 144, 238, 144), // Vert clair
                Color.FromArgb(255, 162, 216, 128),
                Color.FromArgb(255, 180, 194, 112),
                Color.FromArgb(255, 198, 172, 96),
                Color.FromArgb(255, 216, 150, 80),
                Color.FromArgb(255, 234, 128, 64),
                Color.FromArgb(255, 244, 106, 48),
                Color.FromArgb(255, 248,  84, 36),
                Color.FromArgb(255, 252,  62, 24),
                Color.FromArgb(255, 254,  48, 18),
                Color.FromArgb(255, 255,  32, 12),
                Color.FromArgb(255, 255,  16,  6),
                Color.FromArgb(255, 255,   0,  0)  // Rouge vif
            };

        }
    }
}
