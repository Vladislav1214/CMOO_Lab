using System.Text;
using System;

namespace Cm2_Lab_1
{
    public class Program
    {
        public static byte CheckingForANumberBt()
        {
            string arr;
            arr = Console.ReadLine();

            if (byte.TryParse(arr, out byte number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Введені дані не є числом");
                Console.Write("Введіть повторно: ");
                return CheckingForANumberBt();
            }
        }
        public static double CheckingForANumberDb()
        {
            string arr;
            arr = Console.ReadLine();

            if (double.TryParse(arr, out double number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Введені дані не є числом");
                Console.Write("Введіть повторно: ");
                return CheckingForANumberDb();
            }
        }
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Обчислення математичного виразу (1)");
            Console.WriteLine("Обчислення та друк значень функції (2)");
            Console.WriteLine("Тест «Перевір свої можливості» (3)");
            Console.WriteLine("Задача про вантажний літак (4)");
            Console.Write("Ваш вибір: ");

            byte namber = CheckingForANumberBt();
            switch (namber)
            {
                case 1:
                    {
                        double l, a, x;
                        //l = 0.8D;
                        //a = 16.44D;
                        //x = 5.6D;
                        Console.WriteLine("Введіть l");
                        l = CheckingForANumberDb();
                        Console.WriteLine("Введіть a");
                        a = CheckingForANumberDb();
                        Console.WriteLine("Введіть x");
                        x = CheckingForANumberDb();

                        double chuslo = (l * Math.Pow(Math.Sin(x / 2), 3)) / Math.Sqrt(Math.Pow(a, 2) + Math.Pow(l, 2) - 2 * a * l * Math.Cos(x / 2));

                        Console.WriteLine($"Відповідь: {chuslo}");

                        break;
                    }

                case 2:
                    {
                        double checkX = 0, checkY = 0, mnX = 0, mxX = 0;

                        StreamReader file1In = null;
                        try
                        {
                            file1In = new StreamReader("info1.txt");
                            checkX = double.Parse(file1In.ReadLine());
                            checkY = double.Parse(file1In.ReadLine());
                            mnX = double.Parse(file1In.ReadLine());
                            mxX = double.Parse(file1In.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            if (file1In != null)
                            {
                                file1In.Close();
                            }
                        }

                        double interval, yfor2, xfor2 = 0;

                        if (checkY == Math.Round((Math.Tan(checkX) - 3 * Math.Pow(checkX, 2)), 2))
                        {
                            Console.WriteLine("Перевірка функції успішна");
                        }
                        else
                        {
                            Console.WriteLine("Перевірка функції не успішна");
                        }

                        if (mnX > 0 && mxX > 0 || mnX < 0 && mxX < 0)
                        {
                            interval = Math.Max(Math.Abs(mnX), Math.Abs(mxX)) - Math.Min(Math.Abs(mnX), Math.Abs(mxX));
                        }
                        else
                        {
                            interval = Math.Max(mnX, mxX) - Math.Min(mnX, mxX);
                        }

                        using (StreamWriter file1Out = new StreamWriter("lab2.txt"))
                        {

                            file1Out.WriteLine("Таблиця значень");
                            file1Out.WriteLine(new string('+', 30));
                            file1Out.WriteLine("+   Аргумент  +    Функція   +");
                            file1Out.WriteLine(new string('+', 30));
                            for (int i = 0; i <= 8; i++)
                            {
                                xfor2 += interval / 8.0;
                                yfor2 = Math.Tan(xfor2) - 3 * Math.Pow(xfor2, 2);
                                file1Out.WriteLine($"+ X= {xfor2,6:f}   +   Y= {yfor2,6:f}  +");
                            }
                            file1Out.WriteLine(new string('+', 30));
                            file1Out.WriteLine("Таблицю сформував <Озівський В. В.>");
                            file1Out.Close();
                        }

                        break;
                    }

                case 3:
                    {
                        byte points = 0;

                        Console.WriteLine("Професор ліг спати о 8 годині, а встав о 9 годині. Скільки годин \r\nпроспав професор?");
                        if (CheckingForANumberBt() == 1) points++;

                        Console.WriteLine("На двох руках десять пальців. Скільки пальців на 10?");
                        if (CheckingForANumberBt() == 50) points++;

                        Console.WriteLine("Скільки цифр у дюжині?");
                        if (CheckingForANumberBt() == 2) points++;

                        Console.WriteLine("Скільки потрібно зробити розпилів, щоб розпиляти колоду на \r\n12 частин?");
                        if (CheckingForANumberBt() == 11) points++;

                        Console.WriteLine("Лікар зробив три уколи в інтервалі 30 хвилин. Скільки часу він \r\nвитратив?");
                        if (CheckingForANumberBt() == 30) points++;

                        Console.WriteLine("Скільки цифр 9 в інтервалі 1-100?");
                        if (CheckingForANumberBt() == 1) points++;

                        Console.WriteLine("Пастух мав 30 овець. Усі, окрім однієї, розбіглися. Скільки овець \r\nлишилося?");
                        if (CheckingForANumberBt() == 1) points++;

                        switch (points)
                        {
                            case 7: Console.WriteLine("Геній"); break;
                            case 6: Console.WriteLine("Ерудит"); break;
                            case 5: Console.WriteLine("Нормальний"); break;
                            case 4: Console.WriteLine("Здібності середні"); break;
                            case 3: Console.WriteLine("«Здібності нижче середнього"); break;
                            default: Console.WriteLine("Вам треба відпочити!"); break;
                        }

                        break;
                    }

                case 4:
                    {
                        int tankCapacity = 0, distanceAB = 0, distanceBC = 0, mass = 0;

                        StreamReader file2In = null;
                        try
                        {
                            file2In = new StreamReader("info2.txt");
                            tankCapacity = int.Parse(file2In.ReadLine());
                            distanceAB = int.Parse(file2In.ReadLine());
                            distanceBC = int.Parse(file2In.ReadLine());
                            mass = int.Parse(file2In.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            if (file2In != null)
                            {
                                file2In.Close();
                            }
                        }

                        int consumption, consumptionofAB, consumptionofBC, remnantAB, amountOfFuel;

                        if (mass <= 500) consumption = 1;
                        else if (mass <= 1000) consumption = 4;
                        else if (mass <= 1500) consumption = 7;
                        else if (mass <= 2000) consumption = 9;
                        else
                        {
                            Console.WriteLine("Неможливість польоту за введеним маршрутом (перевантаження)");
                            break;
                        }
                        ;

                        consumptionofAB = distanceAB * consumption;
                        consumptionofBC = distanceBC * consumption;

                        if (tankCapacity > consumptionofAB && tankCapacity > consumptionofBC)
                        {
                            remnantAB = tankCapacity - consumptionofAB;
                            amountOfFuel = consumptionofBC - remnantAB;
                            if (amountOfFuel < 0) { amountOfFuel = 0; }
                        }
                        else
                        {
                            Console.WriteLine("Неможливість польоту: недостатньо палива для подолання маршруту");
                            break;
                        }

                        Console.WriteLine($"Мінімальна кількість палива необхідна для дозаправки літака в пункті В становить: {amountOfFuel}");

                        break;
                    }

                default:
                    {
                        Console.WriteLine("Ведено невірне число");
                        break;
                    }
            }
            Console.ReadKey();
        }
    }
}