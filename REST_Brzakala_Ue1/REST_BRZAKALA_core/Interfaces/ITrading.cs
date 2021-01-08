using System;
using System.Collections.Generic;
using System.Text;

namespace REST_BRZAKALA_core.Interfaces
{
    public interface ITrading
    {
        int Tradingid { get; }
        string Karte { get; }
        int MinDamage { get; }
        string Typ { get; }
    }
}
