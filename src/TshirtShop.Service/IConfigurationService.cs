namespace TshirtShop.Service
{
	/// <summary>
	/// Configuration service.
	/// </summary>
	public interface IConfigurationService
	{
		/// <summary>
		/// Gets the rest API URL.
		/// </summary>
		/// <returns>The rest API URL.</returns>
		string GetRestApiUrl();
	}
}

