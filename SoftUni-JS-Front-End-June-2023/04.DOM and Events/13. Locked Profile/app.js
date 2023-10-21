function lockedProfile() {
    let buttons = document.getElementsByTagName('button');
    for (let i = 0; i < buttons.length; i++) {
        buttons[i].addEventListener('click', showMore);
    }

    function showMore() {
        let profile = this.parentNode;
        let lock = profile.querySelector('input[type="radio"][value="lock"]');
        let hiddenFields = profile.querySelector('div');
        if (!lock.checked) {
            if (this.textContent === 'Show more') {
                hiddenFields.style.display = 'block';
                this.textContent = 'Hide it';
            } else {
                hiddenFields.style.display = 'none';
                this.textContent = 'Show more';
            }
        }
    }
}