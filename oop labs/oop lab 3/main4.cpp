#include <iostream>
#include <string> 
using namespace std;

int main()
{
    string input;
    int sum = 0;

    cout << "Enter 6 integer values (as strings):\n";

    for (int i = 1; i <= 6; i++)
    {
        cout << "Value " << i << ": ";
        cin >> input;

        int number = stoi(input);

        sum += number;
    }

    double average = sum / 6.0;

    cout << "\nSum = " << sum << endl;
    cout << "Average = " << average << endl;

    return 0;
}
