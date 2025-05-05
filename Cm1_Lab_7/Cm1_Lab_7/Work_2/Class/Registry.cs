namespace Cm1_Lab_7;

public class Registry
{
    private List<Device> devices;
    
    public Registry()
    {
        devices = new List<Device>();
    }
    
    // Додати пристрій до реєстру
    public void AddDevice(Device device)
    {
        devices.Add(device);
    }
    
    // Вивести список всього обладнання
    public void DisplayAllDevices()
    {
        Console.WriteLine("==== Список всього обладнання ====");
        foreach (var device in devices)
        {
            device.DisplayInfo();
            Console.WriteLine("--------------------------------");
        }
    }
    
    // Вивести список електронного обладнання
    public void DisplayElectronicDevices()
    {
        Console.WriteLine("==== Список електронного обладнання ====");
        foreach (var device in devices.Where(d => d.HasElectronics))
        {
            device.DisplayInfo();
            Console.WriteLine("--------------------------------");
        }
    }
    
    // Вивести список обладнання без двигунів
    public void DisplayDevicesWithoutEngine()
    {
        Console.WriteLine("==== Список обладнання без двигунів ====");
        foreach (var device in devices.Where(d => !(d is IEngine)))
        {
            device.DisplayInfo();
            Console.WriteLine("--------------------------------");
        }
    }
    
    // Сортування за роком виробництва (використовуючи IComparable)
    public void SortByYear()
    {
        devices.Sort();
    }
    
    // Сортування за швидкістю (використовуючи IComparer)
    public void SortBySpeed()
    {
        devices.Sort(new SpeedComparer());
    }
    
    // Сортування за назвою (використовуючи IComparer)
    public void SortByName()
    {
        devices.Sort(new NameComparer());
    }
    
    // Отримати копії всіх пристроїв
    public List<Device> GetDeviceCopies()
    {
        List<Device> copies = new List<Device>();
        foreach (var device in devices)
        {
            copies.Add((Device)device.Clone());
        }
        return copies;
    }
}