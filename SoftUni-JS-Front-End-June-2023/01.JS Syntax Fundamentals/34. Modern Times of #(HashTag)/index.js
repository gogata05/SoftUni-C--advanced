function solve(text) {
    let arrayWords = text.split(' ');
    let arrayResult = [];
    for (let word of arrayWords) {
        if (word.startsWith('#') && word.length > 1) {
            let isOnlyLetters = true;
            let wordWithoutHashTag = word.substring(1);
            for (let char of wordWithoutHashTag) {
                let charCode = char.charCodeAt(0);
                if (charCode < 65 || charCode > 90 && charCode < 97 || charCode > 122) {
                    isOnlyLetters = false;
                    break;
                }
            }
            if (isOnlyLetters) {
                arrayResult.push(wordWithoutHashTag);
            }
        }
    }
    console.log(arrayResult.join('\n'));
}
solve("Nowadays everyone uses # to tag a #special word in #socialMedia")//special
//socialMedia

solve("The symbol # is known #variously in English-speaking #regions as the #number sigh");//variously
//regions
//number

