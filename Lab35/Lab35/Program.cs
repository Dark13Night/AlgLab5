using System;

public class MyMatrix
{
    private int[,] matrix;
    private int rows;
    private int cols;
    private Random random;

    public MyMatrix(int m, int n)
    {
        rows = m;
        cols = n;
        matrix = new int[rows, cols];
        random = new Random();

        Fill();
    }

    public MyMatrix(int m, int n, int minValue, int maxValue)
    {
        rows = m;
        cols = n;
        matrix = new int[rows, cols];
        random = new Random();

        Fill(minValue, maxValue);
    }

    public int Rows
    {
        get { return rows; }
    }

    public int Cols
    {
        get { return cols; }
    }

    public int this[int i, int j]
    {
        get { return matrix[i, j]; }
        set { matrix[i, j] = value; }
    }

    public void Fill()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = random.Next();
            }
        }
    }

    public void Fill(int minValue, int maxValue)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue);
            }
        }
    }

    public void ChangeSize(int m, int n)
    {
        int[,] newMatrix = new int[m, n];
        int copyRows = Math.Min(m, rows);
        int copyCols = Math.Min(n, cols);

        // Copy values from the existing matrix
        for (int i = 0; i < copyRows; i++)
        {
            for (int j = 0; j < copyCols; j++)
            {
                newMatrix[i, j] = matrix[i, j];
            }
        }

        // Fill the extra rows with random values
        for (int i = copyRows; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                newMatrix[i, j] = random.Next();
            }
        }

        // Fill the extra columns with random values
        for (int i = 0; i < m; i++)
        {
            for (int j = copyCols; j < n; j++)
            {
                newMatrix[i, j] = random.Next();
            }
        }

        matrix = newMatrix;
        rows = m;
        cols = n;
    }



    public void ShowPartialy(int startRow, int endRow, int startCol, int endCol)
    {
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startCol; j <= endCol; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void Show()
    {
        ShowPartialy(0, rows - 1, 0, cols - 1);
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите количество строк матрицы: ");
        int m = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите количество столбцов матрицы: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите минимальное значение для заполнения: ");
        int minValue = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите максимальное значение для заполнения: ");
        int maxValue = int.Parse(Console.ReadLine());

        MyMatrix matrix = new MyMatrix(m, n, minValue, maxValue);

        Console.WriteLine("Сгенерированная матрица:");
        matrix.Show();
        Console.WriteLine();

        Console.WriteLine("Измените размер матрицы:");

        Console.WriteLine("Введите новое количество строк: ");
        int newM = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите новое количество столбцов: ");
        int newN = int.Parse(Console.ReadLine());

        matrix.ChangeSize(newM, newN);

        Console.WriteLine("Матрица после изменения размера:");
        matrix.Show();
        Console.WriteLine();

        Console.WriteLine("Введите начальную строку: ");
        int startRow = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите конечную строку: ");
        int endRow = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите начальный столбец: ");
        int startCol = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите конечный столбец: ");
        int endCol = int.Parse(Console.ReadLine());

        Console.WriteLine("Часть матрицы с заданными параметрами:");
        matrix.ShowPartialy(startRow, endRow, startCol, endCol);

     
        Console.WriteLine("перезаписанная матрица:");
        matrix.Fill();
        matrix.Show();

    }
}
