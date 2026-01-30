#include <iostream>
#include <cmath>
using namespace std;

int isRightAngled(double sideA, double sideB, double sideC)
{
    if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
    {
        return -1;
    }
    if (sideA * sideA + sideB * sideB == sideC * sideC ||
        sideA * sideA + sideC * sideC == sideB * sideB ||
        sideB * sideB + sideC * sideC == sideA * sideA)
    {
        return 1;
    }
    else
    {
        return 0;
    }
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

    int result = isRightAngled(sideA, sideB, sideC);
    if (result == 1)
    {
        cout << "The triangle is right-angled." << endl;
    }
    else if (result == 0)
    {
        cout << "The triangle is not right-angled." << endl;
    }
    else
    {
        cout << "Error: The lengths do not form a valid triangle." << endl;
    }

    return 0;
}