namespace Cm1_Lab_7;

public class Airplane : EngineDevice, IPart
{
    int _numberOfSeats;
    string? _partName;
    string? _material;
    
    public Airplane(string name, int yearOfManufacture, int maxSpeed, bool hasElectronics,
        int power, string type, int numberOfSeats, string partName, string material)
        : base(name, yearOfManufacture, maxSpeed, hasElectronics, power, type)
    {
        _numberOfSeats = numberOfSeats;
        _partName = partName;
        _material = material;
    }

    public Airplane()
    {
        
    }
    
    public int NumberOfSeats
    {
        get { return _numberOfSeats; }
        set { _numberOfSeats = value; }
    }
    
    public string Material
    {
        get { return _material?? "NoMaterial"; }
        set { _material = value; }
    }

    public string PartName
    {
        get { return _partName?? "NoPartName"; }
        set { _partName = value; }
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Кількість місць: {NumberOfSeats}");
        DisplayPartInfo();
    }
    
    public void DisplayPartInfo()
    {
        Console.WriteLine($"Частина: {PartName}");
        Console.WriteLine($"Матеріал: {Material}");
    }
    
    public override object Clone()
    {
        return new Airplane(Name, YearOfManufacture, MaxSpeed, HasElectronics, 
            Power, Type, NumberOfSeats, PartName, Material);
    }
}