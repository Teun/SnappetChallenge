// <copyright file="EmailService.cs" company="Pangom Soft">
// Copyright (c) Pangom Soft. All rights reserved.
// </copyright>

namespace Nicollas.Services.Identity
{
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using Nicollas.Core.Services;

    /// <summary>
    /// This class implements the <see cref="IIdentityMessageService"/>
    /// </summary>
    public class EmailService : IEmailService
    {
        private NetworkCredential smtpCredentials;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailService"/> class.
        /// </summary>
        private EmailService()
        {
        }

        /// <summary>
        /// Gets the Smtp Rost
        /// </summary>
        public string SmtpRost { get; private set; }

        /// <summary>
        /// Gets the Smtp port
        /// </summary>
        public int SmtpPort { get; private set; }

        /// <summary>
        /// Gets the Mail address
        /// </summary>
        public string MailAddress { get; private set; }

        /// <summary>
        /// Gets the Mail display name
        /// </summary>
        public string MailDisplayName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailService"/> class.
        /// </summary>
        /// <param name="configuration">dynamic configuration settings</param>
        /// <returns>the <see cref="EmailService"/> configured</returns>
        public static EmailService Create(dynamic configuration)
        {
            return new EmailService()
            {
                SmtpRost = configuration["SmtpRost"],
                SmtpPort = int.Parse(configuration["SmtpPort"]),
                MailAddress = configuration["MailAddress"],
                MailDisplayName = configuration["MailDisplayName"],
                smtpCredentials = new NetworkCredential(configuration["MailAccount"], configuration["MailPassword"])
            };
        }

        /// <inheritdoc/>
        public async Task SendAsync(string destinationGroup, string subject, string body)
        {
            SmtpClient client = new SmtpClient(this.SmtpRost, this.SmtpPort)
            {
                Credentials = this.smtpCredentials,
                EnableSsl = true
            };
            MailMessage mailMessage = new MailMessage()
            {
                From = new MailAddress(this.MailAddress, this.MailDisplayName)
            };
            mailMessage.To.Add(destinationGroup);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            await client.SendMailAsync(mailMessage);
        }

        /// <inheritdoc/>
        public void SendAway(string destinationGroup, string subject, string body)
        {
            Task.Run(() =>
            {
                SmtpClient client = new SmtpClient(this.SmtpRost, this.SmtpPort)
                {
                    Credentials = this.smtpCredentials,
                    EnableSsl = true
                };
                MailMessage mailMessage = new MailMessage()
                {
                    From = new MailAddress(this.MailAddress, this.MailDisplayName)
                };
                mailMessage.To.Add(destinationGroup);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                client.Send(mailMessage);
            });            
        }
    }
}
