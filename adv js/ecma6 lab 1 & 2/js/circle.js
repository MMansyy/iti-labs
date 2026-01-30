import shape from "./shape.js";

class circle extends shape {
    #x;
    #y;
    #radius;

    constructor(color, x, y, radius) {
        super(color);

        this.x = x;
        this.y = y;
        this.radius = radius;
    }

    get x() {
        return this.#x;
    }

    set x(value) {
        this.#x = value;
    }

    get y() {
        return this.#y;
    }

    set y(value) {
        this.#y = value;
    }

    get radius() {
        return this.#radius;
    }

    set radius(value) {
        if (value <= 0) {
            console.log("must be greater than zerooooo");
            return;
        }
        this.#radius = value;
    }

    calcArea() {
        return Math.PI * this.#radius * this.#radius;
    }

    toString() {
        return `
                Circle Info:
                Color: ${this.color}
                Center: (${this.#x}, ${this.#y})
                Radius: ${this.#radius}
                Area: ${this.calcArea()}
                `;
    }
}

export default circle;
