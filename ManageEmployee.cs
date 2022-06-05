using DapperTutorial.Core.Entities;
using DapperTutorial.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperTutorial.Presentation.Menus;

namespace DapperTutorial.Presentation.UI
{
    public class ManageEmployee
    {
        //EmployeeRepository employeeRepository = new EmployeeRepository();
        EmployeeRepository employeeRepository;
        public ManageEmployee()
        {
            employeeRepository = new EmployeeRepository();
        }

        private void AddEmployee()
        {
            Employee e = new Employee();
            Console.Write("Enter First Name: ");
            e.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            e.LastName = Console.ReadLine();
            Console.Write("Enter Salary ==>");
            e.Salary = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Department Id: ");
            e.DeptId = Convert.ToInt32(Console.ReadLine());

            //employeeRepository.Insert(e);
            if (employeeRepository.Insert(e) > 0)
            {
                Console.WriteLine("Successfully Inserted");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        private void GetAllEmployees()
        {
            IEnumerable<Employee> employees = employeeRepository.GetAll();
            foreach(var item in employees)
            {
                Console.WriteLine($"{item.Id} \t {item.FirstName} \t{item.LastName} \t {item.Salary} \t {item.Dept.DName}");
            }
        }

        private void UpdateEmployees()
        {
            Employee e = new Employee();
            Console.Write("Enter FirstName of Employee: ");
            e.FirstName = Console.ReadLine();
            Console.Write("Enter LastName of Employee: ");
            e.LastName = Console.ReadLine();
            Console.Write("Enter Employee Salary: ");
            e.LastName = Console.ReadLine();
            Console.Write("Enter Employee Department Name: ");
            e.LastName = Console.ReadLine();

            if (employeeRepository.Update(e) > 0)
            {
                Console.WriteLine("Successfully Inserted\n");
            }
            else
            {
                Console.WriteLine("Error\n");
            }
        }
        private void DeleteEmployee()
        {
            Console.Write("Enter Id Number to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            employeeRepository.DeleteById(id);
            Console.WriteLine("Successfully delete\n");
        }

        public void Run()
        {
            bool loopContinue = true;
            do
            {
                Console.WriteLine("Select following options.");
                Console.WriteLine("select 1 to add new Employee, 2 to update a Employee, 3 to delete a Employee, 4 to read all Employees, 5 to exit.\n");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case (int)OptionsEmp.Add:
                        AddEmployee();
                        loopContinue = true;
                        break;
                    case (int)OptionsEmp.Update:
                        UpdateEmployees();
                        loopContinue = true;
                        break;
                    case (int)OptionsEmp.Delete:
                        DeleteEmployee();
                        loopContinue = true;
                        break;
                    case (int)OptionsEmp.Read:
                        GetAllEmployees();
                        loopContinue = true;
                        break;
                    case (int)OptionsEmp.Exit:
                        loopContinue = false;
                        break;
                }
            } while (loopContinue);
        }
    }
}
