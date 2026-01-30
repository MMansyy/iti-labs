#include <iostream>
using namespace std;

// make two function one take a int as a reference and other take int as value
void mansy(int a)
{
    a = a + 10;
}
void mansy(int &a)
{
    a = a + 10;
}

int main()
{
    int num1 = 5;
    int num2 = 5;

    mansy(num1);
    mansy(num2);

    cout << "After modifyByValue, num1: " << num1 << endl; // should print 5
    cout << "After modifyByReference, num2: " << num2 << endl; // should print 15

    return 0;
}