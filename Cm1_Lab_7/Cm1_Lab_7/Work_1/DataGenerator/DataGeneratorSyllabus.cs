namespace Cm1_Lab_7;

public static class SampleDataGeneratorSyllabus
{
    static string[] specialties = { "122-КН", "121-ІТ", "123-ІС", "124-КБ" };
    
    public static Syllabus GenerateRandomSyllabus() // Генерація випадкового Syllabus
    {
        Person author = DataGeneratorPerson.GenerateRandomPerson();
        Degree degree = (Degree)DataGeneratorPerson.rand.Next(0, 3);
        string specialty = specialties[DataGeneratorPerson.rand.Next(specialties.Length)];
        Subject[] subjects = DataGeneratorSubject.GenerateRandomSubjects(DataGeneratorPerson.rand.Next(3, 7));

        return new Syllabus(author, degree, specialty, subjects);
    }
    
    public static Syllabus[] GenerateMultipleSyllabuses(int count) // Генерація масиву Syllabus
    {
        Syllabus[] syllabuses = new Syllabus[count];
        for (int i = 0; i < count; i++)
        {
            syllabuses[i] = GenerateRandomSyllabus();
        }
        return syllabuses;
    }
}