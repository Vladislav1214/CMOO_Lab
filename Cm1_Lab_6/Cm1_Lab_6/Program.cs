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
            int CrewCount = int.Parse(Console.ReadLine());
            
            switch (CrewCount)
            {
                case (1):
                {

                    try
                    {
                        var schoolboys = new List<Schoolboy>
                        {
                            DataGeneratorSchoolboy.GenerateRandomSchoolboy(),
                            DataGeneratorSchoolboy.GenerateRandomSchoolboy()
                        };

                        var students = new List<UniversityStudent>
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

                    flag = false;
                    break;
                }
                case (2):
                {
                    try
                    {
                        List<Aircraft> aircrafts = new List<Aircraft>
                        {
                            DataGeneratorAircraft.GenerateRandomAircraft(),
                            DataGeneratorAircraft.GenerateRandomAircraft(),
                            DataGeneratorAircraft.GenerateRandomAircraft(),
                            DataGeneratorAircraft.GenerateRandomAircraft()
                        };

                        // Створення військової бази
                        MilitaryBase base1 = new MilitaryBase();

                        foreach (var aircraft in aircrafts)
                        {
                            base1.AddAircraft(aircraft);
                        }

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
                    
                    flag = false;
                    break;
                }
            }

            if (flag == false)
            {
                Console.Write("Бажаєте продовжити? Так(1) Ні(0): ");
                int inflag = int.Parse(Console.ReadLine());
                if (inflag == 1) flag = true;
            }
        }
    }
}
