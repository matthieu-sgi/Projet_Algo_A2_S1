using System;
using System.Collections.Generic;
using System.IO;


namespace Code_Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            string path_fichier_de =  @".\Fichiers_importes\Des.txt"; //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +
            string path_Dictionnaire_Francais =  @".\Fichiers_importes\Dictionnaire.txt"; //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +
           
            DateTime start = DateTime.Now;
            List<Joueur> joueurs = new List<Joueur>(); 
            joueurs.Add(new Joueur("Matthieu"));
            joueurs.Add(new Joueur("Hugo"));
            Jeu game = new Jeu(path_fichier_de,path_Dictionnaire_Francais,"Francais",joueurs);
            int counter = 0;

            while((DateTime.Now - start).Minutes <= 6)
            {
                if(counter<joueurs.Count){
                    Console.WriteLine("Au tour du joueur " + (counter+1) );
                    game.Tour(counter);
                    counter++;
                    
                    
                }
                else counter = 0;
            

            }

        }
    }
}
