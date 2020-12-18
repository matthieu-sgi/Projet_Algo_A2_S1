using Code_Projet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test_Unitaires_Projet
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Code_Projet.De.ReadFile(@"..\..\..\..\Fichiers_importes\Des.txt");
            string[] test_tab = new string[] { "B;A;J;O;Q;M" ,  "R;A;L;E;S;C" ,  "L;I;B;A;R;T" ,  "T;O;K;U;E;N" ,  "R;O;F;I;A;X" , "A;V;E;Z;D;N" ,  "N;U;L;E;G;Y" , "M;E;D;A;P;C" ,  "S;U;T;E;L;P" ,  "H;E;F;S;I;E" ,  "R;O;M;A;S;I" ,  "G;I;N;E;V;T" , "R;U;E;I;L;W" ,  "R;E;N;I;S;H" ,  "T;I;E;A;A;O" ,  "D;O;N;E;S;T" };
            Queue<string> test = new Queue<string>( test_tab);
            bool achieve = true;
            while (De.De_extrait.Count > 0)
            {
                if (test.Dequeue() != De.De_extrait.Dequeue()) achieve = false;

            }

            Assert.IsTrue(achieve);
        }
        [TestMethod]
        public void TestMethod_Add_Mot()
        {
            Code_Projet.Joueur Hugo = new Code_Projet.Joueur("Hugo");
            string mot = "mot";

            Hugo.Add_Mot(mot);
            int score = Hugo.Score;

            Assert.AreEqual(2, score);
        }
        [TestMethod]
        public void TestMethod_Contains()
        {
            List<string> words = new List<string>();
            words.Add("mot");
            Code_Projet.Joueur Hugo = new Code_Projet.Joueur("Hugo", 0, words);
            string mot = "mot";

            bool existe = words.Contains(mot);

            Assert.AreEqual(true, existe);

        }
        [TestMethod]
        public void TestMethod_toString_Joueur()
        {
            List<string> words = new List<string>();
            words.Add("mot");
            words.Add("idée");
            Code_Projet.Joueur Hugo = new Code_Projet.Joueur("Hugo", 12, words);

            string s = Hugo.toString();

            Assert.AreEqual("Le joueur Hugo a un score de 12 et à trouvé 2 mots", s);
        }



    }
}
