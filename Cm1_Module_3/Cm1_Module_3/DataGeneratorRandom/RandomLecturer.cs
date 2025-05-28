namespace Cm1_Module_3.DataGeneratorRandom;
using Class;
public class RandomLecturer
{
    static Random _random = new Random();
    
    private static readonly string[] LecturerNames = 
    {
        "Іванов", "Петров", "Сидоров", "Коваленко", "Шевченко", 
        "Бондаренко", "Гриценко", "Ткаченко", "Морозов", "Поліщук"
    };
    
    public static List<Lecturer> GenerateLecturers(int count)
    {
        var lecturers = new List<Lecturer>();
        var usedNames = new List<string>();
        
        for (int i = 0; i < Math.Min(count, LecturerNames.Length); i++)
        {
            string name;
            do
            {
                name = LecturerNames[_random.Next(LecturerNames.Length)];
            } while (usedNames.Contains(name));
            
            usedNames.Add(name);
            lecturers.Add(new Lecturer(name));
        }
        
        return lecturers;
    }
}