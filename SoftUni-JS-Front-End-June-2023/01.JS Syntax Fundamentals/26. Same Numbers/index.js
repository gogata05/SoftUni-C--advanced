function solve(number) {
    let numberAsString = number.toString();
    let firstDigit = numberAsString[0];
    let isSame = true;
    let sum = 0;
    for (let i = 0; i < numberAsString.length; i++) {
        let digit = numberAsString[i];
        if (firstDigit != digit) {
            isSame = false;
        }
        sum += Number(digit);
    }
    console.log(isSame);
    console.log(sum);   
}
solve(2222222);//true
//14
solve(1234);//false
//10

