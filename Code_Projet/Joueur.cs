using System;
using System.Collections.Generic;

namespace Code_Projet
{
    class Joueur
    {
        private string name;
        private int score;
        private List<string> words = new List<string>();

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
            this.words = null;
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
    }
}