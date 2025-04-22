namespace Cm1_Lab_6;

public class Schoolboy
{
    private string? fullName;
    private string? schoolName;
    private string? className;
    private int[] grades;

    public Schoolboy()
    {
        
    }

    public Schoolboy(string fullName, string schoolName, string className, int[] grades)
    {
        this.fullName = fullName;
        this.schoolName = schoolName;
        this.className = className;
        this.grades = grades;
    }

    public string FullName
    {   
        get { return fullName?? "NoFullName"; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Не може бути (null).");
            fullName = value;
        }
    }

    public string SchoolName
    {
        get { return schoolName ?? "NoSchoolName"; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Не може бути (null).");
            schoolName = value;
        }
    }

    public string ClassName
    {
        get { return className ?? "NoClassName"; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Не може бути (null).");
            className = value;
        }
    }

    public int[] Grades
    {
        get { return grades; }
        set
        {
            if (value == null || value.Length == 0)
                throw new ArgumentException("Не може бути (null).");
            grades = value;
        }
    }

    public void ChangeSchool(string newSchool)
    {
        if (string.IsNullOrEmpty(newSchool))
            throw new ArgumentException("Назва школи не може бути пустою.");
        SchoolName = newSchool;
    }

    public void ChangeGrades(int[] newGrades)
    {
        Grades = newGrades;
    }

    public virtual double GetAverageGrade()
    {
        if (grades == null || grades.Length == 0) 
            return 0.0;
        double sum = 0;
        foreach (int grade in grades)
            sum += grade;
        return sum / grades.Length;
    }

    public override string ToString()
    {
        return $"Школяр: {FullName}, Школа: {SchoolName}, Клас: {ClassName}, Середній бал: {GetAverageGrade():F2}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Schoolboy other)
        {
            return fullName == other.fullName &&
                   schoolName == other.schoolName &&
                   className == other.className;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FullName, SchoolName, ClassName);
    }
}
