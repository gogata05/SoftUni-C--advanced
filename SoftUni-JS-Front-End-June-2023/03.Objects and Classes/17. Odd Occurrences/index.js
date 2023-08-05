function solve(sentence) {
    let words = sentence.toLowerCase().split(' ');
    let wordsCount = {};

    for (const word of words) {
        if (!wordsCount.hasOwnProperty(word)) {
            wordsCount[word] = 0;
        }
        wordsCount[word]++;
    }

    let oddOccurences = [];

    for (const [word, count] of Object.entries(wordsCount)) {
        if (count % 2 !== 0) {
            oddOccurences.push(word);
        }
    }

    console.log(oddOccurences.join(' '));
}
solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');//c# php 1 5
solve('Cake IS SWEET is Soft CAKE sweet Food');//soft food
