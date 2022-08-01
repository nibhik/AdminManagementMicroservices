using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        //[AllowAnonymous]

        public async Task<IActionResult> AddDepartment(DepartmentDTO departmentdto)
        {
            try
            {
                var dept = new Department(departmentdto.DepartmentName, departmentdto.Consultant, departmentdto.Category);
                departmentRepository.Add(dept);
                await departmentRepository.SaveAsync();
                return StatusCode(201, dept);
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
           
        }

        [HttpGet]
        [ProducesResponseType(200, Type =  typeof(List<DepartmentDTO>))]
        [AllowAnonymous]
        public IActionResult GetDepartment()
        {
            try
            {
                var deaprtments = departmentRepository.Get();
                var dto = from department in deaprtments
                          select new DepartmentDTO
                          {
                              Id = department.Id,
                              Consultant = department.Consultant,
                              DepartmentName = department.DepartmentName,
                              Category = department.Category

                          };
                return Ok(dto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
            


        [HttpDelete("{Id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [Authorize(Roles = "Admin")]
        //[AllowAnonymous]
        public async Task<IActionResult> DeleteDepartment(int Id)
        {
            try
            {
                var department = departmentRepository.GetById(Id);
                if (department == null)
                    return NotFound();
                departmentRepository.Remove(department);
                await departmentRepository.SaveAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
           
        }
    }
}
