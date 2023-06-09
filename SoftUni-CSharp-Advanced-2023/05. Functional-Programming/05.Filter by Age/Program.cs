using System.Xml.Linq;
int n = int.Parse(Console.ReadLine());//5
List<PersonNameAgeClass> peopleList = new();
//Lucas, 20 //Tomas, 18 //Mia, 29 //Noah, 31 //Simo, 16
//older //20 // name age
for (int i = 0; i < n; i++)
{
    string[] inputArray = Console.ReadLine().Split(", ");
    peopleList.Add(new PersonNameAgeClass() { Name = inputArray[0], Age = int.Parse(inputArray[1]) });
}
string filterType = Console.ReadLine();//older or younger
int filterValue = int.Parse(Console.ReadLine());//20

Func<PersonNameAgeClass, int, bool> filterFunc = GetFilter(filterType);//older or younger
peopleList = peopleList.Where(x => filterFunc(x, filterValue)).ToList();
Action<PersonNameAgeClass> formatterAction = GetFormatter(Console.ReadLine());//name , age or name age
foreach (var person in peopleList)
{
    formatterAction(person);
}
Func<PersonNameAgeClass, int, bool> GetFilter(string filterType)
{
    if (filterType == "younger")
    {
        return (p, value) => p.Age < value;
    }
    else
    {
        return (PersonNameAgeClass p, int value) => p.Age >= value;
    }
}

Action<PersonNameAgeClass> GetFormatter(string formatType)
{
    if (formatType == "name age")
    {
        return p => Console.WriteLine($"{p.Name} - {p.Age}");
    }
    if (formatType == "name")
    {
        return p => Console.WriteLine($"{p.Name}");
    }
    if (formatType == "age")
    {
        return p => Console.WriteLine($"{p.Age}");
    }
    return null;
}
class PersonNameAgeClass
{
    public string Name;
    public int Age;
}