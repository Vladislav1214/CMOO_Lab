namespace Cm1_Lab_6;

public class Fighter : Airplane
{
    private int maxSpeed; // Максимальна швидкість, км/год
    private int weaponCount; // Кількість одиниць озброєння

    public Fighter(string name, int year, double maxAltitude, string manufacturer, 
        double flightRange, int crewCount, double payloadCapacity, string fuelType, 
        int wingspan, int passengerCapacity, int maxSpeed, int weaponCount) 
        : base(name, year, maxAltitude, manufacturer, flightRange, crewCount, payloadCapacity, fuelType, wingspan, passengerCapacity)
    {
        
        
        this.maxSpeed = maxSpeed;
        this.weaponCount = weaponCount;
    }

    public Fighter()
    {
        
    }

    public int MaxSpeed
    {
        get { return maxSpeed; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Максимальна швидкість має бути більше 0.");
            maxSpeed = value;
        }
    }

    public int WeaponCount
    {
        get { return weaponCount; }
        set
        {
            if (weaponCount < 0)
                throw new ArgumentException("Кількість озброєння не може бути від'ємною.");
            weaponCount = value;
        }
    }
    
    
    public override string GetDetails()
    {
        return $"Винищувач: {Name}, Рік: {Year}, Виробник: {Manufacturer}, Розмах крил: {Wingspan} м, " +
               $"Макс. швидкість: {maxSpeed} км/год, Озброєння: {weaponCount}, Дальність: {FlightRange} км, " +
               $"Екіпаж: {CrewCount}, Вантажопідйомність: {PayloadCapacity} кг, Макс. висота: {MaxAltitude} м, Паливо: {FuelType}";
    }

    public override string ToString()
    {
        return "Винищувач: " + base.ToString() + $", Макс. швидкість: {maxSpeed} км/год, Озброєння: {weaponCount}";
    }
}