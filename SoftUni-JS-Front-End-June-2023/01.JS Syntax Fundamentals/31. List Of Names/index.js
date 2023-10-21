function solve(arrayNames) {
    arrayNames.sort((a, b) => a.localeCompare(b));
    for (let i = 0; i < arrayNames.length; i++) {
        console.log(`${i + 1}.${arrayNames[i]}`);
    }
}
solve(["John", "Bob", "Christina", "Ema"]);//1.Bob
//2.Christina
//3.Ema
//4.John

