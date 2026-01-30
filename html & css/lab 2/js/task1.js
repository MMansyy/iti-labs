
// Task 1: Geolocation and Map Display
let map = document.getElementById('map');
let locationButton = document.getElementById('loc-btn');


locationButton.addEventListener('click', () => {
    navigator.geolocation.watchPosition((position) => {
        let latitude = position.coords.latitude;
        let longitude = position.coords.longitude;
        map.src = `https://www.google.com/maps?q=${latitude},+${longitude}&output=embed`;
    }, (error) => {
        console.log('Error in location:', error);
    });
})



// Task 2: User Details Form
let userForm = document.getElementById('user-form');
let nameInput = document.getElementById('name');
let emailInput = document.getElementById('email');
let ageInput = document.getElementById('age');
let userList = document.getElementById('user-list');
let users = JSON.parse(localStorage.getItem('users')) || [];


userForm.addEventListener('submit', (e) => {
    e.preventDefault();
    let user = {
        name: nameInput.value,
        email: emailInput.value,
        age: ageInput.value
    };
    users.push(user);
    localStorage.setItem('users', JSON.stringify(users));
    userForm.reset();
    alert('User details saved successfully!');
    displayUsers();
});

function displayUsers() {
    let cartona = `<li class="d-flex justify-content-between align-items-center list-group-item">
                            <span>Name</span>
                            <span>Email</span>
                            <span>Age</span>
                            <span>Delete</span>
                        </li>`;
    users.forEach((user, i) => {
        cartona += `
        <li class="d-flex justify-content-between align-items-center list-group-item">
            <span>${user.name}</span>
            <span>${user.email}</span>
            <span>${user.age}</span>
            <button user=${i} class="btn btn-danger btn-sm delete-btn">Delete</button>
        </li>
        `;
    });
    userList.innerHTML = cartona;
}

userList.addEventListener('click', (e) => {
    if (e.target.classList.contains('delete-btn')) {
        let index = e.target.getAttribute('user');
        deleteUser(index);
    }
});

function deleteUser(index) {
    users.splice(index, 1);
    localStorage.setItem('users', JSON.stringify(users));
    displayUsers();
}


displayUsers();


// use worker to calc and fetch
let startWorker1 = document.getElementById('start-worker-1');
let startWorker2 = document.getElementById('start-worker-2');

startWorker1.addEventListener('click', () => {
    let worker1 = new Worker('js/worker1.js');
    worker1.postMessage('');
    worker1.onmessage = (e) => {
        alert(`Big Calc Result: ${e.data}`);
        worker1.terminate();
    }
});

startWorker2.addEventListener('click', () => {
    let worker2 = new Worker('js/worker2.js');
    worker2.postMessage('');
    worker2.onmessage = (e) => {
        console.log(`Fetched Data: ${e.data}`);
        alert(`Fetched Data: ${e.data}`);
        worker2.terminate();
    }
});