namespace CineAimane.Helpers.EmailSenderHelper
{
	public interface IEmailService
	{
		Task Send(EmailModel message);
	}
}