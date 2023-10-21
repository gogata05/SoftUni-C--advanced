const baseUrl = 'http://localhost:3030/jsonstore/grocery/';

// Selectors
const productInput = document.getElementById('product');
const countInput = document.getElementById('count');
const priceInput = document.getElementById('price');
const addBtn = document.getElementById('add-product');
const updateBtn = document.getElementById('update-product');
const loadBtn = document.getElementById('load-product');
const tbody = document.getElementById('tbody');

let updateId = null;

// Event Listeners
addBtn.addEventListener('click', addProduct);
updateBtn.addEventListener('click', updateProduct);
loadBtn.addEventListener('click', loadProducts);

function loadProducts() {
  fetch(baseUrl)
    .then(response => response.json())
    .then(data => {
      tbody.innerHTML = '';
      Object.values(data).forEach(product => {
        const tr = document.createElement('tr');
        tr.innerHTML = `
          <td class="name">${product.product}</td>
          <td class="count-product">${product.count}</td>
          <td class="product-price">${product.price}</td>
          <td class="btn">
            <button class="update" data-id="${product._id}">Update</button> 
            <button class="delete" data-id="${product._id}">Delete</button>
          </td>
        `;
        tbody.appendChild(tr);
      });
      Array.from(tbody.getElementsByClassName('delete')).forEach(btn => btn.addEventListener('click', deleteProduct));
      Array.from(tbody.getElementsByClassName('update')).forEach(btn => btn.addEventListener('click', prepareUpdate));
    });
}

function addProduct(e) {
  e.preventDefault();
  const product = productInput.value;
  const count = countInput.value;
  const price = priceInput.value;

  fetch(baseUrl, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ product, count, price })
  })
    .then(() => {
      productInput.value = '';
      countInput.value = '';
      priceInput.value = '';
      loadProducts();
    });
}

function deleteProduct(e) {
  const id = e.target.dataset.id;
  fetch(baseUrl + id, { method: 'DELETE' })
    .then(() => loadProducts());
}

function prepareUpdate(e) {
  updateId = e.target.dataset.id;
  const product = e.target.parentElement.parentElement.getElementsByClassName('name')[0].textContent;
  const count = e.target.parentElement.parentElement.getElementsByClassName('count-product')[0].textContent;
  const price = e.target.parentElement.parentElement.getElementsByClassName('product-price')[0].textContent;

  productInput.value = product;
  countInput.value = count;
  priceInput.value = price;

  addBtn.disabled = true;
  updateBtn.disabled = false;
}

function updateProduct(e) {
  e.preventDefault();
  const product = productInput.value;
  const count = countInput.value;
  const price = priceInput.value;

  fetch(baseUrl + updateId, {
    method: 'PATCH',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ product, count, price })
  })
    .then(() => {
      productInput.value = '';
      countInput.value = '';
      priceInput.value = '';
      addBtn.disabled = false;
      updateBtn.disabled = true;
      updateId = null;
      loadProducts();
    });
}
