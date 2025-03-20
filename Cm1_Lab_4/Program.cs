using System.Text;
using System.Text.RegularExpressions;

namespace Cm1_Lab_4
{
    internal class Program
    {

        static int CheckingForANumberInt()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number))           
                    return number;
                else
                {
                    Console.WriteLine("Введені дані не є числом");
                    Console.Write("Введіть повторно: ");
                }
            }
        }

        static int InputMethodSelection()
        {
            Console.WriteLine("Виберіть метод введеня:");
            Console.WriteLine("Введення користувачем (1)");
            Console.WriteLine("Введення з файлу (2)");
            Console.Write("Ваш вибір: ");
            return CheckingForANumberInt();
        }

        static string LoadArrayFromFileArray()
        {
            Console.WriteLine("Введіть назву файлу: .....(.txt)");
            string fileName = Console.ReadLine() + ".txt";//"Test.txt";

            try
            {
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException("Файл не знайдено", fileName);
                }

                using (StreamReader fileContentLoad = new StreamReader(fileName))
                {
                    return fileContentLoad.ReadLine();
                }
                //return File.ReadAllLines(fileName);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
                return "001";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Сталася непередбачена помилка: {ex.Message}");
                return "002"; 
            }
        }
        static void UpLoadArrayFromFileArray(string UpLoad)
        {
           using (StreamWriter fileContentUpLoad = new StreamWriter("TestUpLoad.txt"))
           {
                fileContentUpLoad.WriteLine(UpLoad);
           }
        }


        static string CreateStr()
        {
            while (true)
            {
                Console.Clear();
                switch (InputMethodSelection())
                {
                    case 1:
                        {
                            return Console.ReadLine(); 
                        }
                    case 2:
                        {
                            string fileContent = LoadArrayFromFileArray();

                            if (fileContent == null || fileContent == "001")
                            {
                                Console.WriteLine("Файл пустий, введіть текст вручну:");
                                return Console.ReadLine();
                            }                           
                            else if (fileContent == "002")
                            {
                                Console.WriteLine("Сталася помилка читання файлу, спробуйте ще раз.");
                                continue;
                            }

                            Console.WriteLine($"Результат з файлу: {fileContent}");
                            return fileContent;
                        }                    
                    default:
                        break;
                }
            }
        }

        static int Menu()
        {
            Console.WriteLine("Завдання (1)");
            Console.WriteLine("Написати регулярний вираз, який визначає, чи є заданий рядок IP " +
                "\nадресою, що записана у десятковому вигляді." +
                "\n– правильний вираз: 127.0.0.1, 255.255.255.0." +
                "\n– неправильний вираз: 1300.6.7.8, abc.def.gha.bcd.\n");
            Console.WriteLine("Завдання (2)");
            Console.WriteLine("Створити запит для вводу тільки правильно написаних виразів з \r\nдужками (кількість відкритих та закритих дужок збігається )." +
                "\n– правильний вираз: (3 + 5) – 9 × 4." +
                "\n– неправильний вираз: ((3 + 5) – 9 × 4.\n");
            Console.WriteLine("Завдання (3)");
            Console.WriteLine("У рядку слів у кожному слові довжиною більше восьми елементів " +
                "\nпоміняти місцями кожні два символи розпочавши з початку слова, " +
                "\nа у інших словах поміняти перший символ та останній.\n");
            Console.Write("Ваш вибір: ");
            return CheckingForANumberInt();
        } 

        static void Objectives()
        {
            bool flag = true;
            while (flag)
            {
                switch (Menu())
                {
                    case 1:
                        {
                            string inputText = CreateStr();
                            Console.Clear();

                            string bracketsOnly = Regex.Replace(inputText, "[^()]", "");
                            string pattern = @"^\s*(\(?\s*\d+\s*[\+\-\*/]\s*\d+\s*\)?\s*[\+\-\*/]\s*\d+\s*[\+\-\*/]\s*\d+\s*)+$";
                            bool isStructureValid = Regex.IsMatch(inputText, pattern);

                            int bracketBalance = 0;
                            bool isBracketOrderCorrect = true;

                            foreach (char character in bracketsOnly)
                            {
                                if (character == '(')
                                    bracketBalance++;
                                else if (character == ')')
                                {
                                    bracketBalance--;
                                    if (bracketBalance < 0)
                                    {
                                        isBracketOrderCorrect = false;
                                        break;
                                    }
                                }
                            }

                            bool isCorrect = isStructureValid && isBracketOrderCorrect && bracketBalance == 0;

                            if (isCorrect)
                                Console.WriteLine("Вираз правильний");
                            else
                            {
                                Console.WriteLine("Вираз неправильний");
                                if (!isBracketOrderCorrect)
                                    Console.WriteLine("Причина: неправильний порядок дужок");
                                else if (bracketBalance != 0)
                                    Console.WriteLine("Причина: кількість дужок не збігається");
                                else if (!isStructureValid)
                                    Console.WriteLine("Причина: неправильна структура виразу");
                            }
                            break;
                        }
                    case 2:
                        {
                            string inputText = CreateStr();
                            // перевірка структури: (числа від 0 до 225, крапка як роздільник)
                            string pattern = @"^([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])$";

                            bool isStructureValid = Regex.IsMatch(inputText, pattern);

                            if (System.Net.IPAddress.TryParse(inputText, out _))
                                Console.WriteLine("IP-адреса правильна");
                            else
                                Console.WriteLine("IP-адреса неправильна");

                            break;
                        }
                    case 3:
                        {
                            string inputText = CreateStr();
                            Console.WriteLine("Початок: " + inputText);
                            Regex regex = new Regex(@"[.\,\`\:\;\']");
                            string result = regex.Replace(inputText, "");
                            string[] words = result.Split(" ");

                            for (int i = 0; i < words.Length; i++)
                            {
                                char[] characters = words[i].ToCharArray();
                                int charCount = characters.Length;

                                if (charCount > 8)
                                    for (int j = 0; j < charCount - 2; j += 2)
                                        (characters[j], characters[j + 2]) = (characters[j + 2], characters[j]);
                                else if (charCount > 1)
                                    (characters[0], characters[charCount - 1]) = (characters[charCount - 1], characters[0]);

                                words[i] = new string(characters);
                            }

                            inputText = string.Join(" ", words);
                            Console.WriteLine("Результат: " + inputText);
                            UpLoadArrayFromFileArray(inputText);
                            break;
                        }
                    default:
                        break;
                }

                Console.WriteLine("Продовження (Number) Вихід (0)");
                if (CheckingForANumberInt() == 0)
                    flag = false;
            }
        }
     
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Objectives();
        }
    }
}