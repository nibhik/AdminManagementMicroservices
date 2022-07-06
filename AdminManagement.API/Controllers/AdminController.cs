using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminManagement.Domain.Aggregates.AdminAggregate;
using AdminManagement.Domain.Interfaces;
using AdminManagement.API.DTOs;


namespace AdminManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRepository<Department> departmentRepository;

       //private readonly IRepository<Admin> adminRepository;
        public AdminController(IRepository<Department> departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

     /* public AdminController(IRepository<Admin> adminRepository)
        {
            this.adminRepository = adminRepository;
        }*/

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddDepartment(DepartmentDTO departmentdto)
        {
            var dept = new Department(departmentdto.DepartmentName, departmentdto.Consultant, departmentdto.Category);
            departmentRepository.Add(dept);
            await departmentRepository.SaveAsync();
            return StatusCode(201, dept);
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateDepartment(int Id)
        {
            var depat = departmentRepository.GetById(Id);
            if (depat == null)
                return NotFound();

            //departmentRepository.ChangeConsultant(newConsultant);
            departmentRepository.Update(depat);
            await departmentRepository.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteDepartment(int Id)
        {
            var department = departmentRepository.GetById(Id);
            if (department == null)
                return NotFound();
            departmentRepository.Remove(department);
            await departmentRepository.SaveAsync();
            return StatusCode(204);
        }



    }
}
