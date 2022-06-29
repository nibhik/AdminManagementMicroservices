using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminManagement.API.DTOs
{
    public class AdminDTO
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(30)]
        public virtual string FirstName { get; private set; }
        public virtual string LastName { get; private set; }
        public virtual string HospitalName { get; private set; }
        public virtual string Gender { get; private set; }
        public virtual int Age { get; private set; }
        public virtual string PhoneNumber { get; private set; }
        public virtual string Address { get; private set; }
        public virtual DateTime DateOfBirth { get; private set; }
        public virtual string Email { get; private set; }
    }
}
