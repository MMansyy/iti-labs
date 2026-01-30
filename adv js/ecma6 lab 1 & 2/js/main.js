import car from "./car.js";
import ev from "./ev.js";
import rectangle from "./rectangle.js";
import square from "./square.js";


let shapes = [
    new rectangle("red", 5, 10),
    new square("blue", 4),
    new rectangle("green", 3, 7),
    new square("yellow", 6)
];


// shapes.forEach((shape) => console.log(shape.calcArea()))

// console.log(rectangle.rectNum);
// console.log(square.squareNum);



let car1 = new car("MERCEDES");
let car2 = new car("BMW");
let car3 = new car("BMW");

car1.accelerate();
car1.accelerate();
car1.brake();


car2.accelerate();
car2.brake();


// car.carInfo(car1);
// car.carInfo(car2);
// car.carInfo(car3); 



let tesla = new ev("Tesla", 120, 23);
tesla.accelerate(); 
tesla.brake(); 
tesla.chargeBattery(90); 
tesla.accelerate(); 
