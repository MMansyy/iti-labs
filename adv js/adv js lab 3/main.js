

function Shape(color) {
    if (this.constructor.name == 'Shape') {
        throw new Error("this is Abstract Class");
    }
    this.color = color
}

Shape.prototype.printColor = function () {
    console.log("Color:", this.color);
};

Shape.prototype.calcArea = function () {
    return 0;
};

Shape.prototype.calcPerimeter = function () {
    return 0;
};

function Rectangle(color, width, height) {
    Shape.call(this, color);
    this.width = width;
    this.height = height;
    Rectangle.NumberOfRect++;
}

Rectangle.prototype = Object.create(Shape.prototype);
Rectangle.prototype.constructor = Rectangle;

Rectangle.prototype.calcArea = function () {
    return this.width * this.height;
};

Rectangle.prototype.calcPerimeter = function () {
    return 2 * (this.width + this.height);
};

Rectangle.prototype.printColor = function () {
    console.log("Rectangle Color:", this.color);
};

Rectangle.prototype.toString = function () {
    return `Rectangle Color: ${this.color}, Area: ${this.calcArea()}, Perimeter: ${this.calcPerimeter()}`;
};

Rectangle.NumberOfRect = 0


function Square(color, width) {
    Rectangle.call(this, color, width, width);
    Square.NumberOfSquares++;
}

Square.prototype = Object.create(Rectangle.prototype);
Square.prototype.constructor = Square;

Square.prototype.calcArea = function () {
    return this.width * this.width;
};

Square.prototype.calcPerimeter = function () {
    return 4 * this.width;
};

Square.prototype.printColor = function () {
    console.log("Square Color:", this.color);
};

Square.prototype.toString = function () {
    return `Square Color: ${this.color}, Area: ${this.calcArea()}, Perimeter: ${this.calcPerimeter()}`;
};

Square.NumberOfSquares = 0;

let r = new Rectangle('red', 5, 10)

let s = new Square('red', 5)

console.log(s);

let shapes = [
    new Rectangle("red", 5, 10),
    new Square("blue", 4),
    new Rectangle("green", 3, 7),
    new Square("yellow", 6)
];

shapes.forEach((ele) => console.log(`${ele.constructor.name} shape ${ele.calcArea()}`))

console.log(Rectangle.NumberOfRect);
console.log(Square.NumberOfSquares);


////////////////////////
/////   part two   ////
//////////////////////


function Car(name, speed) {
    this.name = name
    this.speed = speed
}


Car.prototype.accelerate = function () {
    this.speed += 10;
    return 'Speed : ' + this.speed;
}
Car.prototype.brake = function () {
    this.speed -= 5;
    return 'Speed : ' + this.speed;
}

let bmw = new Car('bmw', 100)
let mercedes = new Car('mercedes', 80)

console.log(bmw.accelerate());  //110
console.log(mercedes.accelerate()); //90
console.log(mercedes.accelerate()); //100
console.log(bmw.brake());   //105
console.log(mercedes.brake());  //95



//////////////////
/// part tree ///
////////////////

function Ev(name, speed, charge) {
    Car.call(this, name, speed);
    this.charge = charge;
}

Ev.prototype = Object.create(Car.prototype)
Ev.prototype.constructor = Ev

Ev.prototype.chargeBattery = function (num) {
    this.charge = num
    return 'Current capacity ' + this.charge
}

Ev.prototype.accelerate = function () {
    this.speed += 20;
    this.charge -= 1;
    return `${this.name} going at ${this.speed} km/h, with a charge of ${this.charge}%`
}


let tesla = new Ev('Tesla', 100, 50)

console.log(tesla.accelerate());
console.log(tesla.accelerate());
console.log(tesla.accelerate());
console.log(tesla.brake());
console.log(tesla.brake());
console.log(tesla.chargeBattery(90));
console.log(tesla.accelerate());
console.log(tesla.brake());

