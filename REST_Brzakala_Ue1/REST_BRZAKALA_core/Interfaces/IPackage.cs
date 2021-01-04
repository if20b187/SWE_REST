using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace REST_BRZAKALA_core.Interfaces
{
    interface IPackage
    {
        public List<Card> Package { get; }
        public List<Card> AllCards { get; }
    }
}
