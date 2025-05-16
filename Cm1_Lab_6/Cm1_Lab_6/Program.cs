using System.Text;

namespace Cm1_Lab_6;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        bool flag = true;
        while (flag)
        {
            Console.WriteLine("Головне меню");
            Console.WriteLine("Преше завдання (1)");
            Console.WriteLine("Дреге завдання (2)");
            Console.WriteLine("Вихід (0)");
            Console.Write("Ваш вибір: ");
            
            int crewCount = Convert.ToInt32(Console.ReadLine());
            
            switch (crewCount)
            {
                case (1):
                {
                    try
                    {
                        Schoolboy[] schoolboys =
                        {
                            DataGeneratorSchoolboy.GenerateRandomSchoolboy(),
                            DataGeneratorSchoolboy.GenerateRandomSchoolboy()
                        };

                        UniversityStudent[] students =
                        {
                            DataGeneratorUniversityStudent.GenerateRandomUniversityStudent(),
                            DataGeneratorUniversityStudent.GenerateRandomUniversityStudent()
                        };

                        Console.WriteLine("Школярі:");
                        foreach (var s in schoolboys)
                            Console.WriteLine(s);

                        Console.WriteLine("\nСтуденти:");
                        foreach (var s in students)
                            Console.WriteLine(s);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Сталася помилка: {ex.Message}");
                    }
                    
                    break;
                }
                case (2):
                {
                    try
                    {
                        Aircraft[] aircrafts =
                        {
                            DataGeneratorAircraft.GenerateRandomAircraft(),
                            DataGeneratorAircraft.GenerateRandomAircraft(),
                            DataGeneratorAircraft.GenerateRandomAircraft(),
                            DataGeneratorAircraft.GenerateRandomAircraft()
                        };

                        MilitaryBase base1 = new MilitaryBase(aircrafts);

                        base1.AddAircrafts(DataGeneratorAircraft.GenerateRandomAircraft());

                        base1.DisplayAircraftCount();

                        Console.WriteLine("\nІнформація про літальні апарати на базі:");
                        base1.DisplayDetailedInfo();
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Сталася помилка при обробці літальних апаратів: {ex.Message}");
                    }
                    break;
                }
                case (0):
                {
                    Console.WriteLine("Завершення програми");
                    flag = false;
                    break;
                }
                default:
                {
                    Console.WriteLine("Невірний вибір");
                    break;
                }
            }
        }
    }
}
