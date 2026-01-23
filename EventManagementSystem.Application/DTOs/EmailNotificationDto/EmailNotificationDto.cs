using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Application.DTOs.EmailNotificationDto
{
    public class EmailNotificationDto
    {
        public string? To { get; set; } 
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
