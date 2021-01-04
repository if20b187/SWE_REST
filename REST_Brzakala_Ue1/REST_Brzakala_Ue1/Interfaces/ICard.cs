using System;
using System.Collections.Generic;
using System.Text;

namespace REST_BRZAKALA_UE1.Interfaces
{
    interface ICard
    {
        string name { get; }
        int damage { get; }
        string element { get; }

    }
}
