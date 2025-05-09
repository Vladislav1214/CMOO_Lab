namespace Cm1_Lab_8.Class;

public class VolumeExceededException : Exception
{
    public VolumeExceededException(string message) : base(message) { }
}