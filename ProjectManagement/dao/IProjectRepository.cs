using ProjectManagementApp.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = ProjectManagementApp.entity.Task;

namespace ProjectManagementApp.dao
{
    public interface IProjectRepository
    {
        bool CreateEmployee(Employee emp);
        bool CreateProject(Project pj);
        bool CreateTask(Task task);
        bool AssignProjectToEmployee(int projectId, int employeeId);
        bool AssignTaskInProjectToEmployee(int taskId, int projectId, int employeeId);
        bool DeleteEmployee(int employeeId);
        bool DeleteProject(int projectId);
        List<Task> GetAllTasks(int employeeId, int projectId);
    }
}
