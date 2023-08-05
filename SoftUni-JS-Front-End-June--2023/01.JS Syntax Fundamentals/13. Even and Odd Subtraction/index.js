function solve(arrayNumbers) {
    let evenSum = 0;
    let oddSum = 0;
    for (let i = 0; i < arrayNumbers.length; i++) {
        let currentNumber = arrayNumbers[i];
        if (currentNumber % 2 === 0) {
            evenSum += currentNumber;
        } else {
            oddSum += currentNumber;
        }
    }
    let result = evenSum - oddSum;
    console.log(result);
}
solve([1, 2, 3, 4, 5, 6]);//3
solve([3, 5, 7, 9]);//-24
solve([2, 4, 6, 8, 10]);//30
