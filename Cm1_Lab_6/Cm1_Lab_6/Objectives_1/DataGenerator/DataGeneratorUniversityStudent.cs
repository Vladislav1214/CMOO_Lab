namespace Cm1_Lab_6;

public class DataGeneratorUniversityStudent
{
    private static string[] firstNames =
    {
        "Дмитро", "Ірина", "Олег", "Світлана",
        "Віталій", "Анна", "Руслан", "Тетяна"
    };

    private static string[] lastNames =
    {
        "Сидоренко", "Ткаченко", "Мельник",
        "Горбенко", "Литвин", "Романенко",
        "Білоус", "Шевчук"
    };

    private static string[] patronymics =
    {
        "Іванович", "Петрович", "Олександрович", "Сергійович",
        "Іванівна", "Петрівна", "Олександрівна", "Сергіївна"
    };

    private static string[] universityNames =
    {
        "КНУ", "НТУУ 'КПІ'", "ЛНУ ім. Франка", "ХНУ ім. Каразіна", "ЧНУ ім. Федьковича"
    };

    private static string[] studyDirections =
    {
        "Комп'ютерні науки", "Право", "Філологія", "Математика", "Міжнародні відносини"
    };

    public static UniversityStudent GenerateRandomUniversityStudent()
    {
        string fullName =
            $"{lastNames[DataGeneratorSchoolboy.rand.Next(lastNames.Length)]} {firstNames[DataGeneratorSchoolboy.rand.Next(firstNames.Length)]} {patronymics[DataGeneratorSchoolboy.rand.Next(patronymics.Length)]}";
        string university = universityNames[DataGeneratorSchoolboy.rand.Next(universityNames.Length)];
        string direction = studyDirections[DataGeneratorSchoolboy.rand.Next(studyDirections.Length)];
        int year = DataGeneratorSchoolboy.rand.Next(2019, 2024);

        int[] grades = new int[DataGeneratorSchoolboy.rand.Next(4, 8)];
        for (int i = 0; i < grades.Length; i++)
        {
            grades[i] = DataGeneratorSchoolboy.rand.Next(1, 13);
        }

        return new UniversityStudent(fullName, university, direction, year, grades);
    }
}