using System;
using System.Collections.Generic;


namespace Code_Projet
{
    /// <summary>
    /// Classe Joueur permettant la création d'un objet joueur caractérisé par son nom, son score et une liste de mots
    /// </summary>
    public class Joueur
    {
        private string name;
        private int score;
        private List<string> words = new List<string>();

        /// <summary>
        /// Propriété permettant de connaitre le score du joueur en question
        /// </summary>
        /// <value></value>
        public int Score
        {
            get { return this.score; }
        }

        /// <summary>
        /// Propriété permettant de connaitre la liste de mots du joueur en question et de la modifier
        /// </summary>
        /// <value></value>
        public List<string> Words
        {
            get { return this.words; }
            set { this.words = value; }
        }

        /// <summary>
        /// Propriété permettant d'accéder à la valeur du nom du joueur
        /// </summary>
        /// <value></value>
        public string Name
        {
            get { return this.name; }
        }
        public Joueur(string _name, int _score, List<string> _words) //Constructeur non utilisé mais au cas ou
        {
            this.name = _name;
            this.score = _score;
            this.words = _words;
        }

        /// <summary>
        /// Constructeur principal pour un joueur classique
        /// </summary>
        /// <param name="_name"></param>
        public Joueur(string _name)
        {
            this.name = _name;
            this.score = 0;

        }

        /// <summary>
        /// Constructeur pour une IA
        /// </summary>
        public Joueur()
        {
            this.name = "Destroyer 2000";
            this.score = 0;
            

        }

        /// <summary>
        /// Fonction vérifiant si le mot entré en paramètre est contenu dans la liste de mots du joueur en question
        /// </summary>
        /// <param name="mot"></param>
        /// <returns></returns>
        public bool Contains(string mot)
        {
            bool found = false;
            if (this.words != null)
            {
                for (int i = 0; i < this.words.Count; i++)//On se déplace dans la liste et on vérifie si le mot entré n'y est pas déjà
                {
                    if (words[i] == mot)
                    {
                        found = true;
                        break;
                    }
                }
            }
            return found;
        }

        /// <summary>
        /// Fonction ajoutant le string entré en paramètre dans la liste de mot du joueur et incrémentant le score de ce meme joueur
        /// </summary>
        /// <param name="mot"></param>
        public void Add_Mot(string mot)
        {
            this.words.Add(mot);
            switch (mot.Length)
            { //Switch de l'ajout de points
                case 2:
                    this.score += 1;
                    break;
                case 3:
                    this.score += 2;
                    break;
                case 4:
                    this.score += 3;
                    break;
                case 5:
                    this.score += 4;
                    break;
                case 6:
                    this.score += 5;
                    break;
                default:
                    this.score += 11;
                    break;

            }
        }

        /// <summary>
        /// Fonction d'affichage basique affichant les mots compris dans la liste de mots du joueur
        /// </summary>
        public void Print_Words()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta; //Changement de couleur de la console
            foreach (string a in this.words)
            {
                Console.Write(a + " ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        /// <summary>
        /// Fonction retournant un string comprenant le nom, le score et le nombre de mots trouvés par un joueur
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            return "Le joueur " + this.name + " a un score de " + this.score + " et à trouvé " + this.words.Count + " mots";
        }


        #region Partie du code pour l'IA
        public void Find_All_Words(Dictionnaire dico, Plateau gameboard, char separator)
        {
            for(int i = 0; i < dico.Dico_Complet.Count; i++)
            {
                for(int j = 0; j < dico.Dico_Complet[i].Split(separator).Length; j++)
                {
                    bool found = gameboard.Test_Plateau(dico.Dico_Complet[i].Split(separator)[j]);
                    if (found) this.Add_Mot(dico.Dico_Complet[i].Split(separator)[j]);
                }
            }

        }

        




        #endregion

    }
}