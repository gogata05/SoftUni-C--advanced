const API_URL = 'http://localhost:3030/jsonstore/tasks';

document.getElementById('load-course').addEventListener('click', loadCourses);
document.getElementById('add-course').addEventListener('click', addCourse);

async function loadCourses() {
  const response = await fetch(API_URL);
  const courses = await response.json();
  const listElement = document.getElementById('list');

  listElement.innerHTML = '';

  for (const id in courses) {
    const course = courses[id];

    const courseElement = document.createElement('div');
    courseElement.classList.add('container');

    const titleElement = document.createElement('h2');
    titleElement.textContent = course.title;
    courseElement.appendChild(titleElement);

    const teacherElement = document.createElement('h3');
    teacherElement.textContent = course.teacher;
    courseElement.appendChild(teacherElement);

    const typeElement = document.createElement('h3');
    typeElement.textContent = course.type;
    courseElement.appendChild(typeElement);

    const descriptionElement = document.createElement('h4');
    descriptionElement.textContent = course.description;
    courseElement.appendChild(descriptionElement);

    listElement.appendChild(courseElement);
  }
}

async function addCourse(event) {
  event.preventDefault();

  const titleInput = document.getElementById('course-name');
  const typeInput = document.getElementById('course-type');
  const descriptionInput = document.getElementById('description');
  const teacherInput = document.getElementById('teacher-name');

  const newCourse = {
    title: titleInput.value,
    type: typeInput.value,
    description: descriptionInput.value,
    teacher: teacherInput.value,
  };

  await fetch(API_URL, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(newCourse),
  });

  titleInput.value = '';
  typeInput.value = '';
  descriptionInput.value = '';
  teacherInput.value = '';

  loadCourses();
}

async function editCourse(id) {
  const response = await fetch(`${API_URL}/${id}`);
  const course = await response.json();

  document.getElementById('course-name').value = course.title;
  document.getElementById('course-type').value = course.type;
  document.getElementById('description').value = course.description;
  document.getElementById('teacher-name').value = course.teacher;

  document.getElementById('add-course').disabled = true;
  document.getElementById('edit-course').disabled = false;

  editedCourseId = id;
}

document.getElementById('edit-course').addEventListener('click', async (event) => {
  event.preventDefault();

  if (!editedCourseId) return;

  const updatedCourse = {
    title: document.getElementById('course-name').value,
    type: document.getElementById('course-type').value,
    description: document.getElementById('description').value,
    teacher: document.getElementById('teacher-name').value,
  };

  await fetch(`${API_URL}/${editedCourseId}`, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(updatedCourse),
  });

  document.getElementById('course-name').value = '';
  document.getElementById('course-type').value = '';
  document.getElementById('description').value = '';
  document.getElementById('teacher-name').value = '';

  document.getElementById('add-course').disabled = false;
  document.getElementById('edit-course').disabled = true;