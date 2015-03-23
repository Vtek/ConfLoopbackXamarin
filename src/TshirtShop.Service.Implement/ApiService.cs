namespace TshirtShop.Service.Implement
{
	public class ApiService
	{
		/// <summary>
		/// Gets or sets the URL.
		/// </summary>
		/// <value>The URL.</value>
		protected string Url { get; private set; }

		/// <summary>
		/// Gets or sets the rest data service.
		/// </summary>
		/// <value>The rest data service.</value>
		protected IRestDataService RestDataService { get; set; }

		/// <summary>
		/// Initializes a new instance of the ApiService class.
		/// </summary>
		/// <param name="restDataService">Rest data service.</param>
		/// <param name="configurationService">Configuration service.</param>
		/// <param name="apiCollectionName">Api colleciton name</param>
		protected ApiService(IRestDataService restDataService, IConfigurationService configurationService, string apiCollectionName)
		{
			RestDataService = restDataService;
			Url = string.Format("{0}/{1}", configurationService.GetRestApiUrl(), apiCollectionName);
		}
	}
}

