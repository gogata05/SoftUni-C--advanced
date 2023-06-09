using System;
using System.Collections.Generic;
using System.Text;
namespace GenericMethodCountStrings;
public class Box<T> where T : IComparable<T>
{
    private List<T> list;
    public Box() { list = new List<T>(); }

    public override string ToString()
    {
        StringBuilder sb = new();
        foreach (var item in list)
        {
            sb.AppendLine($"{typeof(T)}: {item}");
        }
        return sb.ToString().TrimEnd();
    }
    public void Add(T item)
    {
        list.Add(item);
    }
    public void Swap(int firstIndex, int secondIndex)
    {
        T temp = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = temp;
    }
    public int Count(T itemToCompare)
    {
        int count = 0;
        foreach (var item in list)
        {
            if (item.CompareTo(itemToCompare) > 0)
            {
                count++;
            }
        }
        return count;
    }
}