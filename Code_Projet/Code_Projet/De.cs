using System;
using System.IO;
using System.Collections.Generic;

namespace Code_Projet
{
    class De
    {

        private char de;

        private static Queue<string> extract_de = new Queue<string>();


        public De()
        {
            Random ran = new Random();
            this.Lance(ran);


        }

        /// <summary>
        /// Propriété permettant d'accéder à la valeur de la face supérieure du dé en question
        /// </summary>
        /// <value></value>
        public char Get_Face_Superieur
        {
            get { return this.de; }

        }

        /// <summary>
        /// Fonction à intitialiser avant tout appel de la classe de permettant de stocker le doc lié aux dés dans une queue static
        /// </summary>
        /// <param name="path"></param>
        public static void ReadFile(string path)
        {
            try //Sécurités
            {
                StreamReader sr = new StreamReader(path); //Ouverture du stream avec le document spécifié
                while (sr.Peek() >= 0)
                {
                    extract_de.Enqueue(sr.ReadLine());




                }


                sr.Close();
            }
            catch (FileNotFoundException) //S'il ne trouve pas le fichier
            {
                Console.WriteLine("Vous n'avez pas renseigné de fichier dé");
            }
            catch (SystemException ex) //Au cas où il y aurait d'autres exceptions
            {
                Console.WriteLine(ex.ToString());

            }

        }
        /// <summary>
        /// Extrait un string de la queue static et "fais rouler" le dé pour obtenir une face
        /// </summary>
        /// <param name="r"></param>
        public void Lance(Random r)
        {
            char separator = ';';
            string[] de_line = extract_de.Dequeue().ToUpper().Split(separator); //Extrait toutes les faces d'un dé

            bool essai = char.TryParse(de_line[r.Next(0, de_line.Length)], out this.de); //Rend aléatoire le tirage

            if (!essai) Console.WriteLine("Votre fichier n'est pas dans le bon format, veuillez seulement mettre des caractères et des " + separator);



        }


        /// <summary>
        /// Fonction retournant un string comprenant la face du dé
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            return "La lettre affichée du dé est : " + this.de;
        }


    }
}