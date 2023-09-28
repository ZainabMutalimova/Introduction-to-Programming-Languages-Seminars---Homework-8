// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
int[,] CreateIncreasingMatrix(int m, int n, int k)
{
    int[,] array = new int[m, n];
    int i = 0;
    int j = 0;

    for (int temp = 1; temp <= m * n; temp += k)
    {
        array[i, j] = temp;
        if (i <= j + 1 && i + j < array.GetLength(1) - 1)
            j++;
        else if (i < j && i + j >= array.GetLength(0) - 1)
            i++;
        else if (i >= j && i + j > array.GetLength(1) - 1)
            j--;
        else
            i--;
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

Console.WriteLine("Ввведите количество строк матрицы:");
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Ввведите количество столбцов матрицы:");
int n = Convert.ToInt32(Console.ReadLine());
int k = 1;
int[,] matrix = CreateIncreasingMatrix(m, n, k);
Console.WriteLine("Сформирована матрица:");
PrintArray(matrix);