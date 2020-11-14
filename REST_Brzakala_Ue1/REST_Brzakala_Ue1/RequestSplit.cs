﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace REST_BRZAKALA_UE1
{
	public class RequestSplit : IRequestContext
	{
		public RequestSplit()
		{
			RequestBody = new Dictionary<string, string>();
			//AllMsg = new Dictionary<int, string>();
		}

		public void split(string request)
		{
			//read line by line
			using (StringReader reader = new StringReader(request))
			{
				string line;        //line
				int l = 0;          //lines, starting from 0
				while ((line = reader.ReadLine()) != null)
				{
					Console.WriteLine(line); // Request line by line ausgeben.
					if (l == 0)
					{
						Method = request.Split(' ')[0];
						Url = request.Split(' ')[1];
						Version = request.Split(' ', '\n')[2];
						l++;
					}
					if (string.IsNullOrEmpty(line))
					{
						break;
					}
					if (line.Contains(':') && l > 0)
					{
						string[] arr = line.Split(':');
						string k = arr[0];
						string v = arr[1].Trim();
						RequestBody.Add(k, v);

					}
					l++;
				}
				if (ContentLength > 0)
				{
					char[] msg = new char[ContentLength];
					// Read(Char[], Int32, Int32)
					// Reads a specified maximum of characters from the current stream
					// into a buffer, beginning at the specified index.
					reader.Read(msg, 0, ContentLength);

					// Char in String convert
					ContentStr = new string(msg);
				}
				else
				{
					ContentStr = "";
				}
			}

		}
		public int ContentLength
		{
			get
			{
				if (!RequestBody.ContainsKey("Content-Length"))
				{
					return 0;
				}
				return Int32.Parse(RequestBody["Content-Length"]);
			}
		}
		public Dictionary<string, string> RequestBody { get; set; }
		//public Dictionary<int, string> AllMsg { get; set; }
		public string Method { get; set; }
		public string Url { get; set; }
		public string Version { get; set; }
		public string ContentStr { get; set; }
	}
}