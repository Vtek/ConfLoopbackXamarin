using Xamarin.Forms;

namespace TshirtShop
{
	public sealed class RootPage : ContentPage
	{
		public RootPage ()
		{
			Initialize();
		}

		void Initialize()
		{
			Content = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				Children = {
					new Label {
						XAlign = TextAlignment.Center,
						Text = "Welcome to Xamarin Forms!"
					}
				}
			};
		}
	}
}

