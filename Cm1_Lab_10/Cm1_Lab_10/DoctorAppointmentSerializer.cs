using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace Cm1_Lab_10;

public class DoctorAppointmentSerializer
{
    #pragma warning disable SYSLIB0011
    static BinaryFormatter formatter = new BinaryFormatter();
    #pragma warning restore SYSLIB0011

    static XmlSerializer xmlSerializer = new XmlSerializer(typeof(DoctorAppointment[]));
    
    public static void SerializeBinary(DoctorAppointment[] appointments)
    {
        Console.WriteLine("Введіть назву файлу");
        string filename = Console.ReadLine() + ".dat";
        using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
        {
            //formatter.Serialize(fs, appointments);
            Console.WriteLine($"Об’єкт серіалізовано до файлу {filename}");
        }
    }

    public static void DeserializeBinary()
    {
        Console.WriteLine("Введіть назву файлу");
        string filename = Console.ReadLine() + ".dat";
        using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
        {
            DoctorAppointment[] newDoctorAppointment = (DoctorAppointment[])formatter.Deserialize(fs);
            foreach (var appointment in newDoctorAppointment)
                Console.WriteLine(appointment.ToString());
        }
    }
    
    public static void SerializeXML(DoctorAppointment[] appointments)
    {
        Console.WriteLine("Введіть назву файлу");
        string filename = Console.ReadLine() + ".xml";
        using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
        {
            xmlSerializer.Serialize(fs, appointments);
            Console.WriteLine($"Об’єкт серіалізовано до файлу {filename}");
        }
    }

    public static void DeserializeXML()
    {
        Console.WriteLine("Введіть назву файлу");
        string filename = Console.ReadLine() + ".xml";
        using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
        {
            DoctorAppointment[]? newDoctorAppointment = xmlSerializer.Deserialize(fs) as DoctorAppointment[];
            if (newDoctorAppointment != null)
                foreach (var appointment in newDoctorAppointment)
                    Console.WriteLine(appointment.ToString());
        }
    }

    public async static void SerializeJSON(DoctorAppointment[] appointments)
    {
        Console.WriteLine("Введіть назву файлу");
        string filename = Console.ReadLine() + ".json";
        using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
        {
            await JsonSerializer.SerializeAsync<DoctorAppointment[]>(fs, appointments);
            Console.WriteLine($"Об’єкт серіалізовано до файлу {filename}");
        }
    }
    
    public async static void DeserializeJSON()
    {
        Console.WriteLine("Введіть назву файлу");
        string filename = Console.ReadLine() + ".json";
        using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
        {
            DoctorAppointment[]? newDoctorAppointment = await JsonSerializer.DeserializeAsync<DoctorAppointment[]>(fs);
            if (newDoctorAppointment != null)
                foreach (var appointment in newDoctorAppointment)
                    Console.WriteLine(appointment.ToString());
        }
    }
}