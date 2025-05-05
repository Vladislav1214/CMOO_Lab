namespace Cm1_Lab_7;

public class DataGeneratorDeltaplane : DataGeneratorDevice
{
    public override Device CreateDevice()
    {
        string name = GenerateRandomName();
        int year = GenerateRandomYear();
        int speed = GenerateRandomSpeed(30, 150);
        bool hasElectronics = GenerateRandomBool();
        double wingArea = random.Next(10, 30) + random.NextDouble(); // випадкова площа крила
        wingArea = Math.Round(wingArea, 1); // округлення до 1 знака після коми
        string partName = GenerateRandomPartName();
        string material = GenerateRandomMaterial();
        
        return new Deltaplane(name, year, speed, hasElectronics, wingArea, partName, material);
    }
}