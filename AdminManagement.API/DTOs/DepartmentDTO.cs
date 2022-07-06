using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminManagement.API.DTOs
{
    public class DepartmentDTO
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(30)]
        public  string Consultant { get;  set; }
        public string DepartmentName { get;  set; }
        public string Category { get; set; }

    }
}
