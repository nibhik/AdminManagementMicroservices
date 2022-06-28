using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AdminManagement.Domain.Entities;

namespace AdminManagement.Domain.Aggregates.AdminAggregate
{
    public class Admin : EntityBase,IAggregateRoot
    {
        public virtual string FirstName { get; private set; }
        public virtual string LastName { get; private set; }
        public virtual string HospitalName { get; private set; }
        public virtual string Gender { get; private set; }
        public virtual int Age { get; private set; }
        public virtual string PhoneNumber { get; private set; }
        public virtual string Address { get; private set; }
        public virtual DateTime DateOfBirth { get; private set; }
        public virtual string Email { get; private set; }
        public virtual string UserName { get; private set; }

        public virtual IList<Department> DepartmentNames { get; set; } = new List<Department>();

        public Admin(string firstName, string lastName, string hospitalName, string gender, int age, string phoneNumber, string address, DateTime dateOfBirth, string email, string UserName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.HospitalName = hospitalName;
            this.Gender = gender;
            this.Age = age;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.DateOfBirth = dateOfBirth;
            this.Email = email;
            this.UserName = UserName;
        }

        protected Admin() { }

        public void ChangeEmail(string newEmail)
        {
            if (string.IsNullOrEmpty(newEmail) || !newEmail.Contains("@"))
                throw new ArgumentException("Invalid email");
            if (this.Email == newEmail)
                return;
            this.Email = newEmail;
        }

        public void ChangePhoneNumber(string newPhoneNumber)
        {
            if (string.IsNullOrEmpty(newPhoneNumber) || !(newPhoneNumber.Length == 10))
                throw new ArgumentException("Invalid newPhoneNumber");

            if (this.PhoneNumber == newPhoneNumber)
                return;
            this.PhoneNumber = newPhoneNumber;
        }

        public void ChangeAddress(string newAddress)
        {
            if (string.IsNullOrEmpty(newAddress))
                throw new ArgumentException("Invalid address");
            if (this.Address == newAddress)
                return;
            this.Address = newAddress;
        }

        public void AddDepartment(Department newDepartment)
        {
            this.DepartmentNames.Add(newDepartment);
        }

     /*   public void RemoveDepartment(int DepartmentId)
        {
            var department = DepartmentNames.First(d => d.Id = DepartmentId);
            this.DepartmentNames.Remove(department);
                
        }*/



    }
}
