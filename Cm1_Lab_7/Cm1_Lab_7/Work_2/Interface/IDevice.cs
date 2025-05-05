namespace Cm1_Lab_7;


interface IDevice 
{
    string Name { get; set; }
    int YearOfManufacture { get; set; }
    int MaxSpeed { get; set; }
    void DisplayInfo();
}