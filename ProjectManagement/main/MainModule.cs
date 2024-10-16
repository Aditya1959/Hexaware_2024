using ProjectManagementApp.dao;
using ProjectManagementApp.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = ProjectManagementApp.entity.Task;

namespace ProjectManagementApp.main
{
    namespace ProjectManagementApp.main
    {
        public class MainModule
        {
            static void Main(string[] args)
            {
                IProjectRepository projectRepo = new ProjectRepositoryImpl();

                while (true)
                {
                    Console.WriteLine("1. Add Employee\n2. Add Project\n3. Add Task\n4. Assign Project to Employee\n5. Assign Task to Employee\n6. Delete Employee\n7. Delete Project\n8. Get All Tasks\nEnter your choice:");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddEmployee(projectRepo);
                            break;
                        case 2:
                            AddProject(projectRepo);
                            break;
                        case 3:
                            AddTask(projectRepo);
                            break;
                        case 4:
                            AssignProjectToEmployee(projectRepo);
                            break;
                        case 5:
                            AssignTaskToEmployee(projectRepo);
                            break;
                        case 6:
                            DeleteEmployee(projectRepo);
                            break;
                        case 7:
                            DeleteProject(projectRepo);
                            break;
                        case 8:
                            GetAllTasks(projectRepo);
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }

            private static void AddEmployee(IProjectRepository projectRepo)
            {
                Console.WriteLine("Enter Employee Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Employee Designation:");
                string designation = Console.ReadLine();
                Console.WriteLine("Enter Employee Gender (M/F):");
                string gender = Console.ReadLine();
                Console.WriteLine("Enter Employee Salary:");
                decimal salary = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter Project ID the employee is assigned to:");
                int projectId = Convert.ToInt32(Console.ReadLine());

                Employee emp = new Employee
                {
                    Name = name,
                    Designation = designation,
                    Gender = gender,
                    Salary = salary,
                    ProjectId = projectId
                };

                bool success = projectRepo.CreateEmployee(emp);
                Console.WriteLine(success ? "Employee added successfully." : "Failed to add employee.");
            }

            private static void AddProject(IProjectRepository projectRepo)
            {
                Console.WriteLine("Enter Project Name:");
                string projectName = Console.ReadLine();
                Console.WriteLine("Enter Project Description:");
                string description = Console.ReadLine();
                Console.WriteLine("Enter Project Start Date (YYYY-MM-DD):");
                DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter Project Status:");
                string status = Console.ReadLine();

                Project project = new Project
                {
                    ProjectName = projectName,
                    Description = description,
                    StartDate = startDate,
                    Status = status
                };

                bool success = projectRepo.CreateProject(project);
                Console.WriteLine(success ? "Project added successfully." : "Failed to add project.");
            }

            private static void AddTask(IProjectRepository projectRepo)
            {
                Console.WriteLine("Enter Task Name:");
                string taskName = Console.ReadLine();
                Console.WriteLine("Enter Project ID associated with the task:");
                int projectId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee ID assigned to this task:");
                int employeeId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Task Status:");
                string status = Console.ReadLine();

                Task task = new Task
                {
                    TaskName = taskName,
                    ProjectId = projectId,
                    EmployeeId = employeeId,
                    Status = status
                };

                bool success = projectRepo.CreateTask(task);
                Console.WriteLine(success ? "Task added successfully." : "Failed to add task.");
            }

            private static void AssignProjectToEmployee(IProjectRepository projectRepo)
            {
                Console.WriteLine("Enter Project ID to assign:");
                int projectId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee ID to assign the project to:");
                int employeeId = Convert.ToInt32(Console.ReadLine());

                bool success = projectRepo.AssignProjectToEmployee(projectId, employeeId);
                Console.WriteLine(success ? "Project assigned to employee." : "Failed to assign project.");
            }

            private static void AssignTaskToEmployee(IProjectRepository projectRepo)
            {
                Console.WriteLine("Enter Task ID to assign:");
                int taskId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Project ID the task is associated with:");
                int projectId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee ID to assign the task to:");
                int employeeId = Convert.ToInt32(Console.ReadLine());

                bool success = projectRepo.AssignTaskInProjectToEmployee(taskId, projectId, employeeId);
                Console.WriteLine(success ? "Task assigned to employee." : "Failed to assign task.");
            }

            private static void DeleteEmployee(IProjectRepository projectRepo)
            {
                Console.WriteLine("Enter Employee ID to delete:");
                int employeeId = Convert.ToInt32(Console.ReadLine());
                bool success = projectRepo.DeleteEmployee(employeeId);
                Console.WriteLine(success ? "Employee deleted." : "Failed to delete employee.");
            }

            private static void DeleteProject(IProjectRepository projectRepo)
            {
                Console.WriteLine("Enter Project ID to delete:");
                int projectId = Convert.ToInt32(Console.ReadLine());
                bool success = projectRepo.DeleteProject(projectId);
                Console.WriteLine(success ? "Project deleted." : "Failed to delete project.");
            }

            private static void GetAllTasks(IProjectRepository projectRepo)
            {
                Console.WriteLine("Enter Employee ID:");
                int employeeId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Project ID:");
                int projectId = Convert.ToInt32(Console.ReadLine());

                var tasks = projectRepo.GetAllTasks(employeeId, projectId);
                foreach (var task in tasks)
                {
                    Console.WriteLine($"{task.TaskId}: {task.TaskName}, Status: {task.Status}");
                }
            }
        }
    }
}
