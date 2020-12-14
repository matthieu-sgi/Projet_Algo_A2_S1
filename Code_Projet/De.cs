using System;
using System.IO;
using System.Collections.Generic;

namespace Code_Projet
{
    class De
    {
        //private string path_file;
        private char de;

        private static Queue<string> extract_de = new Queue<string>();


        public De()
        {


        }

        public char Get_Face_Superieur
        {
            get { return this.de; }
        }

        static void ReadFile(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                while (sr.Peek() >= 0)
                {
                    extract_de.Enqueue(sr.ReadLine().ToUpper());




                }


                sr.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Vous n'avez pas renseigné de fichier dé");
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.ToString());

            }

        }

        public void Lance(Random r)
        {
            char separator = ';';
            string[] de_line = extract_de.Dequeue().Split(separator);
            bool essai = char.TryParse(de_line[r.Next(0, de_line.Length)], out this.de);
            if (!essai) Console.WriteLine("Votre fichier n'est pas dans le bon format, veuillez seulement mettree des caractères et des " + separator);



        }

        public string toString()
        {
            return "La lettre affichée du dé est : " + this.de;
        }

    }
}