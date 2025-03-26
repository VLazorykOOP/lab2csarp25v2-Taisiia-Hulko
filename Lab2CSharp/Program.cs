using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nLab 1 - Виберіть завдання:");
            Console.WriteLine("1. Підрахунок середнього арифметичного від’ємних елементів");
            Console.WriteLine("2. Знайти номер першого мінімального елемента");
            Console.WriteLine("3. Поміняти місцями рядки в квадратній матриці");
            Console.WriteLine("4. Знайти перші додатні елементи у східчастому масиві");
            Console.WriteLine("0. Вийти");
            Console.Write("Вибір: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1();
                    break;
                case "2":
                    Task2();
                    break;
                case "3":
                    Task3();
                    break;
                case "4":
                    Task4();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                    break;
            }
        }
    }

    static void Task1()
    {
        Console.Write("Введіть розмірність масиву: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Введіть число для елемента " + i + ": ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        int sum = 0, count = 0;

        for (int i = 0; i < n; i++)
        {
            if (numbers[i] < 0)
            {
                sum = sum + numbers[i];
                count = count + 1;
            }
        }

        if (count > 0)
        {
            double average = (double)sum / count;
            Console.WriteLine("Середнє арифметичне від’ємних: " + average);
        }
        else
        {
            Console.WriteLine("Від’ємних чисел немає");
        }
    }

    static void Task2()
    {
        Console.Write("Введіть розмірність масиву: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double[] numbers = new double[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Введіть число для елемента " + i + ": ");
            numbers[i] = Convert.ToDouble(Console.ReadLine());
        }

        double min = numbers[0];
        int minIndex = 0;

        for (int i = 1; i < n; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
                minIndex = i;
            }
        }

        Console.WriteLine("Номер першого мінімального елемента: " + minIndex);
    }

    static void Task3()
    {
        Console.Write("Введіть розмірність квадратної матриці (n×n): ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[n, n];

        Console.WriteLine("Введіть елементи матриці:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"matrix[{i},{j}] = ");
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        Console.WriteLine("\nПочаткова матриця:");
        PrintMatrix(matrix, n);

        if (n % 2 == 0)
        {
            int mid1 = n / 2 - 1;
            int mid2 = n / 2;
            SwapRows(matrix, mid1, mid2);
        }
        else
        {
            int mid = n / 2;
            SwapRows(matrix, 0, mid);
        }

        Console.WriteLine("\nМатриця після перестановки рядків:");
        PrintMatrix(matrix, n);
    }

    static void SwapRows(int[,] matrix, int row1, int row2)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int temp = matrix[row1, j];
            matrix[row1, j] = matrix[row2, j];
            matrix[row2, j] = temp;
        }
    }

    static void PrintMatrix(int[,] matrix, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void Task4()
    {
        Console.Write("Введіть кількість рядків (n): ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[][] jaggedArray = new int[n][];
        int maxColumns = 0;

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введіть кількість елементів у рядку {i + 1}: ");
            int m = Convert.ToInt32(Console.ReadLine());
            jaggedArray[i] = new int[m];

            if (m > maxColumns)
                maxColumns = m;

            for (int j = 0; j < m; j++)
            {
                Console.Write($"Введіть елемент [{i},{j}]: ");
                jaggedArray[i][j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        int[] firstPositiveInColumn = new int[maxColumns];

        for (int j = 0; j < maxColumns; j++)
        {
            firstPositiveInColumn[j] = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                if (j < jaggedArray[i].Length && jaggedArray[i][j] > 0)
                {
                    firstPositiveInColumn[j] = jaggedArray[i][j];
                    break;
                }
            }
        }

        Console.WriteLine("\nМасив перших додатних елементів у стовпцях:");
        for (int i = 0; i < maxColumns; i++)
        {
            if (firstPositiveInColumn[i] == int.MinValue)
                Console.Write("N/A ");
            else
                Console.Write(firstPositiveInColumn[i] + " ");
        }
        Console.WriteLine();
    }
}
