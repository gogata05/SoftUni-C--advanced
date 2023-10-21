window.addEventListener("load", solve);
function solve() {
    const publishBtn = document.getElementById("publish-btn");
    const reviewList = document.getElementById("review-list");
    const publishedList = document.getElementById("published-list");

    function createPostElement(title, category, content) {
        const li = document.createElement("li");
        li.classList.add("rpost");

        const span = document.createElement("span");
        span.textContent = title;
        li.appendChild(span);

        const strong = document.createElement("strong");
        strong.textContent = category;
        li.appendChild(strong);

        const article = document.createElement("article");
        article.textContent = content;
        li.appendChild(article);

        return li;
    }

    publishBtn.addEventListener("click", () => {
        const titleInput = document.getElementById("task-title");
        const categoryInput = document.getElementById("task-category");
        const contentInput = document.getElementById("task-content");

        const title = titleInput.value.trim();
        const category = categoryInput.value.trim();
        const content = contentInput.value.trim();

        if (title === "" || category === "" || content === "") return;

        const li = createPostElement(title, category, content);

        const editBtn = document.createElement("button");
        editBtn.classList.add("action-btn");
        editBtn.textContent = "Edit";
        li.appendChild(editBtn);

        const postBtn = document.createElement("button");
        postBtn.classList.add("action-btn");
        postBtn.textContent = "Post";
        li.appendChild(postBtn);

        reviewList.appendChild(li);

        titleInput.value = "";
        categoryInput.value = "";
        contentInput.value = "";

        editBtn.addEventListener("click", () => {
            titleInput.value = title;
            categoryInput.value = category;
            contentInput.value = content;
            reviewList.removeChild(li);
        });

        postBtn.addEventListener("click", () => {
            reviewList.removeChild(li);
            li.removeChild(editBtn);
            li.removeChild(postBtn);
            publishedList.appendChild(li);
        });
    });
}
