using System;
using System.IO;
using System.Collections.Generic;

namespace Code_Projet
{
    class Dictionnaire
    {
        private string langage;
        char separator;
        private List<String> dico = new List<String>();
        int nb_min_lettres = 10;


        /// <summary>
        /// Propriété permettant d'accéder à la liste de tous les mots du dictionnaire, permettant notamment de connaitre la longueur de celle-ci ou autre
        /// </summary>
        /// <value></value>
        public List<String> Dico_Complet
        {
            get { return this.dico; }
        }
        /// <summary>
        /// Propriété permettant d'accéder au nombre de lettre du plus petit mot du dictionnaire
        /// </summary>
        /// <value></value>
        public int Nb_min_lettres
        {
            get { return this.nb_min_lettres; }
        }
        /// <summary>
        /// Propriété permettant d'accéder à la valeur du séparateur du dictionnaire
        /// </summary>
        /// <value></value>
        public char Separator
        {
            get { return this.separator; }
        }

        public Dictionnaire(string _langage, string path, char _separator)//Constructeur acceptant un argument de séparateur
        {
            this.langage = _langage;
            this.separator = _separator;
            Extract_Dictionary(path);


        }

        public Dictionnaire(string _langage, string path) //Constructeur minimal prenant uniquement le chemin d'accès au dictionnaire et la langue de celui-ci
        {
            this.langage = _langage;
            this.separator = ' ';
            Extract_Dictionary(path);

        }
        /// <summary>
        /// Fonction d'extraction du dictionnaire de son fichier .txt et de l'intégrer dans une liste
        /// </summary>
        /// <param name="path"></param>
        public void Extract_Dictionary(string path)
        {
            try //Sécurités
            {
                StreamReader sr = new StreamReader(path); //On créer un lien avec le fichier .txt et on extrait
                while (sr.Peek() >= 0)
                {
                    int a;
                    string temp = sr.ReadLine();
                    if (!int.TryParse(temp, out a))
                    {


                        dico.Add(temp.ToUpper());
                    }
                    else if (a < this.nb_min_lettres) //On récupère la valeur de lettre minimal
                    {
                        this.nb_min_lettres = a;
                    }





                }


                sr.Close();
            }
            catch (FileNotFoundException) //Si le chemin d'accès n'est pas le bon 
            {
                Console.WriteLine("Vous n'avez pas renseigné de fichier dictionnaire");
            }
            catch (SystemException ex)//En cas de tout autre exception
            {
                Console.WriteLine(ex.ToString());

            }
        }
        /// <summary>
        /// Fonction retournant un string comprenant le nombre de mot par nombre de lettres
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            string retour = "Voici le nombre de mot par taille du dictonnaire " + langage + " :\n";
            for (int i = 0; i < dico.Count; i++)
            {
                retour += "Il existe " + dico[i].Split(separator).Length + " mots de longueur " + (i + this.nb_min_lettres) + "\n";
            }
            return retour;
        }

        /// <summary>
        /// Fonction recherchant si le string entré en paramètre existe dans le dictionnaire
        /// </summary>
        /// <param name="debut"></param>
        /// <param name="fin"></param>
        /// <param name="mot"></param>
        /// <returns></returns>
        public bool RechDichoRecursif(int debut, int fin, string mot)
        {
            int mid = (fin + debut) / 2;


            if (debut > fin) return false; //Condition de sortie
            else if (mot.Length < this.nb_min_lettres) return false;//Condition de sortie

            else if (this.dico[mot.Length - this.nb_min_lettres].Split(separator)[mid].CompareTo(mot) == 0) return true;//Condition de sortie
            else if (this.dico[mot.Length - this.nb_min_lettres].Split(separator)[mid].CompareTo(mot) < 0) return RechDichoRecursif(mid + 1, fin, mot);
            //On appelle la meme fonction en changeant ses arguments (principe de la récursivité)
            else return RechDichoRecursif(debut, mid - 1, mot);




        }


    }
}