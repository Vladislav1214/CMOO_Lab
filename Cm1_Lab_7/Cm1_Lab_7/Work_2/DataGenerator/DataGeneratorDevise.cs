namespace Cm1_Lab_7;

public abstract class DataGeneratorDevice
{
    protected Random random;
    
    // Словники з можливими значеннями для рандомізації
    protected static readonly string[] MaterialOptions = { "Алюміній", "Карбон", "Титан", "Сталь", "Композит", "Дерево", "Нейлон", "Дакрон", "Шовк" };
    protected static readonly string[] EngineTypes = { "Турбореактивний", "Газотурбінний", "Поршневий", "Електричний", "Гібридний" };
    protected static readonly string[] PartNames = { "Крило", "Корпус", "Шасі", "Гвинт", "Двигун", "Оболонка", "Стабілізатор", "Кабіна", "Хвіст" };
    
    // Масиви префіксів та суфіксів для генерації імен
    protected static readonly string[] NamePrefixes = { "Небесний", "Швидкий", "Легкий", "Повітряний", "Сучасний", "Комфортний", "Потужний" };
    protected static readonly string[] NameSuffixes = { "Сокіл", "Орел", "Яструб", "Стріла", "Хмара", "Вітер", "Блискавка", "Промінь" };
    
    public DataGeneratorDevice()
    {
        random = new Random();
    }
    
    // Абстрактний метод для створення пристрою
    public abstract Device CreateDevice();
    
    // Генерація випадкового імені
    protected string GenerateRandomName()
    {
        string prefix = NamePrefixes[random.Next(NamePrefixes.Length)];
        string suffix = NameSuffixes[random.Next(NameSuffixes.Length)];
        return $"{prefix} {suffix} {random.Next(100, 1000)}";
    }
    
    // Генерація випадкового року виробництва
    protected int GenerateRandomYear()
    {
        return random.Next(1980, 2025);
    }
    
    // Генерація випадкової швидкості
    protected int GenerateRandomSpeed(int min, int max)
    {
        return random.Next(min, max);
    }
    
    // Генерація випадкової потужності
    protected int GenerateRandomPower(int min, int max)
    {
        return random.Next(min, max);
    }
    
    // Генерація випадкового матеріалу
    protected string GenerateRandomMaterial()
    {
        return MaterialOptions[random.Next(MaterialOptions.Length)];
    }
    
    // Генерація випадкового типу двигуна
    protected string GenerateRandomEngineType()
    {
        return EngineTypes[random.Next(EngineTypes.Length)];
    }
    
    // Генерація випадкової назви частини
    protected string GenerateRandomPartName()
    {
        return PartNames[random.Next(PartNames.Length)];
    }
    
    // Генерація випадкового логічного значення
    protected bool GenerateRandomBool()
    {
        return random.Next(2) == 1;
    }
}