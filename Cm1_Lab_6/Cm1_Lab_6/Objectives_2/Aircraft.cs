namespace Cm1_Lab_6;

public abstract class Aircraft
{
    private string? name;
    private string? manufacturer; // Виробник
    private int year;
    private double maxAltitude; // Максимальна висота польоту, м
    private double flightRange; // Дальність польоту, км
    private double payloadCapacity; // Вантажопідйомність, кг
    private string? fuelType; // Тип палива
    private int crewCount; // Кількість членів екіпажу
    

    public Aircraft(string name, int year, double maxAltitude, string manufacturer, 
        double flightRange, int crewCount, double payloadCapacity, string fuelType)
    {
        this.name = name;
        this.year = year;
        this.maxAltitude = maxAltitude;
        this.manufacturer = manufacturer;
        this.flightRange = flightRange;
        this.crewCount = crewCount;
        this.payloadCapacity = payloadCapacity;
        this.fuelType = fuelType;
    }

    public Aircraft()
    {
        
    }

    public string Name
    {
        get { return name?? "NoName"; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Назва не може бути порожньою.");
            name = value;
        }
    }

    public int Year
    {
        get { return year; }
        set
        {
            if (value < 1900 || value > DateTime.Now.Year)
                throw new ArgumentException("Некоректний рік виробництва.");
            year = value;
        }
    }

    public double MaxAltitude
    {
        get { return maxAltitude; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Максимальна висота має бути більше 0.");
            maxAltitude = value;
        }
        
    }

    public string Manufacturer
    {
        get { return manufacturer ?? "NoManufacturer"; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Виробник не може бути порожнім.");
            manufacturer = value;
        }
    }

    public double FlightRange
    {
        get { return flightRange; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Дальність польоту має бути більше 0.");
            flightRange = value;
        }
    }

    public int CrewCount
    {
        get { return crewCount; }
        set
        {
            if (crewCount < 0)
                throw new ArgumentException("Кількість екіпажу не може бути від'ємною.");
            crewCount = value;
        }
    }

    public double PayloadCapacity
    {
        get { return payloadCapacity; }
        set
        {
            if (payloadCapacity <= 0)
                throw new ArgumentException("Вантажопідйомність має бути більше 0.");
            payloadCapacity = value;
        }
    }

    public string FuelType
    {
        get { return fuelType?? "NoFuelType"; }
        set
        {
            if (string.IsNullOrEmpty(fuelType))
                throw new ArgumentException("Тип палива не може бути порожнім.");
            fuelType = value;
        }
    }
    

    public abstract string GetDetails();

    public override string ToString() => 
        $"Назва: {name?? "NoName"}, Виробник: {manufacturer ?? "NoManufacturer"}, Рік: {year}, Макс. висота: {maxAltitude} м, " +
        $"Дальність: {flightRange} км, Екіпаж: {crewCount}, Вантажопідйомність: {payloadCapacity} кг, Паливо: {fuelType?? "NoFuelType"}";
}