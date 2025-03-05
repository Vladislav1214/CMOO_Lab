using System.Text;

namespace Cm2_Lb_2
{
    internal class Program
    {
        public static int RandRound1()
        {
            var rand = new Random();
            int number = rand.Next(1, 10);
            return number;
        }
        public static int RandRound2()
        {
            var rand = new Random();
            int number = rand.Next(10, 100);
            return number;
        }

        public static byte CheckingForANumberBt()
        {
            string arr;

            while (true)
            {
                arr = Console.ReadLine();

                if (byte.TryParse(arr, out byte number))
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
        public static int CheckingForANumberIn()
        {
            string arr;

            while (true)
            {
                arr = Console.ReadLine();

                if (int.TryParse(arr, out int number))
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

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Підрахунок значення функції у(х) - (1)");
            Console.WriteLine("Підраховану суму ряду - (2)");
            Console.WriteLine("GUESS MY NUMBER - (3)");
            Console.Write("Ваш вибір: ");

            byte namber;
            namber = CheckingForANumberBt();

            switch (namber)
            {
                case 1:
                    {

                        double a = 1.0, x1, y1;

                        for (int i = 0; i < 4; i++)
                        {
                            if (i == 4) { a += 0.25; }

                            Console.WriteLine($"A = {a}");

                            for (int j = 0; j <= 360; j += 6)
                            {
                                x1 = Math.PI * j / 180;
                                y1 = Math.Pow(Math.Sin(a * x1), 2) / (a + 2);

                                Console.WriteLine($"X = {x1}");
                                Console.WriteLine($"Y = {y1}");
                            }

                            a += 0.25;
                        }

                        break;
                    }
                case 2:
                    {
                        double term, y2, sum;
                        int n;
                        double[] x2 = new double[] { 0.2, 0.6, 0.9 };

                        for (int i = 0; i < 3; i++)
                        {
                            term = 1.0;
                            sum = 0.0;
                            n = 1;

                            while (Math.Abs(term) >= 1e-6)
                            {
                                sum += term;
                                term *= -((x2[i] * n) + x2[i]) / n;
                                n++;
                                Console.WriteLine($"Ітерація = {n}, Сума = {sum}, член ряду = {term}");
                            }

                            y2 = 1.0 / Math.Pow((1 + x2[i]), 2);

                            Console.WriteLine($"Сума ряду S(x) = {sum}");
                            Console.WriteLine($"Значення функції у(x) = {y2}");
                            Console.WriteLine($"Кількість ітерацій = {n}");
                        }
                        break;
                    }
                case 3:
                    {
                        int mysteriousNumber, userNumber, userPoints = 0, computerPoints = 0, life, li;
                        bool flag = false, flagLvl = false;
                        int pointLevel1 = 5, pointLevel2 = 10, pointLevelAll, namberRound;

                        for (int j = 0; j < 2; j++)
                        {

                            if (j == 0)
                            {
                                Console.WriteLine("Рівень 1 (вгадайте число від 1 да 10)");

                                pointLevelAll = pointLevel1;
                                namberRound = 3;
                                li = 5;
                            }
                            else
                            {

                                if (!flagLvl)
                                {
                                    Console.WriteLine("Бажаєте продовжити (Рівень 2) Так(1) Ні(0)");
                                    Console.Write("Ваш вибір: ");

                                    if (CheckingForANumberBt() != 1)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }

                                Console.WriteLine("Рівень 2 (вгадайте число від 10 да 100)");

                                pointLevelAll = pointLevel2;
                                namberRound = 2;
                                li = 23;
                            }

                            for (int i = 0; i < namberRound; i++)
                            {

                                if (namberRound == 3)
                                {
                                    mysteriousNumber = RandRound1();
                                }
                                else
                                {
                                    mysteriousNumber = RandRound2();
                                }

                                life = li;

                                do
                                {
                                    Console.Write("Введіть число: ");
                                    userNumber = CheckingForANumberIn();

                                    if (mysteriousNumber == userNumber)
                                    {
                                        Console.WriteLine($"Етап {i + 1}: Виграш");
                                        userPoints += life * pointLevelAll;
                                    }
                                    else
                                    {
                                        life--;
                                        flag = true;
                                        Console.WriteLine("Віповдь невірна");
                                        Console.WriteLine($"Кількість життів ({life})");
                                    }

                                    if (flag && life > 0)
                                    {
                                        Console.WriteLine("Бажаєте взяти підказку (-1 життя): Так(1), Ні(0)");
                                        Console.Write("Ваш вибір: ");
                                        if (CheckingForANumberBt() == 1)
                                        {
                                            life--;
                                            if (mysteriousNumber > userNumber)
                                            {
                                                Console.WriteLine($"Число {userNumber} менше ніж загадане");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Число {userNumber} більше ніж загадане");
                                            }
                                        }
                                    }

                                    flag = false;

                                } while (mysteriousNumber != userNumber && life > 0);

                                if (life == 0)
                                {
                                    Console.WriteLine($"Етап {i + 1}: Програш");
                                    Console.WriteLine($"Загадане число {mysteriousNumber}");
                                    computerPoints += li * pointLevelAll;
                                    flagLvl = true;
                                }

                                Console.WriteLine($"Бали користувача {userPoints}");
                                Console.WriteLine($"Бали комп'ютера {computerPoints}");
                            }
                        }
                        break;
                    }
                default:
                    {

                        break;
                    }
            }
            Console.ReadKey();
        }
    }
}
