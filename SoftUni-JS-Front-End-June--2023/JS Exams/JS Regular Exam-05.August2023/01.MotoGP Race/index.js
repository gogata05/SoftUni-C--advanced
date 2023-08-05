function race(input) {
    let n = Number(input.shift());
    let riders = {};

    for (let i = 0; i < n; i++) {
        let [rider, fuel, position] = input[i].split('|');
        riders[rider] = {
            fuel: Number(fuel),
            position: Number(position)
        };
    }

    for (let i = n; i < input.length; i++) {
        let [command, rider1, rider2OrFuel, positionOrLaps] = input[i].split(' - ');

        if (command === 'Finish') {
            break;
        }

        switch (command) {
            case 'StopForFuel':
                let minFuel = Number(rider2OrFuel);
                let changedPosition = Number(positionOrLaps);
                if (riders[rider1].fuel < minFuel) {
                    riders[rider1].position = changedPosition;
                    console.log(`${rider1} stopped to refuel but lost his position, now he is ${changedPosition}.`);
                } else {
                    console.log(`${rider1} does not need to stop for fuel!`);
                }
                break;
            case 'Overtaking':
                let rider2 = rider2OrFuel;
                if (riders[rider1].position < riders[rider2].position) {
                    let temp = riders[rider1].position;
                    riders[rider1].position = riders[rider2].position;
                    riders[rider2].position = temp;
                    console.log(`${rider1} overtook ${rider2}!`);
                }
                break;
            case 'EngineFail':
                let lapsLeft = Number(rider2OrFuel);
                delete riders[rider1];
                console.log(`${rider1} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`);
                break;
        }
    }

    let sortedRiders = Object.entries(riders).sort((a, b) => a[1].position - b[1].position);
    for (let [rider, info] of sortedRiders) {
        console.log(`${rider}\n  Final position: ${info.position}`);
    }
}

race(["3", "Valentino Rossi|100|1", "Marc Marquez|90|2", "Jorge Lorenzo|80|3", "StopForFuel - Valentino Rossi - 50 - 1", "Overtaking - Marc Marquez - Jorge Lorenzo", "EngineFail - Marc Marquez - 10", "Finish"]);
