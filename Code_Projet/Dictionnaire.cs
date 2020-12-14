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

        public Dictionnaire(string _langage, char _separator, string path)
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
                    if (!int.TryParse(sr.ReadLine(), out a))
                    {
                        dico.Add(sr.ReadLine().ToUpper());
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
                retour += "Il existe " + dico[i].Split(separator).Length + " mots de longueur " + (i + 1) + "\n";
            }
            return retour;
        }

        public bool RechDichoRecursif(int debut, int fin, string mot)
        {
            int mid = (fin + debut) / 2;
            if (debut > fin) return false;


            return true;
        }


    }
}