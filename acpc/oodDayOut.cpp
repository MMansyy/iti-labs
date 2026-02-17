#include <iostream>
using namespace std;

int main()
{
    int x, y;
    cin >> x >> y;
    if (x >= 1 && x <= 100 && y >= 1 && y <= 100)
    {
        int z = x + y;
        if (z % 2 == 0)
        {
            cout << "NO" << endl;
        }
        else
        {
            cout << "YES" << endl;
        }
    } else {
        cout << "Input values must be between 1 and 100." << endl;
    }

    return 0;
}