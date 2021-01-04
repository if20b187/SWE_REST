using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace REST_BRZAKALA_UE1
{
    public class User : Interfaces.IUser
    {
        public User()
        {
            Cards = new ArrayList();
            
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public int Coins { get; set; }
        public ArrayList Cards { get; set; }
    }
}

