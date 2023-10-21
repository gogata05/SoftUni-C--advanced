function solve(arrayNumbers, n) {
    let arrayResult = [];//empty array
    for (let i = 0; i < arrayNumbers.length; i += n){//5 20 31 4 20 
        arrayResult.push(arrayNumbers[i]);
    }
    return arrayResult;
}

const result1 = solve(["5", "20", "31", "4", "20"], 2); // [ '5', '31', '20']
console.log(result1);





const result2 = solve(["dsa", "asd", "test", "tset"], 2); // [ 'dsa', 'test' ]
console.log(result2);
