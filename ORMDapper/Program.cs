using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORMDapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            

            IDbConnection conn = new MySqlConnection(connString);

            var departmentrepo = new DapperDepartmentRepository(conn);
            departmentrepo.InsertDepartment("Department 88");

            var departments = departmentrepo.GetAllDepartments();
            foreach (var department in departments)
            {
                Console.WriteLine(department.DepartmentId);
                Console.WriteLine(department.Name);
                Console.WriteLine();
            }

            
        }
    }
}