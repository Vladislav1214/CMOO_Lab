namespace Cm1_Lab_6;

public class Schoolboy
{
    private string? fullName;
    private string? educationalInstitutionName;
    private string? groupName;
    private int[] grades;
    
    public Schoolboy(string fullName, string educationalInstitutionName, string groupName, int[] grades)
    {
        this.fullName = fullName;
        this.educationalInstitutionName = educationalInstitutionName;
        this.groupName = groupName;
        this.grades = grades;
    }
    
    public Schoolboy()
    {
        
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

    public string EducationalInstitutionName
    {
        get { return educationalInstitutionName ?? "NoSchoolName"; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Не може бути (null).");
            educationalInstitutionName = value;
        }
    }

    public string GroupName
    {
        get { return groupName ?? "NoClassName"; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Не може бути (null).");
            groupName = value;
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
        EducationalInstitutionName = newSchool;
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
        return $"Школяр: {FullName}, Школа: {EducationalInstitutionName}, Клас: {GroupName}, Середній бал: {GetAverageGrade():F2}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Schoolboy other)
        {
            return fullName == other.fullName &&
                   educationalInstitutionName == other.educationalInstitutionName &&
                   groupName == other.groupName;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FullName, EducationalInstitutionName, GroupName);
    }
}
