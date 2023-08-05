function solve(arrayNumbers, n) {
    for (let i = 0; i < n; i++) {
        let firstElement = arrayNumbers[0];
        for (let j = 0; j < arrayNumbers.length - 1; j++) {
            arrayNumbers[j] = arrayNumbers[j + 1];
        }
        arrayNumbers[arrayNumbers.length - 1] = firstElement;
    }
   console.log(arrayNumbers.join(' '));
   
}
solve([51, 47, 32, 61, 21], 2);// 32 61 21 51 47
solve([32, 21, 61, 1], 4);// 32 21 61 1
solve([2, 4, 15, 31], 5);// 4 15 31 2

