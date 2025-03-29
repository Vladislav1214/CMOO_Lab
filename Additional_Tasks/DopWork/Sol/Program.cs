namespace Sol;

static class Program
{
    static int[,] Random(int n)
    {
        int a = 0, b = 20;

        Random random = new Random();
        
        int[,] arrayA = new int[n, n];
        
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                arrayA[i, j] = random.Next(a, b);

        return arrayA;
    }
    
    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
                Console.Write($"{matrix[i, j],2:D} ");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    
    static int[] FindMaximumWeightZero(int[,] matrix) 
    {
        for (int i = 0; i < matrix.GetLength(0); i++) // зменшення кожного стовпця на найменший ел. в ньому 
        {
            int minElement = matrix[i, 0]; // початкови мінімальний ел.

            for (int j = 1; j < matrix.GetLength(0); j++) // пошук мінімального ел. стовпця
                if (matrix[i, j] < minElement) 
                    minElement = matrix[i, j];

            for (int j = 0; j < matrix.GetLength(0); j++) // зменншення кожного ел. стовпця на найменший
                matrix[i, j] -= minElement;
        }
        
        for (int i = 0; i < matrix.GetLength(0); i++) // зменшення кожного рядка на найменший елемент в ньому
        {
            int minElement = matrix[0, i];

            for (int j = 1; j < matrix.GetLength(0); j++) // пошук мінімального ел. рядка
                if (matrix[j, i] < minElement)
                    minElement = matrix[j, i];

            for (int j = 0; j < matrix.GetLength(0); j++) // зменншення кожного ел. рядка на найменший
                matrix[j, i] -= minElement;
        }

        PrintMatrix(matrix); // Для переірки
        
        int[] index = new int[2]; // індекс першого нуля з найбільшою вагою
        int maxWeight = -1000; // максимальна вага 0 (початкове значення)

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[i, j] == 0) // знаходимо 0
                {
                    int rowWeight = 0; 
                    for (int k = 0; k < matrix.GetLength(0); k++) // сума ел. у рядку 
                        rowWeight += matrix[i, k];

                    int colWeight = 0;
                    for (int k = 0; k < matrix.GetLength(0); k++) // сума ел. у стовпці
                        if (k != i) // крім ел. який вже доданий
                            colWeight += matrix[k, j];
                    
                    int totalWeight = rowWeight + colWeight; // вага 0
                    
                    if (totalWeight > maxWeight) // пошук найбільшої ваги
                    {
                        maxWeight = totalWeight;
                        // зписуемо індекс
                        index[0] = i; 
                        index[1] = j;
                    }  
                }
            }
        }
        
        return index;
    }
    
    static void Main(string[] args)
    {
        int[,] array1 = Random(10);
        PrintMatrix(array1);
        int[] array2 = FindMaximumWeightZero(array1);
        
        Console.WriteLine("\nНуль з найбільшою вагою знаходяться в позиції:");
        Console.WriteLine($"({array2[0] + 1}, {array2[1] + 1})");
    }
}