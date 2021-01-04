using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace REST_BRZAKALA_core
{
    public class Packages : Interfaces.IPackage
    {
        
        public Packages()
        {
            AllCards = new List<Card>();
            Package = new List<Card>();
        }
        /*
        public void setPackage()
        {
            AllCards.Add(new Card(1, "WaterGoblin", 37, "water", "spell"));
            AllCards.Add(new Card(2, "Dragon", 42, "fire", "monster"));
            AllCards.Add(new Card(3, "WaterSpell", 11, "water", "spell"));
            AllCards.Add(new Card(4, "Ork", 39, "water", "monster"));
            AllCards.Add(new Card(5, "Wizzard", 9, "normal", "spell"));
            AllCards.Add(new Card(6, "Knight", 11, "normal", "monster"));
            AllCards.Add(new Card(7, "Kraken", 43, "water", "monster"));
            AllCards.Add(new Card(8, "FireElves", 29, "fire", "monster"));
            AllCards.Add(new Card(9, "FireTroll", 38, "fire", "spell"));
            AllCards.Add(new Card(10, "WaterGoblin", 33, "water", "spell"));
            AllCards.Add(new Card(11, "Dragon", 46, "fire", "monster"));
            AllCards.Add(new Card(12, "FireSpell", 44, "fire", "spell"));
            AllCards.Add(new Card(13, "Ork", 46, "water", "spell"));
            AllCards.Add(new Card(14, "Wizzard", 17, "normal", "spell"));
            AllCards.Add(new Card(15, "Knight", 15, "normal", "spell"));
            AllCards.Add(new Card(16, "Kraken", 12, "water", "spell"));
            AllCards.Add(new Card(17, "FireElves", 14, "fire", "monster"));
            AllCards.Add(new Card(18, "FireTroll", 13, "fire", "spell"));
            AllCards.Add(new Card(19, "WaterTroll", 18, "water", "spell"));
            AllCards.Add(new Card(20, "WaterElves", 11, "water", "spell"));         
        }
        */

        public string randomZu()
        {
            string pack = "";
            int index;
            do
            {
                Random rnd = new Random();
                index = rnd.Next(0, AllCards.Count - 1);
                Card c1 = AllCards[index];
                if (!Package.Contains(c1)) 
                    Package.Add(c1);
            } while (Package.Count != 5);


            //Console.WriteLine("r1: {0}", index);

            foreach (Object obj in Package)
                //Console.Write("   {0}", obj);
                pack = pack + obj;
            Console.WriteLine();
            //Console.WriteLine("DAS IST PACK: {0}", pack);
            Package.Clear();
            return pack;
        }
           
        public List<Card> Package { get; set; }
        public List<Card> AllCards { get; set; }
    }
}
