using Cm1_Lab_8.Class;

namespace Cm1_Lab_8.DataGenerator;
public class DataGeneratorItem
{
    private static readonly string[] itemNames = {
        "Футболка", "Штани", "Ноутбук", "Книга", "Кросівки", "Зарядка", "Фен", "Пляшка", "Годинник", "Плед"
    };

    private static readonly Random rnd = new Random();

    public static Item DataGeneratorRandomItem()
    {
        string name = itemNames[rnd.Next(itemNames.Length)];
        double volume = Math.Round(rnd.NextDouble() * 6 + 1, 2); // від 0.5 до 5.5 л
        return new Item(name, volume);
    }
}