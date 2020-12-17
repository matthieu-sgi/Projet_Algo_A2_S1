using System;
using System.Collections.Generic;
using System.IO;


namespace Code_Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            string path_fichier_de = @".\Fichiers_importes\Des.txt"; //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +
            string path_Dictionnaire_Francais = @".\Fichiers_importes\Dictionnaire.txt"; //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +

            DateTime start = DateTime.Now;
            List<Joueur> joueurs = new List<Joueur>();
            Console.WriteLine("Entrer le nom du joueur n°1");
            joueurs.Add(new Joueur(Console.ReadLine()));
            Console.WriteLine("Entrer le nom du joueur n°2");
            joueurs.Add(new Joueur(Console.ReadLine()));
            Jeu game = new Jeu(path_fichier_de, path_Dictionnaire_Francais, "Francais", joueurs);
            int counter_player = 0;
            int tour = 0;

            while (tour <= 6)
            {
                if (counter_player < joueurs.Count)
                {
                    Console.WriteLine("Au tour de " + joueurs[counter_player].Name);
                    game.Tour(counter_player);
                    tour++;
                    counter_player++;


                }
                else counter_player = 0;


            }

            Console.WriteLine("La partie est terminée !\nVoici les résultats :\n" + joueurs[1].Name + " : " + joueurs[1].Score + "point(s)\n" + joueurs[2].Name + " : " + joueurs[2].Score + "point(s)\n");
            if (joueurs[1].Score < joueurs[2].Score) Console.WriteLine("La victoire revient à " + joueurs[2].Name);
            else if (joueurs[1].Score > joueurs[2].Score) Console.WriteLine("La victoire revient à " + joueurs[1].Name);
            else Console.WriteLine("Egalité");


        }
    }
}
