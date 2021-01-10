using System;
using System.Collections.Generic;
using System.Text;

namespace REST_BRZAKALA_core
{
    public class History : Interfaces.IHistory
    {
        public History(int matchid, string winner, string protokol)
        {
            this.Matchid = matchid;
            this.Winner = winner;
            this.Protokol = protokol;

        }
        public int Matchid { get; set; }
        public string Winner { get; set; }
        public string Protokol { get; set; }

        public override string ToString()
        {
            return "Matchid: " + Matchid + " Winner: " + Winner + " Protokoll: " + Protokol + "\n";
        }
    }
}
