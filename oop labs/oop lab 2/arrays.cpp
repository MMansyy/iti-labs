#include <iostream>
using namespace std;

int main()
{
    double sales[20];
    double allowance[75];
    int numbers[50] = {0};
    int GPA[10];

    for (int i = 0; i < 20; i++)
    {
        cin >> sales[i];
    }

    for (int i = 0; i < 75; i++)
    {
        allowance[i] += 1000;
    }

    for (int i = 0; i < 10; i++)
    {
        cout << GPA[i] << endl;
    }

    return 0;
}
