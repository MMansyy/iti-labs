import shape from "./shape.js";


class rectangle extends shape {
    #width;
    #height;

    static rectNum = 0

    constructor(color, width, height) {
        super(color);
        this.width = width;
        this.height = height;
        rectangle.rectNum++;
    }


    get height() {
        return this.#height
    }

    get width() {
        return this.#width
    }

    set height(h) {
        if (h <= 0) {
            throw new Error('must be greater that zeroooo')
        }
        this.#height = h
    }

    set width(w) {
        if (w <= 0) {
            throw new Error('must be greater that zeroooo')
        }
        this.#width = w
    }

    calcArea() {
        return this.#width * this.#height;
    }

    calcPerimeter() {
        return 2 * (this.#width + this.#height);
    }

    printColor() {
        console.log("Rectangle Color:", this.color);
    }
}

export default rectangle;