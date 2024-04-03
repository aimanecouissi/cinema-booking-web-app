using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CineAimane.ViewModels
{
	public class AdminResetViewModel
	{
		[MinLength(6, ErrorMessage = "The {0} must be at least {1} characters long.")]
		[Required]
		[DisplayName("New Password")]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }
		[Compare("NewPassword")]
		[DisplayName("Confirm New Password")]
		[DataType(DataType.Password)]
		public string ConfirmNewPassword { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		public string Token { get; set; }
	}
}
