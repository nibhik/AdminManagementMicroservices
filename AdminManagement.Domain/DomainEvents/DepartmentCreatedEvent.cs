using System;
using System.Collections.Generic;
using System.Text;

namespace AdminManagement.Domain.DomainEvents
{
    public class DepartmentCreatedEvent
    {
        public string Consultant { get; set; }
        public string DepartmentName { get; set; }
        public string Category { get; set; }
    }
}
