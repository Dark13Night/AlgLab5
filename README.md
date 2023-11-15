# AlgLab5
# Лабораторная работа №5
# «Массивы и коллекции. Интерфейс IEnumerable»

# Цели работы:
Научиться реализации интерфейса IEnumerable и работе с массивами и коллекциями языка C#.

# Задание№1
Создайте класс MyMatrix, представляющий матрицу m на n.
Создайте конструктор, принимающий число строк и столбцов, заполняющий матрицу случайными числами в диапазоне, который пользователь вводит при запуске программы.
Создайте метод Fill, перезаполняющий матрицу случайными значениями.
Создайте метод ChangeSize, изменяющий число строк и/или столбцов с копированием значений существующей матрицы. Если новая матрица больше существующий, то метод должен дозаполнить новую матрицу случайными числами.
Создайте метод ShowPartialy, принимающий в качестве параметров начальные и конечные значения строк и столбцов, значения матрицы внутри которых нужно вывести на консоль.
Создайте метод Show, выводящий все значения матрицы на консоль.
Создайте индексатор для матрицы вида this[int index1, int index2] с аксессором и мутатором.
```
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
```

Задание№2
Создайте класс MyList<T>.
Реализуйте в простейшем приближении возможность использования его экземпляра аналогично экземпляру класса List<T>.
Минимально требуемый интерфейс взаимодействия с экземпляром должен включать метод добавления элемента, индексатор для получения значения элемента по указанному индексу, свойство только для чтения для получения общего количества элементов и поддержку блока инициализации.
При выполнении нельзя использовать коллекции, только массивы.
```
using System;
using System.Collections;

public class MyList<T>:IEnumerable<T>
{
    public T[] items;
    public int count;

    public MyList()
    {
        items = new T[0];
        count = 0;
    }

    public MyList(T[] initialItems)
    {
        items = new T[initialItems.Length];

        Array.Copy(initialItems, items, initialItems.Length);
        count = initialItems.Length;
        
    }

    public void Add(T item)
    {
        Array.Resize(ref items, count + 1);
        items[count] = item;
        count++;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return (IEnumerator<T>)items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return items.GetEnumerator();
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            return items[index];
        }
    }

    public int Count
    {
        get { return count; }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        MyList<int> myList = new MyList<int>() { 1,2,3,5};

        myList.Add(1);
        myList.Add(2);
        myList.Add(3);

        Console.WriteLine("Count: " + myList.Count);
        Console.WriteLine("Item at index 1: " + myList[1]);
    }
}

```

Задание№3
Создайте коллекцию MyDictionary<TKey,TValue>.
Реализуйте в простейшем приближении возможность использования ее экземпляра аналогично экземпляру класса Dictionary<TKey,TValue>.
Минимально требуемый интерфейс взаимодействия с экземпляром должен включать метод добавления элемента, индексатор для получения значения элемента по указанному индексу и свойство только для чтения для получения общего количества элементов.
Реализуйте возможность перебора элементов коллекции в цикле foreach. При выполнении нельзя использовать коллекции, только массивы.
```
using System;
using System.Collections;
using System.Collections.Generic;

public class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
{
    private KeyValuePair<TKey, TValue>[] items;
    private int count;

    public MyDictionary()
    {
        items = new KeyValuePair<TKey, TValue>[4];
        count = 0;
    }

    public void Add(TKey key, TValue value)
    {
        if (count == items.Length)
        {
            Array.Resize(ref items, items.Length * 2);
        }

        items[count] = new KeyValuePair<TKey, TValue>(key, value);
        count++;
    }

    public TValue this[TKey key]
    {
        get
        {
            foreach (var item in items)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }

            throw new KeyNotFoundException();
        }
    }

    public int Count
    {
        get { return count; }
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public static class Program
{
    public static void Main(string[] args)
    {
        MyDictionary<int, string> dictionary = new MyDictionary<int, string>();

        dictionary.Add(1, "One");
        dictionary.Add(2, "Two");
        dictionary.Add(3, "Three");

        Console.WriteLine("Count: " + dictionary.Count);

        foreach (KeyValuePair<int, string> kvp in dictionary)
        {
            Console.WriteLine("Key: " + kvp.Key + ", Value: " + kvp.Value);
        }

        Console.WriteLine("Value at key 2: " + dictionary[2]);
    }
}
```

