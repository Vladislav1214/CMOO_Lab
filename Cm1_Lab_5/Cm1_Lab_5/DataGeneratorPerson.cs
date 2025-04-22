namespace Cm1_Lab_5;

public class DataGeneratorPerson
{
    public static Random rand = new Random();
    
    static string[] firstNames = { "Олександр", "Марія", "Іван", "Наталія", "Андрій", "Олена", "Сергій", "Юлія" };
    static string[] lastNames = { "Коваленко", "Іваненко", "Шевченко", "Бондар", "Кравець", "Петренко" };
    
    public static Person GenerateRandomPerson()
    {
        string name = firstNames[rand.Next(firstNames.Length)];
        string surname = lastNames[rand.Next(lastNames.Length)];

        DateTime birthDate = new DateTime(
            rand.Next(1960, 2001),
            rand.Next(1, 13),
            rand.Next(1, 29)
        );

        return new Person(name, surname, birthDate);
    }
    
}