namespace Cm1_Lab_7;

public interface IEngine
{
    int Power { get; set; }
    string Type { get; set; }
    void StartEngine();
}