namespace Cm1_Lab_7;

public class DataGeneratorHelicopter : DataGeneratorDevice
{
    public override Device CreateDevice()
    {
        string name = GenerateRandomName();
        int year = GenerateRandomYear();
        int speed = GenerateRandomSpeed(100, 350);
        bool hasElectronics = GenerateRandomBool();
        int power = GenerateRandomPower(500, 5000);
        string engineType = GenerateRandomEngineType();
        int blades = random.Next(2, 8); // випадкова кількість лопастей
        string partName = GenerateRandomPartName();
        string material = GenerateRandomMaterial();
        
        return new Helicopter(name, year, speed, hasElectronics, power, engineType, blades, partName, material);
    }
}