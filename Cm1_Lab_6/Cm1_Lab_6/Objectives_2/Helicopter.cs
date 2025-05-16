namespace Cm1_Lab_6;

public class Helicopter : Aircraft
{
    private int rotorCount;  // Кількість роторів

    public Helicopter(string name, int year, double maxAltitude, string manufacturer, 
        double flightRange, int crewCount, double payloadCapacity, string fuelType, int rotorCount) 
        : base(name, year, maxAltitude, manufacturer, flightRange, crewCount, payloadCapacity, fuelType)
    {
        this.rotorCount = rotorCount;
    }

    public int RotorCount
    {
        get { return rotorCount; }
        set
        {
            if (rotorCount <= 0)
                throw new ArgumentException("Кількість роторів має бути більше 0.");
            rotorCount = value;
        }
    }
    
    public override string GetDetails()
    {
        return $"Вертоліт: {Name}, Рік: {Year}, Виробник: {Manufacturer}, Ротори: {rotorCount}, " +
               $"Дальність: {FlightRange} км, Екіпаж: {CrewCount}, Вантажопідйомність: {PayloadCapacity} кг, " +
               $"Макс. висота: {MaxAltitude} м, Паливо: {FuelType}";
    }

    public override string ToString()
    {
       return "Вертоліт: " + base.ToString() + $", Ротори: {RotorCount}";
    }
}
