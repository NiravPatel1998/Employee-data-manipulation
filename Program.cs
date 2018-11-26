/* Author - Nirav Patel
 * Student ID - 000772459
 * Statement of Authorship - I Nirav patel,000772459 had done this lab by my own and didn't copied anything without acknowledgement
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// This lab sort the data of employees.txt file , the main class make an array of Employee type and store all the data of employees
/// in it. There are two methods one read the file and another sort the data as per user input choice.
///
namespace Lab4a
{
    class Program
    {
        /// <summary>
        /// 
        /// The main method creates an array objects of Employee type and stores the data of all employees and take user input.
        /// It also calls Read() and Sort() method and then print the sorted array
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            List<Employee> employees = new List<Employee>();
            int count = Read(employees);                            // size of array
            //this while loop will be continue unless the user will enter the exit option.
            while (true)
            {
                Console.WriteLine("1. Sort by Employee Name (ascending)\n2. Sort by Employee Number(ascending)\n3. Sort by Employee Pay Rate(descending)\n4. Sort by Employee Hours(descending)\n5. Sort by Employee Gross Pay(descending)\n6. Exit");
                Console.WriteLine("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());         // choice of sorting
                if (choice == 6)
                {
                    break;
                }
                else if (choice > 6 || choice < 1)
                {
                    Console.WriteLine("-------Please enter valid choice given above-------\n");
                }
                else
                {
                    Sort(choice, employees, count);
                    Console.WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine($"{"Name",-18} {"Number",-15} {"Rate",-10} {"Hours",-12} {"Gross Pay",-15}");
                    Console.WriteLine("------------------------------------------------------------------------");
                    foreach (Employee e in employees)
                    {
                        e.PrintEmployee();
                    }
                    Console.WriteLine("------------------------------------------------------------------------");
                }
            }
        }
        /// <summary>
        /// Read() method read the employees.txt file and store the data in created Employee's object 
        /// </summary>
        /// <param name="employees"> it is an array of Employee type stores each employee's data at respective index</param>
        /// <returns>the number of employees or the size of array</returns>
        static int Read(List<Employee> employees)
        {
            //to read the file "employees.tx" 
            int count = 0;
            try
            {
                FileStream inputFile = new FileStream("employees.txt", mode: FileMode.Open, access: FileAccess.Read);
                StreamReader employeeData = new StreamReader(inputFile);
                string oneEmployeeData = String.Empty;                           // stores single line of file.
                while ((oneEmployeeData = employeeData.ReadLine()) != null)
                {
                    string[] spiltedData = oneEmployeeData.Split(',');          //takes one line data and spilt at "," then stores in this string array
                    Employee e = new Employee();
                    e.Name = spiltedData[0];
                    e.Number = int.Parse(spiltedData[1]);
                    e.Rate = decimal.Parse(spiltedData[2]);
                    e.Hours = double.Parse(spiltedData[3]);

                    employees.Add(e);
                    count++;
                }
                employeeData.Close();
                inputFile.Close();

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }

            return count;
        }
        /// <summary>
        /// Sort() method sort the array as per the user choice.
        /// This method use Selection Sort method. 
        /// "I had taken the alogrithm of selection sort from my another course - Data Structure and Alogrithm's given Examples"
        /// </summary>
        /// <param name="choice">the user input choice</param>
        /// <param name="employees">array of Employee type which have employee's data</param>
        /// <param name="count">size of array</param>
        static void Sort(int choice, List<Employee> employees, int count)
        {
            Employee.EmployeeComparer e = Employee.GetComparer();
            switch (choice)
            {
                //--------------- to sort by name of employee------------------//
                case 1:
                    e.WhichComparison = Employee.EmployeeComparer.ComparisonType.Name;
                    employees.Sort(e);
                    break;
                //-------------- to sort by number of employee-----------------//
                case 2:
                    e.WhichComparison = Employee.EmployeeComparer.ComparisonType.Number;
                    employees.Sort(e);
                    break;
                //------------ to sort by rate of employee-------------------//
                case 3:
                    e.WhichComparison = Employee.EmployeeComparer.ComparisonType.Rate;
                    employees.Sort(e);
                    break;
                //------------- to sort by hours of the employee work -------//
                case 4:
                    e.WhichComparison = Employee.EmployeeComparer.ComparisonType.Hours;
                    employees.Sort(e);
                    break;
                //------------- to sort by gross pay of the employee -------//
                case 5:
                    e.WhichComparison = Employee.EmployeeComparer.ComparisonType.Gross;
                    employees.Sort(e);
                    break;
                default:
                    break;

            }
        }
    }
}