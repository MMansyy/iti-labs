class Example<T> {
    constructor(public value: T[]) { }

    pushData(item: T): void {
        this.value.push(item);
    }


    getData(): T[] {
        return this.value;
    }
}

const example = new Example<number>([1, 2, 3]);
example.pushData(4);
console.log(example.getData()); // Output: [1, 2, 3, 4]

const stringExample = new Example<string>(['Hello', 'World']);
stringExample.pushData('TypeScript');
console.log(stringExample.getData()); // Output: ['Hello', 'World', 'TypeScript']



// Decorator example // i used ai to get me an example here
function Log(target: any, propertyKey: string, descriptor: PropertyDescriptor) {
    const originalMethod = descriptor.value;
    descriptor.value = function (...args: any[]) {        console.log(`Method ${propertyKey} called with arguments: ${args.join(', ')}`);
        return originalMethod.apply(this, args);
    }
}

class Calculator {
    @Log
    add(a: number, b: number): number {
        return a + b;
    }
}

const calculator = new Calculator();
console.log(calculator.add(5, 3)); // Output: Method add called with arguments: 5, 3