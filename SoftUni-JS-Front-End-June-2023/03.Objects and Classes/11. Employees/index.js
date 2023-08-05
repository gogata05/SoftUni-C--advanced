function solve(arrayStrings) {
    let employees = [];
    for (let i = 0; i < arrayStrings.length; i++) {
        let employee = {
            name: arrayStrings[i],
            personalNumber: arrayStrings[i].length
        };
        employees.push(employee);
    }
    for (let employee of employees) {
        console.log(`Name: ${employee.name} -- Personal Number: ${employee.personalNumber}`);
    }
}
solve([ 
    'Silas Butler', 
    'Adnaan Buckley', 
    'Juan Peterson', 
    'Brendan Villarreal' 
    ]);// Name: Silas Butler -- Personal Number: 12 
    // Name: Adnaan Buckley -- Personal Number: 14 
    // Name: Juan Peterson -- Personal Number: 13 
    // Name: Brendan Villarreal -- Personal Number: 18
solve([
    'Samuel Jackson', 
        'Will Smith', 
        'Bruce Willis', 
        'Tom Holland' 
        ]);// Name: Samuel Jackson -- Personal Number: 14 
        // Name: Will Smith -- Personal Number: 10 
        // Name: Bruce Willis -- Personal Number: 12 
        // Name: Tom Holland -- Personal Number: 11
    
