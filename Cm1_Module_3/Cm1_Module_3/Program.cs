namespace Cm1_Module_3;
using DataGeneratorRandom;
using Class;

class Program
{
    static void Main()
    {
        try
        {
            var lecturer = RandomLecturer.GenerateLecturers(5);
            var disciplines = RandomSubjects.GenerateSubjects(lecturer);
            var student = new Student("Олег", new List<Lecturer> { lecturer[0], lecturer[1], lecturer[4] });

            student.SelectDisciplines(disciplines);

            student.PrintSelectedDisciplines();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
