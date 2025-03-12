using System;

namespace MatrixAndCalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Калькулятор");
                Console.WriteLine("2. Найти максимальный элемент в матрице");
                Console.WriteLine("3. Сложить две матрицы");
                Console.WriteLine("4. Найти сумму элементов строк и столбцов матрицы");
                Console.WriteLine("5. Выйти");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunCalculator();
                        break;
                    case "2":
                        FindMaxElementInMatrix();
                        break;
                    case "3":
                        AddMatrices();
                        break;
                    case "4":
                        CalculateRowAndColumnSums();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine();
            }
        }

        // Подпрограмма 1: Калькулятор
        static void RunCalculator()
        {
            Console.WriteLine("Введите первое число:");
            double num1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите оператор (+, -, *, /):");
            char op = Console.ReadLine()[0];

            Console.WriteLine("Введите второе число:");
            double num2 = double.Parse(Console.ReadLine());

            double result = 0;

            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                        Console.WriteLine("Ошибка: деление на ноль.");
                    break;
                default:
                    Console.WriteLine("Неверный оператор.");
                    return;
            }

            Console.WriteLine($"Результат: {result}");
        }

        // Подпрограмма 2: Поиск максимального элемента в матрице
        static void FindMaxElementInMatrix()
        {
            Console.WriteLine("Введите размерность матрицы NxM:");
            Console.Write("N (строки): ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("M (столбцы): ");
            int m = int.Parse(Console.ReadLine());

            double[,] matrix = new double[n, m];

            Console.WriteLine("Введите элементы матрицы:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Элемент [{i},{j}]: ");
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }

            double max = matrix[0, 0];
            int maxRow = 0, maxCol = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            Console.WriteLine($"Максимальный элемент: {max}");
            Console.WriteLine($"Индексы: [{maxRow}, {maxCol}]");
        }

        // Подпрограмма 3: Сложение двух матриц
        static void AddMatrices()
        {
            Console.WriteLine("Введите размерность первой матрицы NxM:");
            Console.Write("N (строки): ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("M (столбцы): ");
            int m = int.Parse(Console.ReadLine());

            double[,] matrix1 = new double[n, m];
            double[,] matrix2 = new double[n, m];
            double[,] result = new double[n, m];

            Console.WriteLine("Введите элементы первой матрицы:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Элемент [{i},{j}]: ");
                    matrix1[i, j] = double.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Введите элементы второй матрицы:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Элемент [{i},{j}]: ");
                    matrix2[i, j] = double.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            Console.WriteLine("Результат сложения матриц:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{result[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        // Подпрограмма 4: Сумма элементов строк и столбцов матрицы
        static void CalculateRowAndColumnSums()
        {
            Console.WriteLine("Введите размерность матрицы NxM:");
            Console.Write("N (строки): ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("M (столбцы): ");
            int m = int.Parse(Console.ReadLine());

            double[,] matrix = new double[n, m];

            Console.WriteLine("Введите элементы матрицы:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Элемент [{i},{j}]: ");
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }

            // Сумма элементов каждой строки
            Console.WriteLine("Сумма элементов строк:");
            for (int i = 0; i < n; i++)
            {
                double rowSum = 0;
                for (int j = 0; j < m; j++)
                {
                    rowSum += matrix[i, j];
                }
                Console.WriteLine($"Строка {i}: {rowSum}");
            }

            // Сумма элементов каждого столбца
            Console.WriteLine("Сумма элементов столбцов:");
            for (int j = 0; j < m; j++)
            {
                double colSum = 0;
                for (int i = 0; i < n; i++)
                {
                    colSum += matrix[i, j];
                }
                Console.WriteLine($"Столбец {j}: {colSum}");
            }
        }
    }
}