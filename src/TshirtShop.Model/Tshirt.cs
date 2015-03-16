namespace TshirtShop.Model
{
	/// <summary>
	/// T shirt.
	/// </summary>
	public sealed class Tshirt
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the reference.
		/// </summary>
		/// <value>The reference.</value>
		public string Reference { get; set; }

		/// <summary>
		/// Gets or sets the image file.
		/// </summary>
		/// <value>The image file.</value>
		public string ImageUrl { get; set; }
	}
}

