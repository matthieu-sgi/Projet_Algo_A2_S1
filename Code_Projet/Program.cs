using System;
using System.Collections.Generic;
using System.IO;


namespace Code_Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            string path_fichier_de = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Fichiers_importes\Des.txt";
            string path_Dictionnaire_Francais = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Fichiers_importes\Dictionnaire.txt";
            //string path_fichier_de = @"\Fichiers_importés\Des.txt";
            //string path_Dictionnaire_Francais =@"\Fichiers_importés\Dictionnaire.txt";
            DateTime start = DateTime.Now;
            List<Joueur> joueurs = new List<Joueur>(); 
            joueurs.Add(new Joueur("Matthieu"));
            joueurs.Add(new Joueur("Hugo"));
            Jeu game = new Jeu(path_fichier_de,path_Dictionnaire_Francais,"Francais",joueurs);
            int counter = 0;

            while((DateTime.Now - start).Minutes <= 6)
            {
                if(counter<joueurs.Count){
                    
                    game.Tour(counter);
                    
                }
                else counter = 0;
            

            }

        }
    }
}
