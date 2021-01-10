using System;
using System.Collections.Generic;
using System.Text;

namespace REST_BRZAKALA_core.Interfaces
{
    public interface IHistory
    {
        int Matchid { get; }
        string Winner { get; }
        string Protokol { get; }
    }
}
