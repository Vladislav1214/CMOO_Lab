namespace Cm1_Lab_6;

public class Airplane : Aircraft
{
    private int wingspan; // Розмах крил, м
    private int passengerCapacity; // Місткість пасажирів

    public Airplane(string name, int year, double maxAltitude, string manufacturer, 
        double flightRange, int crewCount, double payloadCapacity, string fuelType, 
        int wingspan, int passengerCapacity) 
        : base(name, year, maxAltitude, manufacturer, flightRange, crewCount, payloadCapacity, fuelType)
    {
        this.wingspan = wingspan;
        this.passengerCapacity = passengerCapacity;
    }

    public Airplane()
    {
        
    }
    
    public int Wingspan { 
        get { return wingspan; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Розмах крил має бути більше 0.");
            wingspan = value;
        }  
    }
    
    public int PassengerCapacity { 
        get { return passengerCapacity; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Місткість пасажирів не може бути від'ємною.");
            passengerCapacity = value;
        }  
    }

    public override string GetDetails()
    {
       return $"Літак: {Name}, Рік: {Year}, Виробник: {Manufacturer}, Розмах крил: {wingspan} м, " +
            $"Пасажиромісткість: {passengerCapacity}, Дальність: {FlightRange} км, Екіпаж: {CrewCount}, " +
            $"Вантажопідйомність: {PayloadCapacity} кг, Макс. висота: {MaxAltitude} м, Паливо: {FuelType}";
    }

    public override string ToString()
    {
       return "Літак: " + base.ToString() + $", Розмах крил: {wingspan} м, Пасажиромісткість: {passengerCapacity}";
    }
}
