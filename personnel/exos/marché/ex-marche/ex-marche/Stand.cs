using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_marche
{
    internal class Stand
    {
        private int Emplacement;
        private string Producteur;
        private string Produit;
        private int Qte;
        private string Unite;
        private double PrixUnitaire;

        public Stand(int emplacement, string producteur, string produit, int qte, string unite, double prixUnitaire)
        {
            Emplacement = emplacement;
            Producteur = producteur;
            Produit = produit;
            Qte = qte;
            Unite = unite;
            PrixUnitaire = prixUnitaire;
        }

        public string GetProduit()
        {
            return this.Produit;
        }

        public int GetEmplacement()
        {
            return this.Emplacement;
        }

        public string GetProducteur()
        {
            return this.Producteur;
        }

        public int GetQte()
        {
            return this.Qte;
        }

        public double GetPrixUnitaire()
        {
            return this.PrixUnitaire;
        }

        public override string ToString()
        {
            return $"Stand numéro {Emplacement} qui appartient à {Producteur} vend {Qte}{Unite} de {Produit} avec un prix unitaire de {PrixUnitaire}";
        }
    }
}
