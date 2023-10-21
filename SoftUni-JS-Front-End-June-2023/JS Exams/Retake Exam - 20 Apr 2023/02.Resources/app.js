window.addEventListener("load", solve);

function solve() {
  let taskTitle = document.getElementById("task-title");
  let taskCategory = document.getElementById("task-category");
  let taskContent = document.getElementById("task-content");
  let publishBtn = document.getElementById("publish-btn");
  let reviewList = document.getElementById("review-list");
  let publishedList = document.getElementById("published-list");

  publishBtn.addEventListener("click", function () {
    if (taskTitle.value !== "" && taskCategory.value !== "" && taskContent.value !== "") {
      let li = document.createElement("li");
      li.className = "rpost";

      let article = document.createElement("article");
      let h4 = document.createElement("h4");
      h4.textContent = taskTitle.value;
      let p1 = document.createElement("p");
      p1.textContent = `Category: ${taskCategory.value}`;
      let p2 = document.createElement("p");
      p2.textContent = `Content: ${taskContent.value}`;

      article.appendChild(h4);
      article.appendChild(p1);
      article.appendChild(p2);

      let editBtn = document.createElement("button");
      editBtn.textContent = "Edit";
      editBtn.className = "action-btn edit";
      editBtn.addEventListener("click", function () {
        taskTitle.value = h4.textContent;
        taskCategory.value = p1.textContent.replace("Category: ", "");
        taskContent.value = p2.textContent.replace("Content: ", "");
        reviewList.removeChild(li);
      });

      let postBtn = document.createElement("button");
      postBtn.textContent = "Post";
      postBtn.className = "action-btn post";
      postBtn.addEventListener("click", function () {
        reviewList.removeChild(li);
        li.removeChild(editBtn);
        li.removeChild(postBtn);
        publishedList.appendChild(li);
      });

      li.appendChild(article);
      li.appendChild(editBtn);
      li.appendChild(postBtn);

      reviewList.appendChild(li);

      taskTitle.value = "";
      taskCategory.value = "";
      taskContent.value = "";
    }
  });
}
