function solve(text) {
    let result = 0;
    if (typeof(text)==='number') {
        result = Math.PI*text*text;
        console.log(result.toFixed(2));
    }
    else{
        console.log(`We can not calculate the circle area, because we receive a ${typeof(text)}.`);
    }
}
solve(5);//78.54 
solve('name');//We can not calculate the circle area, because we receive a string. 