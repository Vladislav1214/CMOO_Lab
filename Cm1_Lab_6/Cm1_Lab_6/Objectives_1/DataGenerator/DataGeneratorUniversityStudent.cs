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

    private static string[] educationalInstitutionName =
    {
        "КНУ", "НТУУ 'КПІ'", "ЛНУ ім. Франка", "ХНУ ім. Каразіна", "ЧНУ ім. Федьковича"
    };
    
    private static string[] specialtiesCourses =
    {
        "КН-1", "МЕ-2", "ЕЕ-3", "БТ-4", "МД-1"
    };

    private static string[] studyDirections =
    {
        "Комп'ютерні науки", "Право", "Філологія", "Математика", "Міжнародні відносини"
    };

    public static UniversityStudent GenerateRandomUniversityStudent()
    {
        string fullName =
            $"{lastNames[DataGeneratorSchoolboy.rand.Next(lastNames.Length)]} {firstNames[DataGeneratorSchoolboy.rand.Next(firstNames.Length)]} {patronymics[DataGeneratorSchoolboy.rand.Next(patronymics.Length)]}";
        string universityName = educationalInstitutionName[DataGeneratorSchoolboy.rand.Next(educationalInstitutionName.Length)];
        string studyDirection = studyDirections[DataGeneratorSchoolboy.rand.Next(studyDirections.Length)];
        string groupName = specialtiesCourses[DataGeneratorSchoolboy.rand.Next(specialtiesCourses.Length)];
        int yearOfAdmission = DataGeneratorSchoolboy.rand.Next(2019, 2024);
        
        int[] grades = new int[DataGeneratorSchoolboy.rand.Next(4, 8)];
        for (int i = 0; i < grades.Length; i++)
        {
            grades[i] = DataGeneratorSchoolboy.rand.Next(1, 13);
        }

        return new UniversityStudent(fullName, universityName, groupName, studyDirection, yearOfAdmission , grades);
    }
}