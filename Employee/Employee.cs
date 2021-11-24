using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    public class Employee
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string surname, name, patronymic, deparment;
        public Employee(string surname, string name, string patronymic, string deparment, int id, int number)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.deparment = deparment;
            Id = id;
            Number = number;
        }
        public string Surname()
        {
            return surname;
        }
        public string Name() 
        {
            return name;
        }
        public string Patronymic()
        {
            return patronymic;
        }
        public string Deparment()
        { 
            return deparment;
        }

        public void GetInfo()
        {
            Console.WriteLine($"{Id,-9}│{Surname(),-15}{Name(),-15}{Patronymic(),-15}{Deparment(),-30}{Number,-15}\n{new String('─', 9)}┼{new String('─', 79)}");
        }
    }
}
