namespace Cm1_Lab_6;

public class DataGeneratorAircraft
{
    public static Random rand = new Random();

    public static Aircraft GenerateRandomAircraft()
    {
        int choice = rand.Next(4); // 0 - Helicopter, 1 - Airplane, 2 - Fighter, 3 - Drone

        switch (choice)
        {
            case 0:
                return DataGeneratorHelicopter.GenerateRandomHelicopter();
            case 1:
                return DataGeneratorAirplane.GenerateRandomAirplane();
            case 2:
                return DataGeneratorFighter.GenerateRandomFighter();
            case 3:
                return DataGeneratorDrone.GenerateRandomDrone();
            default:
                throw new InvalidOperationException("Невірний вибір типу літального апарата.");
        }
    }
}