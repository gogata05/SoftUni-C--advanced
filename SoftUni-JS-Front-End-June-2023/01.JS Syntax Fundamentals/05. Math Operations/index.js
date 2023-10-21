function solve(num1,num2,char) {
    let result = 0;
    switch (char) {
        case '+':
            result=num1+num2;
            break;
        case '-':
            result=num1-num2;
            break;
        case '*':
            result=num1*num2;
            break;
        case '/':
            result=num1/num2;
            break;
        case '%':
            result=num1%num2;
            break;
        case '**':
            result=num1**num2;
            break;
    }
    console.log(result);
}
solve(5, 6, '+' );//11
solve(3, 5.5, '*');//16.5
