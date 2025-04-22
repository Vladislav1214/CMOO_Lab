namespace Cm1_Lab_6;

public class DataGeneratorSchoolboy
{
    public static Random rand = new Random();
    
    private static string[] firstNames =
    {
        "Іван", "Марія", "Олександр", "Юлія",
        "Андрій", "Олена", "Сергій", "Наталія"
    };

    private static string[] lastNames =
    {
        "Петренко", "Шевченко", "Іваненко",
        "Кравченко", "Бондар", "Коваль",
        "Дяченко", "Коваленко"
    };

    private static string[] patronymics =
    {
        "Іванович", "Петрович", "Олександрович", "Сергійович",
        "Іванівна", "Петрівна", "Олександрівна", "Сергіївна"
    };

    private static string[] schoolNames =
    {
        "Ліцей №1", "Гімназія 'Перспектива'", "Школа №15",
        "Ліцей 'Інтелект'", "Школа 'Гармонія'"
    };

    private static string[] classNames = { "5-А", "6-Б", "7-В", "8-Г", "9-А", "10-Б", "11-В" };

    public static Schoolboy GenerateRandomSchoolboy()
    {
        string fullName =
            $"{lastNames[rand.Next(lastNames.Length)]} {firstNames[rand.Next(firstNames.Length)]} {patronymics[rand.Next(patronymics.Length)]}";
        string school = schoolNames[rand.Next(schoolNames.Length)];
        string className = classNames[rand.Next(classNames.Length)];

        int[] grades = new int[rand.Next(3, 7)];
        for (int i = 0; i < grades.Length; i++)
        {
            grades[i] = rand.Next(1, 13);
        }

        return new Schoolboy(fullName, school, className, grades);
    }
}