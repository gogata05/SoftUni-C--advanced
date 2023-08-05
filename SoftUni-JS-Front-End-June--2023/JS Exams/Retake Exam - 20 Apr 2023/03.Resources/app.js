const baseUrl = 'http://localhost:3030/jsonstore/tasks/';

const listElement = document.getElementById('list');
const loadButton = document.getElementById('load-course');
const addButton = document.getElementById('add-course');
const editButton = document.getElementById('edit-course');

const courseNameInput = document.getElementById('course-name');
const courseTypeInput = document.getElementById('course-type');
const descriptionInput = document.getElementById('description');
const teacherNameInput = document.getElementById('teacher-name');

let editId = null;

loadButton.addEventListener('click', loadCourses);
addButton.addEventListener('click', addCourse);
editButton.addEventListener('click', editCourse);

async function loadCourses() {
    listElement.innerHTML = '';
    const response = await fetch(baseUrl);
    const data = await response.json();
    Object.values(data).forEach(createCourseElement);
}

function createCourseElement(course) {
    const container = document.createElement('div');
    container.className = 'container';

    const title = document.createElement('h2');
    title.textContent = course.title;
    container.appendChild(title);

    const teacher = document.createElement('h3');
    teacher.textContent = course.teacher;
    container.appendChild(teacher);

    const type = document.createElement('h3');
    type.textContent = course.type;
    container.appendChild(type);

    const description = document.createElement('h4');
    description.textContent = course.description;
    container.appendChild(description);

    const editBtn = document.createElement('button');
    editBtn.textContent = 'Edit Course';
    editBtn.className = 'edit-btn';
    editBtn.addEventListener('click', () => startEdit(course));
    container.appendChild(editBtn);

    const finishBtn = document.createElement('button');
    finishBtn.textContent = 'Finish Course';
    finishBtn.className = 'finish-btn';
    finishBtn.addEventListener('click', () => finishCourse(course._id));
    container.appendChild(finishBtn);

    listElement.appendChild(container);
}

function startEdit(course) {
    courseNameInput.value = course.title;
    courseTypeInput.value = course.type;
    descriptionInput.value = course.description;
    teacherNameInput.value = course.teacher;
    editId = course._id;

    addButton.disabled = true;
    editButton.disabled = false;
}

async function addCourse() {
    const newCourse = {
        title: courseNameInput.value,
        type: courseTypeInput.value,
        description: descriptionInput.value,
        teacher: teacherNameInput.value
    };

    const response = await fetch(baseUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newCourse)
    });

    if (!response.ok) {
        const error = await response.json();
        return alert(error.message);
    }

    courseNameInput.value = '';
    courseTypeInput.value = '';
    descriptionInput.value = '';
    teacherNameInput.value = '';

    loadCourses();
}

async function editCourse() {
    const updatedCourse = {
        title: courseNameInput.value,
        type: courseTypeInput.value,
        description: descriptionInput.value,
        teacher: teacherNameInput.value
    };

    const response = await fetch(baseUrl + editId, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(updatedCourse)
    });

    if (!response.ok) {
        const error = await response.json();
        return alert(error.message);
    }

    courseNameInput.value = '';
    courseTypeInput.value = '';
    descriptionInput.value = '';
    teacherNameInput.value = '';

    addButton.disabled = false;
    editButton.disabled = true;

    loadCourses();
}

async function finishCourse(id) {
    const response = await fetch(baseUrl + id, {
        method: 'DELETE'
    });

    if (!response.ok) {
        const error = await response.json();
        return alert(error.message);
    }

    loadCourses();
}
