function solve(words, templates) {
    let wordsArray = words.split(", ");
    let templatesArray = templates.split(" ");
    for (let i = 0; i < templatesArray.length; i++) {
        if (templatesArray[i].includes("*")) {
            let wordLength = templatesArray[i].length;
            for (let j = 0; j < wordsArray.length; j++) {
                if (wordsArray[j].length == wordLength) {
                    templatesArray[i] = wordsArray[j];
                    break;
                }
            }
        }
    }
    console.log(templatesArray.join(" "));
}
solve("great","softuni is ***** place for learning new programming languages");//softuni is great place for learning new programming languages
solve("great, learning","softuni is ***** place for ******** new programming languages");//softuni is great place for learning new programming languages

