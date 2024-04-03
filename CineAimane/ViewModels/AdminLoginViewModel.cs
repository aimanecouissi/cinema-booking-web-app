using System.ComponentModel.DataAnnotations;

namespace CineAimane.ViewModels
{
	public class AdminLoginViewModel
	{
		[Required]
		public string Username { get; set; }
		[DataType(DataType.Password)]
		[Required]
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}
