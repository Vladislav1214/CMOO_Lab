namespace Cm1_Lab_6;
public class UniversityStudent : Schoolboy
{
    private int yearOfAdmission;
    private string? studyDirection;

    public UniversityStudent()
    {
        
    }

    public UniversityStudent(string fullName, string universityName, string studyDirection, int yearOfAdmission, int[] grades)
        : base(fullName, universityName, "N/A", grades)
    {
        this.yearOfAdmission = yearOfAdmission;
        this.studyDirection = studyDirection;
    }

    public int YearOfAdmission
    {
        get { return yearOfAdmission; }
        set { yearOfAdmission = value; }
    }

    public string? StudyDirection
    {
        get { return studyDirection?? "NoStudyDirection" ; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Не може бути (null).");
            studyDirection = value;
        }
    }

    public override double GetAverageGrade()
    {
        // Підвищений коефіцієнт (приклад роботи віртуального методу)
        double baseAverage = base.GetAverageGrade();
        return baseAverage + 0.1; // Наприклад, бонус за складність
    }

    public override string ToString()
    {
        return $"Студент: {FullName}, Університет: {SchoolName}, Напрям: {StudyDirection}, Рік вступу: {YearOfAdmission}, Середній бал: {GetAverageGrade():F2}";
    }

    public override bool Equals(object obj)
    {
        if (obj is UniversityStudent other)
        {
            return base.Equals(other) &&
                   yearOfAdmission == other.yearOfAdmission &&
                   studyDirection == other.studyDirection;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), yearOfAdmission, studyDirection);
    }
}
