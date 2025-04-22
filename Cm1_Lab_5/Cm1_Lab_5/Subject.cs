using System.Text.RegularExpressions;

namespace Cm1_Lab_5;
public enum Degree
{
    Specialist,
    Bachelor,  
    Magistr
}
public class Subject
{
    public string name { get; set; } = "NoName";
    public int hours { get; set; }
    public DateTime examDate { get; set; } = DateTime.Now;
    
    
    /*string? name;  //{name?? "NoName"}
    int hours;
    DateTime examDate; */
    
    public Subject(string name, int hours, DateTime examDate)
    {
        this.name = name;
        this.hours = hours;
        this.examDate = examDate;
    }

    public Subject() { }
    
    public string Name
    {
        get { return name; } 
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && Regex.IsMatch(value, Person.pattern))
                name = value;
        }
    }

    public int Hours
    {
        get { return hours; }
        set
        {
            if (value > 0)
                hours = value;
        }
    }

    public DateTime ExamDate
    {
        get { return examDate; }
        set
        {
            if (value > DateTime.Now)
                examDate = value;
        }
    }
    
    public override string ToString()
    {
        return $"Предмет: {name}, Години: {hours}, Дата заліку: {examDate.ToShortDateString()}";
    }
    
}