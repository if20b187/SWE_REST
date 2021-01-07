using System;
using System.Collections.Generic;
using System.Text;

namespace REST_BRZAKALA_core.Interfaces
{
    public interface IStats
    {
        int Win  { get; }
        int Draw { get; }
        int Lose { get; }
    }
}
