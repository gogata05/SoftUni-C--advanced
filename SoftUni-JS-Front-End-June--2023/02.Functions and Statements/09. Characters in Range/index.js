function solve(char1, char2) {
    let result = '';
    let char1Code = char1.charCodeAt(0);
    let char2Code = char2.charCodeAt(0);
    let start = Math.min(char1Code, char2Code);
    let end = Math.max(char1Code, char2Code);
    for (let i = start + 1; i < end; i++) {
        result += String.fromCharCode(i) + ' ';
    }
    console.log(result); 
}
solve('a', 'd');//b c
solve('#', ':');//$ % & ' ( ) * + , - . / 0 1 2 3 4 5 6 7 8 9 : ;
solve('C', '#');//D E F G H I J K L M N O P Q R S T U V W X Y Z [ \ ] ^ _ ` a b c

