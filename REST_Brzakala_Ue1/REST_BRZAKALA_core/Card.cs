using System;
using System.Collections.Generic;
using System.Text;

namespace REST_BRZAKALA_core
{
    public class Card : Interfaces.ICard
    {
        public Card(int id, string name, int damage, string element, string type)
        {
            this.id = id;
            this.name = name;
            this.damage = damage;
            this.element = element;
            this.type = type;

        }
        public int id { get; set; }
        public string name { get; set; }
        public int damage { get; set; }
        public string element { get; set; }
        public string type { get; set; }

        public string CardInfo()
        {
            return "ID: " + id + " Card: " + name + " Damage: " + damage + " Element: " + element + " Type: " + type + "\n";
        }

        public override string ToString()
        {
            //return "ID: " + id + " Card: " + name + " Damage: " + damage + " Element: " + element + " Type: " + type + "\n";
            return "" + id + " ";
        }


    }
}
