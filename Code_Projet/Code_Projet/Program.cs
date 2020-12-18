using System;
using System.Collections.Generic;



namespace Code_Projet
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Si vous avez déplacé les fichiers Dictionnaire.txt et Des.txt, veuillez renseigner leurs nouvelles positions 
            string path_fichier_de = @"..\..\..\..\Fichiers_importes\Des.txt";
            string path_Dictionnaire_Francais = @"..\..\..\..\Fichiers_importes\Dictionnaire.txt";


            List<Joueur> joueurs = new List<Joueur>(); //Création de la liste de joueurs
            //Ajout des joueurs
            bool wanting_an_IA = false;
            Console.Write("Voulez-vous jouer contre une IA ? (y/N) : ");
            string retour_user = Console.ReadLine();
            retour_user = retour_user.ToUpper();
            bool test_ia = false;

            while(!test_ia) //Choix de l'ajout de l'IA
            {
                switch (retour_user)
                {
                    
                    case "Y":
                        wanting_an_IA = true;
                        test_ia = true;
                        break;

                    case "":
                    case "N":
                        wanting_an_IA = false;
                        test_ia = true;
                        break;
                    default:
                        break;

                }
            }

            if (!wanting_an_IA)
            {
                Console.WriteLine("Entrer le nom du joueur n°1");
                joueurs.Add(new Joueur(Console.ReadLine()));
                Console.WriteLine("Entrer le nom du joueur n°2");
                joueurs.Add(new Joueur(Console.ReadLine()));
            }else
            {
                Console.WriteLine("Entrer le nom du joueur");
                joueurs.Add(new Joueur(Console.ReadLine()));
                joueurs.Add(new Joueur());
            }

            //Création du jeu
            Jeu game = new Jeu(path_fichier_de, path_Dictionnaire_Francais, "Francais", joueurs); //Si vous voulez spécifier un séparateur, ajoutez le séparateur en argument
            int counter_player = 0;
            int tour = 0;

            while (tour <= 6) //On a choisi de compter en nombre de tour de 1min (6 tours = 6 min)
            {
                if (!wanting_an_IA)
                {
                    if (counter_player < joueurs.Count)
                    {
                        Console.WriteLine("Au tour de " + joueurs[counter_player].Name);
                        game.Tour(counter_player); //On fait jouer le joueur
                        tour++;
                        counter_player++;


                    }
                    else counter_player = 0;
                }
                else
                {
                    Console.WriteLine("Au tour de " + joueurs[0].Name);
                    game.Tour(counter_player); //On fait jouer le joueur
                    tour++;
                    game.IA_turn();
                    tour++;
                }

            }

            //Bloc d'affichage du résultat
            Console.Clear();
            Console.WriteLine("La partie est terminée !\nVoici les résultats :\n" + joueurs[1].Name + " : " + joueurs[1].Score + "point(s)\n" + joueurs[2].Name + " : " + joueurs[2].Score + "point(s)\n");
            if (joueurs[1].Score < joueurs[2].Score) Console.WriteLine("La victoire revient à " + joueurs[2].Name);
            else if (joueurs[1].Score > joueurs[2].Score) Console.WriteLine("La victoire revient à " + joueurs[1].Name);
            else Console.WriteLine("Egalité");
            Console.ReadKey();


        }
    }
}
