using System.Threading.Tasks;

namespace TshirtShop.Service
{
	/// <summary>
	/// Rest data service.
	/// </summary>
	public interface IRestDataService
	{
		/// <summary>
		/// Get.
		/// </summary>
		/// <param name="url">URL.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		Task<T> Get<T>(string url);

		/// <summary>
		/// Post.
		/// </summary>
		/// <param name="url">URL.</param>
		/// <param name="obj">Object.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		Task<T> Post<T>(string url, T obj);
	}
}

