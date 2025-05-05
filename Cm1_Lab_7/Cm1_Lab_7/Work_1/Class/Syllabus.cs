namespace Cm1_Lab_7;
public class Syllabus  : IFileContainer, IEnumerable, IEnumerator
{
    
    Person _author;
    Degree _degreeForm;
    string? _specialityCode;
    Subject[] _subjects;
    bool _isDataSaved;
    int _position = -1;
    
    
    public Syllabus()
    {
        _author = new Person();
        _subjects = Array.Empty<Subject>();
    }
    
    public Syllabus(Person author, Degree degree, string specialityCode, Subject[] subjects)
    {
        _author = author;
        _degreeForm = degree;
        _specialityCode = specialityCode;
        _subjects = subjects;
        _isDataSaved = false;
    }
    
    // Реалізація IContainer.Count
    public int Count 
    { 
        get { return _subjects.Length; } 
    }
    
    // Реалізація IContainer.[int]
    public object this[int index]
    {
        get
        {
            if (index < 0 || index >= _subjects.Length)
                throw new IndexOutOfRangeException("Індекс виходить за межі масиву");
            return _subjects[index];
        }
        set
        {
            if (index < 0 || index >= _subjects.Length)
                throw new IndexOutOfRangeException("Індекс виходить за межі масиву");
            
            if (value is Subject subject)
                _subjects[index] = subject;
            else
                throw new ArgumentException("Значення не є об'єктом типу Subject");
            
            _isDataSaved = false;
        }
    }
    
    // Реалізація IContainer.Add
    public void Add(Subject element)
    {
        if (element == null)
            throw new ArgumentNullException(nameof(element));
        
        int oldLength = _subjects.Length;
        Array.Resize(ref _subjects, oldLength + 1);
        _subjects[oldLength] = element;
        _isDataSaved = false;
    }
    
    // Реалізація IContainer.Delete
    public void Delete(Subject element)
    {
        if (element == null)
            throw new ArgumentNullException(nameof(element));
        
        int index = -1;
        for (int i = 0; i < _subjects.Length; i++)
        {
            if (_subjects[i].Equals(element))
            {
                index = i;
                break;
            }
        }
        
        if (index == -1)
            return; // Елемент не знайдено
        
        Subject[] newSubjects = new Subject[_subjects.Length - 1];
        
        // Копіюємо елементи до індексу
        for (int i = 0; i < index; i++)
            newSubjects[i] = _subjects[i];
        
        // Копіюємо елементи після індексу
        for (int i = index + 1; i < _subjects.Length; i++)
            newSubjects[i - 1] = _subjects[i];
        
        _subjects = newSubjects;
        _isDataSaved = false;
    }
    
    // Реалізація IFileContainer.Save
    public void Save(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentNullException(nameof(fileName));
        
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                // Записуємо основну інформацію
                writer.WriteLine($"{_author.FirstName},{_author.LastName},{_author.BirthDate.ToString("dd.MM.yyyy")}");
                writer.WriteLine(_degreeForm);
                writer.WriteLine(_specialityCode);
                writer.WriteLine(_subjects.Length);
                
                // Записуємо інформацію про предмети
                foreach (var subject in _subjects)
                {
                    writer.WriteLine($"{subject.Name},{subject.Hours},{subject.ExamDate.ToString("dd.MM.yyyy")}");
                }
            }
            
            _isDataSaved = true;
        }
        catch (Exception)
        {
            _isDataSaved = false;
            throw;
        }
    }
    
    // Реалізація IFileContainer.Load
    public void Load(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentNullException(nameof(fileName));
        
        if (!File.Exists(fileName))
            throw new FileNotFoundException("Файл не знайдено", fileName);
        
        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                // Читаємо основну інформацію
                string[] authorInfo = reader.ReadLine().Split(',');
                _author = new Person(
                    authorInfo[0],
                    authorInfo[1],
                    DateTime.ParseExact(authorInfo[2], "dd.MM.yyyy", null)
                );
                
                _degreeForm = (Degree)Enum.Parse(typeof(Degree), reader.ReadLine());
                _specialityCode = reader.ReadLine();
                
                int count = int.Parse(reader.ReadLine());
                _subjects = new Subject[count];
                
                // Читаємо інформацію про предмети
                for (int i = 0; i < count; i++)
                {
                    string[] subjectInfo = reader.ReadLine().Split(',');
                    _subjects[i] = new Subject(
                        subjectInfo[0],
                        int.Parse(subjectInfo[1]),
                        DateTime.ParseExact(subjectInfo[2], "dd.MM.yyyy", null)
                    );
                }
            }
            
            _isDataSaved = true;
        }
        catch (Exception)
        {
            _isDataSaved = false;
            throw;
        }
    }
    
    // Реалізація IFileContainer.IsDataSaved
    public bool IsDataSaved
    {
        get { return _isDataSaved; }
    }
    
    // Реалізація IEnumerable
    public IEnumerator GetEnumerator()
    {
        _position = -1;
        return this;
    }
    
    // Реалізація IEnumerator
    public bool MoveNext()
    {
        _position++;
        return (_position < _subjects.Length);
    }
    
    // Реалізація IEnumerator
    public void Reset()
    {
        _position = -1;
    }
    
    // Реалізація IEnumerator
    public object Current
    {
        get
        {
            if (_position == -1 || _position >= _subjects.Length)
                throw new InvalidOperationException();
            return _subjects[_position];
        }
    }
    
    public Person Author
    {
        get { return _author; }
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Автор не може бути (null)");
            _author = value;
            _isDataSaved = false;
        }
    }

    public Degree DegreeForm
    {
        get { return _degreeForm; }
        set
        {
            if (!Enum.IsDefined(typeof(Degree), value))
                throw new ArgumentException("Недопустиме значення для форми навчання");
            _degreeForm = value; 
            _isDataSaved = false;
        }
    }

    public string SpecialityCode
    {
        get { return _specialityCode?? "NoSpecialityCode"; }
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Код не може бути (null)");
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Шифр не може бути порожнім або складатися з пробілів");
            _specialityCode = value;
            _isDataSaved = false;
        }
    }

    public Subject[] Subjects
    {
        get { return _subjects; }
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Список предметів не може бути null");
            foreach (var item in value)
            {
                if (item == null)
                    throw new ArgumentException("Список предметів містить null-елементи");
            }
            _subjects = value;
            _isDataSaved = false;
        } 
    }
    
    // середнє значення кількості годин усього списку навчальних дисциплін
    public double AverageHours
    {
        get
        {
            if (_subjects == null || _subjects.Length == 0)
                return 0;

            int totalHours = 0;
            foreach (var subject in _subjects)
                totalHours += subject.Hours;

            return (double)totalHours / _subjects.Length;
        }
    }
    
    // індексатор логічного типу
    public bool this[Degree degree]
    {
        get { return _degreeForm == degree; }
    }
    
    // додавання елементів до списку навчальних дисциплін
    public void AddSubject(params Subject[] newSubjects)
    {
        if (newSubjects != null && newSubjects.Length != 0)
        {
            int oldLength = _subjects.Length;
            Array.Resize(ref _subjects, oldLength + newSubjects.Length);
            for (int i = 0; i < newSubjects.Length; i++)
                _subjects[oldLength + i] = newSubjects[i];
            _isDataSaved = false;
        }
    }
    
    // Додатковий метод для копіювання елементів з іншої колекції
    public static Syllabus CopyFirstElements(Syllabus source, int count)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));
        
        if (count <= 0)
            throw new ArgumentException("Кількість елементів повинна бути більше 0", nameof(count));
        
        // Визначимо скільки елементів можемо скопіювати
        int actualCount = Math.Min(count, source.Count);
        Subject[] newSubjects = new Subject[actualCount];
        
        for (int i = 0; i < actualCount; i++)
        {
            // Клонуємо об'єкт, щоб уникнути спільних посилань
            newSubjects[i] = (Subject)((Subject)source[i]).Clone();
        }
        
        // Створюємо новий Syllabus з копіями елементів
        return new Syllabus(
            (Person)source.Author.Clone(), 
            source.DegreeForm, 
            source.SpecialityCode, 
            newSubjects
        );
    }
    
    // Метод для виведення вмісту Syllabus
    public static void DisplaySyllabus(Syllabus syllabus)
    {
        Console.WriteLine($"Автор: {syllabus.Author.ToShortString()}");
        Console.WriteLine($"Форма навчання: {syllabus.DegreeForm}");
        Console.WriteLine($"Шифр спеціальності: {syllabus.SpecialityCode}");
        Console.WriteLine("Список предметів:");

        for (int i = 0; i < syllabus.Count; i++)
        {
            Subject subject = (Subject)syllabus[i];
            Console.WriteLine($" {i + 1}. {subject}");
        }
    }

    // Метод для сортування предметів у Syllabus
    public static void SortSyllabus(Syllabus syllabus)
    {
        // Створюємо тимчасовий масив для сортування
        Subject[] tempSubjects = new Subject[syllabus.Count];
        for (int i = 0; i < syllabus.Count; i++)
        {
            tempSubjects[i] = (Subject)syllabus.Subjects[i].Clone();
        }

        // Сортуємо масив
        Array.Sort(tempSubjects);

        // Оновлюємо Syllabus відсортованими елементами
        syllabus.Subjects = tempSubjects;
    }
    
    
    
    public override string ToString()
    {
        string result = $"Автор: {Author}\nФорма навчання: {DegreeForm}\nШифр спеціальності: {SpecialityCode}\nСписок предметів:";
        if (_subjects != null && _subjects.Length != 0)
            foreach (var subject in _subjects)
                result += "\n - " + subject.ToString();
        return result;
    }
    
    public string ToShortString()
    {
        return $"Автор: {Author.ToShortString()}, Ступінь: {DegreeForm}, Шифр: {SpecialityCode}, Середній обсяг годин: {AverageHours:F2}";
    }
}