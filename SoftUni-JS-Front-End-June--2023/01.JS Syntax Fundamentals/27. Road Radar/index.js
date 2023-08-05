function solve(currentSpeed, area) {
    let speedLimit = 0;
    switch (area) {
        case 'motorway':
            speedLimit = 130;
            break;
        case 'interstate':
            speedLimit = 90;
            break;
        case 'city':
            speedLimit = 50;
            break;
        case 'residential':
            speedLimit = 20;
            break;
    }
    let difference = currentSpeed - speedLimit;
    if (difference <= 0) {
        console.log(`Driving ${currentSpeed} km/h in a ${speedLimit} zone`);
    } else if (difference <= 20) {
        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - speeding`);
    } else if (difference <= 40) {
        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - excessive speeding`);
    } else {
        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - reckless driving`);
    }
}
solve(40, 'city');//Driving 40 km/h in a 50 zone
solve(21, 'residential');//The speed is 1 km/h faster than the allowed speed of 20 - speeding
solve(120, 'interstate');//The speed is 30 km/h faster than the allowed speed of 90 - excessive speeding
solve(200, 'motorway');//The speed is 70 km/h faster than the allowed speed of 130 - reckless driving



