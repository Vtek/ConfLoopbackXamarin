using System.Threading.Tasks;
using System.Collections.Generic;
using TshirtShop.Model;

namespace TshirtShop.Service
{
	/// <summary>
	/// Product service.
	/// </summary>
	public interface IProductService
	{
		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns>The all.</returns>
		Task<List<Product>> GetAll();
	}
}

