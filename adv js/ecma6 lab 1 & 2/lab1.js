let numbers = [23, 67, 12, 89, 45, 55, 3, 100, 72];

// sort ascending
let ascending = [...numbers].sort((a, b) => a - b);
console.log("Ascending:", ascending);

// sort descending
let descending = [...numbers].sort((a, b) => b - a);
console.log("Descending:", descending);

// filter numbers larger than 50
let largerThan50 = numbers.filter(n => n > 50);
console.log("Numbers > 50:", largerThan50);

// display max and min 
let maxNumber = Math.max(...numbers);
let minNumber = Math.min(...numbers);
console.log("Max:", maxNumber, "Min:", minNumber);




function calculate(operator, ...numbers) {
    let result;

    switch (operator) {
        case "sum":
            result = numbers.reduce((acc, n) => acc + n, 0);
            break;
        case "multiply":
            result = numbers.reduce((acc, n) => acc * n, 1);
            break;
        case "subtract":
            result = numbers.reduce((acc, n) => acc - n);
            break;
        case "divide":
            result = numbers.reduce((acc, n) => acc / n);
            break;
        default:
            console.log("Unknown");
            return;
    }

    console.log(`Result is ${result}`);
}









let projectId = prompt("Enter Project ID:");
let projectName = prompt("Enter Project Name:");
let duration = prompt("Enter Project Duration");

const project = {
    projectId,
    projectName,
    duration,
    printData() {
        console.log("Project Data:");
        console.log("ID:", this.projectId);
        console.log("Name:", this.projectName);
        console.log("Duration:", this.duration);
    }
};

project.printData();