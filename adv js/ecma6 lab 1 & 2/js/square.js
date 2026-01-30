import rectangle from "./rectangle.js";

class square extends rectangle {
    static squareNum = 0
    constructor(color, side) {
        super(color, side, side)
        square.squareNum++;
    }

    get side() {
        return this.width
    }
    set side(s) {
        this.width = s
        this.height = s
    }

    toString() {
        return `
                Square Info:
                Color: ${this.color}
                Area: ${this.calcArea()}
                Perimeter: ${this.calcPerimeter()}
                `;
    }
}

export default square;
