function countCharOccurrences() {
    let string = prompt("Enter a string:");
    let char = prompt("Enter a character to count:");
    let confirmCase = confirm("Do you want the count to be case-sensitive?");
    let count = 0;
    if (!confirmCase) {
        string = string.toLowerCase();
        char = char.toLowerCase();
    }
    for (let i in string) {
        if (string[i] === char) {
            count++;
        }
    }
    alert(`The character "${char}" appears ${count} times in the string.`);
}



function checkPalindrome() {
    let string = prompt('Enter a string');
    let len = string.length;
    let confirmCase = confirm("Do you want to consider the case-sensitive?");
    if (!confirmCase) {
        string = string.toLowerCase();
    }
    for (let i = 0, j = len - 1; i < j; i++, j--) {
        if (string[i] != string[j]) {
            alert('Its not a palindrome');
            return;
        }
    }
    alert('Its a palindrome');
}


function getLargestWord() {
    let string = prompt('Enter a string').split(' ');
    let largest = '';

    for (let word of string) {
        if (word.length > largest.length) {
            largest = word;
        }
    }

    alert(`The largest word is: ${largest}`);
}

function validateFields() {
    let date = new Date().toDateString();
    let div = document.getElementById('main');
    let namePattern = /^[A-Za-z]+$/;
    let emailPattern = /^[A-Za-z0-9._+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$/;
    let mobilePattern = /^[0-9]{8}$/;
    let phonePattern = /^01(0|1|2|5)[0-9]{8}$/;
    let name = prompt("Enter your name:");
    while (!namePattern.test(name)) {
        alert("Invalid name. Please enter alphabetic characters only.");
        name = prompt("Enter your name:");
    }
    let email = prompt("Enter your email:");
    while (!emailPattern.test(email)) {
        alert("Invalid email format. Please enter a valid email.");
        email = prompt("Enter your email:");
    }
    let phone = prompt("Enter your phone number:");
    while (!phonePattern.test(phone)) {
        alert("Invalid phone number. Please enter a valid Egyptian phone number.");
        phone = prompt("Enter your phone number:");
    }
    let mobile = prompt("Enter your mobile number:");
    while (!mobilePattern.test(mobile)) {
        alert("Invalid mobile number. Please enter an 8-digit mobile number.");
        mobile = prompt("Enter your mobile number:");
    }
    let color = prompt("Enter your favorite color (e.g., red, blue, green):");
    while (!['red', 'blue', 'green'].includes(color.toLowerCase())) {
        alert("Invalid color. Please enter red, blue, or green.");
        color = prompt("Enter your favorite color (e.g., red, blue, green):");
    }

    div.innerHTML = `
    <div style="text-align: center; color: ${color === 'red' ? 'tomato' : color === 'blue' ? '#09c' : '#28a745'};">
        <h2>User Information</h2>
        <p>Hello user ${name}</p>
        <p>Your email is ${email}</p>
        <p>Your phone number is ${phone}</p>
        <p>Your mobile number is ${mobile}</p>
        <p>Today is ${date}</p>
    </div>
    `;

}



validateFields();




// countCharOccurrences();
// checkPalindrome();
// getLargestWord();
