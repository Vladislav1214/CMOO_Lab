namespace Cm1_Lab_7;

public class SpeedComparer : IComparer<Device>
{
    public int Compare(Device x, Device y)
    {
        return x.MaxSpeed.CompareTo(y.MaxSpeed);
    }
}