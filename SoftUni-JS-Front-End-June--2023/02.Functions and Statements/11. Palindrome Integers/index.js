function solve(arrayNumbers) {
    for (let i = 0; i < arrayNumbers.length; i++) {
        let currentNumber = arrayNumbers[i];
        let reversedNumber = Number(currentNumber.toString().split('').reverse().join(''));
        if (currentNumber === reversedNumber) {
            console.log(true);
        } else {
            console.log(false);
        }
    }
}
solve([123,323,421,121]);//false true false true
solve([32,2,232,1010]);//false false false false
