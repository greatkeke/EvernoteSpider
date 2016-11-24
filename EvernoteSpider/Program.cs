using System;
using System.IO;
using System.Net;
using System.Text;

class Program
{
	const string loginPageUrl = "https://app.yinxiang.com/Login.action?targetUrl=%2FHome.action";
	const string loginUrl = @"https://app.yinxiang.com/Login.action";

	static void Main(string[] args)
	{
		Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

		try
		{
			//Get(loginPageUrl);

			//Post(loginUrl);



		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.GetType());
			Console.WriteLine(ex.Message);
		}
	}

	static string Get(string loginPageUrl)
	{
		HttpWebRequest httpWebRequest = WebRequest.CreateHttp(loginPageUrl);
		httpWebRequest.Method = "GET";
		var response = httpWebRequest.GetResponseAsync().Result;
		var loginPage = new StreamReader(response.GetResponseStream()).ReadToEndAsync().Result;
		return loginPage;
	}

	static void Post(string loginUrl)
	{
		HttpWebRequest loginRequest = WebRequest.CreateHttp(loginUrl);
		loginRequest.Method = "POST";
		var loginCredential = @"username=fengxxxke%40gmail.com&password=yx915128&login=%E7%99%BB%E5%BD%95&hpts=1479944545282&hptsh=sIIASlYLFApS4RPar%2B3DTJ9%2FO7E%3D&analyticsLoginOrigin=login_action&clipperFlow=false&showSwitchService=true&targetUrl=%2FHome.action&_sourcePage=TfwI5qit_yPiMUD9T65RG_YvRLZ-1eYO3fqfqRu0fynRL_1nukNa4gH1t86pc1SP&__fp=Ao1beWYEJjc3yWPvuidLz-TPR6I9Jhx8";
		var encoding = Encoding.GetEncoding("gb2312");
		var postData = encoding.GetBytes(loginCredential);
		var requestStream = loginRequest.GetRequestStreamAsync().Result;
		requestStream.Write(postData, 0, postData.Length);
		requestStream.Dispose();
		var loginResponse = loginRequest.GetResponseAsync().Result;
		var loginResult = new StreamReader(loginResponse.GetResponseStream()).ReadToEndAsync().Result;
	}
}



