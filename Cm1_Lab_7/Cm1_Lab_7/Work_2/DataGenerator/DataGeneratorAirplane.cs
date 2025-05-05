namespace Cm1_Lab_7;

public class DataGeneratorAirplane : DataGeneratorDevice
{
    public override Airplane CreateDevice()
    {
        string name = GenerateRandomName();
        int year = GenerateRandomYear();
        int speed = GenerateRandomSpeed(300, 1000);
        bool hasElectronics = GenerateRandomBool();
        int power = GenerateRandomPower(10000, 50000);
        string engineType = GenerateRandomEngineType();
        int seats = random.Next(2, 400); // випадкова кількість місць
        string partName = GenerateRandomPartName();
        string material = GenerateRandomMaterial();
        
        return new Airplane(name, year, speed, hasElectronics, power, engineType, seats, partName, material);
    }
}