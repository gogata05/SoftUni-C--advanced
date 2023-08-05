function create(words) {
   let content = document.getElementById('content');
   for (let i = 0; i < words.length; i++) {
      let div = document.createElement('div');
      let p = document.createElement('p');
      p.textContent = words[i];
      p.style.display = 'none';
      div.appendChild(p);
      content.appendChild(div);
   }
   content.addEventListener('click', function (e) {
      if (e.target.tagName === 'DIV') {
         e.target.children[0].style.display = 'block';
      }
   })
}