using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using AdminManagement.API;
using AdminManagement.API.DTOs;
using AdminManagement.API.Controllers;
using AdminManagement.Domain.Aggregates;
using AdminManagement.Domain.Entities;
using AdminManagement.Domain.Interfaces;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AdminManagement.Domain.Aggregates.AdminAggregate;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AdminManagement.API.Tests
{
    [TestFixture]
    public class AdminControllerShould
    {
      /*  
        [Test]
       
        public async Task Return_201StatusCode()
        {
            var dto = new DepartmentDTO()
            {
                Consultant = "Dr.Jony",
                DepartmentName = "Gyno",
                Category = "General"

            };

            var repo = new Mock<IRepository<Department>>();
            repo.Setup(m => m.SaveAsync()).ReturnsAsync(1);
            var repoObj = repo.Object;

            var controller = new AdminController(repoObj);

            var result = (IStatusCodeActionResult)await controller.AddDepartment(dto).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(201));
            Assert.IsNotNull(result);
        }
        
        [Test]
       // [TestCase(2)]

        public async Task AddDepartmentReturn_201StatusCode()
        {
            var dto = new DepartmentDTO()
            {
                Consultant = "Dr.Jojo",
                DepartmentName = "Gyno",
                Category = "Private"

            };

            var repo = new Mock<IRepository<Department>>();
            repo.Setup(m => m.SaveAsync()).ReturnsAsync(1);
            var repoObj = repo.Object;

            var controller = new AdminController(repoObj);

            var result = (IStatusCodeActionResult)await controller.AddDepartment(dto).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(201));
            Assert.IsNotNull(result);
        }


        [Test]

        public void GetDepartment_Return200StatusCode()
        {
            string consultant = "Dr.Jony";
             string departmentName = "Gyno";
             string category = "General";


            var repo = new Mock<IRepository<Department>>();
            repo.Setup(m => m.Get()).Returns(() =>
            {
                Department department = new Department(consultant, departmentName, category);
                return new List<Department>() { department };
            });

            var repoObj = repo.Object;

            var controller = new AdminController(repoObj);

            OkObjectResult result = (OkObjectResult)controller.GetDepartment();
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(result);
        }

        
        [Test]
        [TestCase(1)]
        public async Task DeleteDepartment_Return404StatusCode( int Id)
        {
            var deoartment = new DepartmentDTO()
            {
                Id = 1,
                Consultant = "Dr.Jony",
                DepartmentName = "Gyno",
                Category = "General"
            };

            var repo = new Mock<IRepository<Department>>();
            repo.Setup(m => m.SaveAsync()).ReturnsAsync(1);

            var repoObj = repo.Object;

            var controller = new AdminController(repoObj);

            var result = (IStatusCodeActionResult)await controller.DeleteDepartment(Id).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(404));
            Assert.IsNotNull(result);
        }
        
        
        [Test]
        //[TestCase(1)]
        public async Task DeleteDepartment_Return200StatusCode()
        {
            var deoartment = new DepartmentDTO()
            {
                Id = 1,
                Consultant = "Dr.Jony",
                DepartmentName = "Gyno",
                Category = "General"
            };

            var repo = new Mock<IRepository<Department>>();
            repo.Setup(m => m.SaveAsync()).ReturnsAsync(1);

            var repoObj = repo.Object;

            var controller = new AdminController(repoObj);

            var result = (IStatusCodeActionResult)await controller.DeleteDepartment(1).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(result);
        }
        
        */

    }
}
