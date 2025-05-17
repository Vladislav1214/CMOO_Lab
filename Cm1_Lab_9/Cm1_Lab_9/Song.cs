namespace Cm1_Lab_9;

public class Song
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Composer { get; set; }
    public int Year { get; set; }
    public string Lyrics { get; set; }

    public string[] Performers { get; set; }
    
    public Song()
    {
        Title = "NoTitle";
        Author = "NoAuthor";
        Composer = "NoComposer";
        Year = 0;
        Lyrics = "NoLyrics";
        Performers = new string[1];
        Performers[0] = "NoPerformer";
    }

    public Song(string title, string author, string composer, int year, string lyrics, string[] performers)
    {
        Title = title;
        Author = author;
        Composer = composer;
        Year = year;
        Lyrics = lyrics;
        Performers = performers;
    }
    
    public override string ToString()
    {
        return $"{Title} ({Year}) - {Author}, {Composer}\n" +
               $"Виконавці: {string.Join(", ", Performers)}\n" +
               $"Текст: {Lyrics}\n";
    }
}