using System;

namespace TshirtShop.Service.Implement
{
	/// <summary>
	/// Configuration service.
	/// </summary>
	public class ConfigurationService : IConfigurationService
	{
		/// <summary>
		/// Gets the rest API URL.
		/// </summary>
		/// <returns>The rest API URL.</returns>
		public string GetRestApiUrl()
		{
			return "http://localhost:3000/api";
		}
	}
}

