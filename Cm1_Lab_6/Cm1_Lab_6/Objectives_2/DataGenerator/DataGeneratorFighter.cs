namespace Cm1_Lab_6;

public class DataGeneratorFighter
{
    private static string[] names = { "Raptor", "Lightning", "Phantom", "Mirage" };
    private static string[] manufacturers = { "Lockheed", "Dassault", "Sukhoi", "Boeing" };
    private static string[] fuelTypes = { "Jet Fuel", "Kerosene" };

    public static Fighter GenerateRandomFighter()
    {
        string name = names[DataGeneratorAircraft.rand.Next(names.Length)];
        string manufacturer = manufacturers[DataGeneratorAircraft.rand.Next(manufacturers.Length)];
        string fuelType = fuelTypes[DataGeneratorAircraft.rand.Next(fuelTypes.Length)];

        int year = DataGeneratorAircraft.rand.Next(1995, 2025);
        int maxAltitude = DataGeneratorAircraft.rand.Next(12000, 18000);
        int flightRange = DataGeneratorAircraft.rand.Next(2500, 5000);
        int crewCount = DataGeneratorAircraft.rand.Next(1, 3);
        int payload = DataGeneratorAircraft.rand.Next(3000, 8000);
        int wingspan = DataGeneratorAircraft.rand.Next(9, 14);
        int maxSpeed = DataGeneratorAircraft.rand.Next(1500, 2500);
        int weaponCount = DataGeneratorAircraft.rand.Next(0, 12);

        return new Fighter(name, year, maxAltitude, manufacturer, flightRange, crewCount, payload, fuelType, wingspan, maxSpeed, weaponCount);
    }
}