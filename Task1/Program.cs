// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
int[,] CreateRandomMatrix(int m, int n, int minLimit, int maxLimit)
{
    int[,] array = new int[m, n];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(minLimit, maxLimit+1);
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
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}
int[,] Multiplication(int[,] matrix1, int[,] matrix2)
{
    int[,] matrix3 = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    if (matrix1.GetLength(1) == matrix2.GetLength(0))
    {
        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2.GetLength(1); j++)
            {
                for (int n = 0; n < matrix1.GetLength(1); n++)
                {
                    matrix3[i, j] += matrix1[i, n] * matrix2[n, j];
                }
            }
        }
    }
    else throw new Exception("Количество столбцов первой матрицы не равняется количеству строк второй матрицы. Попробуйте снова.");
    return matrix3;
}

Console.WriteLine("Ввведите количество строк первой матрицы:");
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Ввведите количество столбцов первой матрицы:");
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Ввведите количество строк второй матрицы:");
int x = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Ввведите количество столбцов второй матрицы:");
int y = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Ввведите минимальное значение элемента в матрицах:");
int minLimit = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Ввведите максимальное значение элемента в матрицах:");
int maxLimit = Convert.ToInt32(Console.ReadLine());
int[,] matrix1 = CreateRandomMatrix (m, n, minLimit, maxLimit);
int[,] matrix2 = CreateRandomMatrix (x, y, minLimit, maxLimit);

Console.WriteLine("Первая матрица:");
PrintArray(matrix1);
Console.WriteLine("Вторая матрица:");
PrintArray(matrix2);
Console.WriteLine("Результат умножения матриц:");
PrintArray(Multiplication(matrix1, matrix2));