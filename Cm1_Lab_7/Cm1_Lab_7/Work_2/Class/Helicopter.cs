namespace Cm1_Lab_7;

public class Helicopter : EngineDevice, IPart
{
    int _numberOfBlades;
    string? _partName;
    string? _material;
    
    public Helicopter(string name, int yearOfManufacture, int maxSpeed, bool hasElectronics,
        int power, string type, int numberOfBlades, string partName, string material)
        : base(name, yearOfManufacture, maxSpeed, hasElectronics, power, type)
    {
        _numberOfBlades = numberOfBlades;
        _partName = partName;
        _material = material;
    }

    public Helicopter()
    {
        
    }

    public int NumberOfBlades
    {
        get { return _numberOfBlades; }
        set { _numberOfBlades = value; }
    }

    public string PartName
    {
        get { return _partName?? "NoPartName"; }
        set { _partName = value; }
    }

    public string Material
    {
        get { return _material?? "NoMaterial"; }
        set { _material = value; }
    }
    
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Кількість лопастей: {NumberOfBlades}");
        DisplayPartInfo();
    }
    
    public void DisplayPartInfo()
    {
        Console.WriteLine($"Частина: {PartName}");
        Console.WriteLine($"Матеріал: {Material}");
    }
    
    public override object Clone()
    {
        return new Helicopter(Name, YearOfManufacture, MaxSpeed, HasElectronics, 
            Power, Type, NumberOfBlades, PartName, Material);
    }
}