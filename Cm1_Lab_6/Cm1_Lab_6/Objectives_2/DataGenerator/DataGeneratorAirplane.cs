namespace Cm1_Lab_6;

public class DataGeneratorAirplane
{

    private static string[] names = { "Eagle", "Falcon", "SkyJet", "WindRider" };
    private static string[] manufacturers = { "Boeing", "Airbus", "Antonov", "Tupolev" };
    private static string[] fuelTypes = { "Kerosene", "Electric", "Petrol"};

    public static Airplane GenerateRandomAirplane()
    {
        string name = names[DataGeneratorAircraft.rand.Next(names.Length)];
        string manufacturer = manufacturers[DataGeneratorAircraft.rand.Next(manufacturers.Length)];
        string fuelType = fuelTypes[DataGeneratorAircraft.rand.Next(fuelTypes.Length)];

        int year = DataGeneratorAircraft.rand.Next(1980, 2025);
        int maxAltitude = DataGeneratorAircraft.rand.Next(9000, 13000);
        int flightRange = DataGeneratorAircraft.rand.Next(4000, 11000);
        int crewCount = DataGeneratorAircraft.rand.Next(2, 6);
        int payload = DataGeneratorAircraft.rand.Next(10000, 20000);
        int wingspan = DataGeneratorAircraft.rand.Next(20, 40);
        int passengerCapacity = DataGeneratorAircraft.rand.Next(100, 300);

        return new Airplane(name, year, maxAltitude, manufacturer, flightRange, crewCount, payload, fuelType, wingspan, passengerCapacity);
    }
}