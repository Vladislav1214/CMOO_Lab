namespace Cm1_Lab_7;

public class DataGeneratorRandomDevice
{
    private readonly List<DataGeneratorDevice> factories;
    private readonly Random random;
    
    public DataGeneratorRandomDevice()
    {
        factories = new List<DataGeneratorDevice>
        {
            new DataGeneratorAirplane(),
            new DataGeneratorHelicopter(),
            new DataGeneratorHotAirBalloon(),
            new DataGeneratorDeltaplane(),
            new DataGeneratorFlyingCarpet()
        };
        
        random = new Random();
    }
    
    // Створення випадкового пристрою
    public Device CreateRandomDevice()
    {
        int index = random.Next(factories.Count);
        return factories[index].CreateDevice();
    }
    
    // Заповнення реєстру вказаною кількістю випадкових пристроїв
    public void FillRegistry(Registry registry, int count)
    {
        for (int i = 0; i < count; i++)
        {
            registry.AddDevice(CreateRandomDevice());
        }
    }}