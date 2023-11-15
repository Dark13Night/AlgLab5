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
