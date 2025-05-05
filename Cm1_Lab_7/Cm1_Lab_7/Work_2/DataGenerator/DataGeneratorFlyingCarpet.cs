namespace Cm1_Lab_7;

public class DataGeneratorFlyingCarpet : DataGeneratorDevice
{
    public override Device CreateDevice()
    {
        string name = GenerateRandomName();
        int year = GenerateRandomYear();
        int speed = GenerateRandomSpeed(50, 200);
        bool hasElectronics = GenerateRandomBool();
        double length = random.Next(2, 10) + random.NextDouble(); // випадкова довжина
        double width = random.Next(1, 5) + random.NextDouble(); // випадкова ширина
        length = Math.Round(length, 1); // округлення до 1 знака після коми
        width = Math.Round(width, 1); // округлення до 1 знака після коми
        string partName = GenerateRandomPartName();
        string material = GenerateRandomMaterial();
        
        return new FlyingCarpet(name, year, speed, hasElectronics, length, width, partName, material);
    }
}