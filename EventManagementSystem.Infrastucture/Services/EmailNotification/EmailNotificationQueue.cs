using EventManagementSystem.Application.DTOs.EmailNotificationDto;
using EventManagementSystem.Application.Interfaces.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace EventManagementSystem.Infrastructure.Services.EmailNotification
{
    public class EmailNotificationQueue : IEmailNotificationQueue
    {
        private readonly Channel<EmailNotificationDto> _channel;
        public EmailNotificationQueue()
        {
            _channel = Channel.CreateUnbounded<EmailNotificationDto>();
        }

        public async Task QueueAsync(EmailNotificationDto notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }
            await _channel.Writer.WriteAsync(notification);


        }

        // This will be used ONLY by the BackgroundService
        public ChannelReader<EmailNotificationDto> Reader => _channel.Reader;
    }
}
