/* Author - Nirav Patel
 * Student ID - 000772459
 * Statement of Authorship - I Nirav patel,000772459 had done this lab by my own and didn't copied anything without acknowledgement
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// This class describes the employee
///  This Employee class stores every single employee's data and return the values as per the objects are called in main method.
/// </summary>
namespace Lab4a
{
    class Employee : IComparable<Employee>
    {
        private decimal gross;        //to calculate gross
        public double Hours { get; set; }    //hours of employee worked
        public string Name { get; set; }   //name of employee
        public int Number { get; set; }    //number of employee
        public decimal Rate { get; set; } //rate of employee
        public decimal Gross
        {
            get
            {
                double overTime;                // calculate overtime under the condition hours greater than 40
                if (Hours > 40.0)
                {
                    overTime = Hours - 40.0;
                    overTime = (double)(overTime / 2);
                    overTime = overTime + Hours;
                    gross = Rate * (decimal)overTime;
                }
                else
                {
                    gross = Rate * (decimal)Hours;
                }
                return gross;
            }
        }
        public Employee()
        {

        }
        /// <summary>
        ///  Set the class varaibles value from the parameters passed in construction 
        ///  and calculate gross pay as per given condition
        /// </summary>
        /// <param name="name">name of employee</param>
        /// <param name="number">number of the employee</param>
        /// <param name="rate">rate charge of the employee</param>
        /// <param name="hours">hours the emmployee work</param>
        public Employee(string name, int number, decimal rate, double hours)
        {



        }
        /// <summary>
        /// Print the formatted string contains data of employee.
        /// </summary>
        public void PrintEmployee()
        {
            Console.WriteLine($"{Name,-18} {Number,-10} {$"{Rate:C}",10} {$"{Hours:F}",10} {$"{Gross:C}",15}");
        }
        public static EmployeeComparer GetComparer()
        {
            return new EmployeeComparer();
        }

        public int CompareTo(Employee other, EmployeeComparer.ComparisonType which)
        {
            switch (which)
            {
                case EmployeeComparer.ComparisonType.Name:
                    return this.Name.CompareTo(other.Name);
                case EmployeeComparer.ComparisonType.Number:
                    return this.Number.CompareTo(other.Number);
                case EmployeeComparer.ComparisonType.Rate:
                    return other.Rate.CompareTo(this.Rate);
                case EmployeeComparer.ComparisonType.Hours:
                    return other.Hours.CompareTo(this.Hours);
                case EmployeeComparer.ComparisonType.Gross:
                    return other.Gross.CompareTo(this.Gross);
            }
            return 0;

        }
        /// <summary>
        /// compare two value of employee for sorting
        /// </summary>
        /// <param name="other">another employee</param>
        /// <returns></returns>
        public int CompareTo(Employee other)
        {
            return this.Name.CompareTo(other.Name);
        }
        /// <summary>
        /// to get the type of comparison user want to sort
        /// </summary>
        public class EmployeeComparer : IComparer<Employee>
        {
            public EmployeeComparer.ComparisonType WhichComparison { get; set; }

            public enum ComparisonType
            {
                Name,
                Number,
                Rate,
                Hours,
                Gross
            };
            public int Compare(Employee lhs, Employee rhs)
            {
                return lhs.CompareTo(rhs, WhichComparison);
            }


        }


    }
}