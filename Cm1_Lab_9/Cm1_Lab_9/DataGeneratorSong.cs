namespace Cm1_Lab_9;

public class DataGeneratorSong
{
    private static readonly Random random = new Random();
    
    private static readonly string[] Titles =
    {
        "Океан мрій", "Сонячний промінь", "Зоряна ніч", "Весняний вітер",
        "Шлях додому", "Мелодія серця", "Танець душі", "Спогади минулого",
        "Тиха гавань", "Пісня дощу", "Сила кохання", "Вільний птах",
        "Міські вогні", "Легенда гір", "Річковий потік", "Світанок надії"
    };

    private static readonly string[] Authors =
    {
        "Тарас Шевченко", "Іван Франко", "Леся Українка", "Ліна Костенко",
        "Василь Стус", "Сергій Жадан", "Оксана Забужко", "Андрій Малишко",
        "Юрій Андрухович", "Марія Матіос", "Олександр Ірванець", "Грицько Чубай"
    };

    private static readonly string[] Composers =
    {
        "Микола Лисенко", "Володимир Івасюк", "Мирослав Скорик", "Платон Майборода",
        "Олександр Білаш", "Ігор Поклад", "Анатолій Кос-Анатольський", "Володимир Верменич",
        "Євген Станкович", "Богдана Фроляк", "Валентин Сильвестров", "Іван Карабиць"
    };

    private static readonly string[] Performers =
    {
        "Океан Ельзи", "ДахаБраха", "Христина Соловій", "ONUKA",
        "Джамала", "Скрябін", "Тіна Кароль", "Іван Дорн",
        "Бумбокс", "The Hardkiss", "Друга Ріка", "Воплі Відоплясова",
        "Один в каное", "Плач Єремії", "KAZKA", "Go_A"
    };

    private static readonly string[] Lyrics =
    {
        "Коли тебе нема, я сам не свій...",
        "Зорі падають в траву, тихо лине спів...",
        "За вікном весна, а на серці зима...",
        "Ми разом йдемо крізь тумани і дощі...",
        "Кожна мить - це нова історія...",
        "Промінь сонця торкнувся землі...",
        "Чуєш, як шепоче вітер твоє ім'я...",
        "Світ навколо нас змінюється щомиті..."
    };
    
    private static string[] _availableTitles = Titles; 
    
    public static Song CreateRandomSong()
    {
        string title = GetRandomTitles();
        string author =  Authors[random.Next(Authors.Length)];
        string composer = Composers[random.Next(Composers.Length)];
        int year = random.Next(1950, DateTime.Now.Year - 1);
        string lyric = Lyrics[random.Next(Lyrics.Length)];
        
        int performersCount = random.Next(2, 5);
        string[] performer = new string[performersCount];
        for (int i = 0; i < performersCount; i++) 
            performer[i] = Performers[random.Next(Performers.Length)];

        return new Song(title, author, composer, year, lyric, performer);
    }
    
    private static string GetRandomTitles()
    {
        string result;

        if (_availableTitles.Length == 0)
        {
            result = $"Пісня {random.Next(1000).ToString()}";
        }
        else
        {
            int index = random.Next(_availableTitles.Length);
            result = _availableTitles[index];
            
            string[] lor = new string[_availableTitles.Length - 1];
            for (int i = 0; i < index; i++)
                lor[i] = _availableTitles[i];
            for (int i = index; i < _availableTitles.Length - 1; i++)
                lor[i] = _availableTitles[i + 1];
            _availableTitles = lor;
        }

        return result;
    }

    public static Song[] CreateRandomSongs(int count)
    {
        Song[] songs = new Song[count];

        for (int i = 0; i < count; i++)
        {
            songs[i] = CreateRandomSong();
        }

        return songs;
    }
}