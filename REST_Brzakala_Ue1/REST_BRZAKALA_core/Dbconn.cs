using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Npgsql;
using System.Linq;

namespace REST_BRZAKALA_core
{
    public class Dbconn
    {
        public string cs = "Host=localhost;Username=postgres;Password=123;Database=postgres";
        public Packages pack = new Packages();
        public void Register(string user, string pass)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO users VALUES (@username, @password, @coins)", con);
            
            cmd.Parameters.AddWithValue("username", user);
            cmd.Parameters.AddWithValue("password", pass);
            cmd.Parameters.AddWithValue("coins", 20);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Card(int id, string name, int damage, string element, string type)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO card VALUES (@id, @name, @damage, @element, @type)", con);

            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("damage", damage);
            cmd.Parameters.AddWithValue("element", element);
            cmd.Parameters.AddWithValue("type", type);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Packages(int id, int card1, int card2, int card3, int card4, int card5)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO packages VALUES (@id, @c1, @c2, @c3, @c4, @c5 )", con);

            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("c1", card1);
            cmd.Parameters.AddWithValue("c2", card2);
            cmd.Parameters.AddWithValue("c3", card3);
            cmd.Parameters.AddWithValue("c4", card4);
            cmd.Parameters.AddWithValue("c5", card5);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Login(string user)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO loggedin VALUES (@username, @token)", con);

            string Token = "Basic " + user + "-mtcgToken";
            cmd.Parameters.AddWithValue("username", user);
            cmd.Parameters.AddWithValue("token", Token);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
        public Boolean CheckUserExists(string user)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM users", con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            ArrayList usersArr = new ArrayList();
            //string output = "";

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                usersArr.Add(rdr.GetString(0));
            }
            con.Close();

            if (usersArr.Contains(user))
            {
                return true;
            }
            else
            {
                return false;
            }

            /*
            foreach (Object obj in usersArr)
            Console.WriteLine("   user:{0}", obj);
            */
        }
        public int cardMaxId()
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT max(id) FROM card", con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            int output = 0;

            while (rdr.Read())
            {
                if (rdr.HasRows)
                {
                    Console.WriteLine("Has rows");
                    output = 0;
                }
                else
                {
                    output = rdr.GetInt32(0);
                }

                try
                {
                    output = rdr.GetInt32(0);
                }
                catch (Exception e)
                {
                    Console.WriteLine("NO CARD YET.");
                }
            }

            //Console.WriteLine("Last Card id is: {0}", output);

            return output;
        }
        public int packidis()
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT max(packid) FROM packages", con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            int output = 0;

            while (rdr.Read())
            {
                if (rdr.HasRows)
                {
                    Console.WriteLine("Has rows");
                    output = 0;
                }
                else
                {
                    output = rdr.GetInt32(0);
                }

                try{
                    output = rdr.GetInt32(0);
                }
                catch (Exception e)
                {
                    Console.WriteLine("NO PACKAGES YET.");
                }
                
            }
            con.Close();

            //Console.WriteLine("packid is: {0}", output);

            return output;
        }
        public void checkAllCard()
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM card", con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            
            int maxid = cardMaxId();

            while (rdr.Read())
            {
                if(pack.AllCards.Any(p => p.id == maxid))
                {
                    Console.WriteLine("Alle Karten vorhanden.");
                }
                else
                {
                    //Console.WriteLine("ADDING CARD);
                    pack.AllCards.Add(new Card(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetString(3), rdr.GetString(4)));
                }
            }
            con.Close();

            //CHECK IF THERE IS SMTH IN ALLCARDS:
            //foreach (Object obj in pack.AllCards)
            //Console.WriteLine("   card:{0}", obj);
            
        }
       
        public Boolean CheckLogin(string user)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM loggedin", con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            ArrayList loginArr = new ArrayList();
            //string output = "";

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                loginArr.Add(rdr.GetString(0));
            }
            con.Close();

            if (loginArr.Contains(user))
            {
                return true;
            }
            else
            {
                return false;
            }

            /*
            foreach (Object obj in usersArr)
            Console.WriteLine("   user:{0}", obj);
            */
        }
        public string CheckToken(string token)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT token FROM loggedin where token=@token", con);
            cmd.Parameters.AddWithValue("token", token);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                Console.WriteLine("{0}", rdr.GetString(0));
                output = rdr.GetString(0);
            }
            con.Close();

            // CHECK IF TOKEN IS CORRECT
            //Console.WriteLine("Token is: {0}", output);

            return output;
        }
        public string CheckCardId(int id)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT id FROM card where id=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            int output = 0;

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                output = rdr.GetInt32(0);
            }
            con.Close();

            //Console.WriteLine("CardId is: {0}", output);

            return output.ToString();
        }
        public string CheckPackId(int id)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT packid FROM packages where packid=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            int output = 0;

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                output = rdr.GetInt32(0);
            }
            con.Close();

            Console.WriteLine("Packid is: {0}", output);

            return output.ToString();
        }
        public string CheckUserPw(string user)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT password FROM users where username=@user", con);
            cmd.Parameters.AddWithValue("user", user);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                Console.WriteLine("{0}", rdr.GetString(0));
                output = rdr.GetString(0);
            }
            con.Close();

            Console.WriteLine("Password is: {0}", output);

            return output;

            /*
            foreach (Object obj in usersArr)
            Console.WriteLine("   user:{0}", obj);
            */
        }
        public void CheckRegister()
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM users", con);

            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("{0} {1} {2}", rdr.GetString(0), rdr.GetString(1),
                        rdr.GetInt32(2));
            }
            con.Close();
        }

    }
}
