// <copyright file="MailService.cs" company="El Roso">
// Copyright (c) El Roso. All rights reserved.
// </copyright>

namespace MyMail.Services
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Reflection;
    using System.Text;
    using log4net;
    using MyMail.Domains.Requests;
    using MyMail.Domains.Responses;
    using MyMail.Domains.Services;

    public class MailService : IMailService
    {
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly SmtpClient client;
        private MailMessage mail;

        public MailService()
        {
            this.client = new SmtpClient()
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = Environment.GetEnvironmentVariable("SMTP_HOST"),
                Port = Convert.ToInt32(Environment.GetEnvironmentVariable("SMTP_PORT")),
                EnableSsl = Convert.ToBoolean(Environment.GetEnvironmentVariable("MAIL_SECURE")),
                Credentials = new NetworkCredential(Environment.GetEnvironmentVariable("MAIL_USERNAME"), Environment.GetEnvironmentVariable("MAIL_PASSWORD")),
            };
        }

        public ModelResponse Send(MailSendRequest request)
        {
            try
            {
                StringBuilder body = new StringBuilder();
                body.Append(this.GetMailFormat());
                body.Replace("(-title-)", request.Notification.Subject);
                body.Replace("(-body-)", request.Notification.Body);

                this.mail = new MailMessage()
                {
                    From = new MailAddress(Environment.GetEnvironmentVariable("MAIL_FROM")),
                    Subject = request.Notification.Subject,
                    Body = body.ToString(),
                    IsBodyHtml = true,
                };

                request.Recipients.ToList().ForEach(x => this.mail.To.Add(new MailAddress(x.EmailAddress, $"{x.LastName} {x.FirstName}")));

                request.Notification.Attachments?.ToList().ForEach(x => this.mail.Attachments.Add(new Attachment(x.OpenReadStream(), x.FileName)));

                this.client.Send(this.mail);

                var response = new ModelResponse { Status = true, Menssage = $"Email Sent Successfully!" };

                this.logger.Info(response);
                return response;
            }
            catch (Exception e)
            {
                var response = new ModelResponse { Status = false, Menssage = e.Message };

                this.logger.Info(response);
                return response;
            }
        }

        private string GetMailFormat()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"MyMail.Services.MailFormat.html";

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
