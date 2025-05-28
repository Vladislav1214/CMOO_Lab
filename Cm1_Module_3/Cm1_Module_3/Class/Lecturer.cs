namespace Cm1_Module_3.Class;

public class Lecturer
{
    string? _name;
    public List<Subjects> Disciplines { get; set; } 

    public Lecturer(string name)
    {
        _name = name;
        Disciplines = new List<Subjects>();
    }

    public Lecturer ()
    {
        Disciplines = new List<Subjects>();
    }
    
    public string Name
    {
        get { return _name ?? "Lecturer"; }
        set { _name = value; }
    }
}