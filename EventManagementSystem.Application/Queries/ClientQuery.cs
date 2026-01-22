using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Application.Queries
{
    public class ClientQuery
    {
        public string? Name { get; set; }
       public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
