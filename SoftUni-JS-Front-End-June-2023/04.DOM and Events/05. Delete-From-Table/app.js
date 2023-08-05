function deleteByEmail() {
    let input = document.querySelector('input[name="email"]');
    let rows = document.querySelectorAll('tbody tr');
    let result = document.getElementById('result');

    let deleted = false;
    for (let row of rows) {
        if (row.children[1].textContent == input.value) {
            row.remove();
            deleted = true;
            result.textContent = 'Deleted.';
        }
    }

    if (!deleted) {
        result.textContent = 'Not found.';
    }

    input.value = '';
}