using System;
using System.Collections.Generic;


namespace Code_Projet
{
    class Jeu
    {
        private Dictionnaire mondico;
        private Plateau monplateau;
        private List<Joueur> joueurs;
        private string path_de;


        public Jeu(string _path_de, string path_dictionnaire, string langue_dictionnaire, List<Joueur> _joueurs)//Constructeur de base 
        {
            this.mondico = new Dictionnaire(langue_dictionnaire, path_dictionnaire);
            
            this.path_de = _path_de;
            this.joueurs = _joueurs;
        }

        public Jeu(string _path_de, string path_dictionnaire, string langue_dictionnaire,  List<Joueur> _joueurs, char separator) //Constructeur prenant en compte le séparateur de l'utilisateur
        {
            this.mondico = new Dictionnaire(langue_dictionnaire, path_dictionnaire, separator);
            this.path_de = _path_de;
            
            this.joueurs = _joueurs;

        }
        /// <summary>
        /// Fonction qui permet de jouer un tour. Pour connaitre qui doit jouer, elle prend en argument le numéro du joueur
        /// </summary>
        /// <param name="player_id"></param>
        public void Tour(int player_id)
        {
            int temps_tour = 60; //Temps d'un tour (60 s)
            DateTime start = DateTime.Now; //On établit le temps au lancement de la fonction
            this.monplateau = new Plateau(this.path_de); //On créer un plateau pour le tour en cours
            this.joueurs[player_id].Words.Clear(); //On efface les mots que le joueurs avait rentrés au tour précédent
            

            while ((DateTime.Now - start).TotalSeconds <= temps_tour) //On installe le chronomètre de 60s
            {

                monplateau.Print_plateau(); //On affiche le plateau

                
                Console.Write("Entrer votre mot : ");
                
                string mot = Console.ReadLine();
                
                mot = mot.ToUpper(); //On travaille dans notre code qu'avec des majuscules, il faut donc utiliser cette fonction

                if ((DateTime.Now - start).TotalSeconds <= temps_tour) //On vérifie si le tour n'est pas fini
                {
                    if (mot != null && mot.Length - this.mondico.Nb_min_lettres < this.mondico.Dico_Complet.Count && mot.Length - this.mondico.Nb_min_lettres >= 0) //On vérifie si le mot entré n'est ni nul, ni plus petit ou plus grand que tous les mots du dictionnaire
                    {
                        if (this.mondico.RechDichoRecursif(0, this.mondico.Dico_Complet[mot.Length - this.mondico.Nb_min_lettres].Split(this.mondico.Separator).Length, mot)) //On appelle la fonction qui vérifie si le mot existe dans le dictionnaire
                        {
                            if (!this.joueurs[player_id].Contains(mot)) //On vérifie si le joueur à déjà entré ce mot
                            {
                                if (this.monplateau.Test_Plateau(mot))//On vérifie si le mot existe sur le plateau
                                {
                                    joueurs[player_id].Add_Mot(mot); //On ajoute le mot dans la liste et les points au joueur
                                    Console.Clear();
                                    Console.WriteLine("Mot accepté");
                                    this.joueurs[player_id].Print_Words();//On affiche les mots que le joueur à déjà entré
                                    Console.WriteLine();
                                    Console.WriteLine("Votre score est de : " + this.joueurs[player_id].Score);

                                }
                                else
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Le mot n'est pas présent dans le plateau actuel");
                                    Console.ForegroundColor = ConsoleColor.Gray;

                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Mot déjà utilisé");
                                Console.ForegroundColor = ConsoleColor.Gray;

                            }

                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Le mot entré n'existe pas dans le dictionnaire actuel");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Le mot entré n'existe pas dans le dictionnaire actuel");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                else Console.Write("Le mot n'a pas été compté, ");

            }
            Console.WriteLine("Votre tour est terminé, vous avez " + this.joueurs[player_id].Score + " points"); //On affiche les points du joueur dont le tour vient de se finir



        }



    }
}