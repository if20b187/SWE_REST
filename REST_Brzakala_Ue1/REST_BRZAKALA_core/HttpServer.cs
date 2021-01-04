using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json;
using System.Linq;
using System.Text.RegularExpressions;

namespace REST_BRZAKALA_core
{
	public class HttpServer
	{
		static Encoding enc = Encoding.UTF8;
		RequestSplit rs = new RequestSplit();
		Response res = new Response();
		Dbconn dbc = new Dbconn();
		Packages pack = new Packages();
		public int packid = 0;


		public void StartServer(object argument)
		{
			TcpClient client = (TcpClient)argument;
			res.msgCounter = 1;

			dbc.checkAllCard();
			packid = dbc.packidis() + 1;
			// CHECK IF PACKID IS CORRECT
			//Console.WriteLine("packid is: {0}",packid);

			// CHECK IF alle Karten übernommen wurden von der Datenbank 
			/*
			Console.WriteLine("-----------------------------");
			Console.WriteLine("What is indbc.pack.AllCards?");
			foreach (Object obj in dbc.pack.AllCards)
				Console.WriteLine("   cards:{0}", obj);
			Console.WriteLine("-----------------------------");
			*/

			Console.WriteLine("request from client:");
			Console.WriteLine("");

			NetworkStream stream = client.GetStream();
			string request = ToString(stream);
			rs.split(request);


			// ALLMSG DICTIONARY AUSGABE TEST:
			/*
			Console.WriteLine("Whats in the allmsg?");
			foreach (KeyValuePair<int, string> kvp in AllMsg)
			{
				Console.WriteLine("{0}{1}",
					kvp.Key, kvp.Value);
			}
			*/
			Console.WriteLine("-------------------------------------------------");
			Console.WriteLine("Whats in the dic?");
			foreach (KeyValuePair<string, string> kvp in rs.RequestBody)
			{
				Console.WriteLine("{0}{1}",
					kvp.Key, kvp.Value);
			}
			Console.WriteLine("-------------------------------------------------");
			Console.WriteLine("Whats in the ContentStr: {0}", rs.ContentStr);
			Console.WriteLine("-------------------------------------------------");

			/*
			Console.WriteLine("");
			res.lastPart = rs.Url.Split('/').Last();
			*/
			// GET ALL
			if (String.Compare(rs.Method, "GET") == 0 && String.Compare(rs.Url, "/message") == 0)
			{
				res.ResponseGet();
				stream.Write(res.sendBytes, 0, res.sendBytes.Length);
				rs.RequestBody.Clear();
			}
			// GET <id>
			else if (String.Compare(rs.Method, "GET") == 0 && String.Compare(rs.Url, "/message/" + res.lastPart) == 0 && res.AllMsg.ContainsKey(Int32.Parse(res.lastPart)))
			{
				res.ResponseGetId();
				stream.Write(res.sendBytes, 0, res.sendBytes.Length);
				rs.RequestBody.Clear();
			}
			// POST
			else if (String.Compare(rs.Method, "POST") == 0 && String.Compare(rs.Url, "/message") == 0)
			{
				res.AllMsg.Add(res.msgCounter, rs.ContentStr);
				res.ResponsePost();

				stream.Write(res.sendBytes, 0, res.sendBytes.Length);
				rs.RequestBody.Clear();
			}
			// PUT <id>
			else if (String.Compare(rs.Method, "PUT") == 0 && String.Compare(rs.Url, "/message/" + res.lastPart) == 0 && res.AllMsg.ContainsKey(Int32.Parse(res.lastPart)))
			{
				res.AllMsg[Int32.Parse(res.lastPart)] = rs.ContentStr;
				res.ResponsePut();
				stream.Write(res.sendBytes, 0, res.sendBytes.Length);
				rs.RequestBody.Clear();
			}
			// DELETE <id>
			else if (String.Compare(rs.Method, "DELETE") == 0 && String.Compare(rs.Url, "/message/" + res.lastPart) == 0 && res.AllMsg.ContainsKey(Int32.Parse(res.lastPart)))
			{
				res.ResponseDeleteId();
				stream.Write(res.sendBytes, 0, res.sendBytes.Length);
				rs.RequestBody.Clear();
			}
			// DELETE All
			else if (String.Compare(rs.Method, "DELETE") == 0 && String.Compare(rs.Url, "/message") == 0)
			{
				res.ResponseDelete();
				stream.Write(res.sendBytes, 0, res.sendBytes.Length);
				rs.RequestBody.Clear();
			}
			//REGISTRATION PART - ROUTE: /users
			else if (String.Compare(rs.Method, "POST") == 0 && String.Compare(rs.Url, "/users") == 0)
			{

                if (dbc.CheckUserExists(rs.acc.Username) ==  true)
                {
					res.ResponseRegExi();
				}
                else
                {
					res.ResponseReg();
					dbc.Register(rs.acc.Username, rs.acc.Password);
					
				}
									
				stream.Write(res.sendBytes, 0, res.sendBytes.Length);
				rs.RequestBody.Clear();
			}
			//LOGIN PART - ROUTE: /sessions
			else if (String.Compare(rs.Method, "POST") == 0 && String.Compare(rs.Url, "/sessions") == 0)
			{
				if (dbc.CheckUserExists(rs.acc.Username) == true && String.Compare(dbc.CheckUserPw(rs.acc.Username), rs.acc.Password) == 0 && dbc.CheckLogin(rs.acc.Username) == false)
				{
					res.ResponseLogin();
					dbc.Login(rs.acc.Username);

				}
				else
				{
					res.ResponseLoginFail();
				}
				stream.Write(res.sendBytes, 0, res.sendBytes.Length);
				rs.RequestBody.Clear();
			}
			//CARD PART - ROUTE: /card   - ONLY ADMIN
			else if (String.Compare(rs.Method, "POST") == 0 && String.Compare(rs.Url, "/card") == 0)
			{
				if (String.Compare("Basic admin-mtcgToken",dbc.CheckToken(rs.RequestBody["Authorization"])) == 0)
				{
					// init new Card
					Card card = new Card(0, "x", 0, "x", "x");
                    // set Card values
                    try
                    {
						card = JsonConvert.DeserializeObject<Card>(rs.ContentStr);
                    }
                    catch (Exception e)
                    {
						Console.WriteLine("------------------");
						Console.WriteLine("Wrong JSON Format!");
						Console.WriteLine("------------------");
					}
					
					if (String.Compare(dbc.CheckCardId(card.id), card.id.ToString()) == 0)
					{
						res.ResponseCardFail();
					}
					else if (card.id == 0)
                    {
						res.ResponseCardFail();
					}
					else
					{
						dbc.Card(card.id, card.name, card.damage, card.element, card.type);
						pack.AllCards.Add(card);
						res.ResponseCard();

						/*
						foreach (Object obj in pack.AllCards)
							Console.Write("   {0}", obj);
						Console.WriteLine();
						*/
					}
				}
				else
				{
					res.ResponseCardFail();
				}
				stream.Write(res.sendBytes, 0, res.sendBytes.Length);
				rs.RequestBody.Clear();
			}
			//PACKAGES PART - ROUTE: /packages   - ONLY ADMIN
			else if (String.Compare(rs.Method, "POST") == 0 && String.Compare(rs.Url, "/packages") == 0)
			{
				
				if (String.Compare("Basic admin-mtcgToken", dbc.CheckToken(rs.RequestBody["Authorization"])) == 0)
				{
					
					if (String.Compare(dbc.CheckPackId(packid), packid.ToString()) == 0)
					{
						Console.WriteLine("compare fehler");
						res.ResponsePackagesFail();
					}
					else if (packid == 0)
					{
						Console.WriteLine("ist 0 fehler.");
						res.ResponsePackagesFail();
					}
					else
					{
						string werte = dbc.pack.randomZu();
						Console.WriteLine(werte);

						string c1 = werte.Split(' ')[0];
						string c2 = werte.Split(' ')[1];
						string c3 = werte.Split(' ')[2];
						string c4 = werte.Split(' ')[3];
						string c5 = werte.Split(' ')[4];
						//Console.WriteLine("Split werte: {0} {1} {2} {3} {4}", c1,c2,c3,c4,c5);

						dbc.Packages(packid,Int32.Parse(c1), Int32.Parse(c2), Int32.Parse(c3), Int32.Parse(c4), Int32.Parse(c5));
						res.ResponsePackages();
					}
	
				}
				// BUY ONE PACKAGE
				//TRANSACTION PACKAGES PART - ROUTE: /transactions/packages  
				else if (String.Compare(rs.Method, "POST") == 0 && String.Compare(rs.Url, "/transactions/packages") == 0)
				{
					// CHECK IF USER HAS MORE THAN 5 COINS ---- ONE BUY - 5 COINS
					if (String.Compare(rs.RequestBody["Authorization"] , dbc.CheckToken(rs.RequestBody["Authorization"])) == 0)
					{
						/*
						 * 
						 * dbc methode: packid - die zahl damit man random macht von x Packages.
						 * das Package z.b: 2 - die karten nehmen als int 
						 * diese hinzufügen jedoch ganz: string(Id, name, damage,...)
						 * dbc add methode usercards
						 * 
						 */

						res.ResponseTransPackages();
					}
					else
					{
					res.ResponseTransPackagesFail();
				}
				stream.Write(res.sendBytes, 0, res.sendBytes.Length);
				rs.RequestBody.Clear();
			}
			//FALSE ROUTE
			else
			{
				res.ResponseFailed();
				stream.Write(res.sendBytes, 0, res.sendBytes.Length);
				rs.RequestBody.Clear();
			}

			stream.Close();
			client.Close();
			
		}


		public string ToString(NetworkStream stream)
		{
			MemoryStream memoryStream = new MemoryStream();
			byte[] data = new byte[256];
			int size;
			do
			{
				size = stream.Read(data, 0, data.Length);
				if (size == 0)
				{
					Console.WriteLine("client disconnected...");
					Console.ReadLine();
					return null;
				}
				memoryStream.Write(data, 0, size);
			} while (stream.DataAvailable);
			return enc.GetString(memoryStream.ToArray());
		}

		public static void Main()
        {
			
			HttpServer hs = new HttpServer();
			Console.WriteLine("-----------------------");
			Console.WriteLine("Waiting for Requests...");

			IPAddress ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
			TcpListener listener = new TcpListener(ipAddress, 8080);
			listener.Start();


            while (true)
            {
				TcpClient client = listener.AcceptTcpClient();
				Thread t = new Thread(hs.StartServer);
				t.Start(client);
			}
		}
	}
}