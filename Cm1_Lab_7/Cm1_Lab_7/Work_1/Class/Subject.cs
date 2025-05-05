using System.Text.RegularExpressions;

namespace Cm1_Lab_7;
public enum Degree
{
    Specialist,
    Bachelor,  
    Magistr
}

public class Subject : IComparable, IComparable<Subject>, ICloneable
{
    string? _name;
    int _hours;
    DateTime _examDate;
    
    public Subject(string name, int hours, DateTime examDate)
    {
        _name = name;
        _hours = hours;
        _examDate = examDate;
    }

    public Subject()
    {
        
    }

    public int CompareTo(Object obj)
    {
        if (obj == null) 
            return 1;
        
        Subject subj = obj as Subject;
        
        if (subj == null)
            throw new ArgumentException("Object is not a Subject");
        
        int nameComp = Name.CompareTo(subj.Name);
        if (nameComp != 0) 
            return nameComp;

        int dateComp = ExamDate.CompareTo(subj.ExamDate);
        if (dateComp != 0) 
            return dateComp;

        return Hours.CompareTo(subj.Hours);
    }

    public int CompareTo(Subject subj)
    {
        if (subj == null) return 1;

        int nameCompare = Name.CompareTo(subj.Name);
        if (nameCompare != 0) return nameCompare;

        int dateCompare = ExamDate.CompareTo(subj.ExamDate);
        if (dateCompare != 0) return dateCompare;

        return Hours.CompareTo(subj.Hours); 
    }
    
    public Object Clone()
    {
        return new Subject(Name, Hours, ExamDate);
    }
    
    public string Name
    {
        get { return _name ?? "NoName"; } 
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && Regex.IsMatch(value, Person.Pattern))
                _name = value;
        }
    }

    public int Hours
    {
        get { return _hours; }
        set
        {
            if (value > 0)
                _hours = value;
        }
    }

    public DateTime ExamDate
    {
        get { return _examDate; }
        set
        {
            if (value > DateTime.Now)
                _examDate = value;
        }
    }
    
    public override string ToString()
    {
        return $"Предмет: {Name}, Дата заліку: {ExamDate.ToString("dd.MM.yyyy")}, Години: {Hours}";
    }
    
    // Повертає предмет із найбільшою кількістю годин
    public static Subject GetMostLoadedSubject(Syllabus syllabus)
    {
        if (syllabus.Subjects.Length == 0)
            throw new ArgumentException("null");

        Subject max = syllabus.Subjects[0];

        foreach (var subject in syllabus.Subjects)
            if (subject.Hours > max.Hours)
                max = subject;

        return max;
    }
    
    // Повертає масив предметів, які є у двох навчальних планах
    public static Subject[] GetCommonSubjects(Syllabus a, Syllabus b)
    {
        // Максимальна кількість спільних предметів — довжина меншого масиву
        
        int maxLength = a.Subjects.Length > b.Subjects.Length ? a.Subjects.Length : b.Subjects.Length;
        int minLength = a.Subjects.Length < b.Subjects.Length ? a.Subjects.Length : b.Subjects.Length;
        
        Syllabus min = a.Subjects.Length < b.Subjects.Length ? a : b;
        Syllabus max = a.Subjects.Length > b.Subjects.Length ? a : b;
        
        Subject[] temp = new Subject[minLength];
        int count = 0;

        for (int i = 0; i < minLength; i++)
        for (int j = 0; j < maxLength; j++) 
            if (min.Subjects[i].Name == max.Subjects[j].Name)
            {
                temp[count++] = min.Subjects[i];
                break;
            }
        
        Subject[] result = new Subject[count];
        for (int i = 0; i < count; i++)
            result[i] = temp[i];

        return result;
    }
}