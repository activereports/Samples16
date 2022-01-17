using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace GrapeCity.ActiveReports.Samples.JsonDataSource
{
	// Provides the data used in the sample.
	internal sealed class DataLayer
	{
		public static string CreateData()
		{
			const string sourceUrl = @"http://localhost:30187/Service.asmx/GetJson";
			string responseText = null;

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Authorization 
					= AuthenticationHeaderValue.Parse("Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("admin:1")));
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var request = new HttpRequestMessage(HttpMethod.Post, sourceUrl)
				{
					Content = new StringContent(String.Empty, Encoding.UTF8, "application/json")
				};
				var response = httpClient.SendAsync(request).Result;
				var json = response.Content.ReadAsStringAsync().Result;
				var values = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
				if (values.ContainsKey("d"))
				{
					responseText = values["d"];
				}
			}
			
			return responseText;
		}
	}
}
