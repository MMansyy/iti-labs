
const products = [
    { img: "https://picsum.photos/150?random=1", name: "Product 1", stock: 25, price: 10000 },
    { img: "https://picsum.photos/150?random=2", name: "Product 2", stock: 40, price: 30000 },
    { img: "https://picsum.photos/150?random=3", name: "Product 3", stock: 20, price: 20000 },
    { img: "https://picsum.photos/150?random=4", name: "Product 4", stock: 25, price: 10000 },
    { img: "https://picsum.photos/150?random=5", name: "Product 5", stock: 40, price: 30000 },
    { img: "https://picsum.photos/150?random=6", name: "Product 6", stock: 20, price: 20000 },
    { img: "https://picsum.photos/150?random=7", name: "Product 7", stock: 20, price: 20000 },
    { img: "https://picsum.photos/150?random=8", name: "Product 8", stock: 20, price: 20000 }
];

const productContainer = document.getElementById('productContainer');
let productHTML = '';

products.forEach(product => {
    productHTML += `
            <div class="col-md-6 col-lg-3">
                <div class="card product-card border-0 h-100 shadow-sm">
                    <div class="row g-0 h-100">
                        <div class="col-5">
                            <img src="${product.img}" class="img-fluid w-100 h-100" style="object-fit: cover;" alt="${product.name}">
                        </div>
                        <div class="col-7">
                            <div class="card-body p-2 d-flex flex-column justify-content-center h-100">
                                <h6 class="card-title mb-1 fw-bold text-dark">${product.name}</h6>
                                <p class="card-text mb-1 fw-bold" style="color: #198754; font-size: 0.85rem;">Price: $${product.price}</p>
                                <p class="card-text mb-0 text-muted" style="font-size: 0.75rem;">Stock: ${product.stock}</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        `;
});

productContainer.innerHTML = productHTML;



const form = document.getElementById('registrationForm');
const password = document.getElementById('password');
const confirmPassword = document.getElementById('confirmPassword');

confirmPassword.addEventListener('input', function () {
    if (password.value !== confirmPassword.value) {
        confirmPassword.setCustomValidity("Passwords do not match.");
    } else {
        confirmPassword.setCustomValidity("");
    }
});

form.addEventListener('submit', function (event) {
    if (password.value !== confirmPassword.value) {
        confirmPassword.setCustomValidity("Passwords do not match.");
    } else {
        confirmPassword.setCustomValidity("");
    }

    if (!form.checkValidity()) {
        event.preventDefault();
        event.stopPropagation();
    } else {
        event.preventDefault();
        alert("Registration successful!");
    }

    form.classList.add('was-validated');
}, false);
