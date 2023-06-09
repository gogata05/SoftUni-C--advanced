using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DefiningClasses;

public class Family
{
    private List<Person> people;
    public List<Person> People { get { return people; } set { people = value; } }
    public Family() { people = new(); }

    
    public void AddMember(Person person)
    {
        people.Add(person);
    }

    public Person GetOldestMember()
    {
        return people.MaxBy(p => p.Age);
    }
}