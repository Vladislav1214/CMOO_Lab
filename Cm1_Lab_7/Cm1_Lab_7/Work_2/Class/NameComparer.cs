namespace Cm1_Lab_7;

public class NameComparer : IComparer<Device>
{
    public int Compare(Device? x, Device? y)
    {
        return string.Compare(x?.Name, y?.Name, StringComparison.Ordinal);
    }
}