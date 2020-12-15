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


        public Jeu( string path_de,string path_dictionnaire, string langue_dictionnaire, List<Joueur> _joueurs)
        {
            this.mondico = new Dictionnaire(langue_dictionnaire, path_dictionnaire);
            this.monplateau = new Plateau(path_de);
            this.joueurs = _joueurs;
        }

        public Jeu( string path_de,string path_dictionnaire, string langue_dictionnaire, char separator, List<Joueur> _joueurs)
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
                Console.Write("Entrer votre mot : ");
                string mot = Console.ReadLine();
                if ((DateTime.Now - start).Minutes <= temps_tour)
                {
                    if (this.mondico.RechDichoRecursif(0, this.mondico.Length_Dico, mot))
                    {
                        if (this.monplateau.Test_Plateau(mot))
                        {
                            joueurs[player_id].Add_Mot(mot);
                            Console.Clear();
                            Console.WriteLine("Mot accepté");

                        }

                    }
                    else Console.WriteLine("Le mot entré n'existe pas dans le dictionnaire actuel");
                }
                else Console.Write("Le mot n'a pas été compté, ");

            }
            Console.WriteLine("Votre tour est terminé");



        }



    }
}