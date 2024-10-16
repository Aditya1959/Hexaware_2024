using ProjectManagementApp.entity;
using ProjectManagementApp.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Task = ProjectManagementApp.entity.Task;
namespace ProjectManagementApp.dao
{
    public class ProjectRepositoryImpl : IProjectRepository
    {
        private SqlConnection connection;

        public ProjectRepositoryImpl()
        {
            connection = DBConnUtil.GetConnection();
        }

        public bool CreateEmployee(Employee emp)
        {
            string query = "INSERT INTO Employee (Name, Designation, Gender, Salary, ProjectId) VALUES (@Name, @Designation, @Gender, @Salary, @ProjectId)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Designation", emp.Designation);
            cmd.Parameters.AddWithValue("@Gender", emp.Gender);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            cmd.Parameters.AddWithValue("@ProjectId", emp.ProjectId);
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        public bool CreateProject(Project pj)
        {
            string query = "INSERT INTO Project (ProjectName, Description, StartDate, Status) VALUES (@ProjectName, @Description, @StartDate, @Status)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ProjectName", pj.ProjectName);
            cmd.Parameters.AddWithValue("@Description", pj.Description);
            cmd.Parameters.AddWithValue("@StartDate", pj.StartDate);
            cmd.Parameters.AddWithValue("@Status", pj.Status);
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        public bool CreateTask(Task task)
        {
            string query = "INSERT INTO Task (TaskName, ProjectId, EmployeeId, Status) VALUES (@TaskName, @ProjectId, @EmployeeId, @Status)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TaskName", task.TaskName);
            cmd.Parameters.AddWithValue("@ProjectId", task.ProjectId);
            cmd.Parameters.AddWithValue("@EmployeeId", task.EmployeeId);
            cmd.Parameters.AddWithValue("@Status", task.Status);
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        public bool AssignProjectToEmployee(int projectId, int employeeId)
        {
            string query = "UPDATE Employee SET ProjectId = @ProjectId WHERE Id = @EmployeeId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ProjectId", projectId);
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        public bool AssignTaskInProjectToEmployee(int taskId, int projectId, int employeeId)
        {
            string query = "UPDATE Task SET EmployeeId = @EmployeeId WHERE TaskId = @TaskId AND ProjectId = @ProjectId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TaskId", taskId);
            cmd.Parameters.AddWithValue("@ProjectId", projectId);
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        public bool DeleteEmployee(int employeeId)
        {
            string query = "DELETE FROM Employee WHERE Id = @EmployeeId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        public bool DeleteProject(int projectId)
        {
            string query = "DELETE FROM Project WHERE Id = @ProjectId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ProjectId", projectId);
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        public List<Task> GetAllTasks(int employeeId, int projectId)
        {
            string query = "SELECT * FROM Task WHERE EmployeeId = @EmployeeId AND ProjectId = @ProjectId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
            cmd.Parameters.AddWithValue("@ProjectId", projectId);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Task> tasks = new List<Task>();
            while (reader.Read())
            {
                Task task = new Task
                {
                    TaskId = Convert.ToInt32(reader["TaskId"]),
                    TaskName = reader["TaskName"].ToString(),
                    ProjectId = Convert.ToInt32(reader["ProjectId"]),
                    EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                    Status = reader["Status"].ToString()
                };
                tasks.Add(task);
            }
            reader.Close();
            return tasks;
        }
    }
}
