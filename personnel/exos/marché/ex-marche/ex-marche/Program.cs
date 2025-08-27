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
            int nbStandsPeches = stands.Where(s => s.GetProduit() == "Pêches").ToList().Count();

            Console.WriteLine($"Il y a {nbStandsPeches} vendeurs de pêches");

            //Trouver le producteur qui a le plus de pastèque
            Stand BestPastequesStand = stands.OrderBy(s => s.GetQte()).Where(s => s.GetProduit() == "Pastèques").Last();

            Console.WriteLine($"C'est {BestPastequesStand.GetProducteur()} qui a le plus de pastèques (stand {BestPastequesStand.GetEmplacement()}, {BestPastequesStand.GetQte()} pièces)");
            
            //Trouver les producteurs qui vendent plus de 10kg de melons
            List<Stand> MelonProducteurs = stands.Where(s => s.GetQte() > 10 && s.GetProduit() == "Melons").OrderBy(s => s.GetPrixUnitaire()).ToList();
            MelonProducteurs.ForEach(m => Console.WriteLine(m));

            //Trouver la quantité de tomate en vente
            int TomateQte = stands.Where(s => s.GetProduit() == "Tomates").Sum(s => s.GetQte());
            Console.WriteLine($"Il y a {TomateQte}kg de tomate en vente");
        }
    }
}