let person = {
    id: 1,
    name: 'Mansy'
}


let employee = Object.create(person)

Object.defineProperty(employee, 'salary', {
    set(value) {
        this._s = value * 1.2;
    },
    get() {
        return this._s;
    },
    enumerable: true
});

employee.salary = 1000

console.log(employee);
console.log(employee.__proto__);


let HREmployee = Object.create(employee)

Object.defineProperty(HREmployee, 'location', {
    value: 'Alexandria'
})

console.log(HREmployee);

// direct parent
console.log(HREmployee.__proto__);

// parent of the parent
console.log(HREmployee.__proto__.__proto__);

//name and id
console.log(HREmployee.id + ' ', HREmployee.name);

Object.defineProperty(HREmployee, 'name', {
    value: 'HR . Mansy',
    writable: true,
    enumerable: true,
    configurable: true

})

Object.defineProperty(HREmployee, 'id', {
    value: 2,
    writable: true,
    enumerable: true,
    configurable: true
})

console.log(HREmployee)


// متغيرش لان الابن اللي غير نفسه مغيرش ابوه.
console.log(person)


Object.defineProperty(person, 'age', {
    value: 23
})


console.log(person)

// can access it
console.log(HREmployee.age)



//////////////////////////////////////////////////////////////////////



let person2 = {};

Object.defineProperties(person2, {
    id: {
        value: 1,
        writable: true,
        enumerable: true,
        configurable: true
    },
    name: {
        value: "Mansy",
        writable: true,
        enumerable: true,
        configurable: true
    }
});


let employee2 = Object.create(person2);

Object.defineProperties(employee2, {
    salary: {
        set(value) {
            this._salary = value * 1.2;
        },
        get() {
            return this._salary;
        },
        enumerable: true,
        configurable: true
    }
});

employee2.salary = 1000;


let HREmployee2 = Object.create(employee2);

Object.defineProperties(HREmployee2, {
    location: {
        value: "Alexandria",
        writable: true,
        enumerable: true,
        configurable: true
    }
});


console.log(HREmployee2.__proto__);
console.log(HREmployee2.__proto__.__proto__);


console.log(HREmployee2.id, HREmployee2.name);


Object.defineProperties(HREmployee2, {
    id: {
        value: 2,
        writable: true,
        enumerable: true,
        configurable: true
    },
    name: {
        value: "HR . Mansy",
        writable: true,
        enumerable: true,
        configurable: true
    }
});

console.log(HREmployee2.id, HREmployee2.name);


console.log(person2.id, person2.name);


Object.defineProperties(person2, {
    age: {
        value: 23,
        writable: true,
        enumerable: true,
        configurable: true
    }
});

// Can access from HREmployee2
console.log(HREmployee2.age);



// part two

//1
let employees = [
    {
        name: "Mansy",
        age: 23,
        department: "PD",
        salary: 8000
    },
    {
        name: "Ahmed",
        age: 28,
        department: "OS",
        salary: 12000
    },
    {
        name: "Sara",
        age: 25,
        department: "AI",
        salary: 9500
    },
    {
        name: "Omar",
        age: 32,
        department: "CS",
        salary: 11000
    }
];


function employeeName() {
    return function (emp) {
        return emp.name
    }
}

let ename = employeeName()
console.log(ename(employees[0]))

//2
function createCounter() {
    let count = 0;
    return function () {
        count++;
        return count;
    }
}

let counter = createCounter()
console.log(counter())
console.log(counter())
console.log(counter())
console.log(counter())





//3
const btn = document.getElementById('btn')

function createCounterBg() {
    let count = 0;
    const colors = ["#ff9999", "#99ff99", "#9999ff", "#ffff99", "#ff99ff", "#99ffff"];
    return function () {
        count++;
        document.body.style.backgroundColor = colors[Math.floor(Math.random() * colors.length)];
        console.log('bg counter :' + count);
    }
}

let clickcounter = createCounterBg()

btn.addEventListener('click', clickcounter)



//4
function addFixed(num) {
    return function (fixed) {
        return fixed + num
    }
}

let MainNum = addFixed(10);
console.log(MainNum(10));
console.log(MainNum(20));
console.log(MainNum(90));

//5
function EmployeCount() {
    let count = 0;

    return function (emp) {
        employees.push(emp);
        count++;
        return { employees, count };
    }
}

let tracker = EmployeCount();
console.log(tracker({ name: 'mansy', salary: 3200 }))
console.log(tracker({ name: 'mansy', salary: 4200 }))


//6
function applyBonus(per) {
    return function (emp) {
        emp.salary = emp.salary + (emp.salary * (per / 100));
        return emp;
    };
}

let bouns = applyBonus(20)
console.log(bouns(employees[0]));

//7
function greeting(dep) {
    return function () {
        return `Hello ${dep} department`;
    }
}

let greets = greeting('IT');
console.log(greets());


//8
let empNames = employees.map((emp) => emp.name)
console.log(empNames.join(' & '));


//9
let empSal = employees.filter((emp) => emp.salary > 4500).map((emp) => emp.name + ' ' + emp.salary)
console.log(empSal);


//10
let total = employees.reduce((tot, emp) => tot + emp.salary, 0);
console.log(total);


//11
function increaseSalary(emp) {
    emp.salary = emp.salary * 1.1
    return emp
}
console.log(increaseSalary(employees[0]));


//12
let newEmployees = employees.map((emp) => emp).concat({ name: 'Eman', salary: 9000, age: 24, department: 'IT' })
console.log(newEmployees);


//13
function bounss(emp, perc) {
    emp.salary = emp.salary + emp.salary * (perc / 100)
    return emp
}


function applyBonus2(fn) {
    return function (emp, sal) {
        return fn(emp, sal)
    }
}

let x = applyBonus2(bounss)
let y = x(employees[4], 15)
console.log(y);


//14
let filterDep = (dep) => (emps) => emps.filter((emp) => emp.department == dep)
let m = filterDep('PD')
let z = m(employees)
console.log(z);

//15 
let newEmp = employees.map((emp) => ({ ...emp, salary: emp.salary * 1.05 }))
console.log(newEmp);
