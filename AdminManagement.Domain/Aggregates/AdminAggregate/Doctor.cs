using System;
using System.Collections.Generic;
using System.Text;
using AdminManagement.Domain.Entities;

namespace AdminManagement.Domain.Aggregates.AdminAggregate
{
    public class Doctor : EntityBase, IAggregateRoot
    {
        //public virtual int DoctorId { get; private set; }
        public virtual string FullName { get; private set; }
        public virtual string Education { get; private set; }
        public virtual string Specialization { get; private set; }

        public Doctor(int doctorId, string fullName, string education, string specialization)
        {
            //this.DoctorId = doctorId;
            this.FullName = fullName;
            this.Education = education;
            this.Specialization = specialization;
        }

        protected Doctor() { }
    }
}
