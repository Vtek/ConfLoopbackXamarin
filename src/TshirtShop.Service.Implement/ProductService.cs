using System.Collections.Generic;
using System.Threading.Tasks;
using TshirtShop.Model;

namespace TshirtShop.Service.Implement
{
	/// <summary>
	/// Product service.
	/// </summary>
	public class ProductService : ApiService, IProductService
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TshirtShop.Service.Implement.ClientService"/> class.
		/// </summary>
		/// <param name="restDataService">Rest data service.</param>
		/// /// <param name="configurationService">Configuration service.</param>
		public ProductService(IRestDataService restDataService, IConfigurationService configurationService)
			: base(restDataService, configurationService, "Products")
		{

		}

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns>The all.</returns>
		public async Task<List<Product>> GetAll()
		{
			return await RestDataService.Get<List<Product>>(Url);
		}
	}
}

