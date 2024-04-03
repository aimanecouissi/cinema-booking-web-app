namespace CineAimane.Helpers.EmailSenderHelper
{
	public class EmailConfiguration
	{
		public string SenderEmail { get; set; } = string.Empty;
		public string SenderName { get; set; } = string.Empty;
		public string Username { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string Host { get; set; } = string.Empty;
		public int Port { get; set; }
		public bool EnableSSL { get; set; }
	}
}
