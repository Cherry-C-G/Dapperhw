// See https://aka.ms/new-console-template for more information


using DapperTutorial.Presentation.Menus;
using DapperTutorial.Presentation.UI;

//ManageDepartment manageDepartment = new ManageDepartment();
//manageDepartment.Run();

bool loopContinue = true;
do
{
    Console.WriteLine("Select Menu options.");
    Console.WriteLine("select 1 to enter Department Menu, 2 to enter Employee Menu, 3 to exit.\n");

    int choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case (int)EmpDeptOptions.DeptMenu:
            ManageDepartment manageDepartment = new ManageDepartment();
            manageDepartment.Run();
            loopContinue = true;
            break;
        case (int)EmpDeptOptions.EmpMenu:
            ManageEmployee manage = new ManageEmployee();
            manage.Run();
            loopContinue = true;
            break;
        case (int)EmpDeptOptions.Exit:
            loopContinue = false;
            break;
    }
} while (loopContinue);

//ManageEmployee manage = new ManageEmployee();
//manage.Run();

//Microsoft.Data.SqlClient
//Dapper

//IDbConnection 
//SqlConnection