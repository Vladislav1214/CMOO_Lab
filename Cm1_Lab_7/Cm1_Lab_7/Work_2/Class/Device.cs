namespace Cm1_Lab_7;

public abstract class Device : IDevice, IComparable<Device>, ICloneable
{
    string? _name;
    int _yearOfManufacture;
    int _maxSpeed; 
    bool _hasElectronics;
    
    public Device(string name, int yearOfManufacture, int maxSpeed, bool hasElectronics)
    {
        _name = name;
        _yearOfManufacture = yearOfManufacture;
        _maxSpeed = maxSpeed;
        _hasElectronics = hasElectronics;
    }

    public Device()
    {
        
    }

    public string Name 
    {
        get { return _name?? "NoName"; }
        set { _name = value; } 
    }

    public int YearOfManufacture
    {
        get { return _yearOfManufacture; }
        set { _yearOfManufacture = value; }
    }

    public int MaxSpeed
    {
        get { return _maxSpeed; }
        set { _maxSpeed = value; }
    }

    public bool HasElectronics
    {
        get { return _hasElectronics; }
        set { _hasElectronics = value; }
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Назва: {Name}");
        Console.WriteLine($"Рік виробництва: {YearOfManufacture}");
        Console.WriteLine($"Максимальна швидкість: {MaxSpeed} км/год");
        Console.WriteLine($"Має електроніку: {(HasElectronics ? "Так" : "Ні")}");
    }
    
    // Реалізація IComparable для сортування за роком виробництва
    public int CompareTo(Device? other)
    {
        return _yearOfManufacture.CompareTo(other?._yearOfManufacture);
    }
    
    // Реалізація ICloneable
    public virtual object Clone()
    {
        // Використовуємо MemberwiseClone для поверхневого копіювання
        return this.MemberwiseClone();
    }
}