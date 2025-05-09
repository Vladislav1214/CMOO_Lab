namespace Cm1_Lab_8.Class;

public class Suitcase
{
   public string? Color { get; set; }
   public string? Brand { get; set; }
   public double Weight { get; set; }
   public double MaxVolume { get; set; }
   public List<Item> Items { get; private set; }
   
   public event Action<Item>? ItemAdded;
   public event Action<Item>? ItemRemoved;
   
   public Suitcase(string color, string brand, double weight, double maxVolume)
   {
      Color = color;
      Brand = brand;
      Weight = weight;
      MaxVolume = maxVolume;
      Items = new List<Item>();
   }

   public Suitcase()
   {
      Items = new List<Item>();
   }
   
   public double ItemsVolume =>
      Items.Sum(i => i.Volume);
   
   public void AddItem(Item item)
   {
      if (ItemsVolume + item.Volume > MaxVolume)
         throw new VolumeExceededException($"Не можна додати '{item.Name}': об'єм перевищено.");

      Items.Add(item);
      ItemAdded?.Invoke(item);
   }
   
   public bool RemoveItemByIndex(int index)
   {
      if (index >= 0 && index < Items.Count)
      {
         Item removedItem = Items[index];
         Items.RemoveAt(index);
         ItemRemoved?.Invoke(removedItem); // <- Подія викликається тут
         return true;
      }
      return false;
   }


   public void Clear()
   {
      Items.Clear();
   }
   
   public override string ToString()
   {
      return $"Валіза {Brand?? "NoBrand"}, колір: {Color?? "NoColor"}, вага: {Weight} кг, обʼєм: {MaxVolume} л. Заповнено: {Math.Round(ItemsVolume, 2)} л.";
   }
}


//колір; фірма-виробник; вага валізи; об’єм валізи; вміст валізи (список об’єктів, у кожного