using System.Text;
using Cm1_Lab_8.DataGenerator;
using Cm1_Lab_8.Class;

namespace Cm1_Lab_8;

public class Program
{
    public static int CheckingForANumberIn()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int number))
                return number;
            
            Console.Write("Введіть повторно: ");
        }
    }
    
    public static double CheckingForNumberDoubleIn()
    {
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double number))
                return number;
            
            Console.Write("Введіть повторно: ");
        }
    }
    
    public static int[] RandomArrNumbers()
    {
        Random random = new Random();
        
        int[] arr = new int[random.Next(5, 20)];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(-50, 51);
        }
        return arr;
    }
    
    // Час
    public static Action ShowCurrentTime = () =>
        Console.WriteLine(DateTime.Now.TimeOfDay.ToString("hh\\:mm\\:ss"));

    // Дата
    public static Action ShowCurrentDate = () =>
        Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));

    // День тижня
    public static Action ShowCurrentDayOfWeek = () =>
        Console.WriteLine(DateTime.Now.DayOfWeek.ToString());

    // Просте число
    public static Predicate<int> IsPrime = n =>
    {
        if (n > 1)
            for (uint i = 2; i < n; i++)
                if (n % i == 0)
                    return false;
        return true;
    };

    // Число Фібоначчі
    public static Predicate<int> IsFibonacci = n =>
    {
        int a = 0, b = 1;
        while (b < n) (a, b) = (b, a + b);
        return n == b || n == 0;
    };

    // Площа трикутника
    public static Func<double, double, double> CalculateTriangleArea = (baseLength, height) =>
        0.5 * baseLength * height;

    // Площа прямокутника
    public static Func<double, double, double> CalculateRectangleArea = (width, height) =>
        width * height;
    
    // Кількість чисел, кратних 7
    public static Func<int[], int> CountDivisibleBySeven = (numbers) =>
    {
        int count = 0;
        foreach (var number in numbers)
        {
            if (number % 7 == 0)
                count++;
        }
        return count;
    };

    // Кількість позитивних чисел
    public static Func<int[], int> CountPositiveNumbers = (numbers) =>
    {
        int count = 0;
        foreach (var number in numbers)
        {
            if (number > 0)
                count++;
        }
        return count;
    };

    // Чи сьогодні день програміста (256-й день року)
    public static Action CheckIfProgrammersDay = () =>
    {
        Console.WriteLine("День програміста" + (DateTime.Now.DayOfYear == 256 ? "" : " не") + " сьогодні");
    };

    // Перевірка, чи є задане слово в тексті 
    public static Func<string?, string?, bool> ContainsExactWord = (text, word) =>
    {
        if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(word))
            return false;

        word = word.ToLower();
        string[] words = text.ToLower().Split();

        foreach (var currentWord in words)
            if (currentWord == word)
                return true;

        return false;
    };

    // Перевірка, чи містить текст хоча б одне слово з масиву слів
    public static Func<string?, string[]?, bool> ContainsAnyWord = (text, wordArray) =>
    {
        if (string.IsNullOrWhiteSpace(text) || wordArray == null)
            return false;

        foreach (var word in wordArray)
        {
            if (ContainsExactWord(text, word))
                return true;
        }

        return false;
    };

    static void RunTimeAndCalculationMenu()
    {
        bool submenu = true;
        while (submenu)
        {
            Console.Clear();
            Console.WriteLine("=== Меню дій ===");
            Console.WriteLine("1 – Поточний час");
            Console.WriteLine("2 – Поточна дата");
            Console.WriteLine("3 – День тижня");
            Console.WriteLine("4 – Перевірка на просте число");
            Console.WriteLine("5 – Перевірка на число Фібоначчі");
            Console.WriteLine("6 – Площа трикутника");
            Console.WriteLine("7 – Площа прямокутника");
            Console.WriteLine("0 – Повернутись назад");
            Console.Write("Ваш вибір: ");

            switch (CheckingForANumberIn())
            {
                case 1: ShowCurrentTime(); break;
                case 2: ShowCurrentDate(); break;
                case 3: ShowCurrentDayOfWeek(); break;
                case 4:
                    Console.Write("Введіть число: ");
                    Console.WriteLine(IsPrime(CheckingForANumberIn()) ? "Просте" : "Складене");
                    break;
                case 5:
                    Console.Write("Введіть число: ");
                    Console.WriteLine(IsFibonacci(CheckingForANumberIn()) ? "Фібоначчі" : "Не Фібоначчі");
                    break;
                case 6:
                    Console.Write("Основа: ");
                    int baseL = CheckingForANumberIn();
                    Console.Write("Висота: ");
                    int h = CheckingForANumberIn();
                    Console.WriteLine($"Площа: {CalculateTriangleArea(baseL, h)}");
                    break;
                case 7:
                    Console.Write("Ширина: ");
                    int w = CheckingForANumberIn();
                    Console.Write("Висота: ");
                    int ht = CheckingForANumberIn();
                    Console.WriteLine($"Площа: {CalculateRectangleArea(w, ht)}");
                    break;
                case 0:
                    submenu = false;
                    break;
                default:
                    Console.WriteLine("Невірний вибір");
                    break;
            }

            Console.WriteLine("Продовження (Enter)");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void RunSuitcaseMenu()
    {
        Console.Clear();
        Suitcase suitcase = DataGeneratorSuitcase.DataGeneratorRandomSuitcase();
        suitcase.ItemAdded += (item) => Console.WriteLine($"Додано новий предмет {item.Name}");
        suitcase.ItemRemoved += (item) => Console.WriteLine($"Видалено предмет: {item.Name}");
        
        Console.WriteLine("Створено валізу:");
        Console.WriteLine(suitcase);
        Console.WriteLine();

        bool submenu = true;
        while (submenu)
        {
            Console.WriteLine("=== Меню взаємодії з валізою ===");
            Console.WriteLine("1 – Додати предмет випадково");
            Console.WriteLine("2 – Додати предмет вручну");
            Console.WriteLine("3 – Видалити предмет за індексом");
            Console.WriteLine("4 – Додати випадкові предмети (до заповнення)");
            Console.WriteLine("5 – Переглянути вміст валізи");
            Console.WriteLine("6 – Очистити валізу");
            Console.WriteLine("7 – Показати інформацію про валізу");
            Console.WriteLine("0 – Повернутись назад");
            Console.Write("Ваш вибір: ");

            switch (CheckingForANumberIn())
            {
                case 1:
                {
                    try
                    {
                        Item randomItem = DataGeneratorItem.DataGeneratorRandomItem();
                        suitcase.AddItem(randomItem);
                    }
                    catch (VolumeExceededException ex)
                    {
                        Console.WriteLine($"Помилка: {ex.Message}");
                    }
                    
                    break;
                }
                case 2:
                {
                    try
                    {
                        Console.Write("Назва предмета: ");
                        string? name = Console.ReadLine();
                        Console.Write("Об’єм предмета: ");
                        double volume = CheckingForNumberDoubleIn();
                        Item manualItem = new Item(name, volume);
                        suitcase.AddItem(manualItem);
                    }
                    catch (VolumeExceededException ex)
                    {
                        Console.WriteLine($"Помилка: {ex.Message}");
                    }

                    break;
                }
                case 3:
                {
                    if (suitcase.Items.Count == 0)
                    {
                        Console.WriteLine("Валіза порожня.");
                        break;
                    }
                    Console.Write("Введіть індекс предмета для видалення: ");
                    int index = CheckingForANumberIn();
                    if (!suitcase.RemoveItemByIndex(index))
                    {
                        Console.WriteLine("Невірний індекс.");
                    }

                    break;
                }
                
                case 4:
                {
                    try
                    {
                        while(true)
                        {
                            Item randomItem = DataGeneratorItem.DataGeneratorRandomItem();
                            suitcase.AddItem(randomItem);
                        }
                    }
                    catch (VolumeExceededException ex)
                    {
                        Console.WriteLine($"Помилка: {ex.Message}");
                    }

                    break;
                }
                case 5:
                {
                    Console.WriteLine("Вміст валізи:");
                    foreach (var item in suitcase.Items)
                    {
                        Console.WriteLine($"- {item}");
                    }

                    break;
                }
                case 6:
                {
                    suitcase.Clear();
                    Console.WriteLine("Валізу очищено.");
                    break;
                }
                case 7:
                {
                    Console.WriteLine("Інформація про валізу:");
                    Console.WriteLine(suitcase);
                    break;
                }
                case 0:
                {
                    submenu = false;
                    break;
                }
                default:
                    Console.WriteLine("Невірний вибір");
                    break;
            }

            Console.WriteLine("Продовження (Enter)");
            Console.ReadKey();
            Console.Clear();
        }

    }


    static void RunArrayAndTextAnalysisMenu()
    {
        Console.Clear();
        bool submenu = true;
        while (submenu)
        {
            Console.WriteLine("\nОберіть дію:");
            Console.WriteLine("1 - Підрахунок чисел, кратних 7");
            Console.WriteLine("2 - Підрахунок позитивних чисел");
            Console.WriteLine("3 - Чи сьогодні день програміста");
            Console.WriteLine("4 - Перевірка наявності слова в тексті");
            Console.WriteLine("5 - Перевірка наявності хоча б одного слова з масиву");
            Console.WriteLine("0 – Повернутись назад");
            Console.Write("Ваш вибір: ");

            switch (CheckingForANumberIn())
            {
                case 1:
                {

                    int[] numbers = RandomArrNumbers();
                    Console.WriteLine("Кількість чисел, кратних 7: " + CountDivisibleBySeven(numbers));
                    break;
                }
                case 2:
                {
                    int[] numbers = RandomArrNumbers();
                    Console.WriteLine("Кількість позитивних чисел: " + CountPositiveNumbers(numbers));
                    break;
                }
                case 3:
                {
                    CheckIfProgrammersDay();
                    break;
                }
                case 4:
                {
                    Console.Write("Введіть текст: ");
                    string? text = Console.ReadLine();
                    Console.Write("Введіть слово для пошуку: ");
                    string? word = Console.ReadLine();

                    Console.WriteLine("Слово" + (ContainsExactWord(text, word) ? " " : " не") + " знайдено");
                    break;
                }
                case 5:
                {
                    Console.Write("Введіть текст: ");
                    string? text = Console.ReadLine();
                    Console.Write("Введіть слова для пошуку (через пробіл): ");
                    string? wordsLine = Console.ReadLine();
                    string[]? words = wordsLine?.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    Console.WriteLine(ContainsAnyWord(text, words)
                        ? "Є хоча б одн збіг"
                        : "Збігів немає");
                    break;
                }
                case 0:
                {
                    submenu = false;
                    break;
                }
                default:
                    Console.WriteLine("Невірний вибір");
                    break;
            }

            Console.WriteLine("Продовження (Enter)");
            Console.ReadKey();
            Console.Clear();
        }
    }
    


    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        bool mainLoop = true;
        while (mainLoop)
        {
            Console.WriteLine("==== Головне меню ====");
            Console.WriteLine("1 – Робота з датою/часом та обчисленнями");
            Console.WriteLine("2 – Робота з валізою");
            Console.WriteLine("3 – Робота з масивами, словами та перевірками");
            Console.WriteLine("0 – Вихід");
            Console.Write("Ваш вибір: ");
            
            switch (CheckingForANumberIn())
            {
                case 1:
                {
                    RunTimeAndCalculationMenu();
                    break;
                }
                case 2:
                {
                    RunSuitcaseMenu();
                    break;
                }
                case 3:
                {
                    RunArrayAndTextAnalysisMenu();
                    break;
                }
                case 0:
                {
                    Console.WriteLine("Завершення програми...");
                    mainLoop = false;
                    break;
                }
                default:
                {
                    Console.WriteLine("Невірний вибір");
                    break;
                }
            }
        }
    }
}