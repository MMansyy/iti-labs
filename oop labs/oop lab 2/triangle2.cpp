#include <iostream>
#include <cmath>
using namespace std;

double calculateArea(double sideA, double sideB, double sideC)
{
    if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
    {
        cout << "Error: msh triamgle da mthzrsh y3m" << endl;
        return 0.0;
    }
    double s = (sideA + sideB + sideC) / 2.0;
    return sqrt(s * ((s - sideA) * (s - sideB) * (s - sideC)));
}

int main()
{
    double sideA, sideB, sideC;
    cout << "Enter length of side A: ";
    cin >> sideA;
    cout << "Enter length of side B: ";
    cin >> sideB;
    cout << "Enter length of side C: ";
    cin >> sideC;
    double area = calculateArea(sideA, sideB, sideC);
    if (area > 0.0 && sideA > 0 && sideB > 0 && sideC > 0)
    {
        cout << "The area of the triangle is: " << area << endl;
    }

    return 0;
}