function solve(array1, array2) {
    let store = {};
    for (let i = 0; i < array1.length; i+=2) {
        let product = array1[i];
        let quantity = Number(array1[i + 1]);
        store[product] = quantity;
    }
    for (let i = 0; i < array2.length; i+=2) {
        let product = array2[i];
        let quantity = Number(array2[i + 1]);
        if (store.hasOwnProperty(product)) {
            store[product] += quantity;
        } else {
            store[product] = quantity;
        }
    }
    for (let product in store) {
        console.log(`${product} -> ${store[product]}`);
    }
}
solve([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2' 
    ], 
    [ 
    'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30' 
    ]);
// Chips -> 5 
// CocaCola -> 9 
// Bananas -> 44 
// Pasta -> 11 
// Beer -> 2 
// Flour -> 44 
// Oil -> 12 
// Tomatoes -> 70
solve([
    'Salt', '2', 'Fanta', '4', 'Apple', '14', 'Water', '4', 'Juice', '5' 
    ], 
    [ 
    'Sugar', '44', 'Oil', '12', 'Apple', '7', 'Tomatoes', '7', 'Bananas', '30' 
    ] );
// Salt -> 2 
// Fanta -> 4 
// Apple -> 21 
// Water -> 4 
// Juice -> 5 
// Sugar -> 44 
// Oil -> 12 
// Tomatoes -> 7 
// Bananas -> 30 

