using EventManagementSystem.Application.DTOs.EmailNotificationDto;
using EventManagementSystem.Application.Interfaces.Email;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EventManagementSystem.Infrastructure.Services.EmailNotification
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public SmtpEmailSender(IConfiguration config)
        {
           _config = config;
        }

        public async Task SendMailAsync(EmailNotificationDto notification)
        {
            try
            {
                var host = _config["Email:SmtpHost"];
                var port = int.Parse(_config["Email:SmtpPort"]);
                var username = _config["Email:SmtpUser"];
                var password = _config["Email:SmtpPass"];


                using var client = new SmtpClient(host, port)
                {
                    Credentials = new NetworkCredential(username, password),
                    EnableSsl = true
                };

                var mail = new MailMessage(username, notification.To)
                {
                    Subject = notification.Subject,
                    Body = notification.Body,
                    IsBodyHtml = true
                };

                await client.SendMailAsync(mail);
            }
            catch( Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }
    }
}
