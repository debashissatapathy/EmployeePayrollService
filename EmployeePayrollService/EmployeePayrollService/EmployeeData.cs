using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class EmployeeData
    {
        public static void CreateDatabase()
        {
            try
            {
                SqlConnection sql = new SqlConnection(@"Data Source = DESKTOP-195K6F7; Initial Catalog = master; Integrated Security = True;");
                sql.Open();
                SqlCommand cmd = new SqlCommand("Create database PayrollService;", sql);
                cmd.ExecuteNonQuery();
                Console.ForegroundColor = ConsoleColor. DarkGreen;
                Console.WriteLine("PayrollService Database created successfully.");
                Console.ResetColor();
                sql.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occure while creating database: " + e.Message + "\t");
            }
        }
        public static void CreateTable()
        {
            try
            {
                SqlConnection sql = new(@"Data Source = DESKTOP-195K6F7; Initial Catalog = PayrollService; Integrated Security = True;");
                sql.Open();
                SqlCommand cmd = new("Create table employee_payroll(EmpId int Identity(1,1)primary key, EmpName varchar(100)," +
                "Gender char(10), BasicPay varchar(100), PhoneNumber varchar(10), Address varchar(200), Deduction varchar(100), " +
                "TaxablePay varchar(100), IncomeTax varchar(100), NetPay varchar(100), Department varchar(100))", sql);
                cmd.ExecuteNonQuery();
                Console.ForegroundColor= ConsoleColor. DarkGreen;
                Console.WriteLine("Employee Payroll table has been  created successfully!");
                Console.ResetColor();
                sql.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table: " + e.Message + "\t");
            }
        }
        public const string ConnectionFile = @"Data Source = DESKTOP-195K6F7; Initial Catalog =PayrollService; Integrated Security = True;";
        SqlConnection sql = new SqlConnection(ConnectionFile);

        public  bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.sql)
                {
                    SqlCommand cmd = new SqlCommand("Sp_employee_payroll_Insert", sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpName", model.EmpName);
                    cmd.Parameters.AddWithValue("@Gender", model.Gender);
                    cmd.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@Deduction", model.Deduction);
                    cmd.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    cmd.Parameters.AddWithValue("@IncomeTax", model.IncomeTax);
                    cmd.Parameters.AddWithValue("@NetPay", model.NetPay);
                    cmd.Parameters.AddWithValue("@Department", model.Department);
                    sql.Open();
                    var result = cmd.ExecuteNonQuery();
                    sql.Close();
                    if (result != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Record inserted Successfully");
                        Console.ResetColor();
                        return true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error");
                        Console.ResetColor();
                        return false;
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sql.Close();
            }
            return false;
        }
        public bool UpdateEmployee(EmployeeModel model)
        {
            try
            {
                using (this.sql)
                {
                    SqlCommand cmd = new SqlCommand("Sp_employee_payroll_Update", this.sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpName", model.EmpName);
                    cmd.Parameters.AddWithValue("@Gender", model.Gender);
                    cmd.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@Deduction", model.Deduction);
                    cmd.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    cmd.Parameters.AddWithValue("@IncomeTax", model.IncomeTax);
                    cmd.Parameters.AddWithValue("@NetPay", model.NetPay);
                    cmd.Parameters.AddWithValue("@DepartMent", model.Department);
                    this.sql.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.sql.Close();
                    if (result != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Record Updated Successfully");
                        Console.ResetColor();
                        return true;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error");
                    Console.ResetColor();
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.sql.Close();
            }
            return false;
        }
        public bool DeleteEmployee(EmployeeModel model)
        {
            try
            {
                using (this.sql)
                {
                    SqlCommand cmd = new SqlCommand("Sp_employee_payroll_Delete", this.sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpName", model.EmpName);
                    cmd.Parameters.AddWithValue("@Gender", model.Gender);
                    cmd.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@Deduction", model.Deduction);
                    cmd.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    cmd.Parameters.AddWithValue("@IncomeTax", model.IncomeTax);
                    cmd.Parameters.AddWithValue("@NetPay", model.NetPay);
                    cmd.Parameters.AddWithValue("@DepartMent", model.Department);
                    this.sql.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.sql.Close();
                    if (result != 0)
                    { 
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Record Deleted Successfully");
                        Console.ResetColor();
                        return true;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error");
                    Console.ResetColor();
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.sql.Close();
            }
            return false;
        }
        public static void  ViewRecord(EmployeeModel model)
        {
            try
            {

                SqlConnection sql = new(@"Data Source = DESKTOP-195K6F7; Initial Catalog = PayrollService; Integrated Security = True;");
                SqlCommand cmd = new SqlCommand("Sp_employee_payroll_ViewRecord", sql);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@EmpName", model.EmpName);
                //cmd.Parameters.AddWithValue("@Gender", model.Gender);
                //cmd.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                //cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                //cmd.Parameters.AddWithValue("@Address", model.Address);
                //cmd.Parameters.AddWithValue("@Deduction", model.Deduction);
                //cmd.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                //cmd.Parameters.AddWithValue("@IncomeTax", model.IncomeTax);
                //cmd.Parameters.AddWithValue("@NetPay", model.NetPay);
                //cmd.Parameters.AddWithValue("@DepartMent", model.Department);
                sql.Open();
                cmd.ExecuteNonQuery();
                sql.Close();
               
                
            }

            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table: " + e.Message + "\t");
            }
        }
    }
   
}

