namespace Cm1_Lab_6;

public class MilitaryBase
{
    private List<Aircraft> aircrafts = new List<Aircraft>();

    public void AddAircraft(Aircraft aircraft)
    {
        aircrafts.Add(aircraft);
    }

    public void RemoveAircraft(Aircraft aircraft)
    {
        aircrafts.Remove(aircraft);
    }

    public void DisplayAircraftCount()
    {
        if (aircrafts.Count == 0)
        {
            Console.WriteLine("На базі відсутні літальні апарати.");
            return;
        }

        Console.WriteLine($"Кількісний склад літальних апаратів: {aircrafts.Count}");
        Console.WriteLine("За типами:");
        var grouped = aircrafts.GroupBy(a => a.GetType().Name);
        foreach (var group in grouped)
        {
            Console.WriteLine($"{group.Key}: {group.Count()}");
        }
    }

    public void DisplayDetailedInfo()
    {
        if (aircrafts.Count == 0)
        {
            Console.WriteLine("На базі відсутні літальні апарати.");
            return;
        }

        Console.WriteLine("\nДокладна інформація про літальні апарати:");
        foreach (var aircraft in aircrafts)
        {
            Console.WriteLine(aircraft.ToString());
        }
    }
}