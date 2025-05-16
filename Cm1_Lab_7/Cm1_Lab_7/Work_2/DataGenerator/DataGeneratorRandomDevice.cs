namespace Cm1_Lab_7;

public class DataGeneratorRandomDevice
{
    private readonly DataGeneratorDevice[] _factories;
    private readonly Random _random;
    
    public DataGeneratorRandomDevice()
    {
        _factories = new DataGeneratorDevice[]
        {
            new DataGeneratorAirplane(),
            new DataGeneratorHelicopter(),
            new DataGeneratorHotAirBalloon(),
            new DataGeneratorDeltaplane(),
            new DataGeneratorFlyingCarpet()
        };
        
        _random = new Random();
    }
    
    // Створення випадкового пристрою
    public Device CreateRandomDevice()
    {
        int index = _random.Next(_factories.Length);
        return _factories[index].CreateDevice();
    }
    
    // Заповнення реєстру вказаною кількістю випадкових пристроїв
    public void FillRegistry(Registry registry, int count)
    {
        for (int i = 0; i < count; i++)
        {
            registry.AddDevice(CreateRandomDevice());
        }
    }}