namespace Cm1_Lab_9;

public class SongCollection
{
    private Song[] songs;
    private int count;
    private const int INITIAL_SIZE = 10;

    public SongCollection()
    {
        songs = new Song[INITIAL_SIZE];
        count = 0;
    }

    public int Count
    {
        get { return count; }
    }

    private void EnsureCapacity()
    {
        if (count == songs.Length)
        {
            Song[] newArray = new Song[songs.Length + 5];
            for (int i = 0; i < songs.Length; i++)
                newArray[i] = songs[i];

            songs = newArray;
        }
    }

    public void AddSong(Song song)
    {
        EnsureCapacity();
        songs[count] = song;
        count++;
        Console.WriteLine($"Пісню \"{song.Title}\" додано до колекції");
    }

    public bool RemoveSong(string title)
    {
        for (int i = 0; i < count; i++)
            if (songs[i].Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                for (int j = i; j < count - 1; j++)
                    songs[j] = songs[j + 1];

                songs[count - 1] = null;
                count--;
                Console.WriteLine($"Пісню \"{title}\" видалено з колекції");
                return true;
            }

        Console.WriteLine($"Пісню \"{title}\" не знайдено в колекції");
        return false;
    }

    public Song GetSong(string title)
    {
        for (int i = 0; i < count; i++)
            if (songs[i].Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                return songs[i];

        return null;
    }

    public void UpdateSong(string title, Song updatedSong)
    {
        for (int i = 0; i < count; i++)
            if (songs[i].Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                songs[i] = updatedSong;
                Console.WriteLine($"Інформацію про пісню \"{title}\" оновлено");
                return;
            }
        

        Console.WriteLine($"Пісню \"{title}\" не знайдено в колекції");
    }

    private Song[] FilterSongs(Func<Song, bool> predicate)
    {
        int matchCount = 0;
        for (int i = 0; i < count; i++)
            if (predicate(songs[i]))
                matchCount++;
        
        Song[] result = new Song[matchCount];
        
        int index = 0;
        for (int i = 0; i < count; i++)
            if (predicate(songs[i]))
                result[index++] = songs[i];

        return result;
    }

    public Song[] SearchByTitle(string title)
    {
        return FilterSongs(song => song.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0);
    }
    
    public Song[] SearchByAuthor(string author)
    {
        return FilterSongs(song => song.Author.IndexOf(author, StringComparison.OrdinalIgnoreCase) >= 0);
    }

    public Song[] SearchByComposer(string composer)
    {
        return FilterSongs(song => song.Composer.IndexOf(composer, StringComparison.OrdinalIgnoreCase) >= 0);
    }

    public Song[] SearchByYear(int year)
    {
        return FilterSongs(song => song.Year == year);
    }

    public Song[] SearchByPerformer(string performer)
    {
        return FilterSongs(song =>
        {
            foreach (string songsPerformers in song.Performers)
                if (songsPerformers.IndexOf(performer, StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;
                
            return false;
        });
    }
    
    public void SaveToFile(string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(count);

                for (int i = 0; i < count; i++)
                {
                    Song song = songs[i];
                    writer.WriteLine(song.Title);
                    writer.WriteLine(song.Author);
                    writer.WriteLine(song.Composer);
                    writer.WriteLine(song.Year);
                    writer.WriteLine(song.Lyrics);
                    
                    writer.WriteLine(song.Performers.Length);
                    for (int j = 0; j < song.Performers.Length; j++)
                        writer.WriteLine(song.Performers[j]);
                }
            }

            Console.WriteLine($"Колекцію пісень збережено у файл: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при збереженні у файл: {ex.Message}");
        }
    }

    public void LoadFromFile(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл {filePath} не існує");
                return;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                if (!int.TryParse(reader.ReadLine(), out int songCount))
                {
                    Console.WriteLine("Помилка формату файлу");
                    return;
                }
                
                songs = new Song[Math.Max(songCount, INITIAL_SIZE)];
                count = 0;

                for (int i = 0; i < songCount; i++)
                {
                    if (reader.EndOfStream)
                        break;
                    
                    string title = reader.ReadLine();
                    string author = reader.ReadLine();
                    string composer = reader.ReadLine();
                    int year = Convert.ToInt32(reader.ReadLine());
                    string lyrics = reader.ReadLine();
                    
                    int performersCount = Convert.ToInt32(reader.ReadLine());
                    string[] performers = new string[performersCount];

                    for (int j = 0; j < performersCount; j++)
                    {
                        performers[j] = reader.ReadLine();
                    }

                    Song song = new Song(title, author, composer, year, lyrics, performers);
                    AddSong(song);
                }
            }

            Console.WriteLine($"Колекцію пісень завантажено з файлу: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при завантаженні з файлу: {ex.Message}");
        }
    }

    public void SaveSongToTextFile(Song song, string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файла \"{filePath}\" не існує"); 
            return;
        }
        
        try
        {
            string songContentText =
                $"Назва:{song.Title}." +
                $"Автор:{song.Author}." +
                $"Композитор:{song.Composer}." +
                $"Рік:{song.Year}." +
                $"Текст:{song.Lyrics}." +
                "Виконавці:";

            foreach (string performer in song.Performers)
                songContentText += $"{performer},";

            File.WriteAllText(filePath, songContentText);
            Console.WriteLine($"Пісню збережено у файл: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при збереженні у файл: {ex.Message}");
        }
    }

    public Song LoadSongFromTextFile(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл {filePath} не існує");
                return null;
            }

            string fileContent = File.ReadAllText(filePath);
            string[] sentences = fileContent.Split(".", StringSplitOptions.RemoveEmptyEntries);

            Song song = new Song();

            song.Title = sentences[0].Split(":")[1];
            song.Author = sentences[1].Split(":")[1];
            song.Composer = sentences[2].Split(":")[1];
            song.Year = Convert.ToInt32(sentences[3].Split(":")[1]);
            song.Lyrics = sentences[4].Split(":")[1];

            string performersText = sentences[5].Split(":")[1];
            song.Performers = performersText.Split(',', StringSplitOptions.RemoveEmptyEntries);

            return song;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при завантаженні з файлу: {ex.Message}");
            return null;
        }
    }

    public void DisplayAllSongs()
    {
        if (count == 0)
        {
            Console.WriteLine("Колекція пісень порожня");
            return;
        }

        Console.WriteLine("Список пісень у колекції:");
        for (int i = 0; i < count; i++)
            Console.WriteLine($"{i + 1}. {songs[i].Title}. Автор: {songs[i].Author} ({songs[i].Year})");
    }

    public void DisplaySongDetails(int index)
    {
        if (index >= 0 && index < count)
            Console.WriteLine(songs[index].ToString());
        else
            Console.WriteLine("Некоректний індекс пісні");
    }
}