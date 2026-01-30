#include <iostream>
using namespace std;

int digitSum(int number)
{
    int sum = 0;
    while (number != 0)
    {
        sum += number % 10;
        number /= 10;
    }
    return sum;
}

int main()
{
    int number;
    cout << "Enter a non-negative integer: ";
    cin >> number;
    if (number < 0)
    {
        cout << "Please enter a non-negative integer." << endl;
        return -1;
    }
    cout << "The sum of the digits is: " << digitSum(number) << endl;
    return 0;
}