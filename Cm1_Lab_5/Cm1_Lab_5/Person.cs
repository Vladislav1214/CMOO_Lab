using System.Text.RegularExpressions;

namespace Cm1_Lab_5;
public class Person
{
    string? firstName;
    string? lastName;
    DateTime birthDate;
    
    public const string pattern = @"^[A-ZА-ЯІЇЄҐ][a-zа-яіїєґ']{2,70}$";
    
    public Person(string firstName, string lastName, DateTime birthDate)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthDate = birthDate;
    }

    public Person()
    {
        firstName = "NoFirstName";
        lastName = "NoLastName";
        birthDate = new DateTime(1990, 1, 1);
    }

    public string FirstName
    {
        get {  return firstName?? "NoFirstName"; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && Regex.IsMatch(value, pattern))
                firstName = value;
        }
    }
    
    public string LastName
    {
        get { return lastName?? "NoLastName"; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && Regex.IsMatch(value, pattern))
                lastName = value;
        }
    }
    
    public DateTime BirthDate
    {
        get { return birthDate; }
        set
        {
            if (value < DateTime.Now || value > DateTime.Now.AddYears(-120))
                birthDate = value;
        }
    }
    
    public int SetYear
    {
        get { return birthDate.Year; }
        set
        {
            if (value < DateTime.Now.AddYears(-120).Year || value < DateTime.Now.Year)
                birthDate = new DateTime(value, birthDate.Month, birthDate.Day);
        }
    }
    
    public override string ToString()
    {
        return $"Ім’я: {firstName?? "NoFirstName"}, Прізвище: {lastName?? "NoLastName"}, Дата народження: {birthDate.ToShortDateString()}";
    }
    
    public string ToShortString()
    {
        return $"{firstName?? "NoFirstName"} {lastName?? "NoLastName"}";
    }
}