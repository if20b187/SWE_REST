using System;
using System.Collections.Generic;
using System.Text;

namespace REST_BRZAKALA_core.Interfaces
{
    public interface IBattle
    {
        public List<Card> Fighter1 { get; }
        public List<Card> Fighter2 { get; }
    }
}
