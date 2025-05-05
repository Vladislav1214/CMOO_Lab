namespace Cm1_Lab_7;

public class DataGeneratorHotAirBalloon : DataGeneratorDevice
{
    public override Device CreateDevice()
    {
        string name = GenerateRandomName();
        int year = GenerateRandomYear();
        int speed = GenerateRandomSpeed(5, 40);
        bool hasElectronics = GenerateRandomBool();
        int volume = random.Next(1000, 5000); // випадковий об'єм кулі
        string partName = GenerateRandomPartName();
        string material = GenerateRandomMaterial();
        
        return new HotAirBalloon(name, year, speed, hasElectronics, volume, partName, material);
    }
}