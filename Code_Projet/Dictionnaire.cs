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



        public List<String> Dico_Complet
        {
            get { return this.dico; }
        }

        public int Nb_min_lettres
        {
            get { return this.nb_min_lettres; }
        }

        public char Separator
        {
            get { return this.separator; }
        }

        public Dictionnaire(string _langage, string path, char _separator)
        {
            this.langage = _langage;
            this.separator = _separator;
            Extract_Dictionary(path);


        }

        public Dictionnaire(string _langage, string path)
        {
            this.langage = _langage;
            this.separator = ' ';
            Extract_Dictionary(path);

        }

        public void Extract_Dictionary(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                while (sr.Peek() >= 0)
                {
                    int a;
                    string temp = sr.ReadLine();
                    if (!int.TryParse(temp, out a))
                    {


                        dico.Add(temp.ToUpper());
                    }
                    else if (a < this.nb_min_lettres)
                    {
                        this.nb_min_lettres = a;
                    }





                }


                sr.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Vous n'avez pas renseigné de fichier dictionnaire");
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        public string toString()
        {
            string retour = "Voici le nombre de mot par taille du dictonnaire " + langage + " :\n";
            for (int i = 0; i < dico.Count; i++)
            {
                retour += "Il existe " + dico[i].Split(separator).Length + " mots de longueur " + (i + this.nb_min_lettres) + "\n";
            }
            return retour;
        }

        public bool RechDichoRecursif(int debut, int fin, string mot)
        {
            int mid = (fin + debut) / 2;


            if (debut > fin) return false;
            else if (mot.Length<this.nb_min_lettres) return false;

            else if (this.dico[mot.Length - this.nb_min_lettres].Split(separator)[mid].CompareTo(mot) == 0) return true;
            else if (this.dico[mot.Length - this.nb_min_lettres].Split(separator)[mid].CompareTo(mot) < 0) return RechDichoRecursif(mid + 1, fin, mot);
            else return RechDichoRecursif(debut, mid - 1, mot);




        }


    }
}