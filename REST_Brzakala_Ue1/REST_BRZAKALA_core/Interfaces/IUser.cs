using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace REST_BRZAKALA_core.Interfaces
{
    public interface IUser
    {
        string Username { get; }
        string Password { get; }
        ArrayList Cards { get; }
        int Coins { get; }


    }
}
