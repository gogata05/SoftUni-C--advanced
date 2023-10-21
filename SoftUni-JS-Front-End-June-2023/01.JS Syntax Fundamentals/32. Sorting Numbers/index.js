function solve(arrayNumbers) {
    arrayNumbers.sort((a, b) => a - b);
    let arrayResult = [];//empty array
    while (arrayNumbers.length > 0) {
        arrayResult.push(arrayNumbers.shift());
        arrayResult.push(arrayNumbers.pop());
    }
    return arrayResult.filter(x => x != undefined);
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56])); //[-3, 65, 1, 63, 3, 56, 18, 52, 31, 48]

