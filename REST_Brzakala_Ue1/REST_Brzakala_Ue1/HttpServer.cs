using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace REST_BRZAKALA_UE1
{
	public class HttpServer
	{
		static Encoding enc = Encoding.UTF8;
		RequestSplit rs = new RequestSplit();
		Response res = new Response();


		public void StartServer()
		{
			Console.WriteLine("-----------------------");
			Console.WriteLine("Waiting for Requests...");

			IPAddress ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
			TcpListener listener = new TcpListener(ipAddress, 8080);
			listener.Start();

			res.msgCounter = 1;

			while (true)
			{
				TcpClient client = listener.AcceptTcpClient();
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

				Console.WriteLine("Whats in the dic?");
				foreach (KeyValuePair<string, string> kvp in RequestBody)
				{
					Console.WriteLine("{0}{1}",
						kvp.Key, kvp.Value);
				}
				Console.WriteLine("Whats in the ContentStr: {0}", ContentStr);
				*/

				Console.WriteLine("");
				res.lastPart = rs.Url.Split('/').Last();


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
				else
				{
					res.ResponseFailed();
					stream.Write(res.sendBytes, 0, res.sendBytes.Length);
					rs.RequestBody.Clear();
				}

				stream.Close();
				client.Close();
			}
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
	}
}