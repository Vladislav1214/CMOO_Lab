namespace Cm1_Lab_7;

public interface IEnumerator
{
    bool MoveNext();
    object Current { get; }
    void Reset();
}