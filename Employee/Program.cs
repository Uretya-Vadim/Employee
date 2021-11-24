using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace Employee
{
    class Program
    {
        static void Main()
        {
            try
            {
                var rand = new Random();
                List<Employee> list = new(15);
                Employee employee;
                string[] surnames = new string[] { "Uretia", "Ptahin", "Pavlenko", "Makalich", "Bradu" };
                string[] names = new string[] { "Vadim", "Sasha", "Dan", "Roma", "Vladimir" };
                string[] patronymics = new string[] { "Vladimirovich", "Ivanivich", "Sergeyevich", "Aleksandrovich", "Vasilyevich" };
                string[] deparments = new string[] { "administration", "commerce", "accounting", "on community outreach", "regional network training" };
                int[] massNumber = new int[15];
                int[] massNumberId = new int[15];
                int count = 0;
                bool key = true;
                while (count < 15)
                {
                    massNumber[count] = rand.Next(101, 116);
                    for (int j = 0; j < count; j++)
                    {
                        if (massNumber[count] == massNumber[j])
                        {
                            key = false;
                            break;
                        }
                    }
                    if (!key)
                    {
                        count--;
                        key = true;
                    }
                    else
                        count++;
                }
                count = 0; 
                key = true;
                while (count < 15)
                {
                    massNumberId[count] = rand.Next(1000, 10000);
                    for (int j = 0; j < count; j++)
                    {
                        if (massNumberId[count] == massNumberId[j])
                        {
                            key = false;
                            break;
                        }
                    }
                    if (!key)
                    {
                        count--;
                        key = true;
                    }
                    else
                        count++;
                }
                while (list.Count != 15)
                {
                    employee = new Employee(surnames[rand.Next(0, 5)], names[rand.Next(0, 5)], patronymics[rand.Next(0, 5)], deparments[rand.Next(0, 5)], massNumberId[list.Count], massNumber[list.Count]);
                    list.Add(employee);
                }
                Console.WriteLine($"{"№",-10}{"Фамилия",-15}{"Имя",-15}{"Отчество",-15}{"Отдел",-30}{"Номер",-15}\n{ new String('─', 9)}┼{ new String('─', 79)}");
                foreach (Employee item in list)
                {
                    item.GetInfo();
                }
                Console.Write("\nВведите номер столбца(от 0 до 5)\nN = ");
                int N = Convert.ToInt32(Console.ReadLine());
                switch (N)
                {
                    case 0:
                        list = list.OrderBy(x => x.Id).ToList();
                        Console.WriteLine("\nСортировка по №:");
                        break;
                    case 1:
                        list = list.OrderBy(x => x.Surname()).ToList();
                        Console.WriteLine("\nСортировка по Фамилии:");
                        break;
                    case 2:
                        list = list.OrderBy(x => x.Name()).ToList();
                        Console.WriteLine("\nСортировка по Имени:");
                        break;
                    case 3:
                        list = list.OrderBy(x => x.Patronymic()).ToList();
                        Console.WriteLine("\nСортировка по Отчеству:");
                        break;
                    case 4:
                        list = list.OrderBy(x => x.Deparment()).ToList();
                        Console.WriteLine("\nСортировка по отделу:");
                        break;
                    case 5:
                        list = list.OrderBy(x => x.Number).ToList();
                        Console.WriteLine("\nСортировка по номеру:");
                        break;
                }
                Console.WriteLine($"{"№",-10}{"Фамилия",-15}{"Имя",-15}{"Отчество",-15}{"Отдел",-30}{"Номер",-17}\n{ new String('─', 9)}┼{ new String('─', 79)}");
                foreach (Employee item in list)
                {
                    item.GetInfo();
                }
                string title;
                do
                {
                    Console.Write("\nВведите Фамилию: ");
                    title = Console.ReadLine();
                }
                while (!surnames.Contains(title));
                    Console.WriteLine("\nФильтрация по фамилии:");
                var listTitle = list.Where(x => x.Surname().Contains(title)).ToList();
                Console.WriteLine($"{"№",-10}{"Фамилия",-15}{"Имя",-15}{"Отчество",-15}{"Отдел",-30}{"Номер",-17}\n{ new String('─', 9)}┼{ new String('─', 79)}");
                foreach (Employee item in listTitle)
                {
                    item.GetInfo();
                }
                Console.WriteLine("\nГруппировка:");
                var listGroup = list.GroupBy(x => x.Deparment()).Select(g => new { Deparment = g.Key, Count = g.Count() });
                foreach (var item in listGroup)
                {
                    Console.WriteLine($"{item.Deparment} : {item.Count}");
                }
                Console.WriteLine("\n\nХотите повторить?\n1-да;\nДругое число-нет.");
                var check = int.Parse(Console.ReadLine());
                if (check == 1)
                {
                    Console.Clear();
                    list.Clear();
                    Main();
                }
                else
                {
                    return;
                }        
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n");
                Main();
            }
        }
    }
}
