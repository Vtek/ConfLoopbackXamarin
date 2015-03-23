using System;
using TshirtShop.Model;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using TshirtShop.Service;
using System.Threading.Tasks;

namespace TshirtShop
{
	/// <summary>
	/// Order view model.
	/// </summary>
	public class OrderViewModel : ViewModel
	{
		/// <summary>
		/// Gets or sets the order service.
		/// </summary>
		/// <value>The order service.</value>
		IOrderService OrderService { get; set; }

		/// <summary>
		/// Gets or sets the client service.
		/// </summary>
		/// <value>The client service.</value>
		IClientService ClientService { get; set; }

		/// <summary>
		/// Occurs when insert.
		/// </summary>
		public event EventHandler Ordered;

		/// <summary>
		/// Occurs when failed.
		/// </summary>
		public event EventHandler Failed;

		/// <summary>
		/// Gets or sets the current.
		/// </summary>
		/// <value>The current.</value>
		public Product Current { get; set; }

		/// <summary>
		/// Gets or sets the size.
		/// </summary>
		/// <value>The size.</value>
		int _sizeIndex;
		public int SizeIndex
		{
			get
			{ 
				return _sizeIndex;
			}
			set
			{ 
				if(_sizeIndex != value)
				{
					_sizeIndex = value;
					OnPropertyChanged("SizeIndex");
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is men.
		/// </summary>
		/// <value><c>true</c> if this instance is men; otherwise, <c>false</c>.</value>
		bool _isMen;
		public bool IsMen
		{
			get
			{ 
				return _isMen;
			}
			set
			{ 
				if(_isMen != value)
				{
					_isMen = value;
					OnPropertyChanged("IsMen");
				}
			}
		}

		/// <summary>
		/// Gets the sizes.
		/// </summary>
		/// <value>The sizes.</value>
		List<string> _sizes = new List<string> { "Small", "Medium", "Large", "X-Large" };
		public List<string> Sizes 
		{
			get
			{ 
				return _sizes;
			}
		}

		string _firstName;
		public string FirstName
		{
			get
			{ 
				return _firstName;
			}
			set
			{ 
				if(_firstName != value)
				{
					_firstName = value;
					OnPropertyChanged("FirstName");
				}
			}
		}

		string _lastName;
		public string LastName
		{
			get
			{ 
				return _lastName;
			}
			set
			{ 
				if(_lastName != value)
				{
					_lastName = value;
					OnPropertyChanged("LastName");
				}
			}
		}

		string _adress;
		public string Adress
		{
			get
			{ 
				return _adress;
			}
			set
			{ 
				if(_adress != value)
				{
					_adress = value;
					OnPropertyChanged("Adress");
				}
			}
		}

		string _city;
		public string City
		{
			get
			{ 
				return _city;
			}
			set
			{ 
				if(_city != value)
				{
					_city = value;
					OnPropertyChanged("City");
				}
			}
		}

		string _zipCode;
		public string ZipCode
		{
			get
			{ 
				return _zipCode;
			}
			set
			{ 
				if(_zipCode != value)
				{
					_zipCode = value;
					OnPropertyChanged("ZipCode");
				}
			}
		}

		string _country;
		public string Country
		{
			get
			{ 
				return _country;
			}
			set
			{ 
				if(_country != value)
				{
					_country = value;
					OnPropertyChanged("Country");
				}
			}
		}

		/// <summary>
		/// Gets the Order command.
		/// </summary>
		/// <value>The insert command.</value>
		public ICommand OrderCommand { get; private set; }

		/// <summary>
		/// Initializes a new instance of the OrderViewModel class.
		/// </summary>
		public OrderViewModel(IOrderService orderService, IClientService clientService)
		{
			OrderService = orderService;
			ClientService = clientService;

			OrderCommand = new Command(async x => {
				var now = DateTime.Now;

				var client = await ClientService.Create(new Client{
					Adress = _adress,
					City = _city,
					Country = _country,
					FirstName = _firstName,
					LastName = _lastName,
					ZipCode = _zipCode
				});

				var order = await OrderService.Create( new Order 
				{ 
					IsMen = IsMen, 
					OrderDate = now, 
					Size = Sizes[SizeIndex],
					ProductId = Current.Id,
					ClientId = client.Id
				});

				var isOrdered = order != null;

				if(isOrdered)
					OnOrdered(order);
				else
					OnFailed();
			}, nothing => true
			);
		}

		/// <summary>
		/// Raises the ordered event.
		/// </summary>
		/// <param name="order">Order.</param>
		void OnOrdered(Order order)
		{
			var tmp = Ordered;
			if(tmp != null)
				tmp(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raises the failed event.
		/// </summary>
		void OnFailed()
		{
			var tmp = Failed;
			if(tmp != null)
				tmp(this, EventArgs.Empty);
		}
	}
}

