namespace Cm1_Lab_10;

public class DoctorAppointmentUtility
{
    private static readonly Random random = new Random();

    private static readonly string[] doctorNames = { 
        "Іванов Іван Іванович", "Петрова Анна Сергіївна", "Сидоренко Олег Петрович", 
        "Коваленко Марія Іванівна", "Шевченко Тарас Григорович", "Мельник Віктор Степанович", 
        "Бондаренко Ірина Олексіївна", "Ткаченко Олександр Андрійович", "Ковальчук Наталія Володимирівна", 
    };
    private static readonly string[] qualifications = { 
        "Терапевт", "Хірург", "Педіатр", "Кардіолог", "Невролог", 
        "Гастроентеролог", "Офтальмолог", "Отоларинголог", 
        "Дерматолог", "Алерголог", "Ортопед", "Психіатр", "Стоматолог"
    };
    private static readonly string[] patientNames = { 
        "Козлов Микола", "Савчук Олена", "Бондаренко Ігор", "Лисенко Юлія", 
        "Мороз Андрій", "Ковальчук Тетяна", "Шевчук Василь", "Дубовий Сергій", 
        "Мельник Оксана", "Пономаренко Роман", "Кравченко Ліна", "Захарчук Євген", 
    };
    public static DoctorAppointment CreateRandomAppointment(int doctorIndex)
    {
        // Обираємо випадкових 0-4 пацієнтів
        int patientCount = random.Next(0, 5);
        string[] registeredPatients = new string[patientCount];
        for (int i = 0; i < patientCount; i++)
        {
            registeredPatients[i] = patientNames[random.Next(patientNames.Length)];
        }

        // Створюємо об'єкт запису до лікаря
        DoctorAppointment appointment = new DoctorAppointment(
            doctorNames[random.Next(doctorNames.Length)],
            qualifications[random.Next(qualifications.Length)],
            DateTime.Today.AddDays(random.Next(1, 30)).AddHours((doctorIndex) % 2 == 0 ? random.Next(8, 13) : random.Next(13, 18)),
            random.Next(1, 20),
            random.Next(10, 31),
            registeredPatients
        );
        
        return appointment;
    }
    
    public static DoctorAppointment[] CreateAppointmentArray(int doctorCount)
    {
        var appointments = new DoctorAppointment[doctorCount];
        for (int i = 0; i < doctorCount; i++)
        {
            appointments[i] = CreateRandomAppointment(i);
        }

        return appointments;
    }
}