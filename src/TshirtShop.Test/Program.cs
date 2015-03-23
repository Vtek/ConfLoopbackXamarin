using System;
using TshirtShop.Service.Implement;
using System.Threading.Tasks;

namespace TshirtShop.Test
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var restApi = new RestDataService();
			var conf = new ConfigurationService();
			var productService = new ProductService(restApi, conf);
			var task = productService.GetAll();
			Task.WaitAll(task);
			var product = task.Result;
		}
	}
}
