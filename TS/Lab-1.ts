type Product = {
    name: string;
    price: number;
};

enum Category {
    Electronics = "Electronics",
    Food = "Food",
}

function getProductInfo(product: Product, discount: number | string): string {
    return `${product.name} costs ${product.price} - Discount: ${discount}`;
}

const item: Product = {
    name: "Laptop",
    price: 1000,
};

console.log(getProductInfo(item, 10));



class Point2D {
    constructor(public x: number, public y: number) { }


    distanceBetween(other: Point2D): number {
        let dx = this.x - other.x;
        let dy = this.y - other.y;
        return Math.sqrt(dx * dx + dy * dy);
    }
}

class Point3D extends Point2D {
    z: number;

    constructor(x: number, y: number, z: number) {
        super(x, y);
        this.z = z;
    }

    distanceTo(point: Point3D): number {
        const dx = point.x - this.x;
        const dy = point.y - this.y;
        const dz = point.z - this.z;

        return Math.sqrt(dx * dx + dy * dy + dz * dz);
    }
}