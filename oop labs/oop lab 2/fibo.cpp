#include <iostream>
using namespace std;

unsigned long long fib(int n)
{
    unsigned long long a = 0, b = 1, c;
    if (n == 0)
        return a;
    if (n == 1)
        return b;
    for (int i = 2; i <= n; i++){
        c = a + b;
        a = b;
        b = c;
    }
    return c;
}

int main()
{
    int n;
    cout << "Enter a positive integer: ";
    cin >> n;
    cout << "Fibonacci number at position " << n << " is " << fib(n) << endl;

    return 0;
}