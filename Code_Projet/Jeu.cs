using System;
using System.Collections.Generic;

namespace Code_Projet
{
    class Jeu
    {
        private Dictionnaire mondico;
        private Plateau monplateau;
        private List<Joueur> joueurs;

        
        public Jeu(string path_dictionnaire, string path_de, string langue_dictionnaire, List<Joueur> _joueurs) 
        {
            this.mondico = new Dictionnaire(langue_dictionnaire, path_dictionnaire);
            this.monplateau = new Plateau();
            this.joueurs = _joueurs;
        }

        public Jeu(string path_dictionnaire, string path_de, string langue_dictionnaire, char separator, List<Joueur> _joueurs)
        {
            this.mondico = new Dictionnaire(langue_dictionnaire, path_dictionnaire, separator);
            this.monplateau = new Plateau();
            this.joueurs = _joueurs;

        }

        public void Tour(int player_id)
        {
            int temps_tour = 30; //30 pour 30 secondes
            DateTime start = DateTime.Now;

            while ((DateTime.Now - start).Seconds <= temps_tour)
            {
                Console.Write("Entrer votre mot : ");
                string mot = Console.ReadLine();
                if(this.mondico.RechDichoRecursif(0,this.mondico.Length_Dico,mot))
                {

                }
                else Console.WriteLine("Le mot entré n'existe pas dans le dictionnaire actuel");

            }

            

        }



    }
}