function solve(n) {
    let result = '';
    for (let i = 0; i < n; i++) {
        result += n + ' ';
    }
    for (let i = 0; i < n; i++) {
        console.log(result);
    }  
}
solve(3);//3 3 3
//3 3 3
//3 3 3
solve(7);//7 7 7 7 7 7 7
//7 7 7 7 7 7 7
//7 7 7 7 7 7 7
//7 7 7 7 7 7 7
//7 7 7 7 7 7 7
//7 7 7 7 7 7 7
//7 7 7 7 7 7 7
solve(2);//2 2
//2 2
