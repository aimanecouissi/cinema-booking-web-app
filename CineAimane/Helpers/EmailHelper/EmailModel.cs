namespace CineAimane.Helpers.EmailSenderHelper
{
	public class EmailModel
	{
		public List<string> To { get; set; } = new List<string>();
		public string Subject { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
	}
}
