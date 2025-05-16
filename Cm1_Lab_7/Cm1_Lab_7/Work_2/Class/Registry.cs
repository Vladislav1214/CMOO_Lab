namespace Cm1_Lab_7;

public class Registry
{
    private Device[] _devices;

    public Registry(Device[] devices)
    {
        _devices = devices;
    }

    public Registry()
    {
        _devices = new Device[0];
    }

    // Додати пристрій до реєстру
    public void AddDevice(params Device[] newDevice)
    {
        if (newDevice != null && newDevice.Length != 0)
        {
            int oldLength = _devices.Length;
            Array.Resize(ref _devices, oldLength + newDevice.Length);
            for (int i = 0; i < newDevice.Length; i++)
                _devices[oldLength + i] = newDevice[i];
        }
    }

    // Вивести список всього обладнання
    public void DisplayAllDevices()
    {
        if (_devices.Length != 0)
        {
            Console.WriteLine("==== Список всього обладнання ====");
            foreach (var device in _devices)
            {
                device.DisplayInfo();
                Console.WriteLine("--------------------------------");
            }
        }
    }

    // Вивести список електронного обладнання
    public void DisplayElectronicDevices()
    {
        if (_devices.Length != 0)
        {
            Console.WriteLine("==== Список електронного обладнання ====");
            foreach (var device in _devices.Where(d => d.HasElectronics))
            {
                device.DisplayInfo();
                Console.WriteLine("--------------------------------");
            }
        }
    }

    // Вивести список обладнання без двигунів
    public void DisplayDevicesWithoutEngine()
    {
        if (_devices.Length != 0)
        {
            Console.WriteLine("==== Список обладнання без двигунів ====");
            foreach (var device in _devices.Where(d => !(d is IEngine)))
            {
                device.DisplayInfo();
                Console.WriteLine("--------------------------------");
            }
        }
    }

    // Сортування за роком виробництва (використовуючи IComparable)
    public void SortByYear()
    {
        if (_devices.Length != 0)
            Array.Sort(_devices);
    }

    // Сортування за швидкістю (використовуючи IComparer)
    public void SortBySpeed()
    {
        if (_devices.Length != 0)
            Array.Sort(_devices, 0, _devices.Length, new SpeedComparer());
    }

    // Сортування за назвою (використовуючи IComparer)
    public void SortByName()
    {
        if (_devices.Length != 0)
            Array.Sort(_devices, 0, _devices.Length, new NameComparer());
    }

    // Отримати копії всіх пристроїв
    public Device[] GetDeviceCopies()
    {
        if (_devices.Length != 0)
        {

            Device[] copies = new Device[_devices.Length];
            for (int i = 0; i < copies.Length; i++)
                copies[i] = (Device)_devices[i].Clone();

            return copies;
        }
        
        return new Device[0];
    }
}