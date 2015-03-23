using System.ComponentModel;

namespace TshirtShop
{
	/// <summary>
	/// View model factory.
	/// </summary>
	public static class ViewModelFactory
	{
		/// <summary>
		/// Get an instance of T type.
		/// </summary>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T Get<T>() where T : INotifyPropertyChanged
		{
			return Host.Get<T>();
		}
	}
}

