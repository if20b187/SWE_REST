using System;
using System.Collections.Generic;
using System.Text;

namespace REST_BRZAKALA_core
{
    public class Deck : Interfaces.IDeck
    {
        public Deck()
        {
            UserDeck = new List<Card>();
        }

        public List<Card> UserDeck { get; set; }
    }
}
