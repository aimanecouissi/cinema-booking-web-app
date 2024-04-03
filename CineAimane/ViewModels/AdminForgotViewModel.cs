using System.ComponentModel.DataAnnotations;

namespace CineAimane.ViewModels
{
	public class AdminForgotViewModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}
