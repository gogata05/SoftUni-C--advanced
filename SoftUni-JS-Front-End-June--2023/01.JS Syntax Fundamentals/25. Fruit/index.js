function solve(typeFruit, weightGrams, priceKg) {
    let weightKg = weightGrams / 1000;
    let money = weightKg * priceKg;
    console.log(`I need $${money.toFixed(2)} to buy ${weightKg.toFixed(2)} kilograms ${typeFruit}.`);
}
    solve('orange', 2500, 1.80);//I need $4.50 to buy 2.50 kilograms orange.
    solve('apple', 1563, 2.35);//I need $3.67 to buy 1.56 kilograms apple.
