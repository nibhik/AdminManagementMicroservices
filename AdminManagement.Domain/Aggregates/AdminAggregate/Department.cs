using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AdminManagement.Domain.Entities;
using AdminManagement.Domain.DomainEvents;

namespace AdminManagement.Domain.Aggregates.AdminAggregate
{
    public class Department:EntityBase, IAggregateRoot
    {
       // public virtual int DepartmentId { get; private set; }
        public virtual string Consultant { get; private set; }
        public virtual string DepartmentName { get; private set; }
       // public virtual string Category { get; private set; }

        public Department(string consultant, string departmentname)
        {
            //this.DepartmentId = departmentId;
            this.Consultant = consultant;
            this.DepartmentName = departmentname;
           // this.Category = category;

            var deaprtmentadded = new DepartmentCreatedEvent()
            {
                Consultant = this.Consultant,
                DepartmentName = this.DepartmentName,
                //Category = this.Category
            };
            //base.DomainEvents.Add(deaprtmentadded);
        }
        protected Department() { }
        public void ChangeConsultant(string newConsultant)
        {
            if (string.IsNullOrEmpty(newConsultant))
                throw new ArgumentException("Invalid name");
            if (this.Consultant == newConsultant)
                return;
            this.Consultant = newConsultant;
        }

       


    }
}
