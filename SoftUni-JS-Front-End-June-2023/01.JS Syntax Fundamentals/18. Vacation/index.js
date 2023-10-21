function solve(group, type, day) {
    let price = 0;
    switch (type) {
        case 'Students':
            switch (day) {
                case 'Friday':
                    price = 8.45;
                    break;
                case 'Saturday':
                    price = 9.80;
                    break;
                case 'Sunday':
                    price = 10.46;
                    break;
            }
            break;
        case 'Business':
            switch (day) {
                case 'Friday':
                    price = 10.90;
                    break;
                case 'Saturday':
                    price = 15.60;
                    break;
                case 'Sunday':
                    price = 16;
                    break;
            }
            break;
        case 'Regular':
            switch (day) {
                case 'Friday':
                    price = 15;
                    break;
                case 'Saturday':
                    price = 20;
                    break;
                case 'Sunday':
                    price = 22.50;
                    break;
            }
            break;
    }
    let totalPrice = group * price;
    if (type === 'Students' && group >= 30) {
        totalPrice *= 0.85;
    } else if (type === 'Business' && group >= 100) {
        totalPrice -= 10 * price;
    } else if (type === 'Regular' && group >= 10 && group <= 20) {
        totalPrice *= 0.95;
    }
    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}
solve('30', 'Students', 'Sunday');//Total price: 266.73
solve('40', 'Regular', 'Saturday');//Total price: 800.00
