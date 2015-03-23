using System;
using System.Collections.Generic;
using System.Linq;
using TshirtShop.Model;
using Xamarin.Forms;

namespace TshirtShop
{
	/// <summary>
	/// Root page.
	/// </summary>
	public sealed class RootPage : ContentPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TshirtShop.RootPage"/> class.
		/// </summary>
		public RootPage ()
		{
			Initialize();
		}

		/// <summary>
		/// Initialize this instance.
		/// </summary>
		void Initialize()
		{
			var layout = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center
			};

			Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
			Content = layout;

			var loadingPage = new LoadingPage(async (page) =>
			{
				var vm = ViewModelFactory.Get<RootViewModel>();
				var products = await vm.GetProducts();

				var kv = products.GroupBy(p => p.Category, p => p, (key, value) => new { Key = key, Value = value});

				var tableRoot = new TableRoot();

				foreach(var obj in kv)
					tableRoot.Add(GetTableSection(obj.Key, obj.Value));

				var tableView = new TableView { Intent = TableIntent.Menu, Root = tableRoot };

				page.OnLoaded(tableView);

			}, "Chargement du catalogue");


			loadingPage.Loaded += async (sender, e) => {

				var label = new Label
				{
					Text = "T-Shirt shop",
					FontSize = 36.0,
					TextColor = Color.FromRgb(52, 152, 219),
					HorizontalOptions = LayoutOptions.Center
				};
				layout.Children.Add(label);
				layout.Children.Add((TableView)e);
				await Navigation.PopModalAsync();
			};
			Navigation.PushModalAsync(loadingPage);
		}

		/// <summary>
		/// Gets the table section.
		/// </summary>
		/// <returns>The table section.</returns>
		/// <param name="title">Title.</param>
		/// <param name="products">Products.</param>
		TableSection GetTableSection(string title, IEnumerable<Product> products)
		{
			var section = new TableSection();
			section.Title = title;
			foreach(var product in products)
			{
				var imageSource = ImageSource.FromUri(new Uri(product.ImageFile));
				var imageCell = new ImageCell { ImageSource = imageSource, Text = product.Name, Detail = string.Format("Ref : {0}", product.Reference), CommandParameter = product };
				imageCell.Tapped += async (sender, e) => await Navigation.PushModalAsync(new OrderPage((Product)imageCell.CommandParameter));
				section.Add(imageCell);
			}

			return section;
		}
	}
}

