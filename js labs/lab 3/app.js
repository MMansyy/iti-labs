function calculateArea() {
    let r = prompt("Enter the radius of the circle:");
    if (isFinite(r) && r !== null) {
        let area = Math.PI * Number(r) * Number(r);
        alert("The area of the circle is: " + area.toFixed(4));
        return
    }
    alert("Invalid input. Please enter a numeric value for the radius.");
}

function calculateSqureRoot() {
    let num = prompt("Enter a number to find its square root:");
    if (isFinite(num) && num !== null) {
        let sqrt = Math.sqrt(Number(num));
        alert("The square root of " + num + " is: " + sqrt.toFixed(2));
        return
    }
    alert("Invalid input. Please enter a numeric value.");
}

function CalculateCosine() {
    let angle = prompt("Enter an angle in degrees to find its cosine:");
    if (isFinite(angle) && angle !== null) {
        let cosine = Math.cos(angle * (Math.PI / 180));
        alert("The cosine of " + angle + " degrees is: " + cosine.toFixed(4));
        return
    }
    alert("Invalid input. Please enter a numeric value for the angle.");
}

function printOddNumbers(start, end) {
    let result = "Odd number between " + start + " and " + end + " are: \n";
    for (let i = start; i <= end; i++) {
        if (i % 2 !== 0) {
            result += i + " ";
        }
    }
    alert(result);
}

function tipOfTheDayInJs() {
    const tips = [
        "Use '===' instead of '==' for strict equality checks.",
        "Always declare variables with 'let' or 'const' to avoid global scope pollution.",
        "Use template literals for easier string interpolation.",
        "Take advantage of arrow functions for concise function expressions.",
        "Use 'Array.prototype.map()' for transforming arrays."
    ];
    const randomIndex = Math.floor(Math.random() * tips.length);
    alert("Tip of the Day: " + tips[randomIndex]);
}

function evaluteExpression() {
    let expression = prompt("Enter a mathematical expression to evaluate with only one operator (e.g., 2 + 3):");
    const operatorPattern = /[\+\-\*\/]/;
    const match = expression.match(operatorPattern);
    if (match) {
        const operator = match[0];
        const operands = expression.split(operator);
        if (operands.length === 2) {
            const num1 = Number(operands[0].trim());
            const num2 = Number(operands[1].trim());
            let result;
            switch (operator) {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 !== 0) {
                        result = num1 / num2;
                    } else {
                        alert("Error: Division by zero is not allowed.");
                        return;
                    }
                    break;
                default:
                    alert("Invalid operator.");
                    return;
            }
            alert("The result of " + expression + " is: " + result);
            return;
        } else {
            alert("Invalid expression format. Please enter a valid expression with two operands and one operator.");
        }
    }
}



function reverseParamsOne(...params) {
    return params.reverse();
}

function reverseParamsTwo() {
    return Array.from(arguments).reverse();
}


function twoParamsOnly(a, b) {
    if (arguments.length < 2 || arguments.length > 2) {
        throw new Error("Function requires exactly 2 parameters");
    }
    return a + b;
}


function addNumbers(...numbers) {
    if (numbers.length === 0) {
        throw new Error("No parameters passed");
    }
    
    for (let i = 0; i < numbers.length; i++) {
        if (typeof numbers[i] !== "number") {
            throw new TypeError("All parameters must be numbers");
        }
    }
    
    return numbers.reduce((sum, num) => sum + num, 0);
}



// calculateArea();
// calculateSqureRoot();
// CalculateCosine();
// printOddNumbers(10, 50);
// tipOfTheDayInJs();
// evaluteExpression();
// console.log("Method 1:", reverseParamsOne(1, 2, 3, 4, 5));
// console.log("Method 2:", reverseParamsTwo("a", "b", "c", "d"));
