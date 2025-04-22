namespace Cm1_Lab_5;
public class Syllabus
{
    
    Person author;
    Degree degreeForm;
    string? specialityCode;
    Subject[] subjects;
    
    public Syllabus()
    {

    }
    
    public Syllabus(Person author, Degree degree, string specialityCode, Subject[] subjects)
    {
        this.author = author;
        degreeForm = degree;
        this.specialityCode = specialityCode;
        this.subjects = subjects;
    }
    
    public Person Author
    {
        get { return author; }
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Автор не може бути (null)");
            author = value;
        }
    }

    public Degree DegreeForm
    {
        get { return degreeForm; }
        set
        {
            if (!Enum.IsDefined(typeof(Degree), value))
                throw new ArgumentException("Недопустиме значення для форми навчання");
            degreeForm = value; 
            
        }
    }

    public string SpecialityCode
    {
        get { return specialityCode?? "NoSpecialityCode"; }
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Код не може бути (null)");
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Шифр не може бути порожнім або складатися з пробілів");
            specialityCode = value;
        }
    }

    public Subject[] Subjects
    {
        get { return subjects; }
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Список предметів не може бути null");
            if (Array.IndexOf(value, null) != -1)
                throw new ArgumentException("Список предметів містить null-елементи");
            subjects = value;
        } 
    }
    
    // середнє значення кількості годин усього списку навчальних дисциплін
    public double AverageHours
    {
        get
        {
            if (subjects.Length == 0)
                return 0;

            int totalHours = 0;
            foreach (var subject in subjects)
                totalHours += subject.Hours;

            return (double)totalHours / subjects.Length;
        }
    }
    
    // індексатор логічного типу
    public bool this[Degree degree]
    {
        get { return degreeForm == degree; }
    }
    
    // додавання елементів до списку навчальних дисциплін
    public void AddSubject(params Subject[] newSubjects)
    {
        int oldLength = subjects.Length;
        Array.Resize(ref subjects, oldLength + newSubjects.Length);
        for (int i = 0; i < newSubjects.Length; i++)
            subjects[oldLength + i] = newSubjects[i];
    }
    
    public override string ToString()
    {
        string result = $"Автор: {author}\nФорма навчання: {degreeForm}\nШифр спеціальності: {specialityCode?? "NoSpecialityCode"}\nСписок предметів:";
        foreach (var subject in subjects)
            result += "\n - " + subject.ToString();
        return result;
    }
    
    public string ToShortString()
    {
        return $"Автор: {author.ToShortString()}, Ступінь: {degreeForm}, Шифр: {specialityCode?? "NoSpecialityCode"}, Середній обсяг годин: {AverageHours:F2}";
    }
}