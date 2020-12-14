using System;

namespace Code_Projet
{
    class Plateau
    {
        Des[,]plateau;


        public Plateau(Des[]TableauDés) //Constructeur du plateau. Prend en paramètre un tableau de dés et le transforme en matrice 4x4.
        {
            if(TableauDés.Length==16)
            {
                for(int i =0;i<4;i++)
                {
                    for(int n = 0 ; n < 4 ; n++)
                    {
                        plateau[i,n] = TableauDés[4*(i+1)+n+1];
                    }
                }
            }
            else
            {
                Console.WriteLine("Il n'y a pas 16 dés");
            }
        }

        public string toString()  //Méthode toString permettant d'afficher le plateau de jeu dans l'état actuel.
        {
            string s = "Le plateau est le suivant : \n"
            for (int i = 0 ; i<4;i++)
            {
                for(int n = 0 ; n < 4 ; n++)
                {
                    s = s + plateau[i,n].GetFaceSuperieure ;
                    if(n!=3)
                    {
                        s = s + " ; ";
                    }
                }
                s = s + "\n" ;
            }
            return s;
        }
        public bool Test_Plateau(string mot)
        {
          mot = mot.ToUpper();
            if(mot.Length==0)
            {
                return true;
            }
            else if()
            {
                
            }
        }
        static int[] Test_Voisin(char lettre, int ligne, int colonne)
        {
           int[]tab = new int [2]
            if(ligne==0&&colonne==0)
            {
                for(int i = ligne;i<=ligne+1;i++)
                {
                    for(int n=colonne;n<=colonne+1;n++)
                    {
                        if(plateau[i,n].GetFaceSuperieure==lettre)
                        {
                            return tab{i,n};
                        }
                    }
                }
            }
            if(ligne==0&&colonne==0)
            {
                for(int i = ligne;i<=ligne+1;i++)
                {
                    for(int n=colonne;n<=colonne+1;n++)
                    {
                        if(plateau[i,n].GetFaceSuperieure==lettre)
                        {
                            return tab{i,n};
                        }
                    }
                }
            }
            if(ligne==0&&colonne==0)
            {
                for(int i = ligne;i<=ligne+1;i++)
                {
                    for(int n=colonne;n<=colonne+1;n++)
                    {
                        if(plateau[i,n].GetFaceSuperieure==lettre)
                        {
                            return tab{i,n};
                        }
                    }
                }
            }
            if(ligne==0&&colonne==0)
            {
                for(int i = ligne;i<=ligne+1;i++)
                {
                    for(int n=colonne;n<=colonne+1;n++)
                    {
                        if(plateau[i,n].GetFaceSuperieure==lettre)
                        {
                            return tab{i,n};
                        }
                    }
                }
            }
        }
    }
}