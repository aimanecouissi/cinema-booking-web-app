using System.ComponentModel.DataAnnotations;

namespace CineAimane.ViewModels
{
	public class CheckoutViewModel
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		//[Required]
		//[EmailAddress]
		//public string Email { get; set; }
	}
}
