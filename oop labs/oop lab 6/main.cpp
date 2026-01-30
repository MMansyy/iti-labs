/// make me class points that represents a 2D point with x and y coordinates
/// include member functions to set and get the coordinates
#include <iostream>
#include <cmath>
using namespace std;
class Point
{
    double x;
    double y;

public:
    // Constructor
    Point(double xCoord = 0, double yCoord = 0)
    {
        x = xCoord;
        y = yCoord;
    }

    void setX(double xCoord)
    {
        x = xCoord;
    }
    void setY(double yCoord)
    {
        y = yCoord;
    }
    double getX()
    {
        return x;
    }
    double getY()
    {
        return y;
    }
    void display()
    {
        cout << "Point(" << x << ", " << y << ")" << endl;
    }
};

class Rectangle_Composition
{
    Point p1;
    Point p2;
    double width, height, area;

public:
    Rectangle_Composition(double x1, double y1, double x2, double y2) : p1(x1, y1), p2(x2, y2)
    {
        width = abs(x2 - x1);
        height = abs(y2 - y1);
        area = width * height;
    }
    Rectangle_Composition() : p1(0, 0), p2(1, 1)
    {
        width = 1;
        height = 1;
        area = 1;
    }
    double getWidth()
    {
        return width;
    }
    double getHeight()
    {
        return height;
    }
    double getArea()
    {
        return area;
    }
    void setP1(double x1, double y1)
    {
        p1.setX(x1);
        p1.setY(y1);
        width = abs(p2.getX() - x1);
        height = abs(p2.getY() - y1);
        area = width * height;
    }
    void setP2(double x2, double y2)
    {
        p2.setX(x2);
        p2.setY(y2);
        width = abs(x2 - p1.getX());
        height = abs(y2 - p1.getY());
        area = width * height;
    }
    Point getP1()
    {
        return p1;
    }
    Point getP2()
    {
        return p2;
    }
};

class Rectangle_Association
{
    Point *p1;
    Point *p2;
    double width, height, area;

public:
    Rectangle_Association()
    {
        p1 = nullptr;
        p2 = nullptr;
        width = 1;
        height = 1;
        area = 1;
    };

    Rectangle_Association(Point *point1, Point *point2) : p1(point1), p2(point2)
    {
        if (p1 != nullptr && p2 != nullptr)
        {
            width = abs(p2->getX() - p1->getX());
            height = abs(p2->getY() - p1->getY());
            area = width * height;
        }
    }
    double getWidth()
    {
        return width;
    }
    double getHeight()
    {
        return height;
    }
    double getArea()
    {
        return area;
    }
    void setP1(Point *point1)
    {
        p1 = point1;
        if (p1 != nullptr && p2 != nullptr)
        {
            width = abs(p2->getX() - p1->getX());
            height = abs(p2->getY() - p1->getY());
            area = width * height;
        };
    }
    void setP2(Point *point2)
    {
        p2 = point2;
        if (p1 != nullptr && p2 != nullptr)
        {
            width = abs(p2->getX() - p1->getX());
            height = abs(p2->getY() - p1->getY());
            area = width * height;
        };
    };
};



int main()
{
    cout << "=== Testing Rectangle_Composition ===" << endl;

    // Composition object (the rectangle owns the points)
    Rectangle_Composition compRect(1, 2, 4, 6);

    cout << "Initial Composition Rectangle:" << endl;
    cout << "Width: " << compRect.getWidth() << endl;
    cout << "Height: " << compRect.getHeight() << endl;
    cout << "Area: " << compRect.getArea() << endl;

    // Update p1 and p2
    compRect.setP1(0, 0);
    compRect.setP2(5, 5);

    cout << "\nAfter updating points (Composition):" << endl;
    cout << "Width: " << compRect.getWidth() << endl;
    cout << "Height: " << compRect.getHeight() << endl;
    cout << "Area: " << compRect.getArea() << endl;

    cout << "\n\n=== Testing Rectangle_Association ===" << endl;

    // Create two points on the stack
    Point a(2, 3);
    Point b(8, 10);

    // Association rectangle (just uses pointers to existing points)
    Rectangle_Association assocRect(&a, &b);

    cout << "Initial Association Rectangle:" << endl;
    cout << "Width: " << assocRect.getWidth() << endl;
    cout << "Height: " << assocRect.getHeight() << endl;
    cout << "Area: " << assocRect.getArea() << endl;

    a.setX(0);
    a.setY(0);

    b.setX(6);
    b.setY(6);

    cout << "\nAfter changing original points (Association):" << endl;
    cout << "Width: " << assocRect.getWidth() << endl;
    cout << "Height: " << assocRect.getHeight() << endl;
    cout << "Area: " << assocRect.getArea() << endl;

    return 0;
}
