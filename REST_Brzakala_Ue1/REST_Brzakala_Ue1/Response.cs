using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;

namespace REST_BRZAKALA_UE1
{
	public class Response : IResponse
	{
		// Encoding.GetBytes 
		static Encoding enc = Encoding.UTF8;



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


		public Dictionary<int, string> AllMsg { get; set; }
		public byte[] sendBytes { get; set; }
		public string lastPart { get; set; }
		public int msgCounter { get; set; }
		public string responseMsg { get; set; }
	}
}
