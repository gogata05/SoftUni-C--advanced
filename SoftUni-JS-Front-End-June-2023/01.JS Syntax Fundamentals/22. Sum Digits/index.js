function solve(number) {
    let sum = 0;
    let result = '';
    let numberAsString = number.toString();
    for (let i = 0; i < numberAsString.length; i++) {
        let digit = Number(numberAsString[i]);
        sum += digit;
    }
    console.log(sum);
}
solve(245678);//32
solve(97561);//28
solve(543);//12
