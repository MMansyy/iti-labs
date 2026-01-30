class car {
    #serial
    #name
    #speed

    static createdCars = 0;
    constructor(name, speed) {
        let randomSerial = Math.floor(Math.random() * 1000)
        this.#serial = randomSerial;
        this.name = name
        this.speed = speed
        car.createdCars++;
    }

    get serial() {
        return this.#serial
    }

    get speed() {
        return this.#speed
    }

    get name() {
        return this.#name
    }

    set speed(h) {
        if (h <= 0) {
            throw new Error('must be greater that zeroooo')
        }
        this.#speed = h
    }

    set name(w) {
        this.#name = w
    }

    accelerate() {
        this.speed += 10;
        return 'Speed : ' + this.speed;
    }

    brake() {
        this.speed -= 5;
        return 'Speed : ' + this.speed;
    }

    static carInfo(_car) {
        console.log(
            `Car Serial: ${_car.serial}, Total Cars: ${car.createdCars}, Speed: ${_car.speed}`
        );
    }
}


export default car;