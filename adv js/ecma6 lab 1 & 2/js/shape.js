
class shape {
    #color;


    constructor(color) {
        if (this.constructor == shape) {
            throw new Error('this is an abstract class');
        }
        this.#color = color
    }

    get color() {
        return this.#color
    }
    set color(_color) {
        this.#color = _color
    }
    printColor() {
        console.log("Color:", this.#color);
    }
    calcArea() {
        return 0;
    }
    calcPerimeter() {
        return 0;
    }
}

export default shape;