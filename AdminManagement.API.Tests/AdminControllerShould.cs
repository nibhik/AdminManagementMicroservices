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
        [Test]

        public async Task Return_201StatusCode()
        {
            var dto = new DepartmentDTO()
            {
                Consultant = "Dr.Jony",
                DepartmentName = "Gyno"

            };

            var repo = new Mock<IRepository<Department>>();
            repo.Setup(m => m.SaveAsync()).ReturnsAsync(1);
            var repoObj = repo.Object;

            var controller = new AdminController(repoObj);

            var result = (IStatusCodeActionResult)await controller.AddDepartment(dto).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(201));
            Assert.IsNotNull(result);
        }

        

   /*     public async Task UpdateDepartment_Return200StatusCode()
        {
            var appointment = new DepartmentDTO()
            {
                Id = 1,
                Consultant = "Dr.Jony",
                DepartmentName = "Orthology",
                
            };
            var rep = new Mock<IRepository<Department>>();
            rep.Setup(m => m.SaveAsync()).ReturnsAsync(1);
            var reObj = rep.Object;
            var controller = new AdminController(reObj);
            var result = (IStatusCodeActionResult)await controller.UpdateDepartment(1).ConfigureAwait(false);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(result);

        }  */



    }
}
