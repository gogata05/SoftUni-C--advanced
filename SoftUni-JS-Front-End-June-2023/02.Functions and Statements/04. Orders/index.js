function solve(product,quantity) {
    let price = 0;
    switch (product) {
        case 'coffee':
            price = 1.50;
            break;
        case 'water':
            price = 1.00;
            break;
        case 'coke':
            price = 1.40;
            break;
        case 'snacks':
            price = 2.00;
            break;
    }
    let result = price * quantity;
    console.log(result.toFixed(2));
}
solve('water', 5);//5.00
solve('coffee', 2);//3.00
