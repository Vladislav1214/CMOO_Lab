using System.Text.RegularExpressions;

namespace Cm1_Lab_7;
public class Person : IComparable, ICloneable
{
    string? _firstName;
    string? _lastName;
    DateTime _birthDate;
    
    public const string Pattern = @"^[A-ZА-ЯІЇЄҐ][a-zа-яіїєґ']{2,70}$";
    
    public Person(string firstName, string lastName, DateTime birthDate)
    {
        _firstName = firstName;
        _lastName = lastName;
        _birthDate = birthDate;
    }

    public Person()
    {
        
    }

    public int CompareTo(object obj)
    {
        if (obj == null)
            return 1;

        Person pers = obj as Person;
        
        if (pers == null)
            throw new ArgumentException("Object is not a Person");

        // Порівнюємо за прізвищем
        int lastNameComparison = this.LastName.CompareTo(pers.LastName);
        if (lastNameComparison != 0)
            return lastNameComparison;

        // Якщо прізвища однакові, порівнюємо за іменем
        int firstNameComparison = this.FirstName.CompareTo(pers.FirstName);
        if (firstNameComparison != 0)
            return firstNameComparison;

        // Якщо імена однакові, порівнюємо за датою народження
        return this.BirthDate.CompareTo(pers.BirthDate);
    }
    
    public Object Clone()
    {
        return new Person(FirstName, LastName, BirthDate);
    }
    
    public string FirstName
    {
        get {  return _firstName?? "NoFirstName"; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && Regex.IsMatch(value, Pattern))
                _firstName = value;
        }
    }
    
    public string LastName
    {
        get { return _lastName?? "NoLastName"; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && Regex.IsMatch(value, Pattern))
                _lastName = value;
        }
    }
    
    public DateTime BirthDate
    {
        get { return _birthDate; }
        set
        {
            if (value <= DateTime.Now && value >= DateTime.Now.AddYears(-120))
                _birthDate = value;
        }
    }
    
    public int SetBirthYear
    {
        get { return _birthDate.Year; }
        set
        {
            if (value <= DateTime.Now.Year && value >= DateTime.Now.AddYears(-120).Year)
                _birthDate = new DateTime(value, _birthDate.Month, _birthDate.Day);
        }
    }
    
    public override string ToString()
    {
        return $"Ім’я: {FirstName}, Прізвище: {LastName}, Дата народження: {BirthDate.ToString("dd.MM.yyyy")}";
    }
    
    public string ToShortString()
    {
        return $"{FirstName} {LastName}";
    }
}