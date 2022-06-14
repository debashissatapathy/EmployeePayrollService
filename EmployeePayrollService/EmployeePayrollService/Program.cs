// See https://aka.ms/new-console-template for more information
using EmployeePayrollService;

Console.WriteLine("*********EmployeePayrollService**********");
EmployeeModel model = new EmployeeModel(1, "Debashis", "Male", 15000, "7873049953", "Bhadrak", "1000", "2000", "2000", "1000", "Engineer");
EmployeeData data = new();
while (true)
{
    Console.WriteLine("Select any option \n1.Create Database \n2.Create Table \n3.Insert Data \n4.Update Record \n5.Delete Record \n6.View Record");
    int option = Convert.ToInt16(Console.ReadLine());
    switch (option)
    {
        case 1:
            EmployeeData.CreateDatabase();
            break;
        case 2:
            EmployeeData.CreateTable();
            break;
        case 3:            
            model.EmpName = "Biswajit";
            model.Gender = "Male";
            model.BasicPay = 25000;
            model.PhoneNumber = "7873049953";
            model.Address = "Bhadrak";
            model.Deduction = "1000";
            model.TaxablePay = "2000";
            model.IncomeTax = "2000";
            model.NetPay = "500";
            model.Department = "Engineer";
            data.AddEmployee(model);            
            break;
        case 4:            
            data.UpdateEmployee(model);
            break;
        case 5:
            model.EmpName = "Biswajit";
            data.DeleteEmployee(model);            
            break;
        case 6:
            EmployeeData.ViewRecord(model);
            break;
    }
    Console.WriteLine("\n");
}


