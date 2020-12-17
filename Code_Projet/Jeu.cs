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


        public Jeu(string path_de, string path_dictionnaire, string langue_dictionnaire, List<Joueur> _joueurs)
        {
            this.mondico = new Dictionnaire(langue_dictionnaire, path_dictionnaire);
            this.monplateau = new Plateau(path_de);
            this.joueurs = _joueurs;
        }

        public Jeu(string path_de, string path_dictionnaire, string langue_dictionnaire, char separator, List<Joueur> _joueurs)
        {
            this.mondico = new Dictionnaire(langue_dictionnaire, path_dictionnaire, separator);
            this.monplateau = new Plateau(path_de);
            this.joueurs = _joueurs;

        }

        public void Tour(int player_id)
        {
            int temps_tour = 1; //30 pour 30 secondes
            DateTime start = DateTime.Now;

            while ((DateTime.Now - start).Minutes <= temps_tour)
            {
                monplateau.Print_plateau();
                Console.WriteLine(mondico.toString());
                Console.WriteLine(mondico.Nb_min_lettres);
                Console.WriteLine(mondico.Dico_Complet[0]);


                Console.Write("Entrer votre mot : ");
                string mot = Console.ReadLine();
                if ((DateTime.Now - start).Minutes <= temps_tour)
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
                                Console.WriteLine("Votre score est de : " + this.joueurs[player_id].Score);

                            }else Console.WriteLine("Le mot n'est pas présent dans le plateau actuel");
                        }else Console.WriteLine("Mot déjà utilisé");

                    }
                    else Console.WriteLine("Le mot entré n'existe pas dans le dictionnaire actuel");
                }
                else Console.Write("Le mot n'a pas été compté, ");

            }
            Console.WriteLine("Votre tour est terminé, vous avez gagné " + this.joueurs[player_id].Score + " points");



        }



    }
}