using TshirtShop.Model;
using System.Threading.Tasks;

namespace TshirtShop.Service.Implement
{
	/// <summary>
	/// Order service.
	/// </summary>
	public class OrderService : ApiService, IOrderService
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TshirtShop.Service.Implement.ClientService"/> class.
		/// </summary>
		/// <param name="restDataService">Rest data service.</param>
		/// /// <param name="configurationService">Configuration service.</param>
		public OrderService(IRestDataService restDataService, IConfigurationService configurationService)
			: base(restDataService, configurationService, "Orders")
		{

		}

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns>The all.</returns>
		public async Task<Order> Create(Order order)
		{
			return await RestDataService.Post<Order>(Url, order);
		}
	}
}

