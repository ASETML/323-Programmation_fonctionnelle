namespace ex_marche
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Liste de Stands
            List<Stand> stands = new List<Stand>();

            //Lecture du CSV et ajout du stand à la liste
            StreamReader sr = new StreamReader("stands.csv");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] values = line.Split(';');
                stands.Add(new Stand(int.Parse(values[0]), values[1], values[2], int.Parse(values[3]), values[4], double.Parse(values[5])));
            }
            sr.Close();

            //Comptage des stands de pêches
            int nbStandsPeches = 0;
            foreach (Stand stand in stands)
            {
                if (stand.GetProduit() == "Pêches")
                {
                    nbStandsPeches++;
                }
            }

            Console.WriteLine($"Il y a {nbStandsPeches} vendeurs de pêches");

            //Trouver le producteur qui a le plus de pastèque
            string NomProducteur = "";
            int StandNumero = 0;
            int NombrePasteques = 0;

            foreach (Stand stand in stands)
            {
                if (stand.GetProduit() == "Pastèques" && stand.GetQte() > NombrePasteques)
                {
                    NomProducteur = stand.GetProducteur();
                    StandNumero = stand.GetEmplacement();
                    NombrePasteques = stand.GetQte();
                }
            }

            Console.WriteLine($"C'est {NomProducteur} qui a le plus de pastèques (stand {StandNumero}, {NombrePasteques} pièces)");
        }
    }
}