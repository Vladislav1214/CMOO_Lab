namespace Cm1_Lab_7;

class Program
{
    public static int CheckingForANumberIn()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int number))
                return number;
            
            Console.Write("Введіть повторно: ");
        }
    }
    
     static void WorkWithSyllabus()
    {
        Syllabus syllabus;
        try
        {
            syllabus = SampleDataGeneratorSyllabus.GenerateRandomSyllabus();

            Console.WriteLine("Початковий список предметів:");
            Syllabus.DisplaySyllabus(syllabus);
            
            try
            {
                syllabus.Add(DataGeneratorSubject.GenerateRandomSubject());
                syllabus.Add(DataGeneratorSubject.GenerateRandomSubject());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при додаванні предметів: {ex.Message}");
            }

            Console.WriteLine("\nСписок після додавання нових предметів:");
            Syllabus.DisplaySyllabus(syllabus);
            
            try
            {
                Syllabus.SortSyllabus(syllabus);
                Console.WriteLine("\nВідсортований список предметів:");
                Syllabus.DisplaySyllabus(syllabus);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при сортуванні: {ex.Message}");
            }
            
            try
            {
                string fileName = "syllabus.txt";
                string path1 = "../../../Work_1/Test_txt/" + $"{fileName}";
                
                syllabus.Save(path1);
                Console.WriteLine($"\nДані збережено у файл: {fileName}");
                Console.WriteLine($"IsDataSaved: {syllabus.IsDataSaved}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при збереженні файлу: {ex.Message}");
            }

            // Створюємо новий контейнер, копіюючи перші 2 елементи
            try
            {
                Syllabus newSyllabus = Syllabus.CopyFirstElements(syllabus, 2);
                Console.WriteLine("\nНовий контейнер з першими 2 елементами:");
                Syllabus.DisplaySyllabus(newSyllabus);
                
                string newFileName = "new_syllabus.txt";
                string path2 = "../../../Work_1/Test_txt/" + $"{newFileName}";
                
                newSyllabus.Save(path2);
                Console.WriteLine($"\nДані нового контейнера збережено у файл: {newFileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при створенні або збереженні нового контейнера: {ex.Message}");
            }
            
            try
            {
                Console.WriteLine("\nВиведення предметів за допомогою foreach:");
                foreach (Subject subject in syllabus)
                    Console.WriteLine($" - {subject}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при виведенні через foreach: {ex.Message}");
            }
            
            try
            {
                Console.WriteLine("\nВидалення предмету 'Математика':");
                Subject mathSubject = null;
                foreach (Subject subject in syllabus)
                {
                    if (subject.Name == "Математика")
                    {
                        mathSubject = subject;
                        break;
                    }
                }

                if (mathSubject != null)
                {
                    syllabus.Delete(mathSubject);
                    Console.WriteLine("Предмет видалено");
                }
                else
                {
                    Console.WriteLine("Предмет 'Математика' не знайдено");
                }

                Console.WriteLine("\nСписок після видалення:");
                Syllabus.DisplaySyllabus(syllabus);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при видаленні предмету: {ex.Message}");
            }
            
            try
            {
                Console.WriteLine("\nСтворення нового контейнера та завантаження даних з файлу:");
                Syllabus loadedSyllabus = new Syllabus();
                string fileName = "syllabus.txt";
                string path = "../../../Work_1/Test_txt/" + $"{fileName}";
                
                if (File.Exists(path))
                {
                    loadedSyllabus.Load(path);
                    Console.WriteLine("Дані завантажено з файлу:");
                    Syllabus.DisplaySyllabus(loadedSyllabus);
                }
                else
                {
                    Console.WriteLine($"Файл {fileName} не знайдено");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при завантаженні даних з файлу: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Загальна помилка при роботі з Syllabus: {ex.Message}");
        }
    }

    static void WorkWithRegistry()
    {
        Registry registry = new Registry();

        DataGeneratorRandomDevice generator = new DataGeneratorRandomDevice();

        Console.Write("Вкажіть, скільки випадкових пристроїв створити: ");
        int count = CheckingForANumberIn();
        if (count <= 0)
        {
            count = 10;
            Console.WriteLine($"Використовуємо значення за замовчуванням: {count} пристроїв");
        }
        
        generator.FillRegistry(registry, count);

        bool flag = false;
        while (!flag)
        {
            Console.WriteLine("Оберіть опцію:");
            Console.WriteLine("1. Показати всі пристрої");
            Console.WriteLine("2. Показати тільки електронні пристрої");
            Console.WriteLine("3. Показати пристрої без двигунів");
            Console.WriteLine("4. Сортувати за роком виробництва");
            Console.WriteLine("5. Сортувати за максимальною швидкістю");
            Console.WriteLine("6. Сортувати за назвою");
            Console.WriteLine("7. Додати новий випадковий пристрій");
            Console.WriteLine("0. Вихід");
            Console.Write("Ваш вибір: ");

            switch (CheckingForANumberIn())
            {
                case 1:
                {
                    registry.DisplayAllDevices();
                    break;
                }
                case 2:
                {
                    registry.DisplayElectronicDevices();
                    break;
                }
                case 3:
                {
                    registry.DisplayDevicesWithoutEngine();
                    break;
                }
                case 4:
                {
                    registry.SortByYear();
                    Console.WriteLine("Пристрої відсортовано за роком виробництва.");
                    registry.DisplayAllDevices();
                    break;
                }
                case 5:
                {
                    registry.SortBySpeed();
                    Console.WriteLine("Пристрої відсортовано за максимальною швидкістю.");
                    registry.DisplayAllDevices();
                    break;
                }
                case 6:
                {
                    registry.SortByName();
                    Console.WriteLine("Пристрої відсортовано за назвою.");
                    registry.DisplayAllDevices();
                    break;
                }
                case 7:
                {
                    Device newDevice = generator.CreateRandomDevice();
                    registry.AddDevice(newDevice);
                    Console.WriteLine($"Додано новий пристрій: {newDevice.Name}");
                    break;
                }
                case 8:
                {
                    Console.WriteLine("Демонстрація клонування.");
                    Device[] copies = registry.GetDeviceCopies();
                    foreach (Device device in copies)
                    {
                        Console.WriteLine();
                        device.DisplayInfo();
                    }

                    break;
                }
                case 0:
                {
                    flag = true;
                    Console.WriteLine("Завершення роботи програми.");
                    break;
                }
                default:
                    Console.WriteLine("Невідома команда. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void WorkWithCipher()
    {
        string testString = "Hello World! Тестування";
        Console.WriteLine($"Оригінальний рядок: {testString}");
        
        Console.WriteLine("\nТестування ACipher (зсув на одну позицію):");
        ICipher aCipher = new ACipher();
        string encoded = aCipher.Encode(testString);
        Console.WriteLine($"Зашифрований: {encoded}");
        string decoded = aCipher.Decode(encoded);
        Console.WriteLine($"Дешифрований: {decoded}");

        Console.WriteLine("\nТестування BCipher (заміна на протилежну літеру в алфавіті):");
        ICipher bCipher = new BCipher();
        encoded = bCipher.Encode(testString);
        Console.WriteLine($"Зашифрований: {encoded}");
        decoded = bCipher.Decode(encoded);
        Console.WriteLine($"Дешифрований: {decoded}");

        Console.WriteLine("Інтерактивний режим");
        Console.WriteLine("Виберіть тип шифрування:");
        Console.WriteLine("1. ACipher (зсув на одну позицію)");
        Console.WriteLine("2. BCipher (заміна на протилежну літеру в алфавіті)");

        Console.Write("Ваш вибір (1-2): ");

        ICipher cipher;
        switch (CheckingForANumberIn())
        {
            case 1:
                cipher = new ACipher();
                break;
            case 2:
                cipher = new BCipher();
                break;
            default:
                Console.WriteLine("Некоректний вибір. Використовується ACipher.");
                cipher = new ACipher();
                break;
        }

        Console.Write("Введіть текст для шифрування: ");
        string userText = Console.ReadLine();

        string userEncoded = cipher.Encode(userText);
        Console.WriteLine($"Зашифрований текст: {userEncoded}");

        string userDecoded = cipher.Decode(userEncoded);
        Console.WriteLine($"Дешифрований текст: {userDecoded}");
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        bool flag = true;
        while (flag)
        {
            Console.WriteLine("\n=== Головне меню ===");
            Console.WriteLine("1. Робота з предметами (Syllabus)");
            Console.WriteLine("2. Робота з реєстром літальних апаратів (Registry)");
            Console.WriteLine("3. Робота з шифруванням (ACipher, BCipher)");
            Console.WriteLine("0. Вихід");
            Console.Write("Ваш вибір: ");
            
            switch (CheckingForANumberIn())
            {
                case 1:
                {
                    WorkWithSyllabus();
                    break;
                }
                case 2:
                {
                    WorkWithRegistry();
                    break;
                }
                case 3:
                {
                    WorkWithCipher();
                    break;
                }
                case 0:
                {
                    flag = false;
                    Console.WriteLine("Завершення роботи програми...");
                    break;
                }
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
            
            Console.ReadKey();
            Console.Clear();
        }
    }
}