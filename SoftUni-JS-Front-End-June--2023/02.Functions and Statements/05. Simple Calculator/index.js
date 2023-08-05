function solve(num1, num2, operator) {
    let result = 0;
    switch (operator) {
        case 'multiply':
            result = num1 * num2;
            break;
        case 'divide':
            result = num1 / num2;
            break;
        case 'add':
            result = num1 + num2;
            break;
        case 'subtract':
            result = num1 - num2;
            break;
    }
    console.log(result);
}
solve(5, 5, 'multiply');//25
solve(40, 8, 'divide');//5
solve(12, 19, 'add');//31
solve(50, 13, 'subtract');//37
