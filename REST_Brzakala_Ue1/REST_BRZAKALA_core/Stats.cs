using System;
using System.Collections.Generic;
using System.Text;

namespace REST_BRZAKALA_core
{
    public class Stats : Interfaces.IStats
    {
        public Stats(int win, int draw, int lose)
        {
            this.Win = win;
            this.Draw = draw;
            this.Lose = lose;

        }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lose { get; set; }

        public override string ToString()
        {
            return "Wins: " + Win + " Draw: " + Draw + " Lose: " + Lose + "\n";
        }
    }
}
