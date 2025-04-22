using System.Text;
using System.Text.RegularExpressions;

namespace Cm1_Lab_5;

class Program
{
    // Повертає предмет із найбільшою кількістю годин
    static Subject GetMostLoadedSubject(Syllabus syllabus)
    {
        if (syllabus.Subjects.Length == 0)
            throw new ArgumentException("null");

        Subject max = syllabus.Subjects[0];

        foreach (var subject in syllabus.Subjects)
            if (subject.Hours > max.Hours)
                max = subject;

        return max;
    }

    // Повертає масив предметів, які є у двох навчальних планах
    static Subject[] GetCommonSubjects(Syllabus a, Syllabus b)
    {
        // Максимальна кількість спільних предметів — довжина меншого масиву
        
        int maxLength = a.Subjects.Length > b.Subjects.Length ? a.Subjects.Length : b.Subjects.Length;
        int minLength = a.Subjects.Length < b.Subjects.Length ? a.Subjects.Length : b.Subjects.Length;
        
        Syllabus min = a.Subjects.Length < b.Subjects.Length ? a : b;
        Syllabus max = a.Subjects.Length > b.Subjects.Length ? a : b;
        
        Subject[] temp = new Subject[minLength];
        int count = 0;

        for (int i = 0; i < minLength; i++)
        for (int j = 0; j < maxLength; j++) 
            if (min.Subjects[i].Name == max.Subjects[j].Name)
            {
                temp[count++] = min.Subjects[i];
                break;
            }
        
        Subject[] result = new Subject[count];
        for (int i = 0; i < count; i++)
            result[i] = temp[i];

        return result;
    }
    
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        try
        {
            Syllabus noPlan = new Syllabus();
            Console.WriteLine(noPlan.ToShortString());
            
            //-------------------------------
            Console.WriteLine("\nЧи план для Specialist? " + noPlan[Degree.Specialist]);
            Console.WriteLine("Чи план для Bachelor? " + noPlan[Degree.Bachelor]);
            Console.WriteLine("Чи план для Magistr? " + noPlan[Degree.Magistr]);
            Console.WriteLine();
            
            //---------------------------------
            Syllabus plan = SampleDataGeneratorSyllabus.GenerateRandomSyllabus();
            Console.WriteLine(plan.ToString());
            
            //---------------------------------
            plan.AddSubject( DataGeneratorSubject.GenerateRandomSubject(), DataGeneratorSubject.GenerateRandomSubject());
            Console.WriteLine(plan.ToString());
            Console.WriteLine();
            
            
            //---------------------------------------
            Syllabus plan1 = SampleDataGeneratorSyllabus.GenerateRandomSyllabus();
            Console.WriteLine(plan1.ToString());
            Syllabus plan2 = SampleDataGeneratorSyllabus.GenerateRandomSyllabus();
            Console.WriteLine(plan2.ToString());
            Console.WriteLine();
            
            Subject[] all = GetCommonSubjects(plan1, plan2);
            foreach (var i in all)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine();
            
            Console.WriteLine(GetMostLoadedSubject(plan1));
            Console.WriteLine(GetMostLoadedSubject(plan2));
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
            Console.WriteLine($"Параметр: {ex.ParamName}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Невідома помилка: {ex.Message}");
        }
        
        Console.ReadKey();
    }
}