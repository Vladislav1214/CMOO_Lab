namespace Cm1_Lab_7;

public class Deltaplane : Device, IPart
{
    double _wingArea;
    string? _partName;
    string? _material;
    
    public Deltaplane(string name, int yearOfManufacture, int maxSpeed, bool hasElectronics,
        double wingArea, string partName, string material)
        : base(name, yearOfManufacture, maxSpeed, hasElectronics)
    {
        _wingArea = wingArea;
        _partName = partName;
        _material = material;
    }

    public Deltaplane()
    {
        
    }

    public double WingArea
    {
        get { return _wingArea; }
        set { _wingArea = value; }
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
        Console.WriteLine($"Площа крила: {WingArea} м²");
        DisplayPartInfo();
    }
    
    public void DisplayPartInfo()
    {
        Console.WriteLine($"Частина: {PartName}");
        Console.WriteLine($"Матеріал: {Material}");
    }
    
    public override object Clone()
    {
        return new Deltaplane(Name, YearOfManufacture, MaxSpeed, HasElectronics, 
            WingArea, PartName, Material);
    }
}
