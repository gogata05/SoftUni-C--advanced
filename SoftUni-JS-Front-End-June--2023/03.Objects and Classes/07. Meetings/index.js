function solve(arrayStrings) {
    let schedule = {};
    for (const line of arrayStrings) {
        let [day, name] = line.split(' ');
        if (schedule.hasOwnProperty(day)) {
            console.log(`Conflict on ${day}!`);
        } else {
            schedule[day] = name;
            console.log(`Scheduled for ${day}`);
        }
    }
    for (const key in schedule) {
        console.log(`${key} -> ${schedule[key]}`);
    }
}
solve(['Monday Peter',
'Wednesday Bill',
'Monday Tim',
'Friday Tim']);//Scheduled for Monday 
//Scheduled for Wednesday 
//Conflict on Monday! 
//Scheduled for Friday 
//Monday -> Peter 
//Wednesday -> Bill 
//Friday -> Tim 
solve(['Friday Bob', 
'Saturday Ted', 
'Monday Bill', 
'Monday John', 
'Wednesday George']);//Scheduled for Friday 
//Scheduled for Saturday 
//Scheduled for Monday 
//Conflict on Monday! 
//Scheduled for Wednesday 
//Friday -> Bob 
//Saturday -> Ted 
//Monday -> Bill 
//Wednesday -> George
