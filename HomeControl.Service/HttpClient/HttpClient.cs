using System;
using System.IO;
using System.Net;
using System.Text;

namespace HomeControl.Service.HttpClient
{
	public class HttpClient : IHttpClient
	{
		public string Get(string url)
		{
			HttpWebRequest request = WebRequest.CreateHttp(url);
			request.Method = "GET";

			using (var response = (HttpWebResponse)request.GetResponse())
			using (Stream responseStream = response.GetResponseStream())
			using (var streamReader = new StreamReader(responseStream ?? throw new Exception($"No response got for GET request to {url}"), Encoding.UTF8))
			{
				string responseJson = streamReader.ReadToEnd();
				return responseJson;
			}
		}
	}
}