namespace Cm1_Module_3.Class;

public class Subjects
{
    string? _name;
    int _hours;
    Lecturer _lecturer;
    
    public Subjects(string? name, int hours, Lecturer lecturer)
    {
        _name = name;
        Hours = hours;
        _lecturer = lecturer;
    }

    public Subjects()
    {
        _lecturer = new Lecturer();
    }
    
    public string Name
    {
        get { return _name ?? "NoSubjectName";}   
        set { _name = value; }
    }
    
    public int Hours
    {
        get { return _hours; }
        set
        {
            if (value % 30 != 0 && value < 0) 
                throw new ArgumentException("Кількість годин повинна бути кратна 30 та більше 0");
            _hours = value;
        }
    }

    public Lecturer Lecturer
    {
        get { return _lecturer; }
        set { _lecturer = value; }
    }
    
    public override string ToString() => $"{Name} ({_hours} годин), Викладач: {_lecturer.Name}";
}