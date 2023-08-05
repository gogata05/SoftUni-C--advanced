function solve(arrayStrings) {
    let cats = [];
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }
        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }
    for (const line of arrayStrings) {
        let [name, age] = line.split(' ');
        let cat = new Cat(name, age);
        cats.push(cat);
    }
    for (const cat of cats) {
        cat.meow();
    }
}
solve(['Mellow 2', 'Tom 5'])//Mellow, age 2 says Meow
//Tom, age 5 says Meow
solve(['Candy 1', 'Poppy 3', 'Nyx 2']);//Candy, age 1 says Meow
//Poppy, age 3 says Meow
//Nyx, age 2 says Meow


