namespace Cm1_Lab_7;

public interface IContainer
{
    // Кількість елементів у контейнері.
    int Count { get; }
    
    // Індексатор контейнера.
    Object this[int index] { get; set; }
    
    // Додати елемент у контейнер.
    void Add(Subject element);
    
    // Видалити елемент з контейнеру.
    void Delete(Subject element);
}