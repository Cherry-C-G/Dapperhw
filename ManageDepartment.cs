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
    public class ManageDepartment
    {
        DepartmentRepository departmentRepository;
        public ManageDepartment()
        {
            departmentRepository = new DepartmentRepository();
        }

        private void AddDepartment()
        {
            Department d = new Department();
            Console.Write("Enter Name of Department: ");
            d.DName = Console.ReadLine();
            Console.Write("Enter Location: ");
            d.Loc = Console.ReadLine();

            if (departmentRepository.Insert(d) > 0)
            {
                Console.WriteLine("Successfully Inserted");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        private void UpdateDepartment()
        {
            Department d = new Department();
            Console.Write("Enter Name of Department: ");
            d.DName = Console.ReadLine();
            Console.Write("Enter Location: ");
            d.Loc = Console.ReadLine();

            if (departmentRepository.Update(d) > 0)
            {
                Console.WriteLine("Successfully Inserted\n");
            }
            else
            {
                Console.WriteLine("Error\n");
            }
        }
        private void DeleteDepartment()
        {
            Console.Write("Enter Id Number to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            departmentRepository.DeleteById(id);
            Console.WriteLine("Successfully delete\n");
        }
        private void ReadAllDepartments()
        {
            IEnumerable<Department> departments = departmentRepository.GetAll();
            foreach (var item in departments)
            {
                Console.WriteLine($"{item.Id} \t {item.DName} \t {item.Loc}");
            }
        }

        public void Run()
        {

            //Do While loop here that uses Enums and Switches to continously ask for operation till exit
            bool loopContinue = true;
            do
            {
                Console.WriteLine("Select following options.");
                Console.WriteLine("select 1 to add new department, 2 to update a department, 3 to delete a department, 4 to read all department, 5 to exit.\n");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case (int)Options.Add:
                        AddDepartment();
                        loopContinue = true;
                        break;
                    case (int)Options.Update:
                        UpdateDepartment();
                        loopContinue = true;
                        break;
                    case (int)Options.Delete:
                        DeleteDepartment();
                        loopContinue = true;
                        break;
                    case (int)Options.Read:
                        ReadAllDepartments();
                        loopContinue = true;
                        break;
                    case (int)Options.Exit:
                        loopContinue = false;
                        break;
                }
            } while (loopContinue);



            //AddDepartment();
            //DeleteDepartment();
            //ReadAllDepartments();

        }
    }
}
