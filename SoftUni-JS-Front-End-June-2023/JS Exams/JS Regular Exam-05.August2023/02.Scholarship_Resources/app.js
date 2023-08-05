window.addEventListener("load", solve);

function solve() {
    const studentInput = document.getElementById('student');
    const universityInput = document.getElementById('university');
    const scoreInput = document.getElementById('score');
    const nextButton = document.getElementById('next-btn');
    const previewList = document.getElementById('preview-list');
    const candidatesList = document.getElementById('candidates-list');

    nextButton.addEventListener('click', () => {
        const studentName = studentInput.value;
        const university = universityInput.value;
        const score = scoreInput.value;

        if (studentName === '' || university === '' || score === '') {
            return;
        }

        const li = document.createElement('li');
        li.className = 'application';
        li.innerHTML = `
            <article>
                <h4>${studentName}</h4>
                <p>University: ${university}</p>
                <p>Score: ${score}</p>
            </article>
            <button class="action-btn edit">edit</button>
            <button class="action-btn apply">apply</button>
        `;

        previewList.appendChild(li);

        studentInput.value = '';
        universityInput.value = '';
        scoreInput.value = '';
        nextButton.disabled = true;

        li.querySelector('.edit').addEventListener('click', () => {
            studentInput.value = studentName;
            universityInput.value = university;
            scoreInput.value = score;
            nextButton.disabled = false;
            previewList.removeChild(li);
        });

        li.querySelector('.apply').addEventListener('click', () => {
            nextButton.disabled = false;
            li.removeChild(li.querySelector('.edit'));
            li.removeChild(li.querySelector('.apply'));
            candidatesList.appendChild(li);
        });
    });
}
