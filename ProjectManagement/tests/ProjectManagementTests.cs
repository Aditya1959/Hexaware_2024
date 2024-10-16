using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using ProjectManagementApp.dao;
using ProjectManagementApp.entity;
using ProjectManagementApp.exception;
using Task = ProjectManagementApp.entity.Task;

namespace ProjectManagementApp.tests
{
    public class ProjectManagementTests
    {
        private IProjectRepository projectRepo;

        [SetUp]
        public void Setup()
        {
            projectRepo = new ProjectRepositoryImpl();  // Ensure this class is correctly implemented
        }

        [Test]
        public void TestEmployeeCreation()
        {
            Employee emp = new Employee(1, "John Doe", "Developer", "Male", 60000, 1);
            Assert.That(projectRepo.CreateEmployee(emp), Is.True);
        }

        [Test]
        public void TestTaskCreation()
        {
            Task task = new Task(1, "Build Module", 1, 1, "Assigned");
            Assert.That(projectRepo.CreateTask(task), Is.True);
        }

        [Test]
        public void TestGetAllTasks()
        {
            var tasks = projectRepo.GetAllTasks(1, 1);
            Assert.That(tasks, Is.Not.Null);
        }

        [Test]
        public void TestEmployeeNotFoundException()
        {
            Assert.Throws<EmployeeNotFoundException>(() => projectRepo.DeleteEmployee(999));
        }

        [Test]
        public void TestProjectNotFoundException()
        {
            Assert.Throws<ProjectNotFoundException>(() => projectRepo.DeleteProject(999));
        }
    }
}
