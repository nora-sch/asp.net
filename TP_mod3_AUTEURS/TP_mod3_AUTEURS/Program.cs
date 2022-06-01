using ProjetLinq.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_mod3_AUTEURS
{
    internal class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();
        static void Main(string[] args)
        {
            InitialiserDatas();

            //o Afficher la liste des prénoms des auteurs dont le nom commence par "G"
            var authorsG = ListeAuteurs.Where(a => a.Nom.StartsWith("G")).Distinct();
            // var prenomsG = ListeAuteurs.Where(a => a.Nom.ToUpper().StartsWith("G")).Select(a => a.Prenom);
            Console.WriteLine();
            Console.WriteLine("La liste des prénoms des auteurs dont le nom commence par G");
            foreach (var auteur in authorsG)
            {
                Console.WriteLine(auteur.Prenom);
            }
            //o Afficher l’auteur ayant écrit le plus de livres
            Console.WriteLine();
            Console.WriteLine("L’auteur ayant écrit le plus de livres");
            var auteurPlusDeLivres = ListeLivres.GroupBy(l => l.Auteur).OrderByDescending(g => g.Count()).FirstOrDefault().Key;
            var countLivres = ListeLivres.Where(l => l.Auteur == auteurPlusDeLivres).Count();
            Console.WriteLine($"{auteurPlusDeLivres.Nom.ToUpper()} {auteurPlusDeLivres.Prenom} - {countLivres} livres");

            //o Afficher le nombre moyen de pages par livre par auteur
            Console.WriteLine();
            Console.WriteLine("Le nombre moyen de pages par livre par auteur");
            var livresParAuthor = ListeLivres.GroupBy(l => l.Auteur);
              foreach (var livres in livresParAuthor)
            {
                Console.WriteLine($"{livres.Average(l => l.NbPages)} pages - {livres.Key.Nom} {livres.Key.Prenom} ");
            }

              //o Afficher le titre du livre avec le plus de pages
            Console.WriteLine();
            Console.WriteLine("Le titre du livre avec le plus de pages");
            var livrePlusDePages = ListeLivres.OrderByDescending(l => l.NbPages).First();
            Console.WriteLine($"Livre {livrePlusDePages.Titre} a {livrePlusDePages.NbPages} pages");

            //o Afficher combien ont gagné les auteurs en moyenne(moyenne des factures)
            Console.WriteLine();
            Console.WriteLine("Les auteurs en moyenne(moyenne des factures) on gagné ");
            var moyenneFactures = ListeAuteurs.Average(a => a.Factures.Sum(f => f.Montant));
            Console.WriteLine($"{moyenneFactures} EUR");

            //o Afficher les auteurs et la liste de leurs livres
            Console.WriteLine();
            Console.WriteLine("Les auteurs et la liste de leurs livres");
            var listeAuteursLivres = ListeLivres.GroupBy(l => l.Auteur);
            foreach (var livres in listeAuteursLivres)
            {
                Console.WriteLine($"Auteur : {livres.Key.Prenom} {livres.Key.Nom} ");
                foreach (var livre in livres)
                {
                    Console.WriteLine($" - {livre.Titre}");
                }
            }
                //o Afficher les titres de tous les livres triés par ordre alphabétique
                Console.WriteLine();
            Console.WriteLine("Les titres de tous les livres triés par ordre alphabétique");
            // ListeLivres.Select(l => l.Titre).OrderBy(t => t).ToList().ForEach(Console.WriteLine);
            var livresTriesAlph = ListeLivres.OrderBy(l => l.Titre);
            foreach (var livre in livresTriesAlph)
            {
                Console.WriteLine($"{livre.Titre}");
            }

            //o Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne
            Console.WriteLine();
            var pagesMoyen = ListeLivres.Average(a => a.NbPages);
            Console.WriteLine($"La liste des livres dont le nombre de pages est supérieur à la moyenne {pagesMoyen}");
         
            var listeLivresPagesPlusMoyen = ListeLivres.Where(p => p.NbPages > pagesMoyen);
        
            foreach (var livre in listeLivresPagesPlusMoyen)
            {
                Console.WriteLine($"{livre.Titre} {livre.NbPages}");
            }

            //o Afficher l'auteur ayant écrit le moins de livres
            Console.WriteLine();
            Console.WriteLine("L'auteur ayant écrit le moins de livres");
            var auteurMoinsDeLivres = ListeLivres.GroupBy(a=>a.Auteur).OrderByDescending(g => g.Count()).LastOrDefault().Key;
            var livresParAuteur = ListeLivres.Where(l => l.Auteur == auteurMoinsDeLivres).Count();
            Console.WriteLine($"{auteurMoinsDeLivres.Nom} {auteurMoinsDeLivres.Prenom} - {livresParAuteur} livres");

            Console.ReadKey();
        }
        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
    }
}
