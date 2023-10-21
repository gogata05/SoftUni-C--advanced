function solve(word, text) {
    let textArray = text.split(" ");
    for (let i = 0; i < textArray.length; i++) {
        if (textArray[i].toLowerCase() == word.toLowerCase()) {
            console.log(word);
            return;
        }
    }
    console.log(`${word} not found!`);   
}
solve("javascript","JavaScript is the best programming language");//javascript
solve("python","JavaScript is the best programming language");//python not found!

