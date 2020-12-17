using System;
using System.Collections.Generic;
using System.IO;

namespace Code_Projet
{
    class Jeu
    {
        private Dictionnaire mondico;
        private Plateau monplateau;
        private List<Joueur> joueurs;
        private string path_de;


        public Jeu(string _path_de, string path_dictionnaire, string langue_dictionnaire, List<Joueur> _joueurs)
        {
            this.mondico = new Dictionnaire(langue_dictionnaire, path_dictionnaire);
            //this.monplateau = new Plateau(path_de);
            this.path_de = _path_de;
            this.joueurs = _joueurs;
        }

        public Jeu(string _path_de, string path_dictionnaire, string langue_dictionnaire, char separator, List<Joueur> _joueurs)
        {
            this.mondico = new Dictionnaire(langue_dictionnaire, path_dictionnaire, separator);
            this.path_de = _path_de;
            //this.monplateau = new Plateau(path_de);
            this.joueurs = _joueurs;

        }

        public void Tour(int player_id)
        {
            int temps_tour = 30; //30 pour 30 secondes
            DateTime start = DateTime.Now;
            this.monplateau = new Plateau(this.path_de);
            this.joueurs[player_id].Words.Clear();

            while ((DateTime.Now - start).Seconds <= temps_tour)
            {

                monplateau.Print_plateau();

                //Lignes de test
                //Console.WriteLine(mondico.toString());
                //Console.WriteLine(mondico.Nb_min_lettres);
                //Console.WriteLine(mondico.Dico_Complet[0]);


                Console.Write("Entrer votre mot : ");
                string mot = Console.ReadLine();
                mot.ToUpper();
                if ((DateTime.Now - start).Seconds <= temps_tour)
                {
                    if (mot.Length - this.mondico.Nb_min_lettres < this.mondico.Dico_Complet.Count)
                    {
                        if (this.mondico.RechDichoRecursif(0, this.mondico.Dico_Complet[mot.Length - this.mondico.Nb_min_lettres].Split(this.mondico.Separator).Length, mot))
                        {
                            if (!this.joueurs[player_id].Contains(mot))
                            {
                                if (this.monplateau.Test_Plateau(mot))
                                {
                                    joueurs[player_id].Add_Mot(mot);
                                    Console.Clear();
                                    Console.WriteLine("Mot accepté");
                                    this.joueurs[player_id].Print_Words();
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
            Console.WriteLine("Votre tour est terminé, vous avez gagné " + this.joueurs[player_id].Score + " points");



        }



    }
}