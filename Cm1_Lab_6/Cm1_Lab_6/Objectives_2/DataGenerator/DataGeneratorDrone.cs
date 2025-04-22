namespace Cm1_Lab_6;

public class DataGeneratorDrone
{
    static string[] names = { "SpyEye", "SkyWatcher", "NanoHawk", "AirScout" };
    static string[] manufacturers = { "Baykar", "DJI", "Northrop", "General Atomics" };
    static string[] fuelTypes = { "Electric", "Kerosene" };

    public static Drone GenerateRandomDrone()
    {
        string name = names[DataGeneratorAircraft.rand.Next(names.Length)];
        string manufacturer = manufacturers[DataGeneratorAircraft.rand.Next(manufacturers.Length)];
        string fuelType = fuelTypes[DataGeneratorAircraft.rand.Next(fuelTypes.Length)];

        int year = DataGeneratorAircraft.rand.Next(2010, 2025);
        int maxAltitude = DataGeneratorAircraft.rand.Next(3000, 10000);
        int flightRange = DataGeneratorAircraft.rand.Next(500, 3000);
        int payload = DataGeneratorAircraft.rand.Next(50, 300);
        bool hasCamera = DataGeneratorAircraft.rand.Next(2) == 0;

        return new Drone(name, year, maxAltitude, manufacturer, flightRange, 0, payload, fuelType, hasCamera);
    }
}