namespace Cm1_Lab_8.Class;

public class Item
{
    string? _name;
    public double Volume { get; set; }

    public Item(string name, double volume)
    {
        _name = name;
        Volume = volume;
    }

    public string Name
    {
        get 
        {
            return _name ?? "NoName";
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _name = value;
        }
    }

    public Item()
    {
        
    }

    public override string ToString() => $"{Name} ({Volume} л)";
}