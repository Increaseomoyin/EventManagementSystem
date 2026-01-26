using EventManagementSystem.Application.Interfaces.Email;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Infrastructure.Services.EmailNotification
{
    public class EmailBackgroundService : BackgroundService
    {
        private readonly EmailNotificationQueue _queue;
        private readonly IEmailSender _emailSender;

        public EmailBackgroundService(EmailNotificationQueue queue, IEmailSender emailSender)
        {
            _queue = queue;
            _emailSender = emailSender;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var notification in _queue.Reader.ReadAllAsync(stoppingToken))
            {
                await _emailSender.SendMailAsync(notification);
            }
        }
    }
}
