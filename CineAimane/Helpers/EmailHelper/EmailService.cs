using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CineAimane.Helpers.EmailSenderHelper
{
	public class EmailService : IEmailService
	{
		private readonly EmailConfiguration _emailConfiguration;
		public EmailService(IOptions<EmailConfiguration> emailConfiguration)
		{
			_emailConfiguration = emailConfiguration.Value;
		}
		public async Task Send(EmailModel emailModel)
		{
			MailMessage mailMessage = new()
			{
				Subject = emailModel.Subject,
				Body = emailModel.Content,
				From = new MailAddress(_emailConfiguration.SenderEmail, _emailConfiguration.SenderName),
				IsBodyHtml = true,
				BodyEncoding = Encoding.Default,
			};
			foreach (var to in emailModel.To)
			{
				mailMessage.To.Add(to);
			}
			NetworkCredential networkCredential = new(_emailConfiguration.Username, _emailConfiguration.Password);
			SmtpClient smtpClient = new()
			{
				Host = _emailConfiguration.Host,
				Port = _emailConfiguration.Port,
				EnableSsl = _emailConfiguration.EnableSSL,
				Credentials = networkCredential,
			};
			await smtpClient.SendMailAsync(mailMessage);
		}
	}
}
