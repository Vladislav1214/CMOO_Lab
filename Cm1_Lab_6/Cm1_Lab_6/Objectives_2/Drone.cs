namespace Cm1_Lab_6;

public class Drone : Aircraft
{
    private bool hasCamera; // Наявність камери

    public Drone(string name, int year, double maxAltitude, string manufacturer, 
        double flightRange, int crewCount, double payloadCapacity, string fuelType, bool hasCamera) 
        : base(name, year, maxAltitude, manufacturer, flightRange, crewCount, payloadCapacity, fuelType)
    {
        this.hasCamera = hasCamera;
    }

    public Drone()
    {
        
    }

    public bool HasCamera
    {
        get { return hasCamera; }
        set
        { 
            hasCamera = value;
        }
        
    }

    public override string GetDetails()
    {
        return $"Дрон: {Name}, Рік: {Year}, Виробник: {Manufacturer}, Дальність: {FlightRange} км, " + 
               $"Камера: {(hasCamera ? "Так" : "Ні")}, Екіпаж: {CrewCount}, Вантажопідйомність: {PayloadCapacity} кг, " + 
               $"Макс. висота: {MaxAltitude} м, Паливо: {FuelType}";
    }

    public override string ToString()
    {
        return "Дрон: " + base.ToString() + $", Камера: {(hasCamera ? "Так" : "Ні")}";
    }
}
