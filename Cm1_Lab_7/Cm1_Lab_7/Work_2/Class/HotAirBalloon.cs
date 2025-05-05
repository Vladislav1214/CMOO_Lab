namespace Cm1_Lab_7;

public class HotAirBalloon : Device, IPart
{
    int _volume;
    string? _partName;
    string? _material;
    
    public HotAirBalloon(string name, int yearOfManufacture, int maxSpeed, bool hasElectronics,
        int volume, string partName, string material)
        : base(name, yearOfManufacture, maxSpeed, hasElectronics)
    {
        _volume = volume;
        _partName = partName;
        _material = material;
    }

    public HotAirBalloon()
    {
        
    }

    public int Volume
    {
        get { return _volume; }
        set { _volume = value; }
    }

    public string PartName
    {
        get { return _partName?? "NoPartName"; }
        set { _partName = value; }
    }

    public string Material
    {
        get { return _material ?? "NoMaterial"; }
        set { _material = value; }
    }
    
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Об'єм: {Volume} м³");
        DisplayPartInfo();
    }
    
    public void DisplayPartInfo()
    {
        Console.WriteLine($"Частина: {PartName}");
        Console.WriteLine($"Матеріал: {Material}");
    }
    
    public override object Clone()
    {
        return new HotAirBalloon(Name, YearOfManufacture, MaxSpeed, HasElectronics, 
            Volume, PartName, Material);
    }
}