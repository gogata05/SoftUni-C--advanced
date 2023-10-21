function solve(num1, num2, num3) {
    let result = '';
    if (num1 >= 0 && num2 >= 0 && num3 >= 0) {
        result = 'Positive';
    } else if (num1 < 0 && num2 < 0 && num3 < 0) {
        result = 'Negative';
    } else if (num1 < 0 && num2 < 0 && num3 >= 0) {
        result = 'Positive';
    } else if (num1 < 0 && num2 >= 0 && num3 < 0) {
        result = 'Positive';
    } else if (num1 >= 0 && num2 < 0 && num3 < 0) {
        result = 'Positive';
    } else if (num1 < 0 && num2 >= 0 && num3 >= 0) {
        result = 'Negative';
    } else if (num1 >= 0 && num2 < 0 && num3 >= 0) {
        result = 'Negative';
    } else if (num1 >= 0 && num2 >= 0 && num3 < 0) {
        result = 'Negative';
    }
    console.log(result);
}
solve(5, 12, -15);//Negative
solve(-6, -12, 14);//Positive
solve(-1, -2, -3);//Negative
solve(-5, 1, 1);//Negative

