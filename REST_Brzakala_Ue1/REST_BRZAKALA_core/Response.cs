using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;

namespace REST_BRZAKALA_core
{
	public class Response : IResponse
	{
		// Encoding.GetBytes 
		static Encoding enc = Encoding.UTF8;
		public Dbconn dbc = new Dbconn();


		public Response()
		{
			AllMsg = new Dictionary<int, string>();
			msgCounter = 1;

		}

		public void ResponseGet()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: text/plain");
			builder.AppendLine("");
			foreach (KeyValuePair<int, string> kvp in AllMsg)
			{
				builder.AppendFormat("{0} {1}\n",
					kvp.Key, kvp.Value);
			}
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());

		}
		public void ResponseGetId()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: text/plain");
			builder.AppendLine("");
			builder.AppendFormat(AllMsg[Int32.Parse(lastPart)]);
			builder.AppendLine("");


			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());

			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());


		}
		public void ResponsePost()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: text/plain");
			builder.AppendLine("");
			builder.AppendFormat("Nachricht id: {0}", msgCounter);

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
			msgCounter++;

		}
		public void ResponsePut()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: text/plain");
			builder.AppendLine("");
			builder.AppendFormat("Nachricht id: {0} is updated.", lastPart);

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());

		}
		public void ResponseDeleteId()
		{
			AllMsg.Remove(Int32.Parse(lastPart));

			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: text/plain");
			builder.AppendLine("");
			builder.AppendFormat("Nachricht id: {0} is deleted.", lastPart);

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseDelete()
		{
			AllMsg.Clear();
			msgCounter = 1;

			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: text/plain");
			builder.AppendLine("");
			builder.AppendLine("Nachrichten wurden geloescht.");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseFailed()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: text/plain");
			builder.AppendLine("");
			builder.AppendLine("Fehler");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseReg()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("Registration Succesfull");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());

		}
		public void ResponseRegExi()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Username already exists.");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());

		}
		public void ResponseLogin()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("Login Succesfull");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());

		}
		public void ResponseLoginFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Login failed.");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseCard()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("Card Succesfull created");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseCardFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Creating Card failed.");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseTradingFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Creating Trading failed.");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseTradingDeleteFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Delete Trading failed.");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseTradingFailCard()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("The Card you want to Trade is not in your possesion.");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseTradingIdFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Creating Trading failed - The Id is already in use.");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponsePackages()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("Packages Succesfull created");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponsePackagesFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Creating Packages failed.");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseTransPackages()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("One Package (5 Cards) Succesfull added to your Cards.");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseTransPackagesFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Package Transaction failed. - Do you have more than 5 Coins?");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseGetAquiredCards(string json)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine(json);

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}

		public void ResponseGetAquiredFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Failed - Already bought some package?");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseGetDeck(string json)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine(json);

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseGetDeckPlain(string json)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: text/plain");
			builder.AppendLine("");
			builder.AppendLine(json);

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}

		public void ResponseDeckFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Failed - do you provide your authorization? ");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseConfigureDeck()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("5 Cards Succesfull added to your Deck.");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseConfigureDeckFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Configure Deck failed. - Do you have the Cards you mentioned in your Cards?");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseConfigureDeckSame()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Configure Deck failed. - Did you enter the same id 2 times?");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseFormatFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Your Json Format is False or Card Id not in your Possesion.");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseGetUserData(string json)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine(json);

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}

		public void ResponseUserDataFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Failed - do you provide your authorization? ");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseUpdateUserData()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Userdata sucessfull added.");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}

		public void ResponseUpdateUserDataFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Failed - do you provide your authorization? ");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseGetUserStats(string json)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine(json);

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseGetScore(string json)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine(json);

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponsePostCardTrade()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("One Card succesfull added to the Trading Store.");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseTradingDelete()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("One Card deleted from Trading Store.");

			Console.WriteLine("");
			Console.WriteLine("responce:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}

		public Dictionary<int, string> AllMsg { get; set; }
		public byte[] sendBytes { get; set; }
		public string lastPart { get; set; }
		public int msgCounter { get; set; }
		public string responseMsg { get; set; }
	}
}
