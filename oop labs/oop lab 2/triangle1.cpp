#include <iostream>
#include <cmath>
using namespace std;

double calculateHypotenuse(double sideA, double sideB)
{
    return sqrt(sideA * sideA + sideB * sideB);
}

int main()
{
    double sideA, sideB;
    cout << "Enter length of side A: ";
    cin >> sideA;
    cout << "Enter length of side B: ";
    cin >> sideB;
    double hypotenuse = calculateHypotenuse(sideA, sideB);
    cout << "The length of the hypotenuse is: " << hypotenuse << endl;
    return 0;
}