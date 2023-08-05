function solve(number) {
    let result = '';
    if (number === 100) {
        result = '100% Complete!\n[%%%%%%%%%%]';
    } else {
        result = `${number}% [${'%'.repeat(number / 10)}${'.'.repeat(10 - number / 10)}]`;
        result += '\nStill loading...';
    }
    console.log(result); 
}
solve(30);//30% [%%%.......]
//Still loading...
solve(50);//50% [%%%%%.....]
//Still loading...
solve(100);//100% Complete!
//[%%%%%%%%%%]

