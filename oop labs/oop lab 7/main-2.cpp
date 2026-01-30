#include <iostream>
#include <cstring>
using namespace std;

class Base {
protected:
    int z;
public:
    Base () {
        z = 0;
    };
    Base(int pz)  {
        z = pz;
    };
    int getZ() const {
        return z;
    }
    void setZ(int pz) {
        z = pz;
    }

};

class Base_1 : virtual public Base {
    protected:
        int x;
    public:
        Base_1()  {
            x = 0;
        };
        Base_1(int px, int pz) : Base(pz) {
            x = px;
        };
        int getX() const {
            return x;
        }
        void setX(int px) {
            x = px;
        }
};


class Base_2 : virtual public Base {
    protected:
        int y;
    public:
        Base_2()  {
            y = 0;
        };
        Base_2(int py, int pz) : Base(pz) {
            y = py;
        };
        int getY() const {
            return y;
        }
        void setY(int py) {
            y = py;
        }
};

class Derived : public Base_1, public Base_2 {
    public:
        Derived()  {
        };
        Derived(int px, int py, int pz) : Base_1(px, pz), Base_2(py, pz) , Base(pz) {
        };
        int product () {
            return x*y*z;
        }
        void display() {
            cout << "X: " << x << ", Y: " << y << ", Z: " << z  << " Product of x y z: " << product() << endl;
        }
};


int main() {
    Derived d(2, 3, 4);
    d.display();
    return 0;
}