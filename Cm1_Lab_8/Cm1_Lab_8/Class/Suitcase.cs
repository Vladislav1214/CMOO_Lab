namespace Cm1_Lab_8.Class;

public class Suitcase
{
   public string? Color { get; set; }
   public string? Brand { get; set; }
   public double Weight { get; set; }
   public double MaxVolume { get; set; }
   private Item[] _items;
   
   public event Action<Item>? ItemAdded;
   public event Action<Item>? ItemRemoved;
   
   public Suitcase(string color, string brand, double weight, double maxVolume)
   {
      Color = color;
      Brand = brand;
      Weight = weight;
      MaxVolume = maxVolume;
      _items = new Item[0];
   }

   public Suitcase()
   {
      _items = new Item[0];
   }
   
   public double ItemsVolume =>
      _items.Sum(i => i.Volume);
   
   public void AddItem(Item item)
   {
      if (ItemsVolume + item.Volume > MaxVolume)
         throw new VolumeExceededException($"Не можна додати '{item.Name}': об'єм перевищено.");
      
      int newLength = _items.Length + 1;
      Array.Resize(ref _items, newLength);
      _items[newLength - 1] = item;
      
      ItemAdded?.Invoke(item);
   }
   
   public bool RemoveItemByIndex(int index)
   {
      if (index >= 0 && index < _items.Length)
      {
         Item removedItem = _items[index];
         
         Item[] result = new Item[_items.Length - 1];

         if (index > 0)
            Array.Copy(_items, 0, result, 0, index);
         
         if (index < _items.Length - 1)
            Array.Copy(_items, index + 1, result, index, _items.Length - index - 1);
         
         _items = result;
         
         ItemRemoved?.Invoke(removedItem);
         return true;
      }
      return false;
   }
   

   public Item[] Items
   {
      get
      {
         return _items;
      }
   }

   public void Clear()
   {
      _items = new Item[0];
   }
   
   public override string ToString()
   {
      return $"Валіза {Brand?? "NoBrand"}, колір: {Color?? "NoColor"}, вага: {Weight} кг, обʼєм: {MaxVolume} л. Заповнено: {Math.Round(ItemsVolume, 2)} л.";
   }
}


//колір; фірма-виробник; вага валізи; об’єм валізи; вміст валізи (список об’єктів, у кожного