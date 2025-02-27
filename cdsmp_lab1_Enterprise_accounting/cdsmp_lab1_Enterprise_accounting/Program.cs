using System;
using System.Collections.Generic;

namespace cdsmp_lab1_Enterprise_accounting
{
    class Program
    {
        // Класс для хранения информации о сотруднике
        class Employee
        {
            public string Name { get; set; }
            public string Position { get; set; }
            public decimal Salary { get; set; }

            public Employee(string name, string position, decimal salary)
            {
                Name = name;
                Position = position;
                Salary = salary;
            }

            public override string ToString()
            {
                return $"{Name} ({Position}) - {Salary:C}";
            }
        }

        // Список сотрудников
        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("1. Добавить сотрудника");
                Console.WriteLine("2. Показать всех сотрудников");
                Console.WriteLine("3. Рассчитать общую сумму зарплат");
                Console.WriteLine("4. Выйти");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        ShowEmployees();
                        break;
                    case "3":
                        CalculateTotalSalary();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine();
            }
        }

        // Метод для добавления сотрудника
        static void AddEmployee()
        {
            Console.Write("Введите имя сотрудника: ");
            string name = Console.ReadLine();

            Console.Write("Введите должность сотрудника: ");
            string position = Console.ReadLine();

            Console.Write("Введите зарплату сотрудника: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal salary))
            {
                employees.Add(new Employee(name, position, salary));
                Console.WriteLine("Сотрудник добавлен!");
            }
            else
            {
                Console.WriteLine("Ошибка ввода зарплаты.");
            }
        }

        // Метод для отображения всех сотрудников
        static void ShowEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("Сотрудников нет.");
                return;
            }

            Console.WriteLine("Список сотрудников:");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        // Метод для расчета общей суммы зарплат
        static void CalculateTotalSalary()
        {
            decimal totalSalary = 0;
            foreach (var employee in employees)
            {
                totalSalary += employee.Salary;
            }

            Console.WriteLine($"Общая сумма зарплат: {totalSalary:C}");
        }
    }
}
