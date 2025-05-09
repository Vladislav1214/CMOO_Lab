using Cm1_Lab_8.Class;

namespace Cm1_Lab_8.DataGenerator;
public class DataGeneratorSuitcase
{
    private static readonly string[] colors = { "чорний", "синій", "червоний", "сірий", "зелений" };
    private static readonly string[] brands = { "Samsonite", "Nike", "Adidas", "American Tourister", "Travel Pro" };

    private static readonly Random rnd = new Random();

    public static Suitcase DataGeneratorRandomSuitcase()
    {
        string color = colors[rnd.Next(colors.Length)];
        string brand = brands[rnd.Next(brands.Length)];
        double weight = Math.Round(rnd.NextDouble() * 4 + 2, 1);
        double volume = Math.Round((double)rnd.Next(30, 81), 1);

        return new Suitcase(color, brand, weight, volume);
    }
}