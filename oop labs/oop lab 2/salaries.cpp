#include <iostream>
using namespace std;

int main()
{
    int counters[9] = {0};
    double sales;
    int salary;

    while (true)
    {
        cout << "Enter salesperson's gross sales (enter -1 to stop): " << endl;
        cin >> sales;

        if (sales == -1)
            break;

        salary = (int)(200 + (0.09 * sales));

        if (salary >= 200 && salary <= 299)
            counters[0]++;
        else if (salary <= 399)
            counters[1]++;
        else if (salary <= 499)
            counters[2]++;
        else if (salary <= 599)
            counters[3]++;
        else if (salary <= 699)
            counters[4]++;
        else if (salary <= 799)
            counters[5]++;
        else if (salary <= 899)
            counters[6]++;
        else if (salary <= 999)
            counters[7]++;
        else
            counters[8]++;
    }

    cout << "Salary Distribution:" << endl;
    cout << "$200-299: " << counters[0] << endl;
    cout << "$300-399: " << counters[1] << endl;
    cout << "$400-499: " << counters[2] << endl;
    cout << "$500-599: " << counters[3] << endl;
    cout << "$600-699: " << counters[4] << endl;
    cout << "$700-799: " << counters[5] << endl;
    cout << "$800-899: " << counters[6] << endl;
    cout << "$900-999: " << counters[7] << endl;
    cout << "$1000 and over: " << counters[8] << endl;

    return 0;
}
