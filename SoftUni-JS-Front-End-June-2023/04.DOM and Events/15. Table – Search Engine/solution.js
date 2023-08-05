function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let rows = Array.from(document.querySelectorAll('tbody tr'));
      let input = document.querySelector('#searchField').value;
      rows.forEach(r => {
         r.classList.remove('select');
      });
      rows.filter(r => r.textContent.includes(input)).forEach(r => {
         r.classList.add('select');
      });
      document.querySelector('#searchField').value = '';

   }
}