namespace Cm1_Module_3.Class;

public class Student
{
    public string? Name {get; set;}
    public List<Lecturer> PreferredLecturers { get; set; }
    public List<Subjects> SelectedDisciplines  { get; set; }

    public Student (string name, List<Lecturer> preferredLecturers)
    {
        Name = name;
        PreferredLecturers = preferredLecturers;
        SelectedDisciplines = new List<Subjects>();
    }

    public Student()
    {
        PreferredLecturers = new List<Lecturer>();
        SelectedDisciplines = new List<Subjects>();   
    }
    
    public int TotalHours => SelectedDisciplines.Sum(d => d.Hours);


    public void SelectDisciplines(List<Subjects> allDisciplines, int targetHours = 1200)
    {
        SelectedDisciplines.Clear();

        foreach (var lecturer in PreferredLecturers)
        {
            var lecturerDisciplines = new List<Subjects>();
            foreach (var discipline in allDisciplines)
            {
                if (discipline.Lecturer == lecturer)
                    lecturerDisciplines.Add(discipline);
            }

            lecturerDisciplines.Sort((d1, d2) => d2.Hours.CompareTo(d1.Hours));

            foreach (var discipline in lecturerDisciplines)
            {
                bool alreadySelected = false;
                foreach (var selected in SelectedDisciplines)
                {
                    if (selected == discipline)
                    {
                        alreadySelected = true;
                        break;
                    }
                }

                if (!alreadySelected && TotalHours + discipline.Hours <= targetHours)
                {
                    SelectedDisciplines.Add(discipline);
                }
            }
        }

        if (TotalHours < targetHours)
        {
            var programmingDisciplines = new List<Subjects>();
            foreach (var discipline in allDisciplines)
            {
                if (discipline.Name.ToLower().Contains("програмування"))
                {
                    bool alreadySelected = false;
                    foreach (var selected in SelectedDisciplines)
                    {
                        if (selected == discipline)
                        {
                            alreadySelected = true;
                            break;
                        }
                    }

                    if (!alreadySelected)
                        programmingDisciplines.Add(discipline);
                }
            }

            programmingDisciplines.Sort((d1, d2) => d2.Hours.CompareTo(d1.Hours));

            foreach (var discipline in programmingDisciplines)
            {
                if (TotalHours + discipline.Hours <= targetHours)
                {
                    SelectedDisciplines.Add(discipline);
                }
            }
        }

        if (TotalHours != targetHours)
        {
            Console.WriteLine($"Загальна кількість годин ({TotalHours}) не відповідає цільовій ({targetHours}).");
        }
    }

    public void PrintSelectedDisciplines()
    {
        Console.WriteLine($"Вибрані дисципліни для {Name ?? "Student"} (Всього: {TotalHours} годин):");
        foreach (var discipline in SelectedDisciplines)
        {
            Console.WriteLine(discipline.ToString());
        }
    }
}