using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CineAimane.ViewModels
{
	public class AdminAccountViewModel
	{
		[ValidateNever]
		public string Username { get; set; }
		[ValidateNever]
		public string Email { get; set; }
		[Required]
		[DisplayName("Current Password")]
		[DataType(DataType.Password)]
		public string CurrentPassword { get; set; }
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		[Required]
		[DisplayName("New Password")]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }
		[Compare("NewPassword")]
		[DisplayName("Confirm New Password")]
		[DataType(DataType.Password)]
		public string ConfirmNewPassword { get; set; }
	}
}
