function sumTable() {
    let table = document.querySelectorAll('table tr');
    let sum = 0;
    for (let i = 1; i < table.length - 1; i++) {
        let price = table[i].lastElementChild.textContent;
        sum += Number(price);
    }
    document.getElementById('sum').textContent = sum;
}