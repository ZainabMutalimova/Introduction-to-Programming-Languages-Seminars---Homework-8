// Задача 59: Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива.
int[,] CreateIncreasingMatrix(int m, int n, int k)
{
    int[,] array = new int[m, n];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = array[0, 0] + ((j + (i * array.GetLength(1))) * k);
            array[0, 0] = 1;
        }
    }
    return array;
}
void PrintArray(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + "\t");
        }
        Console.WriteLine();
    }
}
int[] FindIndexesOfMin(int[,] matrix)
{
    int min = matrix[1, 1];
    int[] IndexesOfMin = new int[2] { 1, 1 };
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] < min)
            {
                min = matrix[i, j];
                IndexesOfMin[0] = i;
                IndexesOfMin[1] = j;
            }
        }
    }
    Console.WriteLine($"Минимальный элемент равен {min}.");
    Console.WriteLine ($"Индекс минимального элемента: [{String.Join (", ", IndexesOfMin)}].");
    return IndexesOfMin;
}

int[,] CutMatrix(int[,] matrix, int[] IndexesOfMin)
{
    int[,] cutMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
    int m = 0, n = 0;
    for (int i = 0; m < cutMatrix.GetLength(0) && i < matrix.GetLength(0); i++)
    {
        for (int j = 0; n < cutMatrix.GetLength(1) && j < matrix.GetLength(1); j++)
        {
            if (i != IndexesOfMin[0] && j != IndexesOfMin[1])
            {
                cutMatrix[m, n] = matrix[i, j];
                n++;
            }
        }
        if (i != IndexesOfMin[0]) m++;
        n = 0;
    }

    // int m = 0, n = 0;
    // for (int i = 0; i < matrix.GetLength(0); i++)
    // {
    //     for (int j = 0; j < matrix.GetLength(1); j++)
    //     if (i != IndexesOfMin[0] && j != IndexesOfMin[1])
    //     {
    //         cutMatrix[m, l] = matrix[i, j];
    //         n++;
    //     }
    //     n = 0;
    //     if (i != IndexesOfMin[0]) m++;
    // }
    return cutMatrix;
}

Console.WriteLine("Ввведите количество строк матрицы:");
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Ввведите количество столбцов матрицы:");
int n = Convert.ToInt32(Console.ReadLine());
int k = 1;
int[,] matrix = CreateIncreasingMatrix(m, n, k);
Console.WriteLine("Сформирована матрица:");
PrintArray(matrix);
int[,] cutMartix = CutMatrix(matrix, FindIndexesOfMin(matrix));
Console.WriteLine("Обрезанная матрица:");
PrintArray(cutMartix);

int  [,] array = new int [,] { {4,4,4,4} , {4,4,1,4}, {4,4,4,4} };

PrintArray(array);
int[,] cutArray = CutMatrix(array, FindIndexesOfMin(array));
Console.WriteLine("Обрезанная матрица:");
PrintArray(cutArray);