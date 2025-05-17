namespace Cm1_Lab_8.Class;

public class Suitcase
{
   public string? Color { get; set; }
   public string? Brand { get; set; }
   public double Weight { get; set; }
   public double MaxVolume { get; set; }
   
   private Item[] _items;
   private int count;
   private const int INITIAL_SIZE = 10;
   
   public event Action<Item>? ItemAdded;
   public event Action<Item>? ItemRemoved;
   
   public Suitcase(string color, string brand, double weight, double maxVolume)
   {
      Color = color;
      Brand = brand;
      Weight = weight;
      MaxVolume = maxVolume;
      _items = new Item[INITIAL_SIZE];
      count = 0;
   }

   public Suitcase()
   {
      _items = new Item[INITIAL_SIZE];
   }
   
   public int Count { get { return count; } }

   public double ItemsVolume()
   {
      double sum = 0;
      for(var i = 0; i < count; i++)
         sum += _items[i].Volume;
      return sum;
   }
   
   private void EnsureCapacity()
   {
      if (count == _items.Length)
      {
         Item[] newArray = new Item[_items.Length + 2];
         for (int i = 0; i < _items.Length; i++)
         {
            newArray[i] = _items[i];
         }

         _items = newArray;
      }
   }
   
   public void AddItem(Item item)
   {
      if (ItemsVolume() + item.Volume > MaxVolume)
         throw new VolumeExceededException($"Не можна додати '{item.Name}': об'єм перевищено.");
      
      EnsureCapacity();
      _items[count] = item;
      count++;
      
      ItemAdded?.Invoke(item);
   }
   
   public bool RemoveItemByIndex(int index)
   {
      if (index >= 0 && index < count)
      {
         Item removedItem = _items[index];
         
         for (int j = index; j < count - 1; j++)
         {
            _items[j] = _items[j + 1];
         }

         _items[count - 1] = null;
         count--;

         ItemRemoved?.Invoke(removedItem);

         return true;
      }

      return false;
   }
   
   public void Clear()
   {
      _items = new Item[INITIAL_SIZE];
   }

   public Item[] Items
   {
      get
      {
         return _items;
      }
   }
   
   public override string ToString()
   {
      return $"Валіза {Brand?? "NoBrand"}, колір: {Color?? "NoColor"}, вага: {Weight} кг, обʼєм: {MaxVolume} л. Заповнено: {Math.Round(ItemsVolume(), 2)} л.";
   }
}