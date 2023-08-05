function solve(string) {
    let ArrayResult = [];
    let word = "";
    for (let i = 0; i < string.length; i++) {
        if (string[i] == string[i].toUpperCase()) {
            if (word.length > 0) {
                ArrayResult.push(word);
            }
            word = "";
        }
        word += string[i];
    }
    ArrayResult.push(word);
    console.log(ArrayResult.join(", "));
}
solve("SplitMeIfYouCanHaHaYouCantOrYouCan");
//Split, Me, If, You, Can, Ha, Ha, You, Cant, Or, You, Can
solve("HoldTheDoor");//Hold, The, Door
solve("ThisIsSoAnnoyingToDo");//This, Is, So, Annoying, To, Do
