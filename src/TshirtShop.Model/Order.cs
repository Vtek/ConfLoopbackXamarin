using System;

namespace TshirtShop.Model
{
	/// <summary>
	/// Order.
	/// </summary>
	public class Order
	{
		/// <summary>
		/// Gets or sets the client identifier.
		/// </summary>
		/// <value>The client identifier.</value>
		public string ClientId { get; set; }

		/// <summary>
		/// Gets or sets the product identifier.
		/// </summary>
		/// <value>The product identifier.</value>
		public string ProductId { get; set; }

		/// <summary>
		/// Gets or sets the order date.
		/// </summary>
		/// <value>The order date.</value>
		public DateTime OrderDate { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is men.
		/// </summary>
		/// <value><c>true</c> if this instance is men; otherwise, <c>false</c>.</value>
		public bool IsMen { get; set; }

		/// <summary>
		/// Gets or sets the size.
		/// </summary>
		/// <value>The size.</value>
		public string Size { get; set; }
	}
}

