using System;
using System.Collections.Generic;
using System.IO;

namespace Code_Projet
{
    public class Plateau
    {
        private De[,] plateau = new De[4, 4];




        public Plateau(string _path_de) //Constructeur du plateau. Prend en paramètre un tableau de dés et le transforme en matrice 4x4.
        {
            this.Create_Plateau(_path_de);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string toString()  //Méthode toString permettant d'afficher le plateau de jeu dans l'état actuel.
        {
            string s = "Le plateau est le suivant : \n";
            for (int i = 0; i < 4; i++)
            {
                for (int n = 0; n < 4; n++)
                {
                    s = s + plateau[i, n].Get_Face_Superieur;
                    if (n != 3)
                    {
                        s = s + " ; ";
                    }
                }
                s = s + "\n";
            }
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path_de"></param>
        public void Create_Plateau(string path_de)
        {
            De.ReadFile(path_de);
            

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.plateau[i, j] = new De();
                }
            }
        }
        /// <summary>
        /// La fonction Test_Plateau sert à déterminer si le mot rentré en paramètre est présent sur le plateau ou non (bool true or false)
        /// </summary>
        /// <param name="mot"></param>
        /// <returns></returns>

        public bool Test_Plateau(string mot)  //La recherche des mots sur le plateau est divisée en 2 parties. La partie 1 est la recherche du nombre de fois où la première lettre du mot apparait sur le plateau.
        {
            Stack<int[]> PileLettreDepart = new Stack<int[]>();  //La pile représentant les positions possibles de la première lettre du mot.
            mot = mot.ToUpper();
            char[,] plateauchar = new char[4, 4];

            for (int i = 0; i < 4; i++)  //Création d'une matrice de char représentant le plateau afin de permettre sa modification plus tard (notamment pour éviter d'utiliser deux fois la même lettre dans le même mot)
            {
                for (int n = 0; n < 4; n++)
                {
                    plateauchar[i, n] = plateau[i, n].Get_Face_Superieur;
                }
            }

            for (int i = 0; i < plateau.GetLength(0); i++)  //Remplissage de la pile avec les différentes positions de la première lettre du mot.
            {
                for (int n = 0; n < plateau.GetLength(1); n++)
                {
                    if (plateauchar[i, n] == mot[0])
                    {
                        int[] tab2 = { i, n };

                        PileLettreDepart.Push(tab2);
                    }
                }
            }

            int a = PileLettreDepart.Count;  // Juste un entier pour retenir le nombre de fois que la 1ère lettre apparait sur le plateau.
            bool existe = false;  // Le booléen qui servira à nous dire si le mot existe sur le plateau ou pas.
            for (int i = 0; i < a; i++)  //Boucle for permettant de parcourir toutes les premières lettre et de leur appliquer l'algorithme récursif.
            {
                int[] tab = new int[2];
                tab = PileLettreDepart.Pop();

                if (existe = Recursivite_Plateau(mot.Remove(0, 1), tab[0], tab[1], plateauchar) == true) // Récupère le résultat de la fonction Recursivite_Plateau. Si le test est validé, c'est que le mot est présent sur la plateau, on peut donc quitter la boucle et retourner True à la présence du mot dans le plateau.
                {
                    break;
                }
            }
            return existe;
        }


        /// <summary>
        /// La fonction Recursivite_Plateau est appelé dans la fonction Test_Plateau et détermine si la première lettre du mot rentré en paramètre est voisine de la lettre dont les coordonnées sont rentrées en paramètre sur le plateau de char donné. Elle retourne True ou False (bool).
        /// </summary>
        /// <param name="mot"></param>
        /// <param name="ligne"></param>
        /// <param name="colonne"></param>
        /// <param name="plateauchar"></param>
        /// <returns></returns>

        public bool Recursivite_Plateau(string mot, int ligne, int colonne, char[,] plateauchar)  // La seconde partie de la recherche des mots sur le plateau est de savoir si le reste des lettres se trouve bien à la suite de la première. Pour cela, nous allons ici utiliser un algorithme récursif.
        {
            mot = mot.ToUpper();
            if (mot.Length == 0)  // Nous utiliserons comme condition de sortie de la récursivité la taille du mot. En effet, à chaque boucle, nous décrémentons la taille du mot en enlevant la lettre se trouvant actuellement en index 1 de ce mot. 
            {
                return true;  // De cette façon, si le mot atteint à un moment la taille 0, cela veut dire que toutes les boucles sont passées et donc que toutes les lettres du mots sont bien présentes et collées sur le plateau, c'est à dire que le mot est bien là.
            }
            else
            {
                Stack<int[]> piletab = Test_Voisin(mot[0], ligne, colonne, plateauchar);  // Afin de faire cela, nous avons utilisé des piles de tableaux pour obtenir les positions des lettres souhaitées sur le plateau pour continuer la récursivité.
                plateauchar[ligne, colonne] = '1'; // Cette ligne sert juste à modifier une lettre en '1', de sorte à ce qu'on ne puisse pas utiliser la lettre 2 fois dans le même mot (voir règle du jeu).
                int[] tab = piletab.Pop();

                int[] tabtemp;
                int[] tabtemp2;
                Stack<int[]> piletemp;
                Stack<int[]> piletemp2;
                if (tab[0] == 0)  // Comme expliqué dans la fonction Test_Voisin, le premier tableau de la pile nous indique le nombre de fois que la lettre est présente autour de la position acutelle. Si cette lettre est présente 0 fois, cela veut dire que le mot n'est pas sur le plateau, on peut donc directement retourner False.
                {
                    return false;
                }
                if (tab[0] == 1)  // Si la lettre est présente uniquement 1 fois, il n'y a pas de risque de prendre un mauvais chemin donc on peut passer directement à l'étape d'après.
                {
                    tab = piletab.Pop();
                    return Recursivite_Plateau(mot.Remove(0, 1), tab[0], tab[1], plateauchar);  // On rappelle la même fonction, c'est le principe de la récursivité. On rentre en paramètre le mot en enlevant sa première lettre pour trouver la position des suivantes autour de celle-ci.
                }
                else  // Dans les autres cas, cela veut dire qu'il y a plus d'une fois la lettre. Il faut donc faire attention à ce que l'algorithme ne se trompe pas de chemin. En effet par exemple, si on cherche le mot "Chat", il peut arriver qu'il y ait deux chemins, un comprenant les lettres "C" puis "H", et l'autre comprenant "C", "H", "A", "T". Le mot est donc bien présent sur le plateau, mais arrivé au "H" du premier chemin l'algorithme ne trouverait pas le "A" et retournerait False, ce qu'on ne veut pas. On va donc regarder une lettre plus loin pour voir si on se trouve sur le bon chemin.
                {
                    int a = tab[0];  // On commence par créer un simple compteur égal à l'index 0 du fameux "premier tableau de la pile qui indique le nombre de lettre autour".
                    for (int i = 1; i <= a; i++)  // Et on crée une boucle for pour parcourir toutes ces lettres.
                    {
                        if (mot.Length < 2) // Etant donné qu'on regarde une lettre plus loin, ce test sert simplement à sortir les fins de mots. En effet, si on a un problème à la dernière lettre du mot, on ne peut pas tester la suivante care cela créerait un problème de taille de tableau. On retourne donc automatiquement True, car si la dernière lettre est présente 2 fois ou plus, c'est qu'elle est présente 1 fois et donc que le mot est présent sur le plateau.
                        {
                            return true;
                        }
                        else  // On test donc ensuite la lettre suivante de la même façon.
                        {
                            tab = null;
                            tab = piletab.Pop();
                            piletemp = Test_Voisin(mot[1], tab[0], tab[1], plateauchar);
                            tabtemp = piletemp.Pop();

                            if (tabtemp[0] > 1) // Si la lettre est présente plus d'une fois, on refait la même chose : on regarde si la lettre suivante est présente à côté d'une des lettres actuelles pour choisir le chemin.
                            {
                                int b = tabtemp[0]; // Même compteur que a.
                                for (int j = 1; j <= b; j++) //Même boucle for.
                                {
                                    tabtemp2 = piletemp.Pop();
                                    piletemp2 = Test_Voisin(mot[2], tabtemp2[0], tabtemp2[1], plateauchar);
                                    tabtemp2 = null;
                                    tabtemp2 = piletemp2.Pop();
                                    if (tabtemp2[0] == 1) // Si la lettre au rang 2 est présente une fois, on quitte les deux boucles for pour prendre ce chemin là. On note qu'on n'effectuera pas de tests supplémentaires car les probabilités de tomber sur un cas comme celui-ci sont déjà extrèmement faibles avec des dés générés au hasard.
                                    {
                                        break;
                                    }
                                }
                                break;
                            }
                            else if (tabtemp[0] == 1)  // Et si la lettre suivante n'est présente qu'une fois, on sort de la boucle for et on continue la récursivité avec la position de la lettre acutelle.
                            {
                                break;
                            }
                        }
                    }
                    return Recursivite_Plateau(mot.Remove(0, 1), tab[0], tab[1], plateauchar);

                }
            }
        }

        /// <summary>
        /// La fonction Test_Voisin sert à déterminer les coordonnées où apparait la lettre souhaitée autour de la position souhaitée dans le plateau. Elle retourne une pile de tableau d'entiers pour représenter les coordonnées des lettres (à l'index 0 la ligne, à l'index 1 la colonne). Enfin, le premier tableau de la pile donne le nombre de fois que la lettre recherchée est présente autour de la position (Exemple : si il y a deux fois la lettre A, qui est la lettre en paramètre, la taille de la pile sera 3, avec un premier tableau contenant 3 à l'index 0, et les tableaux suivant contenant les coordonnées des différents A).
        /// </summary>
        /// <param name="lettre"></param>
        /// <param name="ligne"></param>
        /// <param name="colonne"></param>
        /// <param name="plateauchar"></param>
        /// <returns></returns>
        static Stack<int[]> Test_Voisin(char lettre, int ligne, int colonne, char[,] plateauchar)
        {
            Stack<int[]> piletab = new Stack<int[]>();
            int compteurlettre = 0;

            if (ligne == 0 && colonne == 0)  // Les test corresepondent aux différentes positions possibles de la lettre dont il faut examiner les voisins.
            {
                for (int i = ligne; i <= ligne + 1; i++)
                {
                    for (int n = colonne; n <= colonne + 1; n++)
                    {
                        if (plateauchar[i, n] == lettre)
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
                        if (plateauchar[i, n] == lettre)
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
                        if (plateauchar[i, n] == lettre)
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
                        if (plateauchar[i, n] == lettre)
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
                        if (plateauchar[i, n] == lettre)
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
                        if (plateauchar[i, n] == lettre)
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
                        if (plateauchar[i, n] == lettre)
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
                        if (plateauchar[i, n] == lettre)
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
                        if (plateauchar[i, n] == lettre)
                        {
                            int[] tab = { i, n };
                            piletab.Push(tab);
                            compteurlettre += 1;
                        }

                    }
                }
            }
            int[] tabcompteur = new int[2];
            tabcompteur[0] = compteurlettre;  // Ce tableau sert à avoir le nombre de fois qu'une lettre est présente autour de la position donnée. Cette information sera très utile pour la suite du programme.
            piletab.Push(tabcompteur);

            return piletab;

        }
        /// <summary>
        /// 
        /// </summary>
        public void Print_plateau()
        {
            for (int i = 0; i < this.plateau.GetLength(0); i++)
            {
                for (int j = 0; j < this.plateau.GetLength(1); j++)
                {
                    Console.Write(this.plateau[i, j].Get_Face_Superieur + " ");
                }
                Console.WriteLine();
            }
        }
    }
}