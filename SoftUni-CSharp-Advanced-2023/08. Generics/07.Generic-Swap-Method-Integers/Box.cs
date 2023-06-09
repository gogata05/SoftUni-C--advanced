using System.Collections.Generic;
using System.Text;
namespace GenericMethodSwapIntegers;
public class Box<T>
{
    private List<T> list;
    public Box() { list = new List<T>(); }
    
    public void Add(T input)
    {
        list.Add(input);
    }
    public override string ToString()
    {
        StringBuilder sb = new();
        foreach (var item in list)
        {
            sb.AppendLine($"{typeof(T)}: {item}");
        }
        return sb.ToString().TrimEnd();
    }
    public void Swap(int firstIndex, int secondIndex)
    {
        (list[secondIndex], list[firstIndex]) = (list[firstIndex], list[secondIndex]);
    }
}