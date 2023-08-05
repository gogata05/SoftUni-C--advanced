
const baseUrl = 'http://localhost:3030/jsonstore/tasks/';
let editId = null;

const nameInput = document.getElementById('name');
const daysInput = document.getElementById('num-days');
const dateInput = document.getElementById('from-date');
const addBtn = document.getElementById('add-vacation');
const editBtn = document.getElementById('edit-vacation');
const loadBtn = document.getElementById('load-vacations');
const list = document.getElementById('list');

loadBtn.addEventListener('click', loadVacations);
addBtn.addEventListener('click', addVacation);
editBtn.addEventListener('click', editVacation);
list.addEventListener('click', handleListClick);

function loadVacations() {
    fetch(baseUrl)
    .then(response => response.json())
    .then(data => {
        list.innerHTML = '';
        for (let id in data) {
            const vacation = data[id];
            appendVacation(vacation, id);
        }
    });
}

function addVacation() {
    const newVacation = {
        name: nameInput.value,
        days: daysInput.value,
        date: dateInput.value
    };
    fetch(baseUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newVacation)
    })
    .then(() => {
        nameInput.value = '';
        daysInput.value = '';
        dateInput.value = '';
        loadVacations();
    });
}

function editVacation() {
    const updatedVacation = {
        name: nameInput.value,
        days: daysInput.value,
        date: dateInput.value
    };
    fetch(baseUrl + editId, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(updatedVacation)
    })
    .then(() => {
        nameInput.value = '';
        daysInput.value = '';
        dateInput.value = '';
        editId = null;
        addBtn.disabled = false;
        editBtn.disabled = true;
        loadVacations();
    });
}

function handleListClick(event) {
    if (event.target.className === 'change-btn') {
        const id = event.target.parentNode.id;
        changeVacation(id);
    } else if (event.target.className === 'done-btn') {
        const id = event.target.parentNode.id;
        deleteVacation(id);
    }
}

function changeVacation(id) {
    fetch(baseUrl + id)
    .then(response => response.json())
    .then(vacation => {
        nameInput.value = vacation.name;
        daysInput.value = vacation.days;
        dateInput.value = vacation.date.split('T')[0];
        editId = id;
        addBtn.disabled = true;
        editBtn.disabled = false;
    });
}

function deleteVacation(id) {
    fetch(baseUrl + id, {
        method: 'DELETE'
    })
    .then(() => {
        loadVacations();
    });
}

function appendVacation(vacation, id) {
    const div = document.createElement('div');
    div.className = 'container';
    div.id = id;
    div.innerHTML = `
        <h2>${vacation.name}</h2>
        <h3>${vacation.date.split('T')[0]}</h3>
        <h3>${vacation.days}</h3>
        <button class="change-btn">Change</button>
        <button class="done-btn">Done</button>
    `;
    list.appendChild(div);
}