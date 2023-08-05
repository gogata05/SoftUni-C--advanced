async function request(url, options) {
    const response = await fetch(url, options);
    if (response.ok != true) {
        const error = await response.json();
        alert(error.message);
        throw new Error(error.message);
    }
    return await response.json();
}

function attachEvents() {
    document.getElementById('load-board-btn').addEventListener('click', loadBoard);
    document.getElementById('create-task-btn').addEventListener('click', createTask);
}

async function loadBoard() {
    const tasks = await request('http://localhost:3030/jsonstore/tasks/');
    const sections = {
        'ToDo': document.querySelector('#todo-section ul'),
        'In Progress': document.querySelector('#in-progress-section ul'),
        'Code Review': document.querySelector('#code-review-section ul'),
        'Done': document.querySelector('#done-section ul')
    };

    Array.from(Object.values(sections)).forEach(ul => ul.innerHTML = '');

    Object.values(tasks).forEach(task => {
        const li = document.createElement('li');
        li.className = 'task';
        li.dataset.id = task._id;
        li.innerHTML = `<h3>${task.title}</h3><p>${task.description}</p>`;
        const button = document.createElement('button');
        switch (task.status) {
            case 'ToDo':
                button.textContent = 'Move to In Progress';
                break;
            case 'In Progress':
                button.textContent = 'Move to Code Review';
                break;
            case 'Code Review':
                button.textContent = 'Move to Done';
                break;
            case 'Done':
                button.textContent = 'Close';
                break;
        }
        button.addEventListener('click', modifyTask);
        li.appendChild(button);
        sections[task.status].appendChild(li);
    });
}

async function createTask() {
    const title = document.getElementById('title');
    const description = document.getElementById('description');

    if (title.value == '' || description.value == '') {
        alert('Title and description are required!');
        return;
    }

    const newTask = {
        title: title.value,
        description: description.value,
        status: 'ToDo'
    };

    try {
        const response = await request('http://localhost:3030/jsonstore/tasks/', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(newTask)
        });

        if (response) {
            title.value = '';
            description.value = '';
            await loadBoard();
        }
    } catch (error) {
        console.error('Failed to create task:', error);
    }
}

async function modifyTask(event) {
    const taskElement = event.target.parentNode;
    const taskId = taskElement.dataset.id;
    const taskStatus = {
        'Move to In Progress': 'In Progress',
        'Move to Code Review': 'Code Review',
        'Move to Done': 'Done',
        'Close': 'Done'
    }[event.target.textContent];

    if (taskStatus == 'Done' && event.target.textContent == 'Close') {
        await request('http://localhost:3030/jsonstore/tasks/' + taskId, {
            method: 'delete'
        });
    } else {
        await request('http://localhost:3030/jsonstore/tasks/' + taskId, {
            method: 'put',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ status: taskStatus })
        });
    }

    loadBoard();
}

attachEvents();
