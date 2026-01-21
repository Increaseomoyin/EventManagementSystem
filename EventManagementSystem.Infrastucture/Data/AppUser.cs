using EventManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Infrastructure.Data
{
    public class AppUser :IdentityUser
    {
        public Client? Client { get; set; }
        public Producer? Producer { get; set; }
    }
}
