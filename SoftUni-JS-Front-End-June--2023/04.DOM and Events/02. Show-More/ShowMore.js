function showText() {
    let text = document.getElementById('text');
    let more = document.getElementById('more');
    let button = document.getElementById('btnMore');

    if (button.textContent === 'More') {
        text.style.display = 'inline';
        button.textContent = 'Less';
    } else {
        text.style.display = 'none';
        button.textContent = 'More';
    }
    
} 
