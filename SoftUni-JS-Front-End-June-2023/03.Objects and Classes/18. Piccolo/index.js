function solve(arrayStrings) {
    let parkingLot = {};
    for (const string of arrayStrings) {
        let [direction, carNumber] = string.split(', ');
        if (direction === 'IN') {
            parkingLot[carNumber] = 1;
        } else {
            delete parkingLot[carNumber];
        }
    }
    let sorted = Object.keys(parkingLot).sort((a, b) => a.localeCompare(b));
    if (sorted.length === 0) {
        console.log('Parking Lot is Empty');
    } else {
        console.log(sorted.join('\n'));
    }
}
solve(['IN, CA2844AA', 
'IN, CA1234TA', 
'OUT, CA2844AA', 
'IN, CA9999TT', 
'IN, CA2866HI', 
'OUT, CA1234TA', 
'IN, CA2844AA', 
'OUT, CA2866HI', 
'IN, CA9876HH', 
'IN, CA2822UU'] );
// CA2822UU 
// CA2844AA 
// CA9876HH 
// CA9999TT 
solve(['IN, CA2844AA', 
'IN, CA1234TA', 
'OUT, CA2844AA', 
'OUT, CA1234TA'] );
//Parking Lot is Empty 

