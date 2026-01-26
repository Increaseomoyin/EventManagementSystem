using EventManagementSystem.Application.DTOs.EmailNotificationDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Application.Interfaces.Email
{
    public interface IEmailNotificationQueue
    {
        Task QueueAsync(EmailNotificationDto notification);
    }
}
