using System;
using System.Collections.Generic;
using System.IO;

namespace Code_Projet
{
    class Joueur
    {
        private string name;
        private int score;
        private List<string> words = new List<string>();

        public int Score
        {
            get { return this.score; }
        }

        public Joueur(string _name, int _score, List<string> _words)
        {
            this.name = _name;
            this.score = _score;
            this.words = _words;
        }

        public Joueur(string _name)
        {
            this.name = _name;
            this.score = 0;
            
        }


        public bool Contains(string mot)
        {
            bool found = false;
            if (this.words != null)
            {
                for (int i = 0; i < this.words.Count; i++)
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

        public void Add_Mot(string mot)
        {
            this.words.Add(mot);
            switch (mot.Length)
            {
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

        public string toString()
        {
            return "Le joueur " + this.name + " a un score de " + this.score + " et à trouvé " + this.words.Count + " mots";
        }
    }
}