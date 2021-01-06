using System;
using System.Collections.Generic;
using System.Text;

namespace REST_BRZAKALA_core
{
    public class UserData : Interfaces.IUserData
    {
        public UserData(string name, string bio, string image)
        {
            this.Name = name;
            this.Bio = bio;
            this.Image = image;

        }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return "Name: " + Name + " Bio: " + Bio + " Image: " + Image + "\n";
        }
    }
}
