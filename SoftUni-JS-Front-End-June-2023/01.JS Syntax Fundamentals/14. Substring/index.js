function solve(text, startIndex, count) {
    let result = "";
    for (let i = startIndex; i < startIndex + count; i++) {
        result += text[i];
        if (i === text.length - 1) {
            break;
        }
    }
    console.log(result);
}
solve("ASentance", 1, 8);//Sentance
solve("SkipWord", 4, 7);//Word