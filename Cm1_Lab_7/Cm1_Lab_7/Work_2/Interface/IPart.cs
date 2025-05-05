namespace Cm1_Lab_7;

public interface IPart
{
    string PartName { get; set; }
    string Material { get; set; }
    void DisplayPartInfo();
}