using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1
{
    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double salary) 
        {
            Name = name;
            Salary = salary;
        }

        public static Employee operator +(Employee employee, double amount)
        {
            employee.Salary += amount;
            return employee;
        }
        public static Employee operator -(Employee employee, double amount)
        {
            employee.Salary -= amount;
            return employee;
        }

        public static bool operator ==(Employee employee1, Employee employee2)
        {
            return employee1.Salary == employee2.Salary;
        }
        public static bool operator !=(Employee employee1, Employee employee2)
        {
            return employee1.Salary != employee2.Salary;
        }
        
        public static bool operator >(Employee employee1, Employee employee2)
        {
            return employee1.Salary > employee2.Salary;
        }
        public static bool operator <(Employee employee1, Employee employee2)
        {
            return employee1.Salary < employee2.Salary;
        }

        public override bool Equals(object obj)
        {
            if (obj is Employee employee_other)
            {
                return this.Salary == employee_other.Salary;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Salary.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name}: {Salary}$";
        }
    }
}
