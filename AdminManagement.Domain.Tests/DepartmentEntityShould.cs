using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using AdminManagement.Domain;
using AdminManagement.Domain.Aggregates;
using AdminManagement.Domain.Aggregates.AdminAggregate;
using AdminManagement.Domain.Entities;

namespace AdminManagement.Domain.Tests
{
    [TestFixture]
    public class DepartmentEntityShould
    {
        [Test]
        public void CreateNew_Department_VieConstructor()
        {
            //Arrange
            string consultant = "Dr. John";
            string departmentName = " Orthology";
            string category = "genral";



           //Act

            var department = new Department(consultant,  departmentName, category);

            //Assert
            Assert.That(department, Is.Not.Null);
            Assert.That(department, Is.InstanceOf<Department>());
            Assert.That(department.Consultant, Is.EqualTo(consultant));
            Assert.That(department.DepartmentName, Is.EqualTo(departmentName));
            Assert.That(department.Category, Is.EqualTo(category));
            
        }
    }
}
