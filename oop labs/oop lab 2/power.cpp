#include <iostream>
using namespace std;

int power(int base, int exponent)
{
    if (exponent == 0)
    {
        return 1;
    }
    return base * power(base, exponent - 1);
}

int main()
{
    int base, exponent;
    cout << "Enter base : ";
    cin >> base ;
    cout << "Enter exponent : ";
    cin >> exponent ;
    cout << base << " power " << exponent << " is " << power(base, exponent) << endl;

    return 0;
}