function solve(arrayWords) {
    let words = arrayWords.shift().split(' ');
    let wordsCount = {};

    for (const word of words) {
        wordsCount[word] = 0;
    }

    for (const word of arrayWords) {
        if (wordsCount.hasOwnProperty(word)) {
            wordsCount[word]++;
        }
    }

    let sorted = Object.entries(wordsCount).sort((a, b) => b[1] - a[1]);

    for (const [word, count] of sorted) {
        console.log(`${word} - ${count}`);
    }
}
solve([ 
    'this sentence',  
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task' 
    ] );
    //this - 3 
    //sentence - 2 
    solve([ 
        'is the',  
        'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence'] );
    // the – 3 
    // is - 1 
