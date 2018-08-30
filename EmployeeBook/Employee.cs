using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBook
{
    /// <summary>
    /// This is the blueprint for an employee
    /// </summary>
    public class Employee
    {
        private const string TEXT_FILE_NAME = "EmployeeTextFile.txt";
        /// <summary>
        /// Holds the name of the employee
        /// </summary>
        public string Name { get; set; }

        public string Title { get; set; }

        public async static Task<ICollection<Employee>> GetEmployees()
        {
            var employees = new List<Employee>();
            var fileContent = await FileHelper.ReadTextFileAsync(TEXT_FILE_NAME);
            var lines = fileContent.Split(new char[] { '\r', '\n' });
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                var lineParts = line.Split(',');
                var employee = new Employee
                {
                    Name = lineParts[0],
                    Title = lineParts[1]
                };
                employees.Add(employee);
            }
            return employees;
        }

        /// <summary>
        /// Write employee to file
        /// </summary>
        /// <param name="employee">The employee object to write</param>
        public static void WriteEmployee(Employee employee)
        {
            var employeeData = $"{employee.Name},{employee.Title}";
            FileHelper.WriteTextFileAsync(TEXT_FILE_NAME, employeeData);

        }
    }
}
