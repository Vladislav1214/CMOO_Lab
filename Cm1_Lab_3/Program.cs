using System;
using System.Collections;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cm1_Lab_3
{
    internal class Program
    {        
        static int CheckingForANumberInt()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Введені дані не є числом");
                    Console.Write("Введіть повторно: ");
                }
            }
        }

        static int InputMethodSelection()
        {
            Console.WriteLine("Виберіть метод введеня:");
            Console.WriteLine("Випадкові числа (1)");
            Console.WriteLine("Введення з файлу (2)");
            Console.WriteLine("Введення користувачем (3)");
            Console.Write("Ваш вибір: ");
            return CheckingForANumberInt();
        }

        static void RangeEr(out int a, out int b)
        {
            Console.Write("Введіть діапазон від ");
            a = CheckingForANumberInt();
            Console.Write("до ");
            b = CheckingForANumberInt();
            Console.WriteLine();

            if (a > b)
            {
                a = 0;
                b = 10;
            }
        }

        static int SizeMas()
        {
            Console.Write("Введіть розмір масиву: ");
            int size= CheckingForANumberInt();
            return size;
        }

        static int[] Randomfrom1(int n)
        {
            int a, b;
            RangeEr(out a, out b);

            Random random = new Random();
            int[] arrayA = new int[n];
            for (int i = 0; i < n; i++)
                arrayA[i] = random.Next(a, b); 
            
            return arrayA;
        }

        static int[,] Randomfrom2(int n)
        {
            int a, b;
            RangeEr(out a, out b);

            Random random = new Random();
            int[,] arrayA = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    arrayA[i, j] = random.Next(a, b);

            return arrayA;
        }

        static void PrintMatrix(int[,] matrix, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write($"{matrix[i, j],2:D} ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintArray(int[] array)
        {
            foreach (int element in array)
                Console.Write($"{element,2:D} ");
            Console.WriteLine();
            Console.WriteLine();
        }

        static int[] CreateArray()
        {
            while (true)
            {
                int namber = InputMethodSelection();
                Console.Clear();
                switch (namber)
                {
                    case 1:
                        {
                            int size = SizeMas();
                            int[] arrey = Randomfrom1(size);
                            return arrey;
                        }
                    case 2:
                        {
                            return LoadArrayFromFileArray();
                        }
                    case 3:
                        {
                            int size = SizeMas();
                            int[] arrey = new int[size];
                            for (int i = 0; i < size; i++)
                            {
                                arrey[i] = CheckingForANumberInt();
                            }
                            return arrey;
                        }
                    default:                        
                        break;
                }
            }
        }

        static int[,] CreateMatrix()
        {
            while (true)
            {
                int namber = InputMethodSelection();
                Console.Clear();
                switch (namber)
                {
                    case 1:
                        {
                            int size = SizeMas();
                            int[,] arrey = Randomfrom2(size);
                            return arrey;
                        }
                    case 2:
                        {
                            
                           return LoadArrayFromFileMatrix();
                        }
                    case 3:
                        {
                            int size = SizeMas();
                            int[,] arrey = new int[size, size];
                            for (int i = 0; i < size; i++)
                            {
                                for (int j = 0; j < size; j++)
                                {
                                    arrey[i, j] = CheckingForANumberInt();
                                }
                            }
                            return arrey;
                        }
                    default:
                        break;
                }
            }
        }

        static int CountLinesInFileArray()
        {
            int count = 0;
            using (StreamReader reader = new StreamReader("dat1.txt"))
            {
                while (reader.ReadLine() != null)
                {
                    count++;
                }
            }
            return count;
        }

        static int[] LoadArrayFromFileArray()
        {
            int foll = 5;

            if (!File.Exists("dat1.txt"))
            {
                Console.WriteLine("Файл не знайдений. Масив буде заповнено випадковими числами");
                return Randomfrom1(foll);
            }
            else
            {
                int count;
                count = CountLinesInFileArray();

                int[] iArray = new int[count];

                using (StreamReader reader = new StreamReader("dat1.txt"))
                {
                    for (int j = 0; j < iArray.Length; j++)
                    {
                        string strValue = reader.ReadLine();

                        if (int.TryParse(strValue, out int number))
                            iArray[j] = number;

                        else
                        {
                            Console.WriteLine($"Ошибка: '{strValue}' не число.Тому замінюємо його на 1");
                            iArray[j] = 1;
                        }
                    }
                }
                return iArray;
            }
        }

        static int CountLinesInFileMatrix()
        {
            int count = 0;
            using (StreamReader reader = new StreamReader("dat2.txt"))
            {
                while (reader.ReadLine() != null)
                {
                    count++;
                }
            }
            return count;
        }

        static int[,] LoadArrayFromFileMatrix()
        {
            int foll = 5;

            if (!File.Exists("dat2.txt"))
            {
                Console.WriteLine("Файл не знайдений. Масив буде заповнено випадковими числами");

                return Randomfrom2(foll);
            }
            else
            {
                int count;
                count = CountLinesInFileMatrix();

                int[,] matrix = new int[count, count];

                using (StreamReader reader = new StreamReader("dat2.txt"))
                {
                    for (int i = 0; i < count; i++)
                    {
                        string line = reader.ReadLine();
                        string[] elements = line.Split(' ');

                        for (int j = 0; j < count; j++)
                        {
                            if (j < elements.Length && int.TryParse(elements[j], out int number))
                            {
                                matrix[i, j] = number;
                            }
                            else
                            {
                                Console.WriteLine($"Помилка: '{elements[j]}' не число. Замінюємо його на 1.");
                                matrix[i, j] = 1;
                            }
                        }
                    }
                }

                return matrix;
            }
        }

        static int CountNonZeroInRow(int[,] matrix, int row, int size)
        {
            int count = 0;
            for (int j = 0; j < size; j++)
                if (matrix[row, j] != 0) count++;
            return count;
        }

        static int CountNonZeroInColumn(int[,] matrix, int col, int size)
        {
            int count = 0;
            for (int i = 0; i < size; i++)
                if (matrix[i, col] != 0) count++;
            return count;
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            bool flag = false;
            while (!flag)
            {

                Console.WriteLine("Завдання 1. " +
                    "\nВідсортувати у спадному порядку елементи масиву А, що розташовані " +
                    "\nміж першим та останнім непарними за значеннями елементами масиву.");
                Console.WriteLine("Завдання 2. " +
                    "\nВ заданій матриці суміжності графа С розмірності n×n " +
                    "\nнеобхідно реалізувати крок приведення матриці та провести оцінювання нулів у матриці." +
                    " \nВивести на екран індекси нуля або нулів матриці, вага яких найбільша.");
                Console.WriteLine();
                Console.Write("Введіть номер завдання: ");

                int namber = CheckingForANumberInt(); ;
                Console.Clear();
                switch (namber)
                {
                    case 1:
                        {
                            int[] arrayA = CreateArray();
                            int size = arrayA.Length;

                            int minIndex = 0, maxIndex = 0;

                            PrintArray(arrayA);

                            bool foundFirstEven = false;

                            for (int i = 0; i < size; i++)
                            {
                                if (arrayA[i] % 2 == 0 && !foundFirstEven)
                                {
                                    minIndex = i;
                                    foundFirstEven = true;
                                }

                                if (arrayA[i] % 2 == 0)
                                    maxIndex = i;
                            }

                            int length = maxIndex - minIndex + 1;
                            Array.Sort(arrayA, minIndex, length);
                            Array.Reverse(arrayA, minIndex, length);

                            PrintArray(arrayA);

                            flag = true;
                            break;
                        }
                    case 2:
                        {
                            int[,] matrix = CreateMatrix();
                            int size = matrix.GetLength(0);

                            PrintMatrix(matrix, size);

                            for (int i = 0; i < size; i++)
                            {
                                int minElement = matrix[i, 0];

                                for (int j = 1; j < size; j++)
                                    if (matrix[i, j] < minElement)
                                        minElement = matrix[i, j];

                                for (int j = 0; j < size; j++)
                                    matrix[i, j] -= minElement;
                            }

                            for (int i = 0; i < size; i++)
                            {
                                int minElement = matrix[0, i];

                                for (int j = 1; j < size; j++)
                                    if (matrix[j, i] < minElement)
                                        minElement = matrix[j, i];

                                for (int j = 0; j < size; j++)
                                    matrix[j, i] -= minElement;
                            }

                            PrintMatrix(matrix, size);

                            int maxWeight = -1;
                            int[] zeroRows = new int[size * size];
                            int[] zeroCols = new int[size * size];
                            int zeroCount = 0;

                            for (int i = 0; i < size; i++)
                            {
                                for (int j = 0; j < size; j++)
                                {
                                    if (matrix[i, j] == 0)
                                    {
                                        int rowWeight = CountNonZeroInRow(matrix, i, size);
                                        int colWeight = CountNonZeroInColumn(matrix, j, size);
                                        int totalWeight = rowWeight + colWeight;
                                        if (totalWeight > maxWeight)
                                        {
                                            maxWeight = totalWeight;
                                            zeroCount = 0;
                                            zeroRows[zeroCount] = i;
                                            zeroCols[zeroCount] = j;
                                            zeroCount++;
                                        }
                                        else if (totalWeight == maxWeight)
                                        {
                                            zeroRows[zeroCount] = i;
                                            zeroCols[zeroCount] = j;
                                            zeroCount++;
                                        }
                                    }
                                }
                            }

                            Console.WriteLine($"\nНулі з найбільшою вагою ({maxWeight}) знаходяться в позиціях:");
                            for (int i = 0; i < zeroCount; i++)
                                Console.WriteLine($"({zeroRows[i]}, {zeroCols[i]})");

                            flag = true;
                            break;
                        }
                    default:
                        break;
                }

                Console.WriteLine("Бажаєте повторити?");
                Console.Write("Так(1) Ні(0) : ");
                if (CheckingForANumberInt() == 1) flag = false;
                Console.Clear();
            }
        }
    }
}
