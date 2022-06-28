using System;
using System.Collections.Generic;
using System.Text;
using AdminManagement.Domain.Aggregates;
using AdminManagement.Domain.Entities;

namespace AdminManagement.Domain.Aggregates.AdminAggregate
{
    public class Patient : EntityBase, IAggregateRoot
    {
        public virtual int PatientId { get; private set; }
        public virtual int DoctorId { get; private set; }

        public virtual string Diagnosis { get; private set; }
        public virtual string Treatment { get; private set; }
        public virtual string Prescription { get; private set; }
        public virtual string Problem { get; private set; }

        public Patient(int patientId, int doctorId, string diagnosis, string treatment, string prescription, string problem)
        {
            this.PatientId = patientId;
            this.DoctorId = doctorId;
            this.Diagnosis = diagnosis;
            this.Treatment = treatment;
            this.Prescription = prescription;
            this.Problem = problem;
        }

        protected Patient() { }


    }
}
