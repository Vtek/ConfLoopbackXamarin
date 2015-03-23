using Ninject;

namespace TshirtShop
{
	/// <summary>
	/// Host.
	/// </summary>
	public static class Host
	{
		/// <summary>
		/// Gets or sets the kernel.
		/// </summary>
		/// <value>The kernel.</value>
		static StandardKernel Kernel { get; set; }

		/// <summary>
		/// Initializes the Host class.
		/// </summary>
		static Host()
		{
			Kernel = new StandardKernel(new ServiceModule());
		}

		/// <summary>
		/// Get an instance of T type.
		/// </summary>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T Get<T>()
		{
			return Kernel.Get<T>();
		}
	}
}

