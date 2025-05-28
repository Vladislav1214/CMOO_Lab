namespace Cm1_Module_3.DataGeneratorRandom;
using Class;
public class RandomSubjects
{
    static Random _random = new Random();
    
    private static readonly string[] SubjectNames = 
    {
        "Математика", "Фізика", "Хімія", "Біологія", "Історія", 
        "Географія", "Література", "Іноземна мова", "Економіка", "Психологія",
        "Програмування C#", "Програмування Python", "Програмування Java",
        "Основи програмування", "Веб-програмування", "Мобільне програмування",
        "Алгоритми", "Структури даних", "Бази даних", "Комп'ютерні мережі"
    };
    
    public static List<Subjects> GenerateSubjects(List<Lecturer> lecturers, int count = 20)
    {
        var subjects = new List<Subjects>();
        var usedNames = new List<string>();
        var possibleHours = new[] { 30, 60, 90, 120, 150};
        
        for (int i = 0; i < Math.Min(count, SubjectNames.Length); i++)
        {
            string name;
            do
            {
                name = SubjectNames[_random.Next(SubjectNames.Length)];
            } while (usedNames.Contains(name));
            
            usedNames.Add(name);
            var hours = possibleHours[_random.Next(possibleHours.Length)];
            var lecturer = lecturers[_random.Next(lecturers.Count)];
            
            var subject = new Subjects(name, hours, lecturer);
            subjects.Add(subject);
            lecturer.Disciplines.Add(subject);
        }
        
        return subjects;
    }
}