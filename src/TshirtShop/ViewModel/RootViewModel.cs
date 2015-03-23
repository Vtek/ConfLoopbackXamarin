using TshirtShop.Service;
using TshirtShop.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TshirtShop
{
	/// <summary>
	/// Root view model.
	/// </summary>
	public class RootViewModel : ViewModel
	{
		/// <summary>
		/// Gets or sets the product service.
		/// </summary>
		/// <value>The product service.</value>
		IProductService ProductService { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="TshirtShop.RootViewModel"/> class.
		/// </summary>
		/// <param name="productService">Product service.</param>
		public RootViewModel (IProductService productService)
		{
			ProductService = productService;
		}

		/// <summary>
		/// Gets the products.
		/// </summary>
		/// <returns>The products.</returns>
		public async Task<List<Product>> GetProducts()
		{
			return await ProductService.GetAll();
		}
	}
}

