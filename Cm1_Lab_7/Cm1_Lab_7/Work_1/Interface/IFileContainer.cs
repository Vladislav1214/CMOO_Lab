namespace Cm1_Lab_7;

public interface IFileContainer : IContainer
{
    // Зберегти вміст контейнера у текстовий файл
    void Save(String fileName);
    
    // Завантажити дані з текстового файлу
    void Load(String fileName);
    
    // Повертає true, якщо дані були збережені у файл
    // Повертає false, якщо не були збережені у файл
    Boolean IsDataSaved { get; }
}