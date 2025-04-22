namespace Cm1_Lab_5;

public class DataGeneratorSubject
{
    static string[] subjectNames = { "Програмування", "Математика", "Алгоритми", "Фізика", "Бази даних", "Мережі" };
    
    public static Subject GenerateRandomSubject() // Генерація випадкового предмета
    {
        string name = subjectNames[DataGeneratorPerson.rand.Next(subjectNames.Length)];
        int hours = DataGeneratorPerson.rand.Next(40, 151);
        DateTime examDate = new DateTime(2025, DataGeneratorPerson.rand.Next(5, 8), DataGeneratorPerson.rand.Next(1, 30));
        return new Subject(name, hours, examDate);
    }
    
    public static Subject[] GenerateRandomSubjects(int count) // Генерація масиву випадкових предметів
    {
        Subject[] subjects = new Subject[count];
        for (int i = 0; i < count; i++)
        {
            subjects[i] = GenerateRandomSubject();
        }
        return subjects;
    }
}