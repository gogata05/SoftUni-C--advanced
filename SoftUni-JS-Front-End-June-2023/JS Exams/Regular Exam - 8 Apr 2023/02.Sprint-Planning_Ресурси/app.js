window.addEventListener('load', solve);

function solve() {
    let totalPoints = 0;
    let taskCounter = 0;
    const labelIcons = {
        'Feature': '&#8865;',
        'Low Priority Bug': '&#9737;',
        'High Priority Bug': '&#9888;',
    };
    const labelClasses = {
        'Feature': 'feature',
        'Low Priority Bug': 'low-priority',
        'High Priority Bug': 'high-priority',
    };

    const form = document.getElementById('create-task-form');
    const titleInput = document.getElementById('title');
    const descriptionInput = document.getElementById('description');
    const labelInput = document.getElementById('label');
    const pointsInput = document.getElementById('points');
    const assigneeInput = document.getElementById('assignee');
    const taskIdInput = document.getElementById('task-id');
    const createTaskBtn = document.getElementById('create-task-btn');
    const deleteTaskBtn = document.getElementById('delete-task-btn');
    const tasksSection = document.getElementById('tasks-section');
    const totalPointsElement = document.getElementById('total-sprint-points');

    createTaskBtn.addEventListener('click', createTask);
    deleteTaskBtn.addEventListener('click', deleteTask);

    function createTask() {
        if (titleInput.value && descriptionInput.value && labelInput.value && pointsInput.value && assigneeInput.value) {
            taskCounter++;
            totalPoints += Number(pointsInput.value);
            totalPointsElement.textContent = `Total Points ${totalPoints}pts`;

            const taskCard = document.createElement('article');
            taskCard.classList.add('task-card');
            taskCard.id = `task-${taskCounter}`;

            const taskCardLabel = document.createElement('div');
            taskCardLabel.classList.add('task-card-label', labelClasses[labelInput.value]);
            taskCardLabel.innerHTML = `${labelInput.value} ${labelIcons[labelInput.value]}`;
            taskCard.appendChild(taskCardLabel);

            const taskCardTitle = document.createElement('h3');
            taskCardTitle.classList.add('task-card-title');
            taskCardTitle.textContent = titleInput.value;
            taskCard.appendChild(taskCardTitle);

            const taskCardDescription = document.createElement('p');
            taskCardDescription.classList.add('task-card-description');
            taskCardDescription.textContent = descriptionInput.value;
            taskCard.appendChild(taskCardDescription);

            const taskCardPoints = document.createElement('div');
            taskCardPoints.classList.add('task-card-points');
            taskCardPoints.textContent = `Estimated at ${pointsInput.value} pts`;
            taskCard.appendChild(taskCardPoints);

            const taskCardAssignee = document.createElement('div');
            taskCardAssignee.classList.add('task-card-assignee');
            taskCardAssignee.textContent = `Assigned to: ${assigneeInput.value}`;
            taskCard.appendChild(taskCardAssignee);

            const taskCardActions = document.createElement('div');
            taskCardActions.classList.add('task-card-actions');
            const deleteButton = document.createElement('button');
            deleteButton.textContent = 'Delete';
            deleteButton.addEventListener('click', loadDelete);
            taskCardActions.appendChild(deleteButton);
            taskCard.appendChild(taskCardActions);

            tasksSection.appendChild(taskCard);

            clearForm();
        }
    }

    function loadDelete(e) {
        const taskCard = e.target.parentElement.parentElement;
        taskIdInput.value = taskCard.id;
        titleInput.value = taskCard.querySelector('.task-card-title').textContent;
        descriptionInput.value = taskCard.querySelector('.task-card-description').textContent;
        labelInput.value = taskCard.querySelector('.task-card-label').textContent.trim();
        pointsInput.value = taskCard.querySelector('.task-card-points').textContent.split(' ')[2];
        assigneeInput.value = taskCard.querySelector('.task-card-assignee').textContent.split(': ')[1];

        titleInput.disabled = true;
        descriptionInput.disabled = true;
        labelInput.disabled = true;
        pointsInput.disabled = true;
        assigneeInput.disabled = true;

        createTaskBtn.disabled = true;
        deleteTaskBtn.disabled = false;
    }

    function deleteTask() {
        const taskCard = document.getElementById(taskIdInput.value);
        totalPoints -= Number(taskCard.querySelector('.task-card-points').textContent.split(' ')[2]);
        totalPointsElement.textContent = `Total Points ${totalPoints}pts`;
        taskCard.remove();

        clearForm();
        titleInput.disabled = false;
        descriptionInput.disabled = false;
        labelInput.disabled = false;
        pointsInput.disabled = false;
        assigneeInput.disabled = false;

        createTaskBtn.disabled = false;
        deleteTaskBtn.disabled = true;
    }

    function clearForm() {
        titleInput.value = '';
        descriptionInput.value = '';
        labelInput.value = 'Feature';
        pointsInput.value = '';
        assigneeInput.value = '';
        taskIdInput.value = '';
    }
}
