using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace TshirtShop.Service.Implement
{
	/// <summary>
	/// Rest data service.
	/// </summary>
	public class RestDataService : IRestDataService
	{
		/// <summary>
		/// Get.
		/// </summary>
		/// <param name="url">URL.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public async Task<T> Get<T>(string url)
		{
			var httpClient = new HttpClient();
			var responseTask = await httpClient.GetStringAsync(url);
			return JsonConvert.DeserializeObject<T>(responseTask, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
		}

		/// <summary>
		/// Post.
		/// </summary>
		/// <param name="url">URL.</param>
		/// <param name="obj">Object.</param>
		public async Task<T> Post<T>(string url, T obj)
		{
			using (var httpClient = new HttpClient())
			{
				var json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var responseTask = await httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
				var jsonTask = await responseTask.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(jsonTask, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
			}
		}
	}
}

