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
        public void AddUserCard(string username, int id, string name, int damage, string element, string type)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO usercards VALUES (@username ,@id, @name, @damage, @element, @type)", con);

            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("damage", damage);
            cmd.Parameters.AddWithValue("element", element);
            cmd.Parameters.AddWithValue("type", type);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void CreateDeck(string username)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO deck VALUES (@username, @c1, @c2, @c3, @c4)", con);

            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("c1", "undefined");
            cmd.Parameters.AddWithValue("c2", "undefined");
            cmd.Parameters.AddWithValue("c3", "undefined");
            cmd.Parameters.AddWithValue("c4", "undefined");
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void CreateUserdata(string username)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO userdata VALUES (@username, @name, @bio, @image)", con);

            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("name", "undefined");
            cmd.Parameters.AddWithValue("bio", "undefined");
            cmd.Parameters.AddWithValue("image", "undefined");
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void CreateUserstats(string username)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO userstats VALUES (@username, @wins, @draws, @loses)", con);

            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("wins", 0);
            cmd.Parameters.AddWithValue("draws", 0);
            cmd.Parameters.AddWithValue("loses", 0);
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
        public void CoinsUpdate(string user)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("UPDATE users SET coins = coins - 5 WHERE username=@username", con);

            cmd.Parameters.AddWithValue("username", user);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        
        public string GetUserCards(string user)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT id,name,damage,element,type FROM usercards WHERE username=@user", con);
            cmd.Parameters.AddWithValue("user", user);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                //{ "id":1,"name":"WaterGoblin","damage":37,"element":"water","type": "spell"}
                //string lol = String.Format("{ \"id\":{0},\"name\":{1},\"damage\":{2},\"element\":{3},\"element\":{4}}\n", rdr.GetInt32(0).ToString(), rdr.GetString(1), rdr.GetInt32(2).ToString(), rdr.GetString(3), rdr.GetString(4));
                // JSON VERSUCH
                //output = output + "{ \"id\":" + rdr.GetInt32(0) + ",\"name\":\"" + rdr.GetString(1) + "\",\"damage\":" + rdr.GetInt32(2) + ",\"element\":\"" + rdr.GetString(3) + "\",\"type\":\"" + rdr.GetString(4) + "\"}";
                
                output = output + rdr.GetInt32(0).ToString() + " " + rdr.GetString(1) + " " + rdr.GetInt32(2).ToString() + " " + rdr.GetString(3) + " " + rdr.GetString(4) + "\n";
            }
            con.Close();
            return output;
        }

        public string GetUserDeck(string user)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT card1,card2,card3,card4 FROM deck WHERE username=@user", con);
            cmd.Parameters.AddWithValue("user", user);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                // = output ist hier unnötig.
                output = output + rdr.GetString(0) + "\n" + rdr.GetString(1) + "\n" + rdr.GetString(2) + "\n" + rdr.GetString(3) + "\n";
            }
            con.Close();

            return output;
        }


        //Update deck SET card1 = 'undefined', card2 = 'undefined',.... WHERE username='kienboec'; 
        public void UpdateDeck(string user, string card1, string card2, string card3, string card4)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("UPDATE deck SET card1=@card1, card2=@card2, card3=@card3, card4=@card4 WHERE username=@username", con);
            cmd.Parameters.AddWithValue("username", user);
            cmd.Parameters.AddWithValue("card1", card1);
            cmd.Parameters.AddWithValue("card2", card2);
            cmd.Parameters.AddWithValue("card3", card3);
            cmd.Parameters.AddWithValue("card4", card4);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public string GetUserData(string user)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT name,bio,image FROM userdata WHERE username=@user", con);
            cmd.Parameters.AddWithValue("user", user);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {

                output = rdr.GetString(0) + "\n" + rdr.GetString(1) + "\n" + rdr.GetString(2);
            }
            con.Close();

            return output;
        }
        public string GetUserStats(string user)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT wins,draws,loses FROM userstats WHERE username=@user", con);
            cmd.Parameters.AddWithValue("user", user);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {

                output = rdr.GetInt32(0).ToString() + "\n" + rdr.GetInt32(1).ToString() + "\n" + rdr.GetInt32(2).ToString();
            }
            con.Close();

            return output;
        }

        public string GetUserScore()
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();
            
            using var cmd = new NpgsqlCommand("SELECT * FROM userstats GROUP BY wins, draws, loses, username ORDER BY wins DESC", con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                output = output + rdr.GetString(0) + " " + rdr.GetInt32(1).ToString() + " " + rdr.GetInt32(2).ToString() + " " + rdr.GetInt32(2).ToString() + "\n";
            }
            con.Close();

            return output;
        }
        public string GetTrading()
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM tradings", con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                output = output + rdr.GetInt32(0).ToString() + " " + rdr.GetString(1) + " " + rdr.GetInt32(2).ToString() + " " + rdr.GetString(3) + "\n";
            }
            con.Close();

            return output;
        }

        //Update deck SET card1 = 'undefined', card2 = 'undefined',.... WHERE username='kienboec'; 
        public void UpdateUserData(string user, string name, string bio, string image)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("UPDATE userdata SET name=@name, bio=@bio, image=@image WHERE username=@username", con);
            cmd.Parameters.AddWithValue("username", user);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("bio", bio);
            cmd.Parameters.AddWithValue("image", image);
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
        public Boolean CheckUserHasCard(string user, int iddb, int idcontains)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT id FROM usercards where username=@user AND id=@id", con);
            cmd.Parameters.AddWithValue("user", user);
            cmd.Parameters.AddWithValue("id", iddb);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            Boolean cont = false;
            string idCard = "";
            while (rdr.Read())
            {
                idCard = rdr.GetInt32(0).ToString();
            }

            try
            {
                if ( String.Compare(idCard, idcontains.ToString())== 0)
                {
                    cont = true;
                }
                else
                {
                    cont = false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Card id existiert nicht.");
            }

            return cont;

        }
        public int CardMaxId()
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
                    //Console.WriteLine("Has rows");
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
        public int Packidis()
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
                    //Console.WriteLine("Has rows");
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
        public void CheckAllCard()
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM card", con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            
            int maxid = CardMaxId();

            while (rdr.Read())
            {
                try
                {
                    if (pack.AllCards.Any(p => p.id == maxid))
                    {
                        Console.WriteLine("Alle Karten vorhanden.");
                    }
                    else
                    {
                        //Console.WriteLine("ADDING CARD);
                        pack.AllCards.Add(new Card(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetString(3), rdr.GetString(4)));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("");
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
        public string TokenToUser(string token)
        {
            // Example:
            // Basic testuser-mtcgToken
            try { 
                string userToken = CheckToken(token);
                // testuser-mtcgToken
                string username = userToken.Split(' ')[1];
                username = string.Concat(username.Reverse().Skip(10).Reverse());
                return username;
            }
            catch(Exception e)
            {
                return "";
            }
            // testuser
            

            
        }
        public int CheckUserCoins(string user)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT coins FROM users where username=@user", con);
            cmd.Parameters.AddWithValue("user", user);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            int output = 0;

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                output = rdr.GetInt32(0);
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
        public string FullCardInfo(int id)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM card where id=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                output = rdr.GetInt32(0).ToString() + " " + rdr.GetString(1) + " " + rdr.GetInt32(2).ToString() + " " + rdr.GetString(3) + " " + rdr.GetString(4);
            }
            con.Close();

            //Console.WriteLine("CardId is: {0}", output);

            return output;
        }
        public string CheckCardsFromPack(int id)
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT card1,card2,card3,card4,card5 FROM packages where packid=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                output = rdr.GetInt32(0).ToString() + " " + rdr.GetInt32(1).ToString() + " " + rdr.GetInt32(2).ToString() + " " + rdr.GetInt32(3).ToString() + " " + rdr.GetInt32(4).ToString() + " ";
            }
            con.Close();

            //Console.WriteLine("CardId is: {0}", output);

            return output;
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
