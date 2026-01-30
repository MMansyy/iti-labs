// 1
let img = document.createElement("img");
img.setAttribute("src", "images/Screenshot (80).png");
let myDiv = document.getElementById("f-assign");
img.style.width = "500px";
myDiv.appendChild(img);
// alert("Child nodes count: " + myDiv.childNodes.length);
// myDiv.removeChild(img);



// 2
let images = [{ src: 'images/Screenshot (165).png', desc: 'abgafour nayem' },
{ src: 'images/Screenshot (80).png', desc: 'chandler bing laughing' },
{ src: 'images/Screenshot (92).png', desc: 'oden from gow' },
{ src: 'images/Screenshot (94).png', desc: 'kratos vs thor gow' }
]

let nextBtn = document.getElementById("next-btn");
let prevBtn = document.getElementById("prev-btn");
let imgElement = document.querySelector(".images");
let descElement = document.querySelector(".image-desc");
let currentIndex = 0;

function updateImage(num) {
    currentIndex += num;
    if (currentIndex >= images.length) {
        currentIndex = 0;
    } else if (currentIndex < 0) {
        currentIndex = images.length - 1;
    }
    imgElement.src = images[currentIndex].src;
    descElement.innerHTML = images[currentIndex].desc;
}

nextBtn.addEventListener("click", () => {
    updateImage(1);
});

prevBtn.addEventListener("click", () => {
    updateImage(-1);
});



// 3
let toDos = [];
let taskInput = document.getElementById("task-input");
let addTaskBtn = document.getElementById("add-task-btn");
let taskList = document.getElementById("task-list");

addTaskBtn.addEventListener("click", () => {
    let taskText = taskInput.value.trim();
    if (taskText !== "") {
        toDos.push({ text: taskText, completed: false });
        taskInput.value = "";
        renderTasks();
    }
});

function markTaskDone(index) {
    toDos[index].completed = !toDos[index].completed;
    renderTasks();
}

function markTaskDeleted(index) {
    toDos.splice(index, 1);
    renderTasks();
}

function renderTasks() {
    let tasksHTML = "";
    toDos.forEach((task, index) => {
        tasksHTML += `
            <li class="${task.completed ? "task-completed" : ""}">
                <p>${task.text}</p>
                <div class="spacer">
                    <button onclick="markTaskDone(${index})" class="done-btn">
                        ${task.completed ? "Undo" : "Done"}
                    </button>
                    <button onclick="markTaskDeleted(${index})" class="delete-btn">Delete</button>
                </div>
            </li>
        `;
    });
    taskList.innerHTML = tasksHTML;
}


// 4

let targetText = document.getElementById("target-text");
let controlSection = document.querySelector(".controls-section");

controlSection.addEventListener("change", (event) => {
    if (event.target.matches("input[type='radio']")) {
        let property = event.target.name;
        let value = event.target.value;
        targetText.style[property] = value;
    }
});



//5 
const keyInput = document.getElementById('key-detector-input');
const asciiDisplay = document.getElementById('ascii-code');
const keyNameDisplay = document.getElementById('key-name');


keyInput.addEventListener('keydown', function (event) {
    event.preventDefault();
    const ascii = event.keyCode || event.which;
    const keyName = event.key;
    asciiDisplay.innerText = ascii;
    keyNameDisplay.innerText = keyName === " " ? "Space" : keyName;
});




const noContextArea = document.getElementById('no-context-area');

noContextArea.addEventListener('contextmenu', function (event) {
    event.preventDefault();
    alert("ممنوع يا حبيبي اومال انت فاكر ايه");
});


// 6
let userNameInput = document.getElementById("username");
let emailInput = document.getElementById("email");
let passwordInput = document.getElementById("password");
let rePasswordInput = document.getElementById("rePassword");
let citySelect = document.getElementById("city");
let submitBtn = document.getElementById("submit-btn");
let form = document.querySelector("form");

function showError(input) {
    let errorMsg = input.nextElementSibling;
    errorMsg.classList.remove("hidden");
}

function hideError(input) {
    let errorMsg = input.nextElementSibling;
    errorMsg.classList.add("hidden");
}

function validateInput(input) {
    let value = input.value.trim();

    switch (input.id) {
        case "username":
            if (value.length < 3) {
                showError(input)
            } else {
                hideError(input)
            };
            break;

        case "email":
            let emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailPattern.test(value)) {
                showError(input);
            }
            else { hideError(input) };
            break;

        case "password":
            if (value === "") {
                showError(input);
            }
            else {
                hideError(input)
            };
            break;

        case "rePassword":
            if (value !== passwordInput.value) {
                showError(input);
            }
            else {
                hideError(input)
            };
            break;

        case "city":
            if (input.value === "") {
                showError(input);
            }
            else { hideError(input) };
            break;
    }
}

[userNameInput, emailInput, passwordInput, rePasswordInput, citySelect].forEach(input => {
    input.addEventListener("blur", () => validateInput(input));
});

form.addEventListener("submit", function (event) {
    let valid = true;
    [userNameInput, emailInput, passwordInput, rePasswordInput, citySelect].forEach(input => {
        validateInput(input);
        if (!input.nextElementSibling.contains("hidden")) valid = false;
    });

    if (!valid) {
        event.preventDefault();
    } else {
        alert(`Hello ${userNameInput.value}, your form has been submitted successfully!`);
    }
});


