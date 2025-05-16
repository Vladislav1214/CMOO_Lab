namespace Cm1_Lab_6;

public class MilitaryBase
{
    private Aircraft[] aircrafts;

    public MilitaryBase(Aircraft[] aircraft)
    {
        aircrafts = aircraft;
    }
    
    public void AddAircrafts(params Aircraft[] newAircrafts)
    {
        if (newAircrafts != null && newAircrafts.Length != 0)
        {
            int oldLength = aircrafts.Length;
            Array.Resize(ref aircrafts, oldLength + newAircrafts.Length);
            for (int i = 0; i < newAircrafts.Length; i++)
                aircrafts[oldLength + i] = newAircrafts[i];
        }
    }

    public void DisplayAircraftCount()
    {
        if (aircrafts.Length== 0)
        {
            Console.WriteLine("На базі відсутні літальні апарати.");
            return;
        }

        Console.WriteLine($"Кількісний склад літальних апаратів: {aircrafts.Length}");
        Console.WriteLine("За типами:");
        var grouped = aircrafts.GroupBy(a => a.GetType().Name);
        foreach (var group in grouped)
        {
            Console.WriteLine($"{group.Key}: {group.Count()}");
        }
    }

    public void DisplayDetailedInfo()
    {
        if (aircrafts.Length == 0)
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