using TshirtShop.Model;
using System.Threading.Tasks;

namespace TshirtShop.Service
{
	/// <summary>
	/// Order service.
	/// </summary>
	public interface IOrderService
	{
		/// <summary>
		/// Create the specified order.
		/// </summary>
		/// <param name="order">Order.</param>
		Task<Order> Create(Order order);
	}
}

