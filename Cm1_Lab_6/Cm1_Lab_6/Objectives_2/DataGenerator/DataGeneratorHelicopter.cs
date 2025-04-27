﻿namespace Cm1_Lab_6;

public class DataGeneratorHelicopter
{
    private static string[] names = { "Hawk", "Storm", "Comet", "Hornet" };
    private static string[] manufacturers = { "Kamov", "Sikorsky", "Airbus", "Robinson" };
    private static string[] fuelTypes = { "Kerosene", "Diesel" };

    public static Helicopter GenerateRandomHelicopter()
    {
        string name = names[DataGeneratorAircraft.rand.Next(names.Length)];
        string manufacturer = manufacturers[DataGeneratorAircraft.rand.Next(manufacturers.Length)];
        string fuelType = fuelTypes[DataGeneratorAircraft.rand.Next(fuelTypes.Length)];

        int year = DataGeneratorAircraft.rand.Next(1990, 2025);
        int maxAltitude = DataGeneratorAircraft.rand.Next(3000, 6000);
        int flightRange = DataGeneratorAircraft.rand.Next(300, 600);
        int crewCount = DataGeneratorAircraft.rand.Next(1, 3);
        int payload = DataGeneratorAircraft.rand.Next(1000, 4000);
        int rotorCount = DataGeneratorAircraft.rand.Next(1, 3);

        return new Helicopter(name, year, maxAltitude, manufacturer, flightRange, crewCount, payload, fuelType, rotorCount);
    }
}