using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Domain.Entities
{
    public class Producer
    {
        public int Id { get; set; }
        public string? AppUserId { get; set; }
        public string? Name { get; set; }
        public ICollection<Event>? Events { get; set; }  

    }
}
