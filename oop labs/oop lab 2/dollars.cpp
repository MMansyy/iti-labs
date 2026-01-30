#include <iostream>
using namespace std;

double toYen(double dollars)
{
    return dollars * 118.87;
}

double toEuro(double dollars)
{
    return dollars * 0.92;
}

int main()
{
    int loopLimit;
    cout << "Enter the number of dollars to convert : ";
    cin >> loopLimit;

    cout << "USD\tYEN\tEURO" << endl;
    cout << "----------------------\n";

    for (double i = 1; i <= loopLimit; i++)
    {
        cout << i << "\t" << toYen(i) << "\t" << toEuro(i) << endl;
    }

    return 0;
}
