namespace Cm1_Lab_7;

public interface IContainer
{
    int Count { get; }
    
    Object this[int index] { get; set; }
    
    void Add(Subject element);
    
    void Delete(Subject element);
}