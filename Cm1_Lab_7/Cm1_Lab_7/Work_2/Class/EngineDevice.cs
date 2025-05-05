namespace Cm1_Lab_7;

public abstract class EngineDevice : Device, IEngine
{
    int _power;
    string? _type;
    
    public EngineDevice(string name, int yearOfManufacture, int maxSpeed, bool hasElectronics, 
        int power, string type) 
        : base(name, yearOfManufacture, maxSpeed, hasElectronics)
    {
        _power = power;
        _type = type;
    }

    public EngineDevice()
    {
        
    }

    public int Power
    {
        get { return _power; }
        set { _power = value; }
    }

    public string Type
    {
        get { return _type?? "NoType"; }
        set { _type = value; }
    }
    
    public void StartEngine()
    {
        Console.WriteLine($"Запуск двигуна типу {Type} потужністю {Power} кВт");
    }
    
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Тип двигуна: {Type}");
        Console.WriteLine($"Потужність: {Power} кВт");
    }
}