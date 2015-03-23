using TshirtShop.Model;
using Xamarin.Forms;
using System;

namespace TshirtShop
{
	/// <summary>
	/// Order page.
	/// </summary>
	public class OrderPage : ContentPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TshirtShop.OrderPage"/> class.
		/// </summary>
		/// <param name="product">Product.</param>
		public OrderPage(Product product)
		{
			InitializeComponent(product);
			Bind(product);
		}

		/// <summary>
		/// Initializes the component.
		/// </summary>
		/// <param name="product">Product.</param>
		void InitializeComponent(Product product)
		{
			var layout = new StackLayout 
			{
				VerticalOptions = LayoutOptions.Center
			};

			var image = new Image 
			{ 
				HorizontalOptions = LayoutOptions.Center,
				Source = ImageSource.FromUri(new Uri(product.ImageFile))
			};

			var label = new Label { HorizontalOptions = LayoutOptions.Center, Text = product.Name };

			var genderLabel = new Label { Text = "Men / Women", HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.Center }; 
			var genderSwitch = new Switch();
			genderSwitch.SetBinding<OrderViewModel>(Switch.IsToggledProperty, vm => vm.IsMen);

			var genderLayout = new StackLayout { Padding = new Thickness(15, 0), Spacing = 0, Orientation = StackOrientation.Horizontal, Children = { genderLabel, genderSwitch } };


			var sizeLabel = new Label { Text = "Size", HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.Center }; 
			var sizePicker = new Picker { Title = "Small", WidthRequest = 100.0, HorizontalOptions = LayoutOptions.EndAndExpand, VerticalOptions = LayoutOptions.Center };
			sizePicker.Items.Add("Small");
			sizePicker.Items.Add("Medium");
			sizePicker.Items.Add("Large");
			sizePicker.Items.Add("X-Large");
			sizePicker.SetBinding<OrderViewModel>(Picker.SelectedIndexProperty, vm => vm.SizeIndex);

			var sizeLayout = new StackLayout { Padding = new Thickness(15, 0), Spacing = 0, Orientation = StackOrientation.Horizontal, Children = { sizeLabel, sizePicker } };

			var buttonCancel = new Button { HorizontalOptions = LayoutOptions.EndAndExpand, Text = "Cancel" };
			buttonCancel.Clicked += async (sender, e) => await Navigation.PopModalAsync();

			var buttonOrder = new Button { HorizontalOptions = LayoutOptions.StartAndExpand, Text = "Purchase" };
			buttonOrder.SetBinding<OrderViewModel>(Button.CommandProperty, vm => vm.OrderCommand);

			var bottomLayout = new StackLayout 
			{ 
				Spacing = 0, 
				Orientation = StackOrientation.Horizontal, 
				Children = 
				{ 
					buttonCancel,
					new Label
					{
						HorizontalOptions = LayoutOptions.CenterAndExpand
					},
					buttonOrder
				} 
			};

			var textBoxFirstName = new Entry 
			{ 
				Placeholder = "Prénom",
				WidthRequest = 300,
				HorizontalOptions = LayoutOptions.Center
			};
			textBoxFirstName.SetBinding<OrderViewModel>(Entry.TextProperty, t => t.FirstName);

			var textBoxLastName = new Entry 
			{ 
				Placeholder = "Nom",
				WidthRequest = 300,
				HorizontalOptions = LayoutOptions.Center
			};
			textBoxLastName.SetBinding<OrderViewModel>(Entry.TextProperty, t => t.LastName);

			var textBoxAdress = new Entry 
			{ 
				Placeholder = "Adresse",
				WidthRequest = 300,
				HorizontalOptions = LayoutOptions.Center
			};
			textBoxAdress.SetBinding<OrderViewModel>(Entry.TextProperty, t => t.Adress);

			var textBoxCity = new Entry 
			{ 
				Placeholder = "Ville",
				WidthRequest = 300,
				HorizontalOptions = LayoutOptions.Center
			};
			textBoxCity.SetBinding<OrderViewModel>(Entry.TextProperty, t => t.City);

			var textBoxZipCode = new Entry 
			{ 
				Placeholder = "Code postal",
				WidthRequest = 300,
				HorizontalOptions = LayoutOptions.Center
			};
			textBoxZipCode.SetBinding<OrderViewModel>(Entry.TextProperty, t => t.ZipCode);

			var textBoxCountry = new Entry 
			{ 
				Placeholder = "Pays",
				WidthRequest = 300,
				HorizontalOptions = LayoutOptions.Center
			};
			textBoxCountry.SetBinding<OrderViewModel>(Entry.TextProperty, t => t.Country);

			layout.Children.Add(image);
			layout.Children.Add(label);
			layout.Children.Add(genderLayout);
			layout.Children.Add(sizeLayout);
			layout.Children.Add(textBoxFirstName);
			layout.Children.Add(textBoxLastName);
			layout.Children.Add(textBoxAdress);
			layout.Children.Add(textBoxCity);
			layout.Children.Add(textBoxZipCode);
			layout.Children.Add(textBoxCountry);

			layout.Children.Add(bottomLayout);

			Content = layout;
		}

		void Bind(Product product)
		{
			var viewModel = ViewModelFactory.Get<OrderViewModel>();
			viewModel.Current = product;

			viewModel.Failed += async (sender, e) => 
			{
				await DisplayAlert("Echec de la commande", "Impossible de passer la commande !", "OK");
				await Navigation.PopModalAsync();
			};

			viewModel.Ordered += async (sender, e) => 
			{
				await DisplayAlert("Commande validée", "Merci pour votre achat !", "OK");
				await Navigation.PopModalAsync();
			};

			BindingContext = viewModel;
		}

	}
}

