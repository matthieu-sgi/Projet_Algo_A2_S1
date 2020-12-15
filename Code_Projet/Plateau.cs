using System;
using System.Collections.Generic;

namespace Code_Projet
{
    class Plateau
    {
        De[,] plateau;


        public Plateau(De[] TableauDes) //Constructeur du plateau. Prend en paramètre un tableau de dés et le transforme en matrice 4x4.
        {
            if(TableauDes.Length==16)
            {
                for(int i =0;i<4;i++)
                {
                    for(int n = 0 ; n < 4 ; n++)
                    {
                        plateau[i,n] = TableauDes[4*(i+1)+n+1];
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
         static bool Test_Plateau(string mot)
        {
            Stack<int[]> PileLettreDepart = new Stack<int[]>();
            mot = mot.ToUpper();

            for (int i=0;i<plateau.GetLength(0);i++)
            {
                for(int n = 0;n<plateau.GetLength(1);n++)
                {
                    if(plateau[i,n].Get_Face_Superieur==mot[0])
                    {
                        int[] tab2 = { i, n };
                        
                        PileLettreDepart.Push(tab2);
                    }
                }
            }

            int a = PileLettreDepart.Count;  // Juste un entier pour retenir le nombre de fois que la 1ère lettre apparait sur le plateau.
            bool existe = false;  // Le booléen qui servira à nous dire si le mot existe sur le plateau ou pas.
            for (int i = 0; i < a; i++)
            {
                int[] tab = new int [2];
                
                tab = PileLettreDepart.Pop();
               
                int c = tab[0];
                int b =  tab[1];
                if (existe = Recursivite_Plateau(mot.Remove(0, 1), tab[0], tab[1]) == true) 
                {
                    break;
                }
            }
            return existe;
        }



        static bool Recursivite_Plateau(string mot, int ligne, int colonne)

           //plusieurs problèmes : d'abord, je n'arrive pas à
           // trouver le moyen de faire fonctionner la récursivité en mettant en paramètre le mot entier, je dois forcément entrer le mot 
           // sans sa première lettre ainsi que la position de la première lettre du mot dans le plateau

            // Il reste encore à rajouter le fait que on ne peut pas réutiliser une lettre déjà utiliser
        {
            mot = mot.ToUpper();   
            if (mot.Length == 0)
            {
                return true;
            }
            else 
            {
                Stack<int[]> piletab = Test_Voisin(mot[0], ligne, colonne, plateau);
                plateau[ligne, colonne] = '1';
                int[] tab = piletab.Pop();
               
                int[] tabtemp;
                Stack<int[]> piletemp;
                if (tab[0]==0)
                {
                    return false;
                }
                if(tab[0]==1)
                {
                    tab= piletab.Pop();
                    return Recursivite_Plateau(mot.Remove(0, 1),tab[0],tab[1]);
                }
                else 
                {
                    int a = tab[0];
                    for(int i = 1;i<=a;i++)
                    {
                        tab = null;
                        tab = piletab.Pop();
                        piletemp= Test_Voisin(mot[1], tab[0], tab[1], plateau);
                        tabtemp = piletemp.Pop();
                        if (tabtemp[0] == 1)
                        {
                            break;
                        }
                    }
                   
                    return Recursivite_Plateau(mot.Remove(0, 1), tab[0], tab[1]);
                }               
            }
        }
        static Stack<int[]>Test_Voisin(char lettre, int ligne, int colonne)
        {
            Stack<int[]> piletab = new Stack<int[]>();
            int compteurlettre = 0;
            
            if (ligne == 0 && colonne == 0)
            {
                for (int i = ligne; i <= ligne + 1; i++)
                {
                    for (int n = colonne; n <= colonne + 1; n++)
                    {
                        if (plateau[i, n].Get_Face_Superieur == lettre)
                        {
                            int[] tab = { i, n };
                            piletab.Push(tab);
                            compteurlettre += 1;
                        }
                    }
                }
            }
            else if (ligne == 3 && colonne == 3)
            {
                for (int i = ligne - 1; i <= ligne; i++)
                {
                    for (int n = colonne - 1; n <= colonne; n++)
                    {
                        if (plateau[i, n].Get_Face_Superieur == lettre)
                        {
                            int[] tab = { i, n };
                            piletab.Push(tab);
                            compteurlettre += 1;
                        }
                    }
                }
            }
            else if (ligne == 3 && colonne == 0)
            {
                for (int i = ligne - 1; i <= ligne; i++)
                {
                    for (int n = colonne; n <= colonne + 1; n++)
                    {
                        if (plateau[i, n].Get_Face_Superieur == lettre)
                        {
                            int[] tab = { i, n };
                            piletab.Push(tab);
                            compteurlettre += 1;
                        }
                    }
                }
            }
            else if (ligne == 0 && colonne == 3)
            {
                for (int i = ligne; i <= ligne + 1; i++)
                {
                    for (int n = colonne - 1; n <= colonne; n++)
                    {
                        if (plateau[i, n].Get_Face_Superieur == lettre)
                        {
                            int[] tab = { i, n };
                            piletab.Push(tab);
                            compteurlettre += 1;
                        }
                    }
                }
            }
            else if (ligne == 0)
            {
                for (int i = ligne; i <= ligne + 1; i++)
                {
                    for (int n = colonne - 1; n <= colonne + 1; n++)
                    {
                        if (plateau[i, n].Get_Face_Superieur == lettre)
                        {
                            int[] tab = { i, n };
                            piletab.Push(tab);
                            compteurlettre += 1;
                        }
                    }
                }
            }
            else if (ligne == 3)
            {
                for (int i = ligne - 1; i <= ligne; i++)
                {
                    for (int n = colonne - 1; n <= colonne + 1; n++)
                    {
                        if (plateau[i, n].Get_Face_Superieur == lettre)
                        {
                            int[] tab = { i, n };
                            piletab.Push(tab);
                            compteurlettre += 1;
                        }
                    }
                }
            }
            else if (colonne == 0)
            {
                for (int i = ligne - 1; i <= ligne + 1; i++)
                {
                    for (int n = colonne; n <= colonne + 1; n++)
                    {
                        if (plateau[i,n].Get_Face_Superieur == lettre)
                        { 
                            int[] tab = { i, n };
                            piletab.Push(tab);
                            compteurlettre += 1;
                        }
                    }
                }
            }
            else if (colonne == 3)
            {
                for (int i = ligne - 1; i <= ligne + 1; i++)
                {
                    for (int n = colonne - 1; n <= colonne; n++)
                    {
                        if (plateau[i, n].Get_Face_Superieur == lettre)
                        {
                            int[] tab = { i, n };
                            piletab.Push(tab);
                            compteurlettre += 1;
                        }
                    }
                }
            }
            else
            {
                for (int i = ligne - 1; i <= ligne + 1; i++)
                {
                    for (int n = colonne - 1; n <= colonne + 1; n++)
                    {
                        if (plateau[i, n].Get_Face_Superieur == lettre)
                        {
                            int[] tab = { i, n };
                            piletab.Push(tab);
                            compteurlettre += 1;
                        }
                        
                    }
                }
            }
            int[] tabcompteur = new int[2];
            tabcompteur[0] = compteurlettre;
            piletab.Push(tabcompteur);


            return piletab;
            
        }
    }
}