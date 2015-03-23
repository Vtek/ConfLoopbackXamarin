using System.Threading.Tasks;
using TshirtShop.Model;

namespace TshirtShop.Service
{
	/// <summary>
	/// Client service.
	/// </summary>
	public interface IClientService
	{
		/// <summary>
		/// Create the specified client.
		/// </summary>
		/// <param name="client">Client.</param>
		Task<Client> Create(Client client);
	}
}

