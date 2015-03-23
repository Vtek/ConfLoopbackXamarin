using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace TshirtShop
{
	/// <summary>
	/// Loading page.
	/// </summary>
	public class LoadingPage : ContentPage
	{
		/// <summary>
		/// Occurs when loaded.
		/// </summary>
		public event EventHandler<object> Loaded;

		/// <summary>
		/// Initializes a new instance of the <see cref="TshirtShop.LoadingPage"/> class.
		/// </summary>
		/// <param name="action">Action.</param>
		/// <param name="title">Title</param> 
		public LoadingPage(Action<LoadingPage> action, string title)
		{
			Initialize(title);
			action(this);
		}

		/// <summary>
		/// Initialize this instance.
		/// </summary>
		void Initialize(string title)
		{
			var layout = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center
			};

			var label = new Label
			{
				XAlign = TextAlignment.Center,
				Text = title
			};

			var indicator = new ActivityIndicator
			{
				IsRunning = true,
			};

			layout.Children.Add(label);
			layout.Children.Add(indicator);
			Content = layout;
		}

		/// <summary>
		/// Raises the loaded event.
		/// </summary>
		/// <param name="obj">Object.</param>
		public void OnLoaded(object obj)
		{
			var tmp = Loaded;

			if(tmp != null)
				tmp(this, obj);
		}
	}
}

