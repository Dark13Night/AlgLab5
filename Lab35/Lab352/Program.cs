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

