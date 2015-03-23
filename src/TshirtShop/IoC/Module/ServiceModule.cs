using TshirtShop.Service;
using Ninject.Modules;
using TshirtShop.Service.Implement;

namespace TshirtShop
{
	/// <summary>
	/// Service module.
	/// </summary>
	public class ServiceModule : NinjectModule
	{
		/// <summary>
		/// Loads the module into the kernel.
		/// </summary>
		public override void Load()
		{
			Bind<IClientService>().To<ClientService>().InSingletonScope();
			Bind<IConfigurationService>().To<ConfigurationService>().InSingletonScope();
			Bind<IOrderService>().To<OrderService>().InSingletonScope();
			Bind<IProductService>().To<ProductService>().InSingletonScope();
			Bind<IRestDataService>().To<RestDataService>().InSingletonScope();
		}
	}
}

