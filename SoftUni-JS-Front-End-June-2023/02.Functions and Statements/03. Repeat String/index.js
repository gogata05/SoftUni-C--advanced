function solve(text, n) {
    let result = '';
    for (let i = 0; i < n; i++) {
        result += text;
    }
    console.log(result);
}
solve('abc', 3);// abcabcabc
solve('String', 2);// StringString
