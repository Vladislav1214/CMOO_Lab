namespace Cm1_Lab_10;

class Program
{
    
    static void Main(string[] args)
    {
        bool flag = true;
        DoctorAppointment[] appointments = DoctorAppointmentUtility.CreateAppointmentArray(6);
        
        while (flag)
        {
            Console.WriteLine("\nОберіть опцію:");
            Console.WriteLine("1 - Серіалізувати дані у бінарний файл");
            Console.WriteLine("2 - Десеріалізувати дані з бінарного файлу");
            Console.WriteLine("3 - Серіалізувати дані у XML файл");
            Console.WriteLine("4 - Десеріалізувати дані з XML файлу");
            Console.WriteLine("5 - Серіалізувати дані у JSON файл");
            Console.WriteLine("6 - Десеріалізувати дані з JSON файлу");
            Console.WriteLine("7 - Створити новий набір призначень");
            Console.WriteLine("0 - Вихід");
            Console.Write("Ваш вибір: ");
            
            int menu = int.TryParse(Console.ReadLine(), out int index) ? index : 0;
            
            switch (menu)
            {
                case 1:
                {
                    DoctorAppointmentSerializer.SerializeBinary(appointments);
                    break;
                }
                case 2:
                {
                    DoctorAppointmentSerializer.DeserializeBinary();
                    break;
                }
                case 3:
                {
                    DoctorAppointmentSerializer.SerializeXML(appointments);
                    break;
                }
                case 4:
                {
                    DoctorAppointmentSerializer.DeserializeXML();
                    break;
                }
                case 5:
                {
                    DoctorAppointmentSerializer.SerializeJSON(appointments);
                    break;
                }
                case 6:
                {
                    DoctorAppointmentSerializer.DeserializeJSON();
                    break;
                }
                case 7:
                {
                    Console.Write("Введіть кількість записів: ");
                    int count = int.TryParse(Console.ReadLine(), out int c) ? c : 6;
                    appointments = DoctorAppointmentUtility.CreateAppointmentArray(count);
                    Console.WriteLine($"Створено {count} нових записів до лікаря");
                    break;
                }
                case 0:
                {
                    flag = false;
                    break;
                }
                default:
                    Console.WriteLine("Невірний вибір");
                    break;
            }
        }
    }
}