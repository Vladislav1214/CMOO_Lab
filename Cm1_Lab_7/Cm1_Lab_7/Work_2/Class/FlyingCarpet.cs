using System.IO.Pipelines;

namespace Cm1_Lab_7;

public class FlyingCarpet : Device, IPart
{
    double _length;
    double _width;
    string? _partName;
    string? _material;
    
    public FlyingCarpet(string name, int yearOfManufacture, int maxSpeed, bool hasElectronics,
        double length, double width, string partName, string material)
        : base(name, yearOfManufacture, maxSpeed, hasElectronics)
    {
        _length = length;
        _width = width;
        _partName = partName;
        _material = material;
    }

    public FlyingCarpet()
    {
        
    }

    public double Length
    {
        get { return _length; }
        set { _length = value; }
    }

    public double Width
    {
        get { return _width; }
        set { _width = value; }
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
        Console.WriteLine($"Довжина: {Length} м");
        Console.WriteLine($"Ширина: {Width} м");
        DisplayPartInfo();
    }
    
    public void DisplayPartInfo()
    {
        Console.WriteLine($"Частина: {PartName}");
        Console.WriteLine($"Матеріал: {Material}");
    }
    
    public override object Clone()
    {
        return new FlyingCarpet(Name, YearOfManufacture, MaxSpeed, HasElectronics, 
            Length, Width, PartName, Material);
    }
}