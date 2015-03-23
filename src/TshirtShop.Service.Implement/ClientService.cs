using TshirtShop.Model;
using System.Threading.Tasks;

namespace TshirtShop.Service.Implement
{
	/// <summary>
	/// Client service.
	/// </summary>
	public class ClientService : ApiService, IClientService
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TshirtShop.Service.Implement.ClientService"/> class.
		/// </summary>
		/// <param name="restDataService">Rest data service.</param>
		/// /// <param name="configurationService">Configuration service.</param>
		public ClientService(IRestDataService restDataService, IConfigurationService configurationService)
			: base(restDataService, configurationService, "Clients")
		{

		}

		/// <summary>
		/// Create the specified client.
		/// </summary>
		/// <param name="client">Client.</param>
		public async Task<Client> Create(Client client)
		{
			return await RestDataService.Post<Client>(Url, client);
		}
	}
}

