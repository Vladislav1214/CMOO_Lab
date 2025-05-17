using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Text;

namespace Cm1_Lab_9;

class Program
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

    public static void AnalyzeTextFileStatistics()
    {
        string alphabetLowerUkr = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
        string alphabetUpperUkr = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
        string vowels = "аеєиіїоуяю";
        string consonants = "бвгґджзйклмнпрстфхцчшщ";

        Console.Write("Введіть шлях до файлу: ");
        string? filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файла {filePath} не існує");
            return;
        }
        
        try
        {
            string text = File.ReadAllText(filePath);
            
            string[] sentences = text.Split('.', '!', '?')
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToArray();
            int sentenceCount = sentences.Length;
            
            int upperCount = 0;
            int lowerCount = 0;
            int vowelsCount = 0;
            int consonantsCount = 0;
            int digitCount = 0;
            
            foreach (char c in text)
            {
                if (char.IsUpper(c) && alphabetUpperUkr.Contains(c))
                    upperCount++;
                else if (char.IsLower(c) && alphabetLowerUkr.Contains(c))
                    lowerCount++;
                
                char lowerChar = char.ToLower(c);
                if (vowels.Contains(lowerChar))
                    vowelsCount++;
                else if (consonants.Contains(lowerChar))
                    consonantsCount++;
                    
                if (char.IsDigit(c))
                    digitCount++;
            }
            
            Console.WriteLine($"Статистика файлу: {filePath}");
            Console.WriteLine($"Кількість речень: {sentenceCount}");
            Console.WriteLine($"Кількість великих літер: {upperCount}");
            Console.WriteLine($"Кількість малих літер: {lowerCount}");
            Console.WriteLine($"Кількість голосних: {vowelsCount}");
            Console.WriteLine($"Кількість приголосних: {consonantsCount}");
            Console.WriteLine($"Кількість цифр: {digitCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
    
    public static void CensorTextFile()
    {
        Console.Write("Введіть шлях до текстового файлу: ");
        string? textFilePath = Console.ReadLine();
        if (!File.Exists(textFilePath))
        {
            Console.WriteLine($"Файла \"{textFilePath}\" не існує");
            return;
        }
        
        Console.Write("Введіть шлях до файлу зі забороненими словами: ");
        string? bannedWordsFilePath = Console.ReadLine();
        if (!File.Exists(bannedWordsFilePath))
        {
            Console.WriteLine($"Файла \"{bannedWordsFilePath}\" не існує");
            return;
        }
        
        try
        {
            string text = File.ReadAllText(textFilePath);
            string[] bannedWords = File.ReadAllLines(bannedWordsFilePath);


            foreach (string word in bannedWords)
            {
                if (!string.IsNullOrWhiteSpace(word))
                {
                    string censoredWord = new string('*', word.Length);

                    text = Regex.Replace(text, $@"\b{word}\b", censoredWord, RegexOptions.IgnoreCase);
                }
            }

            Console.WriteLine("Введіть шлях для збереження файлу");
            string outputPath = Console.ReadLine();
            
            File.WriteAllText(outputPath, text);
            
            if (File.Exists(outputPath))
                Console.WriteLine($"Цензурований текст збережено у файлі: {outputPath}");
            else
                Console.WriteLine($"Текст не збережено у файлі: {outputPath}");
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    static Song InputSongData()
    {
        Console.Write("Введіть назву пісні: ");
        string title = Console.ReadLine();
        
        Console.Write("Введіть автора пісні: ");
        string author = Console.ReadLine();
        
        Console.Write("Введіть композитора: ");
        string composer = Console.ReadLine();
        
        Console.Write("Введіть рік написання: ");
        int year = int.TryParse(Console.ReadLine(), out int y) ? y : 0;
        
        Console.Write("Введіть текст пісні: ");
        string lyrics = Console.ReadLine();
        
        Console.Write("Введіть кількість виконавців: ");
        int performersCount = int.TryParse(Console.ReadLine(), out int count) ? count : 0;
        
        string[] performers = new string[performersCount];
        for (int i = 0; i < performersCount; i++)
        {
            Console.Write($"Введіть ім'я виконавця {i + 1}: ");
            performers[i] = Console.ReadLine();
        }
        
        return new Song(title, author, composer, year, lyrics, performers);
    }
    
    public static void TestingSongs()
    {
        SongCollection collection = new SongCollection();
        
        bool continueMenu = true;
        while (continueMenu)
        {
            Console.Clear();
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Додати нову пісню");
            Console.WriteLine("2. Видалити пісню");
            Console.WriteLine("3. Оновити інформацію про пісню");
            Console.WriteLine("4. Знайти пісню");
            Console.WriteLine("5. Вивести список пісень");
            Console.WriteLine("6. Вивести деталі про пісню");
            Console.WriteLine("7. Зберегти колекцію у файл");
            Console.WriteLine("8. Завантажити колекцію з файлу");
            Console.WriteLine("9. Знайти пісні за виконавцем");
            Console.WriteLine("10. Зберегти пісню у текстовий файл");
            Console.WriteLine("11. Завантажити пісню з текстового файлу");
            Console.WriteLine("0. Вихід");
            Console.Write("Виберіть опцію: ");
            
            switch (CheckingForANumberIn())
            {
                case 1: // Додати нову пісню
                {
                    Console.WriteLine("Ввести вручну (1)");
                    Console.WriteLine("Згенерувати випадково (2)");
                    Console.Write("Ваш вибір: ");
                    
                    switch (CheckingForANumberIn())
                    {
                        case 1:
                        {
                            Song newSong = InputSongData();
                            collection.AddSong(newSong);
                            break;
                        }
                        case 2:
                        {
                            Song newSong = DataGeneratorSong.CreateRandomSong();
                            collection.AddSong(newSong);
                            break;
                        }
                        default:
                            Console.WriteLine("Невірний вибір");
                            break;
                    }
                    break;
                }
                case 2:
                {
                    Console.Write("Введіть назву пісні для видалення: ");
                    string title = Console.ReadLine();
                    collection.RemoveSong(title);
                    break;
                }
                case 3:
                {
                    Console.Write("Введіть назву пісні для оновлення: ");
                    string title = Console.ReadLine();
                    Song song = collection.GetSong(title);
                    if (song != null)
                    {
                        Console.WriteLine("Введіть нові дані пісні:");
                        Song updatedSong = InputSongData();
                        collection.UpdateSong(title, updatedSong);
                    }
                    else
                    {
                        Console.WriteLine($"Пісню \"{title}\" не знайдено в колекції");
                    }

                    break;
                }
                case 4:
                {
                    Console.WriteLine("Пошук пісень:");
                    Console.WriteLine("1. За назвою");
                    Console.WriteLine("2. За автором");
                    Console.WriteLine("3. За композитором");
                    Console.WriteLine("4. За роком");
                    Console.Write("Виберіть тип пошуку: ");

                    Song[] searchResults = new Song[1];
                    int searchType = int.TryParse(Console.ReadLine(), out int st) ? st : 0;

                    bool flag = false;
                    switch (searchType)
                    {
                        case 1:
                            Console.Write("Введіть назву пісні: ");
                            searchResults = collection.SearchByTitle(Console.ReadLine());
                            flag = true;
                            break;
                        case 2:
                            Console.Write("Введіть автора пісні: ");
                            searchResults = collection.SearchByAuthor((string)Console.ReadLine());
                            flag = true;
                            break;
                        case 3:
                            Console.Write("Введіть композитора: ");
                            searchResults = collection.SearchByComposer(Console.ReadLine());
                            flag = true;
                            break;
                        case 4:
                            Console.Write("Введіть рік: ");
                            int year = int.TryParse(Console.ReadLine(), out int y) ? y : 0;
                            searchResults = collection.SearchByYear(year);
                            flag = true;
                            break;
                        default:
                            Console.WriteLine("Некоректний тип пошуку");
                            break;
                    }

                    if (flag)
                    {
                        if (searchResults.Length > 0)
                        {
                            Console.WriteLine($"Знайдено {searchResults.Length} пісень:");
                            for (int i = 0; i < searchResults.Length; i++)
                            {
                                Console.WriteLine($"{i + 1}. {searchResults[i].Title} ({searchResults[i].Year})");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Пісень за вказаними критеріями не знайдено");
                        }
                    }

                    break;
                }
                case 5: // Вивести список пісень
                {
                    collection.DisplayAllSongs();
                    break;
                }
                case 6: // Вивести деталі про пісню
                {
                    collection.DisplayAllSongs();
                    Console.Write("Введіть номер пісні для перегляду деталей: ");
                    int index = int.TryParse(Console.ReadLine(), out int idx) ? idx - 1 : -1;
                    collection.DisplaySongDetails(index);
                    break;
                }
                case 7:
                {
                    Console.Write("Введіть шлях до файлу для збереження колекції: ");
                    string filePath = Console.ReadLine();
                    collection.SaveToFile(filePath);
                    break;
                }
                case 8:
                {
                    Console.Write("Введіть шлях до файлу для завантаження колекції: ");
                    string filePath = Console.ReadLine();
                    collection.LoadFromFile(filePath);
                    break;
                }
                case 9:
                {
                    Console.Write("Введіть ім'я виконавця: ");
                    string performer = Console.ReadLine();
                    Song[] performerSongs = collection.SearchByPerformer(performer);

                    if (performerSongs.Length > 0)
                    {
                        Console.WriteLine($"Пісні, які виконує {performer}:");
                        foreach (var song in performerSongs)
                        {
                            Console.WriteLine(song);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Не знайдено пісень, які виконує {performer}");
                    }

                    break;
                }
                case 10:
                {
                    Console.Write("Введіть назву пісні для збереження: ");
                    string title = Console.ReadLine();
                    Song song = collection.GetSong(title);

                    if (song != null)
                    {
                        Console.Write("Введіть шлях до файлу: ");
                        string filePath = Console.ReadLine();
                        collection.SaveSongToTextFile(song, filePath);
                    }
                    else
                    {
                        Console.WriteLine($"Пісню \"{title}\" не знайдено в колекції");
                    }

                    break;
                }
                case 11:
                {
                    Console.Write("Введіть шлях до файлу: ");
                    string filePath = Console.ReadLine();

                    Song loadedSong = collection.LoadSongFromTextFile(filePath);
                    if (loadedSong != null)
                    {
                        Console.WriteLine("Завантажена пісня:");
                        Console.WriteLine(loadedSong);
                        Console.Write("Бажаєте додати цю пісню до колекції? (Так/Ні): ");
                        string answer = Console.ReadLine();
                        if (answer.Equals("Так", StringComparison.OrdinalIgnoreCase))
                        {
                            collection.AddSong(loadedSong);
                        }
                    }

                    break;
                }
                case 0:
                {
                    Console.WriteLine("Завершення роботи програми");
                    continueMenu = false;
                    break;
                }
                default:
                    Console.WriteLine("Невірний вибір, спробуйте ще раз");
                    break;
            }

            Console.WriteLine("Натисніть (Enter)");
            Console.ReadKey();
        }
    }


    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        bool menu = true;
        while (menu)
        {
            switch (CheckingForANumberIn())
            {
                case 1:
                {
                    

                    AnalyzeTextFileStatistics();
                    break;
                }
                case 2:
                {
                    Console.Clear();
                    CensorTextFile();
                    break;
                }
                case 3:
                {
                    TestingSongs();
                    break;
                }
                case 0:
                {
                    Console.WriteLine("Завершення роботи програми");
                    menu = false;
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
}