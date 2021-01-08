using System;
using System.Collections.Generic;
using System.Text;

namespace REST_BRZAKALA_core
{
    public class Trading : Interfaces.ITrading
    {
        public Trading(int id, string card, int minDamage, string type)
        {
            this.Tradingid = id;
            this.Karte = card;
            this.MinDamage = minDamage;
            this.Typ = type;

        }
        public int Tradingid { get; set; }
        public string Karte { get; set; }
        public int MinDamage { get; set; }
        public string Typ { get; set; }
        public override string ToString()
        {
            return "TradingId: " + Tradingid + " Card: " + Karte + " MinDamage: " + MinDamage + " Type: " + Typ + "\n";
        }
    }
}
