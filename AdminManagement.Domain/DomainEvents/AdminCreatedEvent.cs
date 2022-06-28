using System;
using System.Collections.Generic;
using System.Text;

namespace AdminManagement.Domain.DomainEvents
{
    public class AdminCreatedEvent :EventBase
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
