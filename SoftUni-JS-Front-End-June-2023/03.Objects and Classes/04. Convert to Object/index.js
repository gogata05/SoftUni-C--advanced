function solve(jsonStr) {
    let person = JSON.parse(jsonStr);
    for (const key in person) {
        console.log(`${key}: ${person[key]}`);
    }
}
solve('{"name": "George", "age": 40, "town": "Sofia"}');//name -> George
//age -> 40
//town -> Sofia
solve('{"name": "Peter", "age": 35, "town": "Plovdiv"}');//name -> Peter
//age -> 35
//town -> Plovdiv
