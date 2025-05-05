﻿namespace Cm1_Lab_7;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        bool flag = true;
        while (flag)
        {
            Console.Clear();
            
            Console.WriteLine(" ");
            
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                {
                    Syllabus syllabus = SampleDataGeneratorSyllabus.GenerateRandomSyllabus();

                    Console.WriteLine("Початковий список предметів:");
                    Syllabus.DisplaySyllabus(syllabus);

                    // Додаємо нові предмети
                    syllabus.Add(DataGeneratorSubject.GenerateRandomSubject());
                    syllabus.Add(DataGeneratorSubject.GenerateRandomSubject());

                    Console.WriteLine("\nСписок після додавання нових предметів:");
                    Syllabus.DisplaySyllabus(syllabus);

                    // Сортуємо об'єкти за назвою предмету і датою екзамену (IComparable)
                    Syllabus.SortSyllabus(syllabus);

                    Console.WriteLine("\nВідсортований список предметів:");
                    Syllabus.DisplaySyllabus(syllabus);

                    // Зберігаємо вміст контейнера у файл
                    string fileName = "syllabus.txt";

                    string path1 = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Work_1", "Test_txt",
                        $"{fileName}");
                    syllabus.Save(path1);

                    Console.WriteLine($"\nДані збережено у файл: {fileName}");
                    Console.WriteLine($"IsDataSaved: {syllabus.IsDataSaved}");

                    // Створюємо новий контейнер, копіюючи перші 2 елементи
                    Syllabus newSyllabus = Syllabus.CopyFirstElements(syllabus, 2);

                    Console.WriteLine("\nНовий контейнер з першими 2 елементами:");
                    Syllabus.DisplaySyllabus(newSyllabus);

                    // Зберігаємо новий контейнер у файл
                    string newFileName = "new_syllabus.txt";

                    string path2 = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Work_1", "Test_txt",
                        $"{newFileName}");
                    newSyllabus.Save(path2);

                    Console.WriteLine($"\nДані нового контейнера збережено у файл: {newFileName}");

                    // Демонстрація роботи з foreach (IEnumerable)
                    Console.WriteLine("\nВиведення предметів за допомогою foreach:");
                    foreach (Subject subject in syllabus)
                    {
                        Console.WriteLine($" - {subject}");
                    }

                    // Демонстрація видалення елементу
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

                    Console.WriteLine("\nСписок після видалення:");
                    Syllabus.DisplaySyllabus(syllabus);

                    // Демонстрація завантаження даних з файлу
                    Console.WriteLine("\nСтворення нового контейнера та завантаження даних з файлу:");
                    Syllabus loadedSyllabus = new Syllabus();
                    loadedSyllabus.Load(fileName);

                    Console.WriteLine("Дані завантажено з файлу:");
                    Syllabus.DisplaySyllabus(loadedSyllabus);
                    
                    flag = false;
                    break;
                }
                case 2:
                {
                    Registry registry = new Registry();
                    
                    registry.AddDevice(new Airplane("Boeing 737", 2015, 850, true,
                        27300, "Турбореактивний", 189, "Крило", "Алюміній"));

                    registry.AddDevice(new Helicopter("Bell 429", 2018, 287, true,
                        1100, "Газотурбінний", 4, "Несний гвинт", "Карбон"));

                    registry.AddDevice(new HotAirBalloon("Cameron Z-90", 2020, 25, false,
                        2550, "Оболонка", "Нейлон"));

                    registry.AddDevice(new Deltaplane("Wills Wing T3", 2022, 100, false,
                        14.8, "Крило", "Дакрон"));

                    registry.AddDevice(new FlyingCarpet("Килим-Самоліт", 1001, 120, false,
                        3.0, 2.0, "Основа", "Шовк"));

                    // Демонстрація всіх пристроїв
                    registry.DisplayAllDevices();

                    // Демонстрація електронних пристроїв
                    registry.DisplayElectronicDevices();

                    // Демонстрація пристроїв без двигунів
                    registry.DisplayDevicesWithoutEngine();

                    // Сортування за роком виробництва
                    Console.WriteLine("\n==== СПИСОК ПІСЛЯ СОРТУВАННЯ ЗА РОКОМ ВИРОБНИЦТВА ====");
                    registry.SortByYear();
                    registry.DisplayAllDevices();

                    // Сортування за швидкістю
                    Console.WriteLine("\n==== СПИСОК ПІСЛЯ СОРТУВАННЯ ЗА ШВИДКІСТЮ ====");
                    registry.SortBySpeed();
                    registry.DisplayAllDevices();

                    // Демонстрація клонування
                    Console.WriteLine("\n==== ДЕМОНСТРАЦІЯ КЛОНУВАННЯ ====");
                    List<Device> copies = registry.GetDeviceCopies();
                    foreach (Device device in copies)
                    {
                        Console.WriteLine();
                        device.DisplayInfo();
                    }
                    
                    flag = false;
                    break;
                }
                case 3:
                {
                    // Тестовий рядок
                    string testString = "Hello World!";
                    Console.WriteLine($"Оригінальний рядок: {testString}");

                    // Тестування ACipher
                    Console.WriteLine("\nТестування ACipher (зсув на одну позицію):");
                    ICipher aCipher = new ACipher();
                    string encoded = aCipher.Encode(testString);
                    Console.WriteLine($"Зашифрований: {encoded}");
                    string decoded = aCipher.Decode(encoded);
                    Console.WriteLine($"Дешифрований: {decoded}");

                    // Тестування BCipher
                    Console.WriteLine("\nТестування BCipher (заміна на протилежну літеру в алфавіті):");
                    ICipher bCipher = new BCipher();
                    encoded = bCipher.Encode(testString);
                    Console.WriteLine($"Зашифрований: {encoded}");
                    decoded = bCipher.Decode(encoded);
                    Console.WriteLine($"Дешифрований: {decoded}");

                    // Інтерактивний режим
                    Console.WriteLine("\n=== Інтерактивний режим ===");
                    Console.WriteLine("Виберіть тип шифрування:");
                    Console.WriteLine("1. ACipher (зсув на одну позицію)");
                    Console.WriteLine("2. BCipher (заміна на протилежну літеру в алфавіті)");

                    Console.Write("Ваш вибір (1-2): ");
                    string choice = Console.ReadLine();

                    ICipher cipher = null;
                    switch (choice)
                    {
                        case "1":
                            cipher = new ACipher();
                            break;
                        case "2":
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


                    flag = false;
                    break;
                }
                case 4:
                {
                    Registry registry = new Registry();

                    // Створюємо генератор випадкових пристроїв
                    DataGeneratorRandomDevice generator = new DataGeneratorRandomDevice();

                    Console.Write("Вкажіть, скільки випадкових пристроїв створити (рекомендовано 5-20): ");
                    int count;
                    if (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
                    {
                        count = 10; // Значення за замовчуванням
                        Console.WriteLine($"Використовуємо значення за замовчуванням: {count} пристроїв");
                    }

                    // Заповнюємо реєстр випадковими пристроями
                    generator.FillRegistry(registry, count);

                    bool exit = false;
                    while (!exit)
                    {
                        Console.WriteLine("\nОберіть опцію:");
                        Console.WriteLine("1. Показати всі пристрої");
                        Console.WriteLine("2. Показати тільки електронні пристрої");
                        Console.WriteLine("3. Показати пристрої без двигунів");
                        Console.WriteLine("4. Сортувати за роком виробництва");
                        Console.WriteLine("5. Сортувати за максимальною швидкістю");
                        Console.WriteLine("6. Сортувати за назвою");
                        Console.WriteLine("7. Додати новий випадковий пристрій");
                        Console.WriteLine("0. Вихід");

                        Console.Write("\nВаш вибір: ");
                        string choice = Console.ReadLine();

                        Console.WriteLine();

                        switch (choice)
                        {
                            case "1":
                            {
                                registry.DisplayAllDevices();
                                break;
                            }
                            case "2":
                            {
                                registry.DisplayElectronicDevices();
                                break;
                            }
                            case "3":
                            {
                                registry.DisplayDevicesWithoutEngine();
                                break;
                            }
                            case "4":
                            {
                                registry.SortByYear();
                                Console.WriteLine("Пристрої відсортовано за роком виробництва.");
                                registry.DisplayAllDevices();
                                break;
                            }
                            case "5":
                            {
                                registry.SortBySpeed();
                                Console.WriteLine("Пристрої відсортовано за максимальною швидкістю.");
                                registry.DisplayAllDevices();
                                break;
                            }
                            case "6":
                            {
                                registry.SortByName();
                                Console.WriteLine("Пристрої відсортовано за назвою.");
                                registry.DisplayAllDevices();
                                break;
                            }
                            case "7":
                            {
                                Device newDevice = generator.CreateRandomDevice();
                                registry.AddDevice(newDevice);
                                Console.WriteLine($"Додано новий пристрій: {newDevice.Name}");
                                break;
                            }
                            case "0":
                            {
                                exit = true;
                                Console.WriteLine("Дякуємо за використання програми!");
                                break;
                            }
                            default:
                                Console.WriteLine("Невідома команда. Спробуйте ще раз.");
                                break;
                        }
                    }
                    flag = false;
                    break;
                }
                default:
                    Console.WriteLine("Невідома команда. Спробуйте ще раз.");
                    flag = true;
                    break;
            }

            if (!flag)
            {
                Console.Write("Продовжити(1) Завершити(0): ");
                if (Convert.ToInt32(Console.ReadLine()) == 1)
                {
                    flag = true;
                }
            }
        }
    }
}