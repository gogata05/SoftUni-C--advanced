function solve(password) {
    let isValid = true;
    let isBetween = false;
    let isOnlyLettersAndDigits = true;
    let hasAtLeastTwoDigits = false;
    if (password.length >= 6 && password.length <= 10) {
        isBetween = true;
    } else {
        isValid = false;
        console.log('Password must be between 6 and 10 characters');
    }
    for (let i = 0; i < password.length; i++) {
        let currentChar = password[i];
        if ((currentChar.charCodeAt(0) >= 65 && currentChar.charCodeAt(0) <= 90) ||
            (currentChar.charCodeAt(0) >= 97 && currentChar.charCodeAt(0) <= 122) ||
            (currentChar.charCodeAt(0) >= 48 && currentChar.charCodeAt(0) <= 57)) {
            // isOnlyLettersAndDigits = true;
        } else {
            isOnlyLettersAndDigits = false;
            break;
        }
    }
    if (isOnlyLettersAndDigits) {
        // console.log('Password must consist only of letters and digits');
    } else {
        isValid = false;
        console.log('Password must consist only of letters and digits');
    }
    let digitsCount = 0;
    for (let i = 0; i < password.length; i++) {
        let currentChar = password[i];
        if (currentChar.charCodeAt(0) >= 48 && currentChar.charCodeAt(0) <= 57) {
            digitsCount++;
        }
    }
    if (digitsCount >= 2) {
        hasAtLeastTwoDigits = true;
    } else {
        isValid = false;
        console.log('Password must have at least 2 digits');
    }
    if (isBetween && isOnlyLettersAndDigits && hasAtLeastTwoDigits) {
        console.log('Password is valid');
    }
}
solve('logIn');//Password must be between 6 and 10 characters
//Password must have at least 2 digits
solve('MyPass123');//Password is valid
solve('Pa$s$s');//Password must consist only of letters and digits
//Password must have at least 2 digits


