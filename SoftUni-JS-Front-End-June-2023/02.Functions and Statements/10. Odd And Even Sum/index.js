function solve(number) {
    let numberAsString = number.toString();
    let oddSum = 0;
    let evenSum = 0;
    for (let i = 0; i < numberAsString.length; i++) {
        let currentDigit = Number(numberAsString[i]);
        if (currentDigit % 2 === 0) {
            evenSum += currentDigit;
        } else {
            oddSum += currentDigit;
        }
    }
    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}
solve(1000435);//Odd sum = 9, Even sum = 4
solve(3495892137259234);//Odd sum = 54, Even sum = 22

