import car from "./car.js";

class ev extends car {
    #charge;

    constructor(name, speed, charge) {
        super(name, speed);
        this.charge = charge;
    }

    get charge() {
        return this.#charge;
    }

    set charge(value) {
        if (value < 0) this.#charge = 0;
        else if (value > 100) this.#charge = 100;
        else this.#charge = value;
    }

    chargeBattery(chargeTo) {
        this.charge = chargeTo;
        console.log(`${this.name} charged to ${this.#charge}%`);
    }

    accelerate() {
        if (this.#charge <= 0) {
            console.log(`${this.name} cannot accelerate battery empty`);
            return;
        }

        this.speed += 20;
        this.#charge -= 1;
        if (this.#charge < 0) this.#charge = 0;

        console.log(
            `${this.name} going at ${this.speed} km/h, with a charge of ${this.#charge}%`
        );
    }
}

export default ev