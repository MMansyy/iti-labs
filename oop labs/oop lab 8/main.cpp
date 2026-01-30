#include <iostream>
using namespace std;

class Shape
{
protected:
    double dim_1, dim_2;

public:
    Shape(double a = 0, double b = 0)
    {
        dim_1 = a;
        dim_2 = b;
    }

    void setDim1(double a)
    {
        dim_1 = a;
    }
    void setDim2(double b)
    {
        dim_2 = b;
    }
    double getDim1()
    {
        return dim_1;
    }
    double getDim2()
    {
        return dim_2;
    }

    virtual double area() = 0;
};

class Rectangle : public Shape
{
public:
    Rectangle(double a = 0, double b = 0) : Shape(a, b) {}

    double area()
    {
        return dim_1 * dim_2;
    }
};

class Triangle : public Shape
{
public:
    Triangle(double a = 0, double b = 0) : Shape(a, b) {}

    double area()
    {
        return 0.5 * dim_1 * dim_2;
    }
};

class Circle : public Shape
{
public:
    Circle(double r = 0) : Shape(r, 0) {}

    double area()
    {
        return 3.14 * dim_1 * dim_1;
    }
};

class Square : public Rectangle
{
public:
    Square(double a = 0) : Rectangle(a, a) {}
};

class GeoShape
{
    Shape *shape[4];

public:
    GeoShape(Shape *p1, Shape *p2, Shape *p3, Shape *p4)
    {
        shape[0] = p1;
        shape[1] = p2;
        shape[2] = p3;
        shape[3] = p4;
    }

    double totalArea()
    {
        double total = 0;
        for (int i = 0; i < 4; i++)
        {
            total += shape[i]->area();
        }
        return total;
    }
};

int main()
{
    Rectangle rect(4, 5);
    Triangle tri(4, 5);
    Circle cir(3);
    Square sqr(4);

    GeoShape geo(&rect, &tri, &cir, &sqr);
    cout << "Total Area: " << geo.totalArea() << endl;

    return 0;
}