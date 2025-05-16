namespace Cm1_Lab_8.Class;

public class Item
{
    string _name;
    double _volume;

    
    public Item() { }
    
    public Item(string name, double volume)
    {
        _name = name;
        _volume = volume;
    }

    public string Name
    {
        get { return _name ?? "NoName"; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _name = value;
        }
    }

    public double Volume
    {
        get { return _volume; }
        set { _volume = value;}
    }

    public override string ToString() => $"{Name} ({Volume} л)";
}