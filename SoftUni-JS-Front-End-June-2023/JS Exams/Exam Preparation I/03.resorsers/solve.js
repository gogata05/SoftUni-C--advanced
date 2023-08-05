function attachEvents() {
    const loadButton = document.getElementById('load-button');
    const addButton = document.getElementById('add-button');
    const todoList = document.getElementById('todo-list');
    const titleInput = document.getElementById('title');

    loadButton.addEventListener('click', (e) => {
        e.preventDefault();
        fetch('http://localhost:3030/jsonstore/tasks/')
            .then(response => response.json())
            .then(data => {
                todoList.innerHTML = '';
                Object.values(data).forEach(task => {
                    const li = document.createElement('li');
                    const span = document.createElement('span');
                    span.textContent = task.name;
                    li.appendChild(span);
                    const removeButton = document.createElement('button');
                    removeButton.textContent = 'Remove';
                    removeButton.addEventListener('click', () => {
                        fetch(`http://localhost:3030/jsonstore/tasks/${task._id}`, { method: 'DELETE' })
                            .then(() => loadButton.click());
                    });
                    li.appendChild(removeButton);
                    const editButton = document.createElement('button');
                    editButton.textContent = 'Edit';
                    editButton.addEventListener('click', () => {
                        const input = document.createElement('input');
                        input.type = 'text';
                        input.value = span.textContent;
                        li.insertBefore(input, span);
                        li.removeChild(span);
                        editButton.textContent = 'Submit';
                        editButton.addEventListener('click', () => {
                            fetch(`http://localhost:3030/jsonstore/tasks/${task._id}`, {
                                method: 'PATCH',
                                headers: { 'Content-Type': 'application/json' },
                                body: JSON.stringify({ name: input.value })
                            })
                                .then(() => loadButton.click());
                        });
                    });
                    li.appendChild(editButton);
                    todoList.appendChild(li);
                });
            });
    });

    addButton.addEventListener('click', (e) => {
        e.preventDefault();
        fetch('http://localhost:3030/jsonstore/tasks/', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ name: titleInput.value })
        })
            .then(() => {
                titleInput.value = '';
                loadButton.click();
            });
    });
}

attachEvents();
